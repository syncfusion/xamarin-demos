#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using Syncfusion.XForms.Chat;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SampleBrowser.SfChat
{
    /// <summary>
    /// A Class used to communicate with Azure bot service.
    /// </summary>
    public class BotService
    {
        /// <summary>
        /// Http client.
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        /// Conversation details.
        /// </summary>
        private Conversation conversation;

        /// <summary>
        /// Direct line address to establish connection.
        /// </summary>
        private string BotBaseAddress = "https://directline.botframework.com/v3/directline/conversations/";

        /// <summary>
        /// Direct line key to establish connection to syncfusion bot.
        /// </summary>
        private string directLineKey = "XYeLq1aytPw.4wbtMs2r7XEzdkG2_wyxGpP676wpfFS_hSaSJW8IjQg";

        /// <summary>
        /// water mark used to get newly added message or actvity.
        /// </summary>
        private string watermark = string.Empty;

        /// <summary>
        /// Initializes a new instance of <see cref="BotService"/> class.
        /// </summary>
        /// <param name="viewModel">view model as paramter.</param>
        public BotService(FlightBookingViewModel viewModel)
        {
            this.ViewModel = viewModel;
            InitializeHttpConnection();
        }

        /// <summary>
        /// Gets or set the flight booking view model.
        /// </summary>
        internal FlightBookingViewModel ViewModel { get; set; }

        /// <summary>
        /// Checks internet connection state.
        /// </summary>
        /// <returns>true if internet connection is established else false.</returns>
        internal bool CheckInternetConnection()
        {
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                this.ViewModel.IsConnectionNotEstablished = false;
                return true;
            }
            else
            {
                this.ViewModel.ShowBusyIndicator = false;
                this.ViewModel.IsConnectionNotEstablished = true;
                return false;
            }
        }

        /// <summary>
        /// Raised when internet connection is changed.
        /// </summary>
        /// <param name="sender">object as sender</param>
        /// <param name="e">ConnectivityChangedEventArgs as e</param>
        internal async void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                this.ViewModel.IsConnectionNotEstablished = false;
                if (this.conversation == null || (this.conversation != null && string.IsNullOrEmpty(this.conversation.ConversationId)))
                {
                    this.ViewModel.ShowBusyIndicator = true;
                    SetupConversation();
                }
                else
                {
                    await this.ReadMessageFromBot();
                    this.ViewModel.ShowBusyIndicator = false;
                }
            }
            else
            {
                this.ViewModel.ShowBusyIndicator = false;
                this.ViewModel.IsConnectionNotEstablished = true;
            }
        }
        
        /// <summary>
        /// Activity is created and message is send to bot.
        /// </summary>
        /// <param name="text">text from current user.</param>
        internal void SendMessageToBot(string text)
        {
            Activity activity = new Activity()
            {
                From = new ChannelAccount()
                {
                    Id = this.ViewModel.CurrentUser.Name
                },

                Text = text,
                Type = "message"
            };

            PostActvityToBot(activity);
        }

        /// <summary>
        /// Reading bot response message.
        /// </summary>
        /// <returns></returns>
        internal async Task ReadMessageFromBot()
        {
            try
            {
                string conversationUrl = this.BotBaseAddress + this.conversation.ConversationId + "/activities?watermark=" + this.watermark;
                using (HttpResponseMessage messagesReceived = await this.httpClient.GetAsync(conversationUrl, HttpCompletionOption.ResponseContentRead))
                {
                    string messagesReceivedData = await messagesReceived.Content.ReadAsStringAsync();
                    ActivitySet messagesRoot = JsonConvert.DeserializeObject<ActivitySet>(messagesReceivedData);

                    if (messagesRoot != null)
                    {
                        this.watermark = messagesRoot.Watermark;
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            foreach (Activity activity in messagesRoot.Activities)
                            {
                                if (activity.From.Id == "ChatBot_Testing_Syncfusion" && activity.Type == "message")
                                {
                                    this.ProcessBotReplyAndAddMessage(activity);
                                }
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception while reading Bot activity. exception message - {0}", ex.Message);
            }

            this.ViewModel.ShowTypingIndicator = false;
            this.ViewModel.ShowBusyIndicator = false;
        }

        /// <summary>
        /// Initialize the Http client and initiate conversation if internet connection is available.
        /// </summary>
        private void InitializeHttpConnection()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri(this.BotBaseAddress);
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.directLineKey);
            this.httpClient.Timeout = Timeout.InfiniteTimeSpan;

            if (CheckInternetConnection())
            {
                SetupConversation();
            }
        }

        /// <summary>
        /// Starts conversation to azure bot.
        /// </summary>
        private async void SetupConversation()
        {
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(new Conversation()), Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await this.httpClient.PostAsync("/v3/directline/conversations", contentPost);
                if (response.IsSuccessStatusCode)
                {
                    string conversationInfo = await response.Content.ReadAsStringAsync();
                    this.conversation = JsonConvert.DeserializeObject<Conversation>(conversationInfo);
                    await Task.Delay(2000);

                    Activity activity = new Activity();
                    activity.From = new ChannelAccount()
                    {
                        Id = ViewModel.CurrentUser.Name,
                        Name = ViewModel.CurrentUser.Name,
                    };

                    activity.Type = "add";
                    activity.Action = "add";
                    this.PostActvityToBot(activity);
                }
            }
            catch { }
        }

        /// <summary>
        /// current user message is passed to Bot. 
        /// </summary>
        /// <param name="activity"></param>
        private async void PostActvityToBot(Activity activity)
        {
            StringContent contentPost = new StringContent(JsonConvert.SerializeObject(activity), Encoding.UTF8, "application/json");
            string conversationUrl = this.BotBaseAddress + this.conversation.ConversationId + "/activities";

            try
            {
                await this.httpClient.PostAsync(conversationUrl, contentPost);
                await this.ReadMessageFromBot();
            }
            catch { }
        }

        /// <summary>
        /// Used to identify what type of message should be added in message collection. 
        /// </summary>
        /// <param name="activity">bot reply message is received as activity.</param>
        private void ProcessBotReplyAndAddMessage(Activity activity)
        {
            if (!string.IsNullOrEmpty(activity.Text))
            {
                if (activity.Text == "What else can I do for you?")
                {
                    return;
                }

                if (activity.Text == "When are you planning to travel?" || activity.Text == "Oops ! This doesn’t seem to be a valid date. Please select a valid date.")
                {
                    this.AddCalendarMessage(activity.Text);
                }
                else
                {
                    this.AddTextMessage(activity);
                }
            }
        }

        /// <summary>
        /// Text message is created and added to the message collection.
        /// </summary>
        /// <param name="text">new message text.</param>
        /// <param name="suggestedActions">suggestion value for message</param>
        private void AddTextMessage(Activity activity)
        {
            TextMessage message = new TextMessage();
            message.Text = activity.Text;
            message.Author = this.ViewModel.Bot;
            message.DateTime = DateTime.Now;

            if (activity.SuggestedActions != null && activity.SuggestedActions.Actions.Count > 0)
            {
                ChatSuggestions suggestions = new ChatSuggestions();
                var suggestionItems = new ObservableCollection<ISuggestion>();
                foreach (CardAction action in activity.SuggestedActions.Actions)
                {
                    var suggestion = new Suggestion();
                    suggestion.Text = action.Title;
                    suggestionItems.Add(suggestion);
                }

                suggestions.Items = suggestionItems;
                message.Suggestions = suggestions;
            }

            ViewModel.Messages?.Add(message);
        }

        /// <summary>
        /// Calendar message is created and added to the message collection.
        /// </summary>
        /// <param name="text">text for calendar message.</param>
        private void AddCalendarMessage(string text)
        {
            DatePickerMessage message = new DatePickerMessage();
            message.Text = text;
            message.DateTime = DateTime.Now;
            message.Author = this.ViewModel.Bot;
            message.SelectedDate = DateTime.Now;
            ViewModel.Messages?.Add(message);
        }
    }
}

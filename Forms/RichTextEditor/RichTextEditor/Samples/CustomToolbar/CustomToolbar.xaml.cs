#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.RichTextEditor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CustomItem = Syncfusion.XForms.Buttons;

namespace SampleBrowser.SfRichTextEditor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomToolbar : SampleView
    {
        CustomItem.SfButton readOnlyButton;
        CustomItem.SfButton emojiButton;
        Button emojiButtonIOS;
        public CustomToolbar()
        {
            InitializeComponent();

            RTE.Text = "<p>Hi,<br><br>The rich text editor component is WYSIWYG (\"what you see is what you get\") editor that provides the best user experience to create and update the content.</p>";

            AddCustomToolbarItems();
        }

        private void AddCustomToolbarItems()
        {
            ObservableCollection<object> collection = new ObservableCollection<object>();
            collection.Add(ToolbarOptions.Bold);
            collection.Add(ToolbarOptions.Italic);
            collection.Add(ToolbarOptions.Underline);
            collection.Add(ToolbarOptions.Strikethrough);
            collection.Add(ToolbarOptions.NumberList);
            collection.Add(ToolbarOptions.BulletList);

            if (Device.RuntimePlatform != Device.iOS)
            {
                readOnlyButton = new CustomItem.SfButton();
                readOnlyButton.BackgroundColor = Color.Transparent;
                readOnlyButton.TextColor = Color.FromHex("#DE333333");
                if (Device.RuntimePlatform == Device.Android)
                {
                    readOnlyButton.HeightRequest = 44;
                    readOnlyButton.FontFamily = "Text edit 2.ttf#";
                    readOnlyButton.Text = "\ue702";
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    readOnlyButton.FontFamily = "Text edit 2.ttf#Text edit 2";
                    readOnlyButton.Text = "\ue700";
                }
                readOnlyButton.FontSize = 18;
                readOnlyButton.Clicked += ReadOnlyButton_Clicked;
                collection.Add(readOnlyButton);

                emojiButton = CreateButton("\U0001F642");
                emojiButton.VerticalTextAlignment = TextAlignment.Center;
                emojiButton.Clicked += EmojiButton_Clicked;
                if (Device.RuntimePlatform == Device.UWP)
                {
                    emojiButton.BorderColor = Color.Transparent;
                }

                collection.Add(emojiButton);
            }
            else
            {
                Button readonlyButtonIOS = new Button();
                readonlyButtonIOS.FontFamily = "Text edit 2";
                readonlyButtonIOS.Text = "\ue700";
                readonlyButtonIOS.TextColor = Color.FromHex("#DE333333");
                readonlyButtonIOS.Clicked += ReadonlyButtonIOS_Clicked; ;
                collection.Add(readonlyButtonIOS);

                emojiButtonIOS = new Button();
                emojiButtonIOS.Text = "\U0001F642";
                emojiButtonIOS.Clicked += EmojiButtonIOS_Clicked;
                collection.Add(emojiButtonIOS);
            }

            RTE.ToolbarItems = collection;
        }

        private void ReadonlyButtonIOS_Clicked(object sender, EventArgs e)
        {
            RTE.ReadOnly = !RTE.ReadOnly;
            emojiButtonIOS.IsEnabled = !RTE.ReadOnly;
            if (RTE.ReadOnly)
            {
                emojiButtonIOS.Opacity = 0.5;
                (sender as Button).Text = "\ue701";
            }
            else
            {
                emojiButtonIOS.Opacity = 1;
                (sender as Button).Text = "\ue700";
            }
        }

        private void EmojiButtonIOS_Clicked(object sender, EventArgs e)
        {
            RTE.InsertHTMLText("&#128522;");
        }

        CustomItem.SfButton CreateButton(string text)
        {
            CustomItem.SfButton button = new CustomItem.SfButton();
            if (Device.RuntimePlatform == Device.Android)
            {
                button.HeightRequest = 44;
            }
            button.BackgroundColor = Color.Transparent;
            button.TextColor = Color.FromHex("#DE333333");
            if (Device.RuntimePlatform == Device.Android)
            {
                button.FontFamily = "android";
                button.FontSize = 18;
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                button.FontFamily = "V3 Xamarin iOS uwp new.ttf#V3 Xamarin iOS uwp new";
            }
            button.Text = text;
            return button;
        }

        private void EmojiButton_Clicked(object sender, EventArgs e)
        {
            RTE.InsertHTMLText("&#128522;");
        }

        private void ReadOnlyButton_Clicked(object sender, EventArgs e)
        {
            RTE.ReadOnly = !RTE.ReadOnly;
            emojiButton.IsEnabled = !RTE.ReadOnly;
            if (RTE.ReadOnly)
            {
                emojiButton.Opacity = 0.5;
                if (Device.RuntimePlatform == Device.Android)
                {
                    
                    readOnlyButton.Text = "\ue703";
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    emojiButton.BorderColor = Color.Default;
                    readOnlyButton.Text = "\ue701";
                }
            }
            else
            {
                emojiButton.Opacity = 1;
                if (Device.RuntimePlatform == Device.Android)
                {
                    readOnlyButton.Text = "\ue702";
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    emojiButton.BorderColor = Color.Transparent;
                    readOnlyButton.Text = "\ue700";
                }
            }
        }
    }
}
#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
namespace SampleBrowser.SfNavigationDrawer
{
	public class MenuCollectionModel : INotifyPropertyChanged
	{
		public ObservableCollection<Message> MessageContent
		{
			get;
			set;
		}

		private string menuItem;
		public MenuCollectionModel()
		{
		}

		public string MenuItem
		{
			get
			{
				return menuItem;
			}

			set
			{
				menuItem = value;
			}
		}

		public string Icon
		{
			get;
			set;
		}
		private Color fontColor = Color.FromHex("#8e8e92");
		public Color FontColor
		{
			get

			{
				return fontColor;
			}
			set
			{
				fontColor = value;
				OnPropertyChanged("FontColor");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string name)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
	}

	public class Message
	{
		public string Sender
		{
			get;
			set;
		}

		public String Subject
		{
			get;
			set;
		}
		public String Content
		{
			get;
			set;
		}
		public String Date
		{
			get;
			set;
		}
		public Color SubjectColor
		{
			get;
			set;
		}

        public FontAttributes FontAttribute
		{
			get;
			set;
		}

		public String ContactType
		{
			get;
			set;
		}

		public String ContactImage
		{
			get;
			set;
		}
	}

	public class MenuCollectionViewModel
	{
		string[] MonthArray = new string[]
		{
			"Jan",
			"Jan",
			"Mar",
			"Apr",
			"May",
			"May",
			"May",
			"June",
			"July",
			"Sep",
			"Sep"
		};

		Random random = new Random();
		public MenuCollectionModel getItem(string item, string icon)
		{
			int randomValue = 0; 
			MenuCollectionModel mCollection = new MenuCollectionModel();
			mCollection.MessageContent = new ObservableCollection<Message>();
			for (int i = 0; i < 10; i++)
			{
				if (item == "Follow up")
				{
					if (i % 4 != 0)
						continue;
				}

				if (item == "Sent mail")
				{
					if (i % 4 != 0)
						continue;
				}


				if (item == "Trash ")
				{
					if (i % 3 == 0)
						continue;
				}

				randomValue = random.Next(0, 9);
				Message message = new Message();
				message.Sender = sender[i];
				message.Date = MonthArray[i] + " " + (i + 7).ToString();
                if (item != "Inbox")
                {
                    randomValue = random.Next(0, 29);
                    message.Subject = subject[randomValue];
                    message.Content = textContent[randomValue];
                }
                else{
					randomValue = i;
					message.Subject = subject[randomValue];
					message.Content = textContent[randomValue];
                }

                if(item == "Inbox" && i<7)
                {
                    message.SubjectColor = Color.FromHex("#006bcd");
                    message.FontAttribute = FontAttributes.Bold;
                    message.ContactImage ="People_Circle" + (i+1).ToString() + ".png";
                    message.ContactType = contactType[i];
                }
                else
                {
                    message.SubjectColor = Color.FromHex("#545659");
                    message.FontAttribute = FontAttributes.None;
                }
				mCollection.MessageContent.Add(message);
			}
			mCollection.MenuItem = item;
			mCollection.Icon = icon;
			return mCollection;
		}

		string[] contactType = new string[]
		{
            "Green.jpg",
            "Gray.jpg",
            "Yellow.jpg",
            "Red.jpg",
            "Orange_Shape.jpg",
            "Gray.jpg",
            "Green.jpg",
            "Green.jpg",
        };


		ObservableCollection<string> sender = new ObservableCollection<string>();
		ObservableCollection<string> subject = new ObservableCollection<string>();
		ObservableCollection<string> textContent = new ObservableCollection<string>();

		ObservableCollection<MenuCollectionModel> menuCollection;
		public MenuCollectionViewModel()
		{
			menuCollection = new ObservableCollection<MenuCollectionModel>();

            sender.Add("Adriana");
            sender.Add("Daleyza");
            sender.Add("Kyle");
            sender.Add("Victoriya");
            sender.Add("Steve");
            sender.Add("Briley");
            sender.Add("Maci");
            sender.Add("Zariah");
            sender.Add("Mckenna");
            sender.Add("Miranda");

			subject.Add("Goto Meeting");
			subject.Add("FW: Status Update");
			subject.Add("Greetings! Congrats");
			subject.Add("Report Monitor");
			subject.Add("News Letter");
			subject.Add("Conference about Latest Technology");
			subject.Add("RE: Status Update");
			subject.Add("Success! Report Automation");
			subject.Add("Monthly Reports Documents");
			subject.Add("Meeting Confirmation");

			subject.Add("Goto Meeting");
			subject.Add("FW: Status Update");
			subject.Add("Greetings! Congrats");
			subject.Add("Report Monitor");
			subject.Add("News Letter");
			subject.Add("Conference about Latest Technology");
			subject.Add("RE: Status Update");
			subject.Add("Success! Report Automation");
			subject.Add("Monthly Reports Documents");
			subject.Add("Meeting Confirmation");
			subject.Add("Goto Meeting");
			subject.Add("FW: Status Update");
			subject.Add("Greetings! Congrats");
			subject.Add("Report Monitor");
			subject.Add("News Letter");
			subject.Add("Conference about Latest Technology");
			subject.Add("RE: Status Update");
			subject.Add("Success! Report Automation");
			subject.Add("Monthly Reports Documents");
			subject.Add("Meeting Confirmation");

			textContent.Add("Join meeting to discuss about daily status, workflow, pending work and improve process");
			textContent.Add("Hi, Please find the today's status");
			textContent.Add("Hi, Congrats you have won the raffle");
			textContent.Add("Do not reply, Please find the attachment. Attachment have the full details of monitor report with timing");
			textContent.Add("Hi, Please find the attached news letter");
			textContent.Add("Hi, We are scheduled a meeting");
			textContent.Add("Thanks for the status report");
			textContent.Add("Do not reply, Automation result will update soon");
			textContent.Add("Hi, All documents are reviewed");
			textContent.Add("Thanks for scheduling the meeting");
			textContent.Add("Join meeting to discuss about daily status, workflow, pending work and improve process");
			textContent.Add("Hi, Please find the today's status");
			textContent.Add("Hi, Congrats you have won the raffle");
			textContent.Add("Do not reply, Please find the attachment. Attachment have the full details of monitor report with timing");
			textContent.Add("Hi, Please find the attached news letter");
			textContent.Add("Hi,We are scheduled a conference meeting");
			textContent.Add("Thanks for the status report");
			textContent.Add("Do not reply, Automation result will update soon");
			textContent.Add("Hi, All documents are reviewed");
			textContent.Add("Thanks for scheduling the meeting");
			textContent.Add("Join meeting to discuss about daily status, workflow, pending work and improve process");
			textContent.Add("Hi, Please find the today's status");
			textContent.Add("Hi, Congrats you have won the raffle");
			textContent.Add("Do not reply, Please find the attachment. Attachment have the full details of monitor report with timing");
			textContent.Add("Hi, Please find the attached news letter");
			textContent.Add("Hi,We are scheduled a conference meeting");
			textContent.Add("Thanks for the status report");
			textContent.Add("Do not reply, Automation result will update soon");
			textContent.Add("Hi, All documents are reviewed");
			textContent.Add("Thanks for scheduling the meeting");

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {

                menuCollection.Add(getItem("Inbox", "I"));
                menuCollection.Add(getItem("Starred", "R"));
                menuCollection.Add(getItem("Sent mail", "G"));
                menuCollection.Add(getItem("Drafts", "D"));
                menuCollection.Add(getItem("All mail", "A"));
                menuCollection.Add(getItem("Trash", "T"));
                menuCollection.Add(getItem("Spam", "S"));
                menuCollection.Add(getItem("Follow up", "F"));
            }

            if (Device.RuntimePlatform == Device.UWP || (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone))
            {
                this.menuCollection.Add(getItem("Inbox", "\xEDB3"));
                this.menuCollection.Add(getItem("Starred", "\xE208"));
                this.menuCollection.Add(getItem("Sent mail", "\xE120"));
                this.menuCollection.Add(getItem("Drafts", "\xE70B"));
                this.menuCollection.Add(getItem("All mail", "\xE715"));
                this.menuCollection.Add(getItem("Trash", "\xE107"));
                this.menuCollection.Add(getItem("Spam", "\xE10A"));
                this.menuCollection.Add(getItem("Follow up", "\xE290"));
            }
        }

        public ObservableCollection<MenuCollectionModel> MenuCollection
        {
            get
            {
                return menuCollection;
            }

            set
            {
                menuCollection = value;
            }
        }
    }

}

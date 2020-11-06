#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;
using UIKit;
using CoreGraphics;
using Syncfusion.SfAutoComplete.iOS;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SampleBrowser
{
    public class MultiSelection : SampleView
    {
        UILabel email, attach, send, ToLabel, ccLabel, bcclabel;

        UIView redpanel;
        SfAutoComplete toAutoComplete;
        SfAutoComplete ccAutoComplete;
        SfAutoComplete bccAutoComplete;
        UITextField messageBox;
        UITextField subjectBox;
        public UIView option = new UIView();
        private readonly IList<string> cultureList = new List<string>();
        public MultiSelection()
        {
            //ToAutoComplete
            toAutoComplete = new SfAutoComplete();
            toAutoComplete.MultiSelectMode = MultiSelectMode.Token;
            toAutoComplete.TokensWrapMode = TokensWrapMode.Wrap;
            toAutoComplete.DataSource = new ContactsInfoCollection().GetContactDetails();
            toAutoComplete.DisplayMemberPath = (NSString)"ContactName";
            toAutoComplete.ImageMemberPath = "ContactImage";
            toAutoComplete.ItemHeight = 60;
            toAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;
            toAutoComplete.DropDownItemChanged += NativeAutoComplete_DropDownItemChanged;
            this.AddSubview(toAutoComplete);

            //CCAutoComplete
            ccAutoComplete = new SfAutoComplete();
            ccAutoComplete.MultiSelectMode = MultiSelectMode.Token;
            ccAutoComplete.TokensWrapMode = TokensWrapMode.Wrap;
            ccAutoComplete.DataSource = new ContactsInfoCollection().GetContactDetails();
            ccAutoComplete.DisplayMemberPath = (NSString)"ContactName";
            ccAutoComplete.ImageMemberPath = "ContactImage";
            ccAutoComplete.ItemHeight = 60;
            ccAutoComplete.DropDownItemChanged += NativeAutoComplete_DropDownItemChanged;
            ccAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;
            this.AddSubview(ccAutoComplete);

            //BCCAutoComplete
            bccAutoComplete = new SfAutoComplete();
            bccAutoComplete.MultiSelectMode = MultiSelectMode.Token;
            bccAutoComplete.TokensWrapMode = TokensWrapMode.Wrap;
            bccAutoComplete.DataSource = new ContactsInfoCollection().GetContactDetails();
            bccAutoComplete.DisplayMemberPath = (NSString)"ContactName";
            bccAutoComplete.ItemHeight = 60;
            bccAutoComplete.ImageMemberPath = "ContactImage";
            bccAutoComplete.DropDownItemChanged += NativeAutoComplete_DropDownItemChanged;
            bccAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;
            this.AddSubview(bccAutoComplete);

            //SubjectBox
            subjectBox = new UITextField();
            subjectBox.Placeholder = " Subject";
            subjectBox.Font = UIFont.FromName("Helvetica", 15f);
            subjectBox.Layer.BorderWidth = 0.5f;
            subjectBox.Layer.CornerRadius = 5f;
            subjectBox.Layer.BorderColor = UIColor.FromRGB(200, 200, 200).CGColor;
            this.AddSubview(subjectBox);
            //MessageBox
            messageBox = new UITextField();
            messageBox.Text = "Sent from my smart phone.";
            messageBox.Font = UIFont.FromName("Helvetica", 12f);
            this.AddSubview(messageBox);

            mainPageDesign();
        }

        UIView NativeAutoComplete_DropDownItemChanged(object sender, DropDownItemEventArgs e)
        {
            UIView parentView = new UIView();
            SfAutoComplete auto = (sender as SfAutoComplete);
            parentView.Frame = new CGRect(0, 0, auto.Bounds.Width, auto.ItemHeight);
            UIImageView imageView = new UIImageView();
            imageView.Frame = new CGRect(5, 5, 50, auto.ItemHeight - 10);
            UILabel titleLabel = new UILabel();
            titleLabel.Frame = new CGRect(60, 5, auto.Bounds.Width - 65, auto.ItemHeight / 2 - 5);
            titleLabel.TextAlignment = UITextAlignment.Left;
            UILabel resultLabel = new UILabel();
            resultLabel.Frame = new CGRect(60, auto.ItemHeight / 2, auto.Bounds.Width - 65, auto.ItemHeight / 2 - 5);
            resultLabel.Font = UIFont.FromName("Helvetica", 12f);
            resultLabel.TextAlignment = UITextAlignment.Left;

            var item = auto.DataSource.ElementAt((int)e.Index);
            var selectedObject = (item as ContactsInfo);

            imageView.Image = new UIImage(selectedObject.ContactImage);
            titleLabel.Text = selectedObject.ContactName;
            resultLabel.Text = selectedObject.ContactNumber;

            parentView.AddSubview(imageView);
            parentView.AddSubview(titleLabel);
            parentView.AddSubview(resultLabel);

            e.View = parentView;

            return e.View;
        }


        public void mainPageDesign()
        {
            redpanel = new UIView();
            redpanel.BackgroundColor = UIColor.FromRGB(42, 77, 114);
            this.AddSubview(redpanel);
            //emaill
            email = new UILabel();
            email.TextColor = UIColor.White;
            email.BackgroundColor = UIColor.Clear;
            email.Text = @"Email - Compose";
            email.TextAlignment = UITextAlignment.Left;
            email.Font = UIFont.FromName("Helvetica", 16f);
            redpanel.AddSubview(email);

            //attachl
            attach = new UILabel();
            attach.TextColor = UIColor.White;
            attach.BackgroundColor = UIColor.Clear;
            attach.Text = @"ATTACH";
            attach.TextAlignment = UITextAlignment.Left;
            attach.Font = UIFont.FromName("Helvetica", 14f);
            redpanel.AddSubview(attach);

            //send
            send = new UILabel();
            send.TextColor = UIColor.White;
            send.BackgroundColor = UIColor.Clear;
            send.Text = @"SEND";
            send.TextAlignment = UITextAlignment.Left;
            send.Font = UIFont.FromName("Helvetica", 14f);
            redpanel.AddSubview(send);

            //ToLabell
            ToLabel = new UILabel();
            ToLabel.TextColor = UIColor.Black;
            ToLabel.BackgroundColor = UIColor.Clear;
            ToLabel.Text = @"To";
            ToLabel.TextAlignment = UITextAlignment.Left;
            ToLabel.Font = UIFont.FromName("Helvetica", 13f);
            this.AddSubview(ToLabel);

            //ccLabell
            ccLabel = new UILabel();
            ccLabel.TextColor = UIColor.Black;
            ccLabel.BackgroundColor = UIColor.Clear;
            ccLabel.Text = @"Cc";
            ccLabel.TextAlignment = UITextAlignment.Left;
            ccLabel.Font = UIFont.FromName("Helvetica", 13f);
            this.AddSubview(ccLabel);

            //bcclabell
            bcclabel = new UILabel();
            bcclabel.TextColor = UIColor.Black;
            bcclabel.BackgroundColor = UIColor.Clear;
            bcclabel.Text = @"Bcc";
            bcclabel.TextAlignment = UITextAlignment.Left;
            bcclabel.Font = UIFont.FromName("Helvetica", 13f);
            this.AddSubview(bcclabel);

            this.BackgroundColor = UIColor.White;
        }
        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
                redpanel.Frame = new CGRect(0, 0, view.Frame.Width, 50);
                toAutoComplete.Frame = new CGRect(50, 60, view.Frame.Width - 60, 40);
                ccAutoComplete.Frame = new CGRect(50, 110, view.Frame.Width - 60, 40);
                bccAutoComplete.Frame = new CGRect(50, 160, view.Frame.Width - 60, 40);
                subjectBox.Frame = new CGRect(10, 210, view.Frame.Width - 20, 40);
                messageBox.Frame = new CGRect(10, 260, view.Frame.Width - 60, 30);
                email.Frame = new CGRect(15, 10, 180, 40);
                attach.Frame = new CGRect(this.Frame.Size.Width - 120, 10, 60, 40);
                send.Frame = new CGRect(this.Frame.Size.Width - 50, 10, 50, 40);
                ToLabel.Frame = new CGRect(15, 60, 60, 40);
                ccLabel.Frame = new CGRect(15, 110, this.Frame.Size.Width - 20, 40);
                bcclabel.Frame = new CGRect(15, 160, this.Frame.Size.Width - 20, 40);
            }
        }


    }
    public class ContactsInfo
    {
        #region Fields

        private string contactName;
        private string contactNo;
        private string image;

        #endregion

        #region Constructor

        public ContactsInfo()
        {

        }

        #endregion

        #region Public Properties

        public string ContactName
        {
            get { return this.contactName; }
            set
            {
                this.contactName = value;

            }
        }

        public string ContactNumber
        {
            get { return contactNo; }
            set
            {
                this.contactNo = value;

            }
        }

        public string ContactImage
        {
            get { return this.image; }
            set
            {
                this.image = value;
            }
        }

        #endregion


    }
    public class ContactsInfoCollection
    {
        #region Fields

        private Random random = new Random();

        #endregion

        #region Constructor

        public ContactsInfoCollection()
        {

        }

        #endregion

        #region Get Contacts Details

        public ObservableCollection<ContactsInfo> GetContactDetails()
        {
            ObservableCollection<ContactsInfo> customerDetails = new ObservableCollection<ContactsInfo>();

            for (int i = 0; i < CustomerNames2.Count(); i++)
            {
                var details = new ContactsInfo()
                {
                    ContactName = CustomerNames2[i],
                    ContactNumber = CustomerNames2[i].Replace(" ", "") + "@outlook.com",

                    ContactImage = "b" + (i % 14) + ".png",
                };
                customerDetails.Add(details);
                if (i < 23)
                {
                    details = new ContactsInfo()
                    {
                        ContactName = CustomerNames1[i],
                        ContactNumber = CustomerNames1[i].Replace(" ", "") + "@outlook.com",

                        ContactImage = "a" + (i % 6) + ".png",
                    };
                    customerDetails.Add(details);
                }
            }
            return customerDetails;
        }

        #endregion

        #region Contacts Information

        string[] CustomerNames1 = new string[]
        {
            "Kyle",
            "Gina",
            "Michael",
            "Oscar",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Howard",
            "Jack",
            "Holly",
            "Steve",
            "Vince",
            "Zeke",
            "Aiden",
            "Jackson",
            "Mason",
            "Liam",
            "Jacob",
            "Jayden",
            "Ethan",
            "Alexander",
            "Sebastian",
        };

        string[] CustomerNames2 = new string[]
        {
            "Clara",
            "Irene",
            "Ellie",
            "Gabriella",
            "Nora",
            "Lucy",
            "Arianna",
            "Sarah",
            "Kaylee",
            "Adriana",
            "Finley",
            "Daleyza",
            "Leila",
            "Mckenna",
            "Jacqueline",
            "Brynn",
            "Sawyer",
            "Rosalie",
            "Maci",
            "Miranda",
            "Talia",
            "Shelby",
            "Haven",
            "Yaretzi",
            "Zariah",
            "Karla",
            "Cassandra",
            "Pearl",
            "Irene",
            "Zelda",
            "Wren",
            "Yamileth",
            "Belen",
            "Briley",
            "Jada",
            "Jaden"
        };

        #endregion
    }



}



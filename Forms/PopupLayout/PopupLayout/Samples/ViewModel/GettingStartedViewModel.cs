#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace SampleBrowser.SfPopupLayout
{
    public class GettingStartedViewModel : INotifyPropertyChanged
    {
        public GettingStartedViewModel()
        {
        }
        private bool enableRelativePosition = false;

        public bool EnableRelativeOption
        {
            get { return this.enableRelativePosition; }
            set
            {
                this.enableRelativePosition = value;
                OnPropertyChanged("EnableRelativeOption");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class ContactsViewModel : INotifyPropertyChanged
    {

        #region Properties

        public ObservableCollection<ContactInfo> contactsinfo { get; set; }
        int counter = 11;

        #endregion

        #region Constructor

        public ContactsViewModel()
        {
            contactsinfo = new ObservableCollection<ContactInfo>();
            

            foreach (var cusName in CustomerNames)
            {
                if (counter == 26)
                    counter = 11;
                var contact = new ContactInfo(cusName);
                contact.CallTime = CallTime;
#if COMMONSB
                contact.PhoneImage = ImageSource.FromResource("SampleBrowser.Images.PhoneImage.png", typeof(ContactsViewModel).GetTypeInfo().Assembly);
                contact.ContactImage = ImageSource.FromResource("SampleBrowser.Images.Image" + counter + ".png", typeof(ContactsViewModel).GetTypeInfo().Assembly);
#else
                contact.PhoneImage = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Images.PhoneImage.png", typeof(ContactsViewModel).GetTypeInfo().Assembly);
                contact.ContactImage = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Images.Image" + counter + ".png", typeof(ContactsViewModel).GetTypeInfo().Assembly);
#endif
                contactsinfo.Add(contact);
                counter++;
            }
        }

#endregion

#region Fields

        string[] CustomerNames = new string[] {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke",
            "Aiden",
            "Jackson" ,
            "Mason  " ,
            "Liam   " ,
            "Jacob  " ,
            "Jayden " ,
            "Ethan  " ,
            "Noah   " ,
            "Lucas  " ,
            "Logan  " ,
            "Caleb  " ,
            "Caden  " ,
            "Jack   " ,
            "Ryan   " ,
            "Connor " ,
            "Michael" ,
            "Elijah " ,
            "Brayden" ,
            "Benjamin",
            "Nicholas",
            "Alexander" ,
            "William" ,
            "Matthew" ,
            "James  " ,
            "Landon " ,
            "Nathan " ,
            "Dylan  " ,
            "Evan   " ,
            "Luke   " ,
            "Andrew " ,
            "Gabriel" ,
            "Gavin  " ,
            "Joshua " ,
            "Owen   " ,
            "Daniel " ,
            "Carter " ,
            "Tyler  " ,
            "Cameron" ,
            "Christian" ,
            "Wyatt  " ,
            "Henry  " ,
            "Eli    " ,
            "Joseph " ,
            "Max    " ,
            "Isaac  " ,
            "Samuel " ,
            "Anthony" ,
            "Grayson" ,
            "Zachary" ,
            "David  " ,
            "Christopher",
            "John   " ,
            "Isaiah " ,
            "Levi   " ,
            "Jonathan",
            "Oliver " ,
            "Chase  " ,
            "Cooper " ,
            "Tristan" ,
            "Colton " ,
            "Austin " ,
            "Colin  " ,
            "Charlie" ,
            "Dominic" ,
            "Parker " ,
            "Hunter " ,
            "Thomas " ,
            "Alex   " ,
            "Ian    " ,
            "Jordan " ,
            "Cole   " ,
            "Julian " ,
            "Aaron  " ,
            "Carson " ,
            "Miles  " ,
            "Blake  " ,
            "Brody  " ,
            "Adam   " ,
            "Sebastian",
            "Adrian " ,
            "Nolan  " ,
            "Sean   " ,
            "Riley  " ,
            "Bentley" ,
            "Xavier " ,
            "Hayden " ,
            "Jeremiah",
            "Jason  " ,
            "Jake   " ,
            "Asher  " ,
            "Micah  " ,
            "Jace   " ,
            "Brandon" ,
            "Josiah " ,
            "Hudson " ,
            "Nathaniel",
            "Bryson " ,
            "Ryder  " ,
            "Justin " ,
            "Bryce  " ,
        };

        string CallTime = "Mobile 11Hrs. ago";

#endregion

#region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

#endregion
    }

    public class TicketBookingViewModel //: INotifyPropertyChanged
    {
        public TicketBookingViewModel()
        {
            TicketInfoRepository details = new TicketInfoRepository();
            theaterInformation = details.GetDetails();
        }

#region ItemsSource

        private ObservableCollection<TicketBookingInfo> theaterInformation;

        public ObservableCollection<TicketBookingInfo> TheaterInformation
        {
            get { return this.theaterInformation; }
            set { this.theaterInformation = value; }
        }

#endregion
    }

}

#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ContactsViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using Xamarin.Forms;

    /// <summary>
    /// A ViewModel for Contacts sample.
    /// </summary>
    public class ContactsViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Holds the data of CustomerNames.
        /// </summary>
        private readonly string[] customerNames =
        {
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
            "Jackson",
            "Mason  ",
            "Liam   ",
            "Jacob  ",
            "Jayden ",
            "Ethan  ",
            "Noah   ",
            "Lucas  ",
            "Logan  ",
            "Caleb  ",
            "Caden  ",
            "Jack   ",
            "Ryan   ",
            "Connor ",
            "Michael",
            "Elijah ",
            "Brayden",
            "Benjamin",
            "Nicholas",
            "Alexander",
            "William",
            "Matthew",
            "James  ",
            "Landon ",
            "Nathan ",
            "Dylan  ",
            "Evan   ",
            "Luke   ",
            "Andrew ",
            "Gabriel",
            "Gavin  ",
            "Joshua ",
            "Owen   ",
            "Daniel ",
            "Carter ",
            "Tyler  ",
            "Cameron",
            "Christian",
            "Wyatt  ",
            "Henry  ",
            "Eli    ",
            "Joseph ",
            "Max    ",
            "Isaac  ",
            "Samuel ",
            "Anthony",
            "Grayson",
            "Zachary",
            "David  ",
            "Christopher",
            "John   ",
            "Isaiah ",
            "Levi   ",
            "Jonathan",
            "Oliver ",
            "Chase  ",
            "Cooper ",
            "Tristan",
            "Colton ",
            "Austin ",
            "Colin  ",
            "Charlie",
            "Dominic",
            "Parker ",
            "Hunter ",
            "Thomas ",
            "Alex   ",
            "Ian    ",
            "Jordan ",
            "Cole   ",
            "Julian ",
            "Aaron  ",
            "Carson ",
            "Miles  ",
            "Blake  ",
            "Brody  ",
            "Adam   ",
            "Sebastian",
            "Adrian ",
            "Nolan  ",
            "Sean   ",
            "Riley  ",
            "Bentley",
            "Xavier ",
            "Hayden ",
            "Jeremiah",
            "Jason  ",
            "Jake   ",
            "Asher  ",
            "Micah  ",
            "Jace   ",
            "Brandon",
            "Josiah ",
            "Hudson ",
            "Nathaniel",
            "Bryson ",
            "Ryder  ",
            "Justin ",
            "Bryce  "
        };

        /// <summary>
        /// Holds the call time of the contact.
        /// </summary>
        private readonly string callTime = "Mobile 11Hrs. ago";

        /// <summary>
        /// Holds the value for referencing different images of the caller. 
        /// </summary>
        private readonly int counter = 11;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ContactsViewModel class.
        /// </summary>
        public ContactsViewModel()
        {
            this.Contactsinfo = new ObservableCollection<ContactInfo>();

            foreach (var cusName in this.customerNames)
            {
                if (this.counter == 26)
                {
                    this.counter = 11;
                }

                var contact = new ContactInfo(cusName);
                contact.CallTime = this.callTime;
                contact.PhoneImage = "PhoneImage".GetImageSource();
                contact.ContactImage = ("Image" + this.counter).GetImageSource();
                this.Contactsinfo.Add(contact);
                this.counter++;
            }

            this.SetBindingImageSource();
        }

        #endregion

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        /// <summary>
        /// Gets or sets the Contacts info value of ObservableCollection of ContactInfo type.
        /// </summary>
        public ObservableCollection<ContactInfo> Contactsinfo { get; set; }

        /// <summary>
        /// Gets or sets the image source for SendMessage.
        /// </summary>
        public ImageSource SendMessageImage { get; set; }

        /// <summary>
        /// Gets or sets the image source for BlockSpanImage.
        /// </summary>
        public ImageSource BlockSpanImage { get; set; }

        /// <summary>
        /// Gets or sets the image source for CallDetailImage.
        /// </summary>
        public ImageSource CallDetailImage { get; set; }

        #endregion

        #region Interface Member   

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type parameter named as name</param>
        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the Source for the images.
        /// </summary>
        private void SetBindingImageSource()
        {
            this.SendMessageImage = "SendMessage".GetImageSource();
            this.BlockSpanImage = "BlockSpan".GetImageSource();
            this.CallDetailImage = "CallDetails".GetImageSource();
        }

        #endregion
    }
}
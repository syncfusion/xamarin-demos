#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ContactsViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using System;
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
        /// Holds the call time of the contact.
        /// </summary>
        private readonly string callTime = "Mobile 11Hrs. ago";

        /// <summary>
        /// Holds the value for referencing different images of the caller. 
        /// </summary>
        private readonly int counter = 11;

        /// <summary>
        /// Holds the data of FeMale CustomerNames.
        /// </summary>
        private readonly string[] customerNamesFeMale =
        {
            "Kyle",
            "Katie",
            "Brenda",
            "Irene",
            "Danielle",
            "Fiona",
            "Larry",
            "Jennifer",
            "Liz",
            "Pete",
            "Vince",
            "Liam   ",
            "Noah   ",
            "Elijah ",
            "Brayden",
            "Andrew ",
            "Gabriel",
            "Joshua ",
            "Owen   ",
            "Eli    ",
            "Isaac  ",
            "Isaiah ",
            "Levi   ",
            "Adrian ",
            "Nolan  ",
            "Riley  ",
            "Bentley",
            "Jeremiah",
            "Jace   ",
            "Brandon",
            "Josiah ",
            "Bryce  ",
            "Adam   ",
            "Hayden ",
            "Chase  ",
            "Austin ",
            "Colin  ",
            "Cole   ",
            "Julian ",
            "Sebastian",
        };

        /// <summary>
        /// Holds the data of Male CustomerNames.
        /// </summary>
        private readonly string[] customerNamesMale =
        {
            "Gina",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Howard",
            "Jack",
            "Holly",
            "Steve",
            "Zeke",
            "Aiden",
            "Jackson",
            "Mason  ",
            "Jacob  ",
            "Jayden ",
            "Ethan  ",
            "Lucas  ",
            "Logan  ",
            "Caleb  ",
            "Caden  ",
            "Jack   ",
            "Ryan   ",
            "Connor ",
            "Michael",
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
            "Gavin  ",
            "Daniel ",
            "Carter ",
            "Tyler  ",
            "Cameron",
            "Christian",
            "Wyatt  ",
            "Henry  ",
            "Joseph ",
            "Max    ",
            "Samuel ",
            "Anthony",
            "Grayson",
            "Zachary",
            "David  ",
            "Christopher",
            "John   ",
            "Jonathan",
            "Oliver ",
            "Cooper ",
            "Tristan",
            "Colton ",
            "Charlie",
            "Dominic",
            "Parker ",
            "Hunter ",
            "Thomas ",
            "Alex   ",
            "Ian    ",
            "Jordan ",
            "Aaron  ",
            "Carson ",
            "Miles  ",
            "Blake  ",
            "Brody  ",
            "Sean   ",
            "Xavier ",
            "Jason  ",
            "Jake   ",
            "Asher  ",
            "Micah  ",
            "Hudson ",
            "Nathaniel",
            "Bryson ",
            "Ryder  ",
            "Justin ",
        };

        /// <summary>
        /// Holds the data of FeMale Image.
        /// </summary>
        private string[] imageFemale = new string[]
        {
           "People_Circle0.png",
           "People_Circle1.png",
           "People_Circle2.png",
           "People_Circle3.png",
           "People_Circle4.png",
           "People_Circle6.png",
           "People_Circle7.png",
           "People_Circle9.png",
           "People_Circle10.png",
           "People_Circle11.png",
           "People_Circle13.png",
           "People_Circle15.png",
           "People_Circle16.png",
           "People_Circle17.png",
           "People_Circle19.png",
           "People_Circle20.png",
           "People_Circle21.png",
           "People_Circle22.png",
           "People_Circle24.png",
            "People_Circle25.png",
        };

        /// <summary>
        /// Holds the data of Male Image.
        /// </summary>
        private string[] imageMale = new string[]
        {
         "People_Circle5.png",
         "People_Circle8.png",
         "People_Circle12.png",
         "People_Circle14.png",
         "People_Circle18.png",
         "People_Circle23.png",
         "People_Circle26.png",
         "People_Circle27.png",
         };

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ContactsViewModel class.
        /// </summary>
        public ContactsViewModel()
        {
            this.Contactsinfo = new ObservableCollection<ContactInfo>();
            Random random = new Random();
            if (this.counter == 26)
            {
                this.counter = 11;
            }

            for (int i = 1; i <= 80; i++)
            {
                var contact = new ContactInfo();
                contact.ContactName = (this.counter % 2 == 0) ? this.customerNamesMale[random.Next(30)] : this.customerNamesFeMale[random.Next(30)];
                contact.CallTime = this.callTime;
                contact.ContactImage = (this.counter % 2 == 0) ? this.imageMale[random.Next(7)] : this.imageFemale[random.Next(15)];
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
        }

        #endregion
    }
}
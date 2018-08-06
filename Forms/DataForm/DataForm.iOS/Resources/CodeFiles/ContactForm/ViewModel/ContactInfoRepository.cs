#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfDataForm
{
    [Preserve(AllMembers = true)]
    public class ContactsInfoRepository
    {
        #region Fields

        private Random random = new Random();

        #endregion

        #region Constructor

        public ContactsInfoRepository()
        {

        }

        #endregion

        #region Get Contacts Details

        public ObservableCollection<ContactInfo> GetContactDetails(int count)
        {
            ObservableCollection<ContactInfo> customerDetails = new ObservableCollection<ContactInfo>();

            for (int i = 0; i < 25; i++)
            {
                var details = new ContactInfo()
                {
                    ContactType = ContactInfo.ContactsType.Business,
                    ContactNumber = random.Next(100000, 400000).ToString(),
                    ContactName = CustomerNames[i],
                    ContactImage = ImagePathConverter.GetImageSource("SampleBrowser.SfDataForm." + "Contact" + (i % 9) + ".png"),
                };
                customerDetails.Add(details);
            }
            return customerDetails;
        }

        #endregion

        #region Contacts Information

        string[] contactType = new string[]
        {
            "HOME",
            "WORK",
            "MOBILE",
            "OTHER",
            "BUSINESS"
        };



        string[] CustomerNames = new string[]
        {
            "Liz",
            "Ralph",
            "Oscar",
            "Torrey",
            "Gina",
            "Irene",
            "Katie",
            "Fiona",
            "Kyle",
            "Michael",
            "William",
            "Bill" ,
            "Wyatt" ,
            "Henry",
            "Eli",
            "Joseph",
            "Max",
            "Isaac",
            "Samuel",
            "Grayson",
            "Zachary",
            "David",
            "Christopher",
            "John",
            "Isaiah",
            "Levi",
            "Jonathan",
            "Oliver",
            "Chase",
            "Cooper",
            "Tristan",
            "Colton",
            "Austin",
            "Colin",
            "Charlie",
            "Dominic",
            "Parker",
            "Hunter",
            "Thomas",
            "Alex",
            "Ian",
            "Jordan",
            "Cole",
            "Julian",
            "Aaron",
            "Carson",
            "Miles",
        };

        #endregion
    }
}
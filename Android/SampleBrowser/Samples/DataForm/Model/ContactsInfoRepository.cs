#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
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

        public ObservableCollection<ContactsInfo> GetContactDetails(int count)
        {
            ObservableCollection<ContactsInfo> customerDetails = new ObservableCollection<ContactsInfo>();
            for (int i = 0; i < 10; i++)
            {
                var details = new ContactsInfo()
                {
                    ContactType = ContactsInfo.ContactsType.Business,
                    ContactNumber = random.Next(100000, 400000).ToString(),
                    ContactName = customerNames[i],
                };
                customerDetails.Add(details);
            }

            customerDetails[0].ContactImage = Resource.Drawable.Contact0;
            customerDetails[1].ContactImage = Resource.Drawable.Contact1;
            customerDetails[2].ContactImage = Resource.Drawable.Contact2;
            customerDetails[3].ContactImage = Resource.Drawable.Contact3;
            customerDetails[4].ContactImage = Resource.Drawable.Contact4;
            customerDetails[5].ContactImage = Resource.Drawable.Contact5;
            customerDetails[6].ContactImage = Resource.Drawable.Contact6;
            customerDetails[7].ContactImage = Resource.Drawable.Contact7;
            customerDetails[8].ContactImage = Resource.Drawable.Contact8;
            customerDetails[9].ContactImage = Resource.Drawable.Contact9;
            return customerDetails;
        }

        #endregion

        #region Contacts Information

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private string[] contactType = new string[]
        {
            "HOME",
            "WORK",
            "MOBILE",
            "OTHER",
            "BUSINESS"
        };

        private string[] customerNames = new string[]
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
            "Bill",
        };

        #endregion
    }
}
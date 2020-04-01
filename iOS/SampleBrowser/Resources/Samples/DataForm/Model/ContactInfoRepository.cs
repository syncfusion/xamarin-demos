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

using Foundation;
using UIKit;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    class ContactsInfoRepository
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

            for (int i = 0; i < 9; i++)
            {
                var details = new ContactInfo()
                {
                    ContactType = ContactInfo.ContactsType.Business,
                    ContactNumber = random.Next(100000, 400000).ToString(),
                    ContactName = CustomerNames[i],
                    ContactImage = UIImage.FromBundle("Contact" + (i % 10) + ".png"),
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
            "Bill",
        };

        #endregion
    }
}
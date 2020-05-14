#region Copyright
// <copyright file="ContactsInfoRepository.cs" company="Syncfusion"> 
//  Copyright (c) Syncfusion Inc. 2001 - 2020. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace SampleBrowser.SfDataForm
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using SampleBrowser.Core;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    /// <summary>
    /// Represents the repository of data form fields and events.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ContactsInfoRepository
    {
        #region Fields

        /// <summary>
        /// Represents a pseudo random number generator.
        /// </summary>
        private Random random = new Random();

        #endregion

        #region Contacts Information
        
        /// <summary>
        /// Represents the possible contact types.
        /// </summary>
        private string[] contactType = new string[]
        {
            "HOME",
            "WORK",
            "MOBILE",
            "OTHER",
            "BUSINESS"
        };
        
        /// <summary>
        /// Represents the customers names.
        /// </summary>
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
            "Wyatt",
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

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsInfoRepository"/> class.
        /// </summary>
        public ContactsInfoRepository()
        {
        }

        #endregion

        #region Get Contacts Details

        /// <summary>
        /// Gets the contact details of the customer.
        /// </summary>
        /// <param name="count">Represents the number of elements.</param>
        /// <returns>Returns the contact details.</returns>
        public ObservableCollection<ContactInfo> GetContactDetails(int count)
        {
            ObservableCollection<ContactInfo> customerDetails = new ObservableCollection<ContactInfo>();

            for (int i = 0; i < 25; i++)
            {
                var details = new ContactInfo()
                {
                    ContactType = ContactInfo.ContactsType.Home,
                    ContactNumber = this.random.Next(1000000000, 2100000000).ToString(),
                    ContactName = this.customerNames[i],
                    ContactImage = "People_Circle" + (i % 9) + ".png",
                };
                customerDetails.Add(details);
            }

            return customerDetails;
        }

        #endregion
    }
}
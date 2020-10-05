#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
namespace SampleBrowser
{
    internal class OrderDetails
    {
        public OrderDetails(string image, string title, string price, string offer, string rating,string description)
        {
            Image = image;
            Title = title;
            Price = price;
            Offer = offer;
            Rating = rating;
            Description = description;
        }
        public string Title
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string Price
        {
            get;
            set;
        }
        public string Offer
        {
            get;
            set;
        }
        public string Image
        {
            get;
            set;
        }
        public string Rating
        {
            get;
            set;
        }
    }
}

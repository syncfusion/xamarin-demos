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

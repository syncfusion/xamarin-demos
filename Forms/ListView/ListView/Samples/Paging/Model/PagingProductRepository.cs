#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class PagingProductRepository
    {
        internal string[] Names = new string[]
        {
            "Fuji Apple","Honey Banana","Hawaiian Papaya","Lime","Pomegranate",
            "Mandarin Orange","Watermelon","Apricot","Black Grapes","Redrose Cherry",
            "Avacado","Organic Dragon","Asian Guava","Kesar Mango","Organic Lemon",
            "Bluberry","Jackfruit","Fuzzy Kiwi","Peaches","Pineapple","Strawberry","Rasberry",
            "Gala Apple","Saba Banana","Red Papaya","Key Lime","Pomegranate",
            "Blood Orange","Watermelon","Apium Apricot","Fresh Grapes","Bing Cherry",
            "Avacado","Dragon","Guava","Fresh Mango","Lemon",
            "Bluberry","Jackfruit","Fuzzy Kiwi","Gala Peaches","Fresh Pineapple","Red Strawberry","Rasberry",
            "Apple","Banana","Marsh Papaya","Key Lime","Fresh Pomegranate",
            "Manddarin Orange","Fresh Watermelon","Dried Apricot","Black Grapes","Redrose Cherry",
            "Asian Avacado","Dragon","Guava","Langra Mango","Organic Lemon",
            "Fresh Bluberry","Jackfruit","Hardy Kiwi","Gala Peaches","Fresh Pineapple","Red Strawberry","Rasberry",
            "Gala Apple","Saba Banana","Red Papaya","Key Limes",
        };

        internal string[] Ratings = new string[]
        {
            "1500 Reviews", "1000 Reviews", "1200 Reviews", "1400 Reviews", "1600 Reviews",
            "1700 Reviews", "1800 Reviews", "1900 Reviews", "2500 Reviews", "1500 Reviews",
            "1800 Reviews", "1700 Reviews", "1460 Reviews", "1760 Reviews", "1660 Reviews",
            "1230 Reviews", "1850 Reviews", "1120 Reviews", "1980 Reviews", "1540 Reviews",
            "1980 Reviews", "1340 Reviews", "1340 Reviews", "1870 Reviews", "1360 Reviews",
            "1870 Reviews", "1230 Reviews", "1650 Reviews", "1860 Reviews", "1750 Reviews",
            "1570 Reviews", "1650 Reviews", "1660 Reviews", "1650 Reviews", "1270 Reviews",
            "1700 Reviews", "1540 Reviews", "1860 Reviews", "1480 Reviews", "1680 Reviews",
            "1240 Reviews", "1860 Reviews", "1240 Reviews", "1860 Reviews", "1200 Reviews",
            "1400 Reviews", "1600 Reviews", "1700 Reviews", "1800 Reviews", "1900 Reviews",
            "2500 Reviews", "2150 Reviews", "1380 Reviews", "1700 Reviews", "1460 Reviews",
            "1760 Reviews", "1660 Reviews", "1230 Reviews", "1850 Reviews", "1120 Reviews",
            "1980 Reviews", "1540 Reviews", "1980 Reviews", "1340 Reviews", "1340 Reviews",
            "1870 Reviews", "1360 Reviews", "1870 Reviews", "1230 Reviews", "1650 Reviews", "1240 Reviews",
        };

        internal double[] ReviewValue = new double[]
        {
            4.5,3.1,2.2,4.3,3.4,2.5,3.6,4.7,4.8,3.9,2.5,4.2,3.1,4.2,2.3,4.4,3.5,4.6,2.7,4.8,
            3.9,4.6,2.5,2.1,3.2,4.3,4.4,3.5,4.6,2.7,4.8,4.9,2.3,3.4,4.1,2.2,4.3,3.4,4.5,4.6,
            2.7,3.8,4.9,3.4,4.7,2.5,4.6,4.9,2.2,4.3,3.4,2.5,3.6,4.7,4.8,3.9,2.5,4.2,3.1,4.2,
            2.3,4.4,3.5,4.6,2.7,4.8,3.9,4.6,2.5,2.1,3.2,4.3,4.4,3.5,4.8
        };

        internal string[] Names1 = new string[]
        {
            "Apple","Banana","Papaya","Lime","Pomegranate","Orange","Watermelon","Apricot",
            "Grapes","Cherry","Avacado","Dragon","Guava","Mango","Lemon","Blueberry",
            "Jackfruit","Kiwi","Peach","Pineapple","Strawberry","Raspberry"
        };

        internal string[] Weights = new string[]
        {
            "1 lb","1 lb","1 lb","1 lb","1 lb","2 lb","2 lb","2 lb","1 lb",
            "2 lb","1.5 lb","2 lb","1 lb","1 lb","1 lb","1 lb","1 lb","2 lb",
            "1 lb","1 lb","1.5 lb","1 lb","1.5 lb","2 lb","1 lb","1.5 lb","1 lb",
            "1.5 lb","2 lb","2 lb","1 lb","1 lb","1 lb","2 lb","1 lb","1 lb",
            "1 lb","1 lb","1 lb","1 lb","1.5 lb","2 lb","1 lb","2 lb","1 lb",
            "2 lb","1 lb","1.5 lb","2 lb","2 lb","1 lb","2 lb","1 lb","2 lb",
            "1 lb","1 lb","1 lb","1 lb","1 lb","2 lb","1.5 lb","1 lb","1 lb",
            "1 lb","1 lb","2 lb","2 lb","1 lb","1 lb","1 lb","2 lb"
        };

        internal double[] Prices = new double[]
        {
            2.47,1.40,5.48,2.28,1.45,5.00,3.98,3.50,6.50,7.48,6.29,2.46,1.47,2.10,4.40,5.00,
            8.27,7.33,9.99,2.00,3.97,3.79,1.17,6.40,1.78,2.18,3.78,2.12,3.98,9.95,6.50,6.18,
            1.05,2.76,3.47,7.10,6.40,8.25,7.17,8.33,1.55,6.00,1.55,1.15,5.48,2.18,1.40,4.95,
            3.88,1.39,6.40,7.38,6.19,2.36,1.57,2.20,4.30,5.10,8.37,7.23,9.89,2.10,3.87,3.29,
            1.07,6.10,2.08,1.78,4.28,2.10,1.15
        };

        internal string[] Offer = new string[]
        {
            "10 % Off","25 % Off","50 % Off","30 % Off","60 % Off","35 % Off","40 % Off",
            "70 % Off","25 % Off","90 % Off","20 % Off","45 % Off","50 % Off","20 % Off",
            "15 % Off","10 % Off","20 % Off","45 % Off", "10 % Off", "20 % Off", "15 % Off",
            "40 % Off", "20 % Off", "15 % Off", "50 % Off", "20 % Off", "15 % Off", "80 % Off",
            "20 % Off", "45 % Off", "30 % Off", "80 % Off", "35 % Off", "10 % Off", "30 % Off",
            "75 % Off", "50 % Off", "20 % Off", "55 % Off", "40 % Off", "20 % Off", "85 % Off",
            "10 % Off", "20 % Off", "50 % Off", "30 % Off", "60 % Off", "35 % Off", "40 % Off",
            "70 % Off", "25 % Off", "90 % Off", "20 % Off", "45 % Off", "50 % Off", "20 % Off",
            "15 % Off", "10 % Off", "20 % Off", "45 % Off", "10 % Off", "20 % Off", "15 % Off",
            "40 % Off", "20 % Off", "15 % Off", "50 % Off", "20 % Off", "15 % Off", "80 % Off", "30 % Off"
        };
    }
}
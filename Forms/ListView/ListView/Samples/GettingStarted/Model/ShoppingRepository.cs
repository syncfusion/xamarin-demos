#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class ShoppingCategoryInfoRepository
    {
        #region Constructor

        public ShoppingCategoryInfoRepository()
        {

        }

        #endregion

        #region Properties

        internal ObservableCollection<ListViewShoppingCategoryInfo> GetCategoryInfo()
        {
            var categoryInfo = new ObservableCollection<ListViewShoppingCategoryInfo>();
            for (int i = 0; i < CategoryNames.Count(); i++)
            {
                var info = new ListViewShoppingCategoryInfo()
                {
                    CategoryName = CategoryNames[i],
                    CategoryDescription = CategoryDescriptions[i],
                    CategoryImage = CategoryImages[i]
                };
                categoryInfo.Add(info);
            }
            return categoryInfo;
        }

        #endregion

        #region CategoryInfo

        string[] CategoryNames = new string[]
        {
            "Fashion",
            "Electronics",
            "Home & Kitchen",
            "Sports & Health",
            "Kids",
            "Books",
            "Footware",
            "Mobile & Accesories",
            "FlowerGiftCakes",
            "Watches",
            "Jewellery",
            "Food",
            "Perfumes",
            "Movies & Music",
            "Cameras & Optics"
        };

        string[] CategoryImages = new string[]
        {
            "Shopping.jpg",
            "Electronics.jpg",
            "DiningTable.jpg",
            "Sports_Health.jpg",
            "NaughtyBoy.jpg",
            "Novels.jpg",
            "Graycanvas.jpg",
            "Mobile.jpg",
            "FlowerGiftCakes.jpg",
            "Watches.jpg",
            "Jewellery.jpg",
            "Food.jpg",
            "Perfumes.jpg",
            "BrownGuitar.jpg",
            "Cameras.png"
        };

        string[] CategoryDescriptions = new string[]
        {
            "Latest fashion trends in online shopping for branded Shoes, Clothing, Dresses, Handbags, Watches, Home decor for Men & Women...",
            "Shop variety of electronics like Mobiles, Laptops, Tablets, Cameras, Gaming Consoles, TVs, LEDs, Music Systems & much more...",
            "Purchase Home & Kitchen accessories like Cookware, Home Cleaning, Furniture, Dining Accessories, Showcase accessories etc ...",
            "Buy accessories for Badminton, Cricket, Football, Swimming, Sports shoes, Tennis, Gym, Volleyball, hockey at lowest price...",
            "Shop for clothing for Boys, Girls and Babies. Explore the range of Tops, Tees, Jeans, Shirts, Trousers, Skirts, Body Suits...",
            "Purchase various books with Book titles with across various categories at lowest price. Read books online and download as pdf...",
            "Buy Footwear for Men, Women & Kids with collection of Formal Shoes, Slippers, Casual Shoes, Sandals and more with best price...",
            "Buy branded Mobile Phones, SmartPhones, Tablets and mobile accessories are Bluetooth, Headsets, MemoryCards, Charger & Covers etc...",
            "Buy different Flowers, Gifts & Cakes in online shopping. Birthday Gifts, Anniversary Gifts, MothersDay Gifts, Flowers and Cakes etc...",
            "Latest range of trendy branded, Digital watches & Analog watches, Digital Steel Watch, Digital LED Watches for Men's and Women's...",
            "Buy Jewellery for Men, Women and Children from brands like Gitanjali, Tara, Orra, Sia Art Jewellery, Addons, Ayesha, Peora etc...",
            "Shop from a wide range of best quality Fruits, Vegetables, Health Food, Indian Grocery, Pulses, Cereals, Noodles, Foods etc...",
            "Choose the best branded Perfume like Azzaro, Davidoff, CK, Axes, Good Morning, Hugo Boss, Jaguar, Calvin Klein & Antonio etc...",
            "Buy variety of Movies & TV Blu-ray in different languages and Musics in variety of formats like audio CD, DVD, MP3, VCD etc...",
            "Purchase variety of Cameras like Tamron, Sigma, Nikon, Sony, and Canon at best prices and SLRs, Lenses and Optics accessories..."
        };

        #endregion
    }
}

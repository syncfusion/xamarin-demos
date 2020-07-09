#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.Cards
{
    public class CardLayoutViewModel 
    {
        
        internal ObservableCollection<CardData> Data = new ObservableCollection<CardData>();

        public CardLayoutViewModel()
        {
            this.AddData();
        }

        private void AddData()
        {
            Data.Add(new CardData
            {
                Name = "Black Leather Sofa",
                Price = 99.50,
                Rating = "4.9",
                Offer = "5% Offer",
                ImagePath = "BlackSofa.jpg" ,
                Description = "Warranty covers up to 5 years. This frame’s special feature is its bookcase headboard."
            });

            Data.Add(new CardData
            {
                Name = "Wooden Standing Drawer",
                Price = 199.50,
                Rating = "3.9",
                Offer = "50% Offer",
                ImagePath = "TVShelf.jpg",
                Description = "\"This versatile wardrobe strikes the perfect balance between style and functionality. Equipped with a mirror and multiple shelves."
            });

            Data.Add(new CardData
            {
                Name = "Semi-Cotton Fabric Sofa",
                Price = 299.50,
                Rating = "2.9",
                Offer = "25% Offer",
                ImagePath = "GraySofa.jpg",
                Description = "This sofa’s frame is made of engineered wood, which is stable and climate-resistant. Protected with a scratch-resistant finish."
            });

            Data.Add(new CardData
            {
                Name = "Dining Chair",
                Price = 399.50,
                Rating = "4.9",
                Offer = "15% Offer",
                ImagePath = "DiningTable.jpg",
                Description = "Made of plywood to reduce weight and costs, these end tables still look like solid cherry."
            });

            Data.Add(new CardData
            {
                Name = "White Sofa",
                Price = 99.50,
                Rating = "3.9",
                Offer = "35% Offer",
                ImagePath = "AngleSofa.jpg",
                Description = "Lightweight but sturdy, this nightstand is made of particleboard with a maple veneer or painted white."
            });
        }
    }
}

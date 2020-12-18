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
using CoreGraphics;
using Syncfusion.SfTabView.iOS;
using UIKit;

namespace SampleBrowser
{
    public class TabViewGettingStarted : SampleView
    {
        bool isControlLoaded = false;
        UILabel headerLabel;
        TemplateView templateView;
        SfTabView tabView;
        UIScrollView tabContentView;
        TabViewOptionsPage optionsPage;
        List<OrderDetails> FurnitureList = new List<OrderDetails>();
        List<OrderDetails> ToysList = new List<OrderDetails>();
        List<OrderDetails> ClothingList = new List<OrderDetails>();
        List<OrderDetails> ShoesList = new List<OrderDetails>();
        List<OrderDetails> FruitsList = new List<OrderDetails>();

        public TabViewGettingStarted()
        {
            BackgroundColor = UIColor.FromRGB(48, 146, 246);
            InitializeOrderDetails();
            optionsPage = new TabViewOptionsPage();
            this.OptionView = optionsPage;
        }

        public override void LayoutSubviews()
        {
            if (!isControlLoaded)
            {
                isControlLoaded = true;
                InitializeHeaderLabel();
                InitializeTabView();
                this.optionsPage.sftabView = tabView;
                this.optionsPage.Frame = this.Frame;
            }
            base.LayoutSubviews();
        }

        void InitializeHeaderLabel()
        {
            headerLabel = new UILabel();
            headerLabel.Frame = new CGRect(0, 0, this.Frame.Width, 50);
            headerLabel.BackgroundColor = UIColor.FromRGB(48, 146, 246);
            headerLabel.TextColor = UIColor.White;
            headerLabel.Text = "  Shopping Cart";
           // Add(headerLabel);
        }

        UIView InitializeTabContent(string tabName,int count)
        {
            tabContentView = new UIScrollView();
            tabContentView.BackgroundColor = UIColor.FromRGB(232,235,240);
            var height = 0;
            switch(tabName)
            {
                case "Furniture":
                    for (int i = 0;i<count;i++)
                    {
                        var view = InitializeTemplateView(FurnitureList[i].Image, FurnitureList[i].Title, FurnitureList[i].Price, FurnitureList[i].Offer, FurnitureList[i].Rating, FurnitureList[i].Description);
                        view.Frame = new CGRect(5, 5 + (i * 175), this.Frame.Width - 10, 170);
                        tabContentView.Add(view);
                        height = (int)(view.Frame.Y + view.Frame.Height);
                    }
                    break;
                case "Toys":
                    for (int i = 0; i < count; i++)
                    {
                        var view = InitializeTemplateView(ToysList[i].Image, ToysList[i].Title, ToysList[i].Price, ToysList[i].Offer, ToysList[i].Rating, ToysList[i].Description);
                        view.Frame = new CGRect(5, 5 + (i * 175), this.Frame.Width - 10, 170);
                        tabContentView.Add(view);
                        height = (int)(view.Frame.Y + view.Frame.Height);
                    }
                    break;
                case "Clothing":
                    for (int i = 0; i < count; i++)
                    {
                        var view = InitializeTemplateView(ClothingList[i].Image, ClothingList[i].Title, ClothingList[i].Price, ClothingList[i].Offer, ClothingList[i].Rating, ClothingList[i].Description);
                        view.Frame = new CGRect(5, 5 + (i * 175), this.Frame.Width - 10, 170);
                        tabContentView.Add(view);
                        height = (int)(view.Frame.Y + view.Frame.Height);
                    }
                    break;
                case "Shoes":
                    for (int i = 0; i < count; i++)
                    {
                        var view = InitializeTemplateView(ShoesList[i].Image, ShoesList[i].Title, ShoesList[i].Price, ShoesList[i].Offer, ShoesList[i].Rating, ShoesList[i].Description);
                        view.Frame = new CGRect(5, 5 + (i * 175), this.Frame.Width - 10, 170);
                        tabContentView.Add(view);
                        height = (int)(view.Frame.Y + view.Frame.Height);
                    }
                    break;
                case "Fruits":
                    for (int i = 0; i < count; i++)
                    {
                        var view = InitializeTemplateView(FruitsList[i].Image, FruitsList[i].Title, FruitsList[i].Price, FruitsList[i].Offer, FruitsList[i].Rating, FruitsList[i].Description);
                        view.Frame = new CGRect(5, 5 + (i * 175), this.Frame.Width - 10, 170);
                        tabContentView.Add(view);
                        height = (int)(view.Frame.Y + view.Frame.Height);
                    }
                    break;
            }
            tabContentView.ContentSize = new CGSize(this.Frame.Width, height);
            return tabContentView;
        }
        UIView InitializeTemplateView(string image, string title, string price, string offer, string rating,string description)
        {
            templateView = new TemplateView();
            templateView.UpdateContent(image, title, price, offer, rating, description);
            return templateView;
        }

        void InitializeTabView()
        {
            TabItemCollection collection = new TabItemCollection();
            tabView = new SfTabView();
            tabView.BackgroundColor = UIColor.FromRGB(48, 146, 246);//UIColor.White;//UIColor.FromRGB(48, 146, 246);
            tabView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);

            SfTabItem furnitureTab = new SfTabItem();
            furnitureTab.Title = "Furniture";
            furnitureTab.IconFont = "A";
            furnitureTab.Content = InitializeTabContent("Furniture", 5);
            furnitureTab.TitleFontColor = UIColor.White;
            furnitureTab.SelectionColor = UIColor.White;
            furnitureTab.FontIconFont = UIFont.FromName("TabIcons", 20);
            collection.Add(furnitureTab);

            SfTabItem clothingTab = new SfTabItem();
            clothingTab.IconFont = "C";
            clothingTab.Title = "Clothing";
            clothingTab.Content = InitializeTabContent("Clothing", 5);
            clothingTab.TitleFontColor = UIColor.White;
            clothingTab.SelectionColor = UIColor.White;
            clothingTab.FontIconFont = UIFont.FromName("TabIcons", 20);
            collection.Add(clothingTab);

            SfTabItem shoesTab = new SfTabItem();
            shoesTab.IconFont = "F";
            shoesTab.Title = "Shoes";
            shoesTab.Content = InitializeTabContent("Shoes", 5);
            shoesTab.TitleFontColor = UIColor.White;
            shoesTab.SelectionColor = UIColor.White;
            shoesTab.FontIconFont = UIFont.FromName("TabIcons", 20);
            collection.Add(shoesTab);

            SfTabItem fruitsTab = new SfTabItem();
            fruitsTab.IconFont = "H";
            fruitsTab.Title = "Fruits";
            fruitsTab.Content = InitializeTabContent("Fruits", 5);
            fruitsTab.TitleFontColor = UIColor.White;
            fruitsTab.SelectionColor = UIColor.White;
            fruitsTab.FontIconFont = UIFont.FromName("TabIcons", 20);
            collection.Add(fruitsTab);

            SfTabItem toysTab = new SfTabItem();
            toysTab.Title = "Toys";
            toysTab.IconFont = "K";
            toysTab.Content = InitializeTabContent("Toys", 5);
            toysTab.TitleFontColor = UIColor.White;
            toysTab.SelectionColor = UIColor.White;
            toysTab.FontIconFont = UIFont.FromName("TabIcons", 20);
            collection.Add(toysTab);

            tabView.Items = collection;
            Add(tabView);

            tabView.SelectionIndicatorSettings.Color = UIColor.White;
            tabView.TabHeight = 60;

            if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                tabView.TabWidth = 150;
            }

        }

        void InitializeOrderDetails()
        {
            FurnitureList.Add(new OrderDetails("Images/TabView/sofa2.png", "Leather Black Sofa", "$99.50", "5%", "3.9","Warrenty coverred upto 5 years.Its specialty is its bookcase headboard which serves as an easy access to users.Bring a new member into your family.Delivered in non - assembled pieces."));
            FurnitureList.Add(new OrderDetails("Images/TabView/hall.png", "Wooden  Standing Drawer", "$299.40", "1%", "4.1","This versatile wardrobe which strikes the perfect balance between style and functionality. Equipped with a mirror and multiple shelves, this wardrobe is all you will need to store your never-ending wardrobe essentials."));
            FurnitureList.Add(new OrderDetails("Images/TabView/sofa.png", "Semi Fabric Sofa", "$149.90", "10%", "4.4","Engineered wood is created by binding or glueing together at least three thin boards of wood.As a result, your engineered wood furniture will be stable and climate - resistant."));
            FurnitureList.Add(new OrderDetails("Images/TabView/chair.png", "Dinning Chair", "$129.40", "15%", "3.7","Particle boards are a type of engineered wood that are manufactured by binding together small wooden chips, sawdust or wood shavings with synthetic resin. Furniture made of particle boards are lightweight and sturdy."));
            FurnitureList.Add(new OrderDetails("Images/TabView/hall2.png", "Fabric White Sofa", "$199.50", "20%", "4.5","Do not use an overly wet cloth. Wipe your engineered wood furniture clean with a lightly dampened cloth doused either with plain water or a mild cleaning product. Wipe dry with a clean cloth. Avoid exposure to sunlight."));

            ToysList.Add(new OrderDetails("Images/TabView/friends.png", "Warriors", "$9.50", "5%", "4.7","Engineered wood is created by binding or glueing together at least three thin boards of wood. As a result, your engineered wood furniture will be stable and climate-resistant."));
            ToysList.Add(new OrderDetails("Images/TabView/robot.png", "Robots", "$7.97", "15%", "4.2","Particle boards are a type of engineered wood that are manufactured by binding together small wooden chips, sawdust or wood shavings with synthetic resin. Furniture made of particle boards are lightweight and sturdy."));
            ToysList.Add(new OrderDetails("Images/TabView/minion.png", "Minion collections", "$4.55", "20%", "3.5","Do not use an overly wet cloth. Wipe your engineered wood furniture clean with a lightly dampened cloth doused either with plain water or a mild cleaning product. Wipe dry with a clean cloth. Avoid exposure to sunlight."));
            ToysList.Add(new OrderDetails("Images/TabView/train.png", "Train simulation", "$5.97", "15%", "3.9","High quality material has been used. Warrenty coverred upto 5 years. Its specialty is its bookcase headboard which serves as an easy access to users. Bring a new member into your family.Delivered in non-assembled pieces."));
            ToysList.Add(new OrderDetails("Images/TabView/van.png", "Icecream Van", "$18.47", "10%", "4.1","This versatile wardrobe which strikes the perfect balance between style and functionality. Equipped with a mirror and multiple shelves, this wardrobe is all you will need to store your never-ending wardrobe essentials."));

            ClothingList.Add(new OrderDetails("Images/TabView/whiteshirt.png", "Long Sleeve Cotton Shirt", "$25.11", "5%", "4.9","Warrenty coverred upto 5 years.Its specialty is its bookcase headboard which serves as an easy access to users.Bring a new member into your family.Delivered in non - assembled pieces."));
            ClothingList.Add(new OrderDetails("Images/TabView/shirt.png", "Denim Jeans", "$20.21", "10%", "4.1","This versatile wardrobe which strikes the perfect balance between style and functionality. Equipped with a mirror and multiple shelves, this wardrobe is all you will need to store your never-ending wardrobe essentials."));
            ClothingList.Add(new OrderDetails("Images/TabView/tshirt.png", "Short Sleeve T-Shirt", "$11.29", "10%", "4.5","Engineered wood is created by binding or glueing together at least three thin boards of wood. As a result, your engineered wood furniture will be stable and climate-resistant."));
            ClothingList.Add(new OrderDetails("Images/TabView/redcoat.png", "Casual Shirt Semi-Fit", "$35.75", "10%", "4.3","Particle boards are a type of engineered wood that are manufactured by binding together small wooden chips, sawdust or wood shavings with synthetic resin. Furniture made of particle boards are lightweight and sturdy."));
            ClothingList.Add(new OrderDetails("Images/TabView/silvercoat.png", "Classic Slim Fit Suit ", "$74.32", "20%", "4.1","Warrenty coverred upto 5 years. Its specialty is its bookcase headboard which serves as an easy access to users. Bring a new member into your family.Delivered in non-assembled pieces."));
         //   ClothingList.Add(new OrderDetails("Images/TabView/redcoat.jpeg", "Party Suit - Red", "$59.11", "30%", "4.4"));
          
            ShoesList.Add(new OrderDetails("Images/TabView/canvas.png", "Lightweight Shoes", "$12.44", "15%", "3.9","This versatile wardrobe which strikes the perfect balance between style and functionality. Equipped with a mirror and multiple shelves, this wardrobe is all you will need to store your never-ending wardrobe essentials."));
            ShoesList.Add(new OrderDetails("Images/TabView/graycanvas.png", "Trendy Grey Shoes", "$16.37", "20%", "3.7","Engineered wood is created by binding or glueing together at least three thin boards of wood. As a result, your engineered wood furniture will be stable and climate-resistant."));
            ShoesList.Add(new OrderDetails("Images/TabView/boots.png", "Classic Formal Shoes", "$29.45", "35%", "4.3","Particle boards are a type of engineered wood that are manufactured by binding together small wooden chips, sawdust or wood shavings with synthetic resin. Furniture made of particle boards are lightweight and sturdy."));
            ShoesList.Add(new OrderDetails("Images/TabView/blackshoe.png", "White Sporty Shoes", "$29.97", "10%", "4.1","Do not use an overly wet cloth. Wipe your engineered wood furniture clean with a lightly dampened cloth doused either with plain water or a mild cleaning product. Wipe dry with a clean cloth. Avoid exposure to sunlight."));
            ShoesList.Add(new OrderDetails("Images/TabView/leather.png", "Trendy Brown Shoes", "$43.11", "5%", "4.5","High quality material has been used. Warrenty coverred upto 5 years. Its specialty is its bookcase headboard which serves as an easy access to users. Bring a new member into your family.Delivered in non-assembled pieces."));
       
            FruitsList.Add(new OrderDetails("Images/TabView/orange.png", "Orange", "$0.49", "0.5%", "3.9","Engineered wood is created by binding or glueing together at least three thin boards of wood. As a result, your engineered wood furniture will be stable and climate-resistant."));
            FruitsList.Add(new OrderDetails("Images/TabView/blueberry.png", "Blueberries (Imported)", "$1.25", "0.25%", "4.7","Particle boards are a type of engineered wood that are manufactured by binding together small wooden chips, sawdust or wood shavings with synthetic resin. Furniture made of particle boards are lightweight and sturdy."));
            FruitsList.Add(new OrderDetails("Images/TabView/apple.png", "Apple", "$1.45", "5%", "4.1","Do not use an overly wet cloth. Wipe your engineered wood furniture clean with a lightly dampened cloth doused either with plain water or a mild cleaning product. Wipe dry with a clean cloth. Avoid exposure to sunlight."));
            FruitsList.Add(new OrderDetails("Images/TabView/strawberry.png", "Strawberry", "$0.91", "2%", "4.2","High quality material has been used. Warrenty coverred upto 5 years. Its specialty is its bookcase headboard which serves as an easy access to users. Bring a new member into your family.Delivered in non-assembled pieces."));
            FruitsList.Add(new OrderDetails("Images/TabView/banana.png","Banana","$2.23","4%","4.5","This versatile wardrobe which strikes the perfect balance between style and functionality. Equipped with a mirror and multiple shelves, this wardrobe is all you will need to store your never-ending wardrobe essentials."));
        }
    }
}

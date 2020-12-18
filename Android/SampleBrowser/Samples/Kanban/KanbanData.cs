#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using Syncfusion.SfKanban.Android;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace SampleBrowser
{
    public class CustomKanbanModel : KanbanModel
    {
        public string Name
        {
            get;
            set;
        }
    }

    class KanbanData
    {
        public ObservableCollection<CustomKanbanModel> Data
        {
            get;
            set;
        }

        public KanbanData()
        {
            Data = ItemsSourceCards();
        }

        ObservableCollection<CustomKanbanModel> ItemsSourceCards()
        {
            ObservableCollection<CustomKanbanModel> cards = new ObservableCollection<CustomKanbanModel>();

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 1,
                    Title = "iOS - 1",
                    ImageURL = "user.png",
                    Category = "Open",
                    Description = "Analyze customer requirements",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Release Bug" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 6,
                    Title = "Xamarin - 6",
                    ImageURL = "user1.png",
                    Category = "Open",
                    Description = "Show the retrived data from the server in grid control",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 3,
                    Title = "iOS - 3",
                    ImageURL = "user2.png",
                    Category = "Open",
                    Description = "Fix the filtering issues reported in safari",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 11,
                    Title = "iOS - 11",
                    ImageURL = "user3.png",
                    Category = "Open",
                    Description = "Add input validation for editing",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 15,
                    Title = "Android - 15",
                    Category = "Open",
                    ImageURL = "user4.png",
                    Description = "Arrange web meeting for cutomer requirement",
                    ColorKey = "Red",
                    Tags = new string[] { "Story", "Kanban" }
                });

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 3,
                    Title = "Android - 3",
                    Category = "Code Review",
                    ImageURL = "user5.png",
                    Description = "API Improvements",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug", "Customer" }
                });

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 4,
                    Title = "UWP - 4",
                    ImageURL = "user.png",
                    Category = "Code Review",
                    Description = "Enhance editing functionality",
                    ColorKey = "Brown",
                    Tags = new string[] { "Story", "Kanban" }
                });

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 9,
                    Title = "Xamarin - 9",
                    ImageURL = "user1.png",
                    Category = "Code Review",
                    Description = "Improve application performance",
                    ColorKey = "Orange",
                    Tags = new string[] { "Story", "Kanban" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 13,
                    Title = "UWP - 13",
                    ImageURL = "user3.png",
                    Category = "In Progress",
                    Description = "Add responsive support to applicaton",
                    ColorKey = "Brown",
                    Tags = new string[] { "Story", "Kanban" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 17,
                    Title = "Xamarin - 17",
                    Category = "In Progress",
                    ImageURL = "user5.png",
                    Description = "Fix the issues reported in IE browser",
                    ColorKey = "Brown",
                    Tags = new string[] { "Bug", "Customer" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 21,
                    Title = "Xamarin - 21",
                    Category = "In Progress",
                    ImageURL = "user2.png",
                    Description = "Improve performance of editing functionality",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug", "Customer" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 19,
                    Title = "iOS - 19",
                    Category = "In Progress",
                    ImageURL = "user4.png",
                    Description = "Fix the issues reported by the customer",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 8,
                    Title = "Android",
                    Category = "Code Review",
                    ImageURL = "user.png",
                    Description = "Check login page validation",
                    ColorKey = "Brown",
                    Tags = new string[] { "Feature" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 24,
                    Title = "UWP - 24",
                    ImageURL = "user1.png",
                    Category = "In Progress",
                    Description = "Test editing functionality",
                    ColorKey = "Orange",
                    Tags = new string[] { "Feature", "Customer", "Release" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 20,
                    Title = "iOS - 20",
                    Category = "In Progress",
                    ImageURL = "user4.png",
                    Description = "Fix the issues reported in data binding",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 12,
                    Title = "Xamarin - 12",
                    Category = "In Progress",
                    ImageURL = "user5.png",
                    Description = "Test editing functionality",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 11,
                    Title = "iOS - 11",
                    Category = "In Progress",
                    ImageURL = "user1.png",
                    Description = "Check filtering validation",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 13,
                    Title = "UWP - 13",
                    ImageURL = "user.png",
                    Category = "Closed",
                    Description = "Fix cannot open user's default database sql error",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug", "Internal", "Release" }
                });

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 14,
                    Title = "Android - 14",
                    Category = "Closed",
                    ImageURL = "user3.png",
                    Description = "Arrange web meeting with customer to get login page requirement",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 15,
                    Title = "Xamarin - 15",
                    Category = "Closed",
                    ImageURL = "user5.png",
                    Description = "Login page validation",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 16,
                    Title = "Xamarin - 16",
                    ImageURL = "user.png",
                    Category = "Closed",
                    Description = "Test the application in IE browser",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 20,
                    Title = "UWP - 20",
                    ImageURL = "user5.png",
                    Category = "Closed",
                    Description = "Analyze stored procedure",
                    ColorKey = "Brown",
                    Tags = new string[] { "CustomSample", "Customer", "Incident" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 21,
                    Title = "Android - 21",
                    Category = "Closed",
                    ImageURL = "user4.png",
                    Description = "Arrange web meeting with customer to get editing requirements",
                    ColorKey = "Orange",
                    Tags = new string[] { "Story", "Improvement" }
                }
            );

            cards.Add(
                 new CustomKanbanModel()
                 {
                     ID = 1,
                     Title = "Margherita",
                     ImageURL = "margherita.png",
                     Category = "Menu",
                     Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only",
                     Tags = new string[] { "Cheese" }
                 }
             );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 2,
                    Title = "Double Cheese Margherita",
                    ImageURL = "doublecheesemargherita.png",
                    Category = "Menu",
                    Description = "The minimalist classic with a double helping of cheese",
                    Tags = new string[] { "Cheese" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 3,
                    Title = "Bucolic Pie",
                    ImageURL = "bucolicpie.png",
                    Category = "Menu",
                    Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes.",
                    Tags = new string[] { "Onions", "Capsicum" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 4,
                    Title = "Bumper Crop",
                    ImageURL = "bumpercrop.png",
                    Category = "Menu",
                    Description = "Can't get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more.",
                    Tags = new string[] { "Tomato", "Mushroom" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 5,
                    Title = "Spice of Life",
                    ImageURL = "spiceoflife.png",
                    Category = "Menu",
                    Description = "Thrill-seeking, heat-seeking pizza people only.  It's hot. Trust us",
                    Tags = new string[] { "Corn", "Gherkins" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 6,
                    Title = "Very Nicoise",
                    ImageURL = "verynicoise.png",
                    Category = "Menu",
                    Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.",
                    Tags = new string[] { "Red pepper", "Capsicum" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 8,
                    Title = "Salad Daze",
                    ImageURL = "saladdaze.png",
                    Category = "Menu",
                    Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion.",
                    Tags = new string[] { "Capsicum", "Mushroom" }
                }
            );


            cards.Add(
             new CustomKanbanModel()
             {
                 ID = 9,
                 Title = "Margherita",
                 ImageURL = "margherita.png",
                 Category = "Delivery",
                 Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only",
                 Tags = new string[] { "Cheese" }
             }
         );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 10,
                    Title = "Double Cheese Margherita",
                    ImageURL = "doublecheesemargherita.png",
                    Category = "Ready",
                    Description = "The minimalist classic with a double helping of cheese",
                    Tags = new string[] { "Cheese" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 11,
                    Title = "Bucolic Pie",
                    ImageURL = "bucolicpie.png",
                    Category = "Dining",
                    Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes.",
                    Tags = new string[] { "Onions", "Capsicum" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 12,
                    Title = "Bumper Crop",
                    ImageURL = "bumpercrop.png",
                    Category = "Ready",
                    Description = "Can't get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more.",
                    Tags = new string[] { "Tomato", "Mushroom" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 13,
                    Title = "Spice of Life",
                    ImageURL = "spiceoflife.png",
                    Category = "Ready",
                    Description = "Thrill-seeking, heat-seeking pizza people only.  It's hot. Trust us",
                    Tags = new string[] { "Corn", "Gherkins" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 14,
                    Title = "Very Nicoise",
                    ImageURL = "verynicoise.png",
                    Category = "Dining",
                    Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.",
                    Tags = new string[] { "Red pepper", "Capsicum" }
                }
            );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 16,
                    Title = "Salad Daze",
                    ImageURL = "saladdaze.png",
                    Category = "Delivery",
                    Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion.",
                    Tags = new string[] { "Capsicum", "Mushroom" }
                }
            );



            cards.Add(
            new CustomKanbanModel()
            {
                ID = 17,
                Title = "Bumper Crop",
                ImageURL = "bumpercrop.png",
                Category = "Door Delivery",
                Description = "Can't get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more.",
                Tags = new string[] { "Tomato", "Mushroom" }
            }
        );

            cards.Add(
                new CustomKanbanModel()
                {
                    ID = 18,
                    Title = "Spice of Life",
                    ImageURL = "spiceoflife.png",
                    Category = "Door Delivery",
                    Description = "Thrill-seeking, heat-seeking pizza people only.  It's hot. Trust us",
                    Tags = new string[] { "Corn", "Gherkins" }
                }
            );
            return cards;
        }
    }
}
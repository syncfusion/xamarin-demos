#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfKanban.XForms;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleBrowser.SfKanban
{
    public class ThemesViewModel
    {
        public ObservableCollection<KanbanModel> Cards { get; set; }
        
        public ThemesViewModel()
        {
          
            Cards = new ObservableCollection<KanbanModel>();
            
            Cards.Add(
                new KanbanModel()
                {
                    ID = 1,
                    Title = "iOS - 1",
                    ImageURL = "People_Circle1.png",
                    Category = "Open",
                    Description = "Analyze customer requirements",
                    Tags = new string[] { "Bug", "Customer", "Release Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 6,
                    Title = "Xamarin - 6",
                    ImageURL = "People_Circle2.png",
                    Category = "Open",
                    Description = "Show the retrived data from the server in grid control",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 3,
                    Title = "iOS - 3",
                    ImageURL = "People_Circle3.png",
                    Category = "Open",
                    Description = "Fix the filtering issues reported in safari",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 11,
                    Title = "iOS - 11",
                    ImageURL = "People_Circle4.png",
                    Category = "Open",
                    Description = "Add input validation for editing",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 15,
                    Title = "Android - 15",
                    Category = "Open",
                    ImageURL = "People_Circle5.png",
                    Description = "Arrange web meeting for cutomer requirement",
                    Tags = new string[] { "Story", "Kanban" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 3,
                    Title = "Android - 3",
                    Category = "Code Review",
                    ImageURL = "People_Circle6.png",
                    Description = "API Improvements",
                    Tags = new string[] { "Bug", "Customer" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 4,
                    Title = "UWP - 4",
                    ImageURL = "People_Circle6.png",
                    Category = "Code Review",
                    Description = "Enhance editing functionality",
                    Tags = new string[] { "Story", "Kanban" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 9,
                    Title = "Xamarin - 9",
                    ImageURL = "People_Circle7.png",
                    Category = "Code Review",
                    Description = "Improve application performance",
                    Tags = new string[] { "Story", "Kanban" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 13,
                    Title = "UWP - 13",
                    ImageURL = "People_Circle8.png",
                    Category = "In Progress",
                    Description = "Add responsive support to applicaton",
                    Tags = new string[] { "Story", "Kanban" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 17,
                    Title = "Xamarin - 17",
                    Category = "In Progress",
                    ImageURL = "People_Circle9.png",
                    Description = "Fix the issues reported in IE browser",
                    Tags = new string[] { "Bug", "Customer" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 21,
                    Title = "Xamarin - 21",
                    Category = "In Progress",
                    ImageURL = "People_Circle10.png",
                    Description = "Improve performance of editing functionality",
                    Tags = new string[] { "Bug", "Customer" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 19,
                    Title = "iOS - 19",
                    Category = "In Progress",
                    ImageURL = "People_Circle11.png",
                    Description = "Fix the issues reported by the customer",
                    Tags = new string[] { "Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 8,
                    Title = "Android",
                    Category = "Code Review",
                    ImageURL = "People_Circle12.png",
                    Description = "Check login page validation",
                    Tags = new string[] { "Feature" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 24,
                    Title = "UWP - 24",
                    ImageURL = "People_Circle13.png",
                    Category = "In Progress",
                    Description = "Test editing functionality",
                    Tags = new string[] { "Feature", "Customer", "Release" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 20,
                    Title = "iOS - 20",
                    Category = "In Progress",
                    ImageURL = "People_Circle14.png",
                    Description = "Fix the issues reported in data binding",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 12,
                    Title = "Xamarin - 12",
                    Category = "In Progress",
                    ImageURL = "People_Circle15.png",
                    Description = "Test editing functionality",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 11,
                    Title = "iOS - 11",
                    Category = "In Progress",
                    ImageURL = "People_Circle16.png",
                    Description = "Check filtering validation",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 13,
                    Title = "UWP - 13",
                    ImageURL = "People_Circle17.png",
                    Category = "Closed",
                    Description = "Fix cannot open user's default database sql error",
                    Tags = new string[] { "Bug", "Internal", "Release" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 14,
                    Title = "Android - 14",
                    Category = "Closed",
                    ImageURL = "People_Circle18.png",
                    Description = "Arrange web meeting with customer to get login page requirement",
                    Tags = new string[] { "Feature" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 15,
                    Title = "Xamarin - 15",
                    Category = "Closed",
                    ImageURL = "People_Circle19.png",
                    Description = "Login page validation",
                    Tags = new string[] { "Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 16,
                    Title = "Xamarin - 16",
                    ImageURL = "People_Circle20.png",
                    Category = "Closed",
                    Description = "Test the application in IE browser",
                    Tags = new string[] { "Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 20,
                    Title = "UWP - 20",
                    ImageURL = "People_Circle21.png",
                    Category = "Closed",
                    Description = "Analyze stored procedure",
                    Tags = new string[] { "CustomSample", "Customer", "Incident" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 21,
                    Title = "Android - 21",
                    Category = "Closed",
                    ImageURL = "People_Circle22.png",
                    Description = "Arrange web meeting with customer to get editing requirements",
                    Tags = new string[] { "Story", "Improvement" }
                }
            );
        }
    }
}

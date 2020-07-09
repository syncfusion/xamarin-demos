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
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class ToDoListRepository
    {
        #region Constructor

        public ToDoListRepository()
        {

        }

        #endregion

        #region Methods

        internal ObservableCollection<ToDoItem> GetToDoList()
        {
            var groceryList = new ObservableCollection<ToDoItem>();
            var random = new Random();

            for (int i = 0; i < toDoLists.Count(); i++)
            {
                var gallery = new ToDoItem()
                {
                    Name = toDoLists[i],
                    CategoryName = GetCategoryList(i)
                };
                groceryList.Add(gallery);
            }
            return groceryList;
        }

        private string GetCategoryList(int pos)
        {
            string toDoCategory;

            if (pos < 4)
                toDoCategory = toDoCategoryLists[0];
            else if (pos < 8)
                toDoCategory = toDoCategoryLists[1];
            else if (pos < 13)
                toDoCategory = toDoCategoryLists[2];
            else
                toDoCategory = toDoCategoryLists[3];
            
            return toDoCategory;
        }

        string[] toDoLists = new string[]
        {
            "Reserve party venue",
            "Choose party attire",
            "Compile guest list",
            "Choose invitation",
            "Create wedding website",
            "Buy wedding ring",
            "Apply marriage license",
            "Hire photographer",
            "Buy wedding dress",
            "Refine guest list",
            "Send invitations",
            "Hire florist",
            "Shop for decorations",
            "Hire musicians",
            "Arrange catering",
            "Shop for groceries",
            "Book hotel for guest",
            "Plan honeymoon",
            "Book transportation",
            "Order wedding cake",
        };

        string[] toDoCategoryLists = new string[]
        {
            "This Week",
            "Next Week",
            "Next Month",
            "Later"
        };

        #endregion
    }
}

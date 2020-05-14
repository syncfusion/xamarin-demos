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
    public class ListViewGalleryInfoRepository
    {
        #region Constructor

        public ListViewGalleryInfoRepository()
        {

        }

        #endregion

        #region GetGalleryInfo

        internal ObservableCollection<ListViewGalleryInfo> GetGalleryInfo()
        {
            var galleryInfo = new ObservableCollection<ListViewGalleryInfo>();
            var random = new Random();
            for (int i = 1; i <= 30; i++)
            {
                var gallery = new ListViewGalleryInfo()
                {
                    Image = Images[i-1] + ".jpg",
                    ImageTitle = random.Next(1242, 5383) + ".jpg",
                    CreatedDate = GetCreatedDate(i),
                    IsFavorite = i % 2 == 0 || i % 3 == 0 ? true : false
                };
                galleryInfo.Add(gallery);
            }
            return galleryInfo;
        }

        private string GetCreatedDate(int pos)
        {
            if (pos <= 4)
                return CreatedDates[0];
            else if (pos <= 8)
                return CreatedDates[1];
            else if (pos <= 11)
                return CreatedDates[2];
            else if (pos <= 16)
                return CreatedDates[3];
            else if (pos <= 23)
                return CreatedDates[4];
            return CreatedDates[5];
        }

        #endregion

        #region GelleryInfo

        string[] CreatedDates = new string[] {
            "This Week",
            "Last Week",
            "Two Weeks Ago",
            "Three Weeks Ago",
            "Last Month",
            "Older",
        };

        string[] Images = new string[]
        {          
            "DadSon",
            "Guitar",
            "Van",
            "City",
            "Ladybug",
            "Minitoys",
            "Friends",
            "Spices1",
            "Chocolate",
            "Kids",
            "BrownCat",
            "Toys",
            "CollegeGirl",
            "Radio",
            "Playing",
            "Hight",
            "Train",
            "Peacock",
            "Spices2",
            "IdealHouse",
            "Calculation",
            "Dog",
            "Sports",
            "Openbook",
            "Money",
            "Violin",
            "Car",
            "Bell",
            "Listeningmusic",
            "Horse",
        };
        #endregion
    }
}

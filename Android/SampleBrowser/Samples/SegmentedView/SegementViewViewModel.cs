#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using Android.Graphics;
using Syncfusion.Android.Buttons;
namespace SampleBrowser
{
    public class SegementViewViewModel
    {
        internal ObservableCollection<SfSegmentItem> SizeCollection;
        internal ObservableCollection<SfSegmentItem> EntertainCollection = new ObservableCollection<SfSegmentItem>();
        internal ObservableCollection<string> ClothTypeCollection = new ObservableCollection<string>();
        internal ObservableCollection<SfSegmentItem> PrimaryColors = new ObservableCollection<SfSegmentItem>();
       
        public SegementViewViewModel(Android.Content.Context con)
        {
            ClothTypeCollection.Add("Formals");
            ClothTypeCollection.Add("Casuals");
            ClothTypeCollection.Add("Trendy");
            Typeface tf = Typeface.CreateFromAsset(con.Assets, "Segmented.ttf");
            Typeface colorfontFamily = Typeface.CreateFromAsset(con.Assets, "SegmentIcon.ttf");

            SizeCollection = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "A", Text="XS", FontIconTypeface = tf,FontColor=Color.ParseColor("#3F3F3F")},
                 new SfSegmentItem(){IconFont = "A", Text="S",FontColor=Color.ParseColor("#3F3F3F")},
                  new SfSegmentItem(){IconFont = "A", Text="M",FontColor=Color.ParseColor("#3F3F3F")},
                   new SfSegmentItem(){IconFont = "A", Text="L",FontColor=Color.ParseColor("#3F3F3F")},
                    new SfSegmentItem(){IconFont = "A", Text="XL",FontColor=Color.ParseColor("#3F3F3F")},
            };

            EntertainCollection = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "A",  FontIconFontColor=Color.ParseColor("#233a7e"), FontIconTypeface = tf},
                new SfSegmentItem(){IconFont = "A",  FontIconFontColor=Color.ParseColor("#7e8188"),  FontIconTypeface = tf},
                new SfSegmentItem(){IconFont = "A",  FontIconFontColor=Color.ParseColor("#292639"), FontIconTypeface = tf},
                new SfSegmentItem(){IconFont = "A",  FontIconFontColor=Color.ParseColor("#11756d"),  FontIconTypeface = tf},
                new SfSegmentItem(){IconFont = "A",  FontIconFontColor=Color.ParseColor("#6e0022"),  FontIconTypeface = tf},
            };

            PrimaryColors = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "7",  FontIconFontColor=Color.ParseColor("#32318E"), Text="Square",FontIconFontSize=32,  FontIconTypeface = colorfontFamily},
                new SfSegmentItem(){IconFont = "7",  FontIconFontColor=Color.ParseColor("#2F7DC0"), Text="Square",FontIconFontSize=32,  FontIconTypeface = colorfontFamily},
                new SfSegmentItem(){IconFont = "7",  FontIconFontColor=Color.ParseColor("#953376"), Text="Square",FontIconFontSize=32,  FontIconTypeface = colorfontFamily},
                new SfSegmentItem(){IconFont = "7",  FontIconFontColor=Color.ParseColor("#B33F3F"), Text="Square",FontIconFontSize=32,  FontIconTypeface = colorfontFamily},
                new SfSegmentItem(){IconFont = "7",  FontIconFontColor=Color.ParseColor("#F1973F"), Text="Square",FontIconFontSize=32,  FontIconTypeface = colorfontFamily},
                new SfSegmentItem(){IconFont = "7",  FontIconFontColor=Color.ParseColor("#C9D656"), Text="Square",FontIconFontSize=32,  FontIconTypeface = colorfontFamily},
                new SfSegmentItem(){IconFont = "7",  FontIconFontColor=Color.ParseColor("#008D7F"), Text="Square",FontIconFontSize=32,  FontIconTypeface = colorfontFamily},
            };
        }
    }
}

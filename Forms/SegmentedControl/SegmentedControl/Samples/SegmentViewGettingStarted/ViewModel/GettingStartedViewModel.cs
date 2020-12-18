#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;

namespace SampleBrowser.SegmentedControl
{
    public  class GettingStartedViewModel :INotifyPropertyChanged
    {
        private string fontIconText;

        public string FontIconText
        {
            get
            {
                return fontIconText;
            }
            set
            {
                fontIconText = value;
                OnPropertyChanged("FontIconText");
            }
        }
        private ObservableCollection<SfSegmentItem> sizeCollection = new ObservableCollection<SfSegmentItem>();
        /// <summary>
        /// Item collectio for Different size of shirt
        /// </summary>
        public ObservableCollection<SfSegmentItem> SizeCollection
        {
            get { return sizeCollection; }
            set { sizeCollection = value; }
        }

        private ObservableCollection<SfSegmentItem> clothTypeCollection = new ObservableCollection<SfSegmentItem>();
        /// <summary>
        /// Item collection for types of cloth
        /// </summary>
        public ObservableCollection<SfSegmentItem> ClothTypeCollection
        {
            get { return clothTypeCollection; }
            set { clothTypeCollection = value; }
        }
        /// <summary>
        /// Item collection for different colors of shirt to be selected.
        /// </summary>
        public ObservableCollection<SfSegmentItem> PrimaryColors { get; set; }


        public GettingStartedViewModel()
        {
            ClothTypeCollection = new ObservableCollection<SfSegmentItem>() { new SfSegmentItem() { Text = "Formals", FontColor = Color.Black }, new SfSegmentItem() { Text = "Casuals", FontColor = Color.Black }, new SfSegmentItem() { Text = "Trendy", FontColor = Color.Black } };
            SizeCollection = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "A", Text="XS",FontColor=Color.FromHex("#3F3F3F") }, 
                 new SfSegmentItem(){IconFont = "A", Text="S",FontColor=Color.FromHex("#3F3F3F")},
                  new SfSegmentItem(){IconFont = "A", Text="M",FontColor=Color.FromHex("#3F3F3F")},
                   new SfSegmentItem(){IconFont = "A", Text="L",FontColor=Color.FromHex("#3F3F3F")},
                    new SfSegmentItem(){IconFont = "A", Text="XL",FontColor=Color.FromHex("#3F3F3F")},

            };


            var fontFamily = "Segmented.ttf";
            var colorfontFamily = "SegmentIcon.ttf";

            if (Device.RuntimePlatform == Device.UWP)
            {
#if COMMONSB
                fontFamily = "/Assets/Fonts/Segmented.ttf#Segmented";
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    fontFamily = "/Assets/Fonts/Segmented.ttf#Segmented";
                }
                else
                {
                    fontFamily = $"ms-appx:///SampleBrowser.SfSegmentedControl.UWP/Assets/Fonts/Segmented.ttf#Segmented"; 
                }
#endif
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                fontFamily = "segment2";
            }
            else if (Device.RuntimePlatform == Device.WPF)
            {
                fontFamily = "/Assets/Fonts/Segmented.ttf#Segmented";
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
#if COMMONSB
                colorfontFamily = "/Assets/Fonts/SegmentIcon.ttf#segment2";
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    colorfontFamily = "/Assets/Fonts/SegmentIcon.ttf#segment2";
                }
                else
                {
                    colorfontFamily = $"ms-appx:///SampleBrowser.SfSegmentedControl.UWP/Assets/Fonts/SegmentIcon.ttf#segment2"; 
                }
#endif
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                colorfontFamily = "segment2";
            }
            else if(Device.RuntimePlatform == Device.WPF)
            {
                colorfontFamily = "/Assets/Fonts/SegmentIcon.ttf#segment2";
            }


            var SegoeFontFamily = "Segoe_MDL2_Assets.ttf";

            if (Device.RuntimePlatform == Device.UWP)
            {
#if COMMONSB
                SegoeFontFamily = "/Assets/Fonts/Segoe_MDL2_Assets.ttf#Segoe MDL2 Assets";
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    SegoeFontFamily = "/Assets/Fonts/Segoe_MDL2_Assets.ttf#Segoe MDL2 Assets";
                }
                else
                {
                    SegoeFontFamily = $"ms-appx:///SampleBrowser.SfSegmentedControl.UWP/Assets/Fonts/Segoe_MDL2_Assets.ttf#Segoe MDL2 Assets";
                }
#endif
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                SegoeFontFamily = "Segoe MDL2 Assets";
            }
            else if(Device.RuntimePlatform == Device.WPF)
            {
                SegoeFontFamily = "/Assets/Fonts/Segoe_MDL2_Assets.ttf#Segoe MDL2 Assets";
            }

            PrimaryColors = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#32318E"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#2F7DC0"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#953376"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#B33F3F"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#F1973F"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#C9D656"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#008D7F"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
            };

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

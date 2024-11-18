#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;

namespace SampleBrowser.SegmentedControl
{
    public class CustomizationViewModel
    {
        #region Properties

        /// <summary>
        /// Get or set the Backlight for the device screen
        /// </summary>
        public ObservableCollection<SfSegmentItem> BackLightCollection { get; set; }

        /// <summary>
        /// Display the different font icons used inside the 
        /// </summary>
        public ObservableCollection<SfSegmentItem> IconCollection { get; set; }

        /// <summary>
        /// Collection which hold the font icon and text
        /// </summary>
        public ObservableCollection<SfSegmentItem> Image_textCollection { get; set; }

        /// <summary>
        /// Collection which hold the font icon and text
        /// </summary>
        public ObservableCollection<SfSegmentItem> TextCollection { get; set; }

        /// <summary>
        /// Collection which have the different colors.
        /// </summary>
        public ObservableCollection<SfSegmentItem> PrimaryColors { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor of customization view class
        /// </summary>
        public CustomizationViewModel()
        {
            var fontFamily = "SegmentIcon.ttf";
            if (Device.RuntimePlatform == Device.UWP)
            {
#if COMMONSB
                fontFamily = "/Assets/Fonts/SegmentIcon.ttf#segment2";
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    fontFamily = "/Assets/Fonts/SegmentIcon.ttf#segment2";
                }
                else
                {
                    fontFamily = $"ms-appx:///SampleBrowser.SfSegmentedControl.UWP/Assets/Fonts/SegmentIcon.ttf#segment2";
                }
#endif
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                fontFamily = "segment2";
            }
            else if (Device.RuntimePlatform == Device.WPF)
            {
                fontFamily = "Assets/Fonts/SegmentIcon.ttf#segment2";
            }
                

            var SegoeFontFamily = string.Empty;

            if (Device.RuntimePlatform == Device.UWP)
            {
#if COMMONSB
                SegoeFontFamily = string.Empty;
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    SegoeFontFamily = string.Empty;
                }
                else
                {
                    SegoeFontFamily = string.Empty;
                }
#endif
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                SegoeFontFamily = string.Empty;
            }
            else if (Device.RuntimePlatform == Device.WPF)
            {
                SegoeFontFamily = string.Empty;
            }
            BackLightCollection = new ObservableCollection<SfSegmentItem> { new SfSegmentItem() { Text = "Backlight On", FontColor = Color.White }, new SfSegmentItem() { Text = "Backlight Off", FontColor = Color.White } };
            IconCollection = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "1",  FontIconFontColor=Color.FromHex("#04ACAC"), FontIconFontSize=18,  FontIconFontFamily = fontFamily },
                new SfSegmentItem(){IconFont = "2",  FontIconFontColor=Color.FromHex("#04ACAC"), FontIconFontSize=18,  FontIconFontFamily = fontFamily},
                new SfSegmentItem(){IconFont = "3",  FontIconFontColor=Color.FromHex("#04ACAC"), FontIconFontSize=18,  FontIconFontFamily = fontFamily},
                new SfSegmentItem(){IconFont = "4",  FontIconFontColor=Color.FromHex("#04ACAC"),FontIconFontSize=18,  FontIconFontFamily = fontFamily},
                new SfSegmentItem(){IconFont = "5",  FontIconFontColor=Color.FromHex("#04ACAC"),FontIconFontSize=18,  FontIconFontFamily = fontFamily},
            };
            Image_textCollection = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "6",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text="Day", FontIconFontSize=18,  FontIconFontFamily = fontFamily},
                new SfSegmentItem(){IconFont = "6",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text="Week",FontIconFontSize=18,  FontIconFontFamily = fontFamily},
                new SfSegmentItem(){IconFont = "6",  FontIconFontColor=Color.FromHex("#FFFFFF"),  FontColor=Color.FromHex("#FFFFFF"), Text="Month", FontIconFontSize=18,  FontIconFontFamily = fontFamily},
            };

            TextCollection = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "6",  Text="Day", FontIconFontSize=18,  FontIconFontFamily = fontFamily},
                new SfSegmentItem(){IconFont = "6",  Text="Week",FontIconFontSize=18,  FontIconFontFamily = fontFamily},
                new SfSegmentItem(){IconFont = "6",  Text="Month", FontIconFontSize=18,  FontIconFontFamily = fontFamily},
            };

            PrimaryColors = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#32318E"), Text="Square",FontIconFontSize=32, },
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#2F7DC0"), Text="Square",FontIconFontSize=32, },
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#953376"), Text="Square",FontIconFontSize=32, },
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#B33F3F"), Text="Square",FontIconFontSize=32, },
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#F1973F"), Text="Square",FontIconFontSize=32, },
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#C9D656"), Text="Square",FontIconFontSize=32, },
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#008D7F"), Text="Square",FontIconFontSize=32, },
            };
            }
#endregion
    }
}

#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using SampleBrowser.Core;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SegmentedControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegmentViewGettingStarted : SampleView
    {
        private readonly GettingStartedViewModel _viewModel = new GettingStartedViewModel();
        private string _fontIconText = String.Empty;

        public SegmentViewGettingStarted()
        {
            InitializeComponent();
            SegmentedView1.ItemsSource = _viewModel.SizeCollection;
            this.PrimaryColorSegment.ItemsSource = _viewModel.PrimaryColors;
            this.clothType.ItemsSource = _viewModel.ClothTypeCollection;
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                descriptiontext.FontSize = 16;
                descriptiondetail.FontSize = 16;
                sizetext.FontSize = 16;
                colortext.FontSize = 16;
                detail.FontSize = 16;
                preview.FontSize = 150;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                MainGrid.HeightRequest = width;
            }
            else
                MainGrid.HeightRequest = height;
        }

        /// <summary>
        /// Raised when change the color from segmented control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Handle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.PrimaryColorSegment.SelectionTextColor = _viewModel.PrimaryColors[e.Index].FontIconFontColor;
            this.preview.TextColor = _viewModel.PrimaryColors[e.Index].FontIconFontColor;
        }

     
        /// <summary>
        /// Raised when select the cloth type segmented control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClothType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = e.Index;
            if (index == 0)
            {
                _fontIconText = "A";
            }
            else if (index == 1)
            {
                _fontIconText = "B";
            }
            else
            {
                _fontIconText = "C";
            }
            this.preview.Text = _fontIconText;
        }
    }

    /// <summary>
    /// To get the platformm specfic path for font icon.
    /// </summary>
    public class SegmentedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == "Android")
            {
                if (parameter != null && parameter is string)
                    return "Segmented.ttf#" + parameter.ToString();
                else
                    return "Segmented.ttf";
            }
            else if (Device.RuntimePlatform == "iOS")
            {
                return "Segmented";
            }
            else
            {
#if COMMONSB
                return "/Assets/Fonts/Segmented.ttf#Segmented";
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    return "/Assets/Fonts/Segmented.ttf#Segmented";
                }
                else
                {
                    return
                        $"ms-appx:///SampleBrowser.SfSegmentedControl.UWP/Assets/Fonts/Segmented.ttf#Segmented"; // "SampleBrowser.SfTabView.UWP\\Assets/Fonts/NestedTab.ttf#NestedTab";
                }
#endif
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

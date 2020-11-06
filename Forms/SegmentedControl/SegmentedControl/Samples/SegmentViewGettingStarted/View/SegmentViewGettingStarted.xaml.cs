#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using SelectionChangedEventArgs = Syncfusion.XForms.Buttons.SelectionChangedEventArgs;

namespace SampleBrowser.SegmentedControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegmentViewGettingStarted : SampleView
    {
        private readonly GettingStartedViewModel _viewModel = new GettingStartedViewModel();

        public SegmentViewGettingStarted()
        {
            InitializeComponent();
            this.BindingContext = _viewModel;
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                descriptiontext.FontSize = 16;
                descriptiondetail.FontSize = 16;
                sizetext.FontSize = 16;
                colortext.FontSize = 16;
                detail.FontSize = 16;
                preview.FontSize = 150;
            }
            if (Device.Idiom == TargetIdiom.Desktop)
            {
                MainGrid.VerticalOptions = LayoutOptions.Center;
                MainGrid.HorizontalOptions = LayoutOptions.Center;
                MainGrid.WidthRequest = 500;
                MainGrid.RowDefinitions[0].Height = 100;
                MainGrid.RowDefinitions[1].Height = 150;
                MainGrid.RowDefinitions[2].Height = 20;
                MainGrid.RowDefinitions[3].Height = 100;
                MainGrid.RowDefinitions[4].Height = 100;
                MainGrid.RowDefinitions[5].Height = 50;
                clothType.HorizontalOptions = LayoutOptions.Center;
                PrimaryColorSegment.HorizontalOptions = LayoutOptions.Center;
                clothType.SegmentWidth = 120;
                SegmentedView1.HorizontalOptions = LayoutOptions.Center;
                SegmentedView1.WidthRequest = 350;
                SegmentedView1.Margin = new Thickness(10, 20, 0, 0);
                MainScrollView.HorizontalOptions = LayoutOptions.Center;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Device.Idiom != TargetIdiom.Desktop)
            {
                if (width > height)
                {
                    MainGrid.HeightRequest = width;
                }
                else
                {
                    MainGrid.HeightRequest = height;
                }
            }
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
                _viewModel.FontIconText = "A";
            }
            else if (index == 1)
            {
                _viewModel.FontIconText = "B";
            }
            else
            {
                _viewModel.FontIconText = "C";
            }

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
                    if (Device.RuntimePlatform == "UWP")
                        return "/Assets/Fonts/Segmented.ttf#Segmented";
                    else
                        return "pack://application:,,,/SampleBrowser.SfSegmentedControl.WPF;component/Assets/Fonts/#Segmented";
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

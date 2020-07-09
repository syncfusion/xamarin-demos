#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Reflection;
using SampleBrowser.Core;
using Syncfusion.ListView.XForms;
using Syncfusion.XForms.ParallaxView;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfParallaxView
{
    [Preserve(AllMembers = true)]

    public partial class ParallaxView : SampleView
    {
        public ParallaxView()
        {
            InitializeComponent();
            Assembly assembly = typeof(ParallaxView).GetTypeInfo().Assembly;
            image.Source = ImageSource.FromFile("ParallaxWallpaper.png");
            listview.ItemsSource = viewModel.GetItemSource();
            parallaxview.Source = listview;
            speed_slider.BindingContext = viewModel;
            speed_value.BindingContext = speed_slider;
        }
    }
}

#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using System.Diagnostics;

namespace PatientMonitor
{
	public partial class HistoryView : ContentPage
    {
        LiveHistoryViewModel liveVM;
        int buttonClickValue = 0;
        Assembly assembly;
        public HistoryView()
        {
            assembly = typeof(HistoryView).Assembly;
            if (Device.OS == TargetPlatform.Android || (Device.OS == TargetPlatform.iOS))
            {
                NavigationPage.SetHasNavigationBar(this, true);
            }
            else
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            NavigationPage.SetHasBackButton(this, true);
		   InitializeComponent();            

            pri.MajorTickStyle.StrokeColor = Color.Transparent;
            pri.LabelStyle.TextColor = Color.Transparent;
            pri.MajorTickStyle.TickSize = 0;
            pri.LabelStyle.Font = Xamarin.Forms.Font.SystemFontOfSize(0d);
            pri.LabelStyle.Margin = new Thickness(0);
            pri.Title.Margin = new Thickness(0);


            sec.MajorTickStyle.StrokeColor = Color.Transparent;
            //sec.LabelCreated += Sec_LabelCreated;
            pri1.MajorTickStyle.StrokeColor = Color.Transparent;
            pri1.LabelStyle.TextColor = Color.Transparent;
            pri1.MajorTickStyle.TickSize = 0;
            pri1.LabelStyle.Font = Xamarin.Forms.Font.SystemFontOfSize(0d);
            pri1.LabelStyle.Margin = new Thickness(0);
            sec1.MajorTickStyle.StrokeColor = Color.Transparent;

            pri2.MajorTickStyle.StrokeColor = Color.Transparent;
            pri2.LabelStyle.TextColor = Color.Transparent;
            pri2.MajorTickStyle.TickSize = 0;
            pri2.LabelStyle.Font = Xamarin.Forms.Font.SystemFontOfSize(0d);
            pri2.LabelStyle.Margin = new Thickness(0);
            sec2.MajorTickStyle.StrokeColor = Color.Transparent;
			imageButton.HeightRequest = 30;
			imageButton.WidthRequest = 30;
            pri3.MajorTickStyle.StrokeColor = Color.Transparent;
            pri3.LabelStyle.TextColor = Color.Black;
            if (Device.Idiom == TargetIdiom.Phone)
            {
                pri3.LabelStyle.LabelFormat = "h:m:s";
                historyChart1.StrokeWidth =1;
                historyChart2.StrokeWidth = 1;
                historyChart3.StrokeWidth = 1;
                historyChart4.StrokeWidth = 1;
                historyChart5.StrokeWidth = 1;
                historyChart6.StrokeWidth = 1;
                historyChart7.StrokeWidth = 1;
				labelLive.FontSize = 20;

                
            }
            else
            {
                pri3.LabelStyle.LabelFormat = "dd/MM  h:m:s";
                historyChart1.StrokeWidth = 3;
                historyChart2.StrokeWidth = 3;
                historyChart3.StrokeWidth = 3;
                historyChart4.StrokeWidth = 3;
                historyChart5.StrokeWidth = 3;
                historyChart6.StrokeWidth = 3;
                historyChart7.StrokeWidth = 3;
                
            }
			if (Device.OS == TargetPlatform.iOS || Device.OS== TargetPlatform.Android) {
                LiveHeaderGrid.ColumnDefinitions[1].Width = new GridLength(0.2, GridUnitType.Star);
            } 
			if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows) {
				alignLabel.WidthRequest = -30;
				//imageButton.HeightRequest = 30;
			} else if (Device.OS == TargetPlatform.Windows) {
				// alignLabel.WidthRequest = 30;
				//imageButton.HeightRequest = 40;
			} else if (Device.Idiom == TargetIdiom.Tablet) 
			{
				if (Device.OS == TargetPlatform.Android) {
					imageButton.WidthRequest = 40;
					imageButton.HeightRequest = 40;
				}
				else if (Device.OS == TargetPlatform.iOS) {
					imageButton.WidthRequest = 40;
					imageButton.HeightRequest = 40;
				}
				LiveHeaderGrid.ColumnDefinitions[1].Width = new GridLength(0.1, GridUnitType.Star);
				sec1.Title.Font=Xamarin.Forms.Font.SystemFontOfSize(20d);
				sec2.Title.Font=Xamarin.Forms.Font.SystemFontOfSize(20d);
				sec3.Title.Font=Xamarin.Forms.Font.SystemFontOfSize(20d);
				sec.Title.Font=Xamarin.Forms.Font.SystemFontOfSize(20d);
				mainGrid.RowDefinitions[0].Height = 70;
			}
                pri3.MajorTickStyle.TickSize = 0;
            pri3.LabelStyle.Font = Xamarin.Forms.Font.SystemFontOfSize(0d);
            pri3.LabelStyle.Margin = new Thickness(10);
            sec3.MajorTickStyle.StrokeColor = Color.Transparent;



            
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += TapGesture_Tapped;
			imageButton.GestureRecognizers.Add(tapGesture);

            imageButton.Source = ImageSource.FromResource("PatientMonitor.Images.Clock_128.png", assembly);

            this.BindingContextChanged -= LiveViewPage_BindingContextChanged;
            this.BindingContextChanged += LiveViewPage_BindingContextChanged;

            if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                Label label = new Label();
                label.WidthRequest = 20;
            }
            
        }

        private void TapGesture_Tapped(object sender, EventArgs e)
        {
            if (buttonClickValue == 0)
            {
                SampleLayout.IsVisible = true;
                LiveLayout.IsVisible = false;
                labelLive.Text = "History View";
                mainGrid.RowSpacing = 10;
                imageButton.Source = ImageSource.FromResource("PatientMonitor.Images.Audip_128.png",assembly);
                buttonClickValue++;
            }
            else
            {
                SampleLayout.IsVisible = false;
                LiveLayout.IsVisible = true;
                mainGrid.RowSpacing = 0;
                labelLive.Text = "Live View";
                imageButton.Source = ImageSource.FromResource("PatientMonitor.Images.Clock_128.png", assembly);
                buttonClickValue = 0;
            }
        }

        void LiveViewPage_BindingContextChanged(object sender, EventArgs e)
        {
            liveVM = this.BindingContext as LiveHistoryViewModel;
            liveVM.LiveObservations.CollectionChanged -= LiveObservations_CollectionChanged;
            liveVM.LiveObservations.CollectionChanged += LiveObservations_CollectionChanged;
        }

        void LiveObservations_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            LiveBPLabel1.Text = liveVM.LiveObservations[liveVM.LiveObservations.Count - 1].BP.ToString() + "/73";
            LiveRRValueLabel.Text = liveVM.LiveObservations[liveVM.LiveObservations.Count - 1].RR.ToString();
            LiveTempValueLabel.Text = liveVM.LiveObservations[liveVM.LiveObservations.Count - 1].Temp.ToString();
        }
        private void B_Clicked(object sender, EventArgs e)
        {
            if (buttonClickValue == 0)
            {
                SampleLayout.IsVisible = true;
                LiveLayout.IsVisible = false;
                labelLive.Text = "History View";
                buttonClickValue++;
            }
            else
            {
                SampleLayout.IsVisible = false;
                LiveLayout.IsVisible = true;
                labelLive.Text = "Live View";
                buttonClickValue = 0;
            }
        }

        

    }
}

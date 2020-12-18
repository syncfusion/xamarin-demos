#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using SampleBrowser;
using Syncfusion.SfPullToRefresh.iOS;
using UIKit;

namespace SampleBrowser
{
	public class PullToRefreshDemo: SampleView
	{
		
		internal	SFPullToRefresh pullToRefresh;
		UIView mainView;
		internal	BaseView baseView;
		CustomScroll scrollView;
		public override void LayoutSubviews()
		{
			pullToRefresh.Frame = new CGRect(0, 0, Frame.Width, Frame.Height);
			mainView.Frame = new CGRect(Frame.Location.X, 0, Frame.Width, Frame.Height);
			if (baseView == null)
			{
				load();
			}
			pullToRefresh.PullableContent = mainView;
		
			SetNeedsDisplay();
		}
		public PullToRefreshDemo()
		{
			mainView = new UIView();
			pullToRefresh = new SFPullToRefresh();
			mainView.BackgroundColor = UIColor.FromRGBA(0.012f,0.608f,0.898f,1);
			AddSubview(pullToRefresh);
			pullToRefresh.Delegate = new PullToRefreshDelegate(this);

		}

		void load()
		{

			scrollView = new CustomScroll(new CGRect(0, pullToRefresh.Frame.Height - 150, pullToRefresh.Frame.Width, 150));

			mainView.AddSubview(scrollView);
			scrollView.BackgroundColor = UIColor.FromRGBA(0, 0.478f, 0.667f, 1);
			scrollView.ShowsHorizontalScrollIndicator = false;
			scrollView.ShowsVerticalScrollIndicator = false;
			int x = 0;
			List<WeatherModel> array = addPopulationData();

			baseView = new BaseView(new CGRect(0, (Frame.Height / 4), Frame.Width, Frame.Height / 2));
			baseView.model = array[0];
			baseView.updateBaseView();


			for (int i = 0; i < array.Count; i++)
			{
				WeatherView button = new WeatherView(new CGRect(x, 20, 100, 100));
				button.model = array[i];
				button.baseView = baseView;
				button.drawView();
				if (i == 0)
				{
					baseView.selectedView = button;
					button.selectView();

				}
				scrollView.AddSubview(button);

				x += (int)button.Frame.Width;
			}

			scrollView.ContentSize = new CGSize(x, 0);

			mainView.AddSubview(baseView);

			UILabel label = new UILabel(new CGRect(0, 20, pullToRefresh.Frame.Width, 50));
			label.Text = @"MorrisVille";
			label.TextColor = UIColor.White;
			label.Font = UIFont.SystemFontOfSize(14);
			label.TextAlignment = UITextAlignment.Center;
			mainView.AddSubview(label);
		}



		List<WeatherModel> addPopulationData()
		{
			List<WeatherModel> array = new List<WeatherModel>();

			NSDate now = NSDate.Now;


			string[] imagesArray = new string[] { "Cloudy.png", "Humid.png", "Rainy.png", "Warm.png", "Windy.png", "Cloudy.png", "Humid.png" };
			for (int i = 0; i < 7; i++)
			{
				int daysToAdd = i;
				NSDateComponents components = new NSDateComponents();
				components.Day = daysToAdd;

				NSCalendar gregorian =  NSCalendar.CurrentCalendar;

				NSDate newDate2 = gregorian.DateByAddingComponents(components, now, NSCalendarOptions.None);
				NSDateFormatter dateFormatter = new NSDateFormatter();
				dateFormatter.DateFormat = "EEEE, MMMM dd";

				NSDateFormatter dateFormatter1 = new NSDateFormatter();
				dateFormatter1.DateFormat = "EEEE";
				array.Add(new WeatherModel((NSString)dateFormatter.StringFor(newDate2), (NSString)imagesArray[i], (NSString)new Random().Next(10, 40).ToString(), (NSString)dateFormatter1.StringFor(newDate2)));
			}

			return array;
		}






	}

	public class PullToRefreshDelegate : SFPullToRefreshDelegate
	{
		public PullToRefreshDelegate(PullToRefreshDemo markers)
		{
			sample = markers;
		}
		PullToRefreshDemo sample;

	
		public override void Refreshed(SFPullToRefresh pulltorefresh)
		{
			NSTimer.CreateScheduledTimer(TimeSpan.FromSeconds(2), new Action<NSTimer>(delegate {
				sample.baseView.model.Temp = (NSString)new Random().Next(10, 40).ToString();

				sample.baseView.updateBaseView();
				sample.baseView.selectedView.selectView();
				sample.baseView.selectedView.updateTemp();
				sample.pullToRefresh.Refresh();

			}));


		}


	}




}

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
using Syncfusion.SfPullToRefresh;
using UIKit;
using System.Threading.Tasks;

namespace SampleBrowser
{
	public class PullToRefreshDemo: SampleView
	{
		
		internal SfPullToRefresh pullToRefresh;
        PullableContentView mainView;
		internal BaseView baseView;
		CustomScroll scrollView;
        UILabel label;

        public override void LayoutSubviews()
		{
            this.Superview.SendSubviewToBack(this);
            pullToRefresh.Frame = new CGRect(0, 0, Frame.Width, Frame.Height);          
		}
		public PullToRefreshDemo()
		{
            load();
            mainView = new PullableContentView(baseView, scrollView, label);
			pullToRefresh = new SfPullToRefresh();
            pullToRefresh.RefreshContentThreshold = 0;
			mainView.BackgroundColor = UIColor.FromRGBA(0.012f,0.608f,0.898f,1);
			AddSubview(pullToRefresh);
            pullToRefresh.Refreshing += PullToRefresh_Refreshing;
            pullToRefresh.PullableContent = mainView;
            this.OptionView = new Options(pullToRefresh);
        }

        private void PullToRefresh_Refreshing(object sender, RefreshingEventArgs e)
        {
            NSTimer.CreateScheduledTimer(TimeSpan.FromSeconds(3), new Action<NSTimer>(delegate {
                baseView.model.Temp = (NSString)new Random().Next(10, 40).ToString();

                baseView.updateBaseView();
                baseView.selectedView.selectView();
                baseView.selectedView.updateTemp();
                e.Refreshed = true;
            }));
        }

        void load()
		{

			scrollView = new CustomScroll();

			scrollView.BackgroundColor = UIColor.FromRGBA(0, 0.478f, 0.667f, 1);
			scrollView.ShowsHorizontalScrollIndicator = false;
			scrollView.ShowsVerticalScrollIndicator = false;
			int x = 0;
			List<WeatherModel> array = addPopulationData();

			baseView = new BaseView();
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


			label = new UILabel();
			label.Text = @"MorrisVille";
			label.TextColor = UIColor.White;
			label.Font = UIFont.SystemFontOfSize(14);
			label.TextAlignment = UITextAlignment.Center;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (pullToRefresh != null)
                {
                    pullToRefresh.Refreshing -= PullToRefresh_Refreshing;
                    pullToRefresh.Dispose();
                    pullToRefresh = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}

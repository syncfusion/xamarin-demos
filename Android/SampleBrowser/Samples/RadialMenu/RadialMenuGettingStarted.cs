#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Sfrangeslider;
using Syncfusion.SfRadialMenu.Android;

namespace SampleBrowser
{
	public class RadialMenuGettingStarted : SamplePage
	{

		#region Properties
		float height, width, density;
        ScrollView scrollviewer; LinearLayout textFrame;
		Context con;
		#endregion
		string[] fontIcons = new string[] { "\uE800", "\uF0C5", "\uE804", "\uE805", "\uF0CD", "\uF12B", "\uF12C", "\uF0CC", "\uF0C5", "\uE800" };
		string[] strings1 = new string[] { "Wifi", "BlueTooth", "Alarm", "Brightness", "Battery", "Power" };

		string[] layer = new string[] { "\uE701", "\uE702", "\uEA8F", "\uE706", "\uEBAA", "\uE7E8" };
		string[] wifi = new string[] { "\uEC3B", "\uEC3A", "\uEC39", "\uEC38", "\uEC37" };
		string[] wifis = new string[] { "High", "Moderate", "Medium", "Low", "\uEC37" };
		string[] battery = new string[] { "\uEBB8", "\uEBBC", "\uEBC0" };
		string[] batterys = new string[] { "Low", "Medium", "High" };
		string[] brightness = new string[] { "\uEC8A", "\uEC8A", "\uE706" };
		string[] brightnesss = new string[] { "Low", "Medium", "High" };
		string[] profile = new string[] { "\uE7ED", "\uE877", "\uEA8F" };
		string[] profiles = new string[] { "Silent", "Vibrate", "Loud" };
		string[] power = new string[] { "\uE708", "\uE777", "\uE7E8" };
		string[] powers = new string[] { "Sleep", "Restart", "PowerOff" };

		TextView text; LinearLayout mainLayout; SfRadialMenu radialMenu;
		public override View GetSampleContent(Context context)
		{
			height = context.Resources.DisplayMetrics.HeightPixels;
			width = context.Resources.DisplayMetrics.WidthPixels;
			con = context;
			density = con.Resources.DisplayMetrics.Density;
			ImageView image = new ImageView(context);
			image.SetImageResource(Resource.Drawable.Font);
			FrameLayout frame = new FrameLayout(context);
			frame.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(400, 400);


			mainLayout = new LinearLayout(con);
			mainLayout.Orientation = Android.Widget.Orientation.Vertical;
			mainLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			FrameLayout radialFrame = new FrameLayout(con);
			radialFrame.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(height * 0.60));
			radialMenu = new SfRadialMenu(con);
			///radialMenu.MenuIcon = image;
			ImageView back = new ImageView(con);
			back.SetImageResource(Resource.Drawable.Previous);
			//radialMenu.BackIcon = back;
			radialMenu.RimColor = Color.LightGray;
			radialMenu.OuterRimColor = Color.Transparent;
			Typeface tf = Typeface.CreateFromAsset(con.Assets, "Segoe_MDL2_Assets.ttf");
			for (int i = 0; i < 6; i++)
			{
                SfRadialMenuItem item = new SfRadialMenuItem(con) { IconFont = tf, FontIconSize = 20, FontIconText = layer[i], FontIconColor = Color.Black, ItemWidth = 45, ItemHeight = 45 };
				item.ItemTapped += Item_ItemTapped;
				radialMenu.Items.Add(item);
			}

			for (int i = 0; i < 4; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem(con) { IconFont = tf, FontIconSize = 20, FontIconText = wifi[i], FontIconColor = Color.Black };
				item.ItemTapped += Item_ItemTapped;
				(radialMenu.Items[0] as SfRadialMenuItem).Items.Add(item);
			}
			for (int i = 0; i < 4; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem(con) { IconFont = tf, FontIconSize = 20, FontIconText = wifi[i], FontIconColor = Color.Black };
				item.ItemTapped += Item_ItemTapped;
				(radialMenu.Items[1] as SfRadialMenuItem).Items.Add(item);
			}
			for (int i = 0; i < 3; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem(con) { IconFont = tf, FontIconSize = 20, FontIconText = profile[i], FontIconColor = Color.Black };
				item.ItemTapped += Item_ItemTapped;
				(radialMenu.Items[2] as SfRadialMenuItem).Items.Add(item);
			}
			for (int i = 0; i < 3; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem(con) { IconFont = tf, FontIconSize = 20, FontIconText = brightness[i], FontIconColor = Color.Black };
				item.ItemTapped += Item_ItemTapped;
				(radialMenu.Items[3] as SfRadialMenuItem).Items.Add(item);
			}
			for (int i = 0; i < 3; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem(con) { IconFont = tf, FontIconSize = 20, FontIconText = battery[i], FontIconColor = Color.Black, ItemWidth = 45, ItemHeight = 45 };
				item.ItemTapped += Item_ItemTapped;
				(radialMenu.Items[4] as SfRadialMenuItem).Items.Add(item);
			}
			for (int i = 0; i < 3; i++)
			{
				SfRadialMenuItem item = new SfRadialMenuItem(con) { IconFont = tf, FontIconSize = 20, FontIconText = power[i], FontIconColor = Color.Black, ItemWidth = 45, ItemHeight = 45 };
				item.ItemTapped += Item_ItemTapped;
				(radialMenu.Items[5] as SfRadialMenuItem).Items.Add(item);
			}

			radialMenu.RimRadius = radialRadius;
            radialMenu.CenterButtonRadius = 30;
            radialMenu.Opening += RadialMenu_Opening;
            radialMenu.Opened += RadialMenu_Opened;
            radialMenu.Closing += RadialMenu_Closing;
            radialMenu.Closed += RadialMenu_Closed;
            radialMenu.Navigating += RadialMenu_Navigating;
            radialMenu.Navigated += RadialMenu_Navigated;
            radialMenu.CenterButtonBackTapped += RadialMenu_CenterButtonBackTapped;
			radialFrame.AddView(radialMenu);
			mainLayout.AddView(radialFrame);
			scrollviewer = new ScrollView(con);
			textFrame = new LinearLayout(con);

            TextView menuIcon = new TextView(con);
            menuIcon.LayoutParameters= new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            menuIcon.Text = "\uE713";
            menuIcon.Typeface = tf;
            menuIcon.TextSize = 30;
            menuIcon.SetTextColor(Color.White);
            menuIcon.Gravity = GravityFlags.Center;
            radialMenu.CenterButtonView = menuIcon;

            TextView backIcon = new TextView(con);
            backIcon.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            backIcon.Text = "\uE72B";
            backIcon.TextSize = 25;
            backIcon.Typeface = tf;
            backIcon.SetTextColor(Color.White);
            backIcon.Gravity = GravityFlags.Center;
            radialMenu.CenterButtonBackIcon = backIcon;

			TextView textview = new TextView(con);
			textview.Text = "Event Log";
			textview.Typeface = tf;
			textview.SetTextColor(Color.Black);
			textview.TextSize = 20;
			if(density>2)
				textview.SetPadding(20, 0, 0, 20);
			else
				textview.SetPadding(10, 0, 0, 10);
			mainLayout.AddView(textview);

			textFrame.Orientation = Android.Widget.Orientation.Vertical;
            textFrame.SetScrollContainer(true);
			scrollviewer.AddView(textFrame);
			scrollviewer.VerticalScrollBarEnabled = true;
			FrameLayout bottomFrame = new FrameLayout(con);
            bottomFrame.SetScrollContainer(true);
			bottomFrame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(height * 0.40));
			bottomFrame.SetBackgroundColor(Color.Silver);
			bottomFrame.AddView(scrollviewer);
			bottomFrame.SetPadding(10, 0, 10, 0);
			mainLayout.AddView(bottomFrame);
			mainLayout.SetBackgroundColor(Color.White);
			radialMenu.EnableRotation = rotate;
			radialMenu.IsDragEnabled = drag;
			return mainLayout;
		}
		
        void RadialMenu_Opening(object sender, OpeningEventArgs e)
        {
            if (textFrame.ChildCount == 10)
                textFrame.RemoveView(textFrame.GetChildAt(10));
			text = new TextView(con);
			text.SetTextColor(Color.Black);
			textFrame.AddView(text,0);
			text.Text = "RadialMenu is Opening";
            scrollviewer.ScrollTo(textFrame.Bottom, 0);


        }

        void RadialMenu_Opened(object sender, OpenedEventArgs e)
        {
            if (textFrame.ChildCount == 10)
                textFrame.RemoveView(textFrame.GetChildAt(10));
			text = new TextView(con);
			text.SetTextColor(Color.Black);
			textFrame.AddView(text,0);
			text.Text = "RadialMenu is Opened";
            scrollviewer.ScrollTo(textFrame.Bottom, 0);


        }

        void RadialMenu_Closing(object sender, ClosingEventArgs e)
        {
            if (textFrame.ChildCount == 10)
                textFrame.RemoveView(textFrame.GetChildAt(10));
			text = new TextView(con);
			text.SetTextColor(Color.Black);
			textFrame.AddView(text,0);
			text.Text = "RadialMenu is Closing";
            scrollviewer.ScrollTo(textFrame.Bottom, 0);


        }

        void RadialMenu_Closed(object sender, ClosedEventArgs e)
        {
            if (textFrame.ChildCount == 10)
                textFrame.RemoveView(textFrame.GetChildAt(10));
			text = new TextView(con);
			text.SetTextColor(Color.Black);
			textFrame.AddView(text,0);
			text.Text = "RadialMenu is Closed";
            scrollviewer.ScrollTo(textFrame.Bottom, 0);


        }

        void RadialMenu_Navigating(object sender, NavigatingEventArgs e)
        {
            if (textFrame.ChildCount == 10)
                textFrame.RemoveView(textFrame.GetChildAt(10));
			text = new TextView(con);
			text.SetTextColor(Color.Black);
			textFrame.AddView(text,0);
			text.Text = "RadialMenu is Navigating";
            scrollviewer.ScrollTo(textFrame.Bottom, 0);


        }

        void RadialMenu_Navigated(object sender, NavigatedEventArgs e)
        {
            if (textFrame.ChildCount == 10)
                textFrame.RemoveView(textFrame.GetChildAt(10));
			text = new TextView(con);
			text.SetTextColor(Color.Black);
			textFrame.AddView(text,0);
			text.Text = "RadialMenu is Navigated";
            scrollviewer.ScrollTo(textFrame.Bottom, 0);


        }

        void RadialMenu_CenterButtonBackTapped(object sender, CenterButtonBackTappedEventArgs e)
        {
            if (textFrame.ChildCount == 10)
                textFrame.RemoveView(textFrame.GetChildAt(10));
			text = new TextView(con);
			text.SetTextColor(Color.Black);
			textFrame.AddView(text,0);
			text.Text = "RadialMenu CenterButtonBack is Tapped";
            scrollviewer.ScrollTo(textFrame.Bottom, 0);


        }

        void Item_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
		{
            if (textFrame.ChildCount == 10)
                textFrame.RemoveView(textFrame.GetChildAt(10));
			text = new TextView(con);
			text.SetTextColor(Color.Black);
			textFrame.AddView(text,0);
			text.Text = "RadialMenu Item is Tapped";
            scrollviewer.ScrollTo(textFrame.Bottom,0);


		}

		TextView  enableRotation;
		LinearLayout propertylayout, stackView3, stackView4;
		public override View GetPropertyWindowLayout(Context context)
		{
			propertylayout = new LinearLayout(context);
			propertylayout.Orientation = Android.Widget.Orientation.Vertical;
			width = context.Resources.DisplayMetrics.WidthPixels / 2;
			TextView textView = new TextView(context);
			textView.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
			textView.Text = "Rim Radius";
            if (IsTabletDevice(context))
                textView.SetPadding(3, 0, 0, 0);
			textView.TextSize = 16;
			propertylayout.AddView(textView);
			SfRangeSlider seekBar = new SfRangeSlider(context);
			seekBar.Minimum = 100;
			seekBar.Maximum = 200;
			seekBar.Value = 100;
			seekBar.ShowRange = false;
			seekBar.ShowValueLabel = false;
			seekBar.TickPlacement = TickPlacement.None;
			seekBar.ToolTipPlacement = ToolTipPlacement.None;
			seekBar.ValueChanged += SeekBar_ValueChanged;
			seekBar.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, 200);
			propertylayout.AddView(seekBar);
			SnapsToLayout(context);
			ShowLabelLayout(context);
			return propertylayout;
		}

		int radialRadius = 100;
		void SeekBar_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			radialRadius = (int)e.Value;
		}

		bool rotate = true; bool drag = true;
		private void SnapsToLayout(Context context)
		{

			enableRotation = new TextView(context);
			enableRotation.Text = "  " + "Enable Rotation";
			enableRotation.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
			enableRotation.Gravity = GravityFlags.Center;
			enableRotation.TextSize = 16;


			Switch checkBox2 = new Switch(context);
			checkBox2.Checked = true;
			checkBox2.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) =>
			{
				rotate = e.IsChecked;
			};

			//layoutParams
			LinearLayout.LayoutParams layoutParams5 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			layoutParams5.SetMargins(0, 20, 0, 0);
			LinearLayout.LayoutParams layoutParams6 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.WrapContent, 55);
			layoutParams6.SetMargins(0, 20, 0, 0);

			//stackView
			stackView4 = new LinearLayout(context);
			stackView4.AddView(enableRotation);
			stackView4.AddView(checkBox2, layoutParams5);
			stackView4.Orientation = Android.Widget.Orientation.Horizontal;
			propertylayout.AddView(stackView4);
			SeparatorView separate4 = new SeparatorView(context, width * 2);
			separate4.LayoutParameters = new ViewGroup.LayoutParams((int)(width * 2), 5);
			LinearLayout.LayoutParams layoutParams8 = new LinearLayout.LayoutParams((int)(width * 2), 5);
            if (IsTabletDevice(context))
                layoutParams8.SetMargins(0, 30, 0, 200);
            else
                layoutParams8.SetMargins(0, 30, 0, 0);

			propertylayout.AddView(separate4, layoutParams8);
		}
        public static bool IsTabletDevice(Android.Content.Context context)
        {
            try
            {
                DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
                float screenWidth = displayMetrics.WidthPixels / displayMetrics.Xdpi;
                float screenHeight = displayMetrics.HeightPixels / displayMetrics.Ydpi;
                double size = Math.Sqrt(Math.Pow(screenWidth, 2) + Math.Pow(screenHeight, 2));
                return size >= 6;
            }
            catch
            {
                return false;
            }
        }
		private void ShowLabelLayout(Context context)
		{
			//showLabel
			TextView showLabel = new TextView(context);
			showLabel.Text = "  " + "Enable Dragging";
			showLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
			showLabel.Gravity = GravityFlags.Center;
			showLabel.TextSize = 16;

			//checkBox
			Switch checkBox = new Switch(context);
			checkBox.Checked = true;
			checkBox.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) =>
			{
				drag = e.IsChecked;
			};

			//layoutParams
			LinearLayout.LayoutParams layoutParams3 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			layoutParams3.SetMargins(0, 10, 0, 0);
			LinearLayout.LayoutParams layoutParams4 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.WrapContent, 55);
			layoutParams4.SetMargins(0, 10, 0, 0);

			//stackView
			stackView3 = new LinearLayout(context);
			stackView3.AddView(showLabel);
			stackView3.AddView(checkBox, layoutParams3);
			stackView3.Orientation = Android.Widget.Orientation.Horizontal;
			propertylayout.AddView(stackView3);
			SeparatorView separate3 = new SeparatorView(context, width * 2);
			separate3.LayoutParameters = new ViewGroup.LayoutParams((int)(width * 2), 5);
			LinearLayout.LayoutParams layoutParams7 = new LinearLayout.LayoutParams((int)(width * 2), 5);
			layoutParams7.SetMargins(0, 30, 0, 0);
			propertylayout.AddView(separate3, layoutParams7);
		}

		public override void OnApplyChanges()
		{
			radialMenu.RimRadius = radialRadius;
			radialMenu.EnableRotation = rotate;
			radialMenu.IsDragEnabled = drag;
		}

	}
}


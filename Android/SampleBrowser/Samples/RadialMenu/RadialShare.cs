#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using Syncfusion.SfRadialMenu.Android;

namespace SampleBrowser
{
	public class RadialShare : SamplePage
	{
		public RadialShare()
		{
		}
		float density;
		Context con;
		LinearLayout mainLayout;
		SfRadialMenu radialMenu;
        Button touchDraw;
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
		public override View GetSampleContent(Context context)
		{
			mainLayout = new LinearLayout(context);
			mainLayout.Orientation = Orientation.Vertical;
			mainLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			con = context;
			density = con.Resources.DisplayMetrics.Density;
			TextView about = new TextView(context);
			about.Text = "About Syncfusion";
            if (IsTabletDevice(context))
            {
                about.SetPadding(0, 10, 0, 40);

                about.Gravity = GravityFlags.Center;
            }
			about.SetTextColor(Color.Black);
			about.SetBackgroundColor(Color.Transparent);
			about.TextSize = 10 * density; //TypedValue.ApplyDimension(ComplexUnitType.Pt, 5, context.Resources.DisplayMetrics);
			mainLayout.AddView(about);
			TextView desc = new TextView(context);
			if (density > 2)
			{
				mainLayout.SetPadding(10, 10, 10, 10);
				about.TextSize = 20;
			}
			else {
				about.TextSize = 17;
				mainLayout.SetPadding(5, 5, 5, 5);
			}
            if (IsTabletDevice(context))
                desc.Text = "\tSyncfusion is the enterprise technology partner of choice for software development, delivering \n \n a broad range of web, mobile, and desktop controls coupled with a service-oriented approach \n \n throughout the entire application lifecycle. Syncfusion has established itself as the trusted\n\n partner worldwide for use in applications.";
            else
                desc.Text = "\tSyncfusion is the enterprise technology partner of choice for software development, delivering a broad range of web, mobile, and desktop controls coupled with a service-oriented approach throughout the entire application lifecycle. Syncfusion has established itself as the trusted partner worldwide for use in applications.";

			desc.SetTextColor(Color.Black);
			desc.SetBackgroundColor(Color.Transparent);
			//desc.TextSize =5 * density; //TypedValue.ApplyDimension(ComplexUnitType.Pt, 3.5f, context.Resources.DisplayMetrics);
			mainLayout.AddView(desc);

			FrameLayout backFrame = new FrameLayout(context);
			backFrame.SetBackgroundColor(Color.Gray);
			mainLayout.AddView(backFrame, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
			FrameLayout frontFrame = new FrameLayout(context);
			frontFrame.SetBackgroundColor(Color.White);
			frontFrame.SetPadding(5, 5, 5, 5);
			touchDraw = new Button(context);
			touchDraw.Text = "Tap here to follow us";
			touchDraw.SetTextColor(Color.Blue);
			touchDraw.SetBackgroundColor(Color.Transparent);
			//touchDraw.TextSize = 10 * density; //TypedValue.ApplyDimension(ComplexUnitType.Pt, 3, context.Resources.DisplayMetrics);
			frontFrame.AddView(touchDraw, new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.Center));
			Typeface typeface = Typeface.CreateFromAsset(context.Assets, "socialicons.ttf");
			radialMenu = new SfRadialMenu(context);
			radialMenu.RimColor = Color.Transparent;
            radialMenu.SelectionColor = Color.Transparent;


			FrameLayout facebookLayout = new FrameLayout(context);
			facebookLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView facebookImage = new ImageView(context);
			facebookImage.LayoutParameters = facebookLayout.LayoutParameters;
            facebookImage.SetImageResource(Resource.Drawable.facebook);
			facebookImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView facebookText = new TextView(context);
			facebookText.LayoutParameters = facebookLayout.LayoutParameters;
			facebookText.Text = "\uE700";
			facebookText.Typeface = typeface;
			facebookText.TextSize = 20;
			facebookText.TextAlignment = TextAlignment.Center;
			facebookText.Gravity = GravityFlags.Center;
			facebookText.SetTextColor(Color.White);
			facebookLayout.AddView(facebookImage);
			facebookLayout.AddView(facebookText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem facebookItem = new SfRadialMenuItem(context) { View = facebookLayout, ItemWidth = 50, ItemHeight = 50 };
            facebookItem.ItemTapped += FacebookItem_ItemTapped;
			facebookItem.SetBackgroundColor(Color.Transparent);
			radialMenu.Items.Add(facebookItem);


			FrameLayout gplusLayout = new FrameLayout(context);
			gplusLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView gplusImage = new ImageView(context);
			gplusImage.LayoutParameters = gplusLayout.LayoutParameters;
            gplusImage.SetImageResource(Resource.Drawable.gplus);
			gplusImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView gplusText = new TextView(context);
			gplusText.LayoutParameters = gplusLayout.LayoutParameters;
			gplusText.Text = "\uE707";
			gplusText.Typeface = typeface;
			gplusText.TextSize = 20;
			gplusText.TextAlignment = TextAlignment.Center;
			gplusText.Gravity = GravityFlags.Center;
			gplusText.SetTextColor(Color.White);
			gplusLayout.AddView(gplusImage);
			gplusLayout.AddView(gplusText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem gplusItem = new SfRadialMenuItem(context) { View = gplusLayout, ItemWidth = 50, ItemHeight = 50 };
            gplusItem.ItemTapped += GplusItem_ItemTapped;
			gplusItem.SetBackgroundColor(Color.Transparent);
			radialMenu.Items.Add(gplusItem);


			FrameLayout twitterLayout = new FrameLayout(context);
			twitterLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView twitterImage = new ImageView(context);
			twitterImage.LayoutParameters = twitterLayout.LayoutParameters;
            twitterImage.SetImageResource(Resource.Drawable.twitter);
			twitterImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView twitterText = new TextView(context);
			twitterText.LayoutParameters = twitterLayout.LayoutParameters;
			twitterText.Text = "\uE704";
			twitterText.Typeface = typeface;
			twitterText.TextSize = 20;
			twitterText.TextAlignment = TextAlignment.Center;
			twitterText.Gravity = GravityFlags.Center;
			twitterText.SetTextColor(Color.White);
			twitterLayout.AddView(twitterImage);
			twitterLayout.AddView(twitterText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem twitterItem = new SfRadialMenuItem(context) { View = twitterLayout, ItemWidth = 50, ItemHeight = 50 };
            twitterItem.ItemTapped +=TwitterItem_ItemTapped;
			twitterItem.SetBackgroundColor(Color.Transparent);
			radialMenu.Items.Add(twitterItem);


			FrameLayout pinterestLayout = new FrameLayout(context);
			pinterestLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView pinterestImage = new ImageView(context);
			pinterestImage.LayoutParameters = pinterestLayout.LayoutParameters;
            pinterestImage.SetImageResource(Resource.Drawable.pinterest);
			pinterestImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView pinterestText = new TextView(context);
			pinterestText.LayoutParameters = pinterestLayout.LayoutParameters;
			pinterestText.Text = "\uE705";
			pinterestText.Typeface = typeface;
			pinterestText.TextSize = 20;
			pinterestText.TextAlignment = TextAlignment.Center;
			pinterestText.Gravity = GravityFlags.Center;
			pinterestText.SetTextColor(Color.White);
			pinterestLayout.AddView(pinterestImage);
			pinterestLayout.AddView(pinterestText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem pinterestItem = new SfRadialMenuItem(context) { View = pinterestLayout, ItemWidth = 50, ItemHeight = 50 };
            pinterestItem.ItemTapped += PinterestItem_ItemTapped;
			pinterestItem.SetBackgroundColor(Color.Transparent);
			radialMenu.Items.Add(pinterestItem);

			FrameLayout linkedInLayout = new FrameLayout(context);
			linkedInLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView linkedInImage = new ImageView(context);
			linkedInImage.LayoutParameters = linkedInLayout.LayoutParameters;
            linkedInImage.SetImageResource(Resource.Drawable.linkedin);
			linkedInImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView linkedInText = new TextView(context);
			linkedInText.LayoutParameters = linkedInLayout.LayoutParameters;
			linkedInText.Text = "\uE706";
			linkedInText.Typeface = typeface;
			linkedInText.TextSize = 20;
			linkedInText.TextAlignment = TextAlignment.Center;
			linkedInText.Gravity = GravityFlags.Center;
			linkedInText.SetTextColor(Color.White);
			linkedInLayout.AddView(linkedInImage);
			linkedInLayout.AddView(linkedInText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem linkedInItem = new SfRadialMenuItem(context) { View = linkedInLayout, ItemWidth = 50, ItemHeight = 50 };
            linkedInItem.ItemTapped +=LinkedInItem_ItemTapped;
			linkedInItem.SetBackgroundColor(Color.Transparent);
			radialMenu.Items.Add(linkedInItem);

		
			FrameLayout instagramLayout = new FrameLayout(context);
			instagramLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			ImageView instagramImage = new ImageView(context);
			instagramImage.LayoutParameters = instagramLayout.LayoutParameters;
            instagramImage.SetImageResource(Resource.Drawable.instagram);
			instagramImage.SetScaleType(ImageView.ScaleType.FitXy);
			TextView instagramText = new TextView(context);
			instagramText.LayoutParameters = instagramLayout.LayoutParameters;
			instagramText.Text = "\uE708";
			instagramText.Typeface = typeface;
			instagramText.TextSize = 20;
			instagramText.TextAlignment = TextAlignment.Center;
			instagramText.Gravity = GravityFlags.Center;
			instagramText.SetTextColor(Color.White);
			instagramLayout.AddView(instagramImage);
			instagramLayout.AddView(instagramText, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
			SfRadialMenuItem instagramItem = new SfRadialMenuItem(context) { View = instagramLayout, ItemWidth = 50, ItemHeight = 50 };
            instagramItem.ItemTapped += InstagramItem_ItemTapped;
			instagramItem.SetBackgroundColor(Color.Transparent);
			radialMenu.Items.Add(instagramItem);


			backFrame.AddView(frontFrame, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));

            TextView menuIcon = new TextView(context);
            menuIcon.Text = "\uE703";
            menuIcon.TextSize = 20;
            menuIcon.Typeface = typeface;
            menuIcon.SetTextColor(Color.White);
            menuIcon.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            menuIcon.Gravity = GravityFlags.Center;
			radialMenu.Visibility = ViewStates.Invisible;
            radialMenu.CenterButtonView = menuIcon;
			radialMenu.IsDragEnabled = false;
			radialMenu.EnableRotation = false;
			radialMenu.OuterRimColor = Color.Transparent;
			radialMenu.CenterButtonBackground = Color.Rgb(41, 146, 247);
			radialMenu.CenterButtonRadius = 25;
			radialMenu.RimRadius = 100;
			radialMenu.Closed += RadialMenu_Closed;
			frontFrame.AddView(radialMenu);

			touchDraw.Click += (sender, e) =>
			{
				radialMenu.Visibility = ViewStates.Visible;
                touchDraw.Visibility = ViewStates.Invisible;
				radialMenu.Show();
			};

			return mainLayout;
		}

        void FacebookItem_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
        {
			radialMenu.Close();
			Toast.MakeText(con, "Shared with Facebook", ToastLength.Short).Show();
        }

        void GplusItem_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
        {
			radialMenu.Close();
			Toast.MakeText(con, "Shared with G+", ToastLength.Short).Show();
        }

        void PinterestItem_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
        {
			radialMenu.Close();
			Toast.MakeText(con, "Shared with Pinterest", ToastLength.Short).Show();
        }

        void LinkedInItem_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
        {
			radialMenu.Close();
			Toast.MakeText(con, "Shared with Linked in", ToastLength.Short).Show();
        }

        void TwitterItem_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
        {
			radialMenu.Close();
			Toast.MakeText(con, "Shared with Twitter", ToastLength.Short).Show();
        }

        void InstagramItem_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
        {
			radialMenu.Close();
			Toast.MakeText(con, "Shared with Instagram", ToastLength.Short).Show();
        }

		void RadialMenu_Closed(object sender, ClosedEventArgs e)
		{
			radialMenu.Visibility = ViewStates.Invisible;
            touchDraw.Visibility = ViewStates.Visible;
		}
	}
}

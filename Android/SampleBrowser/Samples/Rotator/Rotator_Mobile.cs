#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Com.Syncfusion.Rotator;
using System.Collections;
using Android.Graphics;


namespace SampleBrowser
{
    public class Rotator_Mobile
    {

        /*********************************
         **Local Varabile Inizialization**
         *********************************/
        ArrayAdapter<String> tabAdapter, directionAdapter, modeAdapter;
        double  navigationBarHeight, statusBarHeight;
        Spinner directionSpinner, tabStripSpinner, modeSpinner;
        LinearLayout propertylayout, stackView3;
        LinearLayout.LayoutParams layoutParams2, layoutParams3;
        int height,width;
        TextView adjlabel3;
        SfRotator rotator;
        Context context;

        public Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            Context con = context;
            List<SfRotatorItem> images = new List<SfRotatorItem>();
            List<int> imageID = new List<int>();
            SamplPageContent(con);
           
            /***********
             **Rotator**
             ***********/
            rotator = new SfRotator(con);
            rotator.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, height / 2);//ActionBar.LayoutParameters(ViewGroup.LayoutParams.MATCH_PARENT,height/2);
            rotator.NavigationStripMode = NavigationStripMode.Dots;
            rotator.NavigationDirection = NavigationDirection.Horizontal;
            rotator.NavigationStripPosition = NavigationStripPosition.Bottom;
            rotator.SelectedIndex = 2;
            rotator.EnableAutoPlay = false;
            rotator.SetBackgroundColor(Color.ParseColor("#ececec"));
                              
            //Images Id List           
            imageID.Add(Resource.Drawable.movie1);
            imageID.Add(Resource.Drawable.movie2);
            imageID.Add(Resource.Drawable.movie3);
            imageID.Add(Resource.Drawable.movie4);
            imageID.Add(Resource.Drawable.movie5);
            SfRotatorItem item;
            ImageView image;
            for (int i = 0; i < imageID.Count; i++)
            {
                item = new SfRotatorItem(con);
                image = new ImageView(con);
                image.SetImageResource(imageID[i]);
                image.SetScaleType(ImageView.ScaleType.FitXy);
                item.Content = image;
                images.Add(item);
            }
            rotator.DataSource = images;

            //Main View
            LinearLayout mainView = new LinearLayout(con);
            mainView.AddView(GetView(con));

            return mainView;         
        }

        private LinearLayout GetView(Context con)
        {

            LinearLayout completeLayout = new LinearLayout(con);
            completeLayout.Orientation = Orientation.Vertical;
            completeLayout.LayoutParameters = (new ActionBar.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
            completeLayout.AddView(rotator);          
            completeLayout.AddView(adjlabel3);
           
            //ScrollView
            ScrollView scrollView = new ScrollView(con);
            scrollView.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)((height / 2) - (navigationBarHeight + statusBarHeight + 20))));
            scrollView.AddView(GetPropertyLayout(con));
            completeLayout.AddView(scrollView);

            return completeLayout;
        }

       
        private void SamplPageContent(Context con)
        {
            height = (int)(con.Resources.DisplayMetrics.HeightPixels);

          
            
            statusBarHeight = getStatusBarHeight(con);
            navigationBarHeight = getNavigationBarHeight(con);

            //AdjLabel
            adjlabel3 = new TextView(con);
            adjlabel3.LayoutParameters = (new ActionBar.LayoutParams(ViewGroup.LayoutParams.MatchParent, 10));    
        }

       
        public View GetPropertyLayout(Android.Content.Context context1)
        {
            context = context1;
            width = context.Resources.DisplayMetrics.WidthPixels / 2;
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(width * 2, 2);
            layoutParams.SetMargins(0, 5, 0, 0);

            DirectionLayout();
            TapPositionLayout();
            NavigationStripLayout();
            EnableAutoPlayLayout();

            return propertylayout;
        }

        private void DirectionLayout()
        {
            /******************
            **DirectionLabel**
            ******************/
            TextView directionLabel = new TextView(context);
            directionLabel.Text = "  " + "Navigation Direction";
            directionLabel.TextSize = 15;
            directionLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Bold);
            directionLabel.SetTextColor(Color.Black);
            directionLabel.Gravity = GravityFlags.Left;

            //AdjLabel
            TextView adjLabel2 = new TextView(context);
            adjLabel2.SetHeight(14);
            propertylayout.AddView(adjLabel2);

            //DirectionSpinner
            directionSpinner = new Spinner(context,SpinnerMode.Dialog);
            directionSpinner.SetPadding(0, 0, 0, 0);
            propertylayout.AddView(directionLabel);
            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 2);

            //AdjLabel
            TextView adjLabel3 = new TextView(context);
            adjLabel3.SetHeight(20);
            propertylayout.AddView(adjLabel3);
            propertylayout.AddView(directionSpinner);
            TextView adjLabel4 = new TextView(context);
            propertylayout.AddView(adjLabel4);

            //Direction List
            List<String> directionList = new List<String>();
            directionList.Add("Horizontal");
            directionList.Add("Vertical");

            //Direction adapter
            directionAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, directionList);
            directionAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //Direction Spinner Item Selected Listener
            directionSpinner.Adapter = directionAdapter;
            directionSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = directionAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Horizontal"))
                {
                    rotator.NavigationDirection = NavigationDirection.Horizontal;
                }
                else if (selectedItem.Equals("Vertical"))
                {
                    rotator.NavigationDirection = NavigationDirection.Vertical;
                }
            };
        }

       
        private void TapPositionLayout()
        {
            /****************
            **Tap Position**
            ****************/
            TextView tabPoitionLabel = new TextView(context);
            tabPoitionLabel.Text = "  " + "Navigation Strip Position";
            tabPoitionLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Bold);
            tabPoitionLabel.Gravity = GravityFlags.Left;
            tabPoitionLabel.TextSize = 15;
            tabPoitionLabel.SetTextColor(Color.Black);

            //Tab List
            List<String> tabList = new List<String>();
            tabList.Add("Bottom");
            tabList.Add("Top");
            tabList.Add("Right");
            tabList.Add("Left");
            tabStripSpinner = new Spinner(context,SpinnerMode.Dialog);

            //Tap Adapter
            tabAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, tabList);
            tabAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //Tab Spinner
            tabStripSpinner.Adapter = tabAdapter;
            tabStripSpinner.SetPadding(0, 0, 0, 0);

            //Tab Spinner ItemSelected Listener
            tabStripSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = tabAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Bottom"))
                {
                    rotator.NavigationStripPosition = NavigationStripPosition.Bottom;
                }
                else if (selectedItem.Equals("Top"))
                {
                    rotator.NavigationStripPosition = NavigationStripPosition.Top;
                }
                if (selectedItem.Equals("Right"))
                {
                    rotator.NavigationStripPosition = NavigationStripPosition.Right;
                }
                else if (selectedItem.Equals("Left"))
                {
                    rotator.NavigationStripPosition = NavigationStripPosition.Left;
                }
            };

            //Layout Params
            layoutParams2 = new LinearLayout.LayoutParams(width * 2, 2);
            layoutParams2.SetMargins(0, 5, 0, 0);
            propertylayout.AddView(tabPoitionLabel);
            SeparatorView separate2 = new SeparatorView(context, width * 2);
            separate2.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 2);

            //sanpSToLabel
            TextView snapsToLabel = new TextView(context);
            snapsToLabel.SetHeight(20);
            propertylayout.AddView(snapsToLabel);
            propertylayout.AddView(tabStripSpinner);
            propertylayout.SetPadding(15, 0, 15, 0);

            //AdjLabel
            TextView adjLabel12 = new TextView(context);
            adjLabel12.SetHeight(20);
            propertylayout.AddView(adjLabel12);

        }

        private void NavigationStripLayout()
        {
            /*******************
            **Navigation Mode**
            *******************/
            TextView modeLabel = new TextView(context);
            modeLabel.Text = "  " + "Navigation Strip Mode";
            modeLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Bold);
            modeLabel.Gravity = GravityFlags.Left;
            modeLabel.TextSize = 15;
            modeLabel.SetTextColor(Color.Black);

            //Mode List
            List<String> modeList = new List<String>();
            modeList.Add("Dots");
            modeList.Add("Thumbnail");

            //Mode Adapter
            modeAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, modeList);
            modeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //Mode Spinner
            modeSpinner = new Spinner(context,SpinnerMode.Dialog);
            modeSpinner.Adapter = modeAdapter;
            modeSpinner.SetPadding(0, 0, 0, 0);

            //Mode Spinner Item Selected Listener
            modeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = modeAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Dots"))
                {
                    rotator.NavigationStripMode = NavigationStripMode.Dots;
                }
                else if (selectedItem.Equals("Thumbnail"))
                {
                    rotator.NavigationStripMode = NavigationStripMode.Thumbnail;
                }
            };

            //LayoutParams 
            layoutParams3 = new LinearLayout.LayoutParams(width * 2, 7);
            layoutParams2.SetMargins(0, 5, 0, 0);
            propertylayout.AddView(modeLabel);

            //Separator
            SeparatorView separate4 = new SeparatorView(context, width * 2);
            separate4.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 2);
            LinearLayout.LayoutParams layoutParams8 = new LinearLayout.LayoutParams(width * 2, 2);
            layoutParams8.SetMargins(0, 5, 0, 0);

            //Adjust Label
            TextView adjustLabel = new TextView(context);
            adjustLabel.SetHeight(20);
            propertylayout.AddView(adjustLabel);
            propertylayout.AddView(modeSpinner);
            propertylayout.SetPadding(15, 0, 15, 0);
            TextView adjLabel13 = new TextView(context);
            adjLabel13.SetHeight(20);
            propertylayout.AddView(adjLabel13);
        }

        private void EnableAutoPlayLayout()
        {
            /********************
            **Enable Auto Play**
            ********************/
            TextView autoPlayLabel = new TextView(context);
            autoPlayLabel.Text = "  " + "Enable AutoPlay";
            autoPlayLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Bold);
            autoPlayLabel.Gravity = GravityFlags.Center;
            autoPlayLabel.TextSize = 16;

            //Auto Play Switch
            Switch playSwitch = new Switch(context);
            playSwitch.Checked = false;
            playSwitch.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) =>
            {
                rotator.EnableAutoPlay = e.IsChecked;
            };

            //LayoutParams
            LinearLayout.LayoutParams layoutParams5 = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            layoutParams3.SetMargins(0, 5, 0, 0);
            LinearLayout.LayoutParams layoutParams4 = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, 55);
            layoutParams4.SetMargins(0, 5, 0, 0);

            //StackView
            stackView3 = new LinearLayout(context);
            stackView3.AddView(autoPlayLabel);
            stackView3.AddView(playSwitch, layoutParams5);
            stackView3.Orientation = Orientation.Horizontal;
            propertylayout.AddView(stackView3);

			TextView textSpacing = new TextView(context);
			propertylayout.AddView(textSpacing);

            //Separater
            SeparatorView separate3 = new SeparatorView(context, width * 2);
            separate3.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 2);
            LinearLayout.LayoutParams layoutParams7 = new LinearLayout.LayoutParams(
                width * 2, 2);
            layoutParams7.SetMargins(0, 10, 0, 0);
        }

        private int getStatusBarHeight(Context con)
        {
            int barHeight = 0;
            int resourceId = con.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                barHeight = con.Resources.GetDimensionPixelSize(resourceId);
            }
            return barHeight;
        }

        private int getNavigationBarHeight(Context con)
        {
            int navBarHeight = 0;
            int resourceId = con.Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                navBarHeight = con.Resources.GetDimensionPixelSize(resourceId);
            }
            return navBarHeight;
        }
    }
}


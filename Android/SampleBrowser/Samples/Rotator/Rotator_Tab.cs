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
    public class Rotator_Tab : SamplePage
    {
        public Rotator_Tab()
        {
        }

       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        SfRotator rotator;
        Context con;
        Spinner directionSpinner, tabStripSpinner, modeSpinner;
        ArrayAdapter<String> tabAdapter, directionAdapter, modeAdapter;
        Context context;
        LinearLayout proprtyOptionsLayout;

        public override View GetSampleContent(Android.Content.Context context1)
        {
            con = context1;
            context = context1;
            //Rotator
            rotator = new SfRotator(con);
            rotator.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);//ActionBar.LayoutParameters(ViewGroup.LayoutParams.MATCH_PARENT,height/2);
            rotator.NavigationStripMode = NavigationStripMode.Dots;
            rotator.NavigationDirection = NavigationDirection.Horizontal;
            rotator.NavigationStripPosition = NavigationStripPosition.Bottom;
            rotator.SelectedIndex = 2;
            rotator.EnableAutoPlay = false;
            rotator.SetBackgroundColor(Color.ParseColor("#ececec"));
            
            //Images List
            List<SfRotatorItem> images = new List<SfRotatorItem>();
            
            //Images Id List
            List<int> imageID = new List<int>();
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
                item.Content = image;
                images.Add(item);
            }
            rotator.DataSource = images;
            return rotator;
        }
        public override View GetPropertyWindowLayout(Context context)
        {
            proprtyOptionsLayout = new LinearLayout(context);
            proprtyOptionsLayout.Orientation = Orientation.Vertical;
            NavigationDirectionLayout();
            StripPositionLayout();
            StripModeLayout();
            EnableAutoPlayLayout();
            return proprtyOptionsLayout;
        }
        private void NavigationDirectionLayout()
        {
            //Direction Label
            TextView directionLabel = new TextView(context);
            directionLabel.Text = "Navigation Direction";
            directionLabel.TextSize = 20;
            directionLabel.SetPadding(0,0,0,50);
            directionLabel.SetTextColor(Color.Black);
            directionLabel.Gravity = GravityFlags.Left;

            //directionSpinner
            directionSpinner = new Spinner(context,SpinnerMode.Dialog);
            directionSpinner.SetPadding(0, 0, 0, 0);

            //Direction List
            List<String> directionList = new List<String>();
            directionList.Add("Horizontal");
            directionList.Add("Vertical");
            
            //Direction adapter
            directionAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, directionList);
            directionAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
           
            //Direction Spinner Item Selected Listener
            directionSpinner.Adapter = directionAdapter;
            directionSpinner.SetSelection(0);
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

            //directionLayout
            LinearLayout directionLayout = new LinearLayout(context);
            directionLayout.Orientation = Android.Widget.Orientation.Vertical;
            directionLayout.SetPadding(0,0,0,60);
            directionLayout.AddView(directionLabel);
            directionLayout.AddView(directionSpinner);
            proprtyOptionsLayout.AddView(directionLayout);

           
        }

        private void StripPositionLayout()
        {
            //Tap Position	
            TextView tabPoitionLabel = new TextView(context);
            tabPoitionLabel.SetPadding(0,0,0,50);
            tabPoitionLabel.Text = "Navigation Strip Position";
            tabPoitionLabel.Gravity = GravityFlags.Left;
            tabPoitionLabel.TextSize = 20;
            tabPoitionLabel.SetTextColor(Color.Black);

            //tabList
            List<String> tabList = new List<String>();
            tabList.Add("Bottom");
            tabList.Add("Top");
            tabList.Add("Right");
            tabList.Add("Left");
            tabStripSpinner = new Spinner(context,SpinnerMode.Dialog);

            // Tap Adapter
            tabAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, tabList);
            tabAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //tabStripSpinner
            tabStripSpinner.Adapter = tabAdapter;
            tabStripSpinner.SetSelection(0);
            tabStripSpinner.SetPadding(0, 0, 0, 0);
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

            //tabPoitionLayout
            LinearLayout tabPoitionLayout = new LinearLayout(context);
            tabPoitionLayout.Orientation = Android.Widget.Orientation.Vertical;
            tabPoitionLayout.SetPadding(0,0,0,60);
            tabPoitionLayout.AddView(tabPoitionLabel);
            tabPoitionLayout.AddView(tabStripSpinner);
            proprtyOptionsLayout.AddView(tabPoitionLayout);

         
        }

        private void StripModeLayout()
        {
            //modeLabel
            TextView modeLabel = new TextView(context);
            modeLabel.SetPadding(0,0,0,50);
            modeLabel.Text = "Navigation Strip Mode";
            modeLabel.Gravity = GravityFlags.Left;
            modeLabel.TextSize = 20;
            modeLabel.SetTextColor(Color.Black);
            
            //Mode List
            List<String> modeList = new List<String>();
            modeList.Add("Dots");
            modeList.Add("Thumbnail");
            
            //Mode Spinner Item Selected Listener
            modeSpinner = new Spinner(context,SpinnerMode.Dialog);
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

            //modeAdapter
            modeAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, modeList);
            modeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            modeSpinner.Adapter = modeAdapter;
            modeSpinner.SetSelection(0);

            //modeLayout
            LinearLayout modeLayout = new LinearLayout(context);
            modeLayout.Orientation = Android.Widget.Orientation.Vertical;
            modeLayout.SetPadding(0,0,0,60);
            modeLayout.AddView(modeLabel);
            modeLayout.AddView(modeSpinner);
            proprtyOptionsLayout.AddView(modeLayout);

           
        }

        private void EnableAutoPlayLayout()
        {
            //autoPlayLabel
            TextView autoPlayLabel = new TextView(context);
            autoPlayLabel.SetPadding(0, 0, 0, 50);
            autoPlayLabel.Text = "Enable AutoPlay";
            autoPlayLabel.TextSize = 20;

            //Auto Play Switch
            LinearLayout ex = new LinearLayout(context);

            Switch playSwitch = new Switch(context);
            playSwitch.Checked = false;
            playSwitch.Gravity = GravityFlags.End;
            playSwitch.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) =>
            {
                rotator.EnableAutoPlay = e.IsChecked;
            };
            ex.AddView(playSwitch);
            ex.SetPadding(450,0,0,0);
            LinearLayout autoPlayLayout = new LinearLayout(context);
            autoPlayLayout.SetPadding(0,0,0,60);
            autoPlayLayout.Orientation = Android.Widget.Orientation.Horizontal;

            autoPlayLayout.AddView(autoPlayLabel);
            autoPlayLayout.AddView(ex);
            proprtyOptionsLayout.AddView(autoPlayLayout);


        }
       
    }
}


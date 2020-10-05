#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Carousel;

using Java.Util;
using Android.Graphics;


namespace SampleBrowser
{
    public class Carousel_Mobile
    {
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        LinearLayout.LayoutParams lineParams, labelParams, entryParams, adjustParams, lineParams2;
        LinearLayout propertylayout, offSetStack, scaleStack, rotateStack;
        EditText offSet, scaleOffset, RotateAngle;
        SfCarousel carousel;
        int offSetValue = 60, RotationAngleValue = 45, width;
        double scaleOffsetValue = 0.8;
        Spinner tickSpinner;
        ArrayAdapter<String> dataAdapter;
        ViewMode viewMode;
        Context context;

        public View GetSampleContent(Context context1)
        {
            context = context1;
            carousel = new SfCarousel(context);
            List<SfCarouselItem> tempCollection = new List<SfCarouselItem>();
            for (int i = 1; i <= 7; i++)
            {
                SfCarouselItem carouselItem = new SfCarouselItem(context);
                carouselItem.ImageName = "images" + i;
                tempCollection.Add(carouselItem);
            }
            carousel.DataSource = tempCollection;
            carousel.SelectedIndex = 3;
            carousel.ScaleOffset = 0.8f;
            if (context.Resources.DisplayMetrics.Density > 1.5)
            {
                carousel.ItemHeight = Convert.ToInt32(250 * context.Resources.DisplayMetrics.Density);
                carousel.ItemWidth = Convert.ToInt32(180 * context.Resources.DisplayMetrics.Density);
            }

            carousel.LayoutParameters = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
            return carousel;
        }

        public View GetPropertyWindowLayout(Context context)
        {
            int dp = (int)context.Resources.DisplayMetrics.Density;
            width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;

            offsetLayout();
            ScaleOffsetLayout();
            RotationAngleLayout();
            VisualModeLayout();

            return propertylayout;
        }

       
        private void offsetLayout()
        {
            lineParams = new LinearLayout.LayoutParams(width * 2, 5);
            lineParams.SetMargins(0, 10, 0, 0);

            //labelParams
            labelParams = new LinearLayout.LayoutParams(width, ViewGroup.LayoutParams.MatchParent);
            labelParams.SetMargins(0, 5, 0, 0);
            entryParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            adjustParams = new LinearLayout.LayoutParams(width / 3, ViewGroup.LayoutParams.WrapContent);
            entryParams.SetMargins(0, 5, 20, 0);
            propertylayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            propertylayout.SetBackgroundColor(Color.White);

            //offsetLabel
            TextView offsetLabel = new TextView(context);
            offsetLabel.Text = "Offset";
            offsetLabel.TextSize = 20;
            offsetLabel.Gravity = GravityFlags.CenterVertical;
            offSetStack = new LinearLayout(context);
            TextView centerLabel1 = new TextView(context);

            //offSet
            offSet = new EditText(context);
            offSet.Text = "60";
            offSet.InputType = Android.Text.InputTypes.ClassNumber;
            offSet.TextSize = 20;
            offSet.SetTextColor(Color.Black);
            offSetStack.AddView(offsetLabel, labelParams);
            offSetStack.AddView(centerLabel1, adjustParams);
            offSetStack.SetGravity(GravityFlags.Center);
            offSetStack.AddView(offSet, entryParams);
            offSetStack.Orientation = Orientation.Horizontal;
            propertylayout.AddView(offSetStack);
            
            //offSet TextChanged Listener
            offSet.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                if (offSet.Text.Length > 0)
                {
                    int i = Convert.ToInt32(e.Text.ToString());
                    if (i >= 40 && i <= 100)
                        offSetValue = i;
                    else
                        offSetValue = 60;
                }
            };

            //lineParams
            lineParams2 = new LinearLayout.LayoutParams(width * 2, 5);
            lineParams2.SetMargins(0, 20, 0, 0);      
           
          
        }

        private void ScaleOffsetLayout()
        {
            //scaleLabel
            TextView scaleLabel = new TextView(context);
            scaleLabel.Text = "Scale Offset";
            scaleLabel.TextSize = 20;
            scaleLabel.Gravity = GravityFlags.CenterVertical;
            scaleStack = new LinearLayout(context);
            TextView centerLabel2 = new TextView(context);

			TextView textSpacing = new TextView(context);
			propertylayout.AddView(textSpacing);

            //scaleOffset
            scaleOffset = new EditText(context);
            scaleOffset.InputType = Android.Text.InputTypes.NumberFlagDecimal | Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.ClassNumber;
            scaleOffset.TextSize = 20;
            scaleOffset.Text = "0.8";
            scaleOffset.SetTextColor(Color.Black);
            scaleStack.AddView(scaleLabel, labelParams);
            scaleStack.AddView(centerLabel2, adjustParams);
            scaleStack.AddView(scaleOffset, entryParams);
            scaleStack.SetGravity(GravityFlags.Center);
            scaleStack.Orientation = Orientation.Horizontal;
            propertylayout.AddView(scaleStack);
           
            //scaleOffset TextChanged Listener
            scaleOffset.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                if (scaleOffset.Text.Length > 0)
                {
                    float i = (float)Convert.ToDouble(e.Text.ToString());
                    if (i >= 0.5 && i <= 1)
                        scaleOffsetValue = i;
                    else
                        scaleOffsetValue = 0.8;
                }
            };

           
   
        }

        private void RotationAngleLayout()
        {
            //rotateLabel
            TextView rotateLabel = new TextView(context);
            rotateLabel.Text = "Rotation Angle";
            rotateLabel.TextSize = 20;
            rotateLabel.Gravity = GravityFlags.CenterVertical;
            rotateStack = new LinearLayout(context);
            TextView centerLabel3 = new TextView(context);

			TextView textSpacing = new TextView(context);
			propertylayout.AddView(textSpacing);

            //RotateAngle
            RotateAngle = new EditText(context);
            RotateAngle.InputType = Android.Text.InputTypes.ClassNumber;
            RotateAngle.TextSize = 20;
            RotateAngle.Text = "45";
            RotateAngle.SetTextColor(Color.Black);
            rotateStack.AddView(rotateLabel, labelParams);
            rotateStack.AddView(centerLabel3, adjustParams);
            rotateStack.AddView(RotateAngle, entryParams);
            rotateStack.SetGravity(GravityFlags.Center);
            rotateStack.Orientation = Orientation.Horizontal;
            propertylayout.AddView(rotateStack);
            
            //RotateAngle TextChanged Listener
            RotateAngle.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                if (RotateAngle.Text.Length > 0)
                {
                    int i = Convert.ToInt32(e.Text.ToString());
                    if (i >= 0 && i <= 360)
                        RotationAngleValue = i;
                    else
                        RotationAngleValue = 45;
                }
            };

         
            propertylayout.SetPadding(5, 0, 5, 0);
        }

        private void VisualModeLayout()
        {
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            layoutParams.SetMargins(0, 5, 0, 0);
            TextView adjLabe5 = new TextView(context);
            propertylayout.AddView(adjLabe5);

            //Visual Mode
            TextView placementLabel = new TextView(context);
            placementLabel.Text = "View Mode";
            placementLabel.TextSize = 20;
            placementLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
            placementLabel.SetTextColor(Color.Black);
            placementLabel.Gravity = GravityFlags.Left;
            TextView adjLabel2 = new TextView(context);
            adjLabel2.SetHeight(14);
        

            //tickSpinner
            tickSpinner = new Spinner(context,SpinnerMode.Dialog);
            tickSpinner.SetPadding(0, 0, 0, 0);
            propertylayout.AddView(placementLabel);
            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
          

            //adjLabel
            TextView adjLabel3 = new TextView(context);
            adjLabel3.SetHeight(20);
           
            propertylayout.AddView(tickSpinner);
            TextView adjLabel4 = new TextView(context);
            propertylayout.AddView(adjLabel4);

            //positionList
            List<String> positionList = new List<String>();
            positionList.Add("Default");
            positionList.Add("Linear");

            //dataAdapter
            dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, positionList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //tickSpinner
            tickSpinner.Adapter = dataAdapter;
            tickSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Default"))
                {
                    
                    viewMode = ViewMode.Default;
                }
                else if (selectedItem.Equals("Linear"))
                {
                   
                    viewMode = ViewMode.Linear;
                }
            };
        }
        public void OnApplyChanges()
        {
            carousel.Offset = offSetValue;
            carousel.RotationAngle = RotationAngleValue;
            carousel.ScaleOffset = (float)scaleOffsetValue;
            carousel.ViewMode = viewMode;
        }
    }
}


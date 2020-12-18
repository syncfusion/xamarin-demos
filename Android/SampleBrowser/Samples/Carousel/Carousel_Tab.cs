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
using Android.Views.InputMethods;

namespace SampleBrowser
{
    public class Carousel_Tab :SamplePage
    {
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        EditText offSet, scaleOffset, RotateAngle;
        LinearLayout proprtyOptionsLayout;
        Spinner tickSpinner;
        ArrayAdapter<String> dataAdapter;       
        SfCarousel carousel;
        Context context1;
        int width;

        public override View GetSampleContent(Context context)
        {
            context1 = context;
            //carousel
            carousel = new SfCarousel(context1);
            List<SfCarouselItem> tempCollection = new List<SfCarouselItem>();
            for (int i = 1; i <= 7; i++)
            {
                SfCarouselItem carouselItem = new SfCarouselItem(context1);
                carouselItem.ImageName = "images" + i;
                tempCollection.Add(carouselItem);
            }
            carousel.DataSource = tempCollection;
            carousel.SelectedIndex = 3;
            carousel.ScaleOffset = 0.8f;
            if (context1.Resources.DisplayMetrics.Density > 1.5)
            {
                carousel.ItemHeight = Convert.ToInt32(240 * context1.Resources.DisplayMetrics.Density);
                carousel.ItemWidth = Convert.ToInt32(170 * context1.Resources.DisplayMetrics.Density);
            }
            carousel.LayoutParameters = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);

            return carousel;
        }
        public override View GetPropertyWindowLayout(Context context)
        {
            context1 = context;
            width = (context1.Resources.DisplayMetrics.WidthPixels) / 2;
            proprtyOptionsLayout = new LinearLayout(context1);
            proprtyOptionsLayout.Orientation = Orientation.Vertical;

            OffsetLayout();

            ScaleOffsetLayout();
            RotationAngleLayout();
            VisualModeLayout();

            return proprtyOptionsLayout;

        }


        private void OffsetLayout()
        {
            //OffsetLabel
            TextView offsetLabel = new TextView(context1);
            offsetLabel.SetPadding(0, 0, 0, 10);
            offsetLabel.Text = "Offset";
            offsetLabel.TextSize = 20;
            offsetLabel.Gravity = GravityFlags.CenterVertical;

            //offSetText
            offSet = new EditText(context1);
            offSet.Text = "60";
            offSet.InputType = Android.Text.InputTypes.ClassNumber;
            offSet.TextSize = 20;
            offSet.SetTextColor(Color.Black);

            //Offset Text Changed Listener
            offSet.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                if (offSet.Text.Length > 0)
                {
                    int i = Convert.ToInt32(e.Text.ToString());
                    if (i >= 40 && i <= 100)
                        carousel.Offset = i;
                    else
                        carousel.Offset = 60;
                }

            };

            //offSetLayout
            LinearLayout offSetLayout = new LinearLayout(context1);
            offSetLayout.SetPadding(20, 20, 0, 40);
            offSetLayout.Orientation = Android.Widget.Orientation.Vertical;
            offSetLayout.AddView(offsetLabel);
            offSetLayout.AddView(offSet);
            proprtyOptionsLayout.AddView(offSetLayout);
        }

        private void ScaleOffsetLayout()
        {
            //ScaleLabel
            TextView scaleLabel = new TextView(context1);
            scaleLabel.SetPadding(0, 0, 0, 10);

            scaleLabel.Text = "Scale Offset";
            scaleLabel.TextSize = 20;
            scaleLabel.Gravity = GravityFlags.CenterVertical;

            //scaleOffsetText
            scaleOffset = new EditText(context1);
            scaleOffset.InputType = Android.Text.InputTypes.NumberFlagDecimal | Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.ClassNumber;
            scaleOffset.TextSize = 20;
            scaleOffset.Text = "0.8";
            scaleOffset.SetTextColor(Color.Black);

            //Scale Offset Text Changed Listener
            scaleOffset.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                if (scaleOffset.Text.Length > 0)
                {
                    float i = (float)Convert.ToDouble(e.Text.ToString());
                    if (i >= 0.5 && i <= 1)
                    {
                        carousel.ScaleOffset = i;

                    }
                    else
                        carousel.ScaleOffset = 0.8f;
                }
            };

            //scaleLayout
            LinearLayout scaleLayout = new LinearLayout(context1);
            scaleLayout.SetPadding(20, 20, 0, 40);

            scaleLayout.Orientation = Android.Widget.Orientation.Vertical;
            scaleLayout.AddView(scaleLabel);
            scaleLayout.AddView(scaleOffset);
            proprtyOptionsLayout.AddView(scaleLayout);

        }

        private void RotationAngleLayout()
        {
            //Rotator Lable
            TextView rotateLabel = new TextView(context1);
            rotateLabel.SetPadding(0, 0, 0, 10);

            rotateLabel.Text = "Rotation Angle";
            rotateLabel.TextSize = 20;
            rotateLabel.Gravity = GravityFlags.CenterVertical;

            //Rotation Angle
            RotateAngle = new EditText(context1);
            RotateAngle.InputType = Android.Text.InputTypes.ClassNumber;
            RotateAngle.TextSize = 20;
            RotateAngle.Text = "45";
            RotateAngle.SetTextColor(Color.Black);

            //Rotation Angle Text Changed Listener
            RotateAngle.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                if (RotateAngle.Text.Length > 0)
                {
                    int i = Convert.ToInt32(e.Text.ToString());
                    if (i >= 0 && i <= 360)
                        carousel.RotationAngle = i;
                    else
                        carousel.RotationAngle = 45;
                }

            };

            //rotateLayout
            LinearLayout rotateLayout = new LinearLayout(context1);
            rotateLayout.SetPadding(20, 20, 0, 40);

            rotateLayout.Orientation = Android.Widget.Orientation.Vertical;
            rotateLayout.AddView(rotateLabel);
            rotateLayout.AddView(RotateAngle);
            proprtyOptionsLayout.AddView(rotateLayout);
        }

        private void VisualModeLayout()
        {
            //placementLabel
            TextView placementLabel = new TextView(context1);
            placementLabel.SetPadding(0,0,0,10);
            placementLabel.Text = "View Mode";
            placementLabel.TextSize = 20;

            //tickSpinner
            tickSpinner = new Spinner(context1,SpinnerMode.Dialog);
            tickSpinner.SetPadding(0, 0, 0, 0);

            //positionList
            List<String> positionList = new List<String>();
            positionList.Add("Default");
            positionList.Add("Linear");
            dataAdapter = new ArrayAdapter<String>(context1, Android.Resource.Layout.SimpleSpinnerItem, positionList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            tickSpinner.Adapter = dataAdapter;

            //tickSpinner ItemSelected Listener
            tickSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Default"))
                {
                    if (context1.Resources.DisplayMetrics.Density > 1.5)
                    {
                        carousel.ItemHeight = Convert.ToInt32(250 * context1.Resources.DisplayMetrics.Density);
                        carousel.ItemWidth = Convert.ToInt32(180 * context1.Resources.DisplayMetrics.Density);
                    }
                    carousel.ViewMode = ViewMode.Default;
                }
                else if (selectedItem.Equals("Linear"))
                {
                    if (context1.Resources.DisplayMetrics.Density > 1.5)
                    {
                        carousel.ItemHeight = Convert.ToInt32(250 * context1.Resources.DisplayMetrics.Density);
                        carousel.ItemWidth = Convert.ToInt32(250 * context1.Resources.DisplayMetrics.Density);
                    }
                    carousel.ViewMode = ViewMode.Linear;
                }

            };

            LinearLayout linearLayout = new LinearLayout(context1);
            linearLayout.SetPadding(20,40,0,40);
            linearLayout.Orientation = Android.Widget.Orientation.Vertical;
            linearLayout.AddView(placementLabel);
            linearLayout.AddView(tickSpinner);
            proprtyOptionsLayout.AddView(linearLayout);

         
        }
      
        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
        }
      
   
    }
}


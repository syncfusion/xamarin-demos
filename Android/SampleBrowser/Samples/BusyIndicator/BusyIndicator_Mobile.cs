#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;

using Android.Content;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Sfbusyindicator;
using Android.Graphics;
using Com.Syncfusion.Sfbusyindicator.Enums;

namespace SampleBrowser
{
    public class BusyIndicator_Mobile
    {

       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        TextView animationTypeText, spaceAdderText1, spaceAdderText2;
        SfBusyIndicator sfBusyIndicator;
        Spinner animationSpinner;
       
        public View GetSampleContent(Context con)
        {
            SamplePageContent(con);

            /******************
             **BusyIndicator**
             ******************/
            sfBusyIndicator = new SfBusyIndicator(con);
            sfBusyIndicator.IsBusy = true;
            sfBusyIndicator.TextColor = Color.Rgb(62, 101, 254);
            sfBusyIndicator.AnimationType = AnimationTypes.DoubleCircle;
            sfBusyIndicator.ViewBoxWidth = 133;
            sfBusyIndicator.ViewBoxHeight = 133;
            sfBusyIndicator.TextSize = 60;
            sfBusyIndicator.Title = "";
            sfBusyIndicator.SetBackgroundColor(Color.Rgb(255, 255, 255));

            //main view
            LinearLayout mainView = GetView(con);  
            return mainView;
        }

        private LinearLayout GetView(Context con)
        {
            //linearLayout
            LinearLayout linearLayout = new LinearLayout(con);
            linearLayout.SetPadding(20, 20, 20, 30);
            linearLayout.SetBackgroundColor(Color.Rgb(236, 235, 242));
            linearLayout.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent,
                LinearLayout.LayoutParams.WrapContent);
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.AddView(animationTypeText);
            linearLayout.AddView(spaceAdderText2);
            linearLayout.AddView(animationSpinner);
            linearLayout.AddView(spaceAdderText1);
            linearLayout.AddView(sfBusyIndicator);

            return linearLayout;
        } 
        private void SamplePageContent(Context con)
        {
            //Animation Spinner
            animationSpinner = new Spinner(con,SpinnerMode.Dialog);
            animationSpinner.SetMinimumHeight(60);
            animationSpinner.DropDownWidth = 500;
            animationSpinner.SetBackgroundColor(Color.Gray);
           
            //Animation List
            List<String> animationList = new List<String>();
            animationList.Add("Ball");
            animationList.Add("Battery");
            animationList.Add("DoubleCircle");
            animationList.Add("ECG");
            animationList.Add("Globe");
            animationList.Add("HorizontalPulsingBox");
            animationList.Add("MovieTimer");
            animationList.Add("Print");
            animationList.Add("Rectangle");
            animationList.Add("RollingBall");
            animationList.Add("SingleCircle");
            animationList.Add("SlicedCircle");
            animationList.Add("ZoomingTarget");
			animationList.Add("Gear");
			            
            
            //Data Adapter
            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
                (con, Android.Resource.Layout.SimpleSpinnerItem, animationList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            animationSpinner.Adapter = dataAdapter;
            animationSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(animationSpinner_ItemSelected);
          
            //Animation Text
            animationTypeText = new TextView(con);
            animationTypeText.TextSize = 20;
            animationTypeText.Text = "Animation Types";

            //Space Adder Text1
            spaceAdderText1 = new TextView(con);
            spaceAdderText1.TextSize = 10;
            animationTypeText.SetTextColor(Color.Black);
           
            //Space Adder Text2
            spaceAdderText2 = new TextView(con);
            spaceAdderText2.TextSize = 10;
            spaceAdderText2.SetTextColor(Color.Black);
        }
        
        /*****************************************
         **Animation Spinner ItemSelected Method**
         *****************************************/
        private void animationSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner animationSpinner = (Spinner)sender;
            String selectedItem = animationSpinner.GetItemAtPosition(e.Position).ToString();
            if (selectedItem.Equals("Ball"))
            {
				sfBusyIndicator.ViewBoxWidth = 130;
				sfBusyIndicator.ViewBoxHeight = 130;
                sfBusyIndicator.Duration = 1000;
                sfBusyIndicator.TextColor = Color.ParseColor("#243FD9");
                sfBusyIndicator.AnimationType = AnimationTypes.Ball;
            }
            else if (selectedItem.Equals("Battery"))
            {
				sfBusyIndicator.ViewBoxWidth = 80;
				sfBusyIndicator.ViewBoxHeight = 80;
                sfBusyIndicator.Duration = 300;
                sfBusyIndicator.TextColor = Color.ParseColor("#A70015");
                sfBusyIndicator.AnimationType = AnimationTypes.Battery;
            }
            else if (selectedItem.Equals("DoubleCircle"))
            {
				sfBusyIndicator.ViewBoxWidth = 80;
				sfBusyIndicator.ViewBoxHeight = 80;
                sfBusyIndicator.Duration = 1800;
                sfBusyIndicator.TextColor = Color.ParseColor("#958C7B");
                sfBusyIndicator.AnimationType = AnimationTypes.DoubleCircle;
            }
            else if (selectedItem.Equals("ECG"))
            {
				sfBusyIndicator.ViewBoxWidth = 80;
				sfBusyIndicator.ViewBoxHeight = 80;
                sfBusyIndicator.Duration = 1500;
                sfBusyIndicator.TextColor = Color.ParseColor("#DA901A");
                sfBusyIndicator.AnimationType = AnimationTypes.Ecg;
            }
            else if (selectedItem.Equals("Globe"))
            {
				sfBusyIndicator.ViewBoxWidth = 80;
				sfBusyIndicator.ViewBoxHeight = 80;
                sfBusyIndicator.Duration = 800;
                sfBusyIndicator.TextColor = Color.ParseColor("#9EA8EE");
                sfBusyIndicator.AnimationType = AnimationTypes.Globe;
            }
            else if (selectedItem.Equals("HorizontalPulsingBox"))
            {
				sfBusyIndicator.ViewBoxWidth = 100;
				sfBusyIndicator.ViewBoxHeight = 100;
                sfBusyIndicator.Duration = 500;
                sfBusyIndicator.TextColor = Color.ParseColor("#E42E06");
                sfBusyIndicator.AnimationType = AnimationTypes.HorizontalPulsingBox;
            }
            else if (selectedItem.Equals("MovieTimer"))
            {
				sfBusyIndicator.ViewBoxWidth = 80;
				sfBusyIndicator.ViewBoxHeight = 80;
                sfBusyIndicator.Duration = 800;
                sfBusyIndicator.TextColor = Color.ParseColor("#2d2d2d");
                sfBusyIndicator.SecondaryColor = Color.ParseColor("#9b9b9b");
                sfBusyIndicator.AnimationType = AnimationTypes.MovieTimer;
            }
            else if (selectedItem.Equals("Print"))
            {
				sfBusyIndicator.ViewBoxWidth = 80;
				sfBusyIndicator.ViewBoxHeight = 80;
                sfBusyIndicator.Duration = 1000;
                sfBusyIndicator.TextColor = Color.ParseColor("#5E6FF8");
                sfBusyIndicator.AnimationType = AnimationTypes.Print;
            }
            else if (selectedItem.Equals("Rectangle"))
            {
				sfBusyIndicator.ViewBoxWidth = 100;
				sfBusyIndicator.ViewBoxHeight = 100;
                sfBusyIndicator.Duration = 500;
                sfBusyIndicator.TextColor = Color.ParseColor("#27AA9E");
                sfBusyIndicator.AnimationType = AnimationTypes.Rectangle;
            }
            else if (selectedItem.Equals("RollingBall"))
            {
				sfBusyIndicator.ViewBoxWidth = 80;
				sfBusyIndicator.ViewBoxHeight = 80;
                sfBusyIndicator.Duration = 1000;
                sfBusyIndicator.TextColor = Color.ParseColor("#2d2d2d");
                sfBusyIndicator.SecondaryColor = Color.White;
                sfBusyIndicator.AnimationType = AnimationTypes.RollingBall;
            }
            else if (selectedItem.Equals("SingleCircle"))
            {
				sfBusyIndicator.ViewBoxWidth = 70;
				sfBusyIndicator.ViewBoxHeight = 70;
                sfBusyIndicator.Duration = 2000;
                sfBusyIndicator.TextColor = Color.ParseColor("#AF2541");
                sfBusyIndicator.AnimationType = AnimationTypes.SingleCircle;
            }
            else if (selectedItem.Equals("SlicedCircle"))
            {
				sfBusyIndicator.ViewBoxWidth = 60;
				sfBusyIndicator.ViewBoxHeight = 60;
                sfBusyIndicator.Duration = 3000;
                sfBusyIndicator.TextColor = Color.ParseColor("#779772");
                sfBusyIndicator.AnimationType = AnimationTypes.SlicedCircle;
            }
            else if (selectedItem.Equals("ZoomingTarget"))
            {
				sfBusyIndicator.ViewBoxWidth = 80;
				sfBusyIndicator.ViewBoxHeight = 80;
                sfBusyIndicator.Duration = 600;
                sfBusyIndicator.TextColor = Color.ParseColor("#ED8F3C");
                sfBusyIndicator.AnimationType = AnimationTypes.ZoomingTarget;
            }
			else if (selectedItem.Equals("Gear"))
			{
				sfBusyIndicator.ViewBoxWidth = 80;
				sfBusyIndicator.ViewBoxHeight = 80;
				sfBusyIndicator.Duration = 1500;
				sfBusyIndicator.TextColor = Color.Gray;
				sfBusyIndicator.AnimationType = AnimationTypes.GearBox;
			}
			        
        }
    }
}


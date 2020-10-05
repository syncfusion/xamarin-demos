#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using droid = Android.Widget.Orientation;

using Com.Syncfusion.Sfrangeslider;
using Android.Graphics;
using Android.Content;
namespace SampleBrowser
{
	//[con(Label = "Orientation")]
	public class Equalizer : SamplePage
	{
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        SfRangeSlider slider1,slider2,slider3;
        TextView adjLabel, hertzLabel, hertzLabel1, hertzLabel2, decibelLabel;
        TextView decibelLabel1, decibelLabel2, adjLabel7, adjLabel8, adjLabel9, adjLabel10;
        int height, width;
        LinearLayout mainLayout, layout1, layout2, layout3;
        FrameLayout.LayoutParams sliderLayout;

        public override View GetSampleContent (Context con)
		{		
			height =  con.Resources.DisplayMetrics.HeightPixels/2;
			width = con.Resources.DisplayMetrics.WidthPixels/3;

            SamplePageContent(con);
            sliderLayout = new FrameLayout.LayoutParams(width, height + (height / 4));
           /****************
            **RangeSlider1**
            ****************/
            slider1 =  new SfRangeSlider(con);
			slider1.Minimum=-12;
			slider1.Maximum=12;
			slider1.TickFrequency=12;
			slider1.TrackSelectionColor=Color.Gray;
			slider1.Orientation=Com.Syncfusion.Sfrangeslider.Orientation.Vertical;
			slider1.TickPlacement=TickPlacement.None;
			slider1.ValuePlacement=ValuePlacement.TopLeft;
			slider1.ShowValueLabel=true;
			slider1.SnapsTo=SnapsTo.None;
			slider1.Value=6;

			slider1.ValueChanged += (object sender, ValueChangedEventArgs e) => {
				String decibelString=(string)(Math.Round(e.Value)+".0db");
				decibelLabel.Text=decibelString;
			};

           /****************
            **RangeSlider2**
            ****************/
            slider2 =  new SfRangeSlider(con);
			slider2.Minimum=-12;
			slider2.Maximum=12;
			slider2.TickFrequency=12;
			slider2.TrackSelectionColor=Color.Gray;
			slider2.Orientation=Com.Syncfusion.Sfrangeslider.Orientation.Vertical;
			slider2.TickPlacement=TickPlacement.None;
			slider2.ValuePlacement=ValuePlacement.TopLeft;
			slider2.ShowValueLabel=true;
			slider2.SnapsTo=SnapsTo.None;
			slider2.Value=-3;
			slider2.LayoutParameters=sliderLayout;
			slider2.ValueChanged+= (object sender, ValueChangedEventArgs e) => {
				decibelLabel1.Text=Convert.ToString(Math.Round(e.Value)+".0db");
			};

           /****************
            **RangeSlider3**
            ****************/
            slider3 =  new SfRangeSlider(con);
			slider3.Minimum=-12;
			slider3.Maximum=12;
			slider3.TickFrequency=12;
			slider3.TrackSelectionColor=Color.Gray;
			slider3.Orientation=Com.Syncfusion.Sfrangeslider.Orientation.Vertical;
			slider3.TickPlacement=TickPlacement.None;
			slider3.ValuePlacement=ValuePlacement.TopLeft;
			slider3.ShowValueLabel=true;
			slider3.SnapsTo=SnapsTo.None;
			slider3.Value=12;
			slider3.LayoutParameters=sliderLayout;
			slider3.ValueChanged+= (object sender, ValueChangedEventArgs e) => {
				decibelLabel2.Text=Convert.ToString(Math.Round(e.Value)+".0db");
			};

            LinearLayout mainView = GetView(con);
            return mainView;		
		}

        private LinearLayout GetView(Context con)
        {
            //mainLayout
            mainLayout = new LinearLayout(con);
            mainLayout.SetBackgroundColor(Color.White);
            mainLayout.SetGravity(GravityFlags.Center);

            //parentLayout
            LinearLayout parentLayout = new LinearLayout(con);
            parentLayout.Orientation = droid.Vertical;
            parentLayout.SetBackgroundColor(Color.White);
            parentLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            parentLayout.AddView(adjLabel10);
            parentLayout.AddView(mainLayout);
            parentLayout.SetGravity(GravityFlags.Center);

            //layout1
            layout1 = new LinearLayout(con);
            layout1.Orientation = droid.Vertical;
            layout1.SetGravity(GravityFlags.Center);
            layout1.AddView(hertzLabel);
            layout1.AddView(decibelLabel);
            layout1.AddView(adjLabel);
            layout1.AddView(slider1, sliderLayout);

            //layout2
            layout2 = new LinearLayout(con);
            layout2.Orientation = droid.Vertical;
            layout2.SetGravity(GravityFlags.Center);
            layout2.AddView(hertzLabel1);
            layout2.AddView(decibelLabel1);
            layout2.AddView(adjLabel7);
            layout2.AddView(slider2, sliderLayout);

            //layout3
            layout3 = new LinearLayout(con);
            layout3.Orientation = droid.Vertical;
            layout3.SetGravity(GravityFlags.Center);
            layout3.AddView(hertzLabel2);
            layout3.AddView(decibelLabel2);
            layout3.AddView(adjLabel8);
            layout3.AddView(slider3, sliderLayout);

            mainLayout.AddView(layout1);
            mainLayout.AddView(layout2);
            mainLayout.AddView(layout3);

            return parentLayout;
        }
        private void SamplePageContent(Context con)
        {
           /*************
            **Adj Label**
            *************/
            adjLabel = new TextView(con);
            adjLabel7 = new TextView(con);
            adjLabel8 = new TextView(con);
            adjLabel9 = new TextView(con);
            adjLabel9.Text = "";
            adjLabel.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
            adjLabel9.TextSize = 20;
            adjLabel9.Gravity = GravityFlags.Center;
            adjLabel9.SetTextColor(Color.Argb(255, 182, 182, 182));
            adjLabel10 = new TextView(con);

            //hertzLabel
            hertzLabel = new TextView(con);
            hertzLabel.Text = "60HZ";
            hertzLabel.TextSize = 20;
            hertzLabel.SetTextColor(Color.Black);
            hertzLabel.Gravity = GravityFlags.Center;
            hertzLabel.Typeface = Typeface.Create("Helvetica", TypefaceStyle.Normal);

            //decibelLabel
            decibelLabel = new TextView(con);
            decibelLabel.TextSize = 14;
            decibelLabel.SetTextColor(Color.Argb(255, 50, 180, 228));
            decibelLabel.Text = "6.0db";
            decibelLabel.Typeface = Typeface.Create("Helvetica", TypefaceStyle.Normal);
            decibelLabel.Gravity = GravityFlags.Center;

            //hertzLabel1
            hertzLabel1 = new TextView(con);
            hertzLabel1.Text = "170HZ";
            hertzLabel1.TextSize = 20;
            hertzLabel1.SetTextColor(Color.Black);
            hertzLabel1.Gravity = GravityFlags.Center;
            hertzLabel1.Typeface = Typeface.Create("Helvetica", TypefaceStyle.Normal);

            //decibelLabel1
            decibelLabel1 = new TextView(con);
            decibelLabel1.TextSize = 14;
            decibelLabel1.SetTextColor(Color.Argb(255, 50, 180, 228));
            decibelLabel1.Text = "-3.0db";
            decibelLabel1.Typeface = Typeface.Create("Helvetica", TypefaceStyle.Normal);
            decibelLabel1.Gravity = GravityFlags.Center;

            //hertzLabel2
            hertzLabel2 = new TextView(con);
            hertzLabel2.Text = "310HZ";
            hertzLabel2.TextSize = 20;
            hertzLabel2.SetTextColor(Color.Black);
            hertzLabel2.Gravity = GravityFlags.Center;
            hertzLabel2.Typeface = Typeface.Create("Helvetica", TypefaceStyle.Normal);

            //decibelLabel2
            decibelLabel2 = new TextView(con);
            decibelLabel2.TextSize = 14;
            decibelLabel2.SetTextColor(Color.Argb(255, 50, 180, 228));
            decibelLabel2.Text = "12.0db";
            decibelLabel2.Typeface = Typeface.Create("Helvetica", TypefaceStyle.Normal);
            decibelLabel2.Gravity = GravityFlags.Center;
        }
	}
}


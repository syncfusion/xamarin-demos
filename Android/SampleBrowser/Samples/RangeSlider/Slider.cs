#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Com.Syncfusion.Sfrangeslider;
using System;
using System.Threading.Tasks;
using Android.Widget;
using Android.Views;


namespace SampleBrowser
{
	//[con(Label = "Slider")]
	public class Slider : SamplePage
	{

        /*********************************
        **Local Variable Inizialisation**
        *********************************/
        TextView opacityLabel;
        SfRangeSlider range;
		ImageView mountImg;
        int height;   
        public override View GetSampleContent (Context con)
		{
            SamplePageContent(con);
           /***************
            **RangeSlider**
            ***************/
            range = new SfRangeSlider(con);
			range.Minimum = 0;range.Maximum = 100; range.Value = 100;
			range.ShowRange = false; range.SnapsTo = SnapsTo.None;
			range.Orientation = Com.Syncfusion.Sfrangeslider.Orientation.Horizontal;
			range.TickPlacement = TickPlacement.BottomRight;
			range.ShowValueLabel = true; range.TickFrequency = 20;
			range.ValuePlacement = ValuePlacement.BottomRight;
			range.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, GettingStarted_Mobile.getDimensionPixelSize(con,Resource.Dimension.range_ht)));
			range.ValueChanged += ValueChanged ;				
			range.SetY(-30);
				
            //Frame Layout
			FrameLayout frame = new FrameLayout(con);
			frame.SetBackgroundColor (Color.White);
			frame.LayoutParameters = ( new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent,GravityFlags.Center));
			frame.AddView(GetView(con));

			return frame;
		}
		
        private LinearLayout GetView(Context con)
        {
           /***************
            **LinearLayout**
            ***************/
            LinearLayout linearLayout = new LinearLayout(con);
            linearLayout.SetGravity(Android.Views.GravityFlags.CenterHorizontal);
            linearLayout.Orientation = Android.Widget.Orientation.Vertical;
            linearLayout.SetBackgroundColor(Color.White);
            linearLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            linearLayout.SetPadding(20, 20, 20, 20);
            linearLayout.AddView(mountImg);
            linearLayout.AddView(opacityLabel);
            linearLayout.AddView(range);

            return linearLayout;
        }
        private void SamplePageContent(Context con)
        {
            height = con.Resources.DisplayMetrics.HeightPixels / 2;

            //MountImg
            mountImg = new ImageView(con);
            mountImg.SetImageResource(Resource.Drawable.mount1);
            FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(height + (height / 10)), GravityFlags.Center);
            mountImg.SetPadding(12, 0, 10, 0);
            mountImg.LayoutParameters = (layoutParams);

            //Opacity Label
            opacityLabel = new TextView(con);
            opacityLabel.Text = "  Opacity";
            opacityLabel.TextSize = 20;
            opacityLabel.Gravity = GravityFlags.Left;
        }
		public void ValueChanged(object sender, ValueChangedEventArgs e) {
			float alpha = (float)(e.Value / 100);
			mountImg.Alpha = alpha;
		}
	}
}
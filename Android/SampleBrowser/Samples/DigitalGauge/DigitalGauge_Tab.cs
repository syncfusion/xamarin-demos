#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any indigitalGaugeLayoutingement will be prosecuted under
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
using Com.Syncfusion.Gauges.SfDigitalGauge;
using System.Reflection.Emit;
using Java.Text;
using Java.Lang;
using Android.Graphics;
using Java.Util;

namespace SampleBrowser
{
	public class DigitalGauge_Tab : SamplePage
	{
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        SfDigitalGauge segmentSevenGauge;
		SfDigitalGauge segmentFourteenGauge;
		SfDigitalGauge segmentSixteenGauge;
		SfDigitalGauge segmentMatrixGauge;
		TextView segmentSevenText, segmentFourteenText, segmentSixteenText, segmentMatrixText, segmentSeven, segmentFourteen, segmentSixteen, segmentMatrix;
        Context con;
        int totalHeight;
        LinearLayout segmentSixteenLayout, segmentMatrixLayout, segmentFourteenLayout;
        LinearLayout sevenTextLayout, fourteenTextLayout, sixteenTextLayout, matrixTextLayout;
        LinearLayout segmentSevenLayout;
        string currentDateandTime;
        LinearLayout mainDigitalGaugeLayout;
        TextView spaceText1;
        ScrollView mainGaugeScrollView;
        public override View GetSampleContent (Context con1)
		{
            con = con1;
            totalHeight = con.Resources.DisplayMetrics.HeightPixels;

            SevenSegmentLayout();
            FourteenSegmentLayout();
            SixteenSegmentLayout();
            SegmentMatrixLayout();
            SegmentTextLayout();
            GaugeViewLayout();

			return mainGaugeScrollView;
		}
       
        private void SevenSegmentLayout()
        {
            
            SimpleDateFormat simpleDateFormat = new SimpleDateFormat("HH mm ss");
            currentDateandTime = simpleDateFormat.Format(new Java.Util.Date());
            segmentSevenGauge = new SfDigitalGauge(con);
            segmentFourteenGauge = new SfDigitalGauge(con);
            segmentSixteenGauge = new SfDigitalGauge(con);
            segmentMatrixGauge = new SfDigitalGauge(con);

            //SevenSegmentLayout
            segmentSevenLayout = new LinearLayout(con);
            segmentSevenLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1));
            segmentSevenLayout.SetGravity(GravityFlags.Center);
            segmentSevenLayout.AddView(segmentSevenGauge);
            segmentSevenGauge.CharacterStroke = Color.Rgb(20, 108, 237);
            segmentSevenGauge.CharacterHeight = 25;
            segmentSevenGauge.CharactersSpacing = 2;
            segmentSevenGauge.CharacterWidth = 12;
            segmentSevenGauge.SegmentStrokeWidth = 2;
            segmentSevenGauge.CharacterType = CharacterTypes.SegmentSeven;
            segmentSevenGauge.Value = currentDateandTime.ToString();
            segmentSevenGauge.DimmedSegmentColor = Color.Rgb(20, 108, 237);
            segmentSevenGauge.DimmedSegmentAlpha = 30;
            float segmentSevenHeight = TypedValue.ApplyDimension(ComplexUnitType.Pt, (float)segmentSevenGauge.CharacterHeight, con.Resources.DisplayMetrics);
            float segmentSevenWidth = TypedValue.ApplyDimension(ComplexUnitType.Pt, (float)(8 * segmentSevenGauge.CharacterWidth + 8 * segmentSevenGauge.CharactersSpacing), con.Resources.DisplayMetrics);
            segmentSevenGauge.LayoutParameters = (new LinearLayout.LayoutParams((int)segmentSevenWidth, (int)segmentSevenHeight));
            segmentSevenGauge.SetBackgroundColor(Color.Rgb(240, 240, 240));
            segmentFourteenGauge.SetBackgroundColor(Color.Rgb(240, 240, 240));
            segmentSixteenGauge.SetBackgroundColor(Color.Rgb(240, 240, 240));
            segmentMatrixGauge.SetBackgroundColor(Color.Rgb(240, 240, 240));
        }

        private void FourteenSegmentLayout()
        {
            //segmentFourteenLayout
            segmentFourteenLayout = new LinearLayout(con);
            segmentFourteenLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1));
            segmentFourteenLayout.SetGravity(GravityFlags.Center);
            segmentFourteenLayout.AddView(segmentFourteenGauge);
            segmentFourteenGauge.DimmedSegmentAlpha = 30;
            segmentFourteenGauge.DimmedSegmentColor = Color.Rgb(2, 186, 94);
            segmentFourteenGauge.CharacterStroke = Color.Rgb(2, 186, 94);
            segmentFourteenGauge.CharacterHeight = 25;
            segmentFourteenGauge.CharactersSpacing = 2;
            segmentFourteenGauge.CharacterWidth = 12;
            segmentFourteenGauge.SegmentStrokeWidth = 2;
            segmentFourteenGauge.CharacterType = CharacterTypes.SegmentFourteen;
            segmentFourteenGauge.Value = currentDateandTime;
            float segmentFourteenHeight = TypedValue.ApplyDimension(ComplexUnitType.Pt, (float)segmentFourteenGauge.CharacterHeight, con.Resources.DisplayMetrics);
            float segmentFourteenWidth = TypedValue.ApplyDimension(ComplexUnitType.Pt, (float)(8 * segmentFourteenGauge.CharacterWidth + 8 * segmentFourteenGauge.CharactersSpacing), con.Resources.DisplayMetrics);
            segmentFourteenGauge.LayoutParameters = (new LinearLayout.LayoutParams((int)segmentFourteenWidth, (int)segmentFourteenHeight));

        }

        private void SixteenSegmentLayout()
        {
            //segmentSixteenLayout
            segmentSixteenLayout = new LinearLayout(con);
            segmentSixteenLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1));
            segmentSixteenLayout.SetGravity(GravityFlags.Center);
            segmentSixteenLayout.AddView(segmentSixteenGauge);
            segmentSixteenGauge.DimmedSegmentAlpha = 30;
            segmentSixteenGauge.DimmedSegmentColor = Color.Rgb(219, 153, 7);
            segmentSixteenGauge.CharacterStroke = Color.Rgb(219, 153, 7);
            segmentSixteenGauge.CharacterHeight = 25;
            segmentSixteenGauge.CharactersSpacing = 2;
            segmentSixteenGauge.CharacterWidth = 12;
            segmentSixteenGauge.SegmentStrokeWidth = 2;
            segmentSixteenGauge.CharacterType = CharacterTypes.SegmentSixteen;
            segmentSixteenGauge.Value = currentDateandTime;
            float segmentSixteenHeight = TypedValue.ApplyDimension(ComplexUnitType.Pt, (float)segmentSixteenGauge.CharacterHeight, con.Resources.DisplayMetrics);
            float segmentSixteenWidth = TypedValue.ApplyDimension(ComplexUnitType.Pt, (float)(8 * segmentSixteenGauge.CharacterWidth + 8 * segmentSixteenGauge.CharactersSpacing), con.Resources.DisplayMetrics);
            segmentSixteenGauge.LayoutParameters = (new LinearLayout.LayoutParams((int)segmentSixteenWidth, (int)segmentSixteenHeight));

        }

        private void SegmentMatrixLayout()
        {
            //segmentMatrixLayout
            segmentMatrixLayout = new LinearLayout(con);
            segmentMatrixLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1));
            segmentMatrixLayout.SetGravity(GravityFlags.Center);
            segmentMatrixLayout.AddView(segmentMatrixGauge);
            segmentMatrixGauge.DimmedSegmentAlpha = 30;
            segmentMatrixGauge.DimmedSegmentColor = Color.Rgb(249, 66, 53);
            segmentMatrixGauge.CharacterStroke = Color.Rgb(249, 66, 53);
            segmentMatrixGauge.CharacterHeight = 25;
            segmentMatrixGauge.CharactersSpacing = 5;
            segmentMatrixGauge.CharacterWidth = 9;
            segmentMatrixGauge.SegmentStrokeWidth = 2;
            segmentMatrixGauge.CharacterType = CharacterTypes.EightCrossEightDotMatrix;
            segmentMatrixGauge.Value = currentDateandTime;
            float segmentMatrixHeight = TypedValue.ApplyDimension(ComplexUnitType.Pt, (float)segmentMatrixGauge.CharacterHeight, con.Resources.DisplayMetrics);
            float segmentMatrixWidth = TypedValue.ApplyDimension(ComplexUnitType.Pt, (float)(8 * segmentMatrixGauge.CharacterWidth + 8 * segmentMatrixGauge.CharactersSpacing), con.Resources.DisplayMetrics);
            segmentMatrixGauge.LayoutParameters = (new LinearLayout.LayoutParams((int)segmentMatrixWidth, (int)segmentMatrixHeight));

        }
      
        private void SegmentTextLayout()
        {
            //TextView
            segmentSevenText = new TextView(con);
            segmentFourteenText = new TextView(con);
            segmentSixteenText = new TextView(con);
            segmentMatrixText = new TextView(con);
            segmentSeven = new TextView(con);
            segmentFourteen = new TextView(con);
            segmentSixteen = new TextView(con);
            segmentMatrix = new TextView(con);

            //TextLayout
            sevenTextLayout = new LinearLayout(con);
            sevenTextLayout.SetGravity(GravityFlags.Center);
            sevenTextLayout.AddView(segmentSevenText);
            fourteenTextLayout = new LinearLayout(con);
            fourteenTextLayout.SetGravity(GravityFlags.Center);
            fourteenTextLayout.AddView(segmentFourteenText);
            sixteenTextLayout = new LinearLayout(con);
            sixteenTextLayout.SetGravity(GravityFlags.Center);
            sixteenTextLayout.AddView(segmentSixteenText);
            matrixTextLayout = new LinearLayout(con);
            matrixTextLayout.SetGravity(GravityFlags.Center);
            matrixTextLayout.AddView(segmentMatrixText);

            //definition
            segmentSevenText.Text = "7 Segment";
            segmentSevenText.SetTextColor(Color.Rgb(34, 34, 34));
            segmentSevenText.TextSize = 25;
            segmentFourteenText.Text = "14 Segment";
            segmentFourteenText.SetTextColor(Color.Rgb(34, 34, 34));
            segmentFourteenText.TextSize = 25;
            segmentSixteenText.Text = "16 Segment";
            segmentSixteenText.SetTextColor(Color.Rgb(34, 34, 34));
            segmentSixteenText.TextSize = 25;
            segmentMatrixText.Text = "8 X 8 DotMatrix";
            segmentMatrixText.SetTextColor(Color.Rgb(34, 34, 34));
            segmentMatrixText.TextSize = 25;
            segmentSeven.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt, 8, con.Resources.DisplayMetrics);
            segmentFourteen.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt, 8, con.Resources.DisplayMetrics);
            segmentSixteen.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt, 8, con.Resources.DisplayMetrics);
            segmentMatrix.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt, 8, con.Resources.DisplayMetrics);

            //spaceText
            spaceText1 = new TextView(con);
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 100, GravityFlags.Center);

        }

        private void GaugeViewLayout()
        {
            //gaugeScrollView
            ScrollView gaugeScrollView = new ScrollView(con);
            gaugeScrollView.HorizontalScrollBarEnabled = true;
            LinearLayout digitalGaugeLayout = new LinearLayout(con);
            digitalGaugeLayout.Orientation = Orientation.Vertical;
            digitalGaugeLayout.AddView(spaceText1);
            digitalGaugeLayout.AddView(sevenTextLayout);
            digitalGaugeLayout.AddView(segmentSevenLayout);
            digitalGaugeLayout.AddView(segmentFourteen);
            digitalGaugeLayout.AddView(fourteenTextLayout);
            digitalGaugeLayout.AddView(segmentFourteenLayout);
            digitalGaugeLayout.AddView(segmentSixteen);
            digitalGaugeLayout.AddView(sixteenTextLayout);
            digitalGaugeLayout.AddView(segmentSixteenLayout);
            digitalGaugeLayout.AddView(segmentMatrix);
            digitalGaugeLayout.AddView(matrixTextLayout);
            digitalGaugeLayout.AddView(segmentMatrixLayout);
            digitalGaugeLayout.SetGravity(GravityFlags.Center);

            //mainGaugeScrollView
            mainGaugeScrollView = new ScrollView(con);
            mainDigitalGaugeLayout = new LinearLayout(con);
            mainDigitalGaugeLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

            //mainDigitalGaugeLayout
            mainDigitalGaugeLayout.AddView(digitalGaugeLayout);
            mainDigitalGaugeLayout.SetBackgroundColor(Color.White);
            mainDigitalGaugeLayout.SetGravity(GravityFlags.Center);
            gaugeScrollView.SetForegroundGravity(GravityFlags.Center);
            gaugeScrollView.SetPadding(2, 2, 2, 2);
            gaugeScrollView.SetBackgroundColor(Color.Rgb(248, 248, 248));
            mainGaugeScrollView.AddView(mainDigitalGaugeLayout);
        }
    }
}


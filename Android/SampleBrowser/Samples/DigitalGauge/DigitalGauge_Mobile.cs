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
	public class DigitalGauge_Mobile : SamplePage
	{
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        LinearLayout segmentSevenLayout, segmentFourteenLayout, segmentSixteenLayout, segmentMatrixLayout;
        TextView segmentSevenText, segmentFourteenText, segmentSixteenText, segmentMatrixText;
        TextView segmentSeven, segmentFourteen, segmentSixteen, segmentMatrix;
        SfDigitalGauge segmentFourteenGauge;
        SfDigitalGauge segmentSixteenGauge;
        SfDigitalGauge segmentMatrixGauge;
        SfDigitalGauge segmentSevenGauge;
        string currentDateandTime;
        Context con;


        public override View GetSampleContent (Context con1)
		{
            con = con1;
            SamplePageContent(con);

            SimpleDateFormat  simpleDateFormat= new SimpleDateFormat("HH mm ss");
			currentDateandTime = simpleDateFormat.Format(new Java.Util.Date());

            SevenSegmentLayout();
            FourteenSegmentLayout();
            SixteenSegmentLayout();
            MatrixSegmentLayout();

            //Main View
            LinearLayout mainDigitalGaugeLayout = GetView(con);
            ScrollView mainView = new ScrollView(con);
            mainView.AddView(mainDigitalGaugeLayout);

            return mainView;
		}

        private void SevenSegmentLayout()
        {
            /***********************
            **Segment Seven Gauge**
            ***********************/
            segmentSevenGauge = new SfDigitalGauge(con);
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

            //SegmentSevenLayout
            segmentSevenLayout = new LinearLayout(con);
            segmentSevenLayout.SetGravity(GravityFlags.Center);
            segmentSevenLayout.AddView(segmentSevenGauge);
        }

        private void FourteenSegmentLayout()
        {
            /**************************
           **Segment Fourteen Gauge**
           **************************/
            segmentFourteenGauge = new SfDigitalGauge(con);
            segmentFourteenGauge.SetBackgroundColor(Color.Rgb(240, 240, 240));
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

            //SegmentFourteenLayout
            segmentFourteenLayout = new LinearLayout(con);
            segmentFourteenLayout.SetGravity(GravityFlags.Center);
            segmentFourteenLayout.AddView(segmentFourteenGauge);
        }

        private void SixteenSegmentLayout()
        {
            /*************************
            **Segment Sixteen Gauge**
            *************************/
            segmentSixteenGauge = new SfDigitalGauge(con);
            segmentSixteenGauge.SetBackgroundColor(Color.Rgb(240, 240, 240));
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

            //SegmentSixteenLayout
            segmentSixteenLayout = new LinearLayout(con);
            segmentSixteenLayout.SetGravity(GravityFlags.Center);
            segmentSixteenLayout.AddView(segmentSixteenGauge);
        }

        private void MatrixSegmentLayout()
        {
            /************************
            **Segment Matrix Gauge**
            ************************/
            segmentMatrixGauge = new SfDigitalGauge(con);
            segmentMatrixGauge.SetBackgroundColor(Color.Rgb(240, 240, 240));
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

            //SegmentMatrixLayout
            segmentMatrixLayout = new LinearLayout(con);
            segmentMatrixLayout.SetGravity(GravityFlags.Center);
            segmentMatrixLayout.AddView(segmentMatrixGauge);
        }

        private void SamplePageContent(Context con)
        {
            //SegmentSevenText
            segmentSevenText = new TextView(con);
            segmentSevenText.Text = "7 Segment";
            segmentSevenText.SetTextColor(Color.Rgb(34, 34, 34));
            segmentSevenText.TextSize = 25;

            //SegmentFourteenText
            segmentFourteenText = new TextView(con);
            segmentFourteenText.Text = "14 Segment";
            segmentFourteenText.SetTextColor(Color.Rgb(34, 34, 34));
            segmentFourteenText.TextSize = 25;

            //SegmentSixteenText
            segmentSixteenText = new TextView(con);
            segmentSixteenText.Text = "16 Segment";
            segmentSixteenText.SetTextColor(Color.Rgb(34, 34, 34));
            segmentSixteenText.TextSize = 25;

            //SegmentMatrixText
            segmentMatrixText = new TextView(con);
            segmentMatrixText.Text = "8 X 8 DotMatrix";
            segmentMatrixText.SetTextColor(Color.Rgb(34, 34, 34));
            segmentMatrixText.TextSize = 25;

            //SegmentSeven
            segmentSeven = new TextView(con);
            segmentSeven.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt, 8, con.Resources.DisplayMetrics);

            //SegmentFourteen
            segmentFourteen = new TextView(con);
            segmentFourteen.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt, 8, con.Resources.DisplayMetrics);

            //SegmentSixteen
            segmentSixteen = new TextView(con);
            segmentSixteen.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt, 8, con.Resources.DisplayMetrics);

            //SegmentMatrix
            segmentMatrix = new TextView(con);
            segmentMatrix.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt, 8, con.Resources.DisplayMetrics);
        }
        private LinearLayout GetView(Context con)
        {
            //sevenText Layout
            LinearLayout sevenTextLayout = new LinearLayout(con);
            sevenTextLayout.SetGravity(GravityFlags.Center);
            sevenTextLayout.AddView(segmentSevenText);

            //fourteenText Layout
            LinearLayout fourteenTextLayout = new LinearLayout(con);
            fourteenTextLayout.SetGravity(GravityFlags.Center);
            fourteenTextLayout.AddView(segmentFourteenText);

            //SixteenText Layout
            LinearLayout sixteenTextLayout = new LinearLayout(con);
            sixteenTextLayout.SetGravity(GravityFlags.Center);
            sixteenTextLayout.AddView(segmentSixteenText);

            //matrixText Layout
            LinearLayout matrixTextLayout = new LinearLayout(con);
            matrixTextLayout.SetGravity(GravityFlags.Center);
            matrixTextLayout.AddView(segmentMatrixText);

            //DigitalGauge Layout
            LinearLayout digitalGaugeLayout = new LinearLayout(con);
            digitalGaugeLayout.Orientation = Orientation.Vertical;
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

            //MainDigitalGauge Layout
            LinearLayout mainDigitalGaugeLayout = new LinearLayout(con);
            mainDigitalGaugeLayout.AddView(digitalGaugeLayout);
            mainDigitalGaugeLayout.SetBackgroundColor(Color.White);
            mainDigitalGaugeLayout.SetGravity(GravityFlags.Center);

            return mainDigitalGaugeLayout;
        }
	}
}


#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


using System;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif
using Syncfusion.SfGauge.iOS;
namespace SampleBrowser
{
    public class DigitalGauge : SampleView
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        #region View lifecycle
        public override void LayoutSubviews()
        {
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {

                if (ObjCRuntime.Runtime.Arch == ObjCRuntime.Arch.SIMULATOR)
                {
                    foreach (var view in this.Subviews)
                    {
                        view.Frame = Bounds;
                        CGSize sz = this.Frame.Size;

                        nfloat x = sz.Width / 2;
                        segmentSevenGauge.Frame = new CGRect(20, 90, sz.Width - 50, 90);
                        segmentFourteenGauge.Frame = new CGRect(20, 240, sz.Width - 50, 90);
                        segmentSixteenGauge.Frame = new CGRect(20, 380, sz.Width - 50, 90);
                        segmentMatrixGauge.Frame = new CGRect(20, 530, sz.Width - 50, 90);
                        segmentSevenText.Frame = new CGRect(x - 50, 60, 100, 25);
                        segmentFourteenText2.Frame = new CGRect(x - 50, 210, 100, 25);
                        segmentSixteenText3.Frame = new CGRect(x - 50, 350, 100, 25);
                        segmentMatrixText4.Frame = new CGRect(x - 50, 500, this.Frame.Width, 25);


                    }
                }
                else
                {
                    foreach (var view in this.Subviews)
                    {
                        view.Frame = Bounds;
                        CGSize sz = this.Frame.Size;

                        nfloat x = sz.Width / 2;
                        nfloat xPos = sz.Width / 4;
                        segmentSevenGauge.Frame = new CGRect(xPos, 90, sz.Width - 2 * xPos - 25, 90);
                        segmentFourteenGauge.Frame = new CGRect(xPos, 240, sz.Width - 2 * xPos - 25, 90);
                        segmentSixteenGauge.Frame = new CGRect(xPos, 380, sz.Width - 2 * xPos - 25, 90);
                        segmentMatrixGauge.Frame = new CGRect(xPos, 530, sz.Width - 2 * xPos - 25, 90);
                        segmentSevenText.Frame = new CGRect(x - 50, 60, 100, 25);
                        segmentFourteenText2.Frame = new CGRect(x - 50, 210, 100, 25);
                        segmentSixteenText3.Frame = new CGRect(x - 50, 350, 100, 25);
                        segmentMatrixText4.Frame = new CGRect(x - 50, 500, this.Frame.Width, 25);


                    }
                }

            }
            else
            {
                foreach (var view in this.Subviews)
                {
                    view.Frame = Bounds;
                    CGSize sz = this.Frame.Size;
                    nfloat x = sz.Width / 2;
                    segmentSevenGauge.Frame = new CGRect(x - 132, 60, 265, 60);
                    segmentFourteenGauge.Frame = new CGRect(x - 132, 160, 265, 60);
                    segmentSixteenGauge.Frame = new CGRect(x - 132, 260, 265, 60);
                    segmentMatrixGauge.Frame = new CGRect(x - 132, 360, 265, 60);
                    segmentSevenText.Frame = new CGRect(x - 50, 30, 100, 20);
                    segmentFourteenText2.Frame = new CGRect(x - 50, 130, 100, 20);
                    segmentSixteenText3.Frame = new CGRect(x - 50, 230, 100, 20);
                    segmentMatrixText4.Frame = new CGRect(x - 60, 330, this.Frame.Width, 20);
                }
            }
            base.LayoutSubviews();
        }
        SFDigitalGauge segmentMatrixGauge;
        SFDigitalGauge segmentSevenGauge;
        SFDigitalGauge segmentFourteenGauge;
        SFDigitalGauge segmentSixteenGauge;
        UILabel segmentSevenText, segmentFourteenText2, segmentSixteenText3, segmentMatrixText4;
        public DigitalGauge()
        {


            NSDate date = new NSDate();
            NSString currentDateandTime = (NSString)date.ToString();

            //SevenSegmentGauge
            segmentSevenGauge = new SFDigitalGauge();
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                segmentSevenGauge.CharacterHeight = 48;
                segmentSevenGauge.CharacterWidth = 24;
                segmentSevenGauge.VerticalPadding = 20;

            }
            else
            {
                segmentSevenGauge.CharacterHeight = 36;
                segmentSevenGauge.CharacterWidth = 18;
                segmentSevenGauge.VerticalPadding = 10;

            }
            segmentSevenGauge.SegmentWidth = 3;
            segmentSevenGauge.CharacterType = SFDigitalGaugeCharacterType.SFDigitalGaugeCharacterTypeSegmentSeven;
            segmentSevenGauge.StrokeType = SFDigitalGaugeStrokeType.SFDigitalGaugeStrokeTypeTriangleEdge;
            segmentSevenGauge.Value = currentDateandTime;
            segmentSevenGauge.DimmedSegmentAlpha = 0.11f;
            segmentSevenGauge.BackgroundColor = UIColor.FromRGB(248, 248, 248);
            segmentSevenGauge.CharacterColor = UIColor.FromRGB(20, 108, 237);
            segmentSevenGauge.DimmedSegmentColor = UIColor.FromRGB(20, 108, 237);

            //FourteenSegmentGauge
            segmentFourteenGauge = new SFDigitalGauge();
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                segmentFourteenGauge.CharacterHeight = 48;
                segmentFourteenGauge.CharacterWidth = 24;
                segmentFourteenGauge.VerticalPadding = 20;

            }
            else
            {
                segmentFourteenGauge.CharacterHeight = 36;
                segmentFourteenGauge.CharacterWidth = 18;
                segmentFourteenGauge.VerticalPadding = 10;

            }
            segmentFourteenGauge.SegmentWidth = 3;
            segmentFourteenGauge.CharacterType = SFDigitalGaugeCharacterType.SFDigitalGaugeCharacterTypeSegmentFourteen;
            segmentFourteenGauge.StrokeType = SFDigitalGaugeStrokeType.SFDigitalGaugeStrokeTypeTriangleEdge;
            segmentFourteenGauge.Value = currentDateandTime;
            segmentFourteenGauge.DimmedSegmentAlpha = 0.11f;
            segmentFourteenGauge.BackgroundColor = UIColor.FromRGB(248, 248, 248);
            segmentFourteenGauge.CharacterColor = UIColor.FromRGB(2, 186, 94);
            segmentFourteenGauge.DimmedSegmentColor = UIColor.FromRGB(2, 186, 94);

            //SixteenSegmentGauge
            segmentSixteenGauge = new SFDigitalGauge();
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                segmentSixteenGauge.CharacterHeight = 48;
                segmentSixteenGauge.CharacterWidth = 24;
                segmentSixteenGauge.VerticalPadding = 20;

            }
            else
            {
                segmentSixteenGauge.CharacterHeight = 36;
                segmentSixteenGauge.CharacterWidth = 18;
                segmentSixteenGauge.VerticalPadding = 10;

            }
            segmentSixteenGauge.SegmentWidth = 3;
            segmentSixteenGauge.CharacterType = SFDigitalGaugeCharacterType.SFDigitalGaugeCharacterTypeSegmentSixteen;
            segmentSixteenGauge.StrokeType = SFDigitalGaugeStrokeType.SFDigitalGaugeStrokeTypeTriangleEdge;
            segmentSixteenGauge.Value = currentDateandTime;
            segmentSixteenGauge.DimmedSegmentAlpha = 0.11f;
            segmentSixteenGauge.BackgroundColor = UIColor.FromRGB(248, 248, 248);
            segmentSixteenGauge.CharacterColor = UIColor.FromRGB(219, 153, 7);
            segmentSixteenGauge.DimmedSegmentColor = UIColor.FromRGB(219, 153, 7);

            //8*8 MatrixSegmentGauge
            segmentMatrixGauge = new SFDigitalGauge();
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                segmentMatrixGauge.CharacterHeight = 48;
                segmentMatrixGauge.CharacterWidth = 22;
                segmentMatrixGauge.VerticalPadding = 20;

            }
            else
            {
                segmentMatrixGauge.CharacterHeight = 36;
                segmentMatrixGauge.CharacterWidth = 17;
                segmentMatrixGauge.VerticalPadding = 10;

            }
            segmentMatrixGauge.SegmentWidth = 3;
            segmentMatrixGauge.CharacterType = SFDigitalGaugeCharacterType.SFDigitalGaugeCharacterTypeEightCrossEightDotMatrix;
            segmentMatrixGauge.StrokeType = SFDigitalGaugeStrokeType.SFDigitalGaugeStrokeTypeTriangleEdge;
            segmentMatrixGauge.Value = currentDateandTime;
            segmentMatrixGauge.DimmedSegmentAlpha = 0.11f;
            segmentMatrixGauge.BackgroundColor = UIColor.FromRGB(248, 248, 248);
            segmentMatrixGauge.CharacterColor = UIColor.FromRGB(249, 66, 53);
            segmentMatrixGauge.DimmedSegmentColor = UIColor.FromRGB(249, 66, 53);



            //adding to View
            this.AddSubview(segmentSevenGauge);
            this.AddSubview(segmentFourteenGauge);
            this.AddSubview(segmentSixteenGauge);
            this.AddSubview(segmentMatrixGauge);
            mainPageDesign();

        }
        public void mainPageDesign()
        {
            //segmentSevenTextt
            segmentSevenText = new UILabel();
            segmentSevenText.Text = "7 Segment";

            //segmentFourteenText   
            segmentFourteenText2 = new UILabel();
            segmentFourteenText2.Text = "14 Segment";

            //segmentSixteenText3
            segmentSixteenText3 = new UILabel();
            segmentSixteenText3.Text = "16 Segment";

            //segmentMatrixText4
            segmentMatrixText4 = new UILabel();
            segmentMatrixText4.Text = "8 X 8 DotMatrix";

            //Addign to view
            this.AddSubview(segmentSevenText);
            this.AddSubview(segmentFourteenText2);
            this.AddSubview(segmentSixteenText3);
            this.AddSubview(segmentMatrixText4);
        }
        #endregion

    }
}

#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Syncfusion.SfChart.iOS;
using System.Collections.ObjectModel;

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
using nfloat = System.Single;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
#endif

namespace SampleBrowser
{
    public class CustomizationRangeNavigator : SampleView
    {

        UILabel lblTitle;
        UILabel lblValue;
        SFDateTimeRangeNavigator rangeNavigator;

        public CustomizationRangeNavigator()
        {
            rangeNavigator = new SFDateTimeRangeNavigator();
            lblTitle = new UILabel();
            lblTitle.TextAlignment = UITextAlignment.Center;
            lblTitle.Font = UIFont.FromName("Helvetica", 14f);

            lblValue = new UILabel();
            lblValue.TextAlignment = UITextAlignment.Center;
            lblValue.Font = UIFont.FromName("Helvetica", 14f);

            rangeNavigator.ShowTooltip = false;
            rangeNavigator.Delegate = new CustomizationDelegate(lblTitle, lblValue);

            DateTime minDate = new DateTime(2015, 1, 1, 0, 0, 0);
            DateTime maxDate = new DateTime(2015, 12, 1, 0, 0, 0);
            DateTime startDate = new DateTime(2015, 6, 15, 0, 0, 0);
            DateTime endDate = new DateTime(2015, 9, 15, 0, 0, 0);
            rangeNavigator.Minimum = DateTimeToNSDate(minDate);
            rangeNavigator.Maximum = DateTimeToNSDate(maxDate);
            rangeNavigator.ViewRangeStart = DateTimeToNSDate(startDate);
            rangeNavigator.ViewRangeEnd = DateTimeToNSDate(endDate);
            rangeNavigator.EdgeInsets = new UIEdgeInsets(0, 0, 20, 0);

            rangeNavigator.Content.Layer.BorderWidth = 1.0f;
            rangeNavigator.Content.Layer.BorderColor = UIColor.LightGray.CGColor;
            rangeNavigator.LeftThumbStyle.LineWidth = 3.0f;
            rangeNavigator.LeftThumbStyle.Width = 28.0f;
            rangeNavigator.LeftThumbStyle.LineColor = UIColor.FromRGBA(95.0f / 255.0f, 104.0f / 255.0f, 114.0f / 255.0f, 1.0f);
            rangeNavigator.RightThumbStyle.LineWidth = 3.0f;
            rangeNavigator.RightThumbStyle.Width = 28.0f;
            rangeNavigator.RightThumbStyle.LineColor = UIColor.FromRGBA(95.0f / 255.0f, 104.0f / 255.0f, 114.0f / 255.0f, 1.0f);
            rangeNavigator.MinorScaleStyle.IsVisible = false;
            rangeNavigator.MinorScaleStyle.ShowGridLines = false;
            rangeNavigator.MajorScaleStyle.LabelTextColor = UIColor.FromRGBA(95.0f / 255.0f, 104.0f / 255.0f, 114.0f / 255.0f, 1.0f);
            rangeNavigator.MajorScaleStyle.SelectedLabelTextColor = UIColor.FromRGBA(28.0f / 255.0f, 178.0f / 255.0f, 213.0f / 255.0f, 1.0f);

            ChartViewModel dataModel = new ChartViewModel();
			SFSplineAreaSeries series = new SFSplineAreaSeries();
			series.Alpha                    = 0.6f;
			series.BorderColor                  = UIColor.FromRGBA (28.0f/255.0f, 178.0f/255.0f, 213.0f/255.0f, 1.0f);
			series.Color                = UIColor.FromRGBA (124.0f/255.0f, 230.0f/255.0f, 199.0f/255.0f, 1.0f);
            series.ItemsSource = dataModel.DateTimeRangeData;
            series.XBindingPath = "XValue";
            series.YBindingPath = "YValue";

            ((SFChart)rangeNavigator.Content).Series.Add(series);
       

            ThumbLayer thumbLayer = new ThumbLayer();
            rangeNavigator.ThumbLayer = thumbLayer;

            this.AddSubview(lblTitle);
            this.AddSubview(lblValue);
            this.AddSubview(rangeNavigator);

            NSDateFormatter resultFormatter = new NSDateFormatter();
            resultFormatter.DateFormat = "MMM dd";

            lblTitle.Text = string.Format(@"Data usage cycle: {0} - {1}",
                resultFormatter.ToString(rangeNavigator.ViewRangeStart),
                resultFormatter.ToString(rangeNavigator.ViewRangeEnd));
            lblValue.Text = string.Format(@"Data usage - 101 MB");

            //this.control = this;
        }

        public static NSDate DateTimeToNSDate(DateTime date)
        {
            DateTime reference = new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return NSDate.FromTimeIntervalSinceReferenceDate(
            (date.ToUniversalTime() - reference).TotalSeconds);
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                if (view == lblTitle)
                    lblTitle.Frame = new CGRect(Frame.X, 10, Frame.Width, 35);
                else if (view == rangeNavigator)
                    rangeNavigator.Frame = new CGRect(Frame.X, 55, Frame.Width, 180);
                else if (view == lblValue)
                    lblValue.Frame = new CGRect(Frame.X, 230, Frame.Width, 35);
                else
                    view.Frame = Frame;
            }
            base.LayoutSubviews();
        }
    }

    public class CustomizationDelegate : SFRangeNavigatorDelegate
    {
        UILabel lblTitle;
        UILabel lblValue;
        ChartViewModel dataModel;
        ObservableCollection<ChartDataModel> dataPoints;

        public CustomizationDelegate(UILabel _lblTitle, UILabel _lblValue)
        {
            lblTitle = _lblTitle;
            lblValue = _lblValue;
            dataModel = new ChartViewModel();
            dataPoints = new ObservableCollection<ChartDataModel>();
            dataPoints = dataModel.DateTimeRangeData;
        }

        public override void RangeChanged(SFDateTimeRangeNavigator rangeNavigator, NSDate startDate, NSDate endDate)
        {

            NSDateFormatter resultFormatter = new NSDateFormatter();
            resultFormatter.DateFormat = "MMM dd";

            lblTitle.Text = string.Format(@"Data usage cycle: {0} - {1}",
                resultFormatter.ToString(startDate),
                resultFormatter.ToString(endDate));

            NSDateFormatter dateFormatter = new NSDateFormatter();
            dateFormatter.DateFormat = @"MMM dd";
            ChartDataModel data = new ChartDataModel();

            NSDate date;
            NSNumber value;
            int y = 0;
            for (int i = 0; i < dataPoints.Count; i++)
            {
                data = dataPoints[i];
                date = (CustomizationRangeNavigator.DateTimeToNSDate((DateTime)data.XValue));

                if ((startDate.Compare(date) == NSComparisonResult.Ascending || startDate.Compare(date) == NSComparisonResult.Same) &&
                    (date.Compare(endDate) == NSComparisonResult.Ascending || date.Compare(endDate) == NSComparisonResult.Same))
                {
                    value = (NSNumber)data.YValue;
                    y += (int)value;
                }
            }

            lblValue.Text = string.Format(@"Data usage - {0} MB", y);
        }
    }

    public class ThumbLayer : SFRangeNavigatorThumbLayer
    {

        public override void DrawLeftThumbInContext(CGContext ctx, CGPoint startPoint, CGPoint endPoint)
        {
            CGRect rect = new CGRect(startPoint.X - 14, endPoint.Y - 14, 14, 14);
            DrawTriangleInContext(ctx, rect, 1, false);

            rect = new CGRect(startPoint.X - 14.5f, (float)endPoint.Y + 0.5f, 15.5f, 12f);
            DrawRectShapeInContext(ctx, rect);

            //		Sets the region to be captured for dragging the left thumb. 
            //		When you are changing the default position or size of the thumb by overriding drawLeftThumbInContext method, 
            //		this method should be called mandatorily to set the region a user can touch to drag the thumb.
            this.SetLeftThumbFrame(new CGRect(startPoint.X - 14, startPoint.Y, 22, endPoint.Y + 16));
        }

        public override void DrawRightThumbInContext(CGContext ctx, CGPoint startPoint, CGPoint endPoint)
        {
            CGRect rect = new CGRect(startPoint.X, endPoint.Y - 14, 14, 14);
            DrawTriangleInContext(ctx, rect, 1, true);

            rect = new CGRect(startPoint.X - 1f, endPoint.Y + 0.5f, 15.5f, 12f);
            DrawRectShapeInContext(ctx, rect);

            //		Sets the region to be captured for dragging the right thumb. 
            //		When you are changing the default position or size of the thumb by overriding drawRightThumbInContext method, 
            //		this method should be called mandatorily to set the region a user can touch to drag the thumb.
            this.SetRightThumbFrame(new CGRect(startPoint.X, startPoint.Y - 16, 22, endPoint.Y + 16));
        }

        //utility for drawing triangle shape
        public void DrawTriangleInContext(CGContext ctx, CGRect rect, float BorderWidth, bool isLeft)
        {
            UIColor color = UIColor.FromRGBA(95.0f / 255.0f, 104.0f / 255.0f, 114.0f / 255.0f, 1.0f);
            ctx.SetLineWidth(BorderWidth);
            ctx.SetStrokeColor(color.CGColor);
            ctx.SetFillColor(color.CGColor);
            ctx.SaveState();

            if (isLeft)
                ctx.MoveTo(rect.GetMinX(), rect.GetMinY());
            else
                ctx.MoveTo(rect.GetMaxX(), rect.GetMinY());

            ctx.AddLineToPoint(rect.GetMinX(), rect.GetMaxY());
            ctx.AddLineToPoint(rect.GetMaxX(), rect.GetMaxY());
            ctx.ClosePath();
            ctx.DrawPath(CGPathDrawingMode.FillStroke);
            ctx.RestoreState();
        }

        //utility for drawing rectangle shape
        public void DrawRectShapeInContext(CGContext ctx, CGRect rect)
        {
            ctx.SetFillColor(UIColor.FromRGBA(95.0f / 255.0f, 104.0f / 255.0f, 114.0f / 255.0f, 1.0f).CGColor);
            ctx.SetStrokeColor(UIColor.FromRGBA(95.0f / 255.0f, 104.0f / 255.0f, 114.0f / 255.0f, 1.0f).CGColor);
            ctx.StrokeRect(rect);
            ctx.FillRect(rect);

            // Add rounded rect over plain rect with 4 pixel below the origin y, so that it will visible only the bottom rounded corners
            CGRect cornerRect = new CGRect(rect.X, rect.Y + 4, rect.Width, rect.Height);
            nfloat radius = 4;
            nfloat minx = cornerRect.GetMinX(), midx = cornerRect.GetMidX(), maxx = cornerRect.GetMaxX();
            nfloat miny = cornerRect.GetMinY(), midy = cornerRect.GetMidY(), maxy = cornerRect.GetMaxY();

            ctx.SaveState();
            ctx.MoveTo(minx, miny);
            ctx.AddArcToPoint(minx, miny, midx, miny, radius);
            ctx.AddArcToPoint(maxx, miny, maxx, midy, radius);
            ctx.AddArcToPoint(maxx, maxy, midx, maxy, radius);
            ctx.AddArcToPoint(minx, maxy, minx, midy, radius);
            ctx.ClosePath();
            ctx.DrawPath(CGPathDrawingMode.FillStroke);
            ctx.RestoreState();
        }
    }
}
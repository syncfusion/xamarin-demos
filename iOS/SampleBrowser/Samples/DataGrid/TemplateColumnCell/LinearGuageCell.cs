#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using UIKit;
using Syncfusion.SfRangeSlider.iOS;
using Syncfusion.SfBarcode.iOS;
using Syncfusion.SfGauge.iOS;
using Syncfusion.SfDataGrid;
using Syncfusion.Data;
using CoreAnimation;
using System.Diagnostics;
using Syncfusion.SfChart.iOS;
using Foundation;

namespace SampleBrowser
{

	public class GridImageCell:GridCell
	{
		private UIImageView imageview;
		CoreGraphics.CGRect framespec = new CoreGraphics.CGRect ();

		public GridImageCell ()
		{
			imageview = new UIImageView ();
			this.CanRendererUnload = false;
		}

		protected override void UnLoad ()
		{
			this.RemoveFromSuperview ();
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			if (imageview.Superview == null) {

				this.AddSubview (imageview);
                framespec = new CoreGraphics.CGRect(20, 3, 60, (nfloat)DataColumn.Renderer.DataGrid.RowHeight - 5);
			}
            imageview.Frame = framespec;
			imageview.Image = (UIImage)DataColumn.RowData.GetType ().GetProperty ("CustomerImage").GetValue (DataColumn.RowData);
		}

		public override void Draw (CoreGraphics.CGRect rect)
		{
			base.Draw (rect);
		}

		protected override void Dispose (bool disposing)
		{
			this.imageview = null;
			base.Dispose (disposing);
		}
	}

	public class BoolFormatCell : GridCell
	{
		UISwitch swicth;

		public BoolFormatCell ()
		{
			swicth = new UISwitch ();
			swicth.ValueChanged += Swicth_ValueChanged;
			this.CanRendererUnload = false;
			this.AddSubview (swicth);
		}

		void Swicth_ValueChanged (object sender, EventArgs e)
		{
			bool isChecked = (sender as UISwitch).On;
			DataColumn.Renderer.DataGrid.View.GetPropertyAccessProvider().SetValue (DataColumn.RowData, DataColumn.GridColumn.MappingName, isChecked);
		}

		protected override void UnLoad ()
		{
			this.RemoveFromSuperview ();
		}

		public override void Draw (CoreGraphics.CGRect rect)
		{
			base.Draw (rect);
		}

		public override void LayoutSubviews ()
		{
			this.swicth.Frame = new CoreGraphics.CGRect (30, 17, this.Bounds.Width, this.Bounds.Height);
			this.swicth.On = Convert.ToBoolean (DataColumn.CellValue);
			base.LayoutSubviews ();
		}

		protected override void Dispose (bool disposing)
		{
			if (this.swicth != null) {
				this.swicth.ValueChanged -= Swicth_ValueChanged;
				this.swicth.Dispose ();
				this.swicth = null;
			}
			base.Dispose (disposing);
		}
	}

	//public class LinearGuageCell:GridCell
	//{
	//	SFLinearGauge linearGauge;
	//	SFSymbolPointer symbolPointer;
	//	SFBarPointer rangePointer;

	//	public LinearGuageCell ()
	//	{
	//		linearGauge = new SFLinearGauge ();
	//		linearGauge.Frame = new CoreGraphics.CGRect (2, 2, 105, 40);
	//		linearGauge.BackgroundColor = base.BackgroundColor;
	//		linearGauge.Orientation = SFLinearGaugeOrientation.SFLinearGaugeOrientationHorizontal;
	//		//Scale

	//		SFLinearScale scale = new SFLinearScale ();
	//		scale.Minimum = 0;
	//		scale.Maximum = 100;
	//		scale.Interval = 50;
	//		scale.ScaleBarLength = 100;
	//		scale.ScaleBarColor = UIColor.FromRGB (250, 236, 236);
	//		scale.LabelColor = UIColor.FromRGB (84, 84, 84); 
	//		scale.MinorTicksPerInterval = 1;
	//		scale.ScaleBarSize = 13;
	//		scale.ScalePosition = SFLinearGaugeScalePosition.SFLinearGaugeScalePositionForward;
	//		scale.Hidden = true;
	//		//SymbolPointer
	//		symbolPointer = new SFSymbolPointer ();
	//		symbolPointer.Offset = 0;
	//		symbolPointer.Thickness = 3;
	//		symbolPointer.Color = UIColor.FromRGB (65, 77, 79);

	//		//BarPointer
	//		rangePointer = new SFBarPointer ();
	//		rangePointer.Color = UIColor.FromRGB (206, 69, 69);
	//		rangePointer.Thickness = 10;


	//		//Range
	//		SFLinearRange range = new SFLinearRange ();
	//		range.StartValue = 0;
	//		range.EndValue = 50;
	//		range.Color = UIColor.FromRGB (234, 248, 249);
	//		range.StartWidth = 10;
	//		range.EndWidth = 10;
	//		range.Offset = -0.17f;
	//		scale.Ranges.Add (range);


	//		//Range
	//		SFLinearRange range2 = new SFLinearRange ();
	//		range2.StartValue = 50;
	//		range2.EndValue = 100;
	//		range2.Color = UIColor.FromRGB (50, 184, 198);
	//		range2.StartWidth = 10;
	//		range2.EndWidth = 10;
	//		range2.Offset = -0.17f;
	//		scale.Ranges.Add (range2);

	//		//Minor Ticks setting
	//		SFLinearTickSettings minor = new SFLinearTickSettings ();
	//		minor.Length = 10;
	//		minor.Color = UIColor.FromRGB (175, 175, 175);
	//		minor.Thickness = 1;
	//		scale.MinorTickSettings = minor;

	//		//Major Ticks setting
	//		SFLinearTickSettings major = new SFLinearTickSettings ();
	//		major.Length = 10;
	//		major.Color = UIColor.FromRGB (175, 175, 175);
	//		major.Thickness = 1;
	//		scale.MajorTickSettings = major;
	//		scale.Pointers.Add (symbolPointer);
	//		scale.Pointers.Add (rangePointer);

	//		linearGauge.Scales.Add (scale);
	//		CanRenderUnLoad = false;
	//		this.AddSubview (linearGauge);
	//	}

	//	protected override void UnLoad ()
	//	{
	//		this.RemoveFromSuperview ();
	//	}

	//	public override void Draw (CoreGraphics.CGRect rect)
	//	{
	//		this.linearGauge.Frame = new CoreGraphics.CGRect (rect.Left, rect.Top, Bounds.Width, Bounds.Height);
	//		base.Draw (rect);
	//	}

	//	public override void LayoutSubviews ()
	//	{
	//		base.LayoutSubviews ();
	//		symbolPointer.Value = (nfloat)Convert.ToDouble (DataColumn.CellValue);
	//	}

	//	protected override void Dispose (bool disposing)
	//	{
	//		if (linearGauge != null) {
	//			this.linearGauge.Dispose ();
	//		}
	//		this.linearGauge = null;
	//		this.rangePointer = null;
	//		this.symbolPointer = null;
	//		base.Dispose (disposing);
	//	}
	//}

	//public class LineChartCell : GridCell
	//{
	//	SFChart chart ;
	//	ChartLineDataSource dataModel;
	//	public LineChartCell ()
	//	{
	//		chart = new SFChart ();
	//		SFCategoryAxis primaryAxis 		= new SFCategoryAxis ();
	//		primaryAxis.PlotOffset 			= 5;
	//		chart.PrimaryAxis 				= primaryAxis;
	//		SFNumericalAxis secondaryAxis 	= new SFNumericalAxis ();
	//		chart.SecondaryAxis 			= secondaryAxis;
	//		dataModel	= new ChartLineDataSource ();
	//		chart.DataSource = dataModel as SFChartDataSource;
	//		chart.PrimaryAxis.ShowMajorGridLines = false;
	//		chart.PrimaryAxis.Visible = false;
	//		chart.SecondaryAxis.Visible = false;
	//		chart.SecondaryAxis.ShowMajorGridLines = false;
	//		chart.Legend.Visible = false;
	//		this.AddSubview (chart);
	//		this.CanRenderUnLoad = false;
	//	}

	//	protected override void UnLoad ()
	//	{
	//		this.RemoveFromSuperview ();
	//	}

	//	public override void LayoutSubviews ()
	//	{
	//		chart.Frame = new CoreGraphics.CGRect (0, 0, 105, 50);
	//		//if((this.DataColumn.RowData as BankInfo).CustomerID <14)
	//		//	dataModel.DataPoints.ReplaceObject((nint)((this.DataColumn.RowData as BankInfo).CustomerID),new SFChartDataPoint (NSObject.FromObject ("20"+(this.DataColumn.RowData as BankInfo).CustomerID.ToString()), NSObject.FromObject((this.DataColumn.RowData as BankInfo).CustomerID.ToString())));
	//		//chart.ReloadData ();
	//		base.LayoutSubviews ();

	//	}

	//	public override void Draw (CoreGraphics.CGRect rect)
	//	{
	//		base.Draw (rect);
	//	}
	//}

	//public class ChartLineDataSource : SFChartDataSource
	//{
	//	public NSMutableArray DataPoints;

	//	public ChartLineDataSource ()
	//	{
	//		DataPoints = new NSMutableArray ();
	//		AddDataPointsForChart("2010", 45);
	//		AddDataPointsForChart("2011", 86);
	//		AddDataPointsForChart("2012", 23);
	//		AddDataPointsForChart("2013", 43);
	//		AddDataPointsForChart("2014", 54);
	//		AddDataPointsForChart("2010", 48);
	//		AddDataPointsForChart("2011", 68);
	//		AddDataPointsForChart("2012", 20);
	//		AddDataPointsForChart("2013", 56);
	//		AddDataPointsForChart("2014", 53);
	//		AddDataPointsForChart("2010", 48);
	//		AddDataPointsForChart("2011", 61);
	//		AddDataPointsForChart("2012", 13);
	//		AddDataPointsForChart("2013", 76);
	//		AddDataPointsForChart("2014", 04);
	//	}

	//	void AddDataPointsForChart (String month, Double value)
	//	{
	//		//DataPoints.Add (new SFChartDataPoint (NSObject.FromObject (month), NSObject.FromObject(value)));
	//	}

	//	public override nint NumberOfSeriesInChart (SFChart chart)
	//	{
	//		return 1; 
	//	}

	//	public override SFSeries GetSeries (SFChart chart, nint index)
	//	{
	//		SFLineSeries series			= new SFLineSeries ();
	//		series.DataMarker.ShowLabel	= false;
	//		series.LineWidth 			= 1;
	//		return series;
	//	}

	//	public override SFChartDataPoint GetDataPoint (SFChart chart, nint index, nint seriesIndex)
	//	{
 //           return null;// DataPoints.GetItem<SFChartDataPoint> ((nuint)index);//returns the datapoint for each series.
	//	}

	//	public override nint GetNumberOfDataPoints (SFChart chart, nint index)
	//	{
	//		return (int)DataPoints.Count;//No of datapoints needed for each series.
	//	}
	//}
}


#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
    public partial class BoxAndWhiskerChart : SampleView
    {
        public BoxAndWhiskerChart()
        {
            InitializeComponent();

            boxPlotMode.SelectedIndex = 0;
            boxPlotMode.SelectedIndexChanged += BoxPlotMode_SelectedIndexChanged;

            symbolType.SelectedIndex = 0;
            symbolType.SelectedIndexChanged += SymbolType_SelectedIndexChanged;

        }

        private void SymbolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (symbolType.SelectedIndex)
            {
                case 0:
                    boxPlotSeries.SymbolType = ChartSymbolType.Ellipse;
                    break;
                case 1:
                    boxPlotSeries.SymbolType = ChartSymbolType.Diamond;
                    break;
                case 2:
                    boxPlotSeries.SymbolType = ChartSymbolType.Cross;
                    break;
                case 3:
                    boxPlotSeries.SymbolType = ChartSymbolType.Hexagon;
                    break;
                case 4:
                    boxPlotSeries.SymbolType = ChartSymbolType.InvertedTriangle;
                    break;
                case 5:
                    boxPlotSeries.SymbolType = ChartSymbolType.Pentagon;
                    break;
                case 6:
                    boxPlotSeries.SymbolType = ChartSymbolType.Plus;
                    break;
                case 7:
                    boxPlotSeries.SymbolType = ChartSymbolType.Rectangle;
                    break;
                case 8:
                    boxPlotSeries.SymbolType = ChartSymbolType.Triangle;
                    break;
            }
        }

        private void BoxPlotMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (boxPlotMode.SelectedIndex)
            {
                case 0:
                    boxPlotSeries.BoxPlotMode = BoxPlotMode.Exclusive;
                    break;
                case 1:
                    boxPlotSeries.BoxPlotMode = BoxPlotMode.Inclusive;
                    break;
                case 2:
                    boxPlotSeries.BoxPlotMode = BoxPlotMode.Normal;
                    break;
            }
        }

        private void ShowMedian_Toggled(object sender, ToggledEventArgs e)
        {
            boxPlotSeries.ShowMedian = e.Value;
        }
    }
}
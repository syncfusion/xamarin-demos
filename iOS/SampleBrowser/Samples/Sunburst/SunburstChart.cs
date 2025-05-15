#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfSunburstChart.iOS;
using CoreGraphics;
using UIKit;
using System.Collections.ObjectModel;
using Foundation;

namespace SampleBrowser
{
    public class SunburstChart : SampleView
    {
        SfSunburstChart chart;
        public SunburstChart()
        {
            var Data = new ObservableCollection<SunburstModel>();

            Data.Add(new SunburstModel() { Quarter = "Q1", Month = "Jan", Sales = 11 });
            Data.Add(new SunburstModel() { Quarter = "Q1", Month = "Feb", Sales = 8 });
            Data.Add(new SunburstModel() { Quarter = "Q1", Month = "Mar", Sales = 5 });

            Data.Add(new SunburstModel() { Quarter = "Q2", Month = "Apr", Sales = 13 });
            Data.Add(new SunburstModel() { Quarter = "Q2", Month = "May", Sales = 12 });
            Data.Add(new SunburstModel() { Quarter = "Q2", Month = "Jun", Sales = 17 });

            Data.Add(new SunburstModel() { Quarter = "Q3", Month = "Jul", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q3", Month = "Aug", Sales = 4 });
            Data.Add(new SunburstModel() { Quarter = "Q3", Month = "Sep", Sales = 5 });

            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Oct", Sales = 7 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Nov", Sales = 18 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W1", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W2", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W3", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W4", Sales = 5 });



            chart = new SfSunburstChart();
            chart.ItemsSource = Data;
            chart.Radius = 0.95;
            chart.ValueMemberPath = "Sales";
            var levels = new SunburstLevelCollection()
            {
                new SunburstHierarchicalLevel() { GroupMemberPath = "Quarter"},
                new SunburstHierarchicalLevel() { GroupMemberPath = "Month"},
                new SunburstHierarchicalLevel() { GroupMemberPath = "Week"},
            };
            chart.Levels = levels;


            chart.Title.IsVisible = true;
            chart.Title.Text = "Sales Performance";
            chart.Title.Font= UIFont.SystemFontOfSize(20);
            chart.Title.Margin = new UIEdgeInsets(10, 5, 5, 5);

            chart.Legend.IsVisible = true;
            chart.Legend.LegendPosition = SunburstDockPosition.Bottom;
            chart.Legend.LabelStyle.Font= UIFont.SystemFontOfSize(16);
            chart.Legend.IconHeight = 12;
            chart.Legend.IconWidth = 12;

            chart.DataLabel.ShowLabel = true;

            chart.EnableAnimation = true;

            chart.TooltipSettings = new CustomTooltip();
            chart.TooltipSettings.ShowTooltip = true;

            this.AddSubview(chart);

        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            chart.Frame = new CGRect(Frame.Location.X, 0, this.Frame.Width, this.Frame.Height);
        }
    }

    public class CustomTooltip : SunburstTooltipSettings
    {
        public override UIView GetView(SunburstSegment segment)
        {
            UIView customView = new UIView();
            customView.BackgroundColor = UIColor.Black;

            UILabel label = new UILabel();
            label.TextColor = UIColor.White;
            label.Font = UIFont.FromName("Helvetica", 13f);
            label.Text = "Category : " + segment.Category;
            var labelSize = label.SystemLayoutSizeFittingSize(UIKit.UIView.UILayoutFittingExpandedSize);
            label.Frame = new CGRect(7, 7, labelSize.Width, labelSize.Height);

            UILabel label1 = new UILabel();
            label1.TextColor = UIColor.White;
            label1.Font = UIFont.FromName("Helvetica", 13f);
            label1.Text = "Value : " + segment.Value;
            var labelSize1 = label1.SystemLayoutSizeFittingSize(UIKit.UIView.UILayoutFittingExpandedSize);
            label1.Frame = new CGRect(7, labelSize.Height + 7, labelSize1.Width, labelSize1.Height);

            customView.AddSubview(label);
            customView.AddSubview(label1);

            var height = label.Frame.Height + label1.Frame.Height;
            var width = label.Frame.Width > label1.Frame.Width ? label.Frame.Width : label1.Frame.Width;

            customView.Frame = new CGRect(0, 0, width + 14, height + 14);

            return customView;
        }
    }

    [Preserve(AllMembers = true)]
    public class SunburstModel
    {
        public string Category { get; set; }
        public string Country { get; set; }
        public string JobDescription { get; set; }
        public string JobGroup { get; set; }
        public string JobRole { get; set; }
        public double EmployeesCount { get; set; }

        public string Continent { get; set; }
        public string State { get; set; }
        public double Population { get; set; }

        public string Quarter { get; set; }
        public string Month { get; set; }
        public string Week { get; set; }
        public double Sales { get; set; }
    }

}
#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using Syncfusion.SfSunburstChart.Android;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.Runtime;

namespace SampleBrowser
{
    [Preserve(AllMembers = true)]
	public class SunburstChart :SamplePage
	{
		SfSunburstChart chart;
		public override View GetSampleContent(Context context)
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



            chart = new SfSunburstChart(context);
			chart.ItemsSource = Data;
			chart.Radius = 0.95;
            chart.ValueMemberPath = "Sales";
            var levels = new SunburstLevelCollection()
            {
				new SunburstHierarchicalLevel() { GroupMemberPath = "Quarter"},
				new SunburstHierarchicalLevel() { GroupMemberPath = "Month"},
				new SunburstHierarchicalLevel() { GroupMemberPath = "Week"}				
            };
			chart.Levels = levels;

            chart.EnableAnimation = true;

            chart.Title.IsVisible = true;
            chart.Title.Margin = new Thickness(10, 5, 5, 5);
            chart.Title.Text = "Sales Performance";
            chart.Title.TextSize = 20;

            chart.Legend.IsVisible = true;

            chart.DataLabel.ShowLabel = true;

            chart.TooltipSettings = new CustomTooltip(context);
            chart.TooltipSettings.ShowTooltip = true;

            return chart;
		}
	}

    public class CustomTooltip : SunburstTooltipSettings
    {
        Context context;

        public CustomTooltip(Context con)
        {
            context = con;
        }
        public override View GetView(SunburstSegment segment)
        {
            LinearLayout linearLayout = new LinearLayout(context);
            linearLayout.Orientation = Orientation.Vertical;

            TextView textView = new TextView(context);
            textView.SetTextColor(Color.White);
            textView.Text = "Category : " + segment.Category;

            TextView textView1 = new TextView(context);
            textView1.SetTextColor(Color.White);
            textView1.Text = "Value : " + segment.Value;

            linearLayout.AddView(textView);
            linearLayout.AddView(textView1);

            return linearLayout;
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

        public string Quarter { get; set; }
        public string Month { get; set; }
        public string Week { get; set; }
        public double Sales { get; set; }

        public string Continent { get; set; }
        public string State { get; set; }
        public double Population { get; set; }
    }
}
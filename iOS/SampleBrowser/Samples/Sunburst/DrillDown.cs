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

namespace SampleBrowser
{
	public class DrillDown : SampleView
	{
		SfSunburstChart chart;
        UILabel label;
        public ObservableCollection<SunburstModel> DataSource { get; set; }
        public DrillDown()
		{

            this.DataSource = new ObservableCollection<SunburstModel>
            {
                new SunburstModel { Country = "USA", JobDescription = "Sales", JobGroup="Executive", EmployeesCount = 50 },
                new SunburstModel { Country = "USA", JobDescription = "Sales", JobGroup = "Analyst", EmployeesCount = 40 },
                new SunburstModel { Country = "USA", JobDescription = "Marketing", EmployeesCount = 40 },
                new SunburstModel { Country = "USA", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 35 },
                new SunburstModel { Country = "USA", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 175 },
                new SunburstModel { Country = "USA", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 70 },
                new SunburstModel { Country = "USA", JobDescription = "Management", EmployeesCount = 40 },
                new SunburstModel { Country = "USA", JobDescription = "Accounts", EmployeesCount = 60 },

                new SunburstModel { Country = "India", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 33 },
                new SunburstModel { Country = "India", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 125 },
                new SunburstModel { Country = "India", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 60 },
                new SunburstModel { Country = "India", JobDescription = "HR Executives", EmployeesCount = 70 },
                new SunburstModel { Country = "India", JobDescription = "Accounts", EmployeesCount = 45 },

                new SunburstModel { Country = "Germany", JobDescription = "Sales", JobGroup = "Executive", EmployeesCount = 30 },
                new SunburstModel { Country = "Germany", JobDescription = "Sales", JobGroup = "Analyst", EmployeesCount = 40 },
                new SunburstModel { Country = "Germany", JobDescription = "Marketing", EmployeesCount = 50 },
                new SunburstModel { Country = "Germany", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 40 },
                new SunburstModel { Country = "Germany", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 65 },
                new SunburstModel { Country = "Germany", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 27 },
                new SunburstModel { Country = "Germany", JobDescription = "Management", EmployeesCount = 33 },
                new SunburstModel { Country = "Germany", JobDescription = "Accounts", EmployeesCount = 55 },

                new SunburstModel { Country = "UK", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 25 },
                new SunburstModel { Country = "UK", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 96 },
                new SunburstModel { Country = "UK", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 55 },
                new SunburstModel { Country = "UK", JobDescription = "HR Executives", EmployeesCount = 60 },
                new SunburstModel { Country = "UK", JobDescription = "Accounts", EmployeesCount = 30 }
            };

            chart = new SfSunburstChart();
			chart.ItemsSource = DataSource;
			chart.Radius = 0.95;
			chart.ValueMemberPath = "EmployeesCount";
			var levels = new SunburstLevelCollection()
            {
				new SunburstHierarchicalLevel() { GroupMemberPath = "Country"},
				new SunburstHierarchicalLevel() { GroupMemberPath = "JobDescription"},
                new SunburstHierarchicalLevel() { GroupMemberPath = "JobGroup"},
                new SunburstHierarchicalLevel() { GroupMemberPath = "JobRole"}
            };
			chart.Levels = levels;
			
            chart.Title.IsVisible = true;
            chart.Title.Text = "Employee Count";
            chart.Title.Font= UIFont.SystemFontOfSize(20);
			chart.Title.Margin = new UIEdgeInsets(10, 5, 5, 5);

            chart.Legend.IsVisible = true;
            chart.Legend.LegendPosition = SunburstDockPosition.Top;
            chart.Legend.LabelStyle.Font= UIFont.SystemFontOfSize(16);
            chart.Legend.IconHeight = 12;
            chart.Legend.IconWidth = 12;

            chart.DrilldownSettings.Enable = true;

            chart.DataLabel.ShowLabel = true;

            label = new UILabel();
            label.Text = "Double tap on the segment to perform drill down.";
            label.TextColor = UIColor.Black;
            label.TextAlignment = UITextAlignment.Center;
            label.Font= UIFont.FromName("Helvetica", 12f);



            this.AddSubview(chart);
            this.AddSubview(label);
            
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			chart.Frame = new CGRect(Frame.Location.X, 0, this.Frame.Width, this.Frame.Height);
            label.Frame = new CGRect(0, Frame.Height - 20, Frame.Width, 20);
		}
	}

}
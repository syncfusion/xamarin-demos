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
using System.Drawing;

namespace SampleBrowser
{
    public class SunburstSelection : SampleView
    {
        SfSunburstChart chart;
        UIPickerView selectionModePicker;
        UIPickerView selectionTypePicker;
        UIView option;
        public ObservableCollection<SunburstModel> Population_Data { get; set; }
        public SunburstSelection()
        {
            selectionModePicker = new UIPickerView();
            selectionTypePicker = new UIPickerView();
            option = new UIView();
            this.Population_Data = new ObservableCollection<SunburstModel>
            {
                    new SunburstModel { State = "Ontario", Continent = "North America", Country = "Canada", Population = 13210600 },
                    new SunburstModel { State = "New York", Continent = "North America", Country = "United States", Population = 19378102 },
                    new SunburstModel { State = "Pennsylvania", Continent = "North America", Country = "United States", Population = 12702379 },
                    new SunburstModel { State = "Ohio", Continent = "North America", Country = "United States", Population = 11536504 },
                    new SunburstModel { State = "Buenos Aires", Continent = "South America", Country = "Argentina", Population = 15594428 },
                    new SunburstModel { State = "Minas Gerais", Continent = "South America", Country = "Brazil", Population = 20593366 },
                    new SunburstModel { State = "Rio de Janeiro", Continent = "South America", Country = "Brazil", Population = 16369178 },
                    new SunburstModel { State = "Bahia", Continent = "South America", Country = "Brazil", Population = 15044127 },
                    new SunburstModel { State = "Rio Grande do Sul", Continent = "South America", Country = "Brazil", Population = 11164050 },
                    new SunburstModel { State = "Parana", Continent = "South America", Country = "Brazil", Population = 10997462 },
                    new SunburstModel { State = "Chittagong", Continent = "Asia", Country = "Bangladesh", Population = 28079000 },
                    new SunburstModel { State = "Rajshahi", Continent = "Asia", Country = "Bangladesh", Population = 18329000 },
                    new SunburstModel { State = "Khulna", Continent = "Asia", Country = "Bangladesh", Population = 15563000 },
                    new SunburstModel { State = "Liaoning", Continent = "Asia", Country = "China", Population = 43746323 },
                    new SunburstModel { State = "Shaanxi", Continent = "Asia", Country = "China", Population = 37327378 },
                    new SunburstModel { State = "Fujian", Continent = "Asia", Country = "China", Population = 36894216 },
                    new SunburstModel { State = "Shanxi", Continent = "Asia", Country = "China", Population = 35712111 },
                    new SunburstModel { State = "Kerala", Continent = "Asia", Country = "India", Population = 33387677 },
                    new SunburstModel { State = "Punjab", Continent = "Asia", Country = "India", Population = 27704236 },
                    new SunburstModel { State = "Haryana", Continent = "Asia", Country = "India", Population = 25353081 },
                    new SunburstModel { State = "Delhi", Continent = "Asia", Country = "India", Population = 16753235 },
                    new SunburstModel { State = "Jammu", Continent = "Asia", Country = "India", Population = 12548926 },
                    new SunburstModel { State = "West Java", Continent = "Asia", Country = "Indonesia", Population = 43021826 },
                    new SunburstModel { State = "East Java", Continent = "Asia", Country = "Indonesia", Population = 37476011 },
                    new SunburstModel { State = "Banten", Continent = "Asia", Country = "Indonesia", Population = 10644030 },
                    new SunburstModel { State = "Jakarta", Continent = "Asia", Country = "Indonesia", Population = 10187595 },
                    new SunburstModel { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 24000200 },
                    new SunburstModel { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 15042531 },
                    new SunburstModel { State = "Rift Valley", Continent = "Africa", Country = "Kenya", Population = 10006805 },
                    new SunburstModel { State = "Lagos", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                    new SunburstModel { State = "Kano", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                    new SunburstModel { State = "Gauteng", Continent = "Africa", Country = "South Africa", Population = 12728400 },
                    new SunburstModel { State = "KwaZulu-Natal", Continent = "Africa", Country = "South Africa", Population = 10456900 },
                    new SunburstModel { State = "Ile-de- France", Continent = "Europe", Country = "France", Population = 11694000 },
                    new SunburstModel { State = "North Rhine-Westphalia", Continent = "Europe", Country = "Germany", Population = 17872863 },
                    new SunburstModel { State = "Bavaria", Continent = "Europe", Country = "Germany", Population = 12510331 },
                    new SunburstModel { State = "NBaden-Wurttemberg", Continent = "Europe", Country = "Germany", Population = 10747479 },
                    new SunburstModel { State = "England", Continent = "Europe", Country = "United Kingdom", Population = 51446600 }
            };



            chart = new SfSunburstChart();
            chart.ItemsSource = Population_Data;
            chart.Radius = 0.95;
            chart.ValueMemberPath = "Population";
            var levels = new SunburstLevelCollection()
            {
                new SunburstHierarchicalLevel() { GroupMemberPath = "Continent"},
                new SunburstHierarchicalLevel() { GroupMemberPath = "Country"},
                new SunburstHierarchicalLevel() { GroupMemberPath = "State"}
            };
            chart.Levels = levels;

            chart.Title.IsVisible = true;
            chart.Title.Text = "Population Data";
            chart.Title.Font= UIFont.SystemFontOfSize(20);
            chart.Title.Margin = new UIEdgeInsets(10, 5, 5, 5);

            chart.Legend.IsVisible = true;
            chart.Legend.LabelStyle.Font= UIFont.SystemFontOfSize(16);
            chart.Legend.IconHeight = 12;
            chart.Legend.IconWidth = 12;

            chart.SelectionSettings.EnableSelection = true;


            chart.DataLabel.ShowLabel = true;

            this.AddSubview(chart);

            CreateOptionView();
            this.OptionView = option;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            chart.Frame = new CGRect(Frame.Location.X, 0, this.Frame.Width, this.Frame.Height);
        }

        private void CreateOptionView()
        {
            UILabel selectionMode = new UILabel();

            selectionMode.Text = "Selection Mode";
            selectionMode.TextAlignment = UITextAlignment.Left;

            selectionMode.TextColor = UIColor.Black;
            selectionMode.Frame = new CGRect(10, 20, 120, 20);
            selectionMode.Font = UIFont.FromName("Helvetica", 14f);

            UILabel selectionType = new UILabel();

            selectionType.Text = "Selection Type";
            selectionType.TextAlignment = UITextAlignment.Left;
            selectionType.TextColor = UIColor.Black;
            selectionType.Frame = new CGRect(10, 80, 120, 20);
            selectionType.Font = UIFont.FromName("Helvetica", 14f);

            List<string> position1 = new List<string> { "Opacity", "Color", "Stroke" };
            var picker1 = new SelectionPickerModel(position1);


            selectionModePicker.Model = picker1;
            selectionModePicker.SelectedRowInComponent(0);
            selectionModePicker.Frame = new CGRect(140, 10, 150, 40);

            picker1.ValueChanged += (sender, e) =>
            {
                if (picker1.SelectedValue == "Opacity")
                {
                    chart.SelectionSettings.SelectionDisplayMode = SelectionDisplayMode.HighlightByOpacity;

                }
                else if (picker1.SelectedValue == "Color")
                {
                    chart.SelectionSettings.SelectionDisplayMode = SelectionDisplayMode.HighlightByColor;
                }
                else if (picker1.SelectedValue == "Stroke")
                {
                    chart.SelectionSettings.SelectionDisplayMode = SelectionDisplayMode.HighlightByStroke;
                }

            };

            List<string> position2 = new List<string> { "Child", "Group", "Parent", "Single" };
            var picker2 = new SelectionPickerModel(position2);

            selectionTypePicker.Model = picker2;
            selectionTypePicker.SelectedRowInComponent(0);
            selectionTypePicker.Frame = new CGRect(140, 70, 150, 40);

            picker2.ValueChanged += (sender, e) =>
            {
                if (picker2.SelectedValue == "Child")
                {
                    chart.SelectionSettings.SelectionType = SelectionType.Child;
                }
                else if (picker2.SelectedValue == "Group")
                {
                    chart.SelectionSettings.SelectionType = SelectionType.Group;
                }
                else if (picker2.SelectedValue == "Parent")
                {
                    chart.SelectionSettings.SelectionType = SelectionType.Parent;
                }
                else if (picker2.SelectedValue == "Single")
                {
                    chart.SelectionSettings.SelectionType = SelectionType.Single;
                }
            };


            this.option.AddSubview(selectionMode);
            this.option.AddSubview(selectionType);
            this.option.AddSubview(selectionModePicker);
            this.option.AddSubview(selectionTypePicker);
        }
    }

    public class SelectionPickerModel : UIPickerViewModel
    {
        List<string> position;
        public EventHandler ValueChanged;
        public string SelectedValue;

        public SelectionPickerModel(List<string> position)
        {
            this.position = position;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return position.Count;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return position[(int)row]; ;
        }

        public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            UILabel label = new UILabel(new Rectangle(0, 0, 130, 40));
            label.TextColor = UIColor.Black;
            label.Font = UIFont.FromName("Helvetica", 14f);
            label.TextAlignment = UITextAlignment.Center;
            label.Text = position[(int)row];
            return label;
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            var position1 = position[(int)row];
            SelectedValue = position1;
            ValueChanged?.Invoke(null, null);
        }
    }

}
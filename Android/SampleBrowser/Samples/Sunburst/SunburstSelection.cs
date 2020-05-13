#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.SfSunburstChart.Android;

namespace SampleBrowser
{
    [Preserve(AllMembers = true)]
    public class SunburstSelection : SamplePage
    {
        SfSunburstChart chart;
        List<String> adapter;
        List<String> adapter1;
        public ObservableCollection<SunburstModel> Population_Data { get; set; }
        public override View GetSampleContent(Context context)
        {
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

            chart = new SfSunburstChart(context);
            chart.ItemsSource = Population_Data;
            chart.Radius = 0.95;
            chart.ValueMemberPath = "Population";
            var levels = new SunburstLevelCollection()
            {               
                new SunburstHierarchicalLevel() { GroupMemberPath = "Continent"},
                 new SunburstHierarchicalLevel() { GroupMemberPath = "Country"},
                new SunburstHierarchicalLevel() { GroupMemberPath = "State"},
                
            };
            chart.Levels = levels;

            chart.Title.IsVisible = true;
            chart.Title.Margin = new Thickness(10, 5, 5, 5);
            chart.Title.Text = "Population Data";
            chart.Title.TextSize = 20;

            chart.Legend.IsVisible = true;

            chart.DataLabel.ShowLabel = true;

            chart.SelectionSettings.EnableSelection = true;

            return chart;
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            TextView selectionMode = new TextView(context);
            selectionMode.Text = "Selection Mode";
            selectionMode.Typeface = Typeface.DefaultBold;
            selectionMode.SetTextColor(Color.ParseColor("#262626"));
            selectionMode.TextSize = 20;

            Spinner spinSelectionMode = new Spinner(context, SpinnerMode.Dialog);
            adapter = new List<String>() { "Opacity", "Color", "Stroke" };

            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
                   (context, Android.Resource.Layout.SimpleSpinnerItem, adapter);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            spinSelectionMode.Adapter = dataAdapter;
            spinSelectionMode.ItemSelected += SpinMode_ItemSelected;


            TextView selectionType = new TextView(context);
            selectionType.Text = "Selection Type";
            selectionType.Typeface = Typeface.DefaultBold;
            selectionType.SetTextColor(Color.ParseColor("#262626"));
            selectionType.TextSize = 20;

            Spinner spinSelectionType = new Spinner(context, SpinnerMode.Dialog);
            adapter1 = new List<String>() { "Child", "Group", "Parent" , "Single"};

            ArrayAdapter<String> dataAdapter1 = new ArrayAdapter<String>
                   (context, Android.Resource.Layout.SimpleSpinnerItem, adapter1);
            dataAdapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            spinSelectionType.Adapter = dataAdapter1;
            spinSelectionType.ItemSelected += spinSelectionType_ItemSelected;


            LinearLayout optionsPage = new LinearLayout(context);

            optionsPage.Orientation = Orientation.Vertical;
            optionsPage.AddView(selectionMode);
            optionsPage.AddView(spinSelectionMode);
            optionsPage.AddView(selectionType);
            optionsPage.AddView(spinSelectionType);

            optionsPage.SetPadding(10, 10, 10, 10);
            optionsPage.SetBackgroundColor(Color.White);
            return optionsPage;
        }

        private void spinSelectionType_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter1[e.Position];
            if (selectedItem.Equals("Child"))
            {
                chart.SelectionSettings.SelectionType = SelectionType.Child;
            }
            else if (selectedItem.Equals("Group"))
            {
                chart.SelectionSettings.SelectionType = SelectionType.Group;
            }
            else if (selectedItem.Equals("Parent"))
            {
                chart.SelectionSettings.SelectionType = SelectionType.Parent;
            }
            else if (selectedItem.Equals("Single"))
            {
                chart.SelectionSettings.SelectionType = SelectionType.Single;
            }
        }

        private void SpinMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter[e.Position];
            if (selectedItem.Equals("Opacity"))
            {
                chart.SelectionSettings.SelectionDisplayMode = SelectionDisplayMode.HighlightByOpacity;
            }
            else if (selectedItem.Equals("Color"))
            {
                chart.SelectionSettings.SelectionDisplayMode = SelectionDisplayMode.HighlightByColor;
            }
            else if (selectedItem.Equals("Stroke"))
            {
                chart.SelectionSettings.SelectionDisplayMode = SelectionDisplayMode.HighlightByStroke;
            }
        }
    }
}
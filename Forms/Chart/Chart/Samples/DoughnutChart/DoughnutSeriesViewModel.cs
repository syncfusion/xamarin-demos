#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace SampleBrowser.SfChart
{
	public class DoughnutSeriesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ChartDataModel> DoughnutSeriesData { get; set; }

        public DoughnutSeriesViewModel()
        {
            DoughnutSeriesData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Labour", 10),
                new ChartDataModel("Legal", 8),
                new ChartDataModel("Production", 7),
                new ChartDataModel("License", 5),
                new ChartDataModel("Facilities", 10),
                new ChartDataModel("Taxes", 6),
                new ChartDataModel("Insurance", 18)
           };
        }
		private int selectedIndex;
        private string _selectedItemName;
        private double _selectedItemsPercentage;

        public string SelectedItemName
        {
            get { return _selectedItemName; }
            set
            {
                _selectedItemName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItemName"));
            }
        }


        public double SelectedItemsPercentage
        {
            get { return _selectedItemsPercentage; }
            set
            {
                _selectedItemsPercentage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItemsPercentage"));
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                if (selectedIndex == -1) return;

                SelectedItemName = DoughnutSeriesData[selectedIndex].Name;

                var sum = DoughnutSeriesData.Sum(item => item.Value);
                var selectedValue = DoughnutSeriesData[selectedIndex].Value;

                SelectedItemsPercentage = (selectedValue / sum) * 100;
                SelectedItemsPercentage = Math.Floor(SelectedItemsPercentage * 100) / 100;
            }
        }
    }
}
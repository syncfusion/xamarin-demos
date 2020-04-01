#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SampleBrowser.SfChart
{
    public class TrendlineViewModel :INotifyPropertyChanged
    {
        private ObservableCollection<ChartDataModel> dataCollection;
        public ObservableCollection<ChartDataModel> DataCollection
        {
            get { return dataCollection; }
            set
            {
                dataCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DataCollection"));
            }
        }

        private double interval = 10;

        public double Interval
        {
            get { return interval; }
            set
            {
                interval = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Interval"));
            }
        }

        private ObservableCollection<ChartDataModel> linearDataCollection { get; set; }
        private ObservableCollection<ChartDataModel> exponentialDataCollection { get; set; }
        private ObservableCollection<ChartDataModel> logarithmicDataCollection { get; set; }
        private ObservableCollection<ChartDataModel> polynomialDataCollection { get; set; }
        public ObservableCollection<ChartDataModel> PowerDataCollection { get; set; }

        private int selectedIndex = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnIndexChanged(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedIndex"));
            }
        }

        private ChartTrendlineType type = ChartTrendlineType.Linear;

        public ChartTrendlineType TrendlineType
        {
            get { return type; }
            set
            {
                if(type != value)
                {
                    type = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TrendlineType"));
                }
            }
        }

        private bool isVisible = true;

        public bool IsVisible {
            get { return isVisible; }

            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsVisible"));
                }
            }
        }

        private bool isEnable = false;

        public bool IsEnable
        {
            get { return isEnable; }

            set
            {
                if (isEnable != value)
                {
                    isEnable = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEnable"));
                }
            }
        }

        private string label = "Linear";

        public string Label
        {
            get { return label; }

            set
            {
                if (label != value)
                {
                    label = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Label"));
                }
            }
        }

		private void OnIndexChanged(int value)
		{
			IsEnable = false;
			if (value == 0)
			{
				Label = "Linear";
				TrendlineType = ChartTrendlineType.Linear;
				DataCollection = linearDataCollection;
				Interval = 10;
			}
			else if (value == 1)
			{
				Label = "Exponential";
				TrendlineType = ChartTrendlineType.Exponential;
				DataCollection = exponentialDataCollection;
				Interval = 100;
			}
			else if (value == 2)
			{
				Label = "Logarithmic";
				TrendlineType = ChartTrendlineType.Logarithmic;
				DataCollection = logarithmicDataCollection;
				Interval = 50;
			}
			else if (value == 4)
			{
				TrendlineType = ChartTrendlineType.Polynomial;
				Label = "Polynomial";
				DataCollection = polynomialDataCollection;
				IsEnable = true;
				Interval = 50;
			}

			if (value == 3)
			{
				IsVisible = false;
			}
			else
			{
				IsVisible = true;
			}
		}

        public TrendlineViewModel()
        {
            PowerDataCollection = new ObservableCollection<ChartDataModel>();
            var date = new DateTime(2019, 03, 01);
            int x = 20;
            linearDataCollection = new ObservableCollection<ChartDataModel>();
            exponentialDataCollection = new ObservableCollection<ChartDataModel>();
            for (int i = 0; i < 8; i++)
            {
                linearDataCollection.Add(new ChartDataModel(date, x));
                x += 5;
                date = date.AddMonths(1);
            }

            date = new DateTime(2019, 03, 01);
            x = 250;
            for (int i = 0; i < 8; i++)
            {
                exponentialDataCollection.Add(new ChartDataModel(date, x));
                x += 50;
                date = date.AddMonths(1);
            }

            date = new DateTime(2019, 03, 30);
            logarithmicDataCollection = new ObservableCollection<ChartDataModel>()
            {
                new ChartDataModel(date, 98),
                new ChartDataModel(date.AddMonths(1),110),
                new ChartDataModel(date.AddMonths(2),200),
                new ChartDataModel(date.AddMonths(3),250),
                new ChartDataModel(date.AddMonths(4),289),
                new ChartDataModel(date.AddMonths(5),300),
                new ChartDataModel(date.AddMonths(6),310),
                new ChartDataModel(date.AddMonths(7),330),
            };

			date = new DateTime(2019, 3, 01);
            polynomialDataCollection = new ObservableCollection<ChartDataModel>()
			{
				new ChartDataModel(date, 55),
				new ChartDataModel(date.AddMonths(1), 135),
				new ChartDataModel(date.AddMonths(2),128),
				new ChartDataModel(date.AddMonths(3),120),
				new ChartDataModel(date.AddMonths(4),135),
				new ChartDataModel(date.AddMonths(5),98),
				new ChartDataModel(date.AddMonths(6),120),
				new ChartDataModel(date.AddMonths(7),85),
			};

            DataCollection = linearDataCollection;
            PowerDataCollection.Add(new ChartDataModel(1, 10));
            PowerDataCollection.Add(new ChartDataModel(2, 50));
            PowerDataCollection.Add(new ChartDataModel(3, 80));
            PowerDataCollection.Add(new ChartDataModel(4, 110));
            PowerDataCollection.Add(new ChartDataModel(5, 180));
            PowerDataCollection.Add(new ChartDataModel(6, 220));
            PowerDataCollection.Add(new ChartDataModel(7, 300));
            PowerDataCollection.Add(new ChartDataModel(8, 370));
        }
    }
}

#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
    public class MultipleCircleViewModel
    {
        public ObservableCollection<MultipleCircleModel> DoughnutSeriesData { get; set; }

        public MultipleCircleViewModel()
        {
            DoughnutSeriesData = new ObservableCollection<MultipleCircleModel>
            {
                new MultipleCircleModel("Vehicle", 62.7,"ToyCar.png"),
				new MultipleCircleModel("Education",29.5,"Chart_Book.png"),
                new MultipleCircleModel("Home", 85.2, "HouseIcon.png"),
                new MultipleCircleModel("Personal", 45.6,"Savings.png")
            };
        }

    }

    public class MultipleCircleModel
    {
        public string XValue
        {
            get;
            set;
        }

        public double YValue
        {
            get;
            set;
        }

        public string Image
        {
            get;
            set;
        }

        public MultipleCircleModel(string xValue, double yValue, string image)
        {
            XValue = xValue;
            YValue = yValue;
            Image = image;
        }
    }
}
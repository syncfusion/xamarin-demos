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
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{

    public class LegendViewModel
    {

        List<Color> colors;

        private List<Color> GetPieColors()
        {
            if (colors == null)
            {
                colors = new List<Color>(10)
                {
                    
                    Color.FromRgba(0, 189, 174, 255),
                    Color.FromRgba(64, 64, 65, 255),
                    Color.FromRgba(53, 124, 210, 255),
                    Color.FromRgba(229, 101, 144, 255),
                    Color.FromRgba(248, 184, 131, 255),
                    Color.FromRgba(112, 173, 71, 255),
                    Color.FromRgba(221, 138, 189, 255),
                    Color.FromRgba(127, 132, 232, 255),
                    Color.FromRgba(123, 180, 235, 255),
                    Color.FromRgba(234, 122, 87, 255)
                };
            }
            return colors;
        }

        public ObservableCollection<Model> Data
        {
            get;
            set;
        }

        int previousExplodeIndex = -1;

        int explodeIndex = 5;

        public int ExplodeIndex
        {
            get
            {
                return explodeIndex;
            }

            set
            {
                explodeIndex = value;
                if (previousExplodeIndex != -1)
                {
                    Data[previousExplodeIndex].IsExploded = false;
                    Data[previousExplodeIndex].LegendBackgroundColor = Color.Transparent;
                }
                if (explodeIndex != -1)
                {
                    Data[explodeIndex].IsExploded = true;
                    Data[explodeIndex].LegendBackgroundColor = GetPieColors()[explodeIndex].MultiplyAlpha(0.4);
                }
                previousExplodeIndex = explodeIndex;
            }
        }

        public LegendViewModel()
        {
            Data = new ObservableCollection<Model>
            {
                new Model("Labour", 28),
                new Model("Legal", 10),
                new Model("Production", 20),
                new Model("License", 15),
                new Model("Facilities", 23),
                new Model("Taxes", 17),
                new Model("Insurance", 12)
           };
        }
    }

    public class Model : INotifyPropertyChanged
    {
        Color legendBackgroundColor;

        public Color LegendBackgroundColor
        {
            get
            {
                return legendBackgroundColor;
            }

            set
            {
                legendBackgroundColor = value;
                OnPropertyChanged("LegendBackgroundColor");
            }
        }

        public string Name
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }
        bool isExploded;

        public bool IsExploded
        {
            get
            {
                return isExploded;
            }

            set
            {
                isExploded = value;
                OnPropertyChanged("IsExploded");
            }
        }

        public Model(String name, double value)
        {
            Name = name;
            Value = value;
        }

        void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.Border;
using Syncfusion.XForms.Shimmer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleBrowser.SfShimmer
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int waveWidth = 200;

        private Color waveColor = Color.FromHex("#D1D1D1");

        private Color shimmerColor = Color.FromHex("#EBEBEB");

        private int duration = 1000;

        public int WaveWidth
        {
            get { return waveWidth; }
            set
            {
                waveWidth = value;
                RaisePropertyChanged("WaveWidth");
            }
        }

        public int Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                RaisePropertyChanged("Duration");
            }
        }

        public Color WaveColor
        {
            get { return waveColor; }
            set
            {
                waveColor = value;
                RaisePropertyChanged("WaveColor");
            }
        }

        public Color ShimmerColor
        {
            get { return shimmerColor; }
            set
            {
                shimmerColor = value;
                RaisePropertyChanged("ShimmerColor");
            }
        }

        public ObservableCollection<Color> ShimmerColors { get; set; }

        public List<Color> WaveColors { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Array ShimmerTypes
        {
            get
            {
                return Enum.GetValues(typeof(ShimmerTypes));
            }
        }

        public Array WaveDirectionTypes
        {
            get
            {
                return Enum.GetValues(typeof(WaveDirection));
            }
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public ViewModel()
        {
            ShimmerColors = new ObservableCollection<Color>
            {
                Color.FromHex("#EBEBEB"),
                Color.FromHex("#E7E7F9"),
                Color.FromHex("#E1EFFF"),
                Color.FromHex("#F4E2EE"),
                Color.FromHex("#F6F6DB"),
            };



            WaveColors = new List<Color>
            {
                Color.FromHex("#D1D1D1"),
                Color.FromHex("#CECEEF"),
                Color.FromHex("#B8D4F2"),
                Color.FromHex("#DFBFD5"),
                Color.FromHex("#E7E7B2"),
            };
        }
    }
}
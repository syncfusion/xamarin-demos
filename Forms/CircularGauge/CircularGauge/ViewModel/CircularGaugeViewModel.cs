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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfCircularGauge
{
	[Preserve(AllMembers = true)]
    public class CircularGaugeViewModel : INotifyPropertyChanged
    {
        Random random = new Random();
        private bool canStopTimer;

        public CircularGaugeViewModel()
        {
           
        }

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        #region HeaderText

        private string headerText;

        public string HeaderText
        {
            get { return headerText; }
            set
            {
                headerText = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("HeaderText"));
                }
            }
        }

        #endregion PointerValue

        #region PointerValue

        private double pointerValue;

        public double PointerValue
        {
            get { return pointerValue; }
            set
            {
                pointerValue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("PointerValue"));
                }
            }
        }

        #endregion PointerValue

        #region Scale1_StartAngle

        private double scale1_StartAngle;

        public double Scale1_StartAngle
        {
            get { return scale1_StartAngle; }
            set
            {
                scale1_StartAngle = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Scale1_StartAngle"));
                }
            }
        }

        #endregion Scale1_StartAngle

        #region Scale1_SweepAngle

        private double scale1_SweepAngle;

        public double Scale1_SweepAngle
        {
            get { return scale1_SweepAngle; }
            set
            {
                scale1_SweepAngle = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Scale1_SweepAngle"));
                }
            }
        }

        #endregion Scale1_SweepAngle

        #region Scale2_StartAngle

        private double scale2_StartAngle;

        public double Scale2_StartAngle
        {
            get { return scale2_StartAngle; }
            set
            {
                scale2_StartAngle = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Scale2_StartAngle"));
                }
            }
        }

        #endregion Scale2_StartAngle

        #region Scale2_SweepAngle

        private double scale2_SweepAngle;

        public double Scale2_SweepAngle
        {
            get { return scale2_SweepAngle; }
            set
            {
                scale2_SweepAngle = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Scale2_SweepAngle"));
                }
            }
        }

        #endregion Scale2_SweepAngle

        #region RangePointerColor

        private Color rangePointerColor;

        public Color RangePointerColor
        {
            get { return rangePointerColor; }
            set
            {
                rangePointerColor = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("RangePointerColor"));
                }
            }
        }

        #endregion RangePointerColor

        #region NeedlePointerColor

        private Color needlePointerColor;

        public Color NeedlePointerColor
        {
            get { return needlePointerColor; }
            set
            {
                needlePointerColor = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("NeedlePointerColor"));
                }
            }
        }

        #endregion NeedlePointerColor

        #region RangeColor

        private Color rangeColor;

        public Color RangeColor
        {
            get { return rangeColor; }
            set
            {
                rangeColor = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("RangeColor"));
                }
            }
        }

        #endregion RangeColor


        #endregion Properties

        public async void UpdateLiveData()
        {
            await Task.Delay(200);

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1500), UpdateData);
        }
        private bool UpdateData()
        {
            if (canStopTimer) return false;

            PointerValue = random.Next(35, 100);
            return true;
        }
        public void StopTimer()
        {
            canStopTimer = true;
        }
    }
}

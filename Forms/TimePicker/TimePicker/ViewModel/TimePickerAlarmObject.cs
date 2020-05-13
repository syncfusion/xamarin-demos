#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SampleBrowser.SfTimePicker
{
    #region TimePickerAlarmObject class

    /// <summary>
    /// 
    /// </summary>
    public class TimePickerAlarmObject : INotifyPropertyChanged
    {
        #region Members

        /// <summary>
        /// Update based on selected time 
        /// </summary>
        private TimeSpan timeValue;

        /// <summary>
        /// Indicates switch is ON/OFF 
        /// </summary>
        private bool isOn;

        /// <summary>
        /// TimeDiffernce field
        /// </summary>
        private TimeSpan? timeDifference;

        #endregion

        #region Properties

        /// <summary>
        /// Update based on Picker Selected Time
        /// </summary>
        public TimeSpan TimeValue
        {
            get
            {
                return timeValue;
            }
            set
            {
                timeValue = value;
                CalculateTimeDifference(IsOn);
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// To indicate whether the Switch is ON/OFF
        /// </summary>
        public bool IsOn
        {
            get
            {
                return isOn;
            }
            set
            {
                isOn = value;
                CalculateTimeDifference(isOn);
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Time difference based on selected time
        /// </summary>
        public TimeSpan? TimeDifference
        {
            get
            {
                return timeDifference;
            }
            set
            {
                timeDifference = value;
                this.NotifyPropertyChanged();
            }
        }


        #endregion

        #region NotifyPropertyChanged
        /// <summary>
        /// Property changed event handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify when the property is changed 
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Calculate the time difference
        /// </summary>
        /// <param name="switchOn"></param>
        private void CalculateTimeDifference(bool switchOn)
        {
            if (switchOn)
            {
                DateTime dateTimeValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                dateTimeValue = dateTimeValue.AddTicks(this.TimeValue.Ticks);

                if (dateTimeValue <= DateTime.Now)
                {
                    dateTimeValue = dateTimeValue.AddDays(1);
                }

                DateTime dateTime = DateTime.Now;
                dateTime = dateTime.AddSeconds(-dateTime.Second);

                this.TimeDifference = dateTime.Subtract(dateTimeValue);
            }
            else
                this.TimeDifference = null;
        }

        #endregion

    }

    #endregion
}

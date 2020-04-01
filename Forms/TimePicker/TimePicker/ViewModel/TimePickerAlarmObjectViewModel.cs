#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.Pickers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleBrowser.SfTimePicker
{
    #region TimePickerAlarmObjectViewModel class

    /// <summary>
    /// TimePicker AlarmObject ViewModel class
    /// </summary>
    public class TimePickerAlarmObjectViewModel : INotifyPropertyChanged
    {
        #region Members

        /// <summary>
        /// Alarm object collection field
        /// </summary>
        private ObservableCollection<TimePickerAlarmObject> alarms = new ObservableCollection<TimePickerAlarmObject>();

        /// <summary>
        /// Selected Item field
        /// </summary>
        private TimePickerAlarmObject selectedItem;

        /// <summary>
        /// Indicates Picker is open or closed.
        /// </summary>
        private bool isPickerOpen;

        /// <summary>
        /// Update based on picker SelectedTime
        /// </summary>
        private TimeSpan selectedTime;

        /// <summary>
        /// Update current time field
        /// </summary>
        private string time;

        /// <summary>
        /// Update current time field
        /// </summary>
        private string meridian;

        /// <summary>
        /// Indicates column header is shown or not
        /// </summary>
        private bool showColumnHeader = true;

        /// <summary>
        /// Indicates header is shown or not
        /// </summary>
        private bool showHeader = true;

        /// <summary>
        /// TimeFormat collection field
        /// </summary>
        private ObservableCollection<TimeFormat> timeFormatcollections;

        /// <summary>
        /// Update header text
        /// </summary>
        private string headerText = "Time Picker";

        /// <summary>
        /// Selected Time Fomrat
        /// </summary>
        private TimeFormat selectedTimeFomrat;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value to show the column header
        /// </summary>
        public bool ShowColumnHeader
        {
            get
            {
                return showColumnHeader;
            }
            set
            {
                showColumnHeader = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value for the SelectedTimeFomrat
        /// </summary>
        public TimeFormat SelectedTimeFomrat
        {
            get
            {
                return selectedTimeFomrat;
            }
            set
            {
                selectedTimeFomrat = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value to show the header
        /// </summary>
        public bool ShowHeader
        {
            get
            {
                return showHeader;
            }
            set
            {
                showHeader = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the header text
        /// </summary>
        public string HeaderText
        {
            get
            {
                return headerText;
            }
            set
            {
                headerText = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the time format collection
        /// </summary>
        public ObservableCollection<TimeFormat> TimeFormatcollections
        {
            get
            {
                return timeFormatcollections;
            }
            set
            {
                timeFormatcollections = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Collection of Alarm object to listview itemsource 
        /// </summary>
        public ObservableCollection<TimePickerAlarmObject> Alarms
        {
            get
            {
                return alarms;
            }
            set
            {
                alarms = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Selected item of listview
        /// </summary>
        public TimePickerAlarmObject SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;

                if(value !=null)
                {
                    this.SelectedTime = value.TimeValue;
                    this.IsPickerOpen = true;
                }

                this.NotifyPropertyChanged();
            }

        }

        /// <summary>
        /// Update based on TimePicker SelectedTime 
        /// </summary>
        public TimeSpan SelectedTime
        {
            get
            {
                return selectedTime;
            }
            set
            {
                
                selectedTime = value;

                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// To indicate picker is open or closed
        /// </summary>
        public bool IsPickerOpen
        {
            get
            {
                return isPickerOpen;
            }
            set
            {
                isPickerOpen = value;

                if (!value)
                    this.SelectedItem = null;

                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// To update the current time
        /// </summary>
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// To get set the Meridian
        /// </summary>
        public string Meridian
        {
            get
            {
                return meridian;
            }
            set
            {
                meridian = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Add commamd field
        /// </summary>
        private ICommand addCommand;

        /// <summary>
        /// Gets or sets the value of the command.
        /// </summary>
        public ICommand AddCommand
        {
            get
            {
                return addCommand;
            }
            set
            {
                addCommand = value;
            }
        }

        /// <summary>
        /// Ok commamd field
        /// </summary>
        private ICommand okCommand;

        /// <summary>
        /// Indicates whether the Add button is clicked or not
        /// </summary>
        private bool isAddClicked;

        /// <summary>
        /// Gets or sets the value of the command.
        /// </summary>
        public ICommand OkCommand
        {
            get
            {
                return okCommand;
            }
            set
            {
                okCommand = value;
            }
        }

        /// <summary>
        /// Cancel commamd field
        /// </summary>
        private ICommand cancelCommand;

        /// <summary>
        /// Gets or sets the value of the command.
        /// </summary>
        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand;
            }
            set
            {
                cancelCommand = value;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TimePickerAlarmObjectViewModel"/> class.
        /// </summary>
        public TimePickerAlarmObjectViewModel()
        {
            this.GetDefaultAlarms();
            this.AddCommand = new Command(AddNewAlarmItem);
            this.OkCommand = new Command(AddOkCommand);
            this.CancelCommand = new Command(AddCancelCommand);
            this.SetCurrentTime();
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

        #endregion

        #region Methods

        /// <summary>
        /// Set collection of TimePickerAlarmObject for listview
        /// </summary>
        public void GetDefaultAlarms()
        {
            this.Alarms.Add(new TimePickerAlarmObject() { IsOn = false, TimeValue = new TimeSpan(3, 15, 00) });
            this.Alarms.Add(new TimePickerAlarmObject() { IsOn = true, TimeValue = new TimeSpan(3, 45, 00) });
            this.Alarms.Add(new TimePickerAlarmObject() { IsOn = false, TimeValue = new TimeSpan(4, 10, 00) });
            this.Alarms.Add(new TimePickerAlarmObject() { IsOn = true, TimeValue = new TimeSpan(4, 30, 00) });
            this.Alarms.Add(new TimePickerAlarmObject() { IsOn = false, TimeValue = new TimeSpan(6, 15, 00) });

            this.TimeFormatcollections = new ObservableCollection<TimeFormat>()
            {
                TimeFormat.HH_mm,
                TimeFormat.HH_mm_ss,
                TimeFormat.hh_mm_ss_tt,
                TimeFormat.hh_mm_tt,
                TimeFormat.H_mm,
                TimeFormat.H_mm_ss,
                TimeFormat.h_mm_ss_tt,
                TimeFormat.h_mm_tt
            };

            this.SelectedTimeFomrat = this.TimeFormatcollections[1];
        }

        /// <summary>
        /// Add new Alarm item when selecting  Add icon.
        /// </summary>
        public void AddNewAlarmItem()
        {
            this.SelectedTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
            this.IsPickerOpen = true;
            isAddClicked = true;
        }

        /// <summary>
        /// Add ok command method.
        /// </summary>
        public void AddOkCommand()
        {
            if(SelectedItem!=null)
            SelectedItem.IsOn = true;
            if (this.SelectedItem != null && this.SelectedTime != null)
            {
                this.SelectedItem.TimeValue = this.SelectedTime;
            }
                if (isAddClicked)
            {
                this.SetAlarmValue();
                isAddClicked = false;
            }
        }

        /// <summary>
        /// Add cancel command method.
        /// </summary>
        public void AddCancelCommand()
        {
            isAddClicked = false;
        }
        /// <summary>
        /// Add new items when ok button clicked.
        /// </summary>
        public void SetAlarmValue()
        {
            this.Alarms.Add(new TimePickerAlarmObject() { TimeValue = this.SelectedTime, IsOn = true});
        }

        /// <summary>
        /// Update current time
        /// </summary>
        public async void SetCurrentTime()
        {
            while (true)
            {
                await Task.Delay(200);
                this.Time = DateTime.Now.ToString("h:mm").ToUpper();
                this.Meridian = DateTime.Now.ToString("tt").ToUpper();
            }
        }

        #endregion

    }

    #endregion

    #region TimePickerTimeSpanToTextConverter class

    public class TimePickerTimeSpanToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string format;
            string hourValue = (value).ToString().Substring(0,2);
            string minuteValue = (value).ToString().Substring(3, 2);
            string formatedText = (value).ToString().Remove(5);
            int val = int.Parse(hourValue);
            if (val >= 12)
            {
                if (val > 12)
                    hourValue = (int.Parse(hourValue) - 12).ToString();
                format = hourValue + ":" + minuteValue + " PM";
            }
            else
            {
                format = formatedText.ToString() + " AM";
            }

            return format;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region TimePickerBoolToColor class
    public class TimePickerBoolToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Color.Accent;
            else
                return Color.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region TimePickerBoolToText class
    public class TimePickerBoolToText : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "Off";

            TimeSpan diffTimeSpan = (TimeSpan)value;
            return this.GetTimeString(diffTimeSpan.Hours, diffTimeSpan.Minutes, diffTimeSpan.Seconds);
        }

        public string GetTimeString(int hour, int minute, int second)
        {
            if (hour < 0)
                hour = -hour;
            if (minute < 0)
                minute = -minute;
            if (second < 0)
                second = -second;

            string textValue = "Alarm in ";
            if (hour <= 0)
            {

                if (minute > 1)
                {
                    textValue += minute.ToString() + " Minutes";
                }
                else if (minute == 1)
                {
                    textValue += "1 Minute";
                }

                if (second > 1)
                {
                    textValue += second.ToString() + " Seconds";
                }
                else
                {
                    textValue += second.ToString() + " Second";
                }
            }
            else
            {
                if (hour == 1)
                {
                    textValue += "1 Hour ";
                }
                else
                {
                    textValue += hour.ToString() + " Hours ";
                }

                if(minute>1)
                {
                    textValue += minute.ToString() + " Minutes";
                }
                else
                {
                    textValue += minute.ToString() + " Minute";
                }
            }

            return textValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}

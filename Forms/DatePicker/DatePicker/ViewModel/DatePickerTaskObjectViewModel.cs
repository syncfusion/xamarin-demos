#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.Pickers;
using Syncfusion.XForms.PopupLayout;
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

namespace SampleBrowser.SfDatePicker
{
    #region DatePickerTaskObjectViewModel class

    /// <summary>
    /// DatePickerTaskObjectViewModel class
    /// </summary>
    public class DatePickerTaskObjectViewModel : INotifyPropertyChanged
    {
        #region Members

        /// <summary>
        ///  Tasks collections 
        /// </summary>
        private ObservableCollection<DatePickerTaskObject> tasks = new ObservableCollection<DatePickerTaskObject>();

        /// <summary>
        /// SelectedItem value
        /// </summary>
        private DatePickerTaskObject selectedItem;

        /// <summary>
        /// To check whether the Picker is Open or not. 
        /// </summary>
        private bool isPickerOpen;

        /// <summary>
        /// To check whether the  xamarin picker is Open or not. 
        /// </summary>
        private bool isOpen;

        /// <summary>
        /// isOkClicked
        /// </summary>
        private bool isOkClicked;

        /// <summary>
        /// selectedDate
        /// </summary>
        private DateTime selectedDate = DateTime.Now;

        /// <summary>
        /// Text value
        /// </summary>
        private string text;


        /// <summary>
        /// Default header text value
        /// </summary>
        private string headertext = "Date Picker";

        /// <summary>
        /// show Column Header
        /// </summary>
        private bool showColumnHeader = true;

        /// <summary>
        /// showHeader
        /// </summary>
        private bool showHeader = true;

        /// <summary>
        /// selected DateFormat
        /// </summary>
        private DateFormat selectedDateFormat;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value for the SelectedDateFormat
        /// </summary>
        public DateFormat SelectedDateFormat
        {
            get {
                return selectedDateFormat;
            }
            set
            {
                selectedDateFormat = value;
                this.NotifyPropertyChanged();
            }
        }


        /// <summary>
        /// Gets or sets the value for the SelectedDateFormat
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
        /// Gets or sets the value for the SelectedDateFormat
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
        /// Gets or sets the value for the SelectedDateFormat
        /// </summary>
        public ObservableCollection<DatePickerTaskObject> Tasks
        {
            get
            {
                return tasks;
            }
            set
            {
                tasks = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value for the SelectedDateFormat
        /// </summary>
        public ObservableCollection<DateFormat> DateFormatcollections
        {
            get
            {
                return dateFormatcollections;
            }
            set
            {
                dateFormatcollections = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value for the SelectedDateFormat
        /// </summary>
        public string DateFormat
        {
            get
            {
                return dateFormat;
            }
            set
            {
                dateFormat = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value for the SelectedDateFormat
        /// </summary>
        public DatePickerTaskObject SelectedItem
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
                    this.SelectedDate = value.DateValue;
                    this.IsPickerOpen = true;
                }

                this.NotifyPropertyChanged();
            }

        }

        /// <summary>
        /// Gets or sets the value for the SelectedDateFormat
        /// </summary>
        public DateTime SelectedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                selectedDate = value;

                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value for the SelectedDateFormat
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
        /// Gets or sets the value for the SelectedDateFormat
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
            set
            {
                isOpen = value;

              
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value for the SelectedDateFormat
        /// </summary>
        public bool IsOkClicked
        {
            get
            {
                return isOkClicked;
            }
            set
            {
                isOkClicked = value;


                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value for the SelectedDateFormat
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value for the SelectedDateFormat
        /// </summary>
        public string HeaderText
        {
            get
            {
                return headertext;
            }
            set
            {
                headertext = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Add command value
        /// </summary>
        private ICommand addCommand;

        /// <summary>
        /// AddCommand Command
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
        /// ok command
        /// </summary>
        private ICommand okCommand;

        /// <summary>
        /// Gets or set the value for the Ok command
        /// </summary>
        public ICommand OKCommand
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
        /// Cancel command
        /// </summary>
        private ICommand cancelCommand;

        /// <summary>
        /// Gets or sets the value for the Cancel command
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

        /// <summary>
        /// Accept Command
        /// </summary>
        private ICommand acceptCommand;

        /// <summary>
        /// Gets or sets the value for the AcceptCommand
        /// </summary>
        public ICommand AcceptCommand
        {
            get
            {
                return acceptCommand;
            }
            set
            {
                acceptCommand = value;
            }
        }

        /// <summary>
        /// decline command
        /// </summary>
        private ICommand declineCommand;

        /// <summary>
        ///  Gets or sets the value for the date format collections
        /// </summary>
        private ObservableCollection<DateFormat> dateFormatcollections;

        /// <summary>
        /// dated formart
        /// </summary>
        private string dateFormat;

        /// <summary>
        /// Gets or sets the value for the Decline command
        /// </summary>
        public ICommand DeclineCommand
        {
            get
            {
                return declineCommand;
            }
            set
            {
                declineCommand = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// DatePickerTaskObjectViewModel
        /// </summary>
        public DatePickerTaskObjectViewModel()
        {
            this.GetDefaultTasks();
            this.AddCommand = new Command(AddNewTask);
            this.OKCommand = new Command(AddItems);
            this.CancelCommand = new Command(Cancel);
            this.AcceptCommand = new Command(Accept);
            this.DeclineCommand = new Command(Decline);
        }

        #endregion

        #region NotifyPropertyChanged

        /// <summary>
        /// PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// NotifyPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Methods

        /// <summary>
        /// GetDefaultTasks
        /// </summary>
        public void GetDefaultTasks()
        {
            this.Tasks.Add(new DatePickerTaskObject() { Description = "Get quote from travel agent", DateValue = DateTime.Now });
            this.Tasks.Add(new DatePickerTaskObject() { Description = "Book flight ticket", DateValue = DateTime.Now.AddDays(2) });
            this.Tasks.Add(new DatePickerTaskObject() { Description = "Buy travel guide book", DateValue= DateTime.Now });
            this.Tasks.Add(new DatePickerTaskObject() { Description = "Register for sky diving", DateValue = DateTime.Now.AddDays(9) });

            this.DateFormatcollections = new ObservableCollection<DateFormat>()
            {
                Syncfusion.XForms.Pickers.DateFormat.dd_MMM_yyyy,
                Syncfusion.XForms.Pickers.DateFormat.MM_dd_yyyy,
                Syncfusion.XForms.Pickers.DateFormat.M_d_yyyy,
                Syncfusion.XForms.Pickers.DateFormat.yyyy_MM_dd,
            };

            this.SelectedDateFormat = DateFormatcollections[2];
        }

        /// <summary>
        /// AddNewTask
        /// </summary>
        public void AddNewTask()
        {
            Text = "";
            IsOpen = true;
          
        }
        /// <summary>
        /// AddItems
        /// </summary>
        public void AddItems()
        {
            this.SetTaskValue();
            IsOpen = false;
        }

        /// <summary>
        /// Cancel
        /// </summary>
        public void Cancel()
        {
            IsOpen = false;
        }

        /// <summary>
        /// Accept
        /// </summary>
        public void Accept()
        {
            IsOkClicked = true;

            if (this.SelectedItem != null && this.SelectedDate != null)
            {
                this.SelectedItem.DateValue = this.SelectedDate;
            }
        }

        /// <summary>
        /// Decline
        /// </summary>
        public void Decline()
        {
            IsOkClicked = false;
        }

        /// <summary>
        /// SetTaskValue
        /// </summary>
        public void SetTaskValue()
        {
            if(string.IsNullOrEmpty(Text))
            {
                Text = "New Appointment";
            }
           
            this.Tasks.Add(new DatePickerTaskObject() { DateValue = this.SelectedDate,Description=Text});
        }

        #endregion

    }

    #endregion

    #region DatePickerDateToTextConverter class

    /// <summary>
    /// DatePickerDateToTextConverter
    /// </summary>
    public class DatePickerDateToTextConverter : IValueConverter
    {
        /// <summary>
        /// Convert method
        /// </summary>
        /// <param name="value"> object value</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">parameter value</param>
        /// <param name="culture">culture </param>
        /// <returns>return string</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((DateTime)value).ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                return "Due today";
            }
            else
                return ((DateTime)value).ToString("d");
        }

        /// <summary>
        /// Convert Back method
        /// </summary>
        /// <param name="value"> object value</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">parameter value</param>
        /// <param name="culture">culture </param>
        /// <returns>null</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "Due today")
            {
                return DateTime.Now;
            }
            else
            {
                DateTime oDate = DateTime.Parse((string)value);
                return oDate;
            }
        }
    }

    #endregion

    #region DatePickerBoolToColor class

    /// <summary>
    /// DatePickerBoolToColor
    /// </summary>
    public class DatePickerBoolToColor : IValueConverter
    {
        /// <summary>
        /// Convert method
        /// </summary>
        /// <param name="value"> object value</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">parameter value</param>
        /// <param name="culture">culture </param>
        /// <returns>return clolor</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Color.Accent;
            else
                return Color.Gray;
        }

        /// <summary>
        /// Convert back method
        /// </summary>
        /// <param name="value"> object value</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">parameter value</param>
        /// <param name="culture">culture </param>
        /// <returns>null</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region DatePickerTextToColor class

    /// <summary>
    /// DatePickerTextToColor class
    /// </summary>
    public class DatePickerTextToColor : IValueConverter
    {
        /// <summary>
        /// Convert method
        /// </summary>
        /// <param name="value"> object value</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">parameter value</param>
        /// <param name="culture">culture </param>
        /// <returns>return color</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((DateTime)value).ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                return Color.Accent;
            }
            else
            {
                return Color.Default;
            }
        }

        /// <summary>
        /// Convert Back method
        /// </summary>
        /// <param name="value"> object value</param>
        /// <param name="targetType">target type</param>
        /// <param name="parameter">parameter value</param>
        /// <param name="culture">culture </param>
        /// <returns>null</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}

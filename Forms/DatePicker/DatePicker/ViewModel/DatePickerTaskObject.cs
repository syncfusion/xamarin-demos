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

namespace SampleBrowser.SfDatePicker
{
    #region DatePickerTaskObject class

    /// <summary>
    ///  DatePickerTaskObject Class
    /// </summary>
    public class DatePickerTaskObject : INotifyPropertyChanged
    {
        #region Members

        /// <summary>
        /// date Value 
        /// </summary>
        private DateTime dateValue;

        /// <summary>
        /// description
        /// </summary>
        private string description;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value for the Date Value
        /// </summary>
        public DateTime DateValue
        {
            get
            {
                return dateValue;
            }
            set
            {
                dateValue = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value for the Description
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                this.NotifyPropertyChanged();
            }
        }


        #endregion

        #region NotifyPropertyChanged

        /// <summary>
        /// Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify Property Changed  method
        /// </summary>
        /// <param name="propertyName">string value</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }

    #endregion
}

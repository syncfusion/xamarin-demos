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
using System.Text;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDataForm
{
    [Preserve(AllMembers = true)]
    public class ThemesViewModel: INotifyPropertyChanged
    {

        /// <summary>
        /// The employee info.
        /// </summary>
        private EmployeeInfo employeeInfo;

        public ThemesViewModel()
        {
            this.employeeInfo = new EmployeeInfo();
        }

        /// <summary>
        /// Gets or sets the recipient information.
        /// </summary>
        public EmployeeInfo EmployeeInfo
        {
            get { return this.employeeInfo; }
            set { this.employeeInfo = value; }
        }

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when property value changes.
        /// </summary>
        /// <param name="propertyName">The corresponding name of the property.</param>
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

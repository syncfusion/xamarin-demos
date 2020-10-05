#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfDatePicker
{
    /// <summary>
    /// Date Picker Customization class
    /// </summary>
    public partial class DatePickerCustomization : SampleView
    {
        /// <summary>
        /// DatePickerCustomization
        /// </summary>
        public DatePickerCustomization()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                CustomizePicker.BackgroundColor = Color.FromHex("#FAFAFA");
 				CustomizePicker.ColumnHeaderBackgroundColor = Color.FromHex("#FAFAFA");
                CustomizePicker.HeaderBackgroundColor = Color.FromHex("#FAFAFA");
            }
        }
    }
}
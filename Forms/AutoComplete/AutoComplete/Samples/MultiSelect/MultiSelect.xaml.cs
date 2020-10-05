#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SampleBrowser.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SampleBrowser.SfAutoComplete
{
    public partial class MultiSelect : SampleView
    {
        public MultiSelect()
        {
            InitializeComponent();

            this.BindingContext = new MultiSelectViewModel();
        }
    }
        public class StringToColorConverter : IValueConverter
        {

         object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                   if (value.ToString() == "Blue")
                        return Color.Blue;
                    else if (value.ToString() == "Red")
                        return Color.Red;
                    else if (value.ToString() == "Green")
                        return Color.Green;
                }
            return Color.Blue;
            }

         object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
}


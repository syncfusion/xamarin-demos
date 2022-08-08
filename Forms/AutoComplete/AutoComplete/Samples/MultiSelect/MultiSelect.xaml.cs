#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
        bool closeDropdownOnSelection;
        public MultiSelect()
        {
            InitializeComponent();

            this.BindingContext = new MultiSelectViewModel();
        }

        private void autocomplete_DropDownClosing(object sender, Syncfusion.SfAutoComplete.XForms.DropDownCancelEventArgs e)
        {
            if (!closeDropdownOnSelection)
            {
                if (e.IsItemSelected)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void closeDropdownOnSelection_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                closeDropdownOnSelection = true;
            }
            else
            {
                closeDropdownOnSelection = false;
            }
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


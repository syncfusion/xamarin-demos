#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace SampleBrowser.SfNumericTextBox
{
    public partial class NumericTextBox : SampleView
    {

        public NumericTextBox()
        {
            InitializeComponent();

            if (Device.Idiom == TargetIdiom.Phone || Device.OS == TargetPlatform.Windows)
            {
                NumericTextBox_Default autocomplete = new NumericTextBox_Default();
                this.Content = autocomplete.getContent();
                this.PropertyView = autocomplete.getPropertyView();


            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                NumericTextBox_Tablet autocompleteTab = new NumericTextBox_Tablet();
                this.Content = autocompleteTab.getContent();
            }

        }
    }
}





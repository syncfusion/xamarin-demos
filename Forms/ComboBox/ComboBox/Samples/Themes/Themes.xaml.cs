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
using SampleBrowser.Core;
using Syncfusion.XForms.ComboBox;
using Xamarin.Forms;

namespace SampleBrowser.SfComboBox
{
    public partial class Themes : SampleView
    {
        public Themes()
        {
            InitializeComponent();
             List<String> employeeList = new List<String>();
            employeeList.Add("Frank");
            employeeList.Add("James");
            employeeList.Add("Steve");
            employeeList.Add("Lucas");
            employeeList.Add("Mark");
            employeeList.Add("Michael");
            comboBox.ComboBoxSource = employeeList;
        }
    }
}



   
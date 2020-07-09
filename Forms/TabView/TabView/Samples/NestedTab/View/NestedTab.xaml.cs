#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleBrowser.Core;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleBrowser.SfTabView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NestedTab : SampleView
    {


        public NestedTab()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel();
            this.simTab.SelectionIndicatorSettings = new SelectionIndicatorSettings() { Position = SelectionIndicatorPosition.Fill, Color = Color.FromHex("#FF00AFF0") };

            this.ContactTab1.SelectionIndicatorSettings = this.ContactTab2.SelectionIndicatorSettings = this.CallsTab1.SelectionIndicatorSettings = this.CallTab2.SelectionIndicatorSettings = new SelectionIndicatorSettings() { Position = SelectionIndicatorPosition.Top };
            SfTabItem item = new SfTabItem();
            
            //item.Title

        }

    }
}
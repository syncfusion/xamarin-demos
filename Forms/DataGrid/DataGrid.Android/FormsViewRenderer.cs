#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using SampleBrowser.SfDataGrid;
using SampleBrowser.SfDataGrid.Droid;

[assembly: ExportRenderer(typeof(FormsView), typeof(FormsViewRenderer))]
namespace SampleBrowser.SfDataGrid.Droid
{
    internal class FormsViewRenderer : ViewRenderer
    {
        public FormsView FormsView
        {
            get { return this.Element as FormsView; }
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Visibility")
            {
                if (this.FormsView.Visibility)
                    this.Visibility = ViewStates.Visible;
                else
                    this.Visibility = ViewStates.Invisible;
            }
        }
    }
}
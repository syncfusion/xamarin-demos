#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "FormsViewRenderer.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
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
using SampleBrowser.SfDataGrid;
using SampleBrowser.SfDataGrid.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FormsView), typeof(FormsViewRenderer))]

namespace SampleBrowser.SfDataGrid.Droid
{
    /// <summary>
    ///  A custom View renderer for Android platform
    /// </summary>
    internal class FormsViewRenderer : ViewRenderer
    {
        /// <summary>
        /// Gets the value of PCL View
        /// </summary>
        public FormsView FormsView
        {
            get { return this.Element as FormsView; }
        }

        /// <summary>
        /// Called while Element has changed in View
        /// </summary>
        /// <param name="sender">OnElementPropertyChanged sender</param>
        /// <param name="e">Element Changed Event of View args e</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Visibility")
            {
                if (this.FormsView.Visibility)
                {
                    this.Visibility = ViewStates.Visible;
                }                   
                else
                {
                    this.Visibility = ViewStates.Invisible;
                }              
            }
        }
    }
}
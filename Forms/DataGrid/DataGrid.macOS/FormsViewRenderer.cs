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
using System.Text;
using Foundation;

using SampleBrowser.SfDataGrid;
using SampleBrowser.SfDataGrid.MacOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: Preserve]
[assembly: ExportRenderer(typeof(FormsView), typeof(FormsViewRenderer))]

namespace SampleBrowser.SfDataGrid.MacOS
{
    /// <summary>
    /// A custom View renderer for MAC OS platform
    /// </summary>
    internal class FormsViewRenderer : ViewRenderer
    {
        /// <summary>
        /// Gets the value of the PCL View
        /// </summary>
        public FormsView FormsView
        {
            get { return this.Element as FormsView; }
        }

        /// <summary>
        /// Called while Element has changed in View
        /// </summary>
        /// <param name="e">Element Changed Event of View args e</param>
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            if (e.NewElement != null)
            {
                this.WantsLayer = true;
                this.Layer.BackgroundColor = this.FormsView.BackgroundColor.ToCGColor();
            }

            base.OnElementChanged(e);
        }

        /// <summary>
        /// Called while Elements property has changed in View
        /// </summary>
        /// <param name="sender">Indicates sender of the event</param>
        /// <param name="e">Indicates PropertyChangedEvent args e</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Visibility")
            {
                if (this.FormsView.Visibility)
                {
                    this.Hidden = false;
                }
                else
                {
                    this.Hidden = true;
                }
            }
        }
    }
}

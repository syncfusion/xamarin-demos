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
using SampleBrowser.SfDataGrid;
using SampleBrowser.SfDataGrid.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FormsView), typeof(FormsViewRenderer))]

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]

namespace SampleBrowser.SfDataGrid.iOS
{
    /// <summary>
    ///  A custom View renderer for IOS platform
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
                this.BackgroundColor = this.Element.BackgroundColor.ToUIColor();
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
                    if (this.Control != null)
                    {
                        this.Control.Hidden = false;
                    }                      
                }
                else
                {
                    this.Hidden = true;
                    if (this.Control != null)
                    {
                        this.Control.Hidden = true;
                    }                      
                }
            }
        }
    }
}

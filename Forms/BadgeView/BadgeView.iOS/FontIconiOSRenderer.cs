#region Copyright Syncfusion Inc. 2001-2019.
// ------------------------------------------------------------------------------------
// <copyright file = "FontIconiOSRenderer.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
[assembly: Xamarin.Forms.ExportRenderer(typeof(SampleBrowser.SfBadgeView.FontIconLabel), typeof(SampleBrowser.SfBadgeView.FontIconiOSRenderer))]
namespace SampleBrowser.SfBadgeView
{
    using System;
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;

    /// <summary>
    /// Font Icon Renderer class
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed.")]
    public class FontIconiOSRenderer : LabelRenderer
    {
        public FontIconiOSRenderer()
        {
        }

        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">event args</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {

            base.OnElementChanged(e);
            double? fs = e.NewElement?.FontSize;
            if (fs == null)
            {
                return;
            }

            UIFont font = UIFont.FromName("FONT Sf Badge view", (int)fs);
            Control.Font = font;
        }

        /// <summary>
        /// Ons the element property changed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">event args</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals("Text"))
            {
                Label label = sender as Label;
                UIFont font = UIFont.FromName("FONT Sf Badge view", (int)label.FontSize);
                Control.Font = font;
            }
        }
    }
}
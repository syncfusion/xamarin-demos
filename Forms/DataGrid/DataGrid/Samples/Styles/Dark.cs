#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "Dark.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using Syncfusion.SfDataGrid;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// Derived from DataGridStyle to add the custom styles
    /// </summary>
    public class Dark : DataGridStyle
    {
        /// <summary>
        /// Initializes a new instance of the Dark class.
        /// </summary>
        public Dark()
        {
        }

        /// <summary>
        /// Overrides this method to write a custom style for header back ground color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromRgb(33, 33, 33);
        }

        /// <summary>
        /// Overrides this method to write a custom style for header foreground color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetHeaderForegroundColor()
        {
            return Color.FromRgb(255, 255, 255);
        }

        /// <summary>
        /// Overrides this method to write a custom style for record background color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetRecordBackgroundColor()
        {
            return Color.FromRgb(0, 0, 0);
        }

        /// <summary>
        /// Overrides this method to write a custom style for record foreground color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetRecordForegroundColor()
        {
            return Color.FromRgb(255, 255, 255);
        }

        /// <summary>
        /// Overrides this method to write a custom style for selection background color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetSelectionBackgroundColor()
        {
            return Color.FromRgb(85, 85, 85);
        }

        /// <summary>
        /// Overrides this method to write a custom style for selection foreground color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetSelectionForegroundColor()
        {
            return Color.FromRgb(255, 255, 255);
        }

        /// <summary>
        /// Overrides this method to write a custom style for caption summary row background color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetCaptionSummaryRowBackgroundColor()
        {
            return Color.FromRgb(02, 02, 02);
        }

        /// <summary>
        /// Overrides this method to write a custom style for caption summary row background color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetCaptionSummaryRowForegroundColor()
        {
            return Color.FromRgb(255, 255, 255);
        }

        /// <summary>
        /// Overrides this method to write a custom style for border color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetBorderColor()
        {
            return Color.FromRgb(81, 83, 82);
        }

        /// <summary>
        /// Overrides this method to write a alternate row back ground color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetAlternatingRowBackgroundColor()
        {
            return Color.FromRgb(46, 46, 46);
        }

        /// <summary>
        /// Overrides this method to write a Grid line visibility
        /// </summary>
        /// <returns>Returns GridLinesVisibility Horizontal</returns>
        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Horizontal;
        }
    }
}
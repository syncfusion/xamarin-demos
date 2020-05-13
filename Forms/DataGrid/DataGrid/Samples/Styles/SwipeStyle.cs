#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SwipeStyle.cs" company="Syncfusion.com">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Syncfusion.SfDataGrid.XForms;

    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// Derived from DataGridStyle to add the custom styles
    /// </summary>
    public class SwipeStyle : DataGridStyle
    {
        /// <summary>
        /// Initializes a new instance of the SwipeStyle class.
        /// </summary>
        public SwipeStyle()
        {
        }

        /// <summary>
        /// Overrides this method to write a custom style for header back ground color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromRgb(15, 15, 15);
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
            return Color.FromRgb(25, 25, 25);
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
            return Color.FromHex("#cce5fa");
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
        /// Overrides this method to write a custom style for caption summary row foreground color
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
        /// Overrides this method to write a Grid line visibility
        /// </summary>
        /// <returns>Returns GridLinesVisibility Horizontal</returns>
        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Horizontal;
        }
    }
}
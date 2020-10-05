#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "GettingStartedStyle.cs" company="Syncfusion.com">
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
    using Syncfusion.Data;
    using Syncfusion.SfDataGrid.XForms;

    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// Derived from DataGridStyle to add the custom styles
    /// </summary>
    public class GettingStartedStyle : DataGridStyle
    {
        /// <summary>
        /// Initializes a new instance of the GettingStartedStyle class.
        /// </summary>
        public GettingStartedStyle()
        {
        }

        /// <summary>
        /// Overrides this method to write a custom style for header foreground color.
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetHeaderForegroundColor()
        {
            return Color.FromHex("#212121");
        }

        /// <summary>
        /// Overrides this method to write a custom style for header background color.
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromHex("#F5F5F5");
        }

        /// <summary>
        /// Overrides this method to write a custom style for record foreground color.
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetRecordForegroundColor()
        {
            return Color.FromHex("#212121");
        }

        /// <summary>
        /// Overrides this method to write a custom style for record background color.
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetRecordBackgroundColor()
        {
            return Color.FromHex("#FFFFFF");
        }

        /// <summary>
        /// Overrides this method to write a custom style for caption summary row background color.
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetCaptionSummaryRowBackgroundColor()
        {
            return Color.FromHex("#FFFFFF");
        }

        /// <summary>
        /// Overrides this method to write a custom style for caption summary row foreground color.
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetCaptionSummaryRowForegroundColor()
        {
            return Color.FromHex("#666666");
        }

        /// <summary>
        /// Overrides this method to write a custom style for stacked header background color.
        /// </summary>
        /// <param name="rowIndex">stacked header row index</param>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetStackedHeaderBackgroundColor(int rowIndex)
        {
            return Color.FromHex("#F5F5F5");
        }

        /// <summary>
        /// Overrides this method to write a custom style for stacked header background color.
        /// </summary>
        /// <param name="rowIndex">stacked header row index</param>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetStackedHeaderForegroundColor(int rowIndex)
        {
            return Color.FromHex("#212121");
        }

        /// <summary>
        /// override to get a Custom GridLineVisibility
        /// </summary>
        /// <returns>GridLinesVisibility() method returns GridLineVisibility value</returns>
        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Horizontal;
        }
    }
}

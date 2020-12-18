#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "Purple.cs" company="Syncfusion.com">
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
    public class Purple : DataGridStyle
    {
        /// <summary>
        /// Initializes a new instance of the Purple class.
        /// </summary>
        public Purple()
        {
        }

        /// <summary>
        /// Overrides this method to write a custom style for header background color
        /// </summary>
        /// <returns>Returns From H e x Color</returns>
        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromHex("#83538B");
        }

        /// <summary>
        /// Overrides this method to write a custom style for header foreground color
        /// </summary>
        /// <returns>Returns From H e x Color</returns>
        public override Color GetHeaderForegroundColor()
        {
            return Color.FromRgb(255, 255, 255);
        }

        /// <summary>
        /// Overrides this method to write a custom style for selection background color
        /// </summary>
        /// <returns>Returns given Color</returns>
        public override Color GetSelectionBackgroundColor()
        {
            return Color.FromRgb(149, 117, 205);
        }

        /// <summary>
        /// Overrides this method to write a custom style for selection foreground color
        /// </summary>
        /// <returns>Returns given Color</returns>
        public override Color GetSelectionForegroundColor()
        {
            return Color.FromRgb(255, 255, 255);
        }

        /// <summary>
        /// Overrides this method to write a custom style for alternate row background color
        /// </summary>
        /// <returns>Returns given Color</returns>
        public override Color GetAlternatingRowBackgroundColor()
        {
            return Color.FromRgb(237, 231, 246);
        }

        /// <summary>
        /// Overrides this method to write a custom style for alternate row foreground color
        /// </summary>
        /// <returns>Returns given Color</returns>
        public override Color GetRecordForegroundColor()
        {
            return Color.FromRgb(0, 0, 0);
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

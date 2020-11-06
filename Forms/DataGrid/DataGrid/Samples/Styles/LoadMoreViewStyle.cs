#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "LoadMoreViewStyle.cs" company="Syncfusion.com">
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
    public class LoadMoreViewStyle : DataGridStyle
    {
        /// <summary>
        /// Initializes a new instance of the LoadMoreViewStyle class.
        /// </summary>
        public LoadMoreViewStyle()
        {
        }

        /// <summary>
        /// Overrides this method to write a Grid line visibility
        /// </summary>
        /// <returns>Returns GridLinesVisibility Horizontal</returns>
        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Horizontal;
        }

        /// <summary>
        /// Overrides this method to write a custom style for LoadMoreView background color
        /// </summary>
        /// <returns>Returns From H e x Color</returns>
        public override Color GetLoadMoreViewBackgroundColor()
        {
            return Color.FromHex("#E0E0E0 ");
        }

        /// <summary>
        /// Overrides this method to write a custom style for LoadMoreView foreground color
        /// </summary>
        /// <returns>Returns From H e x Color</returns>
        public override Color GetLoadMoreViewForegroundColor()
        {
            return Color.FromHex(" #000000");
        }
    }
}

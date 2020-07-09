#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "CellTemplateStyle.cs" company="Syncfusion.com">
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
    public class CellTemplateStyle : DataGridStyle
    {
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
            return Color.Black;
        }
    }
}

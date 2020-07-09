#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SelectionControllerStyle.cs" company="Syncfusion.com">
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
    using Syncfusion.GridCommon.ScrollAxis;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    /// <summary>
    /// Derived from DataGridStyle to add the custom styles
    /// </summary>
    public class SelectionControllerStyle : Syncfusion.SfDataGrid.XForms.DefaultStyle
    {
        /// <summary>
        /// Initializes a new instance of the SelectionControllerStyle class.
        /// </summary>
        public SelectionControllerStyle()
        {
        }

        /// <summary>
        /// Overrides this method to write a custom style for selection back ground color.
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetSelectionBackgroundColor()
        {
            return Color.FromHex("#b2d8f7");
        }
    }
}

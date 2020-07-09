#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "UnboundRowStyle.cs" company="Syncfusion.com">
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
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// Derived from DataGridStyle to add the custom styles
    /// </summary>
    public class UnboundRowStyle : DataGridStyle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnboundRowStyle" /> class.
        /// </summary>
        public UnboundRowStyle()
        {
        }
        
        /// <summary>
        /// Overrides this method to write a FontAttribute for Unbound row.
        /// </summary>
        /// <returns>Returns the <see cref="FontAttributes"/>.</returns>
        public override FontAttributes GetUnboundRowFontAttribute()
        {
            return FontAttributes.Bold;
        }
    }
}

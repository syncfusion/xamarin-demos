#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "CustomLayout.cs" company="Syncfusion.com">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Syncfusion.SfDataGrid.XForms;
    
    using Xamarin.Forms;

    /// <summary>
    ///  A layout that arranges views in rows and columns
    /// </summary>
    public class CustomLayout : Grid
    {
        /// <summary>
        ///  Updates the bounds of the element during the layout cycle.
        /// </summary>
        /// <param name="x">A value representing the x coordinate of the child region bounding box.</param>
        /// <param name="y">A value representing the y coordinate of the child region bounding box.</param>
        /// <param name="width">A value representing the width of the child region bounding box.</param>
        /// <param name="height">A value representing the height of the child region bounding box.</param>
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
                this.Children[0].Layout(new Rectangle(0, 0, this.Width, this.Height));
        }

        /// <summary>
        /// Method to decide whether to call <see cref="Xamarin.Forms.VisualElement.InvalidateMeasure()"/> when adding a child.
        /// </summary>
        /// <param name="child">A child of the <see cref="SfDataGrid"/>.</param>
        /// <returns>A boolean value do decide whether to invalidate when adding a child.</returns>
        protected override bool ShouldInvalidateOnChildAdded(View child)
        {
            return false;
        }

        /// <summary>
        /// Method to decide whether to call <see cref="Xamarin.Forms.VisualElement.InvalidateMeasure()"/> when removing a child.
        /// </summary>
        /// <param name="child">A child of the <see cref="SfDataGrid"/>.</param>
        /// <returns>A boolean value do decide whether to invalidate when removing a child.</returns>
        protected override bool ShouldInvalidateOnChildRemoved(View child)
        {
            return false;
        }
    }
}

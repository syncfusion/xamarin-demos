#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "PreviewControllerDS.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]

namespace SampleBrowser.SfDataGrid.iOS
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using QuickLook;

    /// <summary>
    ///  A class that allows a QuickLook.QLPreviewController to preview multiple items.
    /// </summary>
    public class PreviewControllerDS : QLPreviewControllerDataSource
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private QLPreviewItem item;

        /// <summary>
        /// Initializes a new instance of the PreviewControllerDS class.
        /// </summary>
        /// <param name="item">QLPreviewItem type of item</param>
        public PreviewControllerDS(QLPreviewItem item)
        {
            this.item = item;
        }

        /// <summary>
        ///  A UIKit.UIViewController that manages the user experience of previewing an item.
        /// </summary>
        /// <param name="controller">QLPreviewController type of controller parameter</param>
        /// <returns>returns the value of n integer type as 1</returns>
        public override nint PreviewItemCount(QLPreviewController controller)
        {
            return (nint)1;
        }

        /// <summary>
        ///  Override method to get a item
        /// </summary>
        /// <param name="controller">QLPreviewController type of controller parameter</param>
        /// <param name="index">integer type of parameter index</param>
        /// <returns>returns PreviewControllerDS item value</returns>
        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        {
            return this.item;
        }
    }
}
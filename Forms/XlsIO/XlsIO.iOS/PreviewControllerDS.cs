#region Copyright Syncfusion Inc. 2001-2018.
// <copyright file="PreviewControllerDS.cs" company=" Syncfusion Inc.">
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
// </copyright>
#endregion

namespace SampleBrowser.XlsIO.IOS
{
    using System;
    using QuickLook;

    /// <summary>
    /// This class used the specialized view for previewing an item using DataSource.
    /// </summary>
    public class PreviewControllerDS : QLPreviewControllerDataSource
    {
        /// <summary>
        /// Contains the value of <see cref="QLPreviewItem"/> class.
        /// </summary>
        private QLPreviewItem item;

        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewControllerDS" /> class.
        /// </summary>
        /// <param name="ql_Item">The value of item parameter from <see cref="QLPreviewItem"/> class.</param>
        public PreviewControllerDS(QLPreviewItem ql_Item)
        {
            this.item = ql_Item;
        }

        /// <summary>
        /// Override the PreviewItemCount method with <see cref="nint"/>.
        /// </summary>
        /// <param name="controller">The value of controller parameter from <see cref="QLPreviewController"/> class.</param>
        /// <returns>return the value 1.</returns>
        public override nint PreviewItemCount(QLPreviewController controller)
        {
            return (nint)1;
        }

        /// <summary>
        /// Override the GetPreviewItem method with <see cref="IQLPreviewItem"/> interface.
        /// </summary>
        /// <param name="controller">The value of controller parameter from <see cref="QLPreviewController"/> class.</param>
        /// <param name="index">The value of an index.</param>
        /// <returns>return the _item field.</returns>
        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        {
            return this.item;
        }
    }
}
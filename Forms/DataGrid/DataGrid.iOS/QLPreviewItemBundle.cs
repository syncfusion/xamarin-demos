#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "QLPreviewItemBundle.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]
#endregion

namespace SampleBrowser.SfDataGrid.iOS
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Foundation;
    using QuickLook;

    /// <summary>
    ///  An item that can be previewed with a QuickLook.QLPreviewController.
    /// </summary>
    public class QLPreviewItemBundle : QLPreviewItem
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string fileName, filePath;

        /// <summary>
        /// Initializes a new instance of the QLPreviewItemBundle class.
        /// </summary>
        /// <param name="fileName">string type parameter fileName</param>
        /// <param name="filePath">string type parameter filePath</param>
        public QLPreviewItemBundle(string fileName, string filePath)
        {
            this.fileName = fileName;
            this.filePath = filePath;
        }

        /// <summary>
        /// Override this property to return fileName
        /// </summary>
        public override string ItemTitle
        {
            get
            {
                return this.fileName;
            }
        }

        /// <summary>
        /// override this property to return ItemUrl1
        /// </summary>
        public override NSUrl ItemUrl
        {
            get
            {
                var documents = NSBundle.MainBundle.BundlePath;
                var lib = Path.Combine(documents, this.filePath);
                var url = NSUrl.FromFilename(lib);
                return url;
            }
        }
    }
}
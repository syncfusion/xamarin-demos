#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "QLPreviewItemFileSystem.cs" company="Syncfusion.com">
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
    ///   An item that can be previewed with a QuickLook.QLPreviewController.
    /// </summary>
    public class QLPreviewItemFileSystem : QLPreviewItem
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string fileName, filePath;

        /// <summary>
        /// Initializes a new instance of the QLPreviewItemFileSystem class.
        /// </summary>
        /// <param name="fileName">string type parameter fileName</param>
        /// <param name="filePath">string type parameter filePath</param>
        public QLPreviewItemFileSystem(string fileName, string filePath)
        {
            this.fileName = fileName;
            this.filePath = filePath;
        }

        /// <summary>
        /// Override this property to get and returns fileName
        /// </summary>
        public override string ItemTitle
        {
            get
            {
                return this.fileName;
            }
        }

        /// <summary>
        /// Override this property returns the FileName
        /// </summary>
        public override NSUrl ItemUrl
        {
            get
            {
                return NSUrl.FromFilename(this.filePath);
            }
        }
    }
}
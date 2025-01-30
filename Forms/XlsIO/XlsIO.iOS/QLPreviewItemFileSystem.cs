#region Copyright Syncfusion Inc. 2001-2018.
// <copyright file="QLPreviewItemFileSystem.cs" company=" Syncfusion Inc.">
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
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Foundation;
    using QuickLook;

    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]

    /// <summary>
    /// This class used the specialized view for previewing an item.
    /// </summary>
    public class QLPreviewItemFileSystem : QLPreviewItem
    {
        /// <summary>
        /// Used to assign the file name and file path.
        /// </summary>
        private string fileName, filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="QLPreviewItemFileSystem" /> class.
        /// </summary>
        /// <param name="ql_FileName">fileName represents the name of file.</param>
        /// <param name="ql_FilePath">filePath represents the path of file</param>
        public QLPreviewItemFileSystem(string ql_FileName, string ql_FilePath)
        {
            this.fileName = ql_FileName;
            this.filePath = ql_FilePath;
        }

        /// <summary>
        /// override ItemTitle with fileName field.
        /// </summary>
        public override string ItemTitle
        {
            get
            {
                return this.fileName;
            }
        }

        /// <summary>
        /// override ItemUrl with filePath field.
        /// </summary>
        public override NSUrl ItemUrl
        {
            get
            {
                return NSUrl.FromFilename(this.filePath);
            }
        }
    }

    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]

    /// <summary>
    /// This class used the specialized view for previewing an item.
    /// </summary>
    public class QLPreviewItemBundle : QLPreviewItem
    {
        /// <summary>
        /// Used to assign the file name and file path.
        /// </summary>
        private string fileName, filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="QLPreviewItemBundle"/> class.
        /// </summary>
        /// <param name="ql_FileName">fileName represents the name of file.</param>
        /// <param name="ql_filePath">filePath represents the path of file</param>
        public QLPreviewItemBundle(string ql_FileName, string ql_filePath)
        {
            this.fileName = ql_FileName;
            this.filePath = ql_filePath;
        }

        /// <summary>
        /// override ItemTitle with _fileName field.
        /// </summary>
        public override string ItemTitle
        {
            get
            {
                return this.fileName;
            }
        }

        /// <summary>
        /// override ItemUrl with _filePath field.
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
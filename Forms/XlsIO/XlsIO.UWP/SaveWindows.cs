#region Copyright Syncfusion Inc. 2001-2018.
// <copyright file="SaveWindows.cs" company=" Syncfusion Inc.">
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
// </copyright>
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using SampleBrowser.XlsIO;
using SampleBrowser.XlsIO.UWP;
using Windows.Storage;
using Windows.Storage.Pickers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: Dependency(typeof(SaveWindows))]

namespace SampleBrowser.XlsIO.UWP
{
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]

    /// <summary>
    /// This class is used to save option for Windows/UWP.
    /// </summary>
    internal class SaveWindows : ISaveWindowsPhone
    {
        /// <summary>
        /// This method used to provide save option for Windows/UWP.
        /// </summary>
        /// <param name="filename">Name of the output file.</param>
        /// <param name="contentType">Content type of the output file.</param>
        /// <param name="stream">output file of MemoryStream.</param>
        /// <returns>Return Null if the storageFile is null.</returns>
        public async Task Save(string filename, string contentType, MemoryStream stream)
        {
            if (Device.Idiom != TargetIdiom.Desktop)
            {
                StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFile outFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                using (Stream outStream = await outFile.OpenStreamForWriteAsync())
                {
                    outStream.Write(stream.ToArray(), 0, (int)stream.Length);
                }

                if (contentType != "application/html")
                {
                    await Windows.System.Launcher.LaunchFileAsync(outFile);
                }
            }
            else
            {
                StorageFile storageFile = null;
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.SuggestedStartLocation = PickerLocationId.Desktop;
                savePicker.SuggestedFileName = filename;
                switch (contentType)
                {
                    case "application/vnd.openxmlformats-officedocument.presentationml.presentation":
                        savePicker.FileTypeChoices.Add("PowerPoint Presentation", new List<string>() { ".pptx", });
                        break;

                    case "application/msexcel":
                        savePicker.FileTypeChoices.Add("Excel Files", new List<string>() { ".xlsx", });
                        break;

                    case "application/msword":
                        savePicker.FileTypeChoices.Add("Word Document", new List<string>() { ".docx" });
                        break;

                    case "application/pdf":
                        savePicker.FileTypeChoices.Add("Adobe PDF Document", new List<string>() { ".pdf" });
                        break;
                    case "application/html":
                        savePicker.FileTypeChoices.Add("HTML Files", new List<string>() { ".html" });
                        break;
                    case "text/html":
                        savePicker.FileTypeChoices.Add("HTML Files", new List<string>() { ".html" });
                        break;
                    case "image/png":
                        savePicker.FileTypeChoices.Add("Png Image", new List<string>() { ".png" });
                        break;
                    case "image/jpeg":
                        savePicker.FileTypeChoices.Add("Jpeg Image", new List<string>() { ".jpeg" });
                        break;
                }

                storageFile = await savePicker.PickSaveFileAsync();

                if (storageFile == null)
                {
                    return;
                }

                using (Stream outStream = await storageFile.OpenStreamForWriteAsync())
                {
                    if (outStream.CanSeek)
                    {
                        outStream.SetLength(0);
                    }

                    outStream.Write(stream.ToArray(), 0, (int)stream.Length);
                    outStream.Flush();
                    outStream.Dispose();
                }

                stream.Flush();
                stream.Dispose();
                await Windows.System.Launcher.LaunchFileAsync(storageFile);
            }
        }
    }

    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]

    /// <summary>
    /// This class is used to render the images used in samples.
    /// </summary>
    internal class SfImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SfImageRenderer" /> class.
        /// </summary>
        public SfImageRenderer()
        {
        }

        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed.")]

        /// <summary>
        /// Method used to dispose class property
        /// </summary>
        /// <param name="disposing">TRUE if Element Property Changed</param>
        protected override void Dispose(bool disposing)
        {
            this.Element.PropertyChanged -= OnElementPropertyChanged;
            base.Dispose(false);
        }
    }
}

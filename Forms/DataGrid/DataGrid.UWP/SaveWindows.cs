#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SaveWindows.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser;
using SampleBrowser.SfDataGrid.UWP;
using Windows.ApplicationModel.Email;
using Windows.Storage;
using Windows.Storage.Pickers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: Dependency(typeof(SaveWindows))]

namespace SampleBrowser.SfDataGrid.UWP
{
    /// <summary>
    /// A dependency service to save a exported file in UWP
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1400:AccessModifierMustBeDeclared", Justification = "Reviewed.")]
    class SaveWindows : ISaveWindowsPhone
    {
        /// <summary>
        /// Used to Save a Exporting file in UWP device
        /// </summary>
        /// <param name="filename">string type of fileName</param>
        /// <param name="contentType">string type of contentType</param>
        /// <param name="stream">string type of stream</param>
        /// <returns>returns the saved file</returns>
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
                }

                storageFile = await savePicker.PickSaveFileAsync();

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
}

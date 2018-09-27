#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Windows.Storage;
using Windows.Storage.Pickers;
using SampleBrowser;
using SampleBrowser.SfDataGrid.UWP;
using Xamarin.Forms.Platform.UWP;
using Windows.ApplicationModel.Email;

[assembly: Dependency(typeof(SaveWindows))]
namespace SampleBrowser.SfDataGrid.UWP
{
    class SaveWindows: ISaveWindowsPhone
    {

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
                    await Windows.System.Launcher.LaunchFileAsync(outFile);
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
                        outStream.SetLength(0);
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

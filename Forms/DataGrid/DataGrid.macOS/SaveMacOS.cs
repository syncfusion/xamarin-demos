#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SaveMacOS.cs" company="Syncfusion.com">
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
using AppKit;
using Foundation;
using QuickLook;
using SampleBrowser.SfDataGrid.MacOS;
using Xamarin.Forms;
using UIView = AppKit.NSView;

[assembly: Dependency(typeof(SaveMacOS))]

namespace SampleBrowser.SfDataGrid.MacOS
{
    [Preserve(AllMembers = true)]

    /// <summary>
    /// A dependency service to save a exported file in UWP
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1400:AccessModifierMustBeDeclared", Justification = "Reviewed.")]
    class SaveMacOS : ISave
    {
        /// <summary>
        /// Used to Save a Exporting file in UWP device
        /// </summary>
        /// <param name="filename">string type parameter fileName</param>
        /// <param name="contentType">string type parameter content Type</param>
        /// <param name="stream">MemoryStream type parameter stream</param>
        public void Save(string filename, string contentType, MemoryStream stream)
        {
            string exception = string.Empty;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, filename);
            try
            {
                FileStream fileStream = File.Open(filePath, FileMode.Create);
                stream.Position = 0;
                stream.CopyTo(fileStream);
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception e)
            {
                exception = e.ToString();
            }

            if (contentType == "application/html" || exception != string.Empty)
            {
                return;
            }

            NSWorkspace.SharedWorkspace.OpenFile(filePath);
        }
    }
}
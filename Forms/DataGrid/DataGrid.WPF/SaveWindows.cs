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
using System.Windows;
using Microsoft.Win32;
using SampleBrowser;
using SampleBrowser.SfDataGrid.WPF;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveWindows))]

namespace SampleBrowser.SfDataGrid.WPF
{
    /// <summary>
    /// A dependency service to save a exported file in WPF
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1400:AccessModifierMustBeDeclared", Justification = "Reviewed.")]
    class SaveWindows : ISave
    {
        /// <summary>
        /// Used to Save a Exporting file in WPF
        /// </summary>
        /// <param name="filename">string type of fileName</param>
        /// <param name="contentType">string type of contentType</param>
        /// <param name="stream">string type of stream</param>
        /// <returns>returns the saved file</returns>
        public void Save(string filename, string contentType, MemoryStream stream)
        {
            string fileType = null;
            switch (contentType)
            {
                case "application/msexcel":
                    fileType = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx";
                    break;

                case "application/pdf":
                    fileType = "PDF Files(*.pdf)|*.pdf";
                    break;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = fileType
            };

            if (sfd.ShowDialog() == true)
            {
                using (Stream streams = sfd.OpenFile())
                {
                    streams.Write(stream.ToArray(), 0, (int)stream.Length);
                    streams.Flush();
                    streams.Dispose();
                }

                stream.Flush();
                stream.Dispose();

                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }
    }
}

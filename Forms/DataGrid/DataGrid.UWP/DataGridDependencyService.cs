#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "DataGridDependencyService.cs" company="Syncfusion.com">
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.SfDataGrid.UWP;
using Windows.Graphics.Display;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataGridDependencyService))]

namespace SampleBrowser.SfDataGrid.UWP
{
    /// <summary>
    /// A dependency Service for DataGrid Samples.
    /// </summary>
    internal class DataGridDependencyService : IDataGridDependencyService
    {
        /// <summary>
        /// Used to get the device orientation in UWP platform
        /// </summary>
        /// <returns>returns device orientation as landscape or portrait</returns>
        public string GetOrientation()
        {
            return DisplayInformation.GetForCurrentView().CurrentOrientation.ToString();
        }
    }
}
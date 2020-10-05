#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "IDataGridDependencyService.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that defines the methods required for the DataGrid SampleBrowser.
    /// </summary>
    public interface IDataGridDependencyService
    {
        /// <summary>
        /// Used to get device orientation in platform specific by using IDataGridDependencyService Interface
        /// </summary>
        /// <returns>returns device orientation as landscape or portrait</returns>
        string GetOrientation();
    }
}

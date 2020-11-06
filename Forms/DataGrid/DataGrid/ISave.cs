#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ISave.cs" company="Syncfusion.com">
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
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that defines the methods used for saving the exported files in DataGrid.
    /// </summary>
    public interface ISave
    {
        /// <summary>
        /// Used to save a Exporting grid to Excel and PDF file by writing ISave Interface
        /// </summary>
        /// <param name="filename">string type of filename parameter</param>
        /// <param name="contentType">string type of contentType parameter</param>
        /// <param name="stream">MemoryStream type of stream parameter</param>
        void Save(string filename, string contentType, MemoryStream stream);
    }

    /// <summary>
    /// Interface that defines the methods used for saving the exported files in DataGrid in WindowsPhone.
    /// </summary>
    public interface ISaveWindowsPhone
    {
        /// <summary>
        /// Used to save a Exporting grid to Excel and PDF file in UWP devices
        /// </summary>
        /// <param name="filename">string type of filename parameter</param>
        /// <param name="contentType">string type of contentType parameter</param>
        /// <param name="stream">MemoryStream type of stream parameter</param>
        /// <returns>returns saved file</returns>
        Task Save(string filename, string contentType, MemoryStream stream);
    }

    /// <summary>
    ///  Interface that defines the methods used for saving the exported files in DataGrid in Android device.
    /// </summary>
    public interface IAndroidVersionDependencyService
    {
        /// <summary>
        /// Used to get Android version
        /// </summary>
        /// <returns>returns Android version</returns>
        int GetAndroidVersion();
    }

    /// <summary>
    /// Interface that defines methods to compose mail
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// used this method for ComposeMail
        /// </summary>
        /// <param name="fileName">string type of parameter fileName</param>
        /// <param name="recipients">string type of parameter recipients</param>
        /// <param name="subject">string type of parameter subject</param>
        /// <param name="messagebody">string type of parameter message body</param>
        /// <param name="documentStream">MemoryStream type parameter documentStream</param>
        void ComposeMail(string fileName, string[] recipients, string subject, string messagebody, MemoryStream documentStream);
    }
}
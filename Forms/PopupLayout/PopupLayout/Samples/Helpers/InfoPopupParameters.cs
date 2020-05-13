#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "InfoPopupParameters.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using Syncfusion.XForms.PopupLayout;
    using Xamarin.Forms;

    /// <summary>
    /// A class that contains the Parameters of the InformationPopup.
    /// </summary>
    public class InfoPopupParameters
    {
        /// <summary>
        /// Gets or sets the information Popup.
        /// </summary>
        public SfPopupLayout InfoPopup { get; set; }

        /// <summary>
        /// Gets or sets the TheatreLabel.
        /// </summary>
        public Label TheatreLabel { get; set; }
    }
}
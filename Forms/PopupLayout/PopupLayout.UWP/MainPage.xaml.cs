#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "MainPage.xaml.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout.UWP
{
    using Syncfusion.ListView.XForms.UWP;
    using Syncfusion.SfDataGrid.XForms.UWP;
    using Syncfusion.SfRotator.XForms.UWP;
    using Syncfusion.XForms.UWP.PopupLayout;

    /// <summary>
    /// This is the main entry point of the application while launching in UWP platform.
    /// </summary>
    public sealed partial class MainPage
    {
        /// <summary>
        /// Initializes a new instance of the MainPage class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            SfPopupLayoutRenderer.Init();
            SfDataGridRenderer.Init();
            SfListViewRenderer.Init();
            SfRotatorRenderer.Init();
            this.LoadApplication(new SfPopupLayout.App());
        }
    }
}
#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core.WPF;
using Syncfusion.ListView.XForms.WPF;
using Syncfusion.SfDataGrid.XForms.WPF;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace SampleBrowser.SfDataGrid.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();
            Forms.Init();
            CoreSampleBrowser.Init();
            SfDataGridRenderer.Init();
            SfListViewRenderer.Init();
            LoadApplication(new SfDataGrid.App());
        }
    }
}

#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;
using Syncfusion.XForms.WPF.Graphics;
using Syncfusion.XForms.WPF.Buttons;
using SampleBrowser.Core.WPF;
using Syncfusion.XForms.WPF.BadgeView;
using Syncfusion.ListView.XForms.WPF;
using Syncfusion.XForms.WPF.Border;
using Syncfusion.XForms.WPF.TextInputLayout;

namespace SampleBrowser.SfBadgeView.WPF
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
            SfBadgeViewRenderer.Init();
            SfSegmentedControlRenderer.Init();
            SfChipGroupRenderer.Init();
            SfBorderRenderer.Init();
            SfTextInputLayoutRenderer.Init();
            SfButtonRenderer.Init();
            SfListViewRenderer.Init();
            LoadApplication(new SampleBrowser.SfBadgeView.App());
        }
    }
}

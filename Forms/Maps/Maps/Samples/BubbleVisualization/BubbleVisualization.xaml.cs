#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfMaps.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfMaps
{
    [Preserve(AllMembers = true)]
   // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BubbleVisualization : SampleView
    {
        public BubbleVisualization()
        {
            InitializeComponent();

            BubbleVisualizationViewModel viewmodel = new BubbleVisualizationViewModel();
            (this.sfmap.Layers[0] as ShapeFileLayer).ItemsSource = viewmodel.GetDataSource();
            (this.sfmap.Layers[0] as ShapeFileLayer).ShapeSettings.ColorMappings.Clear();
        }
    }
}

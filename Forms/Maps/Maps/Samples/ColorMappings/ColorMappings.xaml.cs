#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorMappings : SampleView
    {
        public ColorMappings()
        {
            InitializeComponent();
            var shapeLayer = this.Map.Layers[0] as ShapeFileLayer;
			shapeLayer.TooltipSettings.TooltipTemplate = grid.Resources["toolTipTemplate"] as DataTemplate;
            
            grid.SizeChanged += Grid_SizeChanged;

        }

        private void Grid_SizeChanged(object sender, EventArgs e)
        {
            if (Map.Bounds.Width > Map.Bounds.Height)
            {
                (this.Map.Layers[0] as ShapeFileLayer).LegendSettings.LegendPosition = new Point(55, 85);
                (this.Map.Layers[0] as ShapeFileLayer).LegendSettings.HorizontalAlignment = HorizontalAlignment.Start;
            }
            else
            {
                (this.Map.Layers[0] as ShapeFileLayer).LegendSettings.LegendPosition = new Point(50, 5);
                (this.Map.Layers[0] as ShapeFileLayer).LegendSettings.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }

    }

}

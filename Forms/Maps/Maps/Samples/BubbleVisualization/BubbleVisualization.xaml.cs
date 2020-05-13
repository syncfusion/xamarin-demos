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
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BubbleVisualization : SampleView
    {
        public BubbleVisualization()
        {
            InitializeComponent();
            grid.SizeChanged += Grid_SizeChanged;
            Uri uri = new Uri("https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_population");
            (this.sfmap.Layers[0] as ShapeFileLayer).BubbleMarkerSettings.TooltipSettings.TooltipTemplate = grid.Resources["toolTipTemplate"] as DataTemplate;
            this.Link.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Device.OpenUri(uri))
            });
        }
        private void Grid_SizeChanged(object sender, EventArgs e)
        {
            if (sfmap.Bounds.Width > sfmap.Bounds.Height)
            {
                (this.sfmap.Layers[0] as ShapeFileLayer).LegendSettings.LegendPosition = new Point(75, 45);
                (this.sfmap.Layers[0] as ShapeFileLayer).LegendSettings.HorizontalAlignment = HorizontalAlignment.Start;
            }
            else
            {
                (this.sfmap.Layers[0] as ShapeFileLayer).LegendSettings.LegendPosition = new Point(50, 5);
                (this.sfmap.Layers[0] as ShapeFileLayer).LegendSettings.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }
    }
}

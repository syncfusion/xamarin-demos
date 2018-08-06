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
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorMappings : SampleView
    {
        public ColorMappings()
        {
            InitializeComponent();
            this.BindingContext = this;
            ColorMappingsViewModel viewmodel = new ColorMappingsViewModel();
            (this.Map.Layers[0] as ShapeFileLayer).ItemsSource = viewmodel.GetDataSource();
            (this.Map.Layers[0] as ShapeFileLayer).LegendSettings.IconSize = new Size(15, 15);
            
            grid.SizeChanged += Grid_SizeChanged;
            
            if ((Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop) && Device.OS == TargetPlatform.Windows)
            {
                (this.Map.Layers[0] as ShapeFileLayer).LegendSettings.LegendPosition = new Point(850, 400);
            }

             (this.Map.Layers[0] as ShapeFileLayer).ShapeSelected += (object data) => {

                AgricultureData dat = data as AgricultureData;
                if (dat != null)
                {
                    Toast.IsVisible = true;
                    State = countryLabel.Text = dat.Name;
                    Type = populationLabel.Text = dat.Type;

                    Device.StartTimer(new TimeSpan(0, 0, 3), () =>
                    {
                        Toast.IsVisible = false;
                        return false;
                    });
                }
            };

        }
        
        private void Grid_SizeChanged(object sender, EventArgs e)
        {
            if (Device.OS != TargetPlatform.Windows)
            {
                var y = Map.Bounds.Height * 0.9d;
                var x = Map.Bounds.Center.X;

                if (Map.Bounds.Width > Map.Bounds.Height)
                {
                    if (Device.OS == TargetPlatform.iOS)
                        (this.Map.Layers[0] as ShapeFileLayer).LegendSettings.LegendPosition = new Point(x, y);
                    else
                        (this.Map.Layers[0] as ShapeFileLayer).LegendSettings.LegendPosition = new Point(85, 50);
                }

                else
                    (this.Map.Layers[0] as ShapeFileLayer).LegendSettings.LegendPosition = new Point(5, 10);
            } 
        }

        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}

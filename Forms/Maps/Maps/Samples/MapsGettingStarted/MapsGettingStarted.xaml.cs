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
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfMaps
{
    [Preserve(AllMembers = true)]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsGettingStarted : SampleView
    {
        public MapsGettingStarted()
        {
            InitializeComponent();

          (this.Maps.Layers[0] as ShapeFileLayer).ShapeSettings.ColorMappings.Clear();    
          (this.Maps.Layers[0] as ShapeFileLayer).MarkerSettings.TooltipSettings.TooltipTemplate = grid.Resources["toolTipTemplate"] as DataTemplate; 		  
                
        }
       
    }

    public class CustomMarker : MapMarker
    {
        public String ImageName { get; set; }
        public  String Population { get; set; }
        public CustomMarker()
        {
            ImageName = "pin.png";
        }
    }
}

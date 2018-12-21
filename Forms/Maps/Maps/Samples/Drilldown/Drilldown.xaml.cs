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
    public partial class Drilldown : SampleView
    {
        public Drilldown()
        {
            InitializeComponent();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Map.BaseMapIndex = 0;
                stackLayout.IsVisible = false;
                header.IsVisible = true;
            };
            label.GestureRecognizers.Add(tapGestureRecognizer);
			switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                case Device.Android:
                    {
                        asiaMarker.Latitude = "63.34303378997662";
                        asiaMarker.Longitude = "102.07617561287645";

                        australiaMarker.Latitude = "-25.74775493367931";
                        australiaMarker.Longitude = "136.80451417932431";

                        africaMarker.Latitude = "19.025302093442327";
                        africaMarker.Longitude = "15.157534554671087";

                        northAmericaMarker.Latitude = "59.88893689676585";
                        northAmericaMarker.Longitude = "-109.3359375";

                        europeMarker.Latitude = "47.95121990866204";
                        europeMarker.Longitude = "18.468749999999998";

                        southAmericaMarker.Latitude = "-6.64607562172573";
                        southAmericaMarker.Longitude = "-55.54687499999999";
                    }
                    break;
                case Device.UWP:
                    {
                        asiaMarker.Latitude = "58.34303378997662";
                        asiaMarker.Longitude = "90.07617561287645";

                        australiaMarker.Latitude = "-22.746024";
                        australiaMarker.Longitude = "121.515605";

                        africaMarker.Latitude = "19.025302093442327";
                        africaMarker.Longitude = "6.157534554671087";

                        northAmericaMarker.Latitude = "58.88893689676585";
                        northAmericaMarker.Longitude = "-118.3359375";

                        europeMarker.Latitude = "53.95121990866204";
                        europeMarker.Longitude = "10.468749999999998";

                        southAmericaMarker.Latitude = "-0.64607562172573";
                        southAmericaMarker.Longitude = "-63.54687499999999";
                    }
                    break;
            }
        }    

        private void Layer_ShapeSelectionChanged(object sender, ShapeSelectedEventArgs args)
        {
            DrilldownModel data = args.Data as DrilldownModel;
            if (data != null)
            {
                continentLabel.Text = data.Continent;
                stackLayout.IsVisible = true;
                header.IsVisible = false;
                if (data.Continent == "South America")
                {
                    Map.BaseMapIndex = 1;
                    layer.ShapeSettings.SelectedShapeColor = Color.FromHex("#9C3367");

                }
                else if (data.Continent == "North America")
                {
                    Map.BaseMapIndex = 2;
                    layer.ShapeSettings.SelectedShapeColor = Color.FromHex("#C13664");

                }
                else if (data.Continent == "Europe")
                {
                    Map.BaseMapIndex = 3;
                    layer.ShapeSettings.SelectedShapeColor = Color.FromHex("#622D6C");
                }
                else if (data.Continent == "Africa")
                {
                    Map.BaseMapIndex = 4;
                    layer.ShapeSettings.SelectedShapeColor = Color.FromHex("#80306A");
                }
                else if (data.Continent == "Australia")
                {
                    Map.BaseMapIndex = 5;
                    layer.ShapeSettings.SelectedShapeColor = Color.FromHex("#2A2870");
                }
                else if (data.Continent == "Asia")
                {
                    Map.BaseMapIndex = 6;
                    layer.ShapeSettings.SelectedShapeColor = Color.FromHex("#462A6D");
                }
            }
        }
    }

}
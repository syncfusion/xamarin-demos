#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Com.Syncfusion.Maps;
using Com.Syncfusion.Sfbusyindicator;
using Com.Syncfusion.Sfbusyindicator.Enums;

using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Content;
using Android.Views;

namespace SampleBrowser
{
	public class DataMarkers : SamplePage
	{
		public DataMarkers ()
		{
		}
		Handler handler;
        Android.Content.Context sampleContext;

        public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
            sampleContext = context;
			LinearLayout layout= new LinearLayout(context);
			layout.Orientation = Orientation.Vertical;
			TextView textView= new TextView(context);
			textView.TextSize = 16;
			textView.SetPadding(10,20,0,0);
			textView.SetHeight(90);
			handler = new Handler();
			textView.Text ="Top Population Countries";
			layout.AddView(textView);
			textView.Gravity = Android.Views.GravityFlags.Top;
			SfMaps maps = new SfMaps (context);
			ShapeFileLayer layer = new ShapeFileLayer ();
			layer.Uri= "world1.shp";
			SfBusyIndicator sfBusyIndicator = new SfBusyIndicator(context);
			sfBusyIndicator.IsBusy = true;
			sfBusyIndicator.AnimationType = AnimationTypes.SlicedCircle;
			sfBusyIndicator.ViewBoxWidth = 50;
			sfBusyIndicator.ViewBoxHeight = 50;

			sfBusyIndicator.TextColor = Color.ParseColor("#779772");
			layout.AddView(sfBusyIndicator);
			Java.Lang.Runnable run = new Java.Lang.Runnable(() =>
				 {
					 layout.RemoveView(sfBusyIndicator);
				     layout.AddView(maps);
					
				 });
			handler.PostDelayed(run,100);
		
			PopulationMarker usa= new PopulationMarker(context);
			usa.Latitude =38.8833;
			usa.Longitude=-77.0167;
			usa.Name= "United States";
			usa.Population ="321,174,000";
			layer.Markers.Add(usa);

			PopulationMarker brazil= new PopulationMarker(context);
			brazil.Latitude=-15.7833;
			brazil.Longitude=-47.8667;
			brazil.Name = "Brazil";
			brazil.Population= "204,436,000";
			layer.Markers.Add(brazil);

			PopulationMarker india= new PopulationMarker(context);
			india.Latitude=21.0000;
			india.Longitude=78.0000;
			india.Name= "India";
			india.Population ="1,272,470,000";
			layer.Markers.Add(india);

			PopulationMarker china= new PopulationMarker(context);
			china.Latitude=35.0000;
			china.Longitude=103.0000;
			china.Name = "China";
			china.Population = "1,370,320,000";
			layer.Markers.Add(china);

			PopulationMarker indonesia= new PopulationMarker(context);
			indonesia.Latitude=-6.1750;
			indonesia.Longitude=106.8283;
			indonesia.Name="Indonesia";
			indonesia.Population="255,461,700";
			layer.Markers.Add(indonesia);
			
			maps.Adapter = new MarkerAdapter(context);
			
			MarkerCustomTooltipSetting tooltipSetting = new MarkerCustomTooltipSetting(context);
            tooltipSetting.ShowTooltip = true;
            layer.MarkerSetting.TooltipSettings = tooltipSetting;

			maps.Layers.Add (layer);

			return layout;
		}
    }
	
	  public class MarkerCustomTooltipSetting : TooltipSetting
    {
        Context context;
        public MarkerCustomTooltipSetting(Context con)
        {
            context = con;
        }

        public override View GetView(object shapeData)
        {
            LinearLayout layout = new LinearLayout(context);
            LinearLayout.LayoutParams linearlayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent,
                    LinearLayout.LayoutParams.WrapContent);
            layout.Orientation = Orientation.Vertical;
            layout.LayoutParameters = linearlayoutParams;
            layout.SetGravity(GravityFlags.CenterHorizontal);

            TextView topLabel = new TextView(context);
            topLabel.Text = (shapeData as PopulationMarker).Name.ToString();
            topLabel.TextSize = 12;
            topLabel.SetTextColor(Color.ParseColor("#FFFFFF"));
            topLabel.Gravity = GravityFlags.CenterHorizontal;

            TextView bottoLabel = new TextView(context);
            bottoLabel.Text = (shapeData as PopulationMarker).Population.ToString();
            bottoLabel.TextSize = 12;
            bottoLabel.SetTextColor(Color.ParseColor("#FFFFFF"));
            bottoLabel.Gravity = GravityFlags.CenterHorizontal;

            layout.AddView(topLabel);
            layout.AddView(bottoLabel);

            return layout;
        }
    }
}


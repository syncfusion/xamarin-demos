#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Com.Syncfusion.Maps;
using Android.Graphics;
using Org.Json;
using Android.Widget;
using Com.Syncfusion.Sfbusyindicator;
using Com.Syncfusion.Sfbusyindicator.Enums;
using Android.OS;

namespace SampleBrowser
{
	public class BubbleVisualization: SamplePage
	{
		SfMaps maps;
		Handler handler;
		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			handler = new Handler();
			LinearLayout layout= new LinearLayout(context);
			layout.Orientation = Orientation.Vertical;
			TextView textView= new TextView(context);
			textView.TextSize = 16;
			textView.SetPadding(10,20,0,0);
			textView.SetHeight(90);

			textView.Text ="Top Population Countries With Bubbles";
			layout.AddView(textView);
			textView.Gravity = Android.Views.GravityFlags.Top;
			maps = new SfMaps (context);
			ShapeFileLayer layer = new ShapeFileLayer ();
			layer.ShowItems = true;
			layer.Uri ="world1.shp";
			layer.DataSource = GetDataSource();
			layer.ShapeIdPath = "Country";
			layer.ShapeIdTableField = "NAME";
			layer.ShapeSettings = new ShapeSetting ();
			layer.ShapeSettings.ShapeValuePath= "ShortName";
			layer.ShapeSettings.ShapeFill = Color.ParseColor ("#A9D9F7");
			BubbleMarkerSetting marker = new BubbleMarkerSetting ()
			{  FillColor = Color.ParseColor ("#ffa500"), MinSize=15,MaxSize=25, ValuePath="Population" };
			layer.BubbleMarkerSetting = marker;
			maps.Layers.Add (layer);
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
			handler.PostDelayed(run, 100);

			return layout;
		}

		public JSONArray GetDataSource()
		{
			var array = new JSONArray ();

		
			array.Put(new JSONObject().Put("Country","Brazil").Put("Population",204436000).Put("ShortName","Brazil"));
			array.Put(new JSONObject().Put("Country","United States").Put("Population",321174000).Put("ShortName","USA"));
			array.Put(new JSONObject().Put("Country","Russia").Put("Population",146267288).Put("ShortName","RUS"));
			array.Put(new JSONObject().Put("Country","India").Put("Population",1272470000).Put("ShortName","IND"));
			array.Put(new JSONObject().Put("Country","China").Put("Population",1370320000).Put("ShortName","CHI"));
			array.Put(new JSONObject().Put("Country","Indonesia").Put("Population",255461700).Put("ShortName","INO"));

			return array;
		}
	}
}


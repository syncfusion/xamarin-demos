#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Maps;
using Com.Syncfusion.Sfbusyindicator;
using Com.Syncfusion.Sfbusyindicator.Enums;
using Org.Json;

namespace SampleBrowser
{
    public class Sublayer : SamplePage
    {
        SfMaps maps;
        Handler handler;
        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            handler = new Handler();
            LinearLayout layout = new LinearLayout(context);
            layout.Orientation = Orientation.Vertical;
            TextView textView = new TextView(context);
            textView.TextSize = 16;
            textView.SetPadding(10, 20, 0, 0);
            textView.SetHeight(90);

            textView.Text = "Samsung Semiconductor office location in USA";
            layout.AddView(textView);
            textView.Gravity = Android.Views.GravityFlags.Top;
            maps = new SfMaps(context);
            ShapeFileLayer layer = new ShapeFileLayer();
            layer.ShowItems = true;
            layer.Uri = "usa_state.shp";
            layer.DataSource = GetDataSource();
            layer.ShapeIdPath = "Name";
            layer.ShapeIdTableField = "STATE_NAME";
            layer.DataLabelSettings = new DataLabelSetting() { TextColor = Color.Black };
            layer.ShapeSettings = new ShapeSetting();
            layer.ShapeSettings.ShapeValuePath = "Type";
            layer.ShapeSettings.ShapeFill = Color.ParseColor("#E5E5E5");
            layer.ShapeSettings.ShapeStroke = Color.ParseColor("#D0D0D0");
            layer.ShapeSettings.ShapeStrokeThickess = 2;

            layer.DataLabelSettings.IntersectionAction = IntersectAction.Trim;

            SubShapeFileLayer subLayer = new SubShapeFileLayer();
            subLayer.Uri = "Texas.shp";
            subLayer.ShapeSettings.ShapeFill = Color.ParseColor("#B1D8F5");
            subLayer.ShapeSettings.ShapeStroke = Color.ParseColor("#8DCCF4");
            subLayer.ShapeSettings.ShapeStrokeThickess = 1;

            MapMarker mapMarker = new MapMarker();
            mapMarker.Latitude = 30.267153;
            mapMarker.Longitude = -97.7430608;
            subLayer.Markers.Add(mapMarker);

            MarkerSetting markerSetting = new MarkerSetting();
            markerSetting.MarkerIconColor = Color.DarkGreen;
            markerSetting.IconSize = 7;
            subLayer.MarkerSetting = markerSetting;

            SubShapeFileLayer subLayer1 = new SubShapeFileLayer();
            subLayer1.Uri = "California.shp";
            subLayer1.ShapeSettings.ShapeFill = Color.ParseColor("#B1D8F5");
            subLayer1.ShapeSettings.ShapeStroke = Color.ParseColor("#8DCCF4");
            subLayer1.ShapeSettings.ShapeStrokeThickess = 1;

            MapMarker mapMarker1 = new MapMarker();
            mapMarker1.Latitude = 37.3382082;
            mapMarker1.Longitude = -121.8863286;
            subLayer1.Markers.Add(mapMarker1);

            MarkerSetting markerSetting1 = new MarkerSetting();
            markerSetting1.MarkerIconColor = Color.DarkGreen;
            markerSetting1.IconSize = 7;
            subLayer1.MarkerSetting = markerSetting1;

            layer.SubShapeFileLayers.Add(subLayer);
            layer.SubShapeFileLayers.Add(subLayer1);

            maps.Layers.Add(layer);

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
            JSONArray array = new JSONArray();

            array.Put(getJsonObject("Alabama", "AL", 9));
            array.Put(getJsonObject("Alaska", "AK", 3));
            array.Put(getJsonObject("Arizona", "AR", 11));
            array.Put(getJsonObject("Arkansas", "AN", 6));
            array.Put(getJsonObject("California", "CA", 55));
            array.Put(getJsonObject("Colorado", "CO", 9));
            array.Put(getJsonObject("Connecticut", "CN", 7));
            array.Put(getJsonObject("Delaware", "DE", 3));
            array.Put(getJsonObject("District of Columbia", "DC", 3));
            array.Put(getJsonObject("Florida", "FL", 29));
            array.Put(getJsonObject("Georgia", "GE", 16));
            array.Put(getJsonObject("Hawaii", "HA", 4));
            array.Put(getJsonObject("Idaho", "ID", 4));
            array.Put(getJsonObject("Illinois", "IL", 20));
            array.Put(getJsonObject("Indiana", "IN", 11));
            array.Put(getJsonObject("Iowa", "IO", 6));
            array.Put(getJsonObject("Kansas", "KA", 6));
            array.Put(getJsonObject("Kentucky", "KE", 8));
            array.Put(getJsonObject("Louisiana", "LO", 8));
            array.Put(getJsonObject("Maine", "MA", 4));
            array.Put(getJsonObject("Maryland", "MY", 10));
            array.Put(getJsonObject("Massachusetts", "MS", 11));
            array.Put(getJsonObject("Michigan", "MI", 16));
            array.Put(getJsonObject("Minnesota", "MN", 10));
            array.Put(getJsonObject("Mississippi", "MP", 6));
            array.Put(getJsonObject("Missouri", "MO", 10));
            array.Put(getJsonObject("Montana", "MT", 3));
            array.Put(getJsonObject("Nebraska", "NE", 5));
            array.Put(getJsonObject("Nevada", "NV", 6));
            array.Put(getJsonObject("New Hampshire", "NH", 4));
            array.Put(getJsonObject("New Jersey", "NJ", 14));
            array.Put(getJsonObject("New Mexico", "NM", 5));
            array.Put(getJsonObject("New York", "NY", 29));
            array.Put(getJsonObject("North Carolina", "NC", 15));
            array.Put(getJsonObject("North Dakota", "ND", 3));
            array.Put(getJsonObject("Ohio", "OH", 18));
            array.Put(getJsonObject("Oklahoma", "OK", 7));
            array.Put(getJsonObject("Oregon", "OR", 7));
            array.Put(getJsonObject("Pennsylvania", "PE", 20));
            array.Put(getJsonObject("Rhode Island", "RH", 4));
            array.Put(getJsonObject("South Carolina", "SC", 9));
            array.Put(getJsonObject("South Dakota", "SD", 3));
            array.Put(getJsonObject("Tennessee", "TE", 11));
            array.Put(getJsonObject("Texas", "TX", 38));
            array.Put(getJsonObject("Utah", "UT", 6));
            array.Put(getJsonObject("Vermont", "VE", 3));
            array.Put(getJsonObject("Virginia", "VI", 13));
            array.Put(getJsonObject("Washington", "WA", 12));
            array.Put(getJsonObject("West Virginia", "WV", 5));
            array.Put(getJsonObject("Wisconsin", "WI", 10));
            array.Put(getJsonObject("Wyoming", "WY", 3));
            return array;
        }

        JSONObject getJsonObject(String name, String type, double count)
        {
            JSONObject obj = new JSONObject();
            obj.Put("Name", name);
            obj.Put("Type", type);
            return obj;
        }
    }
}
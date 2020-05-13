#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

            textView.Text = "Rivers in Australia";
            layout.AddView(textView);
            textView.Gravity = Android.Views.GravityFlags.Top;
            maps = new SfMaps(context);

            ShapeFileLayer layer = new ShapeFileLayer();
            layer.Uri = "australia.shp";
            layer.ShapeSettings.ShapeFill = Color.ParseColor("#ACF9F7");
            layer.ShapeSettings.ShapeStrokeThickess = 1;
            maps.Layers.Add(layer);

            SubShapeFileLayer subLayer = new SubShapeFileLayer();
            subLayer.Uri = "river.shp";
            subLayer.ShapeSettings.ShapeFill = Color.ParseColor("#00A8CC");
            subLayer.ShapeSettings.ShapeStrokeThickess = 2;
            layer.SubShapeFileLayers.Add(subLayer);
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

    }
}
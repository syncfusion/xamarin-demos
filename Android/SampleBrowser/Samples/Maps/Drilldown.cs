#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Com.Syncfusion.Maps;
using Org.Json;
using System.Collections.Generic;
using Android.Graphics;
using Android.Widget;
using Android.OS;
using Com.Syncfusion.Sfbusyindicator;
using Com.Syncfusion.Sfbusyindicator.Enums;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class Drilldown : SamplePage
    {
        SfMaps maps;
        Handler handler;
        TextView text;
        TextView text1;
        TextView text2;
        TextView text3;
        LinearLayout layout;
        ShapeFileLayer layer;
        LinearLayout linearLayout;
        LinearLayout linearLayout1;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            handler = new Handler();
            layout = new LinearLayout(context);
            linearLayout1 = new LinearLayout(context);
            linearLayout = new LinearLayout(context);

            linearLayout.Visibility = Android.Views.ViewStates.Invisible;
            text = new TextView(context);
            text.TextSize = 16;
            text.SetPadding(10, 20, 0, 0);
            text.SetHeight(90);
            text.Text = "WorldMap";
            text.SetTextColor(Color.Blue);

            text.Click += Text_Click;

            linearLayout.AddView(text);

            text3 = new TextView(context);
            text3.TextSize = 16;
            text3.SetPadding(10, 20, 0, 0);
            text3.Text = "Click on a shape to drill";
            text3.TextAlignment = Android.Views.TextAlignment.Center;

            linearLayout1.AddView(text3);

            text1 = new TextView(context);
            text1.Text = ">>";
            text1.SetPadding(10, 20, 0, 0);
            linearLayout.AddView(text1);

            text2 = new TextView(context);
            linearLayout.AddView(text2);

            layout.Orientation = Orientation.Vertical;
            maps = new SfMaps(context);
            maps.EnableZooming = false;
            layer = new ShapeFileLayer();
            layer.Uri = "world-map.shp";
            layer.EnableSelection = true;
            layer.ShapeIdTableField = "admin";
            layer.ShapeIdPath = "country";
            layer.DataSource = GetDataSource();
            layer.ShapeSettings.ShapeColorValuePath = "continent";
            layer.ShapeSelected += (object sender, ShapeFileLayer.ShapeSelectedEventArgs e) =>
            {
                JSONObject data = (JSONObject)e.P0;
                if (data != null)
                {
                    var dat = data.Get("continent").ToString();
                    text2.Text = dat;
                    linearLayout.Visibility = Android.Views.ViewStates.Visible;
                    linearLayout1.Visibility = Android.Views.ViewStates.Invisible;

                    if (dat == "South America")
                    {
                        maps.BaseMapIndex = 1;
                        layer.ShapeSettings.SelectedShapeColor = Color.ParseColor("#9C3367");
                    }
                    else if (dat == "North America")
                    {
                        maps.BaseMapIndex = 2;
                        layer.ShapeSettings.SelectedShapeColor = Color.ParseColor("#C13664");
                    }
                    else if (dat == "Europe")
                    {
                        maps.BaseMapIndex = 3;
                        layer.ShapeSettings.SelectedShapeColor = Color.ParseColor("#622D6C");
                    }
                    else if (dat == "Africa")
                    {
                        maps.BaseMapIndex = 4;
                        layer.ShapeSettings.SelectedShapeColor = Color.ParseColor("#80306A");
                    }
                    else if (dat == "Australia")
                    {
                        maps.BaseMapIndex = 5;
                        layer.ShapeSettings.SelectedShapeColor = Color.ParseColor("#2A2870");
                    }
                    else if (dat == "Asia")
                    {
                        maps.BaseMapIndex = 6;
                        layer.ShapeSettings.SelectedShapeColor = Color.ParseColor("#462A6D");
                    }
                }
            };

            SetColorMapping(layer.ShapeSettings);

            CustomMarker mapMarker = new CustomMarker(context);
            mapMarker.Label = "Asia";
            mapMarker.Latitude = 63.34303378997662;
            mapMarker.Longitude = 102.07617561287645;
            layer.Markers.Add(mapMarker);

            CustomMarker mapMarker1 = new CustomMarker(context);
            mapMarker1.Label = "Australia";
            mapMarker1.Latitude = -25.74775493367931;
            mapMarker1.Longitude = 136.80451417932431;
            layer.Markers.Add(mapMarker1);

            CustomMarker mapMarker2 = new CustomMarker(context);
            mapMarker2.Label = "Africa";
            mapMarker2.Latitude = 19.025302093442327;
            mapMarker2.Longitude = 15.157534554671087;
            layer.Markers.Add(mapMarker2);

            CustomMarker mapMarker3 = new CustomMarker(context);
            mapMarker3.Label = "North America";
            mapMarker3.Latitude = 59.88893689676585;
            mapMarker3.Longitude = -109.3359375;
            layer.Markers.Add(mapMarker3);

            CustomMarker mapMarker4 = new CustomMarker(context);
            mapMarker4.Label = "Europe";
            mapMarker4.Latitude = 47.95121990866204;
            mapMarker4.Longitude = 18.468749999999998;
            layer.Markers.Add(mapMarker4);

            CustomMarker mapMarker5 = new CustomMarker(context);
            mapMarker5.Label = "South America";
            mapMarker5.Latitude = -6.64607562172573;
            mapMarker5.Longitude = -55.54687499999999;
            layer.Markers.Add(mapMarker5);

            maps.Layers.Add(layer);

            ShapeFileLayer layer1 = new ShapeFileLayer();
            layer1.ShapeIdPath = "country";
            layer1.ShapeIdTableField = "admin";
            layer1.Uri = "south-america.shp";
            layer1.ShapeSettings.ShapeFill = Color.ParseColor("#9C3367");
            maps.Layers.Add(layer1);

            ShapeFileLayer layer2 = new ShapeFileLayer();
            layer2.ShapeIdPath = "country";
            layer2.ShapeIdTableField = "admin";
            layer2.Uri = "north-america.shp";
            layer2.ShapeSettings.ShapeFill = Color.ParseColor("#C13664");
            maps.Layers.Add(layer2);

            ShapeFileLayer layer3 = new ShapeFileLayer();
            layer3.ShapeIdPath = "country";
            layer3.ShapeIdTableField = "admin";
            layer3.Uri = "europe.shp";
            layer3.ShapeSettings.ShapeFill = Color.ParseColor("#622D6C");
            maps.Layers.Add(layer3);

            ShapeFileLayer layer4 = new ShapeFileLayer();
            layer4.ShapeIdPath = "country";
            layer4.ShapeIdTableField = "admin";
            layer4.Uri = "africa.shp";
            layer4.ShapeSettings.ShapeFill = Color.ParseColor("#80306A");
            maps.Layers.Add(layer4);

            ShapeFileLayer layer5 = new ShapeFileLayer();
            layer5.ShapeIdPath = "country";
            layer5.ShapeIdTableField = "admin";
            layer5.Uri = "australia.shp";
            layer5.ShapeSettings.ShapeFill = Color.ParseColor("#2A2870");
            maps.Layers.Add(layer5);

            ShapeFileLayer layer6 = new ShapeFileLayer();
            layer6.ShapeIdPath = "country";
            layer6.ShapeIdTableField = "admin";
            layer6.Uri = "asia.shp";
            layer6.ShapeSettings.ShapeFill = Color.ParseColor("#462A6D");
            maps.Layers.Add(layer6);

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
                layout.AddView(linearLayout);
                layout.AddView(linearLayout1);
                layout.AddView(maps);

            });

            handler.PostDelayed(run, 100);

            return layout;
        }

        private void Text_Click(object sender, EventArgs e)
        {
            maps.BaseMapIndex = 0;
            linearLayout.Visibility = Android.Views.ViewStates.Invisible;
            linearLayout1.Visibility = Android.Views.ViewStates.Visible;
        }

        JSONArray GetDataSource()
        {
            JSONArray array = new JSONArray();

            array.Put(getJsonObject("Afghanistan", "Asia"));
            array.Put(getJsonObject("Angola", "Africa"));
            array.Put(getJsonObject("Albania", "Europe"));
            array.Put(getJsonObject("United Arab Emirates", "Asia"));
            array.Put(getJsonObject("Argentina", "South America"));
            array.Put(getJsonObject("Armenia", "Asia"));
            array.Put(getJsonObject("French Southern and Antarctic Lands", "Seven seas (open ocean)"));
            array.Put(getJsonObject("Australia", "Australia"));
            array.Put(getJsonObject("Austria", "Europe"));
            array.Put(getJsonObject("Azerbaijan", "Asia"));
            array.Put(getJsonObject("Burundi", "Africa"));
            array.Put(getJsonObject("Belgium", "Europe"));
            array.Put(getJsonObject("Benin", "Africa"));
            array.Put(getJsonObject("Burkina Faso", "Africa"));
            array.Put(getJsonObject("Bangladesh", "Asia"));
            array.Put(getJsonObject("Bulgaria", "Europe"));
            array.Put(getJsonObject("The Bahamas", "North America"));
            array.Put(getJsonObject("Bosnia and Herzegovina", "Europe"));
            array.Put(getJsonObject("Belarus", "Europe"));
            array.Put(getJsonObject("Belize", "North America"));
            array.Put(getJsonObject("Bolivia", "South America"));
            array.Put(getJsonObject("Brazil", "South America"));
            array.Put(getJsonObject("Brunei", "Asia"));
            array.Put(getJsonObject("Bhutan", "Asia"));
            array.Put(getJsonObject("Botswana", "Africa"));
            array.Put(getJsonObject("Central African Republic", "Africa"));
            array.Put(getJsonObject("Canada", "North America"));
            array.Put(getJsonObject("Switzerland", "Europe"));
            array.Put(getJsonObject("Chile", "South America"));
            array.Put(getJsonObject("China", "Asia"));
            array.Put(getJsonObject("Ivory Coast", "Africa"));
            array.Put(getJsonObject("Cameroon", "Africa"));
            array.Put(getJsonObject("Democratic Republic of the Congo", "Africa"));
            array.Put(getJsonObject("Republic of Congo", "Africa"));
            array.Put(getJsonObject("Colombia", "South America"));
            array.Put(getJsonObject("Costa Rica", "North America"));
            array.Put(getJsonObject("Cuba", "North America"));
            array.Put(getJsonObject("Northern Cyprus", "Asia"));
            array.Put(getJsonObject("Cyprus", "Asia"));
            array.Put(getJsonObject("Czech Republic", "Europe"));
            array.Put(getJsonObject("Germany", "Europe"));
            array.Put(getJsonObject("Djibouti", "Africa"));
            array.Put(getJsonObject("Denmark", "Europe"));
            array.Put(getJsonObject("Dominican Republic", "North America"));
            array.Put(getJsonObject("Algeria", "Africa"));
            array.Put(getJsonObject("Ecuador", "South America"));
            array.Put(getJsonObject("Egypt", "Africa"));
            array.Put(getJsonObject("Eritrea", "Africa"));
            array.Put(getJsonObject("Spain", "Europe"));
            array.Put(getJsonObject("Estonia", "Europe"));
            array.Put(getJsonObject("Ethiopia", "Africa"));
            array.Put(getJsonObject("Finland", "Europe"));
            array.Put(getJsonObject("Fiji", "Australia"));
            array.Put(getJsonObject("Falkland Islands", "South America"));
            array.Put(getJsonObject("France", "Europe"));
            array.Put(getJsonObject("Gabon", "Africa"));
            array.Put(getJsonObject("United Kingdom", "Europe"));
            array.Put(getJsonObject("Georgia", "Asia"));
            array.Put(getJsonObject("Ghana", "Africa"));
            array.Put(getJsonObject("Guinea", "Africa"));
            array.Put(getJsonObject("Gambia", "Africa"));
            array.Put(getJsonObject("Guinea Bissau", "Africa"));
            array.Put(getJsonObject("Equatorial Guinea", "Africa"));
            array.Put(getJsonObject("Greece", "Europe"));
            array.Put(getJsonObject("Greenland", "North America"));
            array.Put(getJsonObject("Guatemala", "North America"));
            array.Put(getJsonObject("Guyana", "South America"));
            array.Put(getJsonObject("Honduras", "North America"));
            array.Put(getJsonObject("Croatia", "Europe"));
            array.Put(getJsonObject("Haiti", "North America"));
            array.Put(getJsonObject("Hungary", "Europe"));
            array.Put(getJsonObject("Indonesia", "Asia"));
            array.Put(getJsonObject("India", "Asia"));
            array.Put(getJsonObject("Ireland", "Europe"));
            array.Put(getJsonObject("Iran", "Asia"));
            array.Put(getJsonObject("Iraq", "Asia"));
            array.Put(getJsonObject("Iceland", "Europe"));
            array.Put(getJsonObject("Israel", "Asia"));
            array.Put(getJsonObject("Italy", "Europe"));
            array.Put(getJsonObject("Jamaica", "North America"));
            array.Put(getJsonObject("Jordan", "Asia"));
            array.Put(getJsonObject("Japan", "Asia"));
            array.Put(getJsonObject("Kazakhstan", "Asia"));
            array.Put(getJsonObject("Kenya", "Africa"));
            array.Put(getJsonObject("Kyrgyzstan", "Asia"));
            array.Put(getJsonObject("Cambodia", "Asia"));
            array.Put(getJsonObject("South Korea", "Asia"));
            array.Put(getJsonObject("Kosovo", "Europe"));
            array.Put(getJsonObject("Kuwait", "Asia"));
            array.Put(getJsonObject("Laos", "Asia"));
            array.Put(getJsonObject("Lebanon", "Asia"));
            array.Put(getJsonObject("Liberia", "Africa"));
            array.Put(getJsonObject("Libya", "Africa"));
            array.Put(getJsonObject("Sri Lanka", "Asia"));
            array.Put(getJsonObject("Lesotho", "Africa"));
            array.Put(getJsonObject("Lithuania", "Europe"));
            array.Put(getJsonObject("Luxembourg", "Europe"));
            array.Put(getJsonObject("Latvia", "Europe"));
            array.Put(getJsonObject("Morocco", "Africa"));
            array.Put(getJsonObject("Moldova", "Europe"));
            array.Put(getJsonObject("Madagascar", "Africa"));
            array.Put(getJsonObject("Mexico", "North America"));
            array.Put(getJsonObject("Macedonia", "Europe"));
            array.Put(getJsonObject("Mali", "Africa"));
            array.Put(getJsonObject("Myanmar", "Asia"));
            array.Put(getJsonObject("Montenegro", "Europe"));
            array.Put(getJsonObject("Mongolia", "Asia"));
            array.Put(getJsonObject("Mozambique", "Africa"));
            array.Put(getJsonObject("Mauritania", "Africa"));
            array.Put(getJsonObject("Malawi", "Africa"));
            array.Put(getJsonObject("Malaysia", "Asia"));
            array.Put(getJsonObject("Namibia", "Africa"));
            array.Put(getJsonObject("New Caledonia", "Australia"));
            array.Put(getJsonObject("Niger", "Africa"));
            array.Put(getJsonObject("Nigeria", "Africa"));
            array.Put(getJsonObject("Nicaragua", "North America"));
            array.Put(getJsonObject("Netherlands", "Europe"));
            array.Put(getJsonObject("Norway", "Europe"));
            array.Put(getJsonObject("Nepal", "Asia"));
            array.Put(getJsonObject("New Zealand", "Australia"));
            array.Put(getJsonObject("Oman", "Asia"));
            array.Put(getJsonObject("Pakistan", "Asia"));
            array.Put(getJsonObject("Panama", "North America"));
            array.Put(getJsonObject("Peru", "South America"));
            array.Put(getJsonObject("Philippines", "Asia"));
            array.Put(getJsonObject("Papua New Guinea", "Australia"));
            array.Put(getJsonObject("Poland", "Europe"));
            array.Put(getJsonObject("Puerto Rico", "North America"));
            array.Put(getJsonObject("North Korea", "Asia"));
            array.Put(getJsonObject("Portugal", "Europe"));
            array.Put(getJsonObject("Paraguay", "South America"));
            array.Put(getJsonObject("Palestine", "Asia"));
            array.Put(getJsonObject("Qatar", "Asia"));
            array.Put(getJsonObject("Romania", "Europe"));
            array.Put(getJsonObject("Russia", "Asia"));
            array.Put(getJsonObject("Rwanda", "Africa"));
            array.Put(getJsonObject("Western Sahara", "Africa"));
            array.Put(getJsonObject("Saudi Arabia", "Asia"));
            array.Put(getJsonObject("Sudan", "Africa"));
            array.Put(getJsonObject("South Sudan", "Africa"));
            array.Put(getJsonObject("Senegal", "Africa"));
            array.Put(getJsonObject("Solomon Islands", "Australia"));
            array.Put(getJsonObject("Sierra Leone", "Africa"));
            array.Put(getJsonObject("El Salvador", "North America"));
            array.Put(getJsonObject("Somaliland", "Africa"));
            array.Put(getJsonObject("Somalia", "Africa"));
            array.Put(getJsonObject("Republic of Serbia", "Europe"));
            array.Put(getJsonObject("Suriname", "South America"));
            array.Put(getJsonObject("Slovakia", "Europe"));
            array.Put(getJsonObject("Slovenia", "Europe"));
            array.Put(getJsonObject("Sweden", "Europe"));
            array.Put(getJsonObject("Swaziland", "Africa"));
            array.Put(getJsonObject("Syria", "Asia"));
            array.Put(getJsonObject("Chad", "Africa"));
            array.Put(getJsonObject("Togo", "Africa"));
            array.Put(getJsonObject("Thailand", "Asia"));
            array.Put(getJsonObject("Tajikistan", "Asia"));
            array.Put(getJsonObject("Turkmenistan", "Asia"));
            array.Put(getJsonObject("East Timor", "Asia"));
            array.Put(getJsonObject("Trinidad and Tobago", "North America"));
            array.Put(getJsonObject("Tunisia", "Africa"));
            array.Put(getJsonObject("Turkey", "Asia"));
            array.Put(getJsonObject("Taiwan", "Asia"));
            array.Put(getJsonObject("United Republic of Tanzania", "Africa"));
            array.Put(getJsonObject("Uganda", "Africa"));
            array.Put(getJsonObject("Ukraine", "Europe"));
            array.Put(getJsonObject("Uruguay", "South America"));
            array.Put(getJsonObject("United States of America", "North America"));
            array.Put(getJsonObject("Uzbekistan", "Asia"));
            array.Put(getJsonObject("Venezuela", "South America"));
            array.Put(getJsonObject("Vietnam", "Asia"));
            array.Put(getJsonObject("Vanuatu", "Australia"));
            array.Put(getJsonObject("Yemen", "Asia"));
            array.Put(getJsonObject("South Africa", "Africa"));
            array.Put(getJsonObject("Zambia", "Africa"));
            array.Put(getJsonObject("Zimbabwe", "Africa"));

            return array;
        }

        JSONObject getJsonObject(String name, String type)
        {
            JSONObject obj = new JSONObject();
            obj.Put("country", name);
            obj.Put("continent", type);
            return obj;
        }

        void SetColorMapping(ShapeSetting setting)
        {
            List<ColorMapping> colorMappings = new List<ColorMapping>();

            EqualColorMapping colorMapping2 = new EqualColorMapping();
            colorMapping2.Value = "North America";
            colorMapping2.Color = Color.ParseColor("#C13664");
            colorMappings.Add(colorMapping2);

            EqualColorMapping colorMapping3 = new EqualColorMapping();
            colorMapping3.Value = "South America";
            colorMapping3.Color = Color.ParseColor("#9C3367");
            colorMappings.Add(colorMapping3);

            EqualColorMapping colorMapping4 = new EqualColorMapping();
            colorMapping4.Value = "Africa";
            colorMapping4.Color = Color.ParseColor("#80306A");
            colorMappings.Add(colorMapping4);

            EqualColorMapping colorMapping1 = new EqualColorMapping();
            colorMapping1.Value = "Europe";
            colorMapping1.Color = Color.ParseColor("#622D6C");
            colorMappings.Add(colorMapping1);

            EqualColorMapping colorMapping5 = new EqualColorMapping();
            colorMapping5.Value = "Asia";
            colorMapping5.Color = Color.ParseColor("#462A6D");
            colorMappings.Add(colorMapping5);

            EqualColorMapping colorMapping6 = new EqualColorMapping();
            colorMapping6.Value = "Australia";
            colorMapping6.Color = Color.ParseColor("#2A2870");
            colorMappings.Add(colorMapping6);

            setting.ColorMapping = colorMappings;
        }
    }

    public class CustomMarker : MapMarker
    {
        Android.Content.Context context;
        public CustomMarker(Android.Content.Context con)
        {
            context = con;
        }

        public override void DrawMarker(PointF p0, Canvas p1)
        {
            float density = context.Resources.DisplayMetrics.Density / 1.5f;

            Paint paint = new Paint();
            paint.Color = Color.ParseColor("#bee8a2");
            paint.TextSize = 15 * density;

            var labels = Label.Split(' ', '\t');

            for (int i = 0; i < labels.Length; i++)
            {
                p1.DrawText(labels[i], (float)p0.X - (paint.TextSize * density), (float)p0.Y + density, paint);
                p0.Y += paint.TextSize;
            }
        }
    }
}
#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Android.Views;
using Android.Content;

namespace SampleBrowser
{
    public class BubbleVisualization : SamplePage
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

            textView.Text = "Top 40 countries population";
            layout.AddView(textView);
            textView.Gravity = Android.Views.GravityFlags.Top;
            maps = new SfMaps(context);

            ShapeFileLayer layer = new ShapeFileLayer();
            layer.ShowItems = true;
            layer.Uri = "world1.shp";
            layer.DataSource = GetDataSource();
            layer.ShapeIdPath = "Country";
            layer.ShowItems = true;
            layer.ShapeIdTableField = "NAME";

            layer.ShapeSettings = new ShapeSetting();
            layer.ShapeSettings.ShapeFill = Color.LightGray;

            BubbleMarkerSetting marker = new BubbleMarkerSetting();
            marker.ValuePath = "Population";
            marker.ColorValuePath = "Population";
			
			BubbleCustomTooltipSetting tooltipSetting = new BubbleCustomTooltipSetting(context);
            tooltipSetting.ShowTooltip = true;
            tooltipSetting.ValuePath = "Country";
            marker.TooltipSettings = tooltipSetting;

            RangeColorMapping rangeColorMapping = new RangeColorMapping();
            rangeColorMapping.Color = Color.ParseColor("#2E769F");
            rangeColorMapping.To = 1400000000;
            rangeColorMapping.From = 325000000;
            rangeColorMapping.LegendLabel = "Above 4%";
            marker.ColorMapping.Add(rangeColorMapping);

            RangeColorMapping rangeColorMapping1 = new RangeColorMapping();
            rangeColorMapping1.Color = Color.ParseColor("#D84444");
            rangeColorMapping1.To = 325000000;
            rangeColorMapping1.From = 180000000;
            rangeColorMapping1.LegendLabel = "4% - 2%";
            marker.ColorMapping.Add(rangeColorMapping1);

            RangeColorMapping rangeColorMapping2 = new RangeColorMapping();
            rangeColorMapping2.Color = Color.ParseColor("#816F28");
            rangeColorMapping2.To = 180000000;
            rangeColorMapping2.From = 100000000;
            rangeColorMapping2.LegendLabel = "2% - 1%";
            marker.ColorMapping.Add(rangeColorMapping2);

            RangeColorMapping rangeColorMapping3 = new RangeColorMapping();
            rangeColorMapping3.Color = Color.ParseColor("#7F38A0");
            rangeColorMapping3.To = 100000000;
            rangeColorMapping3.From = 5000000;
            rangeColorMapping3.LegendLabel = "Below 1%";
            marker.ColorMapping.Add(rangeColorMapping3);

            layer.BubbleMarkerSetting = marker;

            LegendSetting legendSetting = new LegendSetting();
            legendSetting.ShowLegend = true;
            legendSetting.LegendType = LegendType.Bubbles;
            legendSetting.IconHeight = 15;
            legendSetting.IconWidth = 15;
            legendSetting.LegendPosition = new Point(50, 5);
            legendSetting.HorizontalAlignment = HorizontalAlignment.Center;
            layer.LegendSetting = legendSetting;

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
            var array = new JSONArray();

            array.Put(new JSONObject().Put("Country", "China").Put("Population", 1393730000).Put("Percent", 18.2));
            array.Put(new JSONObject().Put("Country", "India").Put("Population", 1336180000).Put("Percent", 17.5));
            array.Put(new JSONObject().Put("Country", "United States").Put("Population", 327726000).Put("Percent", 4.29));
            array.Put(new JSONObject().Put("Country", "Indonesia").Put("Population", 265015300).Put("Percent", 3.47));
            array.Put(new JSONObject().Put("Country", "Pakistan").Put("Population", 209503000).Put("Percent", 2.78));
            array.Put(new JSONObject().Put("Country", "Brazil").Put("Population", 201795000).Put("Percent", 2.74));
            array.Put(new JSONObject().Put("Country", "Nigeria").Put("Population", 197306006).Put("Percent", 2.53));
            array.Put(new JSONObject().Put("Country", "Bangladesh").Put("Population", 165086000).Put("Percent", 2.16));
            array.Put(new JSONObject().Put("Country", "Russia").Put("Population", 146877088).Put("Percent", 1.92));
            array.Put(new JSONObject().Put("Country", "Japan").Put("Population", 126490000).Put("Percent", 1.66));
            array.Put(new JSONObject().Put("Country", "Mexico").Put("Population", 124737789).Put("Percent", 1.63));
            array.Put(new JSONObject().Put("Country", "Ethiopia").Put("Population", 107534882).Put("Percent", 1.41));
            array.Put(new JSONObject().Put("Country", "Philippines").Put("Population", 106375000).Put("Percent", 1.39));
            array.Put(new JSONObject().Put("Country", "Egypt").Put("Population", 97459100).Put("Percent", 1.27));
            array.Put(new JSONObject().Put("Country", "Vietnam").Put("Population", 94660000).Put("Percent", 1.24));
            array.Put(new JSONObject().Put("Country", "Germany").Put("Population", 82740900).Put("Percent", 1.08));
            array.Put(new JSONObject().Put("Country", "Iran").Put("Population", 81737800).Put("Percent", 1.07));
            array.Put(new JSONObject().Put("Country", "Turkey").Put("Population", 80810525).Put("Percent", 1.06));
            array.Put(new JSONObject().Put("Country", "Thailand").Put("Population", 69183173).Put("Percent", 0.91));
            array.Put(new JSONObject().Put("Country", "France").Put("Population", 67297000).Put("Percent", 0.88));
            array.Put(new JSONObject().Put("Country", "United Kingdom").Put("Population", 66040229).Put("Percent", 0.86));
            array.Put(new JSONObject().Put("Country", "Italy").Put("Population", 60436469).Put("Percent", 0.79));
            array.Put(new JSONObject().Put("Country", "South Africa").Put("Population", 57725600).Put("Percent", 0.76));
            array.Put(new JSONObject().Put("Country", "Colombia").Put("Population", 49918600).Put("Percent", 0.65));
            array.Put(new JSONObject().Put("Country", "Spain").Put("Population", 46659302).Put("Percent", 0.61));
            array.Put(new JSONObject().Put("Country", "Argentina").Put("Population", 44494502).Put("Percent", 0.58));
            array.Put(new JSONObject().Put("Country", "Poland").Put("Population", 38433600).Put("Percent", 0.5));
            array.Put(new JSONObject().Put("Country", "Canada").Put("Population", 37206700).Put("Percent", 0.48));
            array.Put(new JSONObject().Put("Country", "Saudi Arabia").Put("Population", 33413660).Put("Percent", 0.44));
            array.Put(new JSONObject().Put("Country", "Malaysia").Put("Population", 32647000).Put("Percent", 0.42));
            array.Put(new JSONObject().Put("Country", "Nepal").Put("Population", 29218867).Put("Percent", 0.38));
            array.Put(new JSONObject().Put("Country", "Australia").Put("Population", 25015400).Put("Percent", 0.32));
            array.Put(new JSONObject().Put("Country", "Kazakhstan").Put("Population", 18253300).Put("Percent", 0.24));
            array.Put(new JSONObject().Put("Country", "Cambodia").Put("Population", 16069921).Put("Percent", 0.21));
            array.Put(new JSONObject().Put("Country", "Belgium").Put("Population", 11414214).Put("Percent", 0.15));
            array.Put(new JSONObject().Put("Country", "Greece").Put("Population", 10768193).Put("Percent", 0.14));
            array.Put(new JSONObject().Put("Country", "Sweden").Put("Population", 10171524).Put("Percent", 0.13));
            array.Put(new JSONObject().Put("Country", "Somalia").Put("Population", 15181925).Put("Percent", 0.12));
            array.Put(new JSONObject().Put("Country", "Austria").Put("Population", 8830487).Put("Percent", 0.12));
            array.Put(new JSONObject().Put("Country", "Bulgaria").Put("Population", 7050034).Put("Percent", 0.092));

            return array;
        }
    }

    public class BubbleCustomTooltipSetting : TooltipSetting
    {
        Context context;
        public BubbleCustomTooltipSetting(Context con)
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
            topLabel.Text = ((JSONObject)shapeData).GetString("Country");
            topLabel.TextSize = 12;
            topLabel.SetTextColor(Color.ParseColor("#FFFFFF"));
            topLabel.Gravity = GravityFlags.CenterHorizontal;

            TextView bottoLabel = new TextView(context);
            bottoLabel.Text = ((JSONObject)shapeData).GetString("Percent") + "%";
            bottoLabel.TextSize = 12;
            bottoLabel.SetTextColor(Color.ParseColor("#FFFFFF"));
            bottoLabel.Gravity = GravityFlags.CenterHorizontal;

            layout.AddView(topLabel);
            layout.AddView(bottoLabel);
                        
            return layout;
        }
    }
}
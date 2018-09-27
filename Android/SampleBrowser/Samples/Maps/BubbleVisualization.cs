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
using Android.Views;
using Android.Content;

namespace SampleBrowser
{
    public class BubbleVisualization : SamplePage
    {
        SfMaps maps;
        Handler handler;
        FrameLayout frameLayout;
        Context sampleContext;
        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            handler = new Handler();
            frameLayout = new FrameLayout(context);
            frameLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
              ViewGroup.LayoutParams.MatchParent);

            LinearLayout linearLayout = new LinearLayout(context);
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, Android.Views.ViewGroup.LayoutParams.MatchParent);

            sampleContext = context;

            LinearLayout layout = new LinearLayout(context);
            layout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.MatchParent);
            layout.Orientation = Orientation.Horizontal;
            layout.SetHorizontalGravity(GravityFlags.Center);
            TextView textView = new TextView(context);
            textView.TextSize = 16;
            textView.SetPadding(2, 2, 2, 2);
            textView.SetHeight(90);
            textView.Gravity = Android.Views.GravityFlags.Top;
            textView.Text = "Top 40 countries population";
            layout.AddView(textView);
            frameLayout.AddView(layout);

            maps = new SfMaps(context);
            maps.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, Android.Views.ViewGroup.LayoutParams.MatchParent);

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
            marker.ValuePath = "Percent";
            marker.ColorValuePath = "Percent";

            RangeColorMapping rangeColorMapping = new RangeColorMapping();
            rangeColorMapping.Color = Color.ParseColor("#2E769F");
            rangeColorMapping.From = 4;
            rangeColorMapping.To = 20;
            rangeColorMapping.LegendLabel = "Above 4%";
            marker.ColorMapping.Add(rangeColorMapping);

            RangeColorMapping rangeColorMapping1 = new RangeColorMapping();
            rangeColorMapping1.Color = Color.ParseColor("#D84444");
            rangeColorMapping1.From = 2;
            rangeColorMapping1.To = 4;
            rangeColorMapping1.LegendLabel = "4% - 2%";
            marker.ColorMapping.Add(rangeColorMapping1);

            RangeColorMapping rangeColorMapping2 = new RangeColorMapping();
            rangeColorMapping2.Color = Color.ParseColor("#816F28");
            rangeColorMapping2.From = 1;
            rangeColorMapping2.To = 2;
            rangeColorMapping2.LegendLabel = "2% - 1%";
            marker.ColorMapping.Add(rangeColorMapping2);

            RangeColorMapping rangeColorMapping3 = new RangeColorMapping();
            rangeColorMapping3.Color = Color.ParseColor("#7F38A0");
            rangeColorMapping3.From = 0;
            rangeColorMapping3.To = 1;
            rangeColorMapping3.LegendLabel = "Below 1%";
            marker.ColorMapping.Add(rangeColorMapping3);

            layer.BubbleMarkerSetting = marker;

            LegendSetting legendSetting = new LegendSetting();
            legendSetting.ShowLegend = true;
            legendSetting.LegendType = LegendType.Bubbles;
            legendSetting.LegendPosition = new Point(50, 10);
            legendSetting.ItemMargin = 15;
            layer.LegendSetting = legendSetting;

            maps.Layers.Add(layer);
            frameLayout.AddView(maps);

            frameLayout.SetClipChildren(false);

            LinearLayout linear = new LinearLayout(context);
            linear.Orientation = Orientation.Horizontal;
            linear.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.MatchParent);
            linear.SetHorizontalGravity(GravityFlags.End);
            linear.SetVerticalGravity(GravityFlags.Bottom);
            TextView textView1 = new TextView(context);
            textView1.Text = "Source:";
            textView1.SetBackgroundColor(Color.White);
            textView1.SetTextColor(Color.Black);
            textView1.SetPadding(2, 2, 2, 2);
            linear.AddView(textView1);
            TextView textView2 = new TextView(context);
            textView2.Text = "en.wikipedia.org";
            textView2.SetTextColor(Color.DeepSkyBlue);
            textView2.SetPadding(0, 2, 3, 2);
            textView2.SetBackgroundColor(Color.White);
            textView2.Clickable = true;
            textView2.Click += TextView2_Click;
            linear.AddView(textView2);
            frameLayout.AddView(linear);

            SfBusyIndicator sfBusyIndicator = new SfBusyIndicator(context);
            sfBusyIndicator.IsBusy = true;
            sfBusyIndicator.AnimationType = AnimationTypes.SlicedCircle;
            sfBusyIndicator.ViewBoxWidth = 50;
            sfBusyIndicator.ViewBoxHeight = 50;
            sfBusyIndicator.TextColor = Color.ParseColor("#779772");
            linearLayout.AddView(sfBusyIndicator);
            Java.Lang.Runnable run = new Java.Lang.Runnable(() =>
            {
                linearLayout.RemoveView(sfBusyIndicator);
                linearLayout.AddView(frameLayout);

            });
            handler.PostDelayed(run, 100);

            return linearLayout;
        }

        private void TextView2_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_population");
            var intent = new Intent(Intent.ActionView, uri);
            sampleContext.StartActivity(intent);
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
}
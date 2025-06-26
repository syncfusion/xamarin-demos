#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using Org.Json;


#endregion
using System;
using Android.Views;
using Android.Graphics;
using Com.Syncfusion.Treemap;
using System.Collections.Generic;
using Android.Widget;
using Com.Syncfusion.Treemap.Enums;
using Android.Content;
using Range = Com.Syncfusion.Treemap.Range;

namespace SampleBrowser
{
    public class FlatCollection : SamplePage
    {
        public FlatCollection()
        {
        }
        SfTreeMap tree;


        public override View GetSampleContent(Context context)
        {
            tree = new SfTreeMap(context);
            tree.WeightValuePath = "Population";
            tree.ColorValuePath = "Growth";
            tree.HighlightOnSelection = false;
            var margin = context.Resources.DisplayMetrics.Density * 20;
            float density = context.Resources.DisplayMetrics.Density;

            //LeafItemSetting
            tree.LeafItemSettings = new LeafItemSetting() { ShowLabels = true, Gap = 5, LabelPath = "Region", StrokeColor = Color.White, StrokeWidth = 2 };
            tree.LeafItemSettings.LabelStyle = new Style() { Margin = new Margin(margin / 2, margin, 0, 0), TextSize = 18, TextColor = Color.White };

            TreeMapFlatLevel level = new TreeMapFlatLevel { ShowHeader = true, GroupPath = "Continent", GroupStrokeColor = Color.Gray, GroupStrokeWidth = 1, GroupPadding = 5, HeaderHeight = 25 };
            level.HeaderStyle = new Style() { TextColor = Color.Gray, TextSize = 16 };

            tree.Levels.Add(level);

            //RangeColorMapping
            List<Range> ranges = new List<Range>();
            ranges.Add(new Range() { LegendLabel = "1 % Growth", From = 0, To = 1, Color = Color.ParseColor("#77D8D8") });
            ranges.Add(new Range() { LegendLabel = "2 % Growth", From = 0, To = 2, Color = Color.ParseColor("#AED960") });
            ranges.Add(new Range() { LegendLabel = "3 % Growth", From = 0, To = 3, Color = Color.ParseColor("#FFAF51") });
            ranges.Add(new Range() { LegendLabel = "4 % Growth", From = 0, To = 4, Color = Color.ParseColor("#F3D240") });
            tree.LeafItemColorMapping = new RangeColorMapping() { Ranges = ranges };

            //LegendSetting
            Size legendSize = new Size(300, 100);
            Size iconSize = new Size(12, 12);
            Color legendColor = Color.Gray;
            tree.LegendSettings = new LegendSetting()
            {
                LabelStyle = new Style()
                {
                    TextSize = 12,
                    TextColor = legendColor
                },
                IconSize = iconSize,
                ShowLegend = true,
                LegendSize = legendSize
            };
            tree.ShowTooltip = true;
            CustomTooltipSetting tooltip = new CustomTooltipSetting(context);
            tree.TooltipSettings = tooltip;
            tree.DataSource = GetDataSource();
            return tree;
        }

        JSONArray GetDataSource()
        {
            JSONArray array = new JSONArray();
            array.Put(getJsonObject("Asia", "Indonesia", 3, 237641326));
            array.Put(getJsonObject("Asia", "Russia", 2, 152518015));
            array.Put(getJsonObject("North America", "United States", 4, 315645000));
            array.Put(getJsonObject("North America", "Mexico", 2, 112336538));
            array.Put(getJsonObject("North America", "Canada", 1, 35056064));
            array.Put(getJsonObject("South America", "Colombia", 1, 47000000));
            array.Put(getJsonObject("South America", "Brazil", 3, 193946886));
            array.Put(getJsonObject("Africa", "Nigeria", 2, 170901000));
            array.Put(getJsonObject("Africa", "Egypt", 1, 83661000));
            array.Put(getJsonObject("Europe", "Germany", 1, 81993000));
            array.Put(getJsonObject("Europe", "France", 1, 65605000));
            array.Put(getJsonObject("Europe", "UK", 1, 63181775));
            return array;
        }

        JSONObject getJsonObject(String continent, String region, double growth, double population)
        {
            JSONObject obj = new JSONObject();

            obj.Put("Continent", continent);
            obj.Put("Region", region);
            obj.Put("Growth", growth);
            obj.Put("Population", population);

            return obj;

        }


    }

    public class CustomTooltipSetting : TooltipSetting
    {
        Context context;
        public CustomTooltipSetting(Context con)
        {
            context = con;
        }
        public override View GetView(object data, Context context)
        {
            LinearLayout layout = new LinearLayout(context);
            LinearLayout.LayoutParams linearlayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent,
                    LinearLayout.LayoutParams.WrapContent);
            layout.Orientation = Orientation.Vertical;
            layout.LayoutParameters = linearlayoutParams;
            layout.SetGravity(GravityFlags.CenterHorizontal);

            TextView topLabel = new TextView(context);
            topLabel.Text = ((JSONObject)data).GetString("Region");
            topLabel.TextSize = 12;
            topLabel.SetTextColor(Color.ParseColor("#FFFFFF"));
            topLabel.Gravity = GravityFlags.CenterHorizontal;

            TextView SplitLine = new TextView(context);
            SplitLine.Text = "-------";
            SplitLine.SetTextColor(Color.Gray);
            SplitLine.Gravity = GravityFlags.CenterHorizontal;


            TextView bottoLabel = new TextView(context);
            var growth = ((JSONObject)data).GetDouble("Growth");
            bottoLabel.Text = ((int)growth).ToString() + "%";
            bottoLabel.TextSize = 12;
            bottoLabel.SetTextColor(Color.ParseColor("#FFFFFF"));
            bottoLabel.Gravity = GravityFlags.CenterHorizontal;

            layout.AddView(topLabel);
            layout.AddView(SplitLine);
            layout.AddView(bottoLabel);

            return layout;
        }
    }
}



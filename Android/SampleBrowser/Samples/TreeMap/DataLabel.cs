#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Treemap;
using Org.Json;
using Range = Com.Syncfusion.Treemap.Range;

namespace SampleBrowser
{
    class DataLabel : SamplePage
    {
        public DataLabel() { }
        List<String> adapter;
        SfTreeMap tree;
        public override View GetSampleContent(Context context)
        {
            tree = new SfTreeMap(context);
            tree.WeightValuePath = "Population";
            tree.ColorValuePath = "Population";
            tree.HighlightOnSelection = false;
            float density = context.Resources.DisplayMetrics.Density;

            //LeafItemSetting
            tree.LeafItemSettings = new LeafItemSetting() { ShowLabels = true, Gap = 1, LabelPath = "Region", StrokeWidth = 2 };
            tree.LeafItemSettings.LabelStyle = new Style() { TextSize = 18 };

            TreeMapTooltipSetting tooltip = new TreeMapTooltipSetting(context);
            tree.TooltipSettings = tooltip;
            List<Range> ranges = new List<Range>();
            ranges.Add(new Range() { LegendLabel = "200M - 1.3B", From = 200000000, To = 10000000000, Color = Color.ParseColor("#4B134F") });
            ranges.Add(new Range() { LegendLabel = "100M - 200M", From = 100000000, To = 200000000, Color = Color.ParseColor("#8C304D") });
            ranges.Add(new Range() { LegendLabel = "20M - 100M", From = 20000000, To = 100000000, Color = Color.ParseColor("#C84B4B") });
            tree.LeafItemColorMapping = new RangeColorMapping() { Ranges = ranges };
            tree.ShowTooltip = true;

            //LegendSetting
            Size legendSize = new Size(300, 100);
            Size iconSize = new Size(14, 14);
            tree.LegendSettings = new LegendSetting()
            {
                LabelStyle = new Style()
                {
                    TextSize = 14,
                    TextColor = Android.Graphics.Color.Black
                },
                IconSize = iconSize,
                ShowLegend = true,
                LegendSize = legendSize
            };
            tree.DataSource = GetDataSource();
            return tree;
        }


        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            TextView label = new TextView(context);
            label.Text = "DataLabelOverflowMode";
            label.Typeface = Typeface.DefaultBold;
            label.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            label.TextSize = 20;

            Spinner labelMode = new Spinner(context, SpinnerMode.Dialog);
            adapter = new List<String>() { "Trim", "Wrap", "Hide" };

            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, adapter);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            labelMode.Adapter = dataAdapter;

            labelMode.ItemSelected += LabelMode_ItemSelected;
            LinearLayout optionsPage = new LinearLayout(context);
            optionsPage.Orientation = Orientation.Vertical;
            optionsPage.AddView(label);
            optionsPage.AddView(labelMode);
            optionsPage.SetPadding(10, 10, 10, 10);
            optionsPage.SetBackgroundColor(Android.Graphics.Color.White);
            return optionsPage;
        }

        private void LabelMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = adapter[e.Position];
            if (selectedItem.Equals("Trim"))
            {
                tree.LeafItemSettings.OverflowMode = LabelOverflowMode.Trim;
            }
            else if (selectedItem.Equals("Wrap"))
            {
                tree.LeafItemSettings.OverflowMode = LabelOverflowMode.Wrap;
            }
            else if (selectedItem.Equals("Hide"))
            {
                tree.LeafItemSettings.OverflowMode = LabelOverflowMode.Hide;
            }
        }
        JSONArray GetDataSource()
        {
            JSONArray array = new JSONArray();
            array.Put(getJsonObject("China", 1388232693));
            array.Put(getJsonObject("India", 1342512706));
            array.Put(getJsonObject("United States of America", 326474013));
            array.Put(getJsonObject("Indonesia", 263510146));
            array.Put(getJsonObject("Brazil", 211243220));
            array.Put(getJsonObject("Pakistan", 196744376));
            array.Put(getJsonObject("Nigeria", 191835936));
            array.Put(getJsonObject("Bangladesh", 164827718));
            array.Put(getJsonObject("Russian Federation", 143375006));
            array.Put(getJsonObject("Mexico", 130222815));
            array.Put(getJsonObject("Japan", 126045211));
            array.Put(getJsonObject("Ethiopia", 104344901));
            array.Put(getJsonObject("Philippines", 103796832));
            array.Put(getJsonObject("Viet Nam", 95414640));
            array.Put(getJsonObject("Egypt", 95215102));
            array.Put(getJsonObject("D.R. Congo", 82242685));

            array.Put(getJsonObject("Iran", 80945718));
            array.Put(getJsonObject("Germany", 80636124));
            array.Put(getJsonObject("Turkey", 80417526));
            array.Put(getJsonObject("Thailand", 68297547));
            array.Put(getJsonObject("United Kingdom", 65511098));
            array.Put(getJsonObject("France", 64938716));
            array.Put(getJsonObject("Italy", 59797978));
            array.Put(getJsonObject("Tanzania", 56877529));
            array.Put(getJsonObject("South Africa", 55436360));
            array.Put(getJsonObject("Myanmar", 54836483));
            array.Put(getJsonObject("Republic of Korea", 50704971));
            array.Put(getJsonObject("Colombia", 49067981));
            array.Put(getJsonObject("Kenya", 48466928));
            array.Put(getJsonObject("Spain", 46070146));
            array.Put(getJsonObject("Ukraine", 44405055));
            array.Put(getJsonObject("Argentina", 44272125));

            array.Put(getJsonObject("Sudan", 42166323));
            array.Put(getJsonObject("Uganda", 41652938));
            array.Put(getJsonObject("Algeria", 41063753));
            array.Put(getJsonObject("Iraq", 38654287));
            array.Put(getJsonObject("Poland", 38563573));
            array.Put(getJsonObject("Canada", 36626083));
            array.Put(getJsonObject("Morocco", 35241418));
            array.Put(getJsonObject("Afghanistan", 34169169));
            array.Put(getJsonObject("Saudi Arabia", 32742664));
            array.Put(getJsonObject("Peru", 32166473));
            array.Put(getJsonObject("Venezuela", 31925705));
            array.Put(getJsonObject("Malaysia", 31164177));
            array.Put(getJsonObject("Uzbekistan", 30690914));
            array.Put(getJsonObject("Mozambique", 29537914));
            array.Put(getJsonObject("Nepal", 29187037));
            array.Put(getJsonObject("Ghana", 28656723));

            array.Put(getJsonObject("Yemen", 28119546));
            array.Put(getJsonObject("Angola", 26655513));

            array.Put(getJsonObject("Madagascar", 25612972));

            array.Put(getJsonObject("Dem Peoples Republic of Korea", 25405296));

            array.Put(getJsonObject("Australia", 24641662));
            array.Put(getJsonObject("Cameroon", 24513689));
            array.Put(getJsonObject("Côte dIvoire", 23815886));
            array.Put(getJsonObject("Taiwan", 23405309));
            array.Put(getJsonObject("Niger", 21563607));

            return array;
        }

        JSONObject getJsonObject(String region, double population)
        {
            JSONObject obj = new JSONObject();
            obj.Put("Region", region);
            obj.Put("Population", population);

            return obj;
        }
    }
    public class TreeMapTooltipSetting : TooltipSetting
    {
        Context context;
        public TreeMapTooltipSetting(Context con)
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
            var population = ((JSONObject)data).GetDouble("Population") / 1000000;
            bottoLabel.Text = ((int)population).ToString() + "M";
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
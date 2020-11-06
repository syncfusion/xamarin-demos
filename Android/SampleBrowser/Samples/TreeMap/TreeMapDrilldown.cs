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
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Treemap;
using Org.Json;

namespace SampleBrowser
{
    public class TreeMapDrilldown : SamplePage
    {
        SfTreeMap treeMap;
        public TreeMapDrilldown()
        {

        }

        public override View GetSampleContent(Context context)
        {
            DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
            int screenHeight = displayMetrics.HeightPixels;

            LinearLayout layout = new LinearLayout(context);
            layout.Orientation = Orientation.Vertical;

            TextView textView = new TextView(context);
            textView.TextAlignment = TextAlignment.Center;
            textView.TextSize = 18;
            textView.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;
            textView.SetHeight((int)(screenHeight * 0.05));
            textView.Text = "Continents by population";
            layout.AddView(textView);

            treeMap = new SfTreeMap(context);
            treeMap.WeightValuePath = "Population";
            treeMap.ColorValuePath = "Growth";
            treeMap.HighlightOnSelection = false;

            treeMap.LeafItemSettings = new LeafItemSetting()
            {
                ShowLabels = true,
                Gap = 5,
                LabelPath = "Region",
                StrokeColor = Android.Graphics.Color.Gray,
                StrokeWidth = 1
            };

            TreeMapFlatLevel level = new TreeMapFlatLevel
            {
                ShowHeader = true,
                GroupPath = "Continent",
                GroupStrokeColor = Android.Graphics.Color.Gray,
                GroupStrokeWidth = 1,
                GroupPadding = 5,
                LabelPath = "Continent",
                HeaderStyle = new Style() { TextColor = Android.Graphics.Color.Black },
                HeaderHeight = 25
            };


            TreeMapFlatLevel level1 = new TreeMapFlatLevel
            {
                ShowHeader = true,
                GroupPath = "States",
                GroupStrokeColor = Android.Graphics.Color.Gray,
                GroupStrokeWidth = 1,
                GroupPadding = 5,
                LabelPath = "States",
                HeaderStyle = new Style() { TextColor = Android.Graphics.Color.Black },
                HeaderHeight = 25
            };

            treeMap.Levels.Add(level);
            treeMap.Levels.Add(level1);

            PaletteColorMapping colorMapping = new PaletteColorMapping();
            colorMapping.Colors.Add(Color.ParseColor("#C044A5"));
            colorMapping.Colors.Add(Color.ParseColor("#665197"));
            colorMapping.Colors.Add(Color.ParseColor("#FF4652"));
            colorMapping.Colors.Add(Color.ParseColor("#8B2286"));
            colorMapping.Colors.Add(Color.ParseColor("#448FC0"));

            treeMap.LeafItemColorMapping = colorMapping;

            treeMap.DataSource = GetDataSource();
            treeMap.EnableDrilldown = true;
            treeMap.ShowTooltip = true;
            layout.AddView(treeMap);
            return layout;
        }

        JSONArray GetDataSource()
        {
            JSONArray array = new JSONArray();

            #region Africa

            array.Put(GetJsonObject("Africa", "Eastern Africa", "Ethiopia", 107534882));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Tanzania", 59091392));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Kenya", 50950879));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Uganda", 44270563));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Mozambique", 30528673));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Madagascar", 26262810));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Malawi", 19164728));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Zambia", 17609178));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Zimbabwe", 16913261));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Somalia", 15181925));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "South Sudan", 12919053));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Rwanda", 12501156));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Burundi", 107534882));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Eritrea", 5187948));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Mauritius", 1268315));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Djibouti", 971408));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Réunion", 883247));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Comoros", 832347));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Mayotte", 259682));
            array.Put(GetJsonObject("Africa", "Eastern Africa", "Seychelles", 95235));

            array.Put(GetJsonObject("Africa", "Middle Africa", "Democratic Republic of the Congo", 84004989));
            array.Put(GetJsonObject("Africa", "Middle Africa", "Angola", 30774205));
            array.Put(GetJsonObject("Africa", "Middle Africa", "Cameroon", 24678234));
            array.Put(GetJsonObject("Africa", "Middle Africa", "Chad", 15353184));
            array.Put(GetJsonObject("Africa", "Middle Africa", "Congo", 5399895));
            array.Put(GetJsonObject("Africa", "Middle Africa", "Central African Republic", 4737423));
            array.Put(GetJsonObject("Africa", "Middle Africa", "Gabon", 2067561));
            array.Put(GetJsonObject("Africa", "Middle Africa", "Equatorial Guinea", 1313894));
            array.Put(GetJsonObject("Africa", "Middle Africa", "Sao Tome and Principe", 208818));

            array.Put(GetJsonObject("Africa", "Northern Africa", "Egypt", 99375741));
            array.Put(GetJsonObject("Africa", "Northern Africa", "Algeria", 42008054));
            array.Put(GetJsonObject("Africa", "Northern Africa", "Sudan", 41511526));
            array.Put(GetJsonObject("Africa", "Northern Africa", "Morocco", 36191805));
            array.Put(GetJsonObject("Africa", "Northern Africa", "Tunisia", 11659174));
            array.Put(GetJsonObject("Africa", "Northern Africa", "Libya", 6470956));
            array.Put(GetJsonObject("Africa", "Northern Africa", "Western Sahara", 567421));

            array.Put(GetJsonObject("Africa", "Southern Africa", "South Africa", 57398421));
            array.Put(GetJsonObject("Africa", "Southern Africa", "Namibia", 2587801));
            array.Put(GetJsonObject("Africa", "Southern Africa", "Botswana", 2333201));
            array.Put(GetJsonObject("Africa", "Southern Africa", "Lesotho", 2263010));
            array.Put(GetJsonObject("Africa", "Southern Africa", "Swaziland", 1391385));

            array.Put(GetJsonObject("Africa", "Western Africa", "Nigeria", 195875237));
            array.Put(GetJsonObject("Africa", "Western Africa", "Ghana", 29463643));
            array.Put(GetJsonObject("Africa", "Western Africa", "Côte d'Ivoire", 24905843));
            array.Put(GetJsonObject("Africa", "Western Africa", "Niger", 22311375));
            array.Put(GetJsonObject("Africa", "Western Africa", "Burkina Faso", 19751651));
            array.Put(GetJsonObject("Africa", "Western Africa", "Mali", 19107706));
            array.Put(GetJsonObject("Africa", "Western Africa", "Senegal", 16294270));
            array.Put(GetJsonObject("Africa", "Western Africa", "Guinea", 13052608));
            array.Put(GetJsonObject("Africa", "Western Africa", "Benin", 11485674));
            array.Put(GetJsonObject("Africa", "Western Africa", "Togo", 7990926));
            array.Put(GetJsonObject("Africa", "Western Africa", "Sierra Leone", 7719729));
            array.Put(GetJsonObject("Africa", "Western Africa", "Liberia", 4853516));
            array.Put(GetJsonObject("Africa", "Western Africa", "Mauritania", 4540068));
            array.Put(GetJsonObject("Africa", "Western Africa", "Gambia", 2163765));
            array.Put(GetJsonObject("Africa", "Western Africa", "Guinea-Bissau", 1907268));
            array.Put(GetJsonObject("Africa", "Western Africa", "Cabo Verde", 553335));
            array.Put(GetJsonObject("Africa", "Western Africa", "Saint Helena", 4074));

            #endregion

            #region Asia

            array.Put(GetJsonObject("Asia", "Central Asia", "Uzbekistan", 32364996));
            array.Put(GetJsonObject("Asia", "Central Asia", "Kazakhstan", 18403860));
            array.Put(GetJsonObject("Asia", "Central Asia", "Tajikistan", 9107211));
            array.Put(GetJsonObject("Asia", "Central Asia", "Kyrgyzstan", 6132932));
            array.Put(GetJsonObject("Asia", "Central Asia", "Turkmenistan", 5851466));

            array.Put(GetJsonObject("Asia", "Eastern Asia", "China", 1415045928));
            array.Put(GetJsonObject("Asia", "Eastern Asia", "Japan", 127185332));
            array.Put(GetJsonObject("Asia", "Eastern Asia", "South Korea", 51164435));
            array.Put(GetJsonObject("Asia", "Eastern Asia", "North Korea", 25610672));
            array.Put(GetJsonObject("Asia", "Eastern Asia", "Taiwan", 23694089));
            array.Put(GetJsonObject("Asia", "Eastern Asia", "Hong Kong", 7428887));
            array.Put(GetJsonObject("Asia", "Eastern Asia", "Mongolia", 3121772));
            array.Put(GetJsonObject("Asia", "Eastern Asia", "Macao", 632418));

            array.Put(GetJsonObject("Asia", "Southeastern Asia", "Indonesia", 266794980));
            array.Put(GetJsonObject("Asia", "Southeastern Asia", "Philippines", 106512074));
            array.Put(GetJsonObject("Asia", "Southeastern Asia", "Viet Nam", 96491146));
            array.Put(GetJsonObject("Asia", "Southeastern Asia", "Thailand", 69183173));
            array.Put(GetJsonObject("Asia", "Southeastern Asia", "Myanmar", 53855735));
            array.Put(GetJsonObject("Asia", "Southeastern Asia", "Malaysia", 32042458));
            array.Put(GetJsonObject("Asia", "Southeastern Asia", "Cambodia", 16245729));
            array.Put(GetJsonObject("Asia", "Southeastern Asia", "Laos", 6961210));
            array.Put(GetJsonObject("Asia", "Southeastern Asia", "Singapore", 5791901));
            array.Put(GetJsonObject("Asia", "Southeastern Asia", "Timor-Leste", 1324094));
            array.Put(GetJsonObject("Asia", "Southeastern Asia", "Brunei Darussalam", 434076));

            array.Put(GetJsonObject("Asia", "Southern Asia", "India", 1354051854));
            array.Put(GetJsonObject("Asia", "Southern Asia", "Pakistan", 200813818));
            array.Put(GetJsonObject("Asia", "Southern Asia", "Bangladesh", 166368149));
            array.Put(GetJsonObject("Asia", "Southern Asia", "Iran", 82011735));
            array.Put(GetJsonObject("Asia", "Southern Asia", "Afghanistan", 36373176));
            array.Put(GetJsonObject("Asia", "Southern Asia", "Nepal", 29624035));
            array.Put(GetJsonObject("Asia", "Southern Asia", "Sri Lanka", 20950041));
            array.Put(GetJsonObject("Asia", "Southern Asia", "Bhutan", 817054));
            array.Put(GetJsonObject("Asia", "Southern Asia", "Maldives", 444259));

            array.Put(GetJsonObject("Asia", "Western Asia", "Turkey", 81916871));
            array.Put(GetJsonObject("Asia", "Western Asia", "Iraq", 39339753));
            array.Put(GetJsonObject("Asia", "Western Asia", "Saudi Arabia", 33554343));
            array.Put(GetJsonObject("Asia", "Western Asia", "Yemen", 28915284));
            array.Put(GetJsonObject("Asia", "Western Asia", "Syria", 18284407));
            array.Put(GetJsonObject("Asia", "Western Asia", "Azerbaijan", 9923914));
            array.Put(GetJsonObject("Asia", "Western Asia", "Jordan", 9903802));
            array.Put(GetJsonObject("Asia", "Western Asia", "United Arab Emirates", 9541615));
            array.Put(GetJsonObject("Asia", "Western Asia", "Israel", 8452841));
            array.Put(GetJsonObject("Asia", "Western Asia", "Lebanon", 6093509));
            array.Put(GetJsonObject("Asia", "Western Asia", "State of Palestine", 5052776));
            array.Put(GetJsonObject("Asia", "Western Asia", "Oman", 4829946));
            array.Put(GetJsonObject("Asia", "Western Asia", "Kuwait", 4197128));
            array.Put(GetJsonObject("Asia", "Western Asia", "Georgia", 3907131));
            array.Put(GetJsonObject("Asia", "Western Asia", "Armenia", 2934152));
            array.Put(GetJsonObject("Asia", "Western Asia", "Qatar", 2694849));
            array.Put(GetJsonObject("Asia", "Western Asia", "Bahrain", 1566993));
            array.Put(GetJsonObject("Asia", "Western Asia", "Cyprus", 1189085));

            #endregion

            #region Northa America

            array.Put(GetJsonObject("North America", "Central America", "Mexico", 130759074));
            array.Put(GetJsonObject("North America", "Central America", "Guatemala", 17245346));
            array.Put(GetJsonObject("North America", "Central America", "Honduras", 9417167));
            array.Put(GetJsonObject("North America", "Central America", "El, Salvador", 6411558));
            array.Put(GetJsonObject("North America", "Central America", "Nicaragua", 6284757));
            array.Put(GetJsonObject("North America", "Central America", "Costa, Rica", 4953199));
            array.Put(GetJsonObject("North America", "Central America", "Panama", 4162618));
            array.Put(GetJsonObject("North America", "Central America", "Belize", 382444));

            array.Put(GetJsonObject("North America", "Northern America", "U.S", 322179605));
            array.Put(GetJsonObject("North America", "Northern America", "Canada", 36953765));
            array.Put(GetJsonObject("North America", "Northern America", "Bermuda", 61070));
            array.Put(GetJsonObject("North America", "Northern America", "Greenland", 56565));
            array.Put(GetJsonObject("North America", "Northern America", "Saint Pierre & Miquelon", 6342));

            #endregion

            #region SouthAmerica

            array.Put(GetJsonObject("South America", "South America", "Brazil", 204519000));
            array.Put(GetJsonObject("South America", "South America", "Colombia", 48549000));
            array.Put(GetJsonObject("South America", "South America", "Argentina", 43132000));
            array.Put(GetJsonObject("South America", "South America", "Peru", 31153000));
            array.Put(GetJsonObject("South America", "South America", "Venezuela", 30620000));
            array.Put(GetJsonObject("South America", "South America", "Chile", 18006000));
            array.Put(GetJsonObject("South America", "South America", "Ecuador", 16279000));
            array.Put(GetJsonObject("South America", "South America", "Bolivia", 10520000));
            array.Put(GetJsonObject("South America", "South America", "Paraguay", 7003000));
            array.Put(GetJsonObject("South America", "South America", "Uruguay", 3310000));
            array.Put(GetJsonObject("South America", "South America", "Guyana", 747000));
            array.Put(GetJsonObject("South America", "South America", "Suri Name", 560000));
            array.Put(GetJsonObject("South America", "South America", "French Guiana", 262000));
            array.Put(GetJsonObject("South America", "South America", "Falkland Islands", 3000));


            #endregion

            #region Europe

            array.Put(GetJsonObject("Europe", "Eastern Europe", "Russia", 143964709));
            array.Put(GetJsonObject("Europe", "Eastern Europe", "Ukraine", 44009214));
            array.Put(GetJsonObject("Europe", "Eastern Europe", "Poland", 38104832));
            array.Put(GetJsonObject("Europe", "Eastern Europe", "Romania", 19580634));
            array.Put(GetJsonObject("Europe", "Eastern Europe", "Crech, Republic", 10625250));
            array.Put(GetJsonObject("Europe", "Eastern Europe", "Hungary", 9688847));
            array.Put(GetJsonObject("Europe", "Eastern Europe", "Belarus", 9452113));
            array.Put(GetJsonObject("Europe", "Eastern Europe", "Bulgaria", 7036848));
            array.Put(GetJsonObject("Europe", "Eastern Europe", "Slovakia", 5449816));
            array.Put(GetJsonObject("Europe", "Eastern Europe", "Moldova", 4041065));

            array.Put(GetJsonObject("Europe", "Northern Europe", "United Kingdom", 66573504));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Sweden", 9982709));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Denmark", 5754356));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Finland", 5542517));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Norway", 5353363));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Ireland", 4803748));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Lithuania", 2876475));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Latvia", 1929938));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Estonia", 1306788));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Iceland", 337780));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Channel Islands", 166083));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Isle of Man", 84831));
            array.Put(GetJsonObject("Europe", "Northern Europe", "Faeroe Islands", 49489));

            array.Put(GetJsonObject("Europe", "Southern Europe", "Italy", 59290969));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Spain", 46397452));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Greece", 11142161));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Portugal", 10291196));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Serbia", 8762027));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Croatia", 4164783));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Bosnia and Herzegovina", 3503554));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Albania", 2934363));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Macedonia", 2085051));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Slovenia", 2081260));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Montenegro", 629219));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Malta", 432089));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Andorra", 76953));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Gibraltar", 34733));
            array.Put(GetJsonObject("Europe", "Southern Europe", "San Marino", 33557));
            array.Put(GetJsonObject("Europe", "Southern Europe", "Holy, See", 801));

            array.Put(GetJsonObject("Europe", "Western Europe", "Germany", 82293457));
            array.Put(GetJsonObject("Europe", "Western Europe", "France", 65233271));
            array.Put(GetJsonObject("Europe", "Western Europe", "Netherlands", 17084459));
            array.Put(GetJsonObject("Europe", "Western Europe", "Belgium", 11498519));
            array.Put(GetJsonObject("Europe", "Western Europe", "Austria", 8751820));
            array.Put(GetJsonObject("Europe", "Western Europe", "Switzerland", 8544034));
            array.Put(GetJsonObject("Europe", "Western Europe", "Luxembourg", 590321));
            array.Put(GetJsonObject("Europe", "Western Europe", "Monaco", 38897));
            array.Put(GetJsonObject("Europe", "Western Europe", "Liechtenstein", 38155));

            #endregion
            return array;
        }

        JSONObject GetJsonObject(string continent, string states, string region, double population)
        {
            JSONObject obj = new JSONObject();
            obj.Put("Continent", continent);
            obj.Put("States", states);
            obj.Put("Region", region);
            obj.Put("Population", population);
            return obj;
        }

    }
}
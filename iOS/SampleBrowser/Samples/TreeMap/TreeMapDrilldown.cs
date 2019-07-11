#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion
using System;
using Syncfusion.SfTreeMap.iOS;
using System.Collections.Generic;
#if __UNIFIED__
using UIKit;
using CoreGraphics;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif
namespace SampleBrowser
{
    public class TreeMapDrilldown : SampleView
    {
        SFTreeMap treeMap;
        UILabel header;
        UIView view;
        public TreeMapDrilldown()
        {
            view = new UIView();
            header = new UILabel();
            header.TextAlignment = UITextAlignment.Center;
            header.Text = "Continents by population";
            header.Font = UIFont.SystemFontOfSize(18);
            header.Frame = new CGRect(0, 0, 400, 40);
            header.TextColor = UIColor.Black;
            view.AddSubview(header);

            treeMap = new SFTreeMap();

            treeMap.WeightValuePath = (NSString)"Population";
            treeMap.ColorValuePath = (NSString)"Population";

            SFLeafItemSetting leafItemSetting = new SFLeafItemSetting();
            leafItemSetting.Gap = 2;
            leafItemSetting.LabelPath = (NSString)"Region";


            leafItemSetting.BorderColor = UIColor.FromRGB(169, 217, 247);
            leafItemSetting.ShowLabels = true;
            treeMap.LeafItemSettings = leafItemSetting;


            SFTreeMapFlatLevel flatLevel = new SFTreeMapFlatLevel();
            flatLevel.GroupBackground = UIColor.White;
            flatLevel.HeaderHeight = 20;
            flatLevel.GroupPath = (NSString)"Continent";
            flatLevel.GroupGap = 5;
            flatLevel.HeaderStyle = new SFStyle() { Color = UIColor.Black };
            flatLevel.LabelPath = (NSString)"Continent";
            flatLevel.ShowHeader = true;
            treeMap.Levels.Add(flatLevel);


            SFTreeMapFlatLevel flatLevel1 = new SFTreeMapFlatLevel();
            flatLevel1.GroupBackground = UIColor.White;
            flatLevel1.HeaderHeight = 20;
            flatLevel1.HeaderStyle = new SFStyle() { Color = UIColor.Black };
            flatLevel1.GroupPath = (NSString)"States";
            flatLevel1.LabelPath = (NSString)"States";

            flatLevel1.GroupGap = 5;
            flatLevel1.ShowHeader = true;
            treeMap.Levels.Add(flatLevel1);

            SFPaletteColorMapping colorMapping = new SFPaletteColorMapping();
            colorMapping.Colors.Add(UIColor.FromRGB(192, 68, 165));
            colorMapping.Colors.Add(UIColor.FromRGB(102, 81, 151));
            colorMapping.Colors.Add(UIColor.FromRGB(255, 70, 82));
            colorMapping.Colors.Add(UIColor.FromRGB(139, 34, 134));
            colorMapping.Colors.Add(UIColor.FromRGB(68, 143, 192));


            treeMap.LeafItemColorMapping = colorMapping;
            treeMap.EnableDrilldown = true;

            GetPopulationData();
            treeMap.DataSource = PopulationDetails;
            treeMap.ShowTooltip = true;
            view.AddSubview(treeMap);

            AddSubview(view);

        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            view.Frame = new CGRect(Frame.Location.X, 0, Frame.Size.Width, Frame.Size.Height);
            header.Frame = new CGRect(0f, 0f, Frame.Size.Width, 40);
            treeMap.Frame = new CGRect(Frame.Location.X, 40, Frame.Size.Width, Frame.Size.Height - 40);

            SetNeedsDisplay();

        }

        void GetPopulationData()
        {
            NSMutableArray array = new NSMutableArray();

            #region Africa

            array.Add(getDictionary("Africa", "Eastern Africa", "Ethiopia", 107534882));
            array.Add(getDictionary("Africa", "Eastern Africa", "Tanzania", 59091392));
            array.Add(getDictionary("Africa", "Eastern Africa", "Kenya", 50950879));
            array.Add(getDictionary("Africa", "Eastern Africa", "Uganda", 44270563));
            array.Add(getDictionary("Africa", "Eastern Africa", "Mozambique", 30528673));
            array.Add(getDictionary("Africa", "Eastern Africa", "Madagascar", 26262810));
            array.Add(getDictionary("Africa", "Eastern Africa", "Malawi", 19164728));
            array.Add(getDictionary("Africa", "Eastern Africa", "Zambia", 17609178));
            array.Add(getDictionary("Africa", "Eastern Africa", "Zimbabwe", 16913261));
            array.Add(getDictionary("Africa", "Eastern Africa", "Somalia", 15181925));
            array.Add(getDictionary("Africa", "Eastern Africa", "South Sudan", 12919053));
            array.Add(getDictionary("Africa", "Eastern Africa", "Rwanda", 12501156));
            array.Add(getDictionary("Africa", "Eastern Africa", "Burundi", 107534882));
            array.Add(getDictionary("Africa", "Eastern Africa", "Eritrea", 5187948));
            array.Add(getDictionary("Africa", "Eastern Africa", "Mauritius", 1268315));
            array.Add(getDictionary("Africa", "Eastern Africa", "Djibouti", 971408));
            array.Add(getDictionary("Africa", "Eastern Africa", "Réunion", 883247));
            array.Add(getDictionary("Africa", "Eastern Africa", "Comoros", 832347));
            array.Add(getDictionary("Africa", "Eastern Africa", "Mayotte", 259682));
            array.Add(getDictionary("Africa", "Eastern Africa", "Seychelles", 95235));

            array.Add(getDictionary("Africa", "Middle Africa", "Democratic Republic of the Congo", 84004989));
            array.Add(getDictionary("Africa", "Middle Africa", "Angola", 30774205));
            array.Add(getDictionary("Africa", "Middle Africa", "Cameroon", 24678234));
            array.Add(getDictionary("Africa", "Middle Africa", "Chad", 15353184));
            array.Add(getDictionary("Africa", "Middle Africa", "Congo", 5399895));
            array.Add(getDictionary("Africa", "Middle Africa", "Central African Republic", 4737423));
            array.Add(getDictionary("Africa", "Middle Africa", "Gabon", 2067561));
            array.Add(getDictionary("Africa", "Middle Africa", "Equatorial Guinea", 1313894));
            array.Add(getDictionary("Africa", "Middle Africa", "Sao Tome and Principe", 208818));

            array.Add(getDictionary("Africa", "Northern Africa", "Egypt", 99375741));
            array.Add(getDictionary("Africa", "Northern Africa", "Algeria", 42008054));
            array.Add(getDictionary("Africa", "Northern Africa", "Sudan", 41511526));
            array.Add(getDictionary("Africa", "Northern Africa", "Morocco", 36191805));
            array.Add(getDictionary("Africa", "Northern Africa", "Tunisia", 11659174));
            array.Add(getDictionary("Africa", "Northern Africa", "Libya", 6470956));
            array.Add(getDictionary("Africa", "Northern Africa", "Western Sahara", 567421));

            array.Add(getDictionary("Africa", "Southern Africa", "South Africa", 57398421));
            array.Add(getDictionary("Africa", "Southern Africa", "Namibia", 2587801));
            array.Add(getDictionary("Africa", "Southern Africa", "Botswana", 2333201));
            array.Add(getDictionary("Africa", "Southern Africa", "Lesotho", 2263010));
            array.Add(getDictionary("Africa", "Southern Africa", "Swaziland", 1391385));

            array.Add(getDictionary("Africa", "Western Africa", "Nigeria", 195875237));
            array.Add(getDictionary("Africa", "Western Africa", "Ghana", 29463643));
            array.Add(getDictionary("Africa", "Western Africa", "Côte d'Ivoire", 24905843));
            array.Add(getDictionary("Africa", "Western Africa", "Niger", 22311375));
            array.Add(getDictionary("Africa", "Western Africa", "Burkina Faso", 19751651));
            array.Add(getDictionary("Africa", "Western Africa", "Mali", 19107706));
            array.Add(getDictionary("Africa", "Western Africa", "Senegal", 16294270));
            array.Add(getDictionary("Africa", "Western Africa", "Guinea", 13052608));
            array.Add(getDictionary("Africa", "Western Africa", "Benin", 11485674));
            array.Add(getDictionary("Africa", "Western Africa", "Togo", 7990926));
            array.Add(getDictionary("Africa", "Western Africa", "Sierra Leone", 7719729));
            array.Add(getDictionary("Africa", "Western Africa", "Liberia", 4853516));
            array.Add(getDictionary("Africa", "Western Africa", "Mauritania", 4540068));
            array.Add(getDictionary("Africa", "Western Africa", "Gambia", 2163765));
            array.Add(getDictionary("Africa", "Western Africa", "Guinea-Bissau", 1907268));
            array.Add(getDictionary("Africa", "Western Africa", "Cabo Verde", 553335));
            array.Add(getDictionary("Africa", "Western Africa", "Saint Helena", 4074));

            #endregion

            #region Asia

            array.Add(getDictionary("Asia", "Central Asia", "Uzbekistan", 32364996));
            array.Add(getDictionary("Asia", "Central Asia", "Kazakhstan", 18403860));
            array.Add(getDictionary("Asia", "Central Asia", "Tajikistan", 9107211));
            array.Add(getDictionary("Asia", "Central Asia", "Kyrgyzstan", 6132932));
            array.Add(getDictionary("Asia", "Central Asia", "Turkmenistan", 5851466));

            array.Add(getDictionary("Asia", "Eastern Asia", "China", 1415045928));
            array.Add(getDictionary("Asia", "Eastern Asia", "Japan", 127185332));
            array.Add(getDictionary("Asia", "Eastern Asia", "South Korea", 51164435));
            array.Add(getDictionary("Asia", "Eastern Asia", "North Korea", 25610672));
            array.Add(getDictionary("Asia", "Eastern Asia", "Taiwan", 23694089));
            array.Add(getDictionary("Asia", "Eastern Asia", "Hong Kong", 7428887));
            array.Add(getDictionary("Asia", "Eastern Asia", "Mongolia", 3121772));
            array.Add(getDictionary("Asia", "Eastern Asia", "Macao", 632418));

            array.Add(getDictionary("Asia", "Southeastern Asia", "Indonesia", 266794980));
            array.Add(getDictionary("Asia", "Southeastern Asia", "Philippines", 106512074));
            array.Add(getDictionary("Asia", "Southeastern Asia", "Viet Nam", 96491146));
            array.Add(getDictionary("Asia", "Southeastern Asia", "Thailand", 69183173));
            array.Add(getDictionary("Asia", "Southeastern Asia", "Myanmar", 53855735));
            array.Add(getDictionary("Asia", "Southeastern Asia", "Malaysia", 32042458));
            array.Add(getDictionary("Asia", "Southeastern Asia", "Cambodia", 16245729));
            array.Add(getDictionary("Asia", "Southeastern Asia", "Laos", 6961210));
            array.Add(getDictionary("Asia", "Southeastern Asia", "Singapore", 5791901));
            array.Add(getDictionary("Asia", "Southeastern Asia", "Timor-Leste", 1324094));
            array.Add(getDictionary("Asia", "Southeastern Asia", "Brunei Darussalam", 434076));

            array.Add(getDictionary("Asia", "Southern Asia", "India", 1354051854));
            array.Add(getDictionary("Asia", "Southern Asia", "Pakistan", 200813818));
            array.Add(getDictionary("Asia", "Southern Asia", "Bangladesh", 166368149));
            array.Add(getDictionary("Asia", "Southern Asia", "Iran", 82011735));
            array.Add(getDictionary("Asia", "Southern Asia", "Afghanistan", 36373176));
            array.Add(getDictionary("Asia", "Southern Asia", "Nepal", 29624035));
            array.Add(getDictionary("Asia", "Southern Asia", "Sri Lanka", 20950041));
            array.Add(getDictionary("Asia", "Southern Asia", "Bhutan", 817054));
            array.Add(getDictionary("Asia", "Southern Asia", "Maldives", 444259));

            array.Add(getDictionary("Asia", "Western Asia", "Turkey", 81916871));
            array.Add(getDictionary("Asia", "Western Asia", "Iraq", 39339753));
            array.Add(getDictionary("Asia", "Western Asia", "Saudi Arabia", 33554343));
            array.Add(getDictionary("Asia", "Western Asia", "Yemen", 28915284));
            array.Add(getDictionary("Asia", "Western Asia", "Syria", 18284407));
            array.Add(getDictionary("Asia", "Western Asia", "Azerbaijan", 9923914));
            array.Add(getDictionary("Asia", "Western Asia", "Jordan", 9903802));
            array.Add(getDictionary("Asia", "Western Asia", "United Arab Emirates", 9541615));
            array.Add(getDictionary("Asia", "Western Asia", "Israel", 8452841));
            array.Add(getDictionary("Asia", "Western Asia", "Lebanon", 6093509));
            array.Add(getDictionary("Asia", "Western Asia", "State of Palestine", 5052776));
            array.Add(getDictionary("Asia", "Western Asia", "Oman", 4829946));
            array.Add(getDictionary("Asia", "Western Asia", "Kuwait", 4197128));
            array.Add(getDictionary("Asia", "Western Asia", "Georgia", 3907131));
            array.Add(getDictionary("Asia", "Western Asia", "Armenia", 2934152));
            array.Add(getDictionary("Asia", "Western Asia", "Qatar", 2694849));
            array.Add(getDictionary("Asia", "Western Asia", "Bahrain", 1566993));
            array.Add(getDictionary("Asia", "Western Asia", "Cyprus", 1189085));

            #endregion

            #region Northa America

            array.Add(getDictionary("North America", "Central America", "Mexico", 130759074));
            array.Add(getDictionary("North America", "Central America", "Guatemala", 17245346));
            array.Add(getDictionary("North America", "Central America", "Honduras", 9417167));
            array.Add(getDictionary("North America", "Central America", "El, Salvador", 6411558));
            array.Add(getDictionary("North America", "Central America", "Nicaragua", 6284757));
            array.Add(getDictionary("North America", "Central America", "Costa, Rica", 4953199));
            array.Add(getDictionary("North America", "Central America", "Panama", 4162618));
            array.Add(getDictionary("North America", "Central America", "Belize", 382444));

            array.Add(getDictionary("North America", "Northern America", "U.S", 322179605));
            array.Add(getDictionary("North America", "Northern America", "Canada", 36953765));
            array.Add(getDictionary("North America", "Northern America", "Bermuda", 61070));
            array.Add(getDictionary("North America", "Northern America", "Greenland", 56565));
            array.Add(getDictionary("North America", "Northern America", "Saint Pierre & Miquelon", 6342));

            #endregion

            #region SouthAmerica

            array.Add(getDictionary("South America", "South America", "Brazil", 204519000));
            array.Add(getDictionary("South America", "South America", "Colombia", 48549000));
            array.Add(getDictionary("South America", "South America", "Argentina", 43132000));
            array.Add(getDictionary("South America", "South America", "Peru", 31153000));
            array.Add(getDictionary("South America", "South America", "Venezuela", 30620000));
            array.Add(getDictionary("South America", "South America", "Chile", 18006000));
            array.Add(getDictionary("South America", "South America", "Ecuador", 16279000));
            array.Add(getDictionary("South America", "South America", "Bolivia", 10520000));
            array.Add(getDictionary("South America", "South America", "Paraguay", 7003000));
            array.Add(getDictionary("South America", "South America", "Uruguay", 3310000));
            array.Add(getDictionary("South America", "South America", "Guyana", 747000));
            array.Add(getDictionary("South America", "South America", "Suri Name", 560000));
            array.Add(getDictionary("South America", "South America", "French Guiana", 262000));
            array.Add(getDictionary("South America", "South America", "Falkland Islands", 3000));


            #endregion

            #region Europe

            array.Add(getDictionary("Europe", "Eastern Europe", "Russia", 143964709));
            array.Add(getDictionary("Europe", "Eastern Europe", "Ukraine", 44009214));
            array.Add(getDictionary("Europe", "Eastern Europe", "Poland", 38104832));
            array.Add(getDictionary("Europe", "Eastern Europe", "Romania", 19580634));
            array.Add(getDictionary("Europe", "Eastern Europe", "Crech, Republic", 10625250));
            array.Add(getDictionary("Europe", "Eastern Europe", "Hungary", 9688847));
            array.Add(getDictionary("Europe", "Eastern Europe", "Belarus", 9452113));
            array.Add(getDictionary("Europe", "Eastern Europe", "Bulgaria", 7036848));
            array.Add(getDictionary("Europe", "Eastern Europe", "Slovakia", 5449816));
            array.Add(getDictionary("Europe", "Eastern Europe", "Moldova", 4041065));

            array.Add(getDictionary("Europe", "Northern Europe", "United Kingdom", 66573504));
            array.Add(getDictionary("Europe", "Northern Europe", "Sweden", 9982709));
            array.Add(getDictionary("Europe", "Northern Europe", "Denmark", 5754356));
            array.Add(getDictionary("Europe", "Northern Europe", "Finland", 5542517));
            array.Add(getDictionary("Europe", "Northern Europe", "Norway", 5353363));
            array.Add(getDictionary("Europe", "Northern Europe", "Ireland", 4803748));
            array.Add(getDictionary("Europe", "Northern Europe", "Lithuania", 2876475));
            array.Add(getDictionary("Europe", "Northern Europe", "Latvia", 1929938));
            array.Add(getDictionary("Europe", "Northern Europe", "Estonia", 1306788));
            array.Add(getDictionary("Europe", "Northern Europe", "Iceland", 337780));
            array.Add(getDictionary("Europe", "Northern Europe", "Channel Islands", 166083));
            array.Add(getDictionary("Europe", "Northern Europe", "Isle of Man", 84831));
            array.Add(getDictionary("Europe", "Northern Europe", "Faeroe Islands", 49489));

            array.Add(getDictionary("Europe", "Southern Europe", "Italy", 59290969));
            array.Add(getDictionary("Europe", "Southern Europe", "Spain", 46397452));
            array.Add(getDictionary("Europe", "Southern Europe", "Greece", 11142161));
            array.Add(getDictionary("Europe", "Southern Europe", "Portugal", 10291196));
            array.Add(getDictionary("Europe", "Southern Europe", "Serbia", 8762027));
            array.Add(getDictionary("Europe", "Southern Europe", "Croatia", 4164783));
            array.Add(getDictionary("Europe", "Southern Europe", "Bosnia and Herzegovina", 3503554));
            array.Add(getDictionary("Europe", "Southern Europe", "Albania", 2934363));
            array.Add(getDictionary("Europe", "Southern Europe", "Macedonia", 2085051));
            array.Add(getDictionary("Europe", "Southern Europe", "Slovenia", 2081260));
            array.Add(getDictionary("Europe", "Southern Europe", "Montenegro", 629219));
            array.Add(getDictionary("Europe", "Southern Europe", "Malta", 432089));
            array.Add(getDictionary("Europe", "Southern Europe", "Andorra", 76953));
            array.Add(getDictionary("Europe", "Southern Europe", "Gibraltar", 34733));
            array.Add(getDictionary("Europe", "Southern Europe", "San Marino", 33557));
            array.Add(getDictionary("Europe", "Southern Europe", "Holy, See", 801));

            array.Add(getDictionary("Europe", "Western Europe", "Germany", 82293457));
            array.Add(getDictionary("Europe", "Western Europe", "France", 65233271));
            array.Add(getDictionary("Europe", "Western Europe", "Netherlands", 17084459));
            array.Add(getDictionary("Europe", "Western Europe", "Belgium", 11498519));
            array.Add(getDictionary("Europe", "Western Europe", "Austria", 8751820));
            array.Add(getDictionary("Europe", "Western Europe", "Switzerland", 8544034));
            array.Add(getDictionary("Europe", "Western Europe", "Luxembourg", 590321));
            array.Add(getDictionary("Europe", "Western Europe", "Monaco", 38897));
            array.Add(getDictionary("Europe", "Western Europe", "Liechtenstein", 38155));

            #endregion

            PopulationDetails = array;
        }

        NSDictionary getDictionary(string continent, string states, string region, double population)
        {
            object[] objects = new object[4];
            object[] keys = new object[4];
            keys.SetValue("Continent", 0);
            keys.SetValue("States", 1);
            keys.SetValue("Region", 2);
            keys.SetValue("Population", 3);
            objects.SetValue((NSString)continent, 0);
            objects.SetValue((NSString)states, 1);
            objects.SetValue((NSString)region, 2);
            objects.SetValue(population, 3);
            return NSDictionary.FromObjectsAndKeys(objects, keys);
        }


        public NSMutableArray PopulationDetails
        {
            get;
            set;
        }
    }

}
#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using Syncfusion.SfAutoComplete.iOS;
using UIKit;


namespace SampleBrowser
{

    public class ToleratingTypos_Tablet : SampleView
    {
        UILabel headerlabel;
        SfAutoComplete countryAutoComplete;
        UILabel searchresults;
        NSMutableArray countryList = new NSMutableArray();
        UITableView table;
        TableSource tableSource;

        string[] tableItems;
        string[] tableItems2;
        string[] imageItems;
        UITableView tableView;
        ToleratingTyposHelper helper;
        public ToleratingTypos_Tablet()
        {

            headerlabel = new UILabel();
            headerlabel.Text = "Search by Countries";
            headerlabel.TextColor = UIColor.Black;
            headerlabel.TextAlignment = UITextAlignment.Left;
            this.AddSubview(headerlabel);

            countryAutoComplete = new SfAutoComplete();
            CountryCollection();
            countryAutoComplete.Watermark = (NSString)"Search Here";
            countryAutoComplete.MaxDropDownHeight = 100;
            countryAutoComplete.FilterItemChanged += CountryAutoComplete_FilterItemChanged;
            this.AddSubview(countryAutoComplete);
            List<string> items = new List<string>();
            items.Add("India");
            items.Add("Iran");
            items.Add("Iraq");
            items.Add("Indonesia");
            countryAutoComplete.DataSource = items;
            countryAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeCustom;
            searchresults = new UILabel();
            searchresults.Text = "Search Results";
            searchresults.TextColor = UIColor.Gray;
            searchresults.TextAlignment = UITextAlignment.Left;
            this.AddSubview(searchresults);
            tableView = new UITableView();
            tableItems = new string[] { "General", "Maps", "News", "Video", "Music", "Books", "Flight", "Quick Search" };
            imageItems = new string[] { "all.png", "Maps1.png", "Newspaper.png", "Media.png", "Music.png", "Book.png", "Aeroplane.png", "Spaceship.png" };

            ToleratingTypoTableView tableViewSource = new ToleratingTypoTableView(tableItems, imageItems);
            tableView.Source = tableViewSource;
            this.AddSubview(tableView);
            countryAutoComplete.SelectionChanged += (object sender, SelectionEventArgs e) =>
            {
                if ((sender as SfAutoComplete).SelectedIndex != -1)
                {
                    tableViewSource.initial = true;
                    tableViewSource.random = new Random().Next(10000, 99999);
                    tableView.ReloadData();
                }
                if ((sender as SfAutoComplete).SelectedIndex == -1)
                {
                    tableViewSource.initial = false;
                    tableViewSource.random = 0;
                    tableView.ReloadData();
                }
            };

            countryAutoComplete.TextChanged += (object sender, TextEventArgs e) =>
            {
                tableViewSource.initial = false;
                tableViewSource.random = 0;
                tableView.ReloadData();
            };
            helper = new ToleratingTyposHelper();

        }

        bool CountryAutoComplete_FilterItemChanged(object sender, FilterItemEventArgs e)
        {
            object value1 = e.Text;
            object value2 = e.Item;
            var string1 = value1.ToString().ToLower();
            var string2 = value2.ToString().ToLower();
            if (string1.Length > 0 && string2.Length > 0)
                if (string1[0] != string2[0])
                    return false;
            var originalString1 = string.Empty;
            var originalString2 = string.Empty;

            if (string1.Length < string2.Length)
            {
                originalString2 = string2.Remove(string1.Length);
                originalString1 = string1;

            }

            if (string2.Length < string1.Length)
            {
                return false;
            }
            if (string2.Length == string1.Length)
            {
                originalString1 = string1;
                originalString2 = string2;
            }

            bool IsMatchSoundex = helper.ProcessOnSoundexAlgorithmn(originalString1) == helper.ProcessOnSoundexAlgorithmn(originalString2);
            int Distance = helper.GetDamerauLevenshteinDistance(originalString1, originalString2);

            if (IsMatchSoundex || Distance <= 4)
                return true;
            else
                return false;

            int matchValue = 0;

            var allWords = value2.ToString().ToLower().Split(' ');
            var keys = value1.ToString().ToLower().Split(' ');

            foreach (var item in allWords)
            {
                foreach (var key in keys)
                {
                    var itemValue = item;
                    if (item.Length > key.Length)
                    {
                        itemValue = item.Remove(key.Length);
                    }
                    if (key == "" || item == "")
                        continue;
                    if ((helper.ProcessOnSoundexAlgorithmn(key) == helper.ProcessOnSoundexAlgorithmn(itemValue)))
                        matchValue++;
                    if ((helper.ProcessOnSoundexAlgorithmn(key) == helper.ProcessOnSoundexAlgorithmn(item)))
                        matchValue++;
                }
            }

            int keysCount = 0;

            if (matchValue >= keysCount)
                return true;
            return false;
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                headerlabel.Frame = new CGRect(20, 10, view.Frame.Width - 60, 30);
                countryAutoComplete.Frame = new CGRect(20, 40, view.Frame.Width - 60, 40);
                searchresults.Frame = new CGRect(20, 130, this.Frame.Width, 30);
                tableView.Frame = new CGRect(20, 170, this.Frame.Width - 40, this.Frame.Height - 160);


            }
        }

        private void CountryCollection()
        {
            countryList.Add((NSString)"Afghanistan");
            countryList.Add((NSString)"Akrotiri");
            countryList.Add((NSString)"Albania");
            countryList.Add((NSString)"Algeria");
            countryList.Add((NSString)"American Samoa");
            countryList.Add((NSString)"Andorra");
            countryList.Add((NSString)"Angola");
            countryList.Add((NSString)"Anguilla");
            countryList.Add((NSString)"Antarctica");
            countryList.Add((NSString)"Antigua and Barbuda");
            countryList.Add((NSString)"Argentina");
            countryList.Add((NSString)"Armenia");
            countryList.Add((NSString)"Aruba");
            countryList.Add((NSString)"Ashmore and Cartier Islands");
            countryList.Add((NSString)"Australia");
            countryList.Add((NSString)"Austria");
            countryList.Add((NSString)"Azerbaijan");
            countryList.Add((NSString)"Bahamas, The");
            countryList.Add((NSString)"Bahrain");
            countryList.Add((NSString)"Bangladesh");
            countryList.Add((NSString)"Barbados");
            countryList.Add((NSString)"Bassas da India");
            countryList.Add((NSString)"Belarus");
            countryList.Add((NSString)"Belgium");
            countryList.Add((NSString)"Belize");
            countryList.Add((NSString)"Benin");
            countryList.Add((NSString)"Bermuda");
            countryList.Add((NSString)"Bhutan");
            countryList.Add((NSString)"Bolivia");
            countryList.Add((NSString)"Bosnia and Herzegovina");
            countryList.Add((NSString)"Botswana");
            countryList.Add((NSString)"Bouvet Island");
            countryList.Add((NSString)"Brazil");
            countryList.Add((NSString)"British Indian Ocean Territory");
            countryList.Add((NSString)"British Virgin Islands");
            countryList.Add((NSString)"Brunei");
            countryList.Add((NSString)"Bulgaria");
            countryList.Add((NSString)"Burkina Faso");
            countryList.Add((NSString)"Burma");
            countryList.Add((NSString)"Burundi");
            countryList.Add((NSString)"Cambodia");
            countryList.Add((NSString)"Cameroon");
            countryList.Add((NSString)"Canada");
            countryList.Add((NSString)"Cape Verde");
            countryList.Add((NSString)"Cayman Islands");
            countryList.Add((NSString)"Central African Republic");
            countryList.Add((NSString)"Chad");
            countryList.Add((NSString)"Chile");
            countryList.Add((NSString)"China");
            countryList.Add((NSString)"Christmas Island");
            countryList.Add((NSString)"Clipperton Island");
            countryList.Add((NSString)"Cocos (Keeling) Islands");
            countryList.Add((NSString)"Colombia");
            countryList.Add((NSString)"Comoros");
            countryList.Add((NSString)"Congo");
            countryList.Add((NSString)"Congo, Republic of the");
            countryList.Add((NSString)"Cook Islands");
            countryList.Add((NSString)"Coral Sea Islands");
            countryList.Add((NSString)"Costa Rica");
            countryList.Add((NSString)"Cote d'Ivoire");
            countryList.Add((NSString)"Croatia");
            countryList.Add((NSString)"Cuba");
            countryList.Add((NSString)"Cyprus");
            countryList.Add((NSString)"Czech Republic");
            countryList.Add((NSString)"Denmark");
            countryList.Add((NSString)"Dhekelia");
            countryList.Add((NSString)"Djibouti");
            countryList.Add((NSString)"Dominica");
            countryList.Add((NSString)"Dominican Republic");
            countryList.Add((NSString)"Ecuador");
            countryList.Add((NSString)"Egypt");
            countryList.Add((NSString)"El Salvador");
            countryList.Add((NSString)"Equatorial Guinea");
            countryList.Add((NSString)"Eritrea");
            countryList.Add((NSString)"Estonia");
            countryList.Add((NSString)"Ethiopia");
            countryList.Add((NSString)"Europa Island");
            countryList.Add((NSString)"Falkland Islands");
            countryList.Add((NSString)"Faroe Islands");
            countryList.Add((NSString)"Fiji");
            countryList.Add((NSString)"Finland");
            countryList.Add((NSString)"France");
            countryList.Add((NSString)"French Guiana");
            countryList.Add((NSString)"French Polynesia");
            countryList.Add((NSString)"French Southern and Antarctic Lands");
            countryList.Add((NSString)"Gabon");
            countryList.Add((NSString)"Gambia, The");
            countryList.Add((NSString)"Gaza Strip");
            countryList.Add((NSString)"Georgia");
            countryList.Add((NSString)"Germany");
            countryList.Add((NSString)"Ghana");
            countryList.Add((NSString)"Gibraltar");
            countryList.Add((NSString)"Glorioso Islands");
            countryList.Add((NSString)"Greece");
            countryList.Add((NSString)"Greenland");
            countryList.Add((NSString)"Grenada");
            countryList.Add((NSString)"Guadeloupe");
            countryList.Add((NSString)"Guam");
            countryList.Add((NSString)"Guatemala");
            countryList.Add((NSString)"Guernsey");
            countryList.Add((NSString)"Guinea");
            countryList.Add((NSString)"Guinea-Bissau");
            countryList.Add((NSString)"Guyana");
            countryList.Add((NSString)"Haiti");
            countryList.Add((NSString)"Heard Island and McDonald Islands");
            countryList.Add((NSString)"Holy See");
            countryList.Add((NSString)"Honduras");
            countryList.Add((NSString)"Hong Kong");
            countryList.Add((NSString)"Hungary");
            countryList.Add((NSString)"Iceland");
            countryList.Add((NSString)"India");
            countryList.Add((NSString)"Indonesia");
            countryList.Add((NSString)"Iran");
            countryList.Add((NSString)"Iraq");
            countryList.Add((NSString)"Ireland");
            countryList.Add((NSString)"Isle of Man");
            countryList.Add((NSString)"Israel");
            countryList.Add((NSString)"Italy");
            countryList.Add((NSString)"Jamaica");
            countryList.Add((NSString)"Jan Mayen");
            countryList.Add((NSString)"Japan");
            countryList.Add((NSString)"Jersey");
            countryList.Add((NSString)"Jordan");
            countryList.Add((NSString)"Juan de Nova Island");
            countryList.Add((NSString)"Kazakhstan");
            countryList.Add((NSString)"Kenya");
            countryList.Add((NSString)"Kiribati");
            countryList.Add((NSString)"Korea, North");
            countryList.Add((NSString)"Korea, South");
            countryList.Add((NSString)"Kuwait");
            countryList.Add((NSString)"Kyrgyzstan");
            countryList.Add((NSString)"Laos");
            countryList.Add((NSString)"Latvia");
            countryList.Add((NSString)"Lebanon");
            countryList.Add((NSString)"Lesotho");
            countryList.Add((NSString)"Liberia");
            countryList.Add((NSString)"Libya");
            countryList.Add((NSString)"Liechtenstein");
            countryList.Add((NSString)"Lithuania");
            countryList.Add((NSString)"Luxembourg");
            countryList.Add((NSString)"Macau");
            countryList.Add((NSString)"Macedonia");
            countryList.Add((NSString)"Madagascar");
            countryList.Add((NSString)"Malawi");
            countryList.Add((NSString)"Malaysia");
            countryList.Add((NSString)"Maldives");
            countryList.Add((NSString)"Mali");
            countryList.Add((NSString)"Malta");
            countryList.Add((NSString)"Marshall Islands");
            countryList.Add((NSString)"Martinique");
            countryList.Add((NSString)"Mauritania");
            countryList.Add((NSString)"Mauritius");
            countryList.Add((NSString)"Mayotte");
            countryList.Add((NSString)"Mexico");
            countryList.Add((NSString)"Micronesia");
            countryList.Add((NSString)"Moldova");
            countryList.Add((NSString)"Monaco");
            countryList.Add((NSString)"Mongolia");
            countryList.Add((NSString)"Montserrat");
            countryList.Add((NSString)"Morocco");
            countryList.Add((NSString)"Mozambique");
            countryList.Add((NSString)"Namibia");
            countryList.Add((NSString)"Nauru");
            countryList.Add((NSString)"Navassa Island");
            countryList.Add((NSString)"Nepal");
            countryList.Add((NSString)"Netherlands");
            countryList.Add((NSString)"Netherlands Antilles");
            countryList.Add((NSString)"New Caledonia");
            countryList.Add((NSString)"New Zealand");
            countryList.Add((NSString)"Nicaragua");
            countryList.Add((NSString)"Niger");
            countryList.Add((NSString)"Nigeria");
            countryList.Add((NSString)"Niue");
            countryList.Add((NSString)"Norfolk Island");
            countryList.Add((NSString)"Northern Mariana Islands");
            countryList.Add((NSString)"Norway");
            countryList.Add((NSString)"Oman");
            countryList.Add((NSString)"Pakistan");
            countryList.Add((NSString)"Palau");
            countryList.Add((NSString)"Panama");
            countryList.Add((NSString)"Papua New Guinea");
            countryList.Add((NSString)"Paracel Islands");
            countryList.Add((NSString)"Paraguay");
            countryList.Add((NSString)"Peru");
            countryList.Add((NSString)"Philippines");
            countryList.Add((NSString)"Pitcairn Islands");
            countryList.Add((NSString)"Poland");
            countryList.Add((NSString)"Portugal");
            countryList.Add((NSString)"Puerto Rico");
            countryList.Add((NSString)"Qatar");
            countryList.Add((NSString)"Reunion");
            countryList.Add((NSString)"Romania");
            countryList.Add((NSString)"Russia");
            countryList.Add((NSString)"Rwanda");
            countryList.Add((NSString)"Saint Helena");
            countryList.Add((NSString)"Saint Kitts and Nevis");
            countryList.Add((NSString)"Saint Lucia");
            countryList.Add((NSString)"Saint Pierre and Miquelon");
            countryList.Add((NSString)"Saint Vincent");
            countryList.Add((NSString)"Samoa");
            countryList.Add((NSString)"San Marino");
            countryList.Add((NSString)"Sao Tome and Principe");
            countryList.Add((NSString)"Saudi Arabia");
            countryList.Add((NSString)"Senegal");
            countryList.Add((NSString)"Serbia and Montenegro");
            countryList.Add((NSString)"Seychelles");
            countryList.Add((NSString)"Sierra Leone");
            countryList.Add((NSString)"Singapore");
            countryList.Add((NSString)"Slovakia");
            countryList.Add((NSString)"Slovenia");
            countryList.Add((NSString)"Solomon Islands");
            countryList.Add((NSString)"Somalia");
            countryList.Add((NSString)"South Africa");
            countryList.Add((NSString)"South Georgia");
            countryList.Add((NSString)"Spain");
            countryList.Add((NSString)"Spratly Islands");
            countryList.Add((NSString)"Sri Lanka");
            countryList.Add((NSString)"Sudan");
            countryList.Add((NSString)"Suriname");
            countryList.Add((NSString)"Svalbard");
            countryList.Add((NSString)"Swaziland");
            countryList.Add((NSString)"Sweden");
            countryList.Add((NSString)"Switzerland");
            countryList.Add((NSString)"Syria");
            countryList.Add((NSString)"Taiwan");
            countryList.Add((NSString)"Tajikistan");
            countryList.Add((NSString)"Tanzania");
            countryList.Add((NSString)"Thailand");
            countryList.Add((NSString)"Timor-Leste");
            countryList.Add((NSString)"Togo");
            countryList.Add((NSString)"Tokelau");
            countryList.Add((NSString)"Tonga");
            countryList.Add((NSString)"Trinidad and Tobago");
            countryList.Add((NSString)"Tromelin Island");
            countryList.Add((NSString)"Tunisia");
            countryList.Add((NSString)"Turkey");
            countryList.Add((NSString)"Turkmenistan");
            countryList.Add((NSString)"Turks and Caicos Islands");
            countryList.Add((NSString)"Tuvalu");
            countryList.Add((NSString)"Uganda");
            countryList.Add((NSString)"Ukraine");
            countryList.Add((NSString)"United Arab Emirates");
            countryList.Add((NSString)"United Kingdom");
            countryList.Add((NSString)"United States");
            countryList.Add((NSString)"Uruguay");
            countryList.Add((NSString)"Uzbekistan");
            countryList.Add((NSString)"Vanuatu");
            countryList.Add((NSString)"Venezuela");
            countryList.Add((NSString)"Vietnam");
            countryList.Add((NSString)"Virgin Islands");
            countryList.Add((NSString)"Wake Island");
            countryList.Add((NSString)"Wallis and Futuna");
            countryList.Add((NSString)"West Bank");
            countryList.Add((NSString)"Western Sahara");
            countryList.Add((NSString)"Yemen");
            countryList.Add((NSString)"Zambia");
            countryList.Add((NSString)"Zimbabwe");

        }


    }

  
}

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

    public class ToleratingTypos : SampleView
    {
        UILabel headerlabel;
        SfAutoComplete countryAutoComplete;
        UILabel searchresults;
        NSMutableArray countryList = new NSMutableArray();

        string[] tableItems;
        string[] imageItems;
        UITableView tableView;
        ToleratingTyposHelper helper;
        public ToleratingTypos()
        {

            headerlabel = new UILabel();
            headerlabel.Text = "Search by Countries";
            headerlabel.TextColor = UIColor.Black;
            headerlabel.TextAlignment = UITextAlignment.Left;
            this.AddSubview(headerlabel);

            countryAutoComplete = new SfAutoComplete();
            countryAutoComplete.Watermark = (NSString)"Search Here";
            countryAutoComplete.MaxDropDownHeight = 100;
            countryAutoComplete.FilterItemChanged += CountryAutoComplete_FilterItemChanged;
            this.AddSubview(countryAutoComplete);
            List<string> items = new List<string>();
            items.Add("Afghanistan");
            items.Add("Akrotiri");
            items.Add("Albania");
            items.Add("Algeria");
            items.Add("American Samoa");
            items.Add("Andorra");
            items.Add("Angola");
            items.Add("Anguilla");
            items.Add("Antarctica");
            items.Add("Antigua and Barbuda");
            items.Add("Argentina");
            items.Add("Armenia");
            items.Add("Aruba");
            items.Add("Ashmore and Cartier Islands");
            items.Add("Australia");
            items.Add("Austria");
            items.Add("Azerbaijan");
            items.Add("Bahamas, The");
            items.Add("Bahrain");
            items.Add("Bangladesh");
            items.Add("Barbados");
            items.Add("Bassas da India");
            items.Add("Belarus");
            items.Add("Bolivia");
            items.Add("Bosnia and Herzegovina");
            items.Add("Botswana");
            items.Add("Bouvet Island");
            items.Add("Brazil");
            items.Add("British Indian Ocean Territory");
            items.Add("British Virgin Islands");
            items.Add("Brunei");
            items.Add("Bulgaria");
            items.Add("Burkina Faso");
            items.Add("Burma");
            items.Add("Burundi");
            items.Add("Cambodia");
            items.Add("Cameroon");
            items.Add("Canada");
            items.Add("Cape Verde");
            items.Add("Cayman Islands");
            items.Add("Central African Republic");
            items.Add("Chad");
            items.Add("Chile");
            items.Add("China");
            items.Add("Christmas Island");
            items.Add("Clipperton Island");
            items.Add("Cocos (Keeling) Islands");
            items.Add("Colombia");
            items.Add("Comoros");
            items.Add("Congo");
            items.Add("Congo, Republic of the");
            items.Add("Cook Islands");
            items.Add("Coral Sea Islands");
            items.Add("Costa Rica");
            items.Add("Cote d'Ivoire");
            items.Add("Croatia");
            items.Add("Cuba");
            items.Add("Cyprus");
            items.Add("Czech Republic");
            items.Add("Denmark");
            items.Add("Dhekelia");
            items.Add("Djibouti");
            items.Add("Dominica");
            items.Add("Dominican Republic");
            items.Add("Ecuador");
            items.Add("Egypt");
            items.Add("El Salvador");
            items.Add("Equatorial Guinea");
            items.Add("Eritrea");
            items.Add("Estonia");
            items.Add("Ethiopia");
            items.Add("Europa Island");
            items.Add("Falkland Islands");
            items.Add("Faroe Islands");
            items.Add("Fiji");
            items.Add("Finland");
            items.Add("France");
            items.Add("French Guiana");
            items.Add("French Polynesia");
            items.Add("French Southern and Antarctic Lands");
            items.Add("Gabon");
            items.Add("Gambia, The");
            items.Add("Gaza Strip");
            items.Add("Georgia");
            items.Add("Germany");
            items.Add("Ghana");
            items.Add("Gibraltar");
            items.Add("Glorioso Islands");
            items.Add("Greece");
            items.Add("Greenland");
            items.Add("Grenada");
            items.Add("Guadeloupe");
            items.Add("Guam");
            items.Add("Guatemala");
            items.Add("Guernsey");
            items.Add("Guinea");
            items.Add("Guinea-Bissau");
            items.Add("Guyana");
            items.Add("Haiti");
            items.Add("Heard Island and McDonald Islands");
            items.Add("Holy See");
            items.Add("Honduras");
            items.Add("Hong Kong");
            items.Add("Hungary");
            items.Add("Iceland");
            items.Add("India");
            items.Add("Indonesia");
            items.Add("Iran");
            items.Add("Iraq");
            items.Add("Ireland");
            items.Add("Isle of Man");
            items.Add("Israel");
            items.Add("Italy");
            items.Add("Jamaica");
            items.Add("Jan Mayen");
            items.Add("Japan");
            items.Add("Jersey");
            items.Add("Jordan");
            items.Add("Juan de Nova Island");
            items.Add("Kazakhstan");
            items.Add("Kenya");
            items.Add("Kiribati");
            items.Add("Korea, North");
            items.Add("Korea, South");
            items.Add("Kuwait");
            items.Add("Kyrgyzstan");
            items.Add("Laos");
            items.Add("Latvia");
            items.Add("Lebanon");
            items.Add("Lesotho");
            items.Add("Liberia");
            items.Add("Libya");
            items.Add("Liechtenstein");
            items.Add("Lithuania");
            items.Add("Luxembourg");
            items.Add("Macau");
            items.Add("Macedonia");
            items.Add("Madagascar");
            items.Add("Malawi");
            items.Add("Malaysia");
            items.Add("Maldives");
            items.Add("Mali");
            items.Add("Malta");
            items.Add("Marshall Islands");
            items.Add("Martinique");
            items.Add("Mauritania");
            items.Add("Mauritius");
            items.Add("Mayotte");
            items.Add("Mexico");
            items.Add("Micronesia");
            items.Add("Moldova");
            items.Add("Monaco");
            items.Add("Mongolia");
            items.Add("Montserrat");
            items.Add("Morocco");
            items.Add("Mozambique");
            items.Add("Namibia");
            items.Add("Nauru");
            items.Add("Navassa Island");
            items.Add("Nepal");
            items.Add("Netherlands");
            items.Add("Netherlands Antilles");
            items.Add("New Caledonia");
            items.Add("New Zealand");
            items.Add("Nicaragua");
            items.Add("Niger");
            items.Add("Nigeria");
            items.Add("Niue");
            items.Add("Norfolk Island");
            items.Add("Northern Mariana Islands");
            items.Add("Norway");
            items.Add("Oman");
            items.Add("Pakistan");
            items.Add("Palau");
            items.Add("Panama");
            items.Add("Papua New Guinea");
            items.Add("Paracel Islands");
            items.Add("Paraguay");
            items.Add("Peru");
            items.Add("Philippines");
            items.Add("Pitcairn Islands");
            items.Add("Poland");
            items.Add("Portugal");
            items.Add("Puerto Rico");
            items.Add("Qatar");
            items.Add("Reunion");
            items.Add("Romania");
            items.Add("Russia");
            items.Add("Rwanda");
            items.Add("Saint Helena");
            items.Add("Saint Kitts and Nevis");
            items.Add("Saint Lucia");
            items.Add("Saint Pierre and Miquelon");
            items.Add("Saint Vincent");
            items.Add("Samoa");
            items.Add("San Marino");
            items.Add("Sao Tome and Principe");
            items.Add("Saudi Arabia");
            items.Add("Senegal");
            items.Add("Serbia and Montenegro");
            items.Add("Seychelles");
            items.Add("Sierra Leone");
            items.Add("Singapore");
            items.Add("Slovakia");
            items.Add("Slovenia");
            items.Add("Solomon Islands");
            items.Add("Somalia");
            items.Add("South Africa");
            items.Add("South Georgia");
            items.Add("Spain");
            items.Add("Spratly Islands");
            items.Add("Sri Lanka");
            items.Add("Sudan");
            items.Add("Suriname");
            items.Add("Svalbard");
            items.Add("Swaziland");
            items.Add("Sweden");
            items.Add("Switzerland");
            items.Add("Syria");
            items.Add("Taiwan");
            items.Add("Tajikistan");
            items.Add("Tanzania");
            items.Add("Thailand");
            items.Add("Timor-Leste");
            items.Add("Togo");
            items.Add("Tokelau");
            items.Add("Tonga");
            items.Add("Trinidad and Tobago");
            items.Add("Tromelin Island");
            items.Add("Tunisia");
            items.Add("Turkey");
            items.Add("Turkmenistan");
            items.Add("Turks and Caicos Islands");
            items.Add("Tuvalu");
            items.Add("Uganda");
            items.Add("Ukraine");
            items.Add("United Arab Emirates");
            items.Add("United Kingdom");
            items.Add("United States");
            items.Add("Uruguay");
            items.Add("Uzbekistan");
            items.Add("Vanuatu");
            items.Add("Venezuela");
            items.Add("Vietnam");
            items.Add("Virgin Islands");
            items.Add("Wake Island");
            items.Add("Wallis and Futuna");
            items.Add("West Bank");
            items.Add("Western Sahara");
            items.Add("Yemen");
            items.Add("Zambia");
            items.Add("Zimbabwe");
          

            countryAutoComplete.DataSource = items;
            countryAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeCustom;
            searchresults = new UILabel();
            searchresults.Text = "Search Results";
            searchresults.TextColor = UIColor.Gray;
            searchresults.TextAlignment = UITextAlignment.Left;
            this.AddSubview(searchresults);
            tableView = new UITableView();
            tableView.RowHeight = 60;
            tableItems = new string[] { "General", "Maps", "News", "Video", "Music", "Books", "Flight", "Quick Search" };
            imageItems = new string[] { "all.png", "Maps1.png", "Newspaper.png", "Media.png", "Music.png", "Book.png", "Aeroplane.png", "Picture.png" };

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
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                headerlabel.Frame = new CGRect(10, 10, view.Frame.Width - 20, 30);
                countryAutoComplete.Frame = new CGRect(10, 40, view.Frame.Width, 40);
                searchresults.Frame = new CGRect(10, 90, this.Frame.Width, 30);
                tableView.Frame = new CGRect(10, 130, this.Frame.Width - 20, this.Frame.Height - 160);

            }
        }

          


    }

    public class ToleratingTypoTableView : UITableViewSource
    {
        string cellIdentifier = "TableCell";
        public bool customise;
        string[] tableItems;
        string[] imageItems;
        public int random = 0;
        internal bool initial;
        public ToleratingTypoTableView(string[] _items)
        {
            tableItems = _items;
        }
        public ToleratingTypoTableView(string[] _items, string[] _imageItems)
        {
            tableItems = _items;
            imageItems = _imageItems;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {

        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            int i = tableItems.Length;
            return (nint)i;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
            }
            UIView parentView = new UIView();
            parentView.Frame = new CGRect(0, 0, cell.Bounds.Width, tableView.RowHeight);
            UIImageView imageView = new UIImageView();
            imageView.Frame = new CGRect(5, 5, 50, tableView.RowHeight - 10);
            UILabel titleLabel = new UILabel();
            titleLabel.Frame = new CGRect(60, 5, cell.Bounds.Width-65, tableView.RowHeight/2-5);
            titleLabel.TextAlignment = UITextAlignment.Left;
            UILabel resultLabel = new UILabel();
            resultLabel.Frame = new CGRect(60, tableView.RowHeight/2, cell.Bounds.Width - 65, tableView.RowHeight / 2-5);
            resultLabel.TextAlignment = UITextAlignment.Left;
            
            imageView.Image = new UIImage(imageItems[indexPath.Row]);
            titleLabel.Text = tableItems[indexPath.Row];
            resultLabel.Text="About " + random.ToString() + " results";
            
            parentView.AddSubview(imageView);
            parentView.AddSubview(titleLabel);
            parentView.AddSubview(resultLabel);
            foreach(var views in cell.Subviews)
            {
                views.RemoveFromSuperview();
            }
            cell.AddSubview(parentView);
            if (initial)
            random = random + new Random().Next(300, 999);
            return cell;
        }
    }
}

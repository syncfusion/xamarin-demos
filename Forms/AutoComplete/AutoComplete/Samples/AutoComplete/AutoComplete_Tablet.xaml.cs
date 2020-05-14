#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfAutoComplete.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser.SfAutoComplete
{
    public partial class AutoComplete_Tablet : SampleView
    {
        List<String> jobList { get; set; }
        List<String> countryList { get; set; }
        List<String> experienceList { get; set; }
        String valueCountry, valueJobField;
        int minpref=1, maxDrop = 150, pop=100;

        public AutoComplete_Tablet()
        {
            InitializeComponent();

            addCountryList();
            jobFieldAutoComplete.BindingContext = jobList;
            countryAutoComplete.BindingContext = countryList;
           
            AddValueChangedEvent();
            AddOptionPageItems();
        }
          


         void addCountryList()
        {
            countryList = new List<string>();
            countryList.Add("Afghanistan");
            countryList.Add("Akrotiri");
            countryList.Add("Albania");
            countryList.Add("Algeria");
            countryList.Add("American Samoa");
            countryList.Add("Andorra");
            countryList.Add("Angola");
            countryList.Add("Anguilla");
            countryList.Add("Antarctica");
            countryList.Add("Antigua and Barbuda");
            countryList.Add("Argentina");
            countryList.Add("Armenia");
            countryList.Add("Aruba");
            countryList.Add("Ashmore and Cartier Islands");
            countryList.Add("Australia");
            countryList.Add("Austria");
            countryList.Add("Azerbaijan");
            countryList.Add("Bahamas, The");
            countryList.Add("Bahrain");
            countryList.Add("Bangladesh");
            countryList.Add("Barbados");
            countryList.Add("Bassas da India");
            countryList.Add("Belarus");
            countryList.Add("Belgium");
            countryList.Add("Belize");
            countryList.Add("Benin");
            countryList.Add("Bermuda");
            countryList.Add("Bhutan");
            countryList.Add("Bolivia");
            countryList.Add("Bosnia and Herzegovina");
            countryList.Add("Botswana");
            countryList.Add("Bouvet Island");
            countryList.Add("Brazil");
            countryList.Add("British Indian Ocean Territory");
            countryList.Add("British Virgin Islands");
            countryList.Add("Brunei");
            countryList.Add("Bulgaria");
            countryList.Add("Burkina Faso");
            countryList.Add("Burma");
            countryList.Add("Burundi");
            countryList.Add("Cambodia");
            countryList.Add("Cameroon");
            countryList.Add("Canada");
            countryList.Add("Cape Verde");
            countryList.Add("Cayman Islands");
            countryList.Add("Central African Republic");
            countryList.Add("Chad");
            countryList.Add("Chile");
            countryList.Add("China");
            countryList.Add("Christmas Island");
            countryList.Add("Clipperton Island");
            countryList.Add("Cocos (Keeling) Islands");
            countryList.Add("Colombia");
            countryList.Add("Comoros");
            countryList.Add("Congo");
            countryList.Add("Congo, Republic of the");
            countryList.Add("Cook Islands");
            countryList.Add("Coral Sea Islands");
            countryList.Add("Costa Rica");
            countryList.Add("Cote d'Ivoire");
            countryList.Add("Croatia");
            countryList.Add("Cuba");
            countryList.Add("Cyprus");
            countryList.Add("Czech Republic");
            countryList.Add("Denmark");
            countryList.Add("Dhekelia");
            countryList.Add("Djibouti");
            countryList.Add("Dominica");
            countryList.Add("Dominican Republic");
            countryList.Add("Ecuador");
            countryList.Add("Egypt");
            countryList.Add("El Salvador");
            countryList.Add("Equatorial Guinea");
            countryList.Add("Eritrea");
            countryList.Add("Estonia");
            countryList.Add("Ethiopia");
            countryList.Add("Europa Island");
            countryList.Add("Falkland Islands");
            countryList.Add("Faroe Islands");
            countryList.Add("Fiji");
            countryList.Add("Finland");
            countryList.Add("France");
            countryList.Add("French Guiana");
            countryList.Add("French Polynesia");
            countryList.Add("French Southern and Antarctic Lands");
            countryList.Add("Gabon");
            countryList.Add("Gambia, The");
            countryList.Add("Gaza Strip");
            countryList.Add("Georgia");
            countryList.Add("Germany");
            countryList.Add("Ghana");
            countryList.Add("Gibraltar");
            countryList.Add("Glorioso Islands");
            countryList.Add("Greece");
            countryList.Add("Greenland");
            countryList.Add("Grenada");
            countryList.Add("Guadeloupe");
            countryList.Add("Guam");
            countryList.Add("Guatemala");
            countryList.Add("Guernsey");
            countryList.Add("Guinea");
            countryList.Add("Guinea-Bissau");
            countryList.Add("Guyana");
            countryList.Add("Haiti");
            countryList.Add("Heard Island and McDonald Islands");
            countryList.Add("Holy See");
            countryList.Add("Honduras");
            countryList.Add("Hong Kong");
            countryList.Add("Hungary");
            countryList.Add("Iceland");
            countryList.Add("India");
            countryList.Add("Indonesia");
            countryList.Add("Iran");
            countryList.Add("Iraq");
            countryList.Add("Ireland");
            countryList.Add("Isle of Man");
            countryList.Add("Israel");
            countryList.Add("Italy");
            countryList.Add("Jamaica");
            countryList.Add("Jan Mayen");
            countryList.Add("Japan");
            countryList.Add("Jersey");
            countryList.Add("Jordan");
            countryList.Add("Juan de Nova Island");
            countryList.Add("Kazakhstan");
            countryList.Add("Kenya");
            countryList.Add("Kiribati");
            countryList.Add("Korea, North");
            countryList.Add("Korea, South");
            countryList.Add("Kuwait");
            countryList.Add("Kyrgyzstan");
            countryList.Add("Laos");
            countryList.Add("Latvia");
            countryList.Add("Lebanon");
            countryList.Add("Lesotho");
            countryList.Add("Liberia");
            countryList.Add("Libya");
            countryList.Add("Liechtenstein");
            countryList.Add("Lithuania");
            countryList.Add("Luxembourg");
            countryList.Add("Macau");
            countryList.Add("Macedonia");
            countryList.Add("Madagascar");
            countryList.Add("Malawi");
            countryList.Add("Malaysia");
            countryList.Add("Maldives");
            countryList.Add("Mali");
            countryList.Add("Malta");
            countryList.Add("Marshall Islands");
            countryList.Add("Martinique");
            countryList.Add("Mauritania");
            countryList.Add("Mauritius");
            countryList.Add("Mayotte");
            countryList.Add("Mexico");
            countryList.Add("Micronesia");
            countryList.Add("Moldova");
            countryList.Add("Monaco");
            countryList.Add("Mongolia");
            countryList.Add("Montserrat");
            countryList.Add("Morocco");
            countryList.Add("Mozambique");
            countryList.Add("Namibia");
            countryList.Add("Nauru");
            countryList.Add("Navassa Island");
            countryList.Add("Nepal");
            countryList.Add("Netherlands");
            countryList.Add("Netherlands Antilles");
            countryList.Add("New Caledonia");
            countryList.Add("New Zealand");
            countryList.Add("Nicaragua");
            countryList.Add("Niger");
            countryList.Add("Nigeria");
            countryList.Add("Niue");
            countryList.Add("Norfolk Island");
            countryList.Add("Northern Mariana Islands");
            countryList.Add("Norway");
            countryList.Add("Oman");
            countryList.Add("Pakistan");
            countryList.Add("Palau");
            countryList.Add("Panama");
            countryList.Add("Papua New Guinea");
            countryList.Add("Paracel Islands");
            countryList.Add("Paraguay");
            countryList.Add("Peru");
            countryList.Add("Philippines");
            countryList.Add("Pitcairn Islands");
            countryList.Add("Poland");
            countryList.Add("Portugal");
            countryList.Add("Puerto Rico");
            countryList.Add("Qatar");
            countryList.Add("Reunion");
            countryList.Add("Romania");
            countryList.Add("Russia");
            countryList.Add("Rwanda");
            countryList.Add("Saint Helena");
            countryList.Add("Saint Kitts and Nevis");
            countryList.Add("Saint Lucia");
            countryList.Add("Saint Pierre and Miquelon");
            countryList.Add("Saint Vincent");
            countryList.Add("Samoa");
            countryList.Add("San Marino");
            countryList.Add("Sao Tome and Principe");
            countryList.Add("Saudi Arabia");
            countryList.Add("Senegal");
            countryList.Add("Serbia and Montenegro");
            countryList.Add("Seychelles");
            countryList.Add("Sierra Leone");
            countryList.Add("Singapore");
            countryList.Add("Slovakia");
            countryList.Add("Slovenia");
            countryList.Add("Solomon Islands");
            countryList.Add("Somalia");
            countryList.Add("South Africa");
            countryList.Add("South Georgia");
            countryList.Add("Spain");
            countryList.Add("Spratly Islands");
            countryList.Add("Sri Lanka");
            countryList.Add("Sudan");
            countryList.Add("Suriname");
            countryList.Add("Svalbard");
            countryList.Add("Swaziland");
            countryList.Add("Sweden");
            countryList.Add("Switzerland");
            countryList.Add("Syria");
            countryList.Add("Taiwan");
            countryList.Add("Tajikistan");
            countryList.Add("Tanzania");
            countryList.Add("Thailand");
            countryList.Add("Timor-Leste");
            countryList.Add("Togo");
            countryList.Add("Tokelau");
            countryList.Add("Tonga");
            countryList.Add("Trinidad and Tobago");
            countryList.Add("Tromelin Island");
            countryList.Add("Tunisia");
            countryList.Add("Turkey");
            countryList.Add("Turkmenistan");
            countryList.Add("Turks and Caicos Islands");
            countryList.Add("Tuvalu");
            countryList.Add("Uganda");
            countryList.Add("Ukraine");
            countryList.Add("United Arab Emirates");
            countryList.Add("United Kingdom");
            countryList.Add("United States");
            countryList.Add("Uruguay");
            countryList.Add("Uzbekistan");
            countryList.Add("Vanuatu");
            countryList.Add("Venezuela");
            countryList.Add("Vietnam");
            countryList.Add("Virgin Islands");
            countryList.Add("Wake Island");
            countryList.Add("Wallis and Futuna");
            countryList.Add("West Bank");
            countryList.Add("Western Sahara");
            countryList.Add("Yemen");
            countryList.Add("Zambia");
            countryList.Add("Zimbabwe");

            jobList = new List<string>();
            jobList.Add("Banking");
            jobList.Add("Media");
            jobList.Add("Medical");
            jobList.Add("Software");

            List<string> dataSource = new List<string>();
            dataSource.Add("1 year");
            dataSource.Add("2 years");
            dataSource.Add("3 years");
            experienceAutoComplete.DataSource = dataSource;

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (countryList.Contains(countryAutoComplete.Text) && jobList.Contains(jobFieldAutoComplete.Text))
            {
                Random r = new Random();

                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Results", "There are " + r.Next(9, 50) + " " + jobFieldAutoComplete.Text + " jobs found in " + countryAutoComplete.Text + ".", "Ok");
            }
            else
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Results", "0 job found", "OK");
            }
        }

        void AddValueChangedEvent()
        {
            countryAutoComplete.ValueChanged += (object sender, Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs e) =>
            {
                valueCountry = e.Value;
            };
            jobFieldAutoComplete.ValueChanged += (object sender, Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs e) =>
            {
                valueJobField = e.Value;
            };
            countryAutoComplete.SelectionChanged += (sender, e) =>
            {
                if (Device.RuntimePlatform == Device.iOS)
                    valueCountry = e.Value.ToString();
            };
            jobFieldAutoComplete.SelectionChanged += (sender, e) =>
            {
                if (Device.RuntimePlatform == Device.iOS)
                    valueJobField = e.Value.ToString();
            };

        }
         
        public void SelectionIndex_Changed(object c, EventArgs e)
        {
            if (suggestionModepicker != null)
            {
                switch (suggestionModepicker.SelectedIndex)
                {
                    case 0:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.StartsWith;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.StartsWith;
                        }
                        break;
                    case 1:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.StartsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.StartsWithCaseSensitive;
                        }
                        break;
                    case 2:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.Contains;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.Contains;
                        }
                        break;
                    case 3:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.ContainsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.ContainsWithCaseSensitive;
                        }
                        break;
                    case 4:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.EndsWith;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.EndsWith;
                        }
                        break;
                    case 5:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.EndsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.EndsWithCaseSensitive;
                        }

                        break;
                    case 6:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.Equals;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.Equals;
                         }
                        break;
                    case 7:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.EqualsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.EqualsWithCaseSensitive;
                        }
                        break;
                }
            }
        }
        public void autoCompleteModepicker_Changed(object c, EventArgs e)
        {
            if (autoCompleteModepicker != null)
            {
                switch (autoCompleteModepicker.SelectedIndex)
                {
                    case 0:
                        {
                            countryAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
                            jobFieldAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
                        }
                        break;
                    case 1:
                        {
                            countryAutoComplete.AutoCompleteMode = AutoCompleteMode.Append;
                            jobFieldAutoComplete.AutoCompleteMode = AutoCompleteMode.Append;
                        }
                        break;
                    case 2:
                        {
                            countryAutoComplete.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            jobFieldAutoComplete.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        }
                        break;
                }
            }

        }

        //autocomplete mode selected index change
        public void PrefixCharacter_Changed(object c, TextChangedEventArgs e)
        {
            if (minPrefixCharacterText != null)
            {
                if (e.NewTextValue.Length > 0)
                {
                    int minimumPrefixCharacters;
                    if (int.TryParse(e.NewTextValue, out minimumPrefixCharacters))
                    {
                        countryAutoComplete.MinimumPrefixCharacters = minimumPrefixCharacters;
                        jobFieldAutoComplete.MinimumPrefixCharacters = minimumPrefixCharacters;
                        minpref = minimumPrefixCharacters;
                    }
                }
            }
        }
        public void MaximumHeight_Changed(object c, TextChangedEventArgs e)
        {
            if (maximumDropDownHeightText != null)
            {
                if (e.NewTextValue.Length > 0)
                {
                    int maximumDropDownHeight;
                    if (int.TryParse(e.NewTextValue, out maximumDropDownHeight))
                    {
                        countryAutoComplete.MaximumDropDownHeight = maximumDropDownHeight;
                        jobFieldAutoComplete.MaximumDropDownHeight = maximumDropDownHeight;
                        maxDrop = maximumDropDownHeight;
                    }
                }
            }

        }
        public void PopUp_Changed(object c, TextChangedEventArgs e)
        {

            if (PopupDelayText != null)
            {
                if (e.NewTextValue.Length > 0)
                {
                    int popupDelay;
                    if (int.TryParse(e.NewTextValue, out popupDelay))
                    {
                        countryAutoComplete.PopupDelay = popupDelay;
                        jobFieldAutoComplete.PopupDelay = popupDelay;
                        pop = popupDelay;
                    }
                }
            }
        }
        public void search_Clicked(object c, EventArgs e)
        {
            if (valueCountry != "" && valueJobField != "")
            {
                Random r = new Random();
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Results", r.Next(9, 50) + " Jobs found", "OK");
            }
            else
            {
				Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Results", "0 Jobs found", "OK");
            }
        }


        void AddOptionPageItems()
        {
            suggestionModepicker.Items.Add("StartsWith");
            suggestionModepicker.Items.Add("StartsWithCaseSensitive");
            suggestionModepicker.Items.Add("Contains");
            suggestionModepicker.Items.Add("ContainsWithCaseSensitive");
            suggestionModepicker.Items.Add("EndsWith");
            suggestionModepicker.Items.Add("EndsWithCaseSensitive");
            suggestionModepicker.Items.Add("Equals");
            suggestionModepicker.Items.Add("EqualsWithCaseSensitive");
            //AutoCompleteModePicker Items
            autoCompleteModepicker.Items.Add("Suggest");
            autoCompleteModepicker.Items.Add("Append");
            autoCompleteModepicker.Items.Add("SuggestAppend");
            autoCompleteModepicker.SelectedIndex = 0;
            suggestionModepicker.SelectedIndex = 0;
            valueCountry = string.Empty;
            valueJobField = string.Empty;

            maximumDropDownHeightText.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                if (e.NewTextValue.Length > 0)
                {
                    int maximumDropDownHeight;
                    if (int.TryParse(e.NewTextValue, out maximumDropDownHeight))
                    {
                        countryAutoComplete.MaximumDropDownHeight = maximumDropDownHeight;
                        jobFieldAutoComplete.MaximumDropDownHeight = maximumDropDownHeight;
                    }
                }
                else
                {
                    countryAutoComplete.MaximumDropDownHeight = 100;
                    jobFieldAutoComplete.MaximumDropDownHeight = 100;
                }
            };
            minPrefixCharacterText.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                if (e.NewTextValue.Length > 0)
                {
                    int minimumPrefixCharacters;
                    if (int.TryParse(e.NewTextValue, out minimumPrefixCharacters))
                    {
                        countryAutoComplete.MinimumPrefixCharacters = minimumPrefixCharacters;
                        jobFieldAutoComplete.MinimumPrefixCharacters = minimumPrefixCharacters;
                    }
                }
                else
                {
                    countryAutoComplete.MinimumPrefixCharacters = 1;
                    jobFieldAutoComplete.MinimumPrefixCharacters = 1;
                }
            };
            PopupDelayText.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                if (e.NewTextValue.Length > 0)
                {
                    int popupDelay;
                    if (int.TryParse(e.NewTextValue, out popupDelay))
                    {
                        countryAutoComplete.PopupDelay = popupDelay;
                        jobFieldAutoComplete.PopupDelay = popupDelay;
                    }
                }
                else
                {
                    countryAutoComplete.PopupDelay = 0;
                    jobFieldAutoComplete.PopupDelay = 0;
                }
            };
            // suggestion mode selected index change 
            suggestionModepicker.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                switch (suggestionModepicker.SelectedIndex)
                {
                    case 0:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.StartsWith;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.StartsWith;
                        }
                        break;
                    case 1:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.StartsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.StartsWithCaseSensitive;
                        }
                        break;
                    case 2:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.Contains;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.Contains;
                        }
                        break;
                    case 3:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.ContainsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.ContainsWithCaseSensitive;
                        }
                        break;
                    case 4:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.EndsWith;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.EndsWith;
                        }
                        break;
                    case 5:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.EndsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.EndsWithCaseSensitive;
                        }
                        break;
                    case 6:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.Equals;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.Equals;
                        }
                        break;
                    case 7:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.EqualsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.EqualsWithCaseSensitive;
                        }
                        break;
                }
            };
            //autocomplete mode selected index change
            autoCompleteModepicker.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                switch (autoCompleteModepicker.SelectedIndex)
                {
                    case 0:
                        {
                            countryAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
                            jobFieldAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
                        }
                        break;
                    case 1:
                        {
                            countryAutoComplete.AutoCompleteMode = AutoCompleteMode.Append;
                            jobFieldAutoComplete.AutoCompleteMode = AutoCompleteMode.Append;
                        }
                        break;
                    case 2:
                        {
                            countryAutoComplete.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            jobFieldAutoComplete.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        }
                        break;
                }
            };

                popupDelayLabel.WidthRequest = 220;
                searchButton.BackgroundColor = Color.FromHex("#2196f3");
                searchButton.CornerRadius = 1;
                searchButton.BorderWidth = 0;
                searchButton.TextColor = Color.White;
                searchButton.FontFamily = "Roboto";

                jobSearchLabel.TextColor = Color.FromHex("#666666");
             
                countryAutoComplete.TextColor = Color.FromHex("#333333");
              
                jobFieldAutoComplete.TextColor = Color.FromHex("#333333");
               
                suggestionModeLabel.TextColor = Color.FromHex("#666666");
                suggestionModepicker.TextColor = Color.FromHex("#333333");
                autoCompleteModeLabel.TextColor = Color.FromHex("#666666");
                autoCompleteModepicker.TextColor = Color.FromHex("#333333");
                minimumPrefixCharacterLabel.TextColor = Color.FromHex("#666666");
                minPrefixCharacterText.TextColor = Color.FromHex("#333333");
                maximumDropDownHeightLabel.TextColor = Color.FromHex("#666666");
                maximumDropDownHeightText.TextColor = Color.FromHex("#333333");
                popupDelayLabel.TextColor = Color.FromHex("#666666");
                PopupDelayText.TextColor = Color.FromHex("#333333");

                pickerLayout1.Padding = new Thickness(-2, 0, 0, 0);
                pickerLayout2.Margin = new Thickness(-2, 0, 0, 0);
              
         
        
          
        }
        public View getContent()
        {
            return this.Content;
        }
        public View getPropertyView()
        {
            return this.PropertyView;
        }

        void Handle_SelectionChanged(object sender, Syncfusion.SfAutoComplete.XForms.SelectionChangedEventArgs e)
        {
            if (experienceAutoComplete.SelectedIndex == 0)
            {
                experienceAutoComplete.Text = "1 year";
            }
            else if (experienceAutoComplete.SelectedIndex == 1)
            {
                experienceAutoComplete.Text = "2 years";
            }
            else if (experienceAutoComplete.SelectedIndex == 2)
            {
                experienceAutoComplete.Text = "3 years";
            }
        }
    }
}



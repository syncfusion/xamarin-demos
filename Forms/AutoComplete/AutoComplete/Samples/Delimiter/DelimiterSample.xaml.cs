#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfAutoComplete
{
	public partial class DelimiterSample : SampleView
	{
		List<string> countryList;
		public DelimiterSample()
		{
			InitializeComponent();
			AddListItems();
			autocomplete.DataSource = countryList;

			InitializeDelimiterpicker();
			InitializeBackgroundPicker();
			InitializeBorderPicker();


		}

		public Color GetColor(int index)
		{
			Color selectedColor = Color.Black;
			switch (index)
			{
				case 0:
					{
						selectedColor = Color.Violet;
					}
					break;
				case 1:
					{
						selectedColor = Color.Indigo;
					}
					break;
				case 2:
					{
						selectedColor = Color.Blue;
					}
					break;
				case 3:
					{
						selectedColor = Color.Green;
					}
					break;
				case 4:
					{
						selectedColor = Color.Yellow;
					}
					break;
				case 5:
					{
						selectedColor = Color.Orange;
					}
					break;
				case 6:
					{
						selectedColor = Color.Red;
					}
					break;
			}
			return selectedColor;
		}
		public void InitializeBorderPicker()
		{
			Borderpicker.Items.Add("Violet");
			Borderpicker.Items.Add("Indigo");
			Borderpicker.Items.Add("Blue");
			Borderpicker.Items.Add("Green");
			Borderpicker.Items.Add("Yellow");
			Borderpicker.Items.Add("Orange");
			Borderpicker.Items.Add("Red");
			Borderpicker.SelectedIndex = 0;

			Borderpicker.SelectedIndexChanged += (object sender, EventArgs e) =>
			{
				var selectedValue = GetColor(Borderpicker.SelectedIndex);
				this.autocomplete.TextColor = selectedValue;
				this.autocomplete.DropDownTextColor = selectedValue;
				this.autocomplete.BorderColor = selectedValue;
				this.autocomplete.ClearButtonColor = selectedValue;
				Footerlabel.TextColor = Headerlabel.TextColor = selectedValue;


			};
		}
		public void InitializeBackgroundPicker()
		{
			BackgroundColorPicker.Items.Add("Violet");
			BackgroundColorPicker.Items.Add("Indigo");
			BackgroundColorPicker.Items.Add("Blue");
			BackgroundColorPicker.Items.Add("Green");
			BackgroundColorPicker.Items.Add("Yellow");
			BackgroundColorPicker.Items.Add("Orange");
			BackgroundColorPicker.Items.Add("Red");
			BackgroundColorPicker.SelectedIndex = 0;

			BackgroundColorPicker.SelectedIndexChanged += (object sender, EventArgs e) =>
			{
				var selectedValue = GetColor(BackgroundColorPicker.SelectedIndex);
				this.autocomplete.DropDownBackgroundColor = selectedValue;
				this.autocomplete.BackgroundColor = selectedValue;
			};
		}
		public void InitializeDelimiterpicker()
		{
			delimiterpicker.Items.Add(",");
			delimiterpicker.Items.Add("#");
			delimiterpicker.Items.Add("*");
			delimiterpicker.SelectedIndex = 0;

			delimiterpicker.SelectedIndexChanged += (object sender, EventArgs e) =>
			{
				switch (delimiterpicker.SelectedIndex)
				{
					case 0:
						{
							autocomplete.Delimiter = ",";
						}
						break;
					case 1:
						{
							autocomplete.Delimiter = "#";
						}
						break;
					case 2:
						{
							autocomplete.Delimiter = "*";
						}
						break;
				}
			};
		}

		void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			//if (autocomplete != null)
           // autocomplete.IsClearButtonVisible = e.Value;
		}

		void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
		{
			var item = (sender as Slider).AutomationId.ToString();

			if (item == "Height")
			{
				var heightValue = (int)(e.NewValue + 20) * 2;
				this.autocomplete.DropDownHeaderViewHeight = this.autocomplete.DropDownFooterViewHeight = autocomplete.HeightRequest = autocomplete.DropDownItemHeight = heightValue + 10;
				Headerlabel.FontSize = Footerlabel.FontSize = autocomplete.TextSize = autocomplete.DropDownTextSize = heightValue / 2;
			}
			else if (item == "CornerRadius")
				autocomplete.DropDownCornerRadius = e.NewValue;
			else if (item == "ItemsHeight")
				autocomplete.DropDownCornerRadius = e.NewValue * 2;

		}

		private double cornerRadius = 0;

		public double CornerRadius
		{
			get { return cornerRadius; }
			set
			{
				cornerRadius = value;
				RaisePropertyChanged("CornerRadius");
			}
		}

		#region INotifyPropertyChanged implementation

		public new event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		#endregion

		void AddListItems()
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
			countryList.Add("The Gambia");
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
		}
	}
}

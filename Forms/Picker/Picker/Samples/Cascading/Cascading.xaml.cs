#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace SampleBrowser.SfPicker
{
	public partial class Cascading : SampleView
	{
		Random r = new Random();
		ObservableCollection<object> column1Source = new ObservableCollection<object>();
		ObservableCollection<object> Source { get; set; }
		ObservableCollection<object> Source2 { get; set; }
		Dictionary<string, string> flags = new Dictionary<string, string>();
        public string str = "";
		public Cascading()
		{

			InitializeComponent();

			frompicker.Parent = tempGrid;
			topicker.Parent = tempGrid;
			arrivepicker.Parent = tempGrid;
			departpicker.Parent = tempGrid;
			submit.Clicked += Submit_Clicked;
			flags.Add("UK", "uk.png");
			flags.Add("USA", "usa.png");
			flags.Add("UAE", "uae.png");
			flags.Add("India", "india.png");
			flags.Add("Germany","germany.png");
			ObservableCollection<object> column2Source = new ObservableCollection<object>();
			column1Source.Add("UK");
			column1Source.Add("USA");
			column1Source.Add("India");
			column1Source.Add("UAE");
			column1Source.Add("Germany");
			column2Source = GetCity("India");

			Source = new ObservableCollection<object>();
			Source2 = new ObservableCollection<object>();
			Source.Add(column1Source);
			Source.Add(column2Source);
			Source2.Add(column1Source);
			Source2.Add(GetCity2("USA"));
			frompicker.SelectionChanged += Picker_SelectionChanged;
			frompicker.ItemsSource = Source;
			frompicker.Opened += Frompicker_OnPopUpOpened;
			frompicker.OnColumnLoaded += Frompicker_OnColumnLoaded;
			if (Device.RuntimePlatform != Device.Android)
				frompicker.OnPickerItemLoaded += Frompicker_OnPickerItemLoaded;
			frompicker.ShowColumnHeader = true;
			ObservableCollection<string> columnHeaderCollection = new ObservableCollection<string>();
			if (Device.RuntimePlatform == Device.Android)
			{
				columnHeaderCollection.Add("COUNTRY");
				columnHeaderCollection.Add("CITY");
                frompicker.PickerWidth = 300;
                topicker.PickerWidth=300;
                departpicker.PickerWidth = 350;
                arrivepicker.PickerWidth = 350;
                departpicker.ColumnHeaderFontSize = 12;
                arrivepicker.ColumnHeaderFontSize = 12;
                btn1.WidthRequest = 30;
                btn2.WidthRequest = 30;
                btn3.WidthRequest = 30;
                btn4.WidthRequest = 30;
			}
			else
			{
				columnHeaderCollection.Add("Country");
				columnHeaderCollection.Add("City");
			}
			frompicker.ColumnHeaderText = columnHeaderCollection;
			frompicker.OkButtonClicked += Frompicker_OkButtonClicked;
			frompicker.CancelButtonClicked += Frompicker_CancelButtonClicked;

			topicker.SelectionChanged += Picker_SelectionChanged1;
			topicker.ItemsSource = Source2;
			topicker.ShowColumnHeader = true;
			topicker.ColumnHeaderText = columnHeaderCollection;
			topicker.CancelButtonClicked += Topicker_CancelButtonClicked;
			topicker.OkButtonClicked += Topicker_OkButtonClicked;
			topicker.Opened += Topicker_OnPopUpOpened;
			topicker.OnColumnLoaded += Topicker_OnColumnLoaded;
			if (Device.RuntimePlatform != Device.Android)
				topicker.OnPickerItemLoaded += Topicker_OnPickerItemLoaded;
			frompicker.Parent = tempGrid;
			topicker.Parent = tempGrid;
			departpicker.OnColumnLoaded += Departpicker_OnColumnLoaded;
			arrivepicker.OnColumnLoaded += Arrivepicker_OnColumnLoaded;
            str = DateTime.Now.Day.ToString();
            if (str.Length == 1)
            {
                str = "0" + str;
            }
            startdate.Text = DateTime.Now.Year.ToString() + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3) + " " + str + " " + DateTime.Now.ToString("hh") + ":" + DateTime.Now.ToString("mm");
            enddate.Text = DateTime.Now.Year.ToString() + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3) + " " + str + " " + " " + DateTime.Now.ToString("hh") + ":" + DateTime.Now.ToString("mm");

			todaycollection.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month));
			if (DateTime.Now.Date.Day < 10)
				todaycollection.Add("0" + DateTime.Now.Date.Day);
			else
				todaycollection.Add(DateTime.Now.Date.Day.ToString());
			todaycollection.Add(DateTime.Now.Date.Year.ToString());
			todaycollection.Add(DateTime.Now.ToString("hh"));
			todaycollection.Add(DateTime.Now.ToString("mm"));

			fromPlace.Focused += FromPlace_Focused;
			toplace.Focused += Toplace_Focused;
			startdate.Focused += Startdate_Focused;
			enddate.Focused += Enddate_Focused;

			fromPlace.Text = "Chennai, India";
			toplace.Text = "Boston, USA";
			this.BindingContext = new CascadingViewModel();

			if (Device.RuntimePlatform == Device.Android)
			{
				submit.BackgroundColor = Color.FromHex("#009688");
				submit.TextColor = Color.White;
				submit.Text = "SEARCH";
				frompicker.HeaderText = "FROM";
				topicker.HeaderText = "TO";
                arrivepicker.ColumnHeaderFontSize = 12;
                departpicker.ColumnHeaderFontSize = 12;
				arrivepicker.HeaderText = "SELECT A DATE & TIME";
				departpicker.HeaderText = "SELECT A DATE & TIME";
				submit.FontFamily = "sans-serif-medium";
				submit.WidthRequest = 130;
				submit.HeightRequest = 60;
				tempGrid.Margin = new Thickness(15, 0, 0, 0);
			}
			if (Device.RuntimePlatform == Device.iOS)
			{
				frompicker.SelectedItemFontSize = 25;
				topicker.SelectedItemFontSize = 25;
				departpicker.SelectedItemFontSize = 25;
				arrivepicker.SelectedItemFontSize = 25;
				//frame.OutlineColor = Color.White;
				submit.WidthRequest = 250;
				submit.HeightRequest = 25;
				submit.BorderWidth = 1;
				arrivepicker.HeaderText = "Select a Date & Time";
				departpicker.HeaderText = "Select a Date & Time";
				fromLayout.HeightRequest = 30;
				toLayout.HeightRequest = 30;
				departLayout.HeightRequest = 30;
				arrivelayout.HeightRequest = 30;
				fromlabel.TextColor = Color.FromRgba(0, 0, 0, 0.5);
				tolabel.TextColor = Color.FromRgba(0, 0, 0, 0.5);
				departlabel.TextColor = Color.FromRgba(0, 0, 0, 0.5);
				arrivelabel.TextColor = Color.FromRgba(0, 0, 0, 0.5);
				fromlabel.FontFamily = "HelveticaNeue-Thin";
				tolabel.FontFamily = "HelveticaNeue-Thin";
				fromPlace.FontFamily = "HelveticaNeue-Thin";
				toplace.FontFamily = "HelveticaNeue-Thin";
				frompicker.SelectedItemFontFamily = "HelveticaNeue-Thin";
				frompicker.UnSelectedItemFontFamily = "HelveticaNeue-Thin";
				topicker.SelectedItemFontFamily = "HelveticaNeue-Thin";
				topicker.UnSelectedItemFontFamily = "HelveticaNeue-Thin";
				departpicker.SelectedItemFontFamily = "HelveticaNeue-Thin";
				departpicker.UnSelectedItemFontFamily = "HelveticaNeue-Thin";
				arrivepicker.SelectedItemFontFamily = "HelveticaNeue-Thin";
				arrivepicker.UnSelectedItemFontFamily = "HelveticaNeue-Thin";
				departlabel.FontFamily = "HelveticaNeue-Thin";
				startdate.FontFamily = "HelveticaNeue-Thin";
				arrivelabel.FontFamily = "HelveticaNeue-Thin";
				enddate.FontFamily = "HelveticaNeue-Thin";
				submit.FontFamily = "HelveticaNeue-Thin";
				submit.BorderColor = Color.FromHex("#cdcdcd");
				submit.FontSize = 14;
				submit.FontAttributes = FontAttributes.Italic;
				frompicker.PickerWidth = 300;
				topicker.PickerWidth = 300;
				arrivepicker.PickerWidth = 360;
				departpicker.PickerWidth = 360;
			}
			
			else if (Device.RuntimePlatform == Device.UWP)
			{
				if (Device.Idiom != TargetIdiom.Phone)
				{
					innerGrid.HorizontalOptions = LayoutOptions.Start;
                    innerGrid.WidthRequest = 500;
                    innerGrid.VerticalOptions = LayoutOptions.Start;
				}
				topicker.HeaderText = "TO";
				frompicker.HeaderText = "FROM";
				departpicker.HeaderText = "SELECT A DATE & TIME";
				arrivepicker.HeaderText = "SELECT A DATE & TIME";
				startdate.IsEnabled = true;
				startdate.HeightRequest = 40;
				arrivepicker.HeaderText = "PICK A DATE TIME";
				departpicker.HeaderText = "PICK A DATE TIME";
				enddate.IsEnabled = true;
				enddate.HeightRequest = 40;
				fromPlace.IsEnabled = true;
				fromPlace.HeightRequest = 40;
				toplace.IsEnabled = true;
				toplace.HeightRequest = 40;
				fromPlace.VerticalOptions = LayoutOptions.Center;
				toplace.VerticalOptions = LayoutOptions.Center;
				startdate.FontSize = 15;
				startdate.VerticalOptions = LayoutOptions.Center;
				enddate.FontSize = 15;
				enddate.VerticalOptions = LayoutOptions.Center;
				frompicker.PickerWidth = 300;
				topicker.PickerWidth = 300;
				departpicker.PickerWidth = 310;
				arrivepicker.PickerWidth = 310;
				submit.HorizontalOptions = LayoutOptions.Start;
				submit.HeightRequest = 40;

				submit.Margin = new Thickness(0, 15, 0, 0);
				if (Device.Idiom == TargetIdiom.Phone)
				{
					fromPlace.WidthRequest = 220;
					toplace.WidthRequest = 220;
					startdate.WidthRequest = 220;
					enddate.WidthRequest = 220;
					submit.WidthRequest = 270;
				}
				else
					submit.WidthRequest = 300;

				submit.BackgroundColor = Color.FromHex("#cdcdcd");
				submit.TextColor = Color.Black;
				interlabel.Margin = new Thickness(10, 0, 0, 0);
				interlabel.FontAttributes = FontAttributes.Bold;
				fromlabel.TextColor = Color.Gray;
				tolabel.TextColor = Color.Gray;
				departlabel.TextColor = Color.Gray;
				arrivelabel.TextColor = Color.Gray;
				journeylabel.FontAttributes = FontAttributes.Bold;
			}
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				if (Device.RuntimePlatform == Device.Android && Device.RuntimePlatform == Device.iOS)
					departpicker.IsOpen = true;
			};
			startdate.GestureRecognizers.Add(tapGestureRecognizer);

			var tapGestureRecognizer2 = new TapGestureRecognizer();
			tapGestureRecognizer2.Tapped += (s, e) =>
			{
				if (Device.RuntimePlatform == Device.Android && Device.RuntimePlatform == Device.iOS)
					arrivepicker.IsOpen = true;
			};
			enddate.GestureRecognizers.Add(tapGestureRecognizer2);



			var tapGestureRecognizer3 = new TapGestureRecognizer();
			tapGestureRecognizer3.Tapped += (s, e) =>
			{
				if (Device.RuntimePlatform == Device.Android && Device.RuntimePlatform == Device.iOS)
					frompicker.IsOpen = true;
			};
			fromPlace.GestureRecognizers.Add(tapGestureRecognizer);

			var tapGestureRecognizer4 = new TapGestureRecognizer();
			tapGestureRecognizer4.Tapped += (s, e) =>
			{
				if (Device.RuntimePlatform == Device.Android && Device.RuntimePlatform == Device.iOS)
					topicker.IsOpen = true;
			};
			toplace.GestureRecognizers.Add(tapGestureRecognizer2);
			if (Device.RuntimePlatform == Device.Android)
			{
                frompicker.BackgroundColor = Color.White;
                topicker.BackgroundColor = Color.White;
			}
		}

       
        private void Enddate_Focused(object sender, FocusEventArgs e)
		{
			enddate.Unfocus();
			arrivepicker.IsOpen = true;
		}

		private void Startdate_Focused(object sender, FocusEventArgs e)
		{
			startdate.Unfocus();
			departpicker.IsOpen = true;
		}

		private void Toplace_Focused(object sender, FocusEventArgs e)
		{
			toplace.Unfocus();
			topicker.IsOpen = true;
		}

		private void FromPlace_Focused(object sender, FocusEventArgs e)
		{
			fromPlace.Unfocus();
			frompicker.IsOpen = true;
		}

		private void Topicker_OnColumnLoaded(object sender, Syncfusion.SfPicker.XForms.ColumnLoadedEventArgs e)
		{
			if (Device.RuntimePlatform != Device.Android)
			{
				if (e.Column == 0)
				{
					e.ColumnWidth = 150;
				}
			}
		}

		private void Topicker_OnPickerItemLoaded(object sender, Syncfusion.SfPicker.XForms.PickerViewEventArgs e)
		{
			if (e.Column == 0 && Device.RuntimePlatform != Device.Android)
			{
				Country c = new Country() { Name = e.Item.ToString() };
				c.Flag = flags[e.Item.ToString()];
				e.View = new Itemview(c);
			}
		}

		private void Submit_Clicked(object sender, EventArgs e)
		{
			int index = r.Next(0, 50);
			Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Results", "\n" + index + " Flights are available on that time to depart from " + fromPlace.Text.ToString(), "Ok");
		}

		private void Frompicker_OnColumnLoaded(object sender, Syncfusion.SfPicker.XForms.ColumnLoadedEventArgs e)
		{
			if (Device.RuntimePlatform != Device.Android)
			{
				if (e.Column == 0)
				{
					e.ColumnWidth = 150;
				}
			}
		}

		private void Frompicker_OnPickerItemLoaded(object sender, Syncfusion.SfPicker.XForms.PickerViewEventArgs e)
		{
			if (e.Column == 0 && Device.RuntimePlatform != Device.Android)
			{
				Country c = new Country() { Name = e.Item.ToString() };
				c.Flag = flags[e.Item.ToString()];
				e.View = new Itemview(c);
			}
		}

		void Topicker_OnPopUpOpened(object sender, EventArgs e)
		{
			CascadingViewModel viewmodel = this.BindingContext as CascadingViewModel;
			ObservableCollection<object> arrivePlace = new ObservableCollection<object>();
			String[] arraivePlaceArray = toplace.Text.Split(',');

			string country = arraivePlaceArray[1].Substring(1);
			arrivePlace.Add(country);
			arrivePlace.Add(arraivePlaceArray[0]);
			viewmodel.ArrivePlace = arrivePlace;
		}

		void Arrivepicker_OnColumnLoaded(object sender, Syncfusion.SfPicker.XForms.ColumnLoadedEventArgs e)
		{
			if (Device.RuntimePlatform == Device.UWP)
			{
                if (e.Column == 0)
                    e.ColumnWidth = 80;
                if (e.Column == 1)
                    e.ColumnWidth = 80;
                if (e.Column == 2)
                    e.ColumnWidth = 50;
            }
		}

		void Departpicker_OnColumnLoaded(object sender, Syncfusion.SfPicker.XForms.ColumnLoadedEventArgs e)
		{
			if (Device.RuntimePlatform == Device.UWP)
			{
				if (e.Column == 0)
					e.ColumnWidth = 80;
				if (e.Column == 1)
					e.ColumnWidth = 80;
				if (e.Column == 2)
					e.ColumnWidth = 50;
			}

		}

		void Frompicker_OnPopUpOpened(object sender, EventArgs e)
		{
			CascadingViewModel viewmodel = this.BindingContext as CascadingViewModel;
			ObservableCollection<object> departPlace = new ObservableCollection<object>();
			String[] departPlaceArray = fromPlace.Text.Split(',');

			string country = departPlaceArray[1].Substring(1);
			departPlace.Add(country);
			departPlace.Add(departPlaceArray[0]);
			viewmodel.FromPlace = departPlace;
		}

		void Topicker_OkButtonClicked(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			if (e.NewValue != null)
			{
				ObservableCollection<object> source = e.NewValue as ObservableCollection<object>;
				toplace.Text = source[1].ToString() + ", " + source[0].ToString();
			}
		}

		void Topicker_CancelButtonClicked(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			CascadingViewModel viewmodel = this.BindingContext as CascadingViewModel;
			ObservableCollection<object> arrivePlace = new ObservableCollection<object>();
			String[] arraivePlaceArray = toplace.Text.Split(',');
			string country = arraivePlaceArray[1].Substring(1);
			arrivePlace.Add(country);
			arrivePlace.Add(arraivePlaceArray[0]);
			viewmodel.ArrivePlace = arrivePlace;
		}

		void Handle_CancelButtonClicked(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			(this.BindingContext as CascadingViewModel).StartDate = GetCollectionfromstring(startdate.Text);
		}

		void Frompicker_CancelButtonClicked(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			CascadingViewModel viewmodel = this.BindingContext as CascadingViewModel;
			ObservableCollection<object> departPlace = new ObservableCollection<object>();
			String[] departPlaceArray = fromPlace.Text.Split(',');
			string country = departPlaceArray[1].Substring(1);
			departPlace.Add(country);
			departPlace.Add(departPlaceArray[0]);
			viewmodel.FromPlace = departPlace;
		}

		void Frompicker_OkButtonClicked(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			if (e.NewValue != null)
			{
				ObservableCollection<object> source = e.NewValue as ObservableCollection<object>;
				fromPlace.Text = source[1].ToString() + ", " + source[0].ToString();
			}
		}

		void Handle_OkButtonClicked(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			if ((e.NewValue as IList).Count > 0)
			{
				startdate.Text = GetStringfromCollection(GetCollectionfromList(e.NewValue as IList));
				(this.BindingContext as CascadingViewModel).StartDate = GetCollectionfromList(e.NewValue as IList);

			}
		}
		ObservableCollection<object> GetCollectionfromList(IList dates)
		{
			ObservableCollection<object> items = new ObservableCollection<object>();
			foreach (var item in dates)
			{
				items.Add(item);
			}

			return items;
		}

		string GetStringfromCollection(ICollection collection)
		{
			string dates = string.Empty;
			int i = 0;
			foreach (var item in collection)
			{
				i++;
				dates += item;
				if (i == 4)
					dates += ":";
				else
					dates += " ";
			}
			return dates;
		}
		ObservableCollection<object> todaycollection = new ObservableCollection<object>();
		ObservableCollection<object> GetCollectionfromstring(string text)
		{
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Replace(':', ' ');
				var str = text.Split(' ').Where(s => !string.IsNullOrEmpty(s));

				ObservableCollection<object> items = new ObservableCollection<object>();
				foreach (var item in str)
				{
					items.Add(item);
				}
				return items;
			}
			return todaycollection;
		}
		void Handle_CancelButtonClicked1(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			(this.BindingContext as CascadingViewModel).EndDate = GetCollectionfromstring(startdate.Text);
		}

		void Handle_OkButtonClicked1(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			if ((e.NewValue as IList).Count > 0)
			{
				enddate.Text = GetStringfromCollection(GetCollectionfromList(e.NewValue as IList));
				(this.BindingContext as CascadingViewModel).EndDate = GetCollectionfromList(e.NewValue as IList);
				//enddate.Text = GetStringfromCollection((this.BindingContext as ViewModel).StartDate);
			}
		}
		private void Enddate_OnPopUpClosed(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(enddate.Text))
			{
				(this.BindingContext as CascadingViewModel).EndDate = todaycollection;
			}
			else
			{
				(this.BindingContext as CascadingViewModel).EndDate = GetCollectionfromstring(enddate.Text);
			}
		}

		private void Startdate_OnPopUpClosed(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(startdate.Text))
			{
				(this.BindingContext as CascadingViewModel).StartDate = todaycollection;
			}
			else
			{
				(this.BindingContext as CascadingViewModel).StartDate = GetCollectionfromstring(startdate.Text);
			}
		}
		string currentData = "India", currentData2 = "UK";
		public ObservableCollection<object> GetCity(string sdata)
		{
			currentData = sdata;
			ObservableCollection<object> selectedCountries = new ObservableCollection<object>();
			if (sdata == "UK")
			{
				selectedCountries.Add("London");
				selectedCountries.Add("Manchester");
				selectedCountries.Add("Cambridge");
				selectedCountries.Add("Edinburgh");
				selectedCountries.Add("Glasgow");
				selectedCountries.Add("Birmingham");
			}
			else if (sdata == "USA")
			{
				selectedCountries.Add("New York");
				selectedCountries.Add("Seattle");
				selectedCountries.Add("Wasington");
				selectedCountries.Add("Chicago");
				selectedCountries.Add("Boston");
				selectedCountries.Add("Los Angles");
			}
			else if (sdata == "UAE")
			{
				selectedCountries.Add("Dubai");
				selectedCountries.Add("Abu Dhabi");
				selectedCountries.Add("Fujairah");
				selectedCountries.Add("Sharjah");
				selectedCountries.Add("Ajman");
				selectedCountries.Add("AL Ain");
			}
			else if (sdata == "India")
			{
				selectedCountries.Add("Mumbai");
				selectedCountries.Add("Bengaluru");
				selectedCountries.Add("Chennai");
				selectedCountries.Add("Pune");
				selectedCountries.Add("Jaipur");
				selectedCountries.Add("Delhi");
			}
			else
			{
				selectedCountries.Add("Berlin");
				selectedCountries.Add("Munich");
				selectedCountries.Add("Frankfurt");
				selectedCountries.Add("Hamburg");
				selectedCountries.Add("Cologne");
				selectedCountries.Add("Bonn");
			}
			return selectedCountries;
		}
		public ObservableCollection<object> GetCity2(string sdata)
		{
			currentData2 = sdata;
			ObservableCollection<object> selectedCountries = new ObservableCollection<object>();
			if (sdata == "UK")
			{
				selectedCountries.Add("London");
				selectedCountries.Add("Manchester");
				selectedCountries.Add("Cambridge");
				selectedCountries.Add("Edinburgh");
				selectedCountries.Add("Glasgow");
				selectedCountries.Add("Birmingham");
			}
			else if (sdata == "USA")
			{
				selectedCountries.Add("New York");
				selectedCountries.Add("San Francisco");
				selectedCountries.Add("Wasington");
				selectedCountries.Add("Chicago");
				selectedCountries.Add("Boston");
				selectedCountries.Add("Los Angles");
			}
			else if (sdata == "UAE")
			{
				selectedCountries.Add("Dubai");
				selectedCountries.Add("Abu Dhabi");
				selectedCountries.Add("Fujairah");
				selectedCountries.Add("Sharjah");
				selectedCountries.Add("Ajman");
				selectedCountries.Add("AL Ain");
			}
			else if (sdata == "India")
			{
				selectedCountries.Add("Mumbai");
				selectedCountries.Add("Chennai");
				selectedCountries.Add("Bengaluru");
				selectedCountries.Add("Pune");
				selectedCountries.Add("Jaipur");
				selectedCountries.Add("Delhi");
			}
			else
			{
				selectedCountries.Add("Berlin");
				selectedCountries.Add("Munich");
				selectedCountries.Add("Frankfurt");
				selectedCountries.Add("Hamburg");
				selectedCountries.Add("Cologne");
				selectedCountries.Add("Bonn");
			}
			return selectedCountries;
		}

		void Picker_SelectionChanged(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			if (e.NewValue != null && e.NewValue is ObservableCollection<object> && (e.NewValue as ObservableCollection<object>).Count > 0)
			{
				if ((e.NewValue as ObservableCollection<object>)[0].ToString() != currentData)
				{
					//ObservableCollection<object> source = new ObservableCollection<object>();
					ObservableCollection<object> columnSource2 = GetCity((e.NewValue as ObservableCollection<object>)[0].ToString());
					//source.Add(column1Source);
					Source.RemoveAt(1);
					Source.Add(GetCity((e.NewValue as ObservableCollection<object>)[0].ToString()));
					//frompicker.ItemsSource = source;
					ObservableCollection<object> fromplaceCollection = new ObservableCollection<object>();
					fromplaceCollection.Add((e.NewValue as ObservableCollection<object>)[0]);
					fromplaceCollection.Add(columnSource2[0]);
					(this.BindingContext as CascadingViewModel).FromPlace = fromplaceCollection;

				}
			}
		}
		private void Button_Click_2(object sender, EventArgs e)
		{
			topicker.IsOpen = true;
		}
		private void Button_Click_3(object sender, EventArgs e)
		{
			frompicker.IsOpen = true;
		}
		private void Button_Click_4(object sender, EventArgs e)
		{
			departpicker.IsOpen = true;
		}
		private void Button_Click_5(object sender, EventArgs e)
		{
			arrivepicker.IsOpen = true;
		}
		void Picker_SelectionChanged1(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			if (e.NewValue != null && e.NewValue is ObservableCollection<object> && (e.NewValue as ObservableCollection<object>).Count > 0)
			{
				if ((e.NewValue as ObservableCollection<object>)[0].ToString() != currentData2)
				{
					//ObservableCollection<object> source = new ObservableCollection<object>();
					ObservableCollection<object> columnSource2 = GetCity2((e.NewValue as ObservableCollection<object>)[0].ToString());
					//source.Add(column1Source);
					Source2.RemoveAt(1);
					Source2.Add(GetCity2((e.NewValue as ObservableCollection<object>)[0].ToString()));
					//topicker.ItemsSource = source;
					ObservableCollection<object> toplaceCollection = new ObservableCollection<object>();
					toplaceCollection.Add((e.NewValue as ObservableCollection<object>)[0]);
					toplaceCollection.Add(columnSource2[0]);
					(this.BindingContext as CascadingViewModel).ArrivePlace = toplaceCollection;

				}
			}
		}
	}

	public class CascadingViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<object> _startdate;

		public ObservableCollection<object> StartDate
		{
			get { return _startdate; }
			set { _startdate = value; RaisePropertyChanged("StartDate"); }
		}

		private ObservableCollection<object> _enddate;

		public ObservableCollection<object> EndDate
		{
			get { return _enddate; }
			set { _enddate = value; RaisePropertyChanged("EndDate"); }
		}

		private ObservableCollection<object> _fromPlace;

		public ObservableCollection<object> FromPlace
		{
			get
			{
				return _fromPlace;
			}

			set
			{
				_fromPlace = value;
				RaisePropertyChanged("FromPlace");
			}
		}

		public ObservableCollection<object> ArrivePlace
		{
			get
			{
				return _endPlace;
			}

			set
			{
				_endPlace = value;
				RaisePropertyChanged("ArrivePlace");
			}
		}

		private ObservableCollection<object> _endPlace;

		void RaisePropertyChanged(string name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
		public event PropertyChangedEventHandler PropertyChanged;

		public CascadingViewModel()
		{
			ObservableCollection<object> todaycollection = new ObservableCollection<object>();

			//Select today dates
			todaycollection.Add(DateTime.Now.Date.Year.ToString());
			todaycollection.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3));
			if (DateTime.Now.Date.Day < 10)
				todaycollection.Add("0" + DateTime.Now.Date.Day);
			else
				todaycollection.Add(DateTime.Now.Date.Day.ToString());


			todaycollection.Add(DateTime.Now.ToString("hh"));
			todaycollection.Add(DateTime.Now.ToString("mm"));


			ObservableCollection<object> initialDepartPlace = new ObservableCollection<object>();
			initialDepartPlace.Add("India");
			initialDepartPlace.Add("Chennai");
			FromPlace = initialDepartPlace;
			ObservableCollection<object> initialArrivePlace = new ObservableCollection<object>();
			initialArrivePlace.Add("USA");
			initialArrivePlace.Add("Boston");
			ArrivePlace = initialArrivePlace;
			this.StartDate = todaycollection;
			this.EndDate = todaycollection;
		}
	}
}

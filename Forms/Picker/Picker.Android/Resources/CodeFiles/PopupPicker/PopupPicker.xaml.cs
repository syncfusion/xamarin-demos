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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfPicker
{
	public partial class PopupPicker : SampleView, INotifyPropertyChanged
    {
        ObservableCollection<object> todaycollection = new ObservableCollection<object>();
        public PopupPicker()
		{
			InitializeComponent();
			startdate.OnColumnLoaded += Startdate_GetColumnWidth;
			startdate.Closed += Startdate_OnPopUpClosed;
			enddate.Closed += Enddate_OnPopUpClosed;
			enddate.OnColumnLoaded += Startdate_GetColumnWidth;
            startdate.CancelButtonClicked += Startdate_CancelButtonClicked;
            enddate.CancelButtonClicked += Enddate_CancelButtonClicked;
            startdatetxt.Focused += Startdatetxt_Focused;
            enddatetxt.Focused += Enddatetxt_Focused;
            startdate.Parent = tempGrid;
			enddate.Parent = tempGrid;
			if (Device.OS == TargetPlatform.Android)
			{
				startdate.BackgroundColor = Color.White;
				enddate.BackgroundColor = Color.White;
                startdatebutton.WidthRequest = 30;
                enddatebutton.WidthRequest = 30;
			}
            if (Device.OS == TargetPlatform.Android)
            {
                submit.BackgroundColor = Color.FromHex("#009688");
                submit.TextColor = Color.White;
                submit.Text = "SUBMIT";
                submit.FontFamily = "sans-serif-medium";
                innergrid.WidthRequest = 250;
                submit.WidthRequest = 250;
                submit.HeightRequest = 36;
				startdate.HeaderText = "DATE PICKER";
				enddate.HeaderText = "DATE PICKER";
				startdate.PickerWidth = 270;
				enddate.PickerWidth = 270;
				startlabel.Margin = new Thickness(5, 0, 0, 0);
				endlabel.Margin = new Thickness(5, 0, 0, 0);
                header.Margin = new Thickness(0, 0, 0, 50);
				startdate.SelectedItemFontSize = 22;
				enddate.SelectedItemFontSize = 22;
				startdate.ColumnHeaderFontSize = 16;
				enddate.ColumnHeaderFontSize = 16;
            }
            if (Device.OS == TargetPlatform.iOS)
            {

                submit.WidthRequest = 250;
                submit.HeightRequest = 25;
                startdate.SelectedItemFontSize = 25;
                enddate.SelectedItemFontSize = 25;
                startlayout.HeightRequest = 30;
                endlayout.HeightRequest = 30;
                startlabel.TextColor = Color.FromRgba(0, 0, 0, 0.5);
                endlabel.TextColor = Color.FromRgba(0, 0, 0, 0.5);
                submit.BorderWidth = 1;
                innergrid.WidthRequest = 250;
                header.FontFamily = "HelveticaNeue-Thin";
                startdatetxt.FontFamily = "HelveticaNeue-Thin";
                enddatetxt.FontFamily = "HelveticaNeue-Thin";
                startlabel.FontFamily = "HelveticaNeue-Thin";
                endlabel.FontFamily = "HelveticaNeue-Thin";
                submit.FontFamily = "HelveticaNeue-Thin";
                submit.BorderColor = Color.FromHex("#cdcdcd");
                submit.FontSize = 14;
                startdate.SelectedItemFontFamily = "HelveticaNeue-Thin";
                startdate.BorderColor = Color.Gray;
                startdate.UnSelectedItemFontFamily = "HelveticaNeue-Thin";
                enddate.SelectedItemFontFamily = "HelveticaNeue-Thin";
                enddate.UnSelectedItemFontFamily = "HelveticaNeue-Thin";
                submit.FontAttributes = FontAttributes.Bold;
                header.Margin = new Thickness(0, 0, 0, 50);
                startdate.HeaderHeight = 40;
                enddate.HeaderHeight = 40;
            }


            this.BindingContext = new ViewModel();
			if (DateTime.Now.Day.ToString().Length != 1)
			{
				startdatetxt.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3) + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
				enddatetxt.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3) + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
			}
			else
			{
				startdatetxt.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3) + " 0" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
				enddatetxt.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3) + " 0" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
			}
            //Select today dates
            todaycollection.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0,3));
            if (DateTime.Now.Date.Day < 10)
                todaycollection.Add("0" + DateTime.Now.Date.Day);
            else
                todaycollection.Add(DateTime.Now.Date.Day.ToString());
            todaycollection.Add(DateTime.Now.Date.Year.ToString());

            if (Device.OS == TargetPlatform.Windows)
            {
                if (Device.Idiom != TargetIdiom.Phone)
                {
                    grid.HorizontalOptions = LayoutOptions.Start;
                    grid.VerticalOptions = LayoutOptions.Start;
                    grid.Margin = new Thickness(20, 20, 0, 0);
                    header.HorizontalOptions = LayoutOptions.Start;
                    
                }
                else
                {
                    innergrid.WidthRequest = 250;
                }
                startdate.HeaderText = "PICK A DATE TIME";
                enddate.HeaderText = "PICK A DATE TIME";
                innergrid.Margin = new Thickness(0,15,0,0);
                startdate.PickerHeight = 350;
                startdate.PickerWidth = 300;
                enddate.PickerHeight = 350;
                enddate.PickerWidth = 300;
                startdatetxt.IsEnabled = true;
                startdatetxt.HeightRequest = 40;
                startlabel.TextColor = Color.Gray;
                endlabel.TextColor = Color.Gray;
                enddatetxt.HeightRequest = 40;
                enddatetxt.IsEnabled = true;
                startdatetxt.VerticalOptions = LayoutOptions.Center;
                enddatetxt.VerticalOptions = LayoutOptions.Center;
                submit.BackgroundColor = Color.FromHex("#cdcdcd");
                submit.TextColor = Color.Black;
                submit.Margin = new Thickness(0);
                submit.HorizontalOptions = LayoutOptions.Start;
                submit.WidthRequest = 205;
                submit.Margin = new Thickness(0);
                submit.HeightRequest = 40;
                submit.BorderWidth = 0;
                layout1.Margin = new Thickness(0);
                layout2.Margin = new Thickness(0);
				startdate.HeaderText = "PICK A DATE TIME";
				enddate.HeaderText = "PICK A DATE TIME";
            }

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				if(Device.OS==TargetPlatform.Android && Device.OS==TargetPlatform.iOS)
					startdate.IsOpen = true;
			};
			startdatetxt.GestureRecognizers.Add(tapGestureRecognizer);

			var tapGestureRecognizer2 = new TapGestureRecognizer();
			tapGestureRecognizer2.Tapped += (s, e) =>
			{
				if (Device.OS == TargetPlatform.Android && Device.OS == TargetPlatform.iOS)
					enddate.IsOpen = true;
			};
			enddatetxt.GestureRecognizers.Add(tapGestureRecognizer2);

        }

      
        private void Enddatetxt_Focused(object sender, FocusEventArgs e)
        {
            enddatetxt.Unfocus();
            enddate.IsOpen = true;
        }

        private void Startdatetxt_Focused(object sender, FocusEventArgs e)
        {
            startdatetxt.Unfocus();
            startdate.IsOpen = true;
        }

        private void Enddate_OnPopUpClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(enddatetxt.Text))
            {
                (this.BindingContext as ViewModel).EndDate = todaycollection;
            }
            else
            {
                (this.BindingContext as ViewModel).EndDate = GetCollectionfromstring(enddatetxt.Text);
            }
        }

        private void Startdate_OnPopUpClosed(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(startdatetxt.Text))
            {
                (this.BindingContext as ViewModel).StartDate = todaycollection;
            }
            else
            {
                (this.BindingContext as ViewModel).StartDate = GetCollectionfromstring(startdatetxt.Text);
            }
        }

        private void Enddate_CancelButtonClicked(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
        {
            (this.BindingContext as ViewModel).EndDate = GetCollectionfromstring(enddatetxt.Text);
        }

        private void Startdate_CancelButtonClicked(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
        {
            (this.BindingContext as ViewModel).StartDate = GetCollectionfromstring(startdatetxt.Text);
        }

        void Startdate_GetColumnWidth(object sender, Syncfusion.SfPicker.XForms.ColumnLoadedEventArgs e)
        {
            //if (Device.OS == TargetPlatform.Android)
            //{
            //    if (e.Column == 0)
            //    {
            //        e.ColumnWidth = 300;
            //    }
            //    else if (e.Column == 1)
            //    {
            //        e.ColumnWidth = 200;
            //    }
            //    else
            //    {
            //        e.ColumnWidth = 300;
            //    }
            //}

        }

        #region get Collections and String
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
            foreach (var item in collection)
            {
                dates += item + " ";
            }
            return dates;
        }

        ObservableCollection<object> GetCollectionfromstring(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
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

        #endregion

        private void Button_Click(object sender, EventArgs e)
		{
			startdate.IsOpen = true;
		}

		private void Button_Click_1(object sender, EventArgs e)
		{
			enddate.IsOpen = true;
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Success", "Your vacation has been updated from "+startdatetxt.Text.ToString()+" to "+enddatetxt.Text.ToString(), "Ok");
			startdatetxt.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3) + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
			enddatetxt.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3) + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
		}

		private void startdate_OkButtonClicked(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			if ((e.NewValue as IList).Count > 0)
			{
				startdatetxt.Text = GetStringfromCollection(GetCollectionfromList(e.NewValue as IList));
				(this.BindingContext as ViewModel).StartDate = GetCollectionfromList(e.NewValue as IList);

			}
		}

		private void enddate_OkButtonClicked(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			if ((e.NewValue as IList).Count > 0)
			{
				enddatetxt.Text = GetStringfromCollection(GetCollectionfromList(e.NewValue as IList));
				(this.BindingContext as ViewModel).EndDate = GetCollectionfromList(e.NewValue as IList);

			}
		}
	}

    public class ViewModel : INotifyPropertyChanged
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

        void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            ObservableCollection<object> todaycollection = new ObservableCollection<object>();

            //Select today dates
            todaycollection.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0,3));
            if (DateTime.Now.Date.Day < 10)
                todaycollection.Add("0" + DateTime.Now.Date.Day);
            else
                todaycollection.Add(DateTime.Now.Date.Day.ToString());
            todaycollection.Add(DateTime.Now.Date.Year.ToString());

            this.StartDate = todaycollection;
            this.EndDate = todaycollection;
        }
    }

    public class CustomPickerEntry:Entry
    {

    }
}

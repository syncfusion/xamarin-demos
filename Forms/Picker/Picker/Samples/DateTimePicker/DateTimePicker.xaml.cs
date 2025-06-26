#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SelectionChangedEventArgs = Syncfusion.SfPicker.XForms.SelectionChangedEventArgs;
using Syncfusion.SfPicker.XForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;
using SampleBrowser.Core;

namespace SampleBrowser.SfPicker
{
	public partial class DateTimePicker : SampleView
	{
        ObservableCollection<object> currenttime;
        public DateTimePicker()
		{
			InitializeComponent();
			this.BindingContext = new DateTimePickerViewModel();
			//picker.OnColumnLoaded += Picker_GetColumnWidth;
			//picker.OnPopUpOpened += Picker_OnPopUpOpened;
			popuppicker.Closed += Popuppicker_OnPopUpClosed;
			popupendpicker.Closed += Popupendpicker_OnPopUpClosed;

            currenttime = new ObservableCollection<object>();
            currenttime.Add(DateTime.Now.ToString("hh"));
            currenttime.Add(DateTime.Now.ToString("mm"));
            currenttime.Add(DateTime.Now.ToString("tt"));
			if (Device.RuntimePlatform == Device.Android)
			{
                popuppicker.BackgroundColor = Color.White;
                popupendpicker.BackgroundColor = Color.White;
                starttimebutton.WidthRequest = 30;
                endtimebutton.WidthRequest = 30;
			}
			startdate.Text = DateTime.Now.ToString("hh") + ":" + DateTime.Now.ToString("mm") + " " + DateTime.Now.ToString("tt");
			enddate.Text = DateTime.Now.ToString("hh") + ":" + DateTime.Now.ToString("mm") + " " + DateTime.Now.ToString("tt");
            https://gitlab.syncfusion.com/essential-studio/xamarinforms-samplebrowser.git
            var no = false;
            if (no)
                goto https;
            startdate.Focused += Startdate_Focused;
            enddate.Focused += Enddate_Focused;
            if (Device.RuntimePlatform == Device.Android)
            {
                submit.BackgroundColor = Color.FromHex("#009688");
                submit.TextColor = Color.White;
                submit.Text = "SUBMIT";
                submit.FontFamily = "sans-serif-medium";
                submit.WidthRequest = 100;
                submit.HeightRequest = 35;
				startdate.FontSize = 14;
				enddate.FontSize = 14;
				picker.PickerWidth = 300;
				innergrid.Margin = new Thickness(10, 3, 10, 3);
				scroll.Margin = new Thickness(10, 0, 10, 3);
				apptimelabel.Margin = new Thickness(0, 5, 0, 5);
				description.HeightRequest = 40;
				popuppicker.HeaderText = "TIME PICKER";
				popupendpicker.HeaderText = "TIME PICKER";
				picker.HeaderText = "APPOINTMENT DATE";
				row1.Height = new GridLength(190);
                popuppicker.ColumnHeaderFontSize = 14;
                popupendpicker.ColumnHeaderFontSize = 14;
				picker.SelectedItemFontSize = 22;
				picker.ColumnHeaderFontSize = 16;
				applabel.TextColor = Color.Black;
				apptimelabel.TextColor = Color.Black;
            }
            if (Device.RuntimePlatform == Device.iOS)    
            {
                startdate.Parent = tempGrid;
                enddate.Parent = tempGrid;
                //frame.OutlineColor = Color.White;
                submit.WidthRequest = 250;
                submit.HeightRequest = 30;
                submit.BorderWidth = 1;
                popuppicker.SelectedItemFontSize = 25;
                popupendpicker.SelectedItemFontSize = 25;
                startlayout.HeightRequest = 30;
                endlayout.HeightRequest = 30;
                startlabel.TextColor = Color.FromRgba(0, 0, 0, 0.5);
                endlabel.TextColor = Color.FromRgba(0, 0, 0, 0.5);
                popuppicker.SelectedItemFontFamily = "HelveticaNeue-Thin";
                popuppicker.UnSelectedItemFontFamily = "HelveticaNeue-Thin";
                popupendpicker.SelectedItemFontFamily = "HelveticaNeue-Thin";
                popupendpicker.UnSelectedItemFontFamily = "HelveticaNeue-Thin";
                picker.SelectedItemFontFamily = "HelveticaNeue-Thin";
                picker.UnSelectedItemFontFamily = "HelveticaNeue-Thin";
                startlabel.FontFamily = "HelveticaNeue-Thin";
                startdate.FontFamily = "HelveticaNeue-Thin";
                endlabel.FontFamily = "HelveticaNeue-Thin";
                enddate.FontFamily = "HelveticaNeue-Thin";
                submit.FontFamily = "HelveticaNeue-Thin";
                submit.BorderColor = Color.FromHex("#cdcdcd");
                submit.FontSize = 14;
				scroll.Margin = new Thickness(10);
                desGrid.Margin = new Thickness(0, 10, 0, 50);
                submit.FontAttributes = FontAttributes.Bold;
            }
            if (Device.RuntimePlatform == Device.iOS && Device.Idiom == TargetIdiom.Phone)
            {
                picker.WidthRequest = 300;
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                applabel.FontAttributes = FontAttributes.Bold;
                deslabel.FontAttributes = FontAttributes.Bold;
                apptimelabel.FontAttributes = FontAttributes.Bold;
                startlabel.TextColor = Color.Gray;
                endlabel.TextColor = Color.Gray;
                scroll.Margin = new Thickness(0);
                innergrid.Margin = new Thickness(20);
                if (Device.Idiom != TargetIdiom.Phone)
                {
                    innergrid.HorizontalOptions = LayoutOptions.Start;
                    innergrid.WidthRequest = 500;
                    innergrid.VerticalOptions = LayoutOptions.Start;
                }
                startdate.VerticalOptions = LayoutOptions.Center;
                enddate.VerticalOptions = LayoutOptions.Center;
                popuppicker.PickerHeight = 350;
                popuppicker.PickerWidth = 300;
                startdate.IsEnabled = true;
				scroll.Margin = new Thickness(10);
                enddate.IsEnabled = true;
                startdate.HeightRequest = 40;
                enddate.HeightRequest = 40;
                popupendpicker.PickerHeight = 350;
                popupendpicker.PickerWidth = 300;
                popuppicker.HeaderText = "PICK A TIME";
                popupendpicker.HeaderText = "PICK A TIME";
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    scroll.Margin = new Thickness(5, 0, 5, 10);
                }
                submit.BorderWidth = 0;
				popuppicker.HeaderText = "PICK A TIME";
				popupendpicker.HeaderText = "PICK A TIME";
                submit.Margin = new Thickness(0,15,0,0);
                submit.BackgroundColor = Color.FromHex("#cdcdcd");
                submit.TextColor = Color.Black;
            }

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				if (Device.RuntimePlatform == Device.Android && Device.RuntimePlatform == Device.iOS)
					popuppicker.IsOpen = true;
			};
			startdate.GestureRecognizers.Add(tapGestureRecognizer);

			var tapGestureRecognizer2 = new TapGestureRecognizer();
			tapGestureRecognizer2.Tapped += (s, e) =>
			{
				if (Device.RuntimePlatform == Device.Android && Device.RuntimePlatform == Device.iOS)
					popupendpicker.IsOpen = true;
			};
			enddate.GestureRecognizers.Add(tapGestureRecognizer2);

        }

        private void Enddate_Focused(object sender, FocusEventArgs e)
        {
            enddate.Unfocus();
            popupendpicker.IsOpen = true;
        }

        private void Startdate_Focused(object sender, FocusEventArgs e)
        {
            startdate.Unfocus();
            popuppicker.IsOpen = true;
        }

        private void Popupendpicker_OnPopUpClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(enddate.Text))
            {
                (this.BindingContext as DateTimePickerViewModel).SelectedEndTime = currenttime;
            }
            else
            {
                (this.BindingContext as DateTimePickerViewModel).SelectedEndTime = GetCollectionfromstring(enddate.Text);
            }
        }

        private void Popuppicker_OnPopUpClosed(object sender, EventArgs e)
        {
                if (string.IsNullOrEmpty(startdate.Text))
                {
                    (this.BindingContext as DateTimePickerViewModel).SelectedStartTime = currenttime;
                }
                else
                {
                    (this.BindingContext as DateTimePickerViewModel).SelectedStartTime = GetCollectionfromstring(startdate.Text);
                }
        }

		void Picker_GetColumnWidth(object sender, ColumnLoadedEventArgs e)
		{
			if (Device.RuntimePlatform == Device.Android)
			{
				if (e.Column == 0)
					e.ColumnWidth = 356;
				if (e.Column == 1)
					e.ColumnWidth = 216;
			}
		}

		private void Button_Click(object sender, EventArgs e)
		{
			popuppicker.IsOpen = true;
		}
		private void Button_Click_2(object sender, EventArgs e)
		{
			popupendpicker.IsOpen = true;
		}

		private void popuppicker_OkButtonClicked(object sender, SelectionChangedEventArgs e)
		{
			if (popupendpicker.IsOpen)
			{
				if((e.NewValue as ObservableCollection<object>).Count!=0)
                	(this.BindingContext as DateTimePickerViewModel).SelectedEndTime = GetCollectionfromList(e.NewValue as IList);
                enddate.Text = GetStringfromCollection((this.BindingContext as DateTimePickerViewModel).SelectedEndTime);
			}
			else
			{
				if ((e.NewValue as ObservableCollection<object>).Count != 0)
				{
					(this.BindingContext as DateTimePickerViewModel).SelectedStartTime = GetCollectionfromList(e.NewValue as IList);
					startdate.Text = GetStringfromCollection((this.BindingContext as DateTimePickerViewModel).SelectedStartTime);
				}
			}
		}

		private void popuppicker_CancelButtonClicked(object sender, SelectionChangedEventArgs e)
		{
			if (popupendpicker.IsOpen)
			{
                (this.BindingContext as DateTimePickerViewModel).SelectedEndTime = GetCollectionfromstring(enddate.Text);
            }
			else
			{
                (this.BindingContext as DateTimePickerViewModel).SelectedStartTime = GetCollectionfromstring(startdate.Text);
            }

		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Appointment Details","Your appointment has been scheduled at "+GetStringfromCollection1(picker.SelectedItem as ICollection) + " between "+ startdate.Text + " - " + enddate.Text , "OK");
			startdate.Text = DateTime.Now.ToString("hh") + ":" + DateTime.Now.ToString("mm") + " " + DateTime.Now.ToString("tt");
			enddate.Text = DateTime.Now.ToString("hh") + ":" + DateTime.Now.ToString("mm") + " " + DateTime.Now.ToString("tt");
			description.Text = "";
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
			int i = 0;
            foreach (var item in collection)
            {

				dates += item;
				if (i == 0)
					dates += ":";
				else
					dates += " ";
				i++;
            }
            return dates;
        }

		 string GetStringfromCollection1(ICollection collection)
		{
			string dates = string.Empty;
			int i = 0;
			foreach (var item in collection)
			{

				dates += item;
				dates += " ";
				i++;
			}
			return dates;
		}

        ObservableCollection<object> GetCollectionfromstring(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
				text = text.Replace(":", " ");
                var str = text.Split(' ').Where(s => !string.IsNullOrEmpty(s));

                ObservableCollection<object> items = new ObservableCollection<object>();
                foreach (var item in str)
                {
                    items.Add(item);
                }

                return items;
            }
            return currenttime;
        }

        #endregion

    }


    public class DateTimePickerViewModel : INotifyPropertyChanged
    {
		private ObservableCollection<object> _appointmentDate;

		public ObservableCollection<object> AppointmentDate
		{
			get { return _appointmentDate; }
			set { _appointmentDate = value; RaisePropertyChanged("StartDate"); }
		}

        private ObservableCollection<object> _selecttime;

        public ObservableCollection<object> SelectedStartTime
        {
            get { return _selecttime; }
            set { _selecttime = value; RaisePropertyChanged("SelectedStartTime"); }
        }

        private ObservableCollection<object> _selectedendtime;

        public ObservableCollection<object> SelectedEndTime
        {
            get { return _selectedendtime; }
            set { _selectedendtime = value;RaisePropertyChanged("SelectedEndTime"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public DateTimePickerViewModel()
        {
            ObservableCollection<object> currentTime = new ObservableCollection<object>();
            currentTime.Add(DateTime.Now.ToString("hh"));
            currentTime.Add(DateTime.Now.ToString("mm"));
            currentTime.Add(DateTime.Now.ToString("tt"));

            this.SelectedStartTime = currentTime;
            this.SelectedEndTime = currentTime;

			ObservableCollection<object> todaycollection = new ObservableCollection<object>();

			//Select today dates
			todaycollection.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0,3));
			if (DateTime.Now.Date.Day < 10)
				todaycollection.Add("0" + DateTime.Now.Date.Day);
			else
				todaycollection.Add(DateTime.Now.Date.Day.ToString());
			todaycollection.Add(DateTime.Now.Date.Year.ToString());

			this.AppointmentDate = todaycollection;
        }
    }


    public class CustomButton:Button
    {

    }
}

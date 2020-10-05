#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfComboBox
{
	public partial class ToleratingTypos : SampleView, INotifyPropertyChanged
	{
        bool check = true;
		SelectionIndicatorViewModel view = new SelectionIndicatorViewModel();

		public ToleratingTypos()
		{
			InitializeComponent();
			this.BindingContext = view;
            check = false;
            listView.SeparatorColor = Color.Transparent;
            check = true;
		}

        public override void OnAppearing()
        {
            base.OnAppearing();
        }

		void Handle_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
		{
            List<object> items=new List<object>();
            if (e.Value != null && (((e.Value is string && (string)e.Value != string.Empty)) || (e.Value is IList && (e.Value as IList).Count > 0)) && check)
            {
                if (Device.RuntimePlatform == Device.UWP)
                {
                    items = new List<object>(e.Value as ObservableCollection<object>);
                }
                else
                {
                    for (int ii = 0; ii < (e.Value as List<object>).Count; ii++)
                    {
                        var collection = (e.Value as List<object>)[ii];
                        items.Add(collection);
                    }
                }
                view.SelectedItem1 = items;
                if (items.Count > 0)
                {
                    listView.SeparatorColor = Color.Black;
                }
                else
                {
                    listView.SeparatorColor = Color.Transparent;
                }
			}
            else
            {
                view.SelectedItem1 = null;
			}

		}
	}

	public class Applicationlist
	{
		private string appimage;
		public string AppImage
		{
			get { return appimage; }
			set
			{
				appimage = value;
			}
		}
		private string name;
		public string AppName
		{
			get { return name; }
			set { name = value; }
		}
		private string date;
		public string Date
		{
			get { return date; }
			set { date = value; }
		}
	}
	public class SelectionIndicatorViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Applicationlist> appCollection;
		public ObservableCollection<Applicationlist> AppCollection
		{
			get { return appCollection; }
			set
			{
				appCollection = value;
				RaisePropertyChanged("AppCollection");
			}
		}

		private List<object> selectedItem;
		public List<object> SelectedItem1
		{
			get { return selectedItem; }
			set
			{
				selectedItem = value;
				RaisePropertyChanged("SelectedItem1");
			}
		}

		public SelectionIndicatorViewModel()
		{
			appCollection = new ObservableCollection<Applicationlist>();

            appCollection.Add(new Applicationlist() { AppImage = "Calculator.png", AppName = "Calculator", Date = "Updated 2 days ago" });
            appCollection.Add(new Applicationlist() { AppImage = "Camera.png", AppName = "Camera",Date = "Updated 4 days ago" });
            appCollection.Add(new Applicationlist() { AppImage = "CDMusic.png", AppName = "CD Music", Date = "Updated 9 days ago" });
			appCollection.Add(new Applicationlist() { AppImage = "Excel.png", AppName = "Excel", Date = "Updated 2 hours ago" });
			appCollection.Add(new Applicationlist() { AppImage = "GmailFill.png", AppName = "Gmail", Date = "Updated 9 days ago" });
			appCollection.Add(new Applicationlist() { AppImage = "ChromeFill.png", AppName = "Google Chrome", Date = "Updated 2 hours ago" });
			appCollection.Add(new Applicationlist() { AppImage = "Instagram.png", AppName = "Instagram", Date = "Updated 8 days ago" });
			appCollection.Add(new Applicationlist() { AppImage = "Maps_Red.png", AppName = "Maps", Date = "Updated 11 days ago" });
			appCollection.Add(new Applicationlist() { AppImage = "MicrosoftPowerPoint.png", AppName = "Microsoft Power Point", Date = "Updated 9 days ago" });
			appCollection.Add(new Applicationlist() { AppImage = "MicrosoftWord.png", AppName = "Microsoft Word", Date = "Updated 7 days ago" });
			appCollection.Add(new Applicationlist() { AppImage = "SkypeFill.png", AppName = "Skype", Date = "Updated 1 day ago" });
			appCollection.Add(new Applicationlist() { AppImage = "Twitter.png", AppName = "Twitter", Date = "Updated 6 weeks ago" });
			appCollection.Add(new Applicationlist() { AppImage = "YahooFill.png", AppName = "Yahoo", Date = "Updated 2 days ago" });
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void RaisePropertyChanged(String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
	}

	public class SelectionBoolToBackgroundColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value == true ? Color.FromRgb(211, 211, 211) : Color.White;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfAutoComplete
{
	public partial class HeaderFooterSample : SampleView, INotifyPropertyChanged
	{
		public ObservableCollection<HeaderFooter.ContactsInfo> Source { get; set; }
		public ObservableCollection<HeaderFooter.ContactsInfo> ListSource { get; set; }

		public string selectedItem;
		public string SelectedItem
		{
			get
			{
				return selectedItem;
			}
			set
			{
				selectedItem = value;

				SelectedItemValue = "Search for '" + selectedItem + "'";
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
				}

			}
		}

		public string selectedItemValue;
		public string SelectedItemValue
		{
			get
			{
				return selectedItemValue;
			}
			set
			{
				selectedItemValue = value;

				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("SelectedItemValue"));
				}
			}
		}

		public bool isFocused;
		public new bool IsFocused
		{
			get
			{
				return isFocused;
			}
			set
			{
				isFocused = value;

				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("IsFocused"));
				}
			}
		}

		public string watermark = "Search here";
		public string Watermark
		{
			get
			{
				return watermark;
			}
			set
			{
				watermark = value;

				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Watermark"));
				}
			}
		}

		Random random = new Random();

		public new event PropertyChangedEventHandler PropertyChanged;
		public HeaderFooterSample()
		{
			InitializeComponent();
			Source = new HeaderFooter.ContactsInfoRepository().GetContactDetails();
			ListSource = new HeaderFooter.ContactsInfoRepository().GetContactDetails();
			this.BindingContext = this;

			// this.autoComplete.SuggestionMode =  Syncfusion.SfAutoComplete.XForms.SuggestionMode.c
		}
		string hintText = "eve";
		double hintCount = -0;
		public void Results(int value)
		{

		}

		public bool ShowHint()
		{

			if (hintCount < hintText.Length)
			{
				this.autoComplete.Text += hintText[(int)hintCount++];
				return true;
			}
			return false;
		}



	}




	public class booltofontConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
				return FontAttributes.Bold;
			return FontAttributes.None;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}
	public class booltocolorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
				return Color.Black;
			return Color.Gray;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class AutoCompleteImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				if (value is string)
				{
                    if (Device.RuntimePlatform == Device.UWP)
					{
#if COMMONSB
                        return value;
#else
                        if (SampleBrowser.Core.SampleBrowser.IsIndividualSB)
							return value;
						else
							return "SampleBrowser.SfAutoComplete.UWP\\" + value;
#endif
                    }
				}
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

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
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfAutoComplete
{
	public class MultiSelectViewModel : INotifyPropertyChanged
	{
		#region Property

		public ObservableCollection<ContactsInfo> ContactData { get; set; }


		private int toHeight = 40;

		public int ToHeight
		{
			get { return toHeight; }
			set
			{
				toHeight = value;
				RaisePropertyChanged("ToHeight");
			}
		}


		private int ccHeight = 40;

		public int CcHeight
		{
			get { return ccHeight; }
			set
			{
				ccHeight = value;
				RaisePropertyChanged("CcHeight");
			}
		}

		private int bccHeight = 40;

		public int BccHeight
		{
			get { return bccHeight; }
			set
			{
				bccHeight = value;
				RaisePropertyChanged("BccHeight");
			}
		}



		private bool isToFocused = false;

		public bool IsToFocused
		{
			get { return isToFocused; }
			set
			{
				isToFocused = value;
				ToHeight = GetHeight(value);
				IsFocused = true;
				RaisePropertyChanged("IsToFocused");
			}
		}

		private bool isCcFocused = false;

		public bool IsCcFocused
		{
			get { return isCcFocused; }
			set
			{
				isCcFocused = value;
				CcHeight = GetHeight(value);
				IsFocused = true;
				RaisePropertyChanged("IsCcFocused");
			}
		}

		private bool isBccFocused = false;

		public bool IsBccFocused
		{
			get { return isBccFocused; }
			set
			{
				isBccFocused = value;
				IsFocused = true;
				BccHeight = GetHeight(value);
				RaisePropertyChanged("IsBccFocused");
			}
		}


		private object selectedItem;

		public object SelectedItem
		{
			get { return selectedItem; }
			set
			{
				selectedItem = value;
				RaisePropertyChanged("SelectedItem");
			}
		}

        private bool isFocused = false;

		public bool IsFocused
		{
			get { return isFocused; }
			set
			{
				RaisePropertyChanged("IsFocused");
			}
		}



		public string watermark = "";
		public string Watermark
		{
			get
			{
				return watermark;
			}
			set
			{
				watermark = value;


				RaisePropertyChanged("Watermark");

			}
		}

		public string customText = string.Empty;
        public string CustomText
		{
			get
			{
                return customText;
			}
			set
			{
                customText = value;


                RaisePropertyChanged("CustomText");

			}
		}


		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		#endregion

		string hintText = "ryan";
		double hintCount = 0;
		ObservableCollection<ContactsInfo> SelectedObject = new ObservableCollection<ContactsInfo>();
		public bool ShowHint()
		{

			if (hintCount < hintText.Length)
			{
                CustomText += hintText[(int)hintCount++];





				foreach (var info in ContactData)
				{
                    if (info.ContactName.ToLower() == CustomText)
					{
						SelectedObject.Add(info);
					}
				}

                if (CustomText == "kyle")
				{
					SelectedItem = ContactData[0];
					IsCcFocused = true;
					return false;
				}
             

				return true;
			}
			else
			{

				return false;
			}
		}


		public MultiSelectViewModel()
		{
			ContactData = new ContactsInfoRepository().GetContactDetails();
		}

		public int GetHeight(bool value)
		{
			if (value)
				return 90;
			return 40;
		}
	}


	public class ImageSourceToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

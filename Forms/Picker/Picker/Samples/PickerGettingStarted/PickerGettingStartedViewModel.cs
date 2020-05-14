#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleBrowser.SfPicker
{
	public class PickerGettingStartedViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<object> source;

		private bool isShowHeader = true;

		private bool isShowColumnHeader = false;

        private bool isEnableAutoReverse = false;

        private bool isEnableBorderColor = false;

		private int selectedIndex = 2;

		private string headerText = "SELECT A COLOR";

		private ObservableCollection<string> columnHeaderTextCollection;

		public event PropertyChangedEventHandler PropertyChanged;

		public PickerGettingStartedViewModel()
		{
			source = new ObservableCollection<object>();
			source.Add("Yellow");
			source.Add("Green");
			source.Add("Navy");
			source.Add("Orange");
			source.Add("Lime");
			source.Add("Purple");
			source.Add("Pink");
			source.Add("Red");
			source.Add("Gray");
			if (Device.RuntimePlatform != Device.Android && Device.RuntimePlatform != Device.UWP)
				headerText = "Select a Color";

			columnHeaderTextCollection = new ObservableCollection<string>();
			if (Device.RuntimePlatform == Device.Android)
			{
				columnHeaderTextCollection.Add("COLORS");
			}
			else
			{
				columnHeaderTextCollection.Add("Colors");
			}
		}

		public ObservableCollection<object> Source
		{
			get
			{
				return source;
			}

			set
			{
				source = value;
			}
		}

		public ObservableCollection<string> ColumnHeaderTextCollection
		{
			get
			{
				return columnHeaderTextCollection;
			}

			set
			{
				columnHeaderTextCollection = value;
			}
		}

		public bool IsShowHeader
		{
			get
			{
				return isShowHeader;
			}

			set
			{
				isShowHeader = value;
				OnPropertyChanged("IsShowHeader");
			}
		}

		public bool IsShowColumnHeader
		{
			get
			{
				return isShowColumnHeader;
			}

			set
			{
				isShowColumnHeader = value;
				OnPropertyChanged("IsShowColumnHeader");
			}
		}

        public bool IsEnableAutoReverse
        {
            get
            {
                return isEnableAutoReverse;
            }

            set
            {
                isEnableAutoReverse = value;
                OnPropertyChanged("IsEnableAutoReverse");
            }
        }

        public bool IsEnableBorderColor
        {
            get
            {
                return isEnableBorderColor;
            }

            set
            {
                isEnableBorderColor = value;
                OnPropertyChanged("IsEnableBorderColor");
            }
        }

		public string HeaderText
		{
			get
			{
				return headerText;
			}

			set
			{
				headerText = value;
				OnPropertyChanged("HeaderText");
			}
		}

		public int SelectedIndex
		{
			get
			{
				return selectedIndex;
			}

			set
			{
				selectedIndex = value;
				OnPropertyChanged("SelectedIndex");
			}
		}

		void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

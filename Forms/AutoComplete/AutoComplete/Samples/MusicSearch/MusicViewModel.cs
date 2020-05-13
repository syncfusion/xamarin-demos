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
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfAutoComplete
{
	public class MusicViewModel : INotifyPropertyChanged
	{
		private MusicInfo selectedItem;

		public MusicInfo SelectedItem
		{
			get { return selectedItem; }
			set
			{
				selectedItem = value;
				if (MusicIcon == "I")
					MusicIcon = "T";
				else
					MusicIcon = "I";

				OnPropertyChange("SelectedItem");
			}
		}

		private string musicIcon = "I";

		public string MusicIcon
		{
			get { return musicIcon; }
			set
			{
				musicIcon = value;
				OnPropertyChange("MusicIcon");
			}
		}


		private int move = 40;

		public int Move
		{
			get { return move; }
			set
			{
				move = value;
				OnPropertyChange("Move");
			}
		}

		private string playing = "0:00";

		public string Playing
		{
			get { return playing; }
			set
			{
				playing = value;
				OnPropertyChange("Playing");
			}
		}



		private bool isFocused = false;

		public bool IsFocused
		{
			get
			{

				return isFocused;
			}
			set
			{
				OnPropertyChange("IsFocused");
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


				OnPropertyChange("Watermark");

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


                OnPropertyChange("CustomText");

			}
		}



		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;



		#endregion

		string hintText = "d'une";
		double hintCount = 0;
		ObservableCollection<ContactsInfo> SelectedObject = new ObservableCollection<ContactsInfo>();
		public bool ShowHint()
		{

			if (hintCount < hintText.Length)
			{
                CustomText += hintText[(int)hintCount++];

				return true;
			}
			else
			{

				return false;
			}
		}


		public void OnPropertyChange(string property)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}

		public ObservableCollection<MusicInfo> DataCollection { get; set; }

		public MusicViewModel()
		{
			DataCollection = new ObservableCollection<MusicInfo>();
			DataCollection = new MusicInfoRepository().GetMusicInfo();

		}
	}

	public class NullToBoolConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

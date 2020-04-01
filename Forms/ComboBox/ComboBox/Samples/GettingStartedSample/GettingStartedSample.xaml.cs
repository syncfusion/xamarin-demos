#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using Syncfusion.XForms.ComboBox;
using Xamarin.Forms;

namespace SampleBrowser.SfComboBox
{
    public partial class GettingStartedSample : SampleView, INotifyPropertyChanged
    {
        public ObservableCollection<string> Source1 { get; set; }
        public ObservableCollection<string> Source2 { get; set; }
        public ObservableCollection<string> Source3 { get; set; }

        private string watermark = "Search Here";
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

        private int textSize = 17;
        public int TextSize
        {
            get
            {
                return textSize;
            }
            set
            {
                textSize = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TextSize"));
                }
            }
        }

        private bool isEditableComboBox = false;
        public bool IsEditableComboBox
        {
            get
            {
                return isEditableComboBox;
            }
            set
            {
                isEditableComboBox = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsEditableComboBox"));
                }
            }
        }

        private bool isIgnoreDiacritic = false;
        public bool IsIgnoreDiacritic
        {
            get
            {
                return isIgnoreDiacritic;
            }
            set
            {
                isIgnoreDiacritic = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsIgnoreDiacritic"));
                }
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;
        public GettingStartedSample()
        {
            InitializeComponent();
            Source1 = new ContactsInfoRepository().GetSizeDetails();
            Source2 = new ContactsInfoRepository().GetResolutionDetails();
            Source3 = new ContactsInfoRepository().GetOrientationDetails();
            this.BindingContext = this;
            optionLayout.BindingContext = this;
            PickerMethod();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            if (height < width && Device.RuntimePlatform == Device.iOS && Device.Idiom == TargetIdiom.Phone)
            {
                comboBox3.SuggestionBoxPlacement = SuggestionBoxPlacement.Top;
            }
            else
            {
                comboBox3.SuggestionBoxPlacement = SuggestionBoxPlacement.Bottom;
            }
            base.OnSizeAllocated(width, height);
        }

        private void PickerMethod()
        {
            ColorPicker.SelectedIndex = 0;
            BackColorPicker.SelectedIndex = 0;
            SizePicker.SelectedIndex = 2;
            ComboBoxModePicker.SelectedIndex = 0;
            SizePicker.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    switch (SizePicker.SelectedIndex)
                    {
                        case 0:
                            {
                                TextSize = 13;
                            }
                            break;
                        case 1:
                            {
                                TextSize = 15;
                            }
                            break;
                        case 2:
                            {
                                TextSize = 17;
                            }
                            break;
                    }
                };
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

	public class ComboBoxImageConverter : IValueConverter
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
							return "SampleBrowser.SfComboBox.UWP\\" + value;
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

	public class StringToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				if (value.ToString() == "Black")
					return Color.Black;
				else if (value.ToString() == "Blue")
					return Color.Blue;
				else if (value.ToString() == "Red")
					return Color.Red;
				else if (value.ToString() == "Yellow")
					return Color.Yellow;
			}
			return Color.Black;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	public class StringToColorConverter2 : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
                if (value.ToString() == "Transparent")
                    return Color.Transparent;
                else if (value.ToString() == "Blue")
                    return Color.FromHex("#7838f7");
                else if (value.ToString() == "Red")
                    return Color.FromHex("#f24864");
				else if (value.ToString() == "Yellow")
                    return Color.FromHex("#e6f954");
			}
			return Color.Transparent;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class StringToComboBoxModeConverter : IValueConverter
	{
	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	    {
	        if (value != null)
	        {
                if (value.ToString() == "Suggest")
                    return Syncfusion.XForms.ComboBox.ComboBoxMode.Suggest;
				else if (value.ToString() == "SuggestAppend")
                    return Syncfusion.XForms.ComboBox.ComboBoxMode.SuggestAppend;
				else if (value.ToString() == "Append")
                    return Syncfusion.XForms.ComboBox.ComboBoxMode.Append;

	        }
	        return Syncfusion.XForms.ComboBox.ComboBoxMode.Suggest;
	    }

	    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	    {
             throw new NotImplementedException();
	    }
	}
}
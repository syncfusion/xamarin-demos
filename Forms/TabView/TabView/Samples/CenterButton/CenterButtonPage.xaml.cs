#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleBrowser.Core;
using System.Collections.ObjectModel;
using System.Linq;
using System.Globalization;

namespace SampleBrowser.SfTabView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CenterButton : SampleView
    {
        public ObservableCollection<SampleBrowser.SfTabView.Model.ContactsInfo> PrimaryListSource { get; set; }
        public ObservableCollection<SampleBrowser.SfTabView.Model.ContactsInfo> SecondaryListSource { get; set; }
		public ObservableCollection<SampleBrowser.SfTabView.Model.ContactsInfo> ThirdListSource { get; set; }

        public CenterButton()
        {
            InitializeComponent();
			this.composer.CenterButtonObject = this;
            this.PrimaryListSource = new SampleBrowser.SfTabView.Model.ContactsInfoRepository().GetContactDetails(7);
            this.SecondaryListSource = new SampleBrowser.SfTabView.Model.ContactsInfoRepository().GetContactDetails(4);
			this.ThirdListSource = new SampleBrowser.SfTabView.Model.ContactsInfoRepository().GetContactDetails(16);
            this.BindingContext = this;
            
        }
        
		void Handle_Tapped(object sender, System.EventArgs e)
        {
            var item = sender as Image;
            if (item.StyleId == "Tabimage")
            {
                TabView.SelectedIndex = 0;
            }
            else if (item.StyleId == "Tabimage1")
            {
                TabView.SelectedIndex = 1;
            }
            else if (item.StyleId == "Tabimage2")
            {
                TabView.SelectedIndex = 2;
            }
            else if (item.StyleId == "Tabimage3")
            {
				TabView.SelectedIndex = 3;
            }
        }

        void Handle_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        {
            if (TabView.SelectedIndex == 3)
            {
                // Navigation.PushAsync(new Profile());
            }
        }

        void CenterButton_Tapped(object sender, System.EventArgs e)
        {
			this.ComposeDialog.Opacity = 0;
			this.ComposeDialog.IsVisible = true;
			this.ComposeDialog.FadeTo(1, 600, Easing.Linear);
          
        }
		void Button_Clicked(object sender, System.EventArgs e)
        {
			TabView.SelectedIndex = 0;
        }
		void Grid_Tapped(object sender, System.EventArgs e)
		{
			if (this.ComposeDialog.IsVisible)
			{
				CloseDialog();
			}
        }

		public void CloseDialog()
        {
			this.ComposeDialog.FadeTo(0, 600, Easing.Linear);
			this.ComposeDialog.IsVisible = false;
			TabView.SelectedIndex = 0;
        }

             
    }

	public class DateTimeToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (DateTime)value;
            if (item != null)
            {
                return item.ToString("hh:mm tt");
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    public class ImageConverter : IValueConverter
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
                            return "SampleBrowser.SfTabView.UWP\\" + value;
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
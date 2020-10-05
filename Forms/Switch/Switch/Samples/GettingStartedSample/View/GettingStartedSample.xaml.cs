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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfSwitch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GettingStartedSample : SampleView
    {
        #region Members

        private ObservableCollection<AppModel> listCollection = new ObservableCollection<AppModel>();

        private bool canNotify;

        #endregion

        #region properties

        /// <summary>
        /// Collection which contains the items that will be enabled and disabled by the segment control to display on the main segment control.
        /// </summary>
        public ObservableCollection<AppModel> ListCollection
        {
            get
            {
                return listCollection;
            }
            set
            {
                listCollection = value;
            }
        }

        public bool CanNotify
        {
            get
            {
                return canNotify;
            }
            set
            {
                if (canNotify != value)
                {
                    canNotify = value;
                    raisepropertyChanged("CanNotify");
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Token constructor
        /// </summary>
        public GettingStartedSample()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                switchRow.Height = 70;
            }

            if (Device.Idiom == TargetIdiom.Desktop)
            {
                MainGrid.VerticalOptions = LayoutOptions.Start;
                MainGrid.HorizontalOptions = LayoutOptions.Start;
                MainGrid.HeightRequest = 500;
                MainGrid.WidthRequest = 500;
            }

            ListCollection.Add(new AppModel(this) { Name = "Facebook", IconColor = Color.FromHex("FF355088"), Icon = "F", CanNotify = true });
            ListCollection.Add(new AppModel(this) { Name = "Twitter", IconColor = Color.FromHex("FF1192DF"), Icon = "T", CanNotify = false });
            ListCollection.Add(new AppModel(this) { Name = "YouTube", IconColor = Color.FromHex("FFD41D1F"), Icon = "Y", CanNotify = true });
            ListCollection.Add(new AppModel(this) { Name = "Instagram", IconColor = Color.FromHex("FFE1306C"), Icon = "I", CanNotify = false });
            ListCollection.Add(new AppModel(this) { Name = "Gmail", IconColor = Color.FromHex("FFE9594E"), Icon = "Z", CanNotify = true });
            ListCollection.Add(new AppModel(this) { Name = "LinkedIn", IconColor = Color.FromHex("FF0172B6"), Icon = "L", CanNotify = true });
            ListCollection.Add(new AppModel(this) { Name = "Skype", IconColor = Color.FromHex("FF1EA5DD"), Icon = "S", CanNotify = true });

            this.BindingContext = this;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Handles the item tapped.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }

        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler propertyChanged;
        private void raisepropertyChanged(string property)
        {
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
        }
        #endregion

        bool? oldValue = null;

        private async void AllAppSwitch_StateChanged(object sender, SwitchStateChangedEventArgs e)
        {
            if (!setAllAppsSwitchState)
            {
                return;
            }
            else
            {
                if (allAppSwitch.IsOn == null)
                {
                    allAppSwitch.IsOn = oldValue;
                }
            }
            await Task.Delay(1);
            if (this.allAppSwitch.IsOn == true)
            {
                foreach (var appModel in this.ListCollection)
                {
                    appModel.CanNotify = true;
                }
            }
            else if (this.allAppSwitch.IsOn == false)
            {
                foreach (var appModel in this.ListCollection)
                {
                    appModel.CanNotify = false;
                }
            }
            oldValue = this.allAppSwitch.IsOn;
        }

        bool setAllAppsSwitchState = true;
        private async void SfSwitch_StateChanged(object sender, SwitchStateChangedEventArgs e)
        {
            setAllAppsSwitchState = false;
            bool hasTrue = false;

            bool hasFalse = false;

            foreach (var appModel in this.ListCollection)
            {
                if (appModel.CanNotify == true)
                {
                    hasTrue = true;
                }
                if (appModel.CanNotify == false)
                {
                    hasFalse = true;
                }
            }

            if (hasFalse && hasTrue)
            {
                this.allAppSwitch.AllowIndeterminateState = true;
                this.allAppSwitch.IsOn = null;
            }
            else if (hasFalse && !hasTrue)
            {
                this.allAppSwitch.AllowIndeterminateState = false;
                this.allAppSwitch.IsOn = false;
            }
            else if (!hasFalse && hasTrue)
            {
                this.allAppSwitch.AllowIndeterminateState = false;
                this.allAppSwitch.IsOn = true;
            }
            await Task.Delay(250);
            setAllAppsSwitchState = true;

        }
    }
    #region App Model
    /// <summary>
    /// Model class for the tokens
    /// </summary>
    public class AppModel : INotifyPropertyChanged
    {
        #region Members
        private bool? canNotify;
        private String name;
        private String icon;
        private Color iconColor;
        private Color selectedColor = Color.FromHex("#E4E4E4");
        private Color capColor = Color.FromHex("#C2C1C1");
        private ObservableCollection<SfSegmentItem> dataCollection = new ObservableCollection<SfSegmentItem>();
        private GettingStartedSample tokensObject;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the name for the items present in the list.
        /// </summary>
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                raisepropertyChanged("Name");
            }
        }
        /// <summary>
        /// get or set the icons inside the listview
        /// </summary>
        public String Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                raisepropertyChanged("Icon");
            }
        }
        /// <summary>
        /// Get or set the color for the icons used inside the listview.
        /// </summary>
        public Color IconColor
        {
            get
            {
                return iconColor;
            }
            set
            {
                iconColor = value;
                raisepropertyChanged("IconColor");
            }
        }

        public bool? CanNotify
        {
            get
            {
                return canNotify;
            }
            set
            {
                if (canNotify != value)
                {
                    canNotify = value;
                    raisepropertyChanged("CanNotify");
                }
            }
        }

        /// <summary>
        /// Data collection for the items used inside the listview
        /// </summary>
        public ObservableCollection<SfSegmentItem> DataCollection
        {
            get
            {
                return dataCollection;
            }
            set
            {
                dataCollection = value;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor initialising for the App model class
        /// </summary>
        /// <param name="tokens"></param>
        public AppModel(GettingStartedSample tokens)
        {
            tokensObject = tokens;
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void raisepropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
    #endregion

    /// <summary>
    /// To get the platformm specfic path for font icon.
    /// </summary>
    public class SwitchConverter : IValueConverter
    {
        /// <summary>
        /// Converts default value to font value
        /// </summary>
        /// <param name="value">the value</param>
        /// <param name="targetType">the targetType</param>
        /// <param name="parameter">the parameter</param>
        /// <param name="culture">the culture</param>
        /// <returns>convert value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == "Android")
            {
                if (parameter != null && parameter is string)
                    return "switch.ttf#" + parameter.ToString();
                else
                    return "switch.ttf";
            }
            else if (Device.RuntimePlatform == "iOS")
            {
                return "switch";
            }
            else
            {
#if COMMONSB
                return "/Assets/Fonts/switch.ttf#switch";
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    return "/Assets/Fonts/switch.ttf#switch";
                }
                else
                {
                    return
                        $"ms-appx:///SampleBrowser.SfSegmentedControl.UWP/Assets/Fonts/switch.ttf#switch";
                }
#endif
            }
        }

        /// <summary>
        /// Converts the font back to its default form
        /// </summary>
        /// <param name="value">the value</param>
        /// <param name="targetType">the targetType</param>
        /// <param name="parameter">the parameter</param>
        /// <param name="culture">the culture</param>
        /// <returns>convert back value</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
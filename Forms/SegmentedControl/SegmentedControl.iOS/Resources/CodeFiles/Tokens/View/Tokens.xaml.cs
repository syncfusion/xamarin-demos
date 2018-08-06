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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfSegmentedControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tokens : SampleView
    {
        #region Members

        private int selectedIndex = 2;
        private int oldIndex = -1;

        private ObservableCollection<SfSegmentItem> dataCollection = new ObservableCollection<SfSegmentItem>();

        private ObservableCollection<AppModel> listCollection = new ObservableCollection<AppModel>();

        private ObservableCollection<SfSegmentItem> _tokenCollection = new ObservableCollection<SfSegmentItem>();

        private bool canNotify;

        private bool allowSelectionChanged = false;

        private Color selectedColor = Color.Silver;

        #endregion

        #region properties

        /// <summary>
        /// Selected index property for ListView switch case.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                raisepropertyChanged("SelectedIndex");

                this.UpdateSegmentColor(value);
                if (value == 1 && this.MainSwitch.SelectedIndex != 1)
                {
                    allowSelectionChanged = true;
                    this.MainSwitch.SelectedIndex = 1;
                }
                else if (value == 0 && this.MainSwitch.SelectedIndex != 0)
                {
                    allowSelectionChanged = true;
                    this.MainSwitch.SelectedIndex = 0;
                }
                else if (value == 2 && this.MainSwitch.SelectedIndex != 2)
                {
                    allowSelectionChanged = true;
                    this.MainSwitch.SelectedIndex = 2;
                }
                else
                {
                    allowSelectionChanged = false;
                }
            }
        }

        /// <summary>
        /// Collection for FontIcon used to enable and disable all the items present inside the listview.
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
        /// <summary>
        /// Collection which display the items from list view to main segment control 
        /// </summary>
        public ObservableCollection<SfSegmentItem> TokenCollection
        {
            get
            {
                return _tokenCollection;
            }
            set
            {
                _tokenCollection = value;
            }
        }
        /// <summary>
        /// Get or set the selected color
        /// </summary>
        public Color SelectedColor
        {
            get
            {
                return selectedColor;
            }
            set
            {
                selectedColor = value;
                raisepropertyChanged("SelectedColor");
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
                    if (canNotify)
                    {
                        SelectedColor = Color.FromHex("#BADAF6");
                    }
                    else
                    {
                        SelectedColor = Color.FromHex("#E4E4E4");
                    }
                    raisepropertyChanged("CanNotify");
                }
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Token constructor
        /// </summary>
        public Tokens()
        {
            InitializeComponent();
            var fontFamily = "switch.ttf";
            if (Device.RuntimePlatform == Device.UWP)
            {
                fontFamily = "/Assets/switch.ttf#switch";
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                fontFamily = "switch";
            }
            DataCollection.Add(new SfSegmentItem() { IconFont = "o", FontIconFontColor = Color.Transparent, FontIconFontSize = 20, FontIconFontFamily = fontFamily });
            DataCollection.Add(new SfSegmentItem() { IconFont = "i", FontIconFontColor = Color.Transparent, FontIconFontSize = 20, FontIconFontFamily = fontFamily });
            DataCollection.Add(new SfSegmentItem() { IconFont = "c", FontIconFontColor = Color.Transparent, FontIconFontSize = 20, FontIconFontFamily = fontFamily });
            ListCollection.Add(new AppModel(this) { Name = "Facebook", IconColor = Color.FromHex("FF355088"), Icon = "F", CanNotify = true });
            ListCollection.Add(new AppModel(this) { Name = "Twitter", IconColor = Color.FromHex("FF1192DF"), Icon = "T" });
            ListCollection.Add(new AppModel(this) { Name = "Youtube", IconColor = Color.FromHex("FFD41D1F"), Icon = "Y", CanNotify = true });
            ListCollection.Add(new AppModel(this) { Name = "Instagram", IconColor = Color.FromHex("FFE1306C"), Icon = "I" });
            ListCollection.Add(new AppModel(this) { Name = "Gmail", IconColor = Color.FromHex("FFE9594E"), Icon = "Z" });
            ListCollection.Add(new AppModel(this) { Name = "Linked In", IconColor = Color.FromHex("FF0172B6"), Icon = "L", CanNotify = true });
            ListCollection.Add(new AppModel(this) { Name = "Maps", IconColor = Color.FromHex("FFD88722"), Icon = "A" });
            ListCollection.Add(new AppModel(this) { Name = "Word", IconColor = Color.FromHex("FF2B569A"), Icon = "W" });
            ListCollection.Add(new AppModel(this) { Name = "Excel", IconColor = Color.FromHex("FF207346"), Icon = "E", CanNotify = true });
            ListCollection.Add(new AppModel(this) { Name = "PowerPoint", IconColor = Color.FromHex("FFD24625"), Icon = "O" });
            ListCollection.Add(new AppModel(this) { Name = "Skype", IconColor = Color.FromHex("FF1EA5DD"), Icon = "S", CanNotify = true });
            ListCollection.Add(new AppModel(this) { Name = "Photo", IconColor = Color.FromHex("FFFF7214"), Icon = "P" });
            ListCollection.Add(new AppModel(this) { Name = "Music", IconColor = Color.FromHex("FF359D8A"), Icon = "M" });
            ListCollection.Add(new AppModel(this) { Name = "Video", IconColor = Color.FromHex("FF90558B"), Icon = "V" });
            this.BindingContext = this;
        }
        #endregion
        #region Methods
        public void SetIndex()
        {
            int value = 0;
            foreach (var item in ListCollection)
            {
                if (item.CanNotify)
                    value += 2;
            }
            if (value == listCollection.Count * 2)
                SelectedIndex = 2;
            else if (value == 0)
                SelectedIndex = 0;
            else
                SelectedIndex = 1;
        }

        /// <summary>
        /// Handles the item tapped.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }

        /// <summary>
        /// Handles the selection changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Handle_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            if (allowSelectionChanged) return;
            this.UpdateSegmentColor(e.Index);
            {
                if (e.Index == 1 && oldIndex == 2)
                {
                    allowSelectionChanged = true;
                    this.MainSwitch.SelectedIndex = 0;
                    this.UpdateSegmentColor(0);

                }
                else if (e.Index == 1 && oldIndex == 0)
                {
                    allowSelectionChanged = true;
                    this.MainSwitch.SelectedIndex = 2;
                    this.UpdateSegmentColor(2);
                }
                else
                    allowSelectionChanged = false;
            }

            oldIndex = this.MainSwitch.SelectedIndex;
        }


        private void UpdateSegmentColor(int index)
        {
            if (index == 0)
            {
                this.MainSwitch.Color = Color.FromHex("FFFF6B60");
                foreach (var appModel in this.ListCollection)
                {
                    appModel.CanNotify = false;
                }
            }
            else if (index == 1)
                this.MainSwitch.Color = Color.FromHex("FFF9AA49");
            else
            {
                this.MainSwitch.Color = Color.FromHex("FF2BCFD0");
                foreach (var appModel in this.ListCollection)
                {
                    appModel.CanNotify = true;
                }
            }
        }


        /// <summary>
        /// Method to remove tokens from the main segment view.
        /// </summary>
        /// <param name="model"></param>
        public void RemoveTokens(AppModel model)
        {
            foreach (var item in TokenCollection)
            {
                if (item.Text == model.Name)
                {
                    TokenCollection.Remove(item);
                    break;
                }
            }
        }
        public void Add(AppModel model)
        {
            this.TokenCollection.Add(new SfSegmentItem() { Text = model.Name, BackgroundColor = model.IconColor });
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
    }
    #region App Model
    /// <summary>
    /// Model class for the tokens
    /// </summary>
    public class AppModel : INotifyPropertyChanged
    {
        #region Members
        private bool canNotify;
        private String name;
        private String icon;
        private Color iconColor;
        private Color selectedColor = Color.FromHex("#E4E4E4");
        private Color capColor = Color.FromHex("#C2C1C1");
        private ObservableCollection<SfSegmentItem> dataCollection = new ObservableCollection<SfSegmentItem>();
        private Tokens tokensObject;
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
        /// <summary>
        /// Get or set the color when the item get selected.
        /// </summary>
        public Color SelectedColor
        {
            get
            {
                return selectedColor;
            }
            set
            {
                selectedColor = value;
                raisepropertyChanged("SelectedColor");
            }
        }
        /// <summary>
        /// get or set the selection strip colour for the switches
        /// </summary>
        public Color CapColor
        {
            get
            {
                return capColor;
            }
            set
            {
                capColor = value;
                raisepropertyChanged("CapColor");
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
                    if (canNotify)
                    {
                        SelectedColor = Color.FromHex("#BADAF6");
                        CapColor = Color.FromHex("#007DEE");
                        tokensObject.Add(this);
                    }
                    else
                    {
                        SelectedColor = Color.FromHex("#E4E4E4");
                        CapColor = Color.FromHex("#C2C1C1");
                        tokensObject.RemoveTokens(this);
                    }
                    if (tokensObject.TokenCollection.Count == 0)
                    {
                        tokensObject.SelectedIndex = 0;
                    }
                    else if (tokensObject.TokenCollection.Count == 14)
                    {
                        tokensObject.SelectedIndex = 2;
                    }
                    else if (tokensObject.TokenCollection.Count > 0 && tokensObject.TokenCollection.Count < 14)
                    {
                        tokensObject.SelectedIndex = 1;
                    }
                    raisepropertyChanged("CanNotify");
                    tokensObject.SetIndex();
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
        public AppModel(Tokens tokens)
        {
            DataCollection.Add(new SfSegmentItem() { Text = "" });
            DataCollection.Add(new SfSegmentItem() { Text = "" });
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
    /// Converter for the segmented view used inside the listview which act like a switch.
    /// </summary>
    public class BoolToNumConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "true")
            {
                return 1;
            }
            return 0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "1")
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace SampleBrowser.SfTabView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabViewGettingStarted : SampleView
    {
        private Syncfusion.XForms.TabView.SfTabView tabView;
        private ObservableCollection<ListView> ListViewCollection = new ObservableCollection<ListView>();
        private TabDataViewModel viewModel = new TabDataViewModel();

        public TabViewGettingStarted()
        {
            InitializeComponent();
            ConfigureListView();
            tabView = GetTabView();
            tabView.TabHeight = 64;
            this.Content = tabView;
            EnableScrollSwitch.Toggled += EnableScrollableSwitch_Toggled;
        }

        private void EnableScrollableSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if(e.Value == true)
            {
               
                if (this.tabView.OverflowMode == OverflowMode.Scroll)
                {
                    this.tabView.IsScrollButtonEnabled = true;
                    this.tabView.ScrollButtonForegroundColor = Color.White;
                    this.tabView.VisibleHeaderCount = 3;
                }
                else
                {
                    this.EnableScrollSwitch.IsToggled = false;
                    this.tabView.VisibleHeaderCount = null;

                }
                }
            else
            {
                if (this.tabView.OverflowMode == OverflowMode.Scroll)
                {
                    this.tabView.IsScrollButtonEnabled = false;
                    this.tabView.VisibleHeaderCount = null;
                }
            }
           
        }

        private Syncfusion.XForms.TabView.SfTabView GetTabView()
        {
            var _tabView = new Syncfusion.XForms.TabView.SfTabView();
            _tabView.DisplayMode = TabDisplayMode.ImageWithText;
            _tabView.OverflowMode = OverflowMode.Scroll;
            _tabView.TabHeaderBackgroundColor = Color.FromHex("#2196F3");
            _tabView.OverflowButtonSettings = new OverflowButtonSettings() { TitleFontColor = Color.White };
            _tabView.VisibleHeaderCount = 4;
            if (Device.RuntimePlatform == "iOS")
                _tabView.TabHeight = 60;
            var index = 0;
            var iconList = new[] {"A", "C", "F", "H", "K"};
            foreach (var category in viewModel.Categories)
            {
                var tabViewItem = new SfTabItem
                {
                    Title = category,
                    IconFont = iconList[index],
                    Content = ListViewCollection[index],
                    SelectionColor = Color.White,
                    TitleFontColor = Color.LightBlue,
                    FontIconFontColor = Color.LightBlue,
                    TitleFontSize = Device.Idiom == TargetIdiom.Tablet ? 16 : 12
                };
               if(Device.RuntimePlatform == "iOS")
                {
                    tabViewItem.FontIconFontFamily = "TabIcons";
                }
               else if(Device.RuntimePlatform == "Android")
                {
                    tabViewItem.FontIconFontFamily = "TabIcons.ttf";
                }
               else if(Device.RuntimePlatform == "UWP")
                {
#if COMMONSB
                    tabViewItem.FontIconFontFamily = "/Assets/Fonts/TabIcons.ttf#TabIcons";
#else
                    if (Core.SampleBrowser.IsIndividualSB)
                    {
                        tabViewItem.FontIconFontFamily = "/Assets/Fonts/TabIcons.ttf#TabIcons";
                    }
                    else
                    {
                        tabViewItem.FontIconFontFamily = $"ms-appx:///SampleBrowser.SfTabView.UWP/Assets/Fonts/TabIcons.ttf#TabIcons";    //@"SampleBrowser.SfTabView.UWP\Assets\Fonts\TabIcons.ttf#TabIcons";
                    }
#endif
                }
                _tabView.Items.Add(tabViewItem);
                index++;
            }

            _tabView.SelectionIndicatorSettings = new SelectionIndicatorSettings()
            {
                Position = SelectionIndicatorPosition.Bottom,
                Color = Color.White
            };

            _tabView.TabHeaderPosition = TabHeaderPosition.Top;
            return _tabView;
        }


        private void ConfigureListView()
        {
            int i = 0;
            foreach (var item in viewModel.Categories)
            {
                var data = from cust in viewModel.Data
                    where cust.Category == item
                    select cust;
                DataTemplate dataTemplate;
                int rowHeight;
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    dataTemplate = new DataTemplate(typeof(ItemViewTabletMode));
                    rowHeight = 250;
                }
                else
                {
                    dataTemplate = new DataTemplate(typeof(ProductView));
                    rowHeight = 240;
                }
                var listView = new ListView
                {
                    RowHeight = rowHeight,
                    ItemsSource = data,
                    BackgroundColor = Color.White,
                    ItemTemplate = dataTemplate,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    SeparatorColor = Color.Transparent
                };
                //   listView.LayoutManager = new GridLayout() { SpanCount = 3 };
                ListViewCollection.Add(listView);
                i++;
            }
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = sender as Picker;
            if (picker == null) return;
            switch (picker.SelectedIndex)
            {
                case 0:
                    tabView.OverflowMode = OverflowMode.Scroll;
                    if(tabView.IsScrollButtonEnabled)
                    {
                        this.EnableScrollSwitch.IsToggled = true;
                    }
                    else
                    {
                        this.EnableScrollSwitch.IsToggled = false;
                    }
                    break;
                case 1:
                    tabView.OverflowMode = OverflowMode.DropDown;
                    this.EnableScrollSwitch.IsToggled = false;
                    break;
            }
        }

        private void HeaderTypePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker == null) return;
            switch (picker.SelectedIndex)
            {
                case 0:
                    tabView.DisplayMode = TabDisplayMode.Text;
                    tabView.TabHeight = 48;
                    break;
                case 1:
                    tabView.DisplayMode = TabDisplayMode.Image;
                    tabView.TabHeight = 48;
                    break;
                case 2:
                    tabView.DisplayMode = TabDisplayMode.ImageWithText;
                    tabView.TabHeight = 64;
                    break;
                default:
                    tabView.DisplayMode = TabDisplayMode.NoHeader;
                    break;
            }
        }

        private void HeaderPositionPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker == null) return;
            switch (picker.SelectedIndex)
            {
                case 0:
                    tabView.TabHeaderPosition = TabHeaderPosition.Top;
                    break;
                default:
                    tabView.TabHeaderPosition = TabHeaderPosition.Bottom;
                    break;
            }
        }

        private void SelectionIndicatorPositionPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if(picker == null) return;
            switch (picker.SelectedIndex)
            {
                case 0:
                    tabView.SelectionIndicatorSettings.Position = SelectionIndicatorPosition.Top;
                    break;
                default:
                    tabView.SelectionIndicatorSettings.Position = SelectionIndicatorPosition.Bottom;
                    break;
            }
        }
    }
}
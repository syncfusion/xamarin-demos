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
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using Syncfusion.Android.TabView;

namespace SampleBrowser
{
    internal class TabControl : SfTabView
    {
        private ObservableCollection<ListView> ListViewCollection = new ObservableCollection<ListView>();
        private TabDataViewModel viewModel = new TabDataViewModel();
        private List<string> fontstring = new List<string>();
        TabDisplayMode displayMode;
        TabHeaderPosition tabheaderPosition;
        SelectionIndicatorPosition selectionindicatorPosition;
        //SelectionIndicatorSettings selectionindicatorSetting;
        Context appcontext;
        public TabControl(Context context) : base(context)
        {
            appcontext = context;
            fontstring.Add("A");
            fontstring.Add("C");
            fontstring.Add("F");
            fontstring.Add("H");
            fontstring.Add("K");
            ConfigureListView();
            ConfigureTabView();
        }

        private void ConfigureTabView()
        {
            this.SetBackgroundColor(Color.ParseColor("#037ef3"));
            var index = 0;
            foreach (var category in viewModel.Categories)
            {
                var tabViewItem = new SfTabItem
                {
                    Title = category,
                    IconFont = fontstring[index],
                    FontIconStyle = Typeface.CreateFromAsset(appcontext.Assets, "TabIcons.ttf"),
                    Content = ListViewCollection[index],
                    SelectionColor = Color.White,
                    TitleFontColor = Color.White,
                    FontIconFontColor = Color.White,
                };
                this.Items.Add(tabViewItem);
                index++;
            }

            this.SelectionIndicatorSettings = new SelectionIndicatorSettings()
            {
                Position = SelectionIndicatorPosition.Bottom,
                Color = Color.White
            };

            this.selectionindicatorPosition = SelectionIndicatorPosition.Bottom;
            this.displayMode = TabDisplayMode.Text;
            this.OverflowMode = OverflowMode.Scroll;
            this.VisibleHeaderCount = 4;
            this.tabheaderPosition = TabHeaderPosition.Top;
        }


        private void ConfigureListView()
        {
            int index = 0;
            foreach (var category in viewModel.Categories)
            {

                var data = from cust in viewModel.Data
                           where cust.Category == category
                           select cust;

                //  var dataTemplate = new DataTemplate(typeof(ItemView));
                if (index % 2 == 0)
                {
                    //   dataTemplate = new DataTemplate(typeof(ProductView));
                }

                var listView = new ListView(Context);
                TabContentListAdapter tabContentListAdapter = new TabContentListAdapter(data);
                listView.DividerHeight = 0;
                listView.Divider = null;
                listView.Adapter=tabContentListAdapter;
                //{
                // ItemsSource = data,
                //RowHeight = rowHeight,
                //HeightRequest = 500,
                //                    WidthRequest = 500,

                //        BindingContext = viewModel,
                //      ItemTemplate = dataTemplate,
                //HorizontalOptions = LayoutOptions.FillAndExpand,
                //  VerticalOptions = LayoutOptions.FillAndExpand
                //};


                //listView.Loaded += ListView_Loaded;
                //   listView.LayoutManager = new GridLayout() { SpanCount = 3 };
                ListViewCollection.Add(listView);
                index++;
            }
        }

        public void ApplyChanges()
        {

            this.displayMode = this.DisplayMode;
            if (this.displayMode == TabDisplayMode.ImageWithText)
                this.TabHeight = 72;
            else
                this.TabHeight = 48;
            this.tabheaderPosition = this.TabHeaderPosition;
            this.selectionindicatorPosition = this.SelectionIndicatorSettings.Position;
        }
      
    }
}
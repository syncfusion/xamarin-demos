#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfTreeMap.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfTreeMap
{
   [Preserve(AllMembers = true)]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TreeMapGettingStarted : SampleView
    {
        public static bool IsDarkTheme = false;
        ToolbarItem baritem;
        LayoutTypes layoutType = LayoutTypes.Squarified;
        Label label3, label4, label5, label6, label9;
        double groupPadding = 4;
        RangeColorMapping rangeMapping;

        DesaturationColorMapping desaturationMapping;
        UniColorMapping uniMapping;
        PaletteColorMapping paletteMapping;

        Syncfusion.SfTreeMap.XForms.ColorMapping treeMapColorMapping;
        Picker picker1, picker2;
        Xamarin.Forms.Slider toggleButton, toggleButton2;
        public TreeMapGettingStarted()
        {
            InitializeComponent();

            baritem = new ToolbarItem();
            this.BindingContext = this;
            ObservableCollection<Range> ranges = new ObservableCollection<Range>();
            ranges.Add(new Range() { LegendLabel = "1 % Growth", From = 0, To = 1, Color = Color.FromHex("#77D8D8") });
            ranges.Add(new Range() { LegendLabel = "2 % Growth", From = 0, To = 2, Color = Color.FromHex("#AED960") });
            ranges.Add(new Range() { LegendLabel = "3 % Growth", From = 0, To = 3, Color = Color.FromHex("#FFAF51") });
            ranges.Add(new Range() { LegendLabel = "4 % Growth", From = 0, To = 4, Color = Color.FromHex("#F3D240") });
            this.TreeMap.LeafItemColorMapping = rangeMapping = new RangeColorMapping() { Ranges = ranges };
            treeMapColorMapping = rangeMapping;
            desaturationMapping = new DesaturationColorMapping() { From = 1, To = 0.2, Color = Color.FromHex("#02AEDC") };
            this.TreeMap.DataSource = new PopulationViewModel().PopulationDetails;
            uniMapping = new UniColorMapping() { Color = Color.FromHex("#D21243") };

            paletteMapping = new PaletteColorMapping();
            paletteMapping.Colors.Add(Color.FromHex("#BD8EC2"));
            paletteMapping.Colors.Add(Color.FromHex("#FFD34E"));
            paletteMapping.Colors.Add(Color.FromHex("#55B949"));
            paletteMapping.Colors.Add(Color.FromHex("#00B2DA"));
            paletteMapping.Colors.Add(Color.FromHex("#744A94"));
            paletteMapping.Colors.Add(Color.FromHex("#A1A616"));
            paletteMapping.Colors.Add(Color.FromHex("#0753A1"));
			DrawOptionsPage();
            baritem.Clicked += buttonClicked;
            this.PropertyView = GetOptionPage();
            toggleButton.Value = groupPadding;

        }

        private void DrawOptionsPage()
        {
            toggleButton = new Xamarin.Forms.Slider();
            toggleButton.MinimumTrackColor = Color.FromHex("#177CE7");
            toggleButton.MaximumTrackColor = Color.DarkGray;
            toggleButton.ThumbColor = Color.FromHex("#1a1aff");
            toggleButton.Value = 2;
            toggleButton2 = new Xamarin.Forms.Slider();
            toggleButton2.Value = 2;
            toggleButton.Maximum = 20;
            toggleButton2.Maximum = 20;
            toggleButton2.ValueChanged += (object sender, ValueChangedEventArgs e) =>
            {
                //groupGap = e.NewValue;
            };
            toggleButton.ValueChanged += (object sender, ValueChangedEventArgs e) => {
                groupPadding = e.NewValue;
                ApplyChanges();
            };
            picker1 = new Picker();
            picker2 = new Picker();
            picker1.Items.Add("Squarified");
            picker1.Items.Add("Slice And Dice Horizontal");
            picker1.Items.Add("Slice And Dice Vertical");
            picker1.Items.Add("Slice And Dice Auto");
            picker1.HeightRequest = 40;
            picker1.SelectedIndex = 0;
            picker1.SelectedIndexChanged += picker1_SelectedIndexChanged;


            picker2.Items.Add("RangeColorMapping");
            picker2.Items.Add("DesaturationColorMapping");
            picker2.Items.Add("UniColorMapping");
            picker2.Items.Add("PaletteColorMapping");
            picker2.HeightRequest = 40;
            picker2.SelectedIndex = 0;

            picker2.SelectedIndexChanged += picker2_SelectedIndexChanged;




            label6 = new Label()
            {
                Text = " " + "Settings",
                FontSize = 60,
                HeightRequest = 60,
                VerticalTextAlignment = TextAlignment.End,
            };
            label3 = new Label()
            {
                Text = "Layout Type",
                HeightRequest = 20,
                VerticalTextAlignment = TextAlignment.End,
            };
            label4 = new Label()
            {
                Text = "Color Mapping",
                HeightRequest = 20,
                VerticalTextAlignment = TextAlignment.End,
            };
            label5 = new Label()
            {
                Text = "Group Padding",
                HeightRequest = 30,
                VerticalTextAlignment = TextAlignment.Center,
            };
            label9 = new Label()
            {
                Text = "Group Gap",
                HeightRequest = 20,
                VerticalTextAlignment = TextAlignment.Center,
            };


            if (Device.RuntimePlatform == Device.Android)
            {
                picker1.BackgroundColor = Color.FromRgb(239, 239, 239);
                picker2.BackgroundColor = Color.FromRgb(239, 239, 239);
                label3.FontSize = 20;
                label4.FontSize = 20;
                label5.FontSize = 20;
            }
            //label10.WidthRequest = tree.Width;
            //label11.WidthRequest = tree.Width;
            label5.WidthRequest = label9.Width;
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {

                label5.WidthRequest = 150;
                label9.WidthRequest = 150;

                picker1.HeightRequest = 60;
                picker2.HeightRequest = 60;




                FileImageSource images = new FileImageSource();
                images.File = "options.png";
                baritem.Icon = images;
                label3.Text = "  " + "Layout Type";
                label3.HeightRequest = 22;
                label4.Text = "  " + "Color Mapping";
                label4.HeightRequest = 22;
                label5.Text = "  " + "Group Padding";
                label5.HeightRequest = 22;

                label9.TextColor = Color.White;
				

            }
			if (Device.RuntimePlatform == Device.iOS)
            {
                picker1.HeightRequest = 0;
                label3.Text = "";
            }
        }


        private StackLayout GetOptionPage()
        {

            //	toggleButton.WidthRequest = picker1.Width - label5.Width;
            //	toggleButton2.WidthRequest = picker1.Width - label9.Width;
            toggleButton.HorizontalOptions = LayoutOptions.Fill;
            toggleButton2.HorizontalOptions = LayoutOptions.Fill;
            var layoutpage = new StackLayout
            {
                Spacing = 10,
                Orientation = StackOrientation.Vertical,
                //Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 50),
                Children = { label5, toggleButton }
            };
            //			var togglepage = new StackLayout
            //			{
            //				Spacing = 10,
            //				Orientation = StackOrientation.Vertical,
            //				//Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 50),
            //				Children = { label9, toggleButton2 }
            //			};
            var page1 = new StackLayout
            {
                Spacing = 10,
                Orientation = StackOrientation.Vertical,
                //Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 50),
                Children = { label3, picker1 }
            };
            var page2 = new StackLayout
            {
                Spacing = 10,
                Orientation = StackOrientation.Vertical,
                //Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 50),
                Children = { label4, picker2 }
            };
            var page3 = new StackLayout
            {
                Spacing = 40,
                Orientation = StackOrientation.Vertical,
                //Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
                Children = { page1, page2 }
            };

            var page = new StackLayout
            {
                Spacing = 40,
                Orientation = StackOrientation.Vertical,
                Padding = 10,
                Children = { page3, layoutpage }
            };

            var page4 = new StackLayout
            {
                Spacing = 40,
                Orientation = StackOrientation.Vertical,
                //Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
                Children = { label6, page }
            };

            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {
                page.Spacing = 25;
                FileImageSource images = new FileImageSource();
                images.File = "options.png";
                baritem.Icon = images;
                return page4;
            }

            return page;
        }
        void buttonClicked(object sender, EventArgs e)
        {
            if (baritem.Text == "Options")
            {

                Content = GetOptionPage();

                baritem.Text = "Done";

            }
            else
            {
                baritem.Text = "Options";
                ApplyChanges();
                Content = this.TreeMap;

            }

        }

        void ApplyChanges()
        {
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
            {
                FileImageSource images = new FileImageSource();
                images.File = "options.png";
                baritem.Icon = images;
            }
            if (!(treeMapColorMapping is RangeColorMapping))
            {
                this.TreeMap.LegendSettings.ShowLegend = false;
            }
            else
            {
                this.TreeMap.LegendSettings.ShowLegend = true; ;
            }
            this.TreeMap.LayoutType = layoutType;
            this.TreeMap.LeafItemColorMapping = treeMapColorMapping;
            (this.TreeMap.Levels[0] as TreeMapFlatLevel).GroupPadding = groupPadding;
            this.TreeMap.Refresh();
        }

        void picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (picker1.SelectedIndex)
            {
                case 0:
                    {
                        layoutType = LayoutTypes.Squarified;

                        break;
                    }
                case 1:
                    {
                        layoutType = LayoutTypes.SliceAndDiceHorizontal;
                        break;
                    }
                case 2:
                    {
                        layoutType = LayoutTypes.SliceAndDiceVertical;
                        break;
                    }
                case 3:
                    {
                        layoutType = LayoutTypes.SliceAndDiceAuto;
                        break;
                    }

            }
            ApplyChanges();
        }
        void picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (picker2.SelectedIndex)
            {
                case 0:
                    {
                        treeMapColorMapping = rangeMapping;
                        break;
                    }
                case 1:
                    {
                        treeMapColorMapping = desaturationMapping;
                        break;
                    }
                case 2:
                    {
                        treeMapColorMapping = uniMapping;
                        break;
                    }
                case 3:
                    {
                        treeMapColorMapping = paletteMapping;
                        break;
                    }
            }
            ApplyChanges();
        }
        //protected override bool OnBackButtonPressed()
        //{
        //    Content = this.TreeMap;
        //    return base.OnBackButtonPressed();
        //}

    }
}

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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfTreeMap
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataLabel : SampleView
    {
        Label label;
        Picker picker;
        public DataLabel()
        {
            InitializeComponent();
            DrawOptionsPage();
            this.PropertyView = GetOptionPage();
        }

        private void DrawOptionsPage()
        {
            picker = new Picker();
            picker.Items.Add("Trim");
            picker.Items.Add("Wrap");
            picker.Items.Add("Hide");

            picker.HeightRequest = 40;
            picker.SelectedIndex = 0;
            picker.SelectedIndexChanged += picker1_SelectedIndexChanged;

            label = new Label()
            {
                Text = "Label OverflowMode",
                HeightRequest = 20,
                VerticalTextAlignment = TextAlignment.End,
            };

            if (Device.RuntimePlatform == Device.Android)
            {
                picker.BackgroundColor = Color.FromRgb(239, 239, 239);
                label.FontSize = 20;
            }
        }


        private StackLayout GetOptionPage()
        {
            var page = new StackLayout
            {
                Spacing = 10,
                Orientation = StackOrientation.Vertical,
                Padding = 10,
                Children = { label, picker }
            };
            return page;
        }

        void picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (picker.SelectedIndex)
            {
                case 0:
                    {
                        TreeMap.LeafItemSettings.OverflowMode = LabelOverflowMode.Trim;
                        break;
                    }
                case 1:
                    {
                        TreeMap.LeafItemSettings.OverflowMode = LabelOverflowMode.Wrap;
                        break;
                    }
                case 2:
                    {
                        TreeMap.LeafItemSettings.OverflowMode = LabelOverflowMode.Hide;
                        break;
                    }
            }
        }
    }
    public class PopulationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var label = (double)value / 1000000;
            string text = ((int)label).ToString() + "M";
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

}
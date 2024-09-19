#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.SfRangeSlider.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfRangeSlider
{
    public partial class RangeSlider_Default : SampleView
    {
        ObservableCollection<Syncfusion.SfRangeSlider.XForms.Items> customCollection { get; set; }
        public RangeSlider_Default()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.UWP)
            {
                layoutRoot.HorizontalOptions = LayoutOptions.Center;
                layoutRoot.WidthRequest = 500;
            }
            customCollection = new ObservableCollection<Syncfusion.SfRangeSlider.XForms.Items>();
            customCollection.Add(new Syncfusion.SfRangeSlider.XForms.Items() { Label = "Min", Value = 0});
            customCollection.Add(new Syncfusion.SfRangeSlider.XForms.Items() { Label = "Max",Value= 10 });
            rangeslider4.CustomLabels = customCollection;
            rangeslider5.ShowValueLabel = true;

            rangeslider5.LabelFormat = " {0:c}";
            rangeslider5.Culture = new System.Globalization.CultureInfo("en-US");
            if (App.Current.MainPage!= null && App.Current.MainPage.Visual == VisualMarker.Material)
            {
                this.SetMaterialValues(rangeslider1);
                this.SetMaterialValues(rangeslider2);
                this.SetMaterialValues(rangeslider3, true);
                this.SetMaterialValues(rangeslider4);
                this.SetMaterialValues(rangeslider5);
            }
        }
            
        public View getContent()
        {
            return this.Content;
        }

        /// <summary>
        /// Set the color values for material
        /// </summary>
        /// <param name="rangeSlider"></param>
        private void SetMaterialValues(Syncfusion.SfRangeSlider.XForms.SfRangeSlider rangeSlider, bool isTick = false)
        {
            if (Device.RuntimePlatform != Device.UWP)
            {
                rangeSlider.LabelColor = Color.FromRgba(0, 0, 0, 200);
                if (isTick)
                {
                    rangeSlider.TickPlacement = TickPlacement.Inline;
                }
            }
        }
    }
}



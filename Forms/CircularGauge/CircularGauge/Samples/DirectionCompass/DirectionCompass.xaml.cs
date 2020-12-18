#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfCircularGauge
{
	[Preserve(AllMembers = true)]
    public partial class DirectionCompass : SampleView
    {
		public DirectionCompass()
        {
            InitializeComponent();
            needlePointerColorPicker.SelectedIndex = 0;
            needlePointerColorPicker.SelectedIndexChanged += NeedlePointerColorPicker_SelectedIndexChanged;

            #region Conditions

            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                pointer1.Thickness = 50;
                pointer2.Thickness = 50;
                scale.LabelOffset = 0.81;
            }
          
            #endregion Conditions            
        }

        private void NeedlePointerColorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (needlePointerColorPicker.SelectedIndex)
            {
                case 0:
                    viewModel.NeedlePointerColor = Color.FromHex("#f03e3e");
                    break;

                case 1:
                    viewModel.NeedlePointerColor = Color.FromHex("#4472c4");
                    break;

                case 2:
                    viewModel.NeedlePointerColor = Color.FromHex("#ed7d31");
                    break;
            }
        }

        private void scale_LabelCreated(object sender, Syncfusion.SfGauge.XForms.LabelCreatedEventArgs args)
        {
            switch ((string)args.LabelContent)
            {

                case "0":
                    args.LabelContent = "N";
                    break;
                case "2":
                    args.LabelContent = "NE";
                    break;
                case "4":
                    args.LabelContent = "E";
                    break;
                case "6":
                    args.LabelContent = "SE";
                    break;
                case "8":
                    args.LabelContent = "S";
                    break;
                case "10":
                    args.LabelContent = "SW";
                    break;
                case "12":
                    args.LabelContent = "W";
                    break;
                case "14":
                    args.LabelContent = "NW";
                    break;
            }
        }
    }
}

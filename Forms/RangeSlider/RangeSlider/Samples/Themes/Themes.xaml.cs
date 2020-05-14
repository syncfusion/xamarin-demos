#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using SampleBrowser.Core;
using Syncfusion.SfRangeSlider.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfRangeSlider
{
    public partial class Themes : SampleView
    {
        public Themes()
        {
			InitializeComponent();
            RangeChangeEvent();
            if (App.Current.MainPage != null)
            {
                if (App.Current.MainPage.Visual == VisualMarker.Material)
                {
                    sfRangeSlider1.ToolTipTextColor = Color.White;
                    sfRangeSlider2.ToolTipTextColor = Color.White;
                    this.SetMaterialValues(sfRangeSlider1);
                    this.SetMaterialValues(sfRangeSlider2);
                }
            }
        }
        void toggleStateChanged(object sender, ToggledEventArgs e)
        {
            sfRangeSlider1.ShowValueLabel = e.Value;
            sfRangeSlider2.ShowValueLabel = e.Value;
        }
        void toggleStateChanged1(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                sfRangeSlider1.SnapsTo = SnapsTo.Ticks;
                sfRangeSlider2.SnapsTo = SnapsTo.Ticks;
            }
            else
            {
                sfRangeSlider1.SnapsTo = SnapsTo.None;
                sfRangeSlider2.SnapsTo = SnapsTo.None;
            }
        }

        void RangeChangeEvent()
        {
            sfRangeSlider1.RangeChanging += (object sender, RangeEventArgs e) =>
            {
                if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                {
                    if (Math.Round(e.Start) < 1)
                    {
                        if (Math.Round(e.End) == 12)
                            timeLabel3.Text = "12 AM - " + Math.Round(e.End) + " PM";
                        else
                            timeLabel3.Text = "12 AM - " + Math.Round(e.End) + " AM";
                    }
                    else
                    {
                        if (Math.Round(e.End) == 12)
                            timeLabel3.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " PM";
                        else
                            timeLabel3.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " AM";
                    }
                    if (Math.Round(e.Start) == Math.Round(e.End))
                    {
                        if (Math.Round(e.Start) < 1)
                            timeLabel3.Text = "12 AM";
                        else if (Math.Round(e.Start) == 12)
                            timeLabel3.Text = "12 PM";
                        else
                            timeLabel3.Text = Math.Round(e.Start) + " AM";
                    }
                }
                if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
                {
                    if (Math.Round(sfRangeSlider1.RangeStart) < 1)
                    {
                        if (Math.Round(sfRangeSlider1.RangeEnd) == 12)
                            timeLabel3.Text = "12 AM - " + Math.Round(sfRangeSlider1.RangeEnd) + " PM";
                        else
                            timeLabel3.Text = "12 AM - " + Math.Round(sfRangeSlider1.RangeEnd) + " AM";
                    }
                    else
                    {
                        if (Math.Round(sfRangeSlider1.RangeEnd) == 12)
                            timeLabel3.Text = Math.Round(sfRangeSlider1.RangeStart) + " AM - " + Math.Round(sfRangeSlider1.RangeEnd) + " PM";
                        else
                            timeLabel3.Text = Math.Round(sfRangeSlider1.RangeStart) + " AM - " + Math.Round(sfRangeSlider1.RangeEnd) + " AM";
                    }
                    if (Math.Round(sfRangeSlider1.RangeStart) == Math.Round(sfRangeSlider1.RangeEnd))
                    {
                        if (Math.Round(sfRangeSlider1.RangeStart) < 1)
                            timeLabel3.Text = "12 AM";
                        else if (Math.Round(sfRangeSlider1.RangeStart) == 12)
                            timeLabel3.Text = "12 PM";
                        else
                            timeLabel3.Text = Math.Round(sfRangeSlider1.RangeStart) + " AM";
                    }
                }
            };
            sfRangeSlider2.RangeChanging += (object sender, RangeEventArgs e) =>
            {
                if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                {
                    if (Math.Round(e.Start) < 1)
                    {
                        if (Math.Round(e.End) == 12)
                            timeLabel4.Text = "12 AM - " + Math.Round(e.End) + " PM";
                        else
                            timeLabel4.Text = "12 AM - " + Math.Round(e.End) + " AM";
                    }
                    else
                    {
                        if (Math.Round(e.End) == 12)
                            timeLabel4.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " PM";
                        else
                            timeLabel4.Text = Math.Round(e.Start) + " AM - " + Math.Round(e.End) + " AM";
                    }
                    if (Math.Round(e.Start) == Math.Round(e.End))
                    {
                        if (Math.Round(e.Start) < 1)
                            timeLabel4.Text = "12 AM";
                        else if (Math.Round(e.Start) == 12)
                            timeLabel4.Text = "12 PM";
                        else
                            timeLabel4.Text = Math.Round(e.Start) + " AM";
                    }
                }
                if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Phone)
                {
                    if (Math.Round(sfRangeSlider2.RangeStart) < 1)
                    {
                        if (Math.Round(sfRangeSlider2.RangeEnd) == 12)
                            timeLabel4.Text = "12 AM - " + Math.Round(sfRangeSlider2.RangeEnd) + " PM";
                        else
                            timeLabel4.Text = "12 AM - " + Math.Round(sfRangeSlider2.RangeEnd) + " AM";
                    }
                    else
                    {
                        if (Math.Round(sfRangeSlider2.RangeEnd) == 12)
                            timeLabel4.Text = Math.Round(sfRangeSlider2.RangeStart) + " AM - " + Math.Round(sfRangeSlider2.RangeEnd) + " PM";
                        else
                            timeLabel4.Text = Math.Round(sfRangeSlider2.RangeStart) + " AM - " + Math.Round(sfRangeSlider2.RangeEnd) + " AM";
                    }
                    if (Math.Round(sfRangeSlider2.RangeStart) == Math.Round(sfRangeSlider2.RangeEnd))
                    {
                        if (Math.Round(sfRangeSlider2.RangeStart) < 1)
                            timeLabel4.Text = "12 AM";
                        else if (Math.Round(sfRangeSlider2.RangeStart) == 12)
                            timeLabel4.Text = "12 PM";
                        else
                            timeLabel4.Text = Math.Round(sfRangeSlider2.RangeStart) + " AM";
                    }
                }
            };
        }

        /// <summary>
        /// Set the color values for material
        /// </summary>
        /// <param name="rangeSlider"></param>
        private void SetMaterialValues(Syncfusion.SfRangeSlider.XForms.SfRangeSlider rangeSlider)
        {
            if (Device.RuntimePlatform != Device.UWP)
            {
                rangeSlider.LabelColor = Color.FromRgba(0, 0, 0, 200);
                rangeSlider.TickPlacement = TickPlacement.Inline;
            }
        }
    }
}
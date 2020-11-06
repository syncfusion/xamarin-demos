#region Copyright Syncfusion Inc. 2001-2019.
// ------------------------------------------------------------------------------------
// <copyright file = "GettingStartedViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion

namespace SampleBrowser.SfGradientView
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Text;
    using Syncfusion.XForms.Buttons;
    using Syncfusion.XForms.Graphics;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]
    public class GettingStartedViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the background brush for gradient view.
        /// </summary>
        private SfGradientBrush backgroundGradient;

        /// <summary>
        /// Gets or sets the background brush for gradient view.
        /// </summary>
        public SfGradientBrush BackgroundGradient
        {
            get
            {
                return backgroundGradient;
            }
            set
            {
                backgroundGradient = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BackgroundGradient"));
                }
            }
        }

        /// <summary>
        /// Gets or sets the string to toggle between linear and radial gradient.
        /// </summary>
        public ObservableCollection<string> ToggleItems { get; set; }

        /// <summary>
        /// Gets or sets the linear gradient brushes.
        /// </summary>
        public ObservableCollection<SfLinearGradientBrush> LinearGradientBrushes { get; set; }

        /// <summary>
        /// Gets or sets the radial gradient brushes.
        /// </summary>
        public ObservableCollection<SfRadialGradientBrush> RadialGradientBrushes { get; set; }


        public GettingStartedViewModel()
        {
            LinearGradientBrushes = new ObservableCollection<SfLinearGradientBrush>();
            LinearGradientBrushes.Add(AddLinearGradient("#2DDD78", "#FFAB2B", 0, 1));
            LinearGradientBrushes.Add(AddLinearGradient("#08D1B6", "#E419FC", 0, 1));
            LinearGradientBrushes.Add(AddLinearGradient("#DD582D", "#FFAB2B", 0, 1));
            LinearGradientBrushes.Add(AddLinearGradient("#FC72CF", "#1B73FF", 0, 1));
            LinearGradientBrushes.Add(AddLinearGradient("#401AE8", "#CF21B4", 0, 1));
            LinearGradientBrushes.Add(AddLinearGradient("#2131C6", "#00D8B3", 0, 1));

            RadialGradientBrushes = new ObservableCollection<SfRadialGradientBrush>();
            RadialGradientBrushes.Add(AddRadialGradient("#2DDD78", "#FFAB2B", 0, 1));
            RadialGradientBrushes.Add(AddRadialGradient("#08D1B6", "#E419FC", 0, 1));
            RadialGradientBrushes.Add(AddRadialGradient("#DD582D", "#FFAB2B", 0, 1));
            RadialGradientBrushes.Add(AddRadialGradient("#FC72CF", "#1B73FF", 0, 1));
            RadialGradientBrushes.Add(AddRadialGradient("#401AE8", "#CF21B4", 0, 1));
            RadialGradientBrushes.Add(AddRadialGradient("#2131C6", "#00D8B3", 0, 1));

            BackgroundGradient = LinearGradientBrushes[0];

            ToggleItems = new ObservableCollection<string>();          
            ToggleItems.Add("LINEAR");
            ToggleItems.Add("RADIAL");
        }

        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Add the radial gradient brushes.
        /// </summary>
        /// <param name="color1">color1</param>
        /// <param name="color2">color2</param>
        /// <param name="offset1">offset1</param>
        /// <param name="offset2">offset2</param>
        /// <returns>radial gradient</returns>
        private SfRadialGradientBrush AddRadialGradient(string color1, string color2, double offset1, double offset2)
        {
            SfRadialGradientBrush gradient1 = new SfRadialGradientBrush();
            gradient1.Center = new Point(0.5, 0.5);
            gradient1.Radius = 0.7;
            gradient1.GradientStops.Add(new SfGradientStop() { Color = Color.FromHex(color1), Offset = offset1 });
            gradient1.GradientStops.Add(new SfGradientStop() { Color = Color.FromHex(color2), Offset = offset2 });
            return gradient1;
        }

        /// <summary>
        /// Add the linear gradient brushes.
        /// </summary>
        /// <param name="color1">color1</param>
        /// <param name="color2">color2</param>
        /// <param name="offset1">offset1</param>
        /// <param name="offset2">offset2</param>
        /// <returns>linear gradient</returns>
        private SfLinearGradientBrush AddLinearGradient(string color1, string color2, int offset1, int offset2)
        {
            SfLinearGradientBrush gradient1 = new SfLinearGradientBrush();
            gradient1.StartPoint = new Point(0.5, 0);
            gradient1.EndPoint = new Point(0.5, 1);
            gradient1.GradientStops.Add(new SfGradientStop() { Color = Color.FromHex(color1), Offset = offset1 });
            gradient1.GradientStops.Add(new SfGradientStop() { Color = Color.FromHex(color2), Offset = offset2 });
            return gradient1;
        }
    }
}

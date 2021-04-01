#region Copyright Syncfusion Inc. 2001-2021.
// ------------------------------------------------------------------------------------
// <copyright file = "Zooming.xaml.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// A sampleView that contains the Zooming sample.
    /// </summary>
    public partial class Zooming : SampleView
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Zooming class.
        /// </summary>
        public Zooming()
        {
            this.InitializeComponent();
            if (Device.RuntimePlatform == Device.UWP)
            {
                this.dataGrid.DefaultColumnWidth = 100;
            }
        }

        #endregion

        /// <summary>
        /// Raises when slider value changes.
        /// </summary>
        /// <param name="sender">Instance of slider.</param>
        /// <param name="e"><see cref="Xamarin.Forms.ValueChangedEventArgs"/> event argument.</param>
        private void OnMaximumZoomScale_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            if (this.maximumZoomScale.Value <= this.minimumZoomScale.Value)
            {
                this.minimumZoomScale.Value = this.maximumZoomScale.Value - 0.1;
            }

            if (this.maximumZoomScale.Value < this.dataGrid.GetZoomScale())
            {
                this.dataGrid.Zoom((float)this.maximumZoomScale.Value);
            }

            this.dataGrid.MaximumZoomScale = (float)this.maximumZoomScale.Value;
            this.maximumZoomScaleValue.Text = "MaximumZoomScale : " + (Math.Truncate(100 * this.maximumZoomScale.Value) / 100).ToString();
        }

        /// <summary>
        /// Raises when slider value changes.
        /// </summary>
        /// <param name="sender">Instance of slider.</param>
        /// <param name="e"><see cref="Xamarin.Forms.ValueChangedEventArgs"/> event argument.</param>
        private void OnMinimumZoomScale_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            if (this.minimumZoomScale.Value >= this.maximumZoomScale.Value)
            {
                this.maximumZoomScale.Value = this.minimumZoomScale.Value + 0.1;
            }

            if (this.minimumZoomScale.Value > this.dataGrid.GetZoomScale())
            {
                this.dataGrid.Zoom((float)this.minimumZoomScale.Value);
            }

            this.dataGrid.MinimumZoomScale = (float)this.minimumZoomScale.Value;
            this.minimumZoomScaleValue.Text = "MinimumZoomScale : " + (Math.Truncate(100 * this.minimumZoomScale.Value) / 100).ToString();
        }
    }
}

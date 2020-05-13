#region Copyright Syncfusion Inc. 2001-2019.
// ------------------------------------------------------------------------------------
// <copyright file = "GettingStarted.xaml.cs" company="Syncfusion.com">
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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.XForms.Buttons;
    using Syncfusion.XForms.Graphics;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public partial class GettingStarted : SampleView
    {
        /// <summary>
        /// Gets or sets the selected chip index.
        /// </summary>
        private int chipSelectedIndex = 0;

        /// <summary>
        /// Gets or sets the linear gradient start point.
        /// </summary>
        private Point startPoint = new Point(0.5, 0);

        /// <summary>
        /// Gets or sets the linear gradient end point.
        /// </summary>
        private Point endPoint = new Point(0.5, 1);

        /// <summary>
        /// Gets or sets the rotation angle.
        /// </summary>
        private int rotationAngle = 0;
        public GettingStarted()
        {
            InitializeComponent();
            gradientAngle.Text = "\xe702";

            if (Device.RuntimePlatform == Device.UWP)
            {
                toggleButton.VisibleSegmentsCount = 1;
            }
            else
            {
                toggleButton.VisibleSegmentsCount = 2;
            }
        }

        /// <summary>
        /// Gradient background changes based on selected chip.
        /// </summary>
        /// <param name="sender">chip</param>
        /// <param name="e">event arguments</param>
        private void Chip1_Clicked(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            var selectedChip = sender as SfChip;
            var viewModel = (chipControl.BindingContext as GettingStartedViewModel);
            for (int i = 0; i < chipControl.Items.Count; i++)
            {
                var chip = chipControl.Items[i];
                if (chip == selectedChip)
                {
                    chip.BorderColor = Color.White;
                    chip.BorderWidth = 2;
                    selectedIndex = i;
                }
                else
                {
                    chip.BorderColor = Color.Transparent;
                    chip.BorderWidth = 0;
                }
            }

            chipSelectedIndex = selectedIndex;

            if (toggleButton.SelectedIndex == 0)
            {
                SfLinearGradientBrush brush = viewModel.LinearGradientBrushes[chipSelectedIndex];
                brush.StartPoint = startPoint;
                brush.EndPoint = endPoint;
                viewModel.BackgroundGradient = brush;
            }
            else
            {
                viewModel.BackgroundGradient = viewModel.RadialGradientBrushes[chipSelectedIndex];
            }
        }

        /// <summary>
        /// Toggle between linear and radial gradient.
        /// </summary>
        /// <param name="sender">segmented control</param>
        /// <param name="e">event arguments</param>
        private void ToggleButton_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            var viewModel = (this.BindingContext as GettingStartedViewModel);
            var chip = chipControl;

            if (e.Index == 0)
            {
                gradientAngle.Text = "\xe702";
                SfLinearGradientBrush brush = viewModel.LinearGradientBrushes[chipSelectedIndex];
                brush.StartPoint = startPoint;
                brush.EndPoint = endPoint;
                viewModel.BackgroundGradient = brush;                
            }
            else
            {
                gradientAngle.Text = "\xe701";
                viewModel.BackgroundGradient = viewModel.RadialGradientBrushes[chipSelectedIndex];
                rotationAngle = 0;
                startPoint = new Point(0.5, 0);
                endPoint = new Point(0.5, 1);
            }
        }

        /// <summary>
        /// Change the gradient start and end point.
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">event arguments</param>
        private void GradientAngle_Clicked(object sender, EventArgs e)
        {
            var button = sender as SfButton;
            var linearGradient = (gradientView.BackgroundBrush as SfLinearGradientBrush);
            string fontText = string.Empty;

            if (linearGradient != null)
            {
                rotationAngle += 45;
                rotationAngle = rotationAngle > 315 ? 0 : rotationAngle;
            }
            else
            {
                fontText = (gradientAngle.Text == "\xe701") ? "\xe703" : "\xe701";
            }

            switch (rotationAngle)
            {
                case 0:
                    startPoint = new Point(0.5, 0);
                    endPoint = new Point(0.5, 1);
                    gradientAngle.Text = "\xe702";
                    break;
                case 45:
                    startPoint = new Point(1, 0);
                    endPoint = new Point(0, 1);
                    gradientAngle.Text = "\xe704";
                    break;
                case 90:
                    startPoint = new Point(1, 0.5);
                    endPoint = new Point(0, 0.5);
                    gradientAngle.Text = "\xe705";
                    break;
                case 135:
                    startPoint = new Point(1, 1);
                    endPoint = new Point(0, 0);
                    gradientAngle.Text = "\xe700";
                    break;
                case 180:
                    startPoint = new Point(0.5, 1);
                    endPoint = new Point(0.5, 0);
                    gradientAngle.Text = "\xe702";
                    break;
                case 225:
                    startPoint = new Point(0, 1);
                    endPoint = new Point(1, 0);
                    gradientAngle.Text = "\xe704";
                    break;
                case 270:
                    startPoint = new Point(0, 0.5);
                    endPoint = new Point(1, 0.5);
                    gradientAngle.Text = "\xe705";
                    break;
                case 315:
                    startPoint = new Point(0, 0);
                    endPoint = new Point(1, 1);
                    gradientAngle.Text = "\xe700";
                    break;
            }

            if (linearGradient != null)
            {
                linearGradient.StartPoint = startPoint;
                linearGradient.EndPoint = endPoint;
            }
            else
            {
                gradientAngle.Text = string.IsNullOrEmpty(fontText) ? "\xe701" : fontText;
                var color1 = gradientView.BackgroundBrush.GradientStops[0].Color;
                var color2 = gradientView.BackgroundBrush.GradientStops[1].Color;

                gradientView.BackgroundBrush.GradientStops[0].Color = color2;
                gradientView.BackgroundBrush.GradientStops[1].Color = color1;
            }
        }

        /// <summary>
        /// Modifies the row height based on orientation.
        /// </summary>
        /// <param name="sender">grid</param>
        /// <param name="e">event arguments</param>
        private void Grid_SizeChanged(object sender, EventArgs e)
        {
            var grid = sender as Grid;

            if (grid.Width > 0 && grid.Height > 0)
            {
                if (grid.Width > grid.Height)
                {
                    if (Device.Idiom == TargetIdiom.Phone)
                    {
                        grid.RowDefinitions[0].Height = new GridLength(2, GridUnitType.Star);
                        grid.RowDefinitions[1].Height = new GridLength(2, GridUnitType.Star);
                    }
                    else
                    {
                        grid.RowDefinitions[0].Height = new GridLength(3, GridUnitType.Star);
                        grid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
                    }
                }
                else
                {
                    grid.RowDefinitions[0].Height = new GridLength(3, GridUnitType.Star);
                    grid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
                }
            }
        }
    }
}
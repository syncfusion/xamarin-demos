#region Copyright Syncfusion Inc. 2001-2019.
// ------------------------------------------------------------------------------------
// <copyright file = "BadgeCustomization.xaml.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfBadgeView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.XForms.BadgeView;
    using Syncfusion.XForms.Buttons;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Badge Customization class.
    /// </summary>
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]     
    public partial class BadgeCustomization : SampleView
    {
        private bool isUpdate = false;
        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeCustomization" /> class.
        /// </summary>
        public BadgeCustomization()
        {
            this.InitializeComponent();
            if (Device.RuntimePlatform == Device.UWP)
            {
                this.textBadgeIcon.IsVisible = false;
                this.textBadgeType.IsVisible = false;
                this.textBadgeIconGrid.IsVisible = true;
                this.textBadgeTypeGrid.IsVisible = true;

                this.badgeTypePicker.SelectedIndex = 6;
                this.badgeIconPicker.SelectedIndex = 3;
            }
            this.badgeIcon.SelectedIndex = 3;
            this.badgeType.SelectedIndex = 6;
            this.TextColorSegment.ItemsSource = viewModel.PrimaryColors;
            
            isUpdate = true;
            DynamicUpdate();
        }

        void Handle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as Syncfusion.XForms.Buttons.SfSegmentedControl) == TextColorSegment)
            {
                viewModel.BackgroundColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
                this.TextColorSegment.SelectionTextColor = viewModel.PrimaryColors[e.Index].FontIconFontColor;
            }
        }

        /// <summary>
        /// Dynamic update for badge text animation 
        /// </summary>
        private async void DynamicUpdate()
        {
            double badgeText = 10;
            while (isUpdate && this.badge1 != null)
            {
                badgeText += 1;
                this.badge1.BadgeText = badgeText.ToString();
                await Task.Delay(2000);
            }
        }
        public override void OnDisappearing()
        {
            base.OnDisappearing();
            isUpdate = false;
        }

        /// <summary>
        /// This method is called when picker collection changed
        /// </summary>
        /// <param name="sender">Gets the sender</param>
        /// <param name="e">Gets the event args</param>
        private void Picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.badge != null && this.badge.BadgeSettings != null)
            {                
                var picker = sender as Picker;
                switch (picker.SelectedIndex)
                {
                    case 0:
                        {
                            viewModel.BadgeIcon = BadgeIcon.None;
                        }
                        break;
                    case 1:
                        {
                            viewModel.BadgeIcon = BadgeIcon.Busy;
                            this.badge2.BadgeSettings.BadgeType = BadgeType.Error;
                        }
                        break;
                    case 2:
                        {
                            viewModel.BadgeIcon = BadgeIcon.Add;
                            this.badge2.BadgeSettings.BadgeType = BadgeType.Success;
                        }
                        break;
                    case 3:
                        {
                            viewModel.BadgeIcon = BadgeIcon.Available;
                            this.badge2.BadgeSettings.BadgeType = BadgeType.Success;
                        }
                        break;
                    case 4:
                        {
                            viewModel.BadgeIcon = BadgeIcon.Prohibit1;
                            this.badge2.BadgeSettings.BadgeType = BadgeType.Error;
                        }
                        break;
                    case 5:
                        {
                            viewModel.BadgeIcon = BadgeIcon.Prohibit2;
                            this.badge2.BadgeSettings.BadgeType = BadgeType.Error;
                        }
                        break;
                    case 6:
                        {
                            viewModel.BadgeIcon = BadgeIcon.Away;
                            this.badge2.BadgeSettings.BadgeType = BadgeType.Warning;
                        }
                        break;
                    case 7:
                        {
                            viewModel.BadgeIcon = BadgeIcon.Delete;
                            this.badge2.BadgeSettings.BadgeType = BadgeType.Error;
                        }
                        break;
                    case 8:
                        {
                            viewModel.BadgeIcon = BadgeIcon.Dot;
                            this.badge2.BadgeSettings.BadgeType = BadgeType.Error;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// This method is called when picker selection changed
        /// </summary>
        /// <param name="sender">Gets the sender </param>
        /// <param name="e">Gets the eventArgs</param>
        private void Picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.badge != null && this.badge.BadgeSettings != null)
            {
                var picker = sender as Picker;
                TextColorSegment.IsEnabled = false;
                switch (picker.SelectedIndex)
                {
                    case 0:
                        viewModel.BadgeType = BadgeType.Primary;
                        TextColorSegment.Opacity = 0.3;
                        break;
                    case 1:
                        viewModel.BadgeType = BadgeType.Secondary;
                        TextColorSegment.Opacity = 0.3;
                        break;
                    case 2:
                        viewModel.BadgeType = BadgeType.Light;
                        TextColorSegment.Opacity = 0.3;
                        break;
                    case 3:
                        viewModel.BadgeType = BadgeType.Dark;
                        TextColorSegment.Opacity = 0.3;
                        break;
                    case 4:
                        viewModel.BadgeType = BadgeType.Success;
                        TextColorSegment.Opacity = 0.3;
                        break;
                    case 5:
                        viewModel.BadgeType = BadgeType.Warning;
                        break;
                    case 6:
                        viewModel.BadgeType = BadgeType.Error;
                        TextColorSegment.Opacity = 0.3;
                        break;
                    case 7:
                        viewModel.BadgeType = BadgeType.Info;
                        TextColorSegment.Opacity = 0.3;
                        break;
                    case 8:
                        {
                            viewModel.BadgeType = BadgeType.None;
                            TextColorSegment.IsEnabled = true;
                            TextColorSegment.Opacity = 1;
                        }                        
                        break;
                }
            }
        }
    }
}
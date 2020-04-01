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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfSwitch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisualType : SampleView
    {
        public VisualType()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
            {
                scrollView.InputTransparent = true;
            }
            if (Device.RuntimePlatform == Device.iOS)
            {
                mainStack.WidthRequest = 500;
            }
        }

        bool setState = false;

        private void SfSwitch_StateChanged(object sender, SwitchStateChangedEventArgs e)
        {

            this.OnStateLabel.Text = GetLabel(this.OnStateSwitch.IsOn);
            setStates(true, this.OnStateSwitch.IsOn);
        }

        private void SfSwitch_StateChanged_1(object sender, SwitchStateChangedEventArgs e)
        {

            this.IndeterminateStateLabel.Text = GetLabel(this.IndeterminateStateSwitch.IsOn);
            setStates(null, this.IndeterminateStateSwitch.IsOn);
        }

        private void SfSwitch_StateChanged_2(object sender, SwitchStateChangedEventArgs e)
        {

            this.OffStateLabel.Text = GetLabel(this.OffStateSwitch.IsOn);
            setStates(false, this.OffStateSwitch.IsOn);
        }

        private string GetLabel(bool? value)
        {
            if (value == true)
                return "On";
            else if (value == false)
                return "Off";
            else
                return "Indeterminate";
        }

        private async void setStates(bool? value, bool? state)
        {
            if (setState)
                return;
            setState = true;

            if (value == true)
            {
                if (state == true)
                {
                    this.IndeterminateStateSwitch.IsOn = null;
                    this.OffStateSwitch.IsOn = false;
                }
                else if (state == false)
                {
                    this.IndeterminateStateSwitch.IsOn = null;
                    this.OffStateSwitch.IsOn = true;
                }
                else
                {
                    this.IndeterminateStateSwitch.IsOn = false;
                    this.OffStateSwitch.IsOn = true;
                }

            }
            else if (value == false)
            {
                if (state == true)
                {
                    this.IndeterminateStateSwitch.IsOn = null;
                    this.OnStateSwitch.IsOn = false;
                }
                else if (state == false)
                {
                    this.IndeterminateStateSwitch.IsOn = null;
                    this.OnStateSwitch.IsOn = true;
                }
                else
                {
                    this.IndeterminateStateSwitch.IsOn = false;
                    this.OnStateSwitch.IsOn = true;
                }
            }
            else
            {
                if (state == true)
                {
                    this.OnStateSwitch.IsOn = null;
                    this.OffStateSwitch.IsOn = false;
                }
                else if (state == false)
                {
                    this.OnStateSwitch.IsOn = true;
                    this.OffStateSwitch.IsOn = null;
                }
                else
                {
                    this.OnStateSwitch.IsOn = true;
                    this.OffStateSwitch.IsOn = false;
                }
            }

            await Task.Delay(500);
            setState = false;
        }

        private void SfSwitch_StateChanged_3(object sender, SwitchStateChangedEventArgs e)
        {
            if (this.ModeSwitch.IsOn == true)
                this.ModeLabel.Text = "Night mode";
            else
                this.ModeLabel.Text = "Day mode";
        }

        bool isOn = true;

        private async void SfSwitch_StateChanging(object sender, SwitchStateChangingEventArgs e)
        {

            this.busySwitch1.IsBusy = true;
            await Task.Delay(2000);
            this.busySwitch1.IsOn = isOn;
            this.busySwitch1.IsBusy = false;
            isOn = !isOn;
        }

        private async void SfSwitch_StateChanging_1(object sender, SwitchStateChangingEventArgs e)
        {
            this.busySwitch2.IsBusy = true;
            await Task.Delay(2000);
            this.busySwitch2.IsOn = false;
            this.busySwitch2.IsBusy = false;
        }
    }
}
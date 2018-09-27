#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfPopupLayout
{
    public class FooterTemplateBehavior : Behavior<StackLayout>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("PopupObject", typeof(object), typeof(TimingButtonBehavior), null);

        public object PopupObject
        {
            get { return (object)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        private Button declineButton;

        private Button acceptButton;

        protected override void OnAttachedTo(StackLayout bindable)
        {
            base.OnAttachedTo(bindable);
            declineButton = bindable.FindByName<Button>("declineButton");
            acceptButton = bindable.FindByName<Button>("acceptButton");
            acceptButton.Clicked += AcceptButton_Clicked;
            declineButton.Clicked += DeclineButton_Clicked;
        }

        private void DeclineButton_Clicked(object sender, EventArgs e)
        {
            if(PopupObject != null)
            {
                (PopupObject as Syncfusion.XForms.PopupLayout.SfPopupLayout).Dismiss();
            }
        }

        private async void AcceptButton_Clicked(object sender, EventArgs e)
        {
            if (PopupObject != null)
            {
                (PopupObject as Syncfusion.XForms.PopupLayout.SfPopupLayout).PopupView.AnimationMode = AnimationMode.None;
                (PopupObject as Syncfusion.XForms.PopupLayout.SfPopupLayout).Dismiss();
            }
            Syncfusion.XForms.PopupLayout.SfPopupLayout popup = (new SeatSelectionPage()).Content as Syncfusion.XForms.PopupLayout.SfPopupLayout;
            popup.PopupView.AnimationMode = AnimationMode.None;
            await Task.Delay(200);
            popup.Show();
        }        

        protected override void OnDetachingFrom(StackLayout bindable)
        {
            base.OnDetachingFrom(bindable);
            acceptButton.Clicked -= AcceptButton_Clicked;
            declineButton.Clicked -= DeclineButton_Clicked;
        }
    }
}

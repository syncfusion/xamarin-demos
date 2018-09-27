#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Globalization;

namespace SampleBrowser.SfPopupLayout
{
    public class TheaterInfoBehavior : Behavior<ContentView>
    {        
        protected override void OnAttachedTo(ContentView bindable)
        {
            base.OnAttachedTo(bindable);
            AddTapGeture(bindable);
        }

        private void AddTapGeture(ContentView infoButton)
        {
            var tapGesture = new TapGestureRecognizer();
            (infoButton as ContentView).GestureRecognizers.Add(tapGesture);
            tapGesture.Tapped += InfoButton_Tapped;
        }

        private void InfoButton_Tapped(object sender, EventArgs e)
        {
            Syncfusion.XForms.PopupLayout.SfPopupLayout popupLayout;
            popupLayout = (new InformationPage()).Content as Syncfusion.XForms.PopupLayout.SfPopupLayout;
            popupLayout.PopupView.HeaderTitle = ((((sender as ContentView).Parent as StackLayout).Children[0] as StackLayout).Children[0] as Label).Text;
            popupLayout.Show();
        }

        protected override void OnDetachingFrom(ContentView bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }

    public class TimingButtonBehavior : Behavior<Button>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("DataGridObject", typeof(object), typeof(TimingButtonBehavior), null);

        public object DataGridObject
        {
            get { return (object)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public Button TimeButton { get; private set; }

        protected override void OnAttachedTo(Button bindable)
        {
            base.OnAttachedTo(bindable);
            TimeButton = bindable;
            TimeButton.Clicked += TimeButton_Clicked;
        }

        private void TimeButton_Clicked(object sender, EventArgs e)
        {
            Syncfusion.XForms.PopupLayout.SfPopupLayout popupLayout;
            if (DataGridObject != null)
            {
                popupLayout = (new TermsAndConditionContent()).Content as Syncfusion.XForms.PopupLayout.SfPopupLayout;
                popupLayout.Show();
            }
        }

        protected override void OnDetachingFrom(Button bindable)
        {
            base.OnDetachingFrom(bindable);
            TimeButton.Clicked -= TimeButton_Clicked;
            TimeButton = null;
            DataGridObject = null;
        }
    }

    public class CustomConverter : IValueConverter
    {
        public CustomConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if ((value as TicketBookingInfo).Timing2 == null)
                {

                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class SeatSelectionBehavior : Behavior<Label>
    {
        public Label seatCountLabel { get; private set; }

        protected override void OnAttachedTo(Label bindable)
        {
            base.OnAttachedTo(bindable);
            seatCountLabel = bindable;
            AddTapGeture();
        }

        private void AddTapGeture()
        {
            var seatCountTapGesture = new TapGestureRecognizer();
            seatCountLabel.GestureRecognizers.Add(seatCountTapGesture);
            seatCountTapGesture.Tapped += seatCountLabel_Tapped;
        }

        private void seatCountLabel_Tapped(object sender, EventArgs e)
        {
            var label = sender as Label;

            foreach (var children in (label.Parent as StackLayout).Children)
            {
                children.BackgroundColor = Color.White;
                (children as Label).TextColor = Color.Black;
            }

            label.BackgroundColor = Color.FromHex("#007CEE");
            label.TextColor = Color.White;
        }

        protected override void OnDetachingFrom(Label bindable)
        {
            base.OnDetachingFrom(bindable);
            seatCountLabel = null;
        }
    }

    public class ProceedButtonBehavior : Behavior<Button>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("PopupObject", typeof(object), typeof(TimingButtonBehavior), null);

        public object PopupObject
        {
            get { return (object)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public Button ProceedButton { get; private set; }

        protected override void OnAttachedTo(Button bindable)
        {
            base.OnAttachedTo(bindable);
            ProceedButton = bindable;
            ProceedButton.Clicked += ProceedButton_Clicked;
        }

        private async void ProceedButton_Clicked(object sender, EventArgs e)
        {
            if (PopupObject != null)
            {
                (PopupObject as Syncfusion.XForms.PopupLayout.SfPopupLayout).Dismiss();
            }
            await Task.Delay(200);
            (new FinalPopup().Content as Syncfusion.XForms.PopupLayout.SfPopupLayout).Show();
        }

        protected override void OnDetachingFrom(Button bindable)
        {
            base.OnDetachingFrom(bindable);
            ProceedButton.Clicked -= ProceedButton_Clicked;
            ProceedButton = null;
            PopupObject = null;
        }
    }
}

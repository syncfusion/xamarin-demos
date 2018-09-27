#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    internal class CustomViewBehavior : Behavior<Syncfusion.SfSchedule.XForms.SfSchedule>
    {
        private Syncfusion.SfSchedule.XForms.SfSchedule AssociatedObject { get; set; }
        protected override void OnAttachedTo(Syncfusion.SfSchedule.XForms.SfSchedule bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            bindable.VisibleDatesChangedEvent += BindableVisibleDatesChangedEvent;
            bindable.OnMonthInlineAppointmentLoadedEvent += BindableOnMonthInlineAppointmentLoadedEvent;
            if (Device.RuntimePlatform == "iOS")
                bindable.MonthViewSettings.TodayBackground = Color.Transparent;
        }

        private void BindableOnMonthInlineAppointmentLoadedEvent(object sender, MonthInlineAppointmentLoadedEventArgs e)
        {

            Button button = new Button();
            button.TextColor = Color.White;
            button.VerticalOptions = LayoutOptions.FillAndExpand;
            button.HorizontalOptions = LayoutOptions.FillAndExpand;

            if (Device.RuntimePlatform == "UWP")
            {
                button.WidthRequest = 250;
                button.HeightRequest = 50;
            }

            if ((e.appointment as ScheduleAppointment).Subject == "Conference")
            {
                button.BackgroundColor = (Color.FromHex("#FFD80073"));
                button.Text = "Conference";
                button.Image = ImagePathConverter.GetImageSource("SampleBrowser.SfSchedule.conference_schedule.png");
            }
            else if ((e.appointment as ScheduleAppointment).Subject == "Checkup")
            {
                button.BackgroundColor = Color.FromHex("#FFA2C139");
                button.Text = "Checkup";
                button.Image = ImagePathConverter.GetImageSource("SampleBrowser.SfSchedule.stethoscope_schedule.png");
            }
            if (!(e.appointment as ScheduleAppointment).IsAllDay)
                e.view = button;
        }

        protected override void OnDetachingFrom(Syncfusion.SfSchedule.XForms.SfSchedule bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.VisibleDatesChangedEvent -= BindableVisibleDatesChangedEvent;
            bindable.OnMonthInlineAppointmentLoadedEvent -= BindableOnMonthInlineAppointmentLoadedEvent;
            AssociatedObject = null;
        }

        private void BindableVisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
        {
            var viewModel = (this.AssociatedObject.BindingContext as CustomizationViewModel);

            if(AssociatedObject.ScheduleView == ScheduleView.MonthView)
            {
                var midDate = e.visibleDates[e.visibleDates.Count / 2].ToString("MMMM yyyy");
                viewModel.HeaderLabelValue = midDate;
            }
            else
                viewModel.HeaderLabelValue = e.visibleDates[0].Date.ToString("MMMM yyyy");

        }
    }
}
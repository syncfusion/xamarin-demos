#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Custom View Behavior class
    /// </summary>
    internal class CustomViewBehavior : Behavior<Syncfusion.SfSchedule.XForms.SfSchedule>
    {
        /// <summary>
        /// Gets or sets associated object
        /// </summary>
        private Syncfusion.SfSchedule.XForms.SfSchedule AssociatedObject { get; set; }

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnAttachedTo(Syncfusion.SfSchedule.XForms.SfSchedule bindable)
        {
            base.OnAttachedTo(bindable);
            this.AssociatedObject = bindable;
            bindable.VisibleDatesChangedEvent += this.BindableVisibleDatesChangedEvent;
            bindable.OnMonthInlineAppointmentLoadedEvent += this.BindableOnMonthInlineAppointmentLoadedEvent;
            if (Device.RuntimePlatform == "iOS")
            {
                bindable.MonthViewSettings.TodayBackground = Color.Transparent;
            }
        }

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnDetachingFrom(Syncfusion.SfSchedule.XForms.SfSchedule bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.VisibleDatesChangedEvent -= this.BindableVisibleDatesChangedEvent;
            bindable.OnMonthInlineAppointmentLoadedEvent -= this.BindableOnMonthInlineAppointmentLoadedEvent;
            this.AssociatedObject = null;
        }

        /// <summary>
        /// Month inline appointment loaded event
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Month Inline Appointment Loaded Event Args</param>
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
                button.BackgroundColor = Color.FromHex("#FFD80073");
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
            {
                e.view = button;
            }
        }

        /// <summary>
        /// Visible dates changed event
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">VisibleDates Changed Event Args</param>
        private void BindableVisibleDatesChangedEvent(object sender, VisibleDatesChangedEventArgs e)
        {
            var viewModel = this.AssociatedObject.BindingContext as CustomizationViewModel;

            if (this.AssociatedObject.ScheduleView == ScheduleView.MonthView)
            {
                var midDate = e.visibleDates[e.visibleDates.Count / 2].ToString("MMMM yyyy");
                viewModel.HeaderLabelValue = midDate;
            }
            else
            {
                viewModel.HeaderLabelValue = e.visibleDates[0].Date.ToString("MMMM yyyy");
            }
        }
    }
}
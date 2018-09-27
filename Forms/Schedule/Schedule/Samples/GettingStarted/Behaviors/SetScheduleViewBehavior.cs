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
using Xamarin.Forms;
using System.Globalization;

namespace SampleBrowser.SfSchedule
{
    internal class SetScheduleViewBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule;
        private LocalizationViewModel localizationViewModel;
        private Picker viewPicker;
        private Picker localePicker;

        protected override void OnAttachedTo(SampleView bindable)
        {
            if (bindable == null)
            {
                return;
            }

            base.OnAttachedTo(bindable);

            schedule = bindable.Content.FindByName<Syncfusion.SfSchedule.XForms.SfSchedule>("Schedule");
   
            if (schedule?.Locale == "ja")
            {
                localizationViewModel = new LocalizationViewModel();
                localePicker = bindable.PropertyView.FindByName<Picker>("localePicker");
                if (localePicker == null)
                {
                    return;
                }
                localePicker.SelectedIndex = 0;
                localePicker.SelectedIndexChanged += LocalePicker_SelectedIndexChanged;
                schedule.DataSource = localizationViewModel.JapaneseAppointments;
            }


            viewPicker = bindable.PropertyView.FindByName<Picker>("viewPicker");

            if (viewPicker == null)
            {
                return;
            }

            if (bindable.GetType().Equals(typeof(RecursiveAppointments)))
                viewPicker.SelectedIndex = 3;
            else if (bindable.GetType().Equals(typeof(ViewCustomization)))
                viewPicker.SelectedIndex = 3;
            else if (bindable.GetType().Equals(typeof(Localization)))
                viewPicker.SelectedIndex = 1;
            else
                viewPicker.SelectedIndex = 2;

            viewPicker.SelectedIndexChanged += ViewPicker_SelectedIndexChanged;
        }

        private void ViewPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    schedule.ScheduleView = ScheduleView.DayView;
                    break;
                case 1:
                    schedule.ScheduleView = ScheduleView.WeekView;
                    break;
                case 2:
                    schedule.ScheduleView = ScheduleView.WorkWeekView;
                    break;
                case 3:
                    schedule.ScheduleView = ScheduleView.MonthView;
                    break;
            }
        }

        private void LocalePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    schedule.Locale = "ja";
                    schedule.DataSource = localizationViewModel.JapaneseAppointments;
                    break;
                case 1:
                    schedule.Locale = "en";
                    schedule.DataSource = localizationViewModel.EnglishAppointments;
                    break;
                case 2:
                    schedule.Locale = "fr";
                    schedule.DataSource = localizationViewModel.FrenchAppointments;
                    break;
                case 3:
                    schedule.Locale = "es";
                    schedule.DataSource = localizationViewModel.SpanishAppointments;
                    break;
            }
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);

            if (viewPicker != null)
            {
                viewPicker.SelectedIndexChanged -= ViewPicker_SelectedIndexChanged;
                viewPicker = null;
            }

            if (localePicker != null)
            {
                localePicker.SelectedIndexChanged -= LocalePicker_SelectedIndexChanged;
                localePicker = null;
            }

            if (schedule != null)
            {
                schedule = null;
            }
        }
    }
}

#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using SampleBrowser.Core;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfCalendar
{
    internal class WeekViewBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfCalendar.XForms.SfCalendar calendar;

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.SizeChanged += Bindable_SizeChanged;
           
            this.calendar = bindable.Content.FindByName<Syncfusion.SfCalendar.XForms.SfCalendar>("calendar");
            this.calendar.InlineViewMode = InlineViewMode.Agenda;
            this.calendar.MonthViewSettings.SelectionShape = SelectionShape.Circle;
            this.calendar.NumberOfWeeksInView = 1;
        }

        private void Bindable_SizeChanged(object sender, EventArgs e)
        {
            var height = (sender as SampleView).Content.Height;
            var width = (sender as SampleView).Content.Width;

            if (height > width)
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        if (Device.Idiom == TargetIdiom.Phone)
                        {
                            this.calendar.AgendaViewHeight = height * 0.75;
                        }
                        else
                        {
                            this.calendar.AgendaViewHeight = height * 0.8;
                        }
                        break;
                    case Device.Android:
                        if (Device.Idiom == TargetIdiom.Phone)
                        {
                            this.calendar.AgendaViewHeight = height * 0.95;
                        }
                        else
                        {
                            this.calendar.AgendaViewHeight = height * 0.35;
                        }
                        break;
                    case Device.UWP:
                        this.calendar.AgendaViewHeight = height * 0.75;
                        break;
                }
            }
            else
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        if (Device.Idiom == TargetIdiom.Phone)
                        {
                            this.calendar.AgendaViewHeight = height * 0.5;
                        }
                        else
                        {
                            this.calendar.AgendaViewHeight = width * 0.5;
                        }
                        break;
                    case Device.Android:
                        if (Device.Idiom == TargetIdiom.Phone)
                        {
                            this.calendar.AgendaViewHeight = height * 0.6;
                        }
                        else
                        {
                            this.calendar.AgendaViewHeight = height * 0.25;
                        }
                        break;
                    case Device.UWP:
                            this.calendar.AgendaViewHeight = height * 0.75;
                        break;
                }
            }
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            calendar = null;
        }
    }
}


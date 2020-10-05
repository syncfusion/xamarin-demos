#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
            this.AssociatedObject = null;
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
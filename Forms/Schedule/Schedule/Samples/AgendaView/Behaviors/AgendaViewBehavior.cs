#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// AgendaView Behavior class.
    /// </summary>
    internal class AgendaViewBehavior : Behavior<SampleView>
    {
        /// <summary>
        /// Gets or Sets schedule instance.
        /// </summary>
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule;

        /// <summary>
        /// Begins when the behavior attached to the view. 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.SizeChanged += Bindable_SizeChanged;
            this.schedule = bindable.Content.FindByName<Syncfusion.SfSchedule.XForms.SfSchedule>("schedule");
        }
        
        /// <summary>
        /// Begins when the behavior attached to the view. 
        /// </summary>
        /// <param name="bindable">bindable value</param>
        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.SizeChanged -= Bindable_SizeChanged;
            this.schedule = null;
        }

        /// <summary>
        /// Method to set the agenda view height
        /// </summary>
        /// <param name="sender">return the object</param>
        /// <param name="e">Event Args</param>
        private void Bindable_SizeChanged(object sender, EventArgs e)
        {
            var height = (sender as SampleView).Content.Height;
            if (Device.RuntimePlatform == "Android")
            {
                this.schedule.MonthViewSettings.AgendaViewHeight = height * 0.6;
            }
            else
            {
                this.schedule.MonthViewSettings.AgendaViewHeight = height * 0.35;
            }

        }
    }
}

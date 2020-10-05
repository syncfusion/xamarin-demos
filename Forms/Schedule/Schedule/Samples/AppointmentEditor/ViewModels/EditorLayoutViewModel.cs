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

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Editor Layout View Model class
    /// </summary>
    internal class EditorLayoutViewModel
    {
        /// <summary>
        /// method for appointment modified
        /// </summary>
        /// <param name="e">Schedule Appointment Modified Event Args</param>
        public virtual void OnAppointmentModified(ScheduleAppointmentModifiedEventArgs e)
        {
            EventHandler<ScheduleAppointmentModifiedEventArgs> handler = this.AppointmentModified;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Event handler
        /// </summary>
        public event EventHandler<ScheduleAppointmentModifiedEventArgs> AppointmentModified;
    }

    /// <summary>
    /// schedule appointment modified event args
    /// </summary>
    public class ScheduleAppointmentModifiedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets appointment
        /// </summary>
        public Meeting Appointment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets is modified value
        /// </summary>
        public bool IsModified
        {
            get;
            set;
        }
    }
}

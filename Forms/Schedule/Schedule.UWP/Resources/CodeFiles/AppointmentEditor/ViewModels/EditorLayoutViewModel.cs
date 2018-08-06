#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
    internal class EditorLayoutViewModel
    {
        public virtual void OnAppointmentModified(ScheduleAppointmentModifiedEventArgs e)
        {
            EventHandler<ScheduleAppointmentModifiedEventArgs> handler = AppointmentModified;
            if (handler != null)
            {
                handler(this, e);
            }

        }
        public event EventHandler<ScheduleAppointmentModifiedEventArgs> AppointmentModified;
    }

    public class ScheduleAppointmentModifiedEventArgs : EventArgs
    {
        public Meeting Appointment { get; set; }
        public bool IsModified { get; set; }
    }
}

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
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Appointment Editor class
    /// </summary>
    [Preserve(AllMembers = true)]
    public partial class AppointmentEditor : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentEditor" /> class.
        /// </summary>
        public AppointmentEditor()
        {
            this.InitializeComponent();
            new ImagePathConverter();
        }
    }
}
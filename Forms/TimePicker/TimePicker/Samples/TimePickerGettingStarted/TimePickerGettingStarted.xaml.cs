#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfTimePicker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimePickerGettingStarted : SampleView
    {
        /// <summary>
        /// Time Picker GettingStarted
        /// </summary>
        public TimePickerGettingStarted()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ListView Swipe Ended event
        /// </summary>
        /// <param name="sender">sender value</param>
        /// <param name="e">Event args</param>
        private void ListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            if (e.SwipeDirection == Syncfusion.ListView.XForms.SwipeDirection.Right)
            {
                e.SwipeOffset = sfListView.Width;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Task.Delay(500);
                    viewModel.Alarms.RemoveAt(e.ItemIndex);
                });
            }
        }
    }
}


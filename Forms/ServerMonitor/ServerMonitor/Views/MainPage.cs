#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ServerMonitor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ServerMonitor
{
    # region MainPage

    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            this.Title = "Server Monitor";
            this.Children.Add(new LiveView
            {
                Title = "SyncServer",
                Icon="Name.png"
            });
            this.Children.Add(new CPUView
            {
                Title = "CPU",
                Icon="CPU.png"
            });
            this.Children.Add(new MemoryView
            {
                Title = "Memory",
                Icon = "Memory.png"
            });
            this.Children.Add(new NetworkView
            {
                Title = "Data",
                Icon = "Data.png"
            });
        }
    }

    #endregion

}

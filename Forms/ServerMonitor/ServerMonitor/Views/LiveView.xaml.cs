#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
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
using Xamarin.Forms;

namespace ServerMonitor.Views
{
    # region LiveView

    public partial class LiveView
    {
        public LiveView()
        {
            InitializeComponent();
            this.Performace.Font = this.Usage.Font = this.Used.Font = this.Download.Font= Device.OnPlatform(iOS: Font.BoldSystemFontOfSize(35), Android: Font.BoldSystemFontOfSize(45), WinPhone: Font.BoldSystemFontOfSize(60));
            this.DiskLayout.Padding = this.MemoryLayout.Padding = this.CPULayout.Padding = Device.OnPlatform(iOS: new Thickness(10, 10, 10, 10), Android: new Thickness(25, 10, 0, 10), WinPhone: new Thickness(10, 10, 10, 10));
            Device.StartTimer(new TimeSpan(0, 0, 1), AddData);
        }

        private bool AddData()
        {
            this.Performace.Text = DataGenerator.CPUUnits.ToString() + " %";
            this.Usage.Text = DataGenerator.MemoryUnits.ToString() + " %";
            this.Used.Text = DataGenerator.UsedSpace.ToString() + " %";
            this.Download.Text = DataGenerator.DownLoadRate.ToString();
            return true;
        }
    }

    #endregion
}

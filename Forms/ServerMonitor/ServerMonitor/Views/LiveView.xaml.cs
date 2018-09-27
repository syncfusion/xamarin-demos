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

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    this.Performace.FontSize = this.Usage.FontSize = this.Used.FontSize = this.Download.FontSize = 35;
                    this.DiskLayout.Padding = this.MemoryLayout.Padding = this.CPULayout.Padding = new Thickness(10);
                    break;
                case Device.Android:
                    this.Performace.FontSize = this.Usage.FontSize = this.Used.FontSize = this.Download.FontSize = 45;
                    this.DiskLayout.Padding = this.MemoryLayout.Padding = this.CPULayout.Padding = new Thickness(25, 10, 0, 10);

                    break;
                case Device.UWP:
                    this.Performace.FontSize = this.Usage.FontSize = this.Used.FontSize = this.Download.FontSize = 60;
                    this.DiskLayout.Padding = this.MemoryLayout.Padding = this.CPULayout.Padding = new Thickness(10);
                    break;
                default:
                    break;
            }

            this.Performace.FontAttributes = this.Usage.FontAttributes = this.Used.FontAttributes = this.Download.FontAttributes = FontAttributes.Bold;
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

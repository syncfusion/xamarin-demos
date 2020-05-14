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
using Xamarin.Forms;

namespace SampleBrowser.XlsIO
{
    public static class DeviceExt  
    {
        public static T OnPlatform<T>(T iOS, T android, T winPhone)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                return iOS;
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                return android;
            }
            else
            {
                return winPhone;
            }
        }
    }
}

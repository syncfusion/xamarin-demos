#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Net;
using SampleBrowser.SfMaps.Droid;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(NetConnection_Droid))]
namespace SampleBrowser.SfMaps.Droid
{
    public class NetConnection_Droid : OSMINetwork
    {
        public bool IsConnected { get; set; }

        public async Task CheckNetworkConnection()
        {
            var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false;
            }
            await Task.Delay(10);
        }
    }
}
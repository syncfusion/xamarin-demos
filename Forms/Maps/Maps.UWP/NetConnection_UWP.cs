#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.SfMaps.UWP;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

[assembly: Xamarin.Forms.Dependency(typeof(NetConnection_UWP))]
namespace SampleBrowser.SfMaps.UWP
{
    public class NetConnection_UWP : OSMINetwork
    {
        public bool IsConnected { get; set; }

        public async Task CheckNetworkConnection()
        {
            var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
            if (connectionProfile != null
                && connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
            {
                IsConnected = true;
            }
            else
                IsConnected = false;
            await Task.Delay(10);
        }
    }
}

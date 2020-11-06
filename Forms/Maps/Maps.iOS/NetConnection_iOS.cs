#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Net;
using System.Threading.Tasks;
using SampleBrowser.SfMaps.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(NetConnection_iOS))]
namespace SampleBrowser.SfMaps.iOS
{
    public class NetConnection_iOS : OSMINetwork
    {
        public bool IsConnected
        {
            get;
            set;
        }

        public async Task CheckNetworkConnection()
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("https://www.openstreetmap.org");
            webRequest.Method = "HEAD";
            try
            {
                using (var httpResponse = await webRequest.GetResponseAsync() as HttpWebResponse)
                {
                    if (httpResponse != null && httpResponse.StatusCode == HttpStatusCode.OK)
                        IsConnected = true;
                    else
                        IsConnected = false;
                }
            }
            catch (WebException)
            {
                IsConnected = false;
            }
        }
    }

}
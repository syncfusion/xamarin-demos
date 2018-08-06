#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;

namespace SampleBrowser
{
	[Activity (Label = "WebView")]			
	public class WebViewActivity : Activity
	{
		private WebView m_webView;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.HtmlViewer);
			m_webView = FindViewById<WebView> (Resource.Id.webview);
			string htmlString = Intent.GetStringExtra ("HtmlString");
			m_webView.LoadDataWithBaseURL (null, htmlString, "text/html", "utf-8", null);
		}
	}
}


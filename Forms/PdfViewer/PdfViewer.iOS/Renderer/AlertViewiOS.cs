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
using Foundation;
using UIKit;
using SampleBrowser.SfPdfViewer.iOS;
using Xamarin.Forms;
[assembly: Dependency(typeof(AlertViewiOS))]
namespace SampleBrowser.SfPdfViewer.iOS
{   
    class AlertViewiOS : IAlertView
    {
        public void Show(string message)
        {
            UIAlertView popUpView = new UIAlertView();
            popUpView.Message = message;
            popUpView.AddButton("OK");                
            popUpView.Show();
        }

    }
}
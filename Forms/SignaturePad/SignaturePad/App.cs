#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using SampleBrowser.Core;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSignaturePad
{
    [Preserve(AllMembers = true)]
    public class App : Application
    {
        public App()
        {
            //Getting the SignaturePad sample page
            var page = SampleBrowser.Core.SampleBrowser.GetMainPage("SfSignaturePad", "SampleBrowser.SfSignaturePad");
            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

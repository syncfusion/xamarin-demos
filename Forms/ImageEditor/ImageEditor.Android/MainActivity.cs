#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.IO;
using Xamarin.Forms;

namespace SampleBrowser.SfImageEditor.Droid
{
    [Activity(Label = "SampleBrowser SfImageEditor", Icon = "@drawable/AppIcon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : SampleBrowser.Core.Android.SampleBrowserActivity
    {
        internal static int DENSITY;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            DENSITY = (int)this.Resources.DisplayMetrics.Density;
            using (var stream = Assets.OpenFd("image.upng"))
            using (var readStream = Assets.Open("image.upng"))
            using (var memoryStream = new MemoryStream())
            {
                byte[] buffer = new byte[stream.Length];
                int read;
                while ((read = readStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, read);
                }
                var data = memoryStream.ToArray();
                var path = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "image.png");             
                System.IO.File.WriteAllBytes(path, data);

            }


            DependencyService.Register<FileStore>();
            DependencyService.Register<Share>();
            LoadApplication(new App());
        }
    }
}


#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Android.Views;

namespace SampleBrowser
{
    class CheckBoxSample : SamplePage
    {
        CheckBox_Mobile mobile;
        public override View GetSampleContent(Context con)
        {
                mobile = new CheckBox_Mobile();
                return mobile.GetSampleContent(con);
        }
    }
}
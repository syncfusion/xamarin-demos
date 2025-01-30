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
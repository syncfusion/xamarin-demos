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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Syncfusion.SfDataGrid;

namespace SampleBrowser
{
    public class Purple : DataGridStyle
    {
        public Purple()
        {
        }

        public override Color GetHeaderBackgroundColor()
        {
            return Color.ParseColor("#83538B");
        }

        public override Color GetHeaderForegroundColor()
        {
            return Color.ParseColor("#FFFFFF");
        }

        public override Color GetRecordForegroundColor()
        {
            return Color.ParseColor("#000000");
        }

        public override Color GetAlternatingRowBackgroundColor()
        {
            return Color.ParseColor("#EDE7F6");
        }

        public override Color GetSelectionBackgroundColor()
        {
            return Color.ParseColor("#9575CD");
        }

        public override Color GetSelectionForegroundColor()
        {
            return Color.ParseColor("#FFFFFF");
        }

        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Horizontal;
        }
    }
}
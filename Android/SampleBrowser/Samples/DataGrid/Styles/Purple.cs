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
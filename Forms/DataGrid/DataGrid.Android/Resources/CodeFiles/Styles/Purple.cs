#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class Purple : DataGridStyle
    {
        public Purple()
        {
        }

        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromHex("#83538B");
        }

        public override Color GetHeaderForegroundColor()
        {
            return Color.FromRgb(255, 255, 255);
        }

        public override Color GetSelectionBackgroundColor()
        {
            return Color.FromRgb(149, 117, 205);
        }

        public override Color GetSelectionForegroundColor()
        {
            return Color.FromRgb(255, 255, 255);
        }

        public override Color GetAlternatingRowBackgroundColor()
        {
            return Color.FromRgb(237, 231, 246);
        }

        public override Color GetRecordForegroundColor()
        {
            return Color.FromRgb(0, 0, 0);
        }

        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Horizontal;
        }
    }
}

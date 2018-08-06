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
    public class LoadMoreViewStyle : DataGridStyle
    {
        public LoadMoreViewStyle()
        {
        }

        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Horizontal;
        }

        public override Color GetLoadMoreViewBackgroundColor()
        {
            return Color.FromHex("#E0E0E0 ");
        }

        public override Color GetLoadMoreViewForegroundColor()
        {
            return Color.FromHex(" #000000");
        }
    }
}

#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
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
    public class DefaultStyle : DataGridStyle
    {
        public DefaultStyle()
        {
        }

        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromHex("#e0e0e0");
        }

        public override Color GetSelectionBackgroundColor()
        {
            return Color.FromHex("#b2d8f7");
        }

        public override Color GetSelectionForegroundColor()
        {
            return Color.Black;
        }

        public override Color GetRecordForegroundColor()
        {
            return Color.Black;
        }

        public override Color GetCaptionSummaryRowBackgroundColor()
        {
            return Color.FromHex("#e6e6e6");
        }

        public override Color GetRecordBackgroundColor()
        {
            return Color.White;
        }
        public override ImageSource GetGroupCollapseIcon()
        {
            if (Device.RuntimePlatform == Device.macOS)
                return base.GetGroupCollapseIcon();
            return null;
        }
    
        public override ImageSource GetHeaderSortIndicatorUp()
        {
            return base.GetHeaderSortIndicatorUp();
        }

        public override ImageSource GetHeaderSortIndicatorDown()
        {
            if (Device.RuntimePlatform == Device.macOS)
                return base.GetHeaderSortIndicatorDown();
            return null;
        }

    }

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SelectionStyle : DataGridStyle
    {
        public SelectionStyle()
        {
        }

        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromHex("#e0e0e0");
        }

        public override Color GetRecordForegroundColor()
        {
            return Color.Black;
        }

        public override Color GetRecordBackgroundColor()
        {
            return Color.White;
        }
    }

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class CellTemplateStyle : DataGridStyle
    {
        public override Color GetSelectionBackgroundColor()
        {
            return Color.FromHex("#cce5fa");
        }

        public override Color GetSelectionForegroundColor()
        {
            return Color.Black;
        }

    }
}

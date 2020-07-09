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

namespace SampleBrowser
{
    public class TreeViewPickerModel : UIPickerViewModel
    {
        private readonly IList<string> values;

        public event EventHandler<TreeViewPickerChangedEventArgs> PickerChanged;

        public TreeViewPickerModel(IList<string> values)
        {
            this.values = values;
        }

        public override nint GetComponentCount(UIPickerView picker)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView picker, nint component)
        {
            return values.Count;
        }

        public override string GetTitle(UIPickerView picker, nint row, nint component)
        {
            return values[(int)row];
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 30f;
        }

        public override void Selected(UIPickerView picker, nint row, nint component)
        {
            if (this.PickerChanged != null)
            {
                this.PickerChanged(this, new TreeViewPickerChangedEventArgs { SelectedValue = values[(int)row] });
            }
        }
    }
    public class TreeViewPickerChangedEventArgs : EventArgs
    {
        public string SelectedValue { get; set; }
    }

}
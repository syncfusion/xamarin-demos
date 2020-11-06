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
using Syncfusion.Android.DataForm;
using Syncfusion.Android.DataForm.Editors;
using Android.Graphics;

namespace SampleBrowser
{
    /// <summary>
    /// Represents a class that used to customize the DataForm.
    /// </summary>
    public class DataFormLayoutManagerExt : DataFormLayoutManager
    {
        public DataFormLayoutManagerExt(SfDataForm dataform) : base(dataform)
        {
        }

        /// <summary>
        /// Overridden to set the left padding for editor.
        /// </summary>             
        protected override int GetLeftPaddingForEditor(DataFormItem dataFormItem)
        {
            if (dataFormItem.Name.Equals("MiddleName") || dataFormItem.Name.Equals("LastName") || dataFormItem.Name.Equals("ContactType"))
            {
                return 56;
            }

            return base.GetLeftPaddingForEditor(dataFormItem);
        }

        protected override int GetLeftPaddingForLabel(DataFormItem dataFormItem)
        {
            if (dataFormItem.Name.Equals("SaveTo"))
            {
                return 60;
            }

            return base.GetLeftPaddingForLabel(dataFormItem);
        }
    }
}
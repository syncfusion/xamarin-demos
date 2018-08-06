#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using DataForm = Syncfusion.XForms.DataForm.SfDataForm;


namespace SampleBrowser.SfDataForm
{

    /// <summary>
    /// Represents a class that used to customize the DataForm.
    /// </summary>
    public class DataFormLayoutManagerExt : DataFormLayoutManager
    {
        public DataFormLayoutManagerExt(DataForm dataform) : base(dataform)
        {

        }
        protected override int GetLeftPaddingForEditor(DataFormItem dataFormItem)
        {         
            if (dataFormItem.Name.Equals("MiddleName") || dataFormItem.Name.Equals("LastName"))
                return 56;                            
            return base.GetLeftPaddingForEditor(dataFormItem);
        }
        protected override int GetLeftPaddingForLabel(DataFormItem dataFormItem)
        {
            if (dataFormItem.Name.Equals("SaveTo"))
                return 60;                            
            return base.GetLeftPaddingForLabel(dataFormItem);
        }      
    } 
}
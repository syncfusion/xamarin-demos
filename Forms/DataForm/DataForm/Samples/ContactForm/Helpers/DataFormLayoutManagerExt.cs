#region Copyright
// <copyright file="DataFormLayoutManagerExt.cs" company="Syncfusion"> 
//  Copyright (c) Syncfusion Inc. 2001 - 2020. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace SampleBrowser.SfDataForm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Syncfusion.XForms.DataForm;
    using Xamarin.Forms;
    using DataForm = Syncfusion.XForms.DataForm.SfDataForm;

    /// <summary>
    /// Represents a class that used to customize the DataForm.
    /// </summary>
    public class DataFormLayoutManagerExt : DataFormLayoutManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFormLayoutManagerExt"/> class.
        /// </summary>
        /// <param name="dataform">DataForm control helps editing the data fields of any data object.</param>
        public DataFormLayoutManagerExt(DataForm dataform) : base(dataform)
        {
        }

        /// <summary>
        /// Gets left start offset for editor.
        /// </summary>
        /// <param name="dataFormItem">DataFormItem of the editor.</param>
        /// <returns>Returns left padding for editor.</returns>
        protected override int GetLeftPaddingForEditor(DataFormItem dataFormItem)
        {
            return 0;
        }

        /// <summary>
        /// Gets left start offset for label.
        /// </summary>
        /// <param name="dataFormItem">DataFormItem of the editor.</param>
        /// <returns>Returns left padding value for label.</returns>
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
#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.DataForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SampleBrowser.SfDataForm
{
    /// <summary>
    /// Represents the source of the dataFormItem whose name is given.
    /// </summary>
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SourceProviderExt:SourceProvider
    {
        public override IList GetSource(string sourceName)
        {
            var list = new List<string>();
            if (sourceName == "Team")
            {
                list.Add("Marketing");
                list.Add("Maintenance");
                list.Add("Accounts");
            }
            return list;
        }
    }
}

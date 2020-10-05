#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfDataForm
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SfDataFormThemesBehavior : Behavior<Syncfusion.XForms.DataForm.SfDataForm>
    {
        /// <summary>
        /// DataForm control to edit the data fields of any data object
        /// </summary>
        private Syncfusion.XForms.DataForm.SfDataForm dataForm;

        /// <summary>
        /// Attaches to the superclass and then calls the OnAttachedTo method on this object.
        /// </summary>
        /// <param name="bindable">The bindable object to which the behavior was attached.</param>
        protected override void OnAttachedTo(Syncfusion.XForms.DataForm.SfDataForm bindable)
        {
            this.dataForm = bindable;
            base.OnAttachedTo(bindable);
        }

        /// <summary>
        /// Calls the OnDetachingFrom method and then detaches from the superclass.
        /// </summary>
        /// <param name="bindable">The bindable object from which the behavior was detached.</param>
        protected override void OnDetachingFrom(Syncfusion.XForms.DataForm.SfDataForm bindable)
        {
            base.OnDetachingFrom(bindable);
            this.dataForm = null;
        }
    }
}

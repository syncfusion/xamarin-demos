#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "AutoResizingPopupBehaviour.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SampleBrowser.Core;
    using Xamarin.Forms;

    /// <summary>
    /// Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    /// Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the samples.
    /// </summary>
    public class AutoResizingPopupBehaviour : Behavior<SampleView>
    {
        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">Label type of parameter bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            base.OnAttachedTo(bindAble);
            (bindAble.Resources["Notification"] as Syncfusion.XForms.PopupLayout.SfPopupLayout).Show();
        }
    }
}

#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Month Cell Date Behavior class
    /// </summary>
    public class MonthCellDateBehavior : Behavior<Label>
    {
        /// <summary>
        /// bindable
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(Label bindable)
        {
            base.OnAttachedTo(bindable);
            if (CustomizationViewModel.MonthCellItem == null)
            {
                return;
            }

            if (CustomizationViewModel.MonthCellItem.IsLeadingDay || CustomizationViewModel.MonthCellItem.IsTrailingDay)
            {
                bindable.TextColor = Color.Gray;
            }
            else
            {
                bindable.TextColor = Color.Black;
            }
        }
    }
}
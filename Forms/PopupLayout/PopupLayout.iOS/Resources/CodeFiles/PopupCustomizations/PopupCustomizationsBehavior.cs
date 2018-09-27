#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfPopupLayout
{
    public class BookButtonBehavior : Behavior<Button>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Parameter", typeof(object), typeof(BookButtonBehavior), null);

        public object Parameter
        {
            get { return (object)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        protected override void OnAttachedTo(Button bindable)
        {
            base.OnAttachedTo(bindable);
            (bindable as Button).Clicked += BookButton_Clicked;
        }

        private void BookButton_Clicked(object sender, EventArgs e)
        {
            if (Parameter != null)
            {
                (((Parameter as Syncfusion.SfDataGrid.XForms.SfDataGrid).Parent as SampleView).Parent.Parent.Parent.Parent as NavigationPage).Popped += BookButtonBehavior_Popped; ;
                ((Parameter as Syncfusion.SfDataGrid.XForms.SfDataGrid).Parent as SampleView).Navigation.PushAsync(new TicketBooking());
            }
        }

        private void BookButtonBehavior_Popped(object sender, NavigationEventArgs e)
        {

        }

        protected override void OnDetachingFrom(Button bindable)
        {
            base.OnDetachingFrom(bindable);
            (bindable as Button).Clicked -= BookButton_Clicked;
            Parameter = null;

        }
    }
}

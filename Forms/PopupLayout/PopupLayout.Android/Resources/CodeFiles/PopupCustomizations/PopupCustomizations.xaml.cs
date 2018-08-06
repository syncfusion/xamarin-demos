#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfPopupLayout
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupCustomizations : SampleView
    {
        Syncfusion.XForms.PopupLayout.SfPopupLayout initialPopup;
        public PopupCustomizations()
        {
            InitializeComponent();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            if (initialPopup == null)
            {
                initialPopup = new InitialPopup().Content as Syncfusion.XForms.PopupLayout.SfPopupLayout;
                initialPopup.Show();
            }
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            initialPopup.Dismiss();
        }
    }
}
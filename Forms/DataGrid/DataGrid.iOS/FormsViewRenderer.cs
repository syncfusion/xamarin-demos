#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.SfDataGrid;
using SampleBrowser.SfDataGrid.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FormsView), typeof(FormsViewRenderer))]
namespace SampleBrowser.SfDataGrid.iOS
{
    internal class FormsViewRenderer : ViewRenderer
    {
        public FormsView FormsView
        {
            get { return this.Element as FormsView; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            if (e.NewElement != null)
            {
                this.BackgroundColor = this.Element.BackgroundColor.ToUIColor();
            }
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Visibility")
            {
                if (this.FormsView.Visibility)
                {
                    this.Hidden = false;
                    if (this.Control != null)
                        this.Control.Hidden = false;
                }
                else
                {
                    this.Hidden = true;
                    if (this.Control != null)
                        this.Control.Hidden = true;
                }
            }
        }
    }
}

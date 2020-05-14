#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.SfPdfViewer;
using SampleBrowser.SfPdfViewer.UWP.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(SfFontButton), typeof(SfFontButtonRenderer))]
namespace SampleBrowser.SfPdfViewer.UWP.Renderer
{
    public class SfFontButtonRenderer : ButtonRenderer
    {
        public Thickness Padding { get; set; }
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var nativeButton = (Xamarin.Forms.Button)e.NewElement;
                Control.Padding = new Windows.UI.Xaml.Thickness(0, 0, 0, 0);
            }
        }

    }
}

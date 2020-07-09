#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using SampleBrowser.SfPdfViewer;
using SampleBrowser.SfPdfViewer.UWP;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace SampleBrowser.SfPdfViewer.UWP
{
	public class CustomEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
		}


		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == "IsFocused")
			{
				if ((sender as CustomEntry) != null && (sender as CustomEntry).IsFocused)
				{
                    Control.SelectAll();
				}
			}
		}
	}

    public class CustomPickerEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;
            Control.IsReadOnly = true;
            Control.BorderBrush = new SolidColorBrush(Colors.LightGray);
            Control.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;
            Control.VerticalContentAlignment = Windows.UI.Xaml.VerticalAlignment.Center;
        }
    }
}

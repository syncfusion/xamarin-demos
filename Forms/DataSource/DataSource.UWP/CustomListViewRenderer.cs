#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms;
using System.Collections.Specialized;
using System.ComponentModel;
using Windows.Foundation;
using SampleBrowser.DataSource;

[assembly: ExportRenderer(typeof(CustomListView), typeof(SampleBrowser.DataSource.UWP.CustomListViewRenderer))]
namespace SampleBrowser.DataSource.UWP
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        internal Windows.UI.Xaml.Controls.ListView NativeListView
        {
            get { return this.Control as Windows.UI.Xaml.Controls.ListView; }
        }


        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (e.NewElement.ItemsSource != null)
                {
                    (e.NewElement.ItemsSource as INotifyCollectionChanged).CollectionChanged += CustomListViewRenderer_CollectionChanged;
                }
            }
        }

        private void CustomListViewRenderer_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.NativeListView != null && this.Element != null)
            {
                var itemsource = this.Element.ItemsSource;
                this.NativeListView.ItemsSource = null;
                this.NativeListView.ItemsSource = itemsource;
            }
        }
    }
}

#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.DataSource;
using System.Collections.Specialized;
using Android.Graphics;

namespace SampleBrowser
{
    public class CustomAdapter : BaseAdapter<object>
    {
        private DataSource dataSource;
        private Context context;

        public CustomAdapter(DataSource dataSource, Context cntxt)
            : base()
        {
            this.dataSource = dataSource;
            this.dataSource.SourcePropertyChanged += DataSource_RecordPropertyChanged;
            this.dataSource.SourceCollectionChanged += DataSource_SourceCollectionChanged;
            this.dataSource.FilterChanged += DataSource_FilterChanged;
            context = cntxt;
        }

        private void DataSource_FilterChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.NotifyDataSetChanged();
        }

        private void DataSource_SourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.NotifyDataSetChanged();
        }

        private void DataSource_RecordPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.NotifyDataSetChanged();
        }

        public override int Count
        {
            get
            {
                return dataSource.DisplayItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override object this[int index]
        {
            get { return this.dataSource.DisplayItems[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            // re-use an existing view, if one is available
            // otherwise create a new one
            if (this[position] is BookDetails)
            {
                if (view == null)
                {
                    view = new GettingStartedTemplate(this.context);
                }

                view.SetBackgroundColor(Color.Transparent);
                (view as GettingStartedTemplate).UpdateValue(this[position]);
            }

            return view;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.dataSource.Dispose();
            this.dataSource = null;
        }
    }
}
#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
    public class RecyclerViewViewItemHolder : RecyclerView.ViewHolder
    {
        #region ctor

        public RecyclerViewViewItemHolder(View itemView, Action<TextView, int> listener) : base(itemView)
        {
            UpdateTagView = itemView.FindViewById<TextView>(Resource.Id.updateImage);

            SampleNameView = itemView.FindViewById<TextView>(Resource.Id.sampleName);

            itemView.Click += (sender, e) => listener(SampleNameView, AdapterPosition);
        }

        #endregion

        #region properties

        internal TextView UpdateTagView { get; set; }

        internal TextView SampleNameView { get; set; }

        #endregion
    }
}
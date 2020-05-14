#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
    public class RecyclerViewAdapter : RecyclerView.Adapter
    {
        #region fields

        private List<SampleModel> items;

        private TextView prevSelectedView;

        private int selectedIndex = -1;

        #endregion

        #region ctor

        public RecyclerViewAdapter(List<SampleModel> values)
        {
            items = values;
        }

        #endregion

        #region event

        public event EventHandler<ListViewSelectionChangedEventArgs> ItemClick;

        #endregion

        #region properties

        public override int ItemCount
        {
            get { return items.Count; }
        }

        #endregion

        #region methods

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as RecyclerViewViewItemHolder;

            var item = items[position];
            viewHolder.SampleNameView.Text = item.Title;
            if (selectedIndex != position)
            {
                viewHolder.SampleNameView.SetTextColor(Color.Black);
            }

            if (selectedIndex == -1 && position == 0)
            {
                prevSelectedView = viewHolder.SampleNameView;
                viewHolder.SampleNameView.SetTextColor(Color.ParseColor("#0277F5"));
            }

            if (selectedIndex == position)
            {
                viewHolder.SampleNameView.SetTextColor(Color.ParseColor("#0277F5"));
            }

            var textView = viewHolder.UpdateTagView;
            var layoutParams = textView.LayoutParameters as ViewGroup.LayoutParams;
            if (string.IsNullOrEmpty(item.Type))
            {
                textView.Visibility = ViewStates.Gone;
            }
            else
            {
                textView.Visibility = ViewStates.Visible;
                if (item.Type.ToLower().Equals("updated"))
                {
                    textView.Text = "U";
                    textView.SetBackgroundResource(Resource.Drawable.updatetagcircle);
                }
                else if (item.Type.ToLower().Equals("new"))
                {
                    textView.Text = "N";
                    textView.SetBackgroundResource(Resource.Drawable.newtagcircle);
                }
                else if (item.Type.ToLower().Equals("preview"))
                {
                    textView.Text = "P";
                    textView.SetBackgroundResource(Resource.Drawable.previewtagcircle);
                }

                layoutParams.Width = (int)(20 * MainActivity.Density);
                layoutParams.Height = (int)(20 * MainActivity.Density);
                textView.LayoutParameters = layoutParams;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CustomListViewLayout, parent, false);

            var viewHolder = new RecyclerViewViewItemHolder(itemView, OnClick);

            return viewHolder;
        }

        private void OnClick(TextView selectedView, int position)
        {
            var eventArgs = new ListViewSelectionChangedEventArgs
            {
                PreviousSelectedItem = prevSelectedView,
                SelectedItem = selectedView,
                SelectedIndex = position
            };
            selectedIndex = position;
            if (prevSelectedView == selectedView)
            {
                return;
            }

            ItemClick?.Invoke(this, eventArgs);

            prevSelectedView = selectedView;
        }

        #endregion
    }

    public class ListViewSelectionChangedEventArgs : EventArgs
    {
        #region properties

        public int SelectedIndex { get; set; }

        public TextView SelectedItem { get; set; }

        public TextView PreviousSelectedItem { get; set; }

        #endregion
    }
}
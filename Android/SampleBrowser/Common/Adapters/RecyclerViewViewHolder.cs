using System;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

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
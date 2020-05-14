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
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

namespace SampleBrowser
{
    internal class BookmarkToolbar : LinearLayout
    {
        private Button backToViewerButton; 
        LinearLayout bookmarkLayout;
        internal ListView bookmarkView;
        internal LinearLayout bookmarkTitle;
        internal CustomToolBarPdfViewerDemo sampleView;
        internal BookmarkListAdapter listAdapter;
        internal PdfLoadedDocument bookmarkLoadedDocument;
        internal Typeface bookmarkFont;
        Button bookmarkCloseButton;
        internal BookmarkToolbar(Context context, CustomToolBarPdfViewerDemo sampleView) :base(context)
        {
            this.sampleView = sampleView;
            bookmarkFont = sampleView.bookmarkFont;
            var inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            bookmarkLayout = (LinearLayout)inflater.Inflate(Resources.GetLayout(Resource.Layout.bookmarkAndroidToolbar), this, true);
            backToViewerButton = bookmarkLayout.FindViewById<Button>(Resource.Id.backToViewerButton);
            bookmarkCloseButton = bookmarkLayout.FindViewById<Button>(Resource.Id.bookmarkCloseButton);
            bookmarkTitle = bookmarkLayout.FindViewById<LinearLayout>(Resource.Id.bookmarkTitleBar);
            if (sampleView.IsDeviceTablet)
            {
                bookmarkTitle.LayoutParameters.Height = (int)(47 * Resources.DisplayMetrics.Density);
                backToViewerButton.Visibility = ViewStates.Invisible;
                bookmarkCloseButton.Click += M_bookmarkCloseButton_Click;
                bookmarkCloseButton.Typeface = sampleView.font;
            }
            else
            {
                bookmarkCloseButton.Visibility = ViewStates.Invisible;
                bookmarkTitle.LayoutParameters.Height = (int)(60 * Resources.DisplayMetrics.Density);
                backToViewerButton.Click += BackToViewerButton_Click;
                backToViewerButton.Typeface = sampleView.bookmarkFont;
            }
            bookmarkView = bookmarkLayout.FindViewById<ListView>(Resource.Id.bookmarkListView);
            listAdapter = new BookmarkListAdapter(context,this, Resources.DisplayMetrics.Density);
            bookmarkView.Adapter = listAdapter; 
            SetBackgroundColor(Color.White);
        }

        private void M_bookmarkCloseButton_Click(object sender, EventArgs e)
        {
            sampleView.CollapseBookmarkToolbar();
        }
        internal void ClearBookmark()
        {
            listAdapter.bookmarkList.Clear();
        }
        internal void PopulateInitialBookmarkList()
        {
            listAdapter.bookmarkList.Clear();
            PdfBookmarkBase bookmarkBase = bookmarkLoadedDocument.Bookmarks;
            for (int i = 0; i < bookmarkBase.Count; i++)
                listAdapter.bookmarkList.Add(new CustomBookmark(bookmarkBase[i], false));
            listAdapter.NotifyDataSetChanged();
        }
        private void BackToViewerButton_Click(object sender, EventArgs e)
        {
            if(!sampleView.IsDeviceTablet)
                sampleView.CollapseBookmarkToolbar();
        }
    }

    internal class BookmarkListAdapter : BaseAdapter<CustomBookmark>, View.IOnClickListener
    {
        internal List<CustomBookmark> bookmarkList;
        Activity context;
        Typeface bookmarkFont;
        BookmarkToolbar bookmarkToolbar;
        float density;
        List<PdfBookmark> navigationQueue = new List<PdfBookmark>();

        internal BookmarkListAdapter(Context context, BookmarkToolbar bookmarkToolbar, float density)
        {
            this.bookmarkToolbar = bookmarkToolbar;
            this.context = context as Activity;
            this.density = density;
            bookmarkList = new List<CustomBookmark>();
            bookmarkFont = bookmarkToolbar.bookmarkFont;
        }
        public override CustomBookmark this[int position]
        {
            get { return bookmarkList[position]; }
        }

        public override int Count
        {
            get { return bookmarkList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            CustomBookmark item = bookmarkList[position];
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.bookmarkListViewRow, null);
            view.SetOnClickListener(this);
            view.Tag = item;
            TextView textView = view.FindViewById<TextView>(Resource.Id.bookmarkTitle);
            textView.Text= item.Bookmark.Title;
            textView.SetWidth((int)(bookmarkToolbar.Width - 94 * density));

            CustomButton expandButton = view.FindViewById<CustomButton>(Resource.Id.expandBookmarkButton);
            expandButton.Click += ExpandButton_Click;
            expandButton.Typeface = bookmarkFont;
            if (!item.IsExpandButtonVisible)
                expandButton.Visibility = ViewStates.Invisible;
            else
                expandButton.Visibility = ViewStates.Visible;
            expandButton.Bookmark = item.Bookmark;

            CustomButton backButton = view.FindViewById<CustomButton>(Resource.Id.backToParentBookmarkButton);
            backButton.Click += BackButton_Click;
            backButton.Typeface = bookmarkFont;
            if (!item.IsBackToParentButtonVisible)
                backButton.Visibility = ViewStates.Invisible;
            else
                backButton.Visibility = ViewStates.Visible;
            backButton.Bookmark = item.Bookmark;
            return view;
        }

        public void OnClick(View v)
        {
            PdfBookmark bookmark = ((CustomBookmark)v.Tag).Bookmark;
            bookmarkToolbar.sampleView.pdfViewerControl.GoToBookmark(bookmark);
            if (!bookmarkToolbar.sampleView.IsDeviceTablet)
                bookmarkToolbar.sampleView.CollapseBookmarkToolbar();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            bookmarkList.Clear();
            if (navigationQueue.Count < 2)
            {
                for (int i = 0; i < bookmarkToolbar.bookmarkLoadedDocument.Bookmarks.Count; i++)
                    bookmarkList.Add(new CustomBookmark(bookmarkToolbar.bookmarkLoadedDocument.Bookmarks[i], false));
                NotifyDataSetChanged();
                if (navigationQueue.Count != 0)
                    navigationQueue.RemoveAt(navigationQueue.Count - 1);
            }
            else
            {
                PdfBookmark parentBookmark = navigationQueue[navigationQueue.Count - 2];
                navigationQueue.RemoveAt(navigationQueue.Count - 2);
                UpdateBookmarkList(parentBookmark);
            }
        }

        internal void UpdateBookmarkList(PdfBookmark bookmark)
        {
            bookmarkList.Clear();
            bookmarkList.Add(new CustomBookmark(bookmark, true));
            for (int i = 0; i < bookmark.Count; i++)
                bookmarkList.Add(new CustomBookmark(bookmark[i], false));
            NotifyDataSetChanged();
        }
        private void ExpandButton_Click(object sender, EventArgs e)
        {
            PdfBookmark bookmark = (sender as CustomButton).Bookmark;
            navigationQueue.Add(bookmark);
            UpdateBookmarkList(bookmark);
        }
    }

    internal class CustomButton : Button
    {
        internal PdfBookmark Bookmark;
        public CustomButton(Context context, IAttributeSet attributeSet):base(context, attributeSet)
        {

        }
    }

    internal class CustomBookmark : Java.Lang.Object
    {
        public PdfBookmark Bookmark { get; set; }
        internal CustomBookmark(PdfBookmark bookmark, bool isBackToParentButtonVisible)
        {
            Bookmark = bookmark;
            IsBackToParentButtonVisible = isBackToParentButtonVisible;
        }
        public bool IsExpandButtonVisible
        {
            get
            {
                return Bookmark.Count != 0 && !IsBackToParentButtonVisible;
            }
        }

        public bool IsBackToParentButtonVisible { get; set; }
    }
}
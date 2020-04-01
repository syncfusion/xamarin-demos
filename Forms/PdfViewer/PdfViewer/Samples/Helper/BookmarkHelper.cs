#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfPdfViewer
{
    internal class BookmarkToolbar : Grid
    {
        internal ListView bookmarkView;
        List<PdfBookmark> navigationQueue = new List<PdfBookmark>();
        IList<CustomBookmark> listViewItemsSource;
        Syncfusion.SfPdfViewer.XForms.SfPdfViewer pdfViewer;
        Grid parentGrid;
        internal bool isBookmarkPaneVisible = false;
        internal PdfLoadedDocument bookmarkLoadedDocument;
        internal BookmarkToolbar(PDFViewerCustomToolbar_Phone sampleView)
        {
            parentGrid = sampleView.parentGrid;
            pdfViewer = sampleView.pdfViewer;
            listViewItemsSource = sampleView.listViewItemsSource;
            CreateBookmarkToolbar();
        }

        internal BookmarkToolbar(PDFViewerCustomToolbar_Tablet sampleView)
        {
            parentGrid = sampleView.parentGrid;
            pdfViewer = sampleView.pdfViewer;
            listViewItemsSource = sampleView.listViewItemsSource;
            CreateBookmarkToolbar();
        }
        private void CreateBookmarkToolbar()
        {
            RowSpacing = 0;
            ColumnSpacing = 0;
            BackgroundColor = Color.White;
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                ColumnDefinitions.Add(new ColumnDefinition() { Width = 1 });
                ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
            RowDefinitions.Add(new RowDefinition() { Height = 60 });
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            Grid title = new Grid() { ColumnSpacing = 0, RowSpacing = 0, BackgroundColor = Color.FromHex("#EDEDED") };
            title.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });
            title.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            title.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });
            title.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            title.RowDefinitions.Add(new RowDefinition() { Height = 1 });

            Label bookmarkTitleText = new Label();
            bookmarkTitleText.HorizontalOptions = LayoutOptions.Start;
            bookmarkTitleText.VerticalOptions = LayoutOptions.Center;
            bookmarkTitleText.Text = "Bookmarks";
            bookmarkTitleText.FontSize = 16;
            bookmarkTitleText.TextColor = Color.FromHex("#000000");
            bookmarkTitleText.FontFamily = "Roboto";
            bookmarkTitleText.FontAttributes = FontAttributes.Bold;
            Grid.SetColumn(bookmarkTitleText, 1);
            Grid.SetRow(bookmarkTitleText, 0);
            title.Children.Add(bookmarkTitleText);

            if (Device.Idiom != TargetIdiom.Tablet)
            {
                SfFontButton backButton = new SfFontButton() { Text = FontMappingHelper.BookmarkBackward, TextColor = Color.FromHex("8A000000"), BackgroundColor = Color.Transparent, VerticalOptions = LayoutOptions.Center };
                backButton.FontFamily = FontMappingHelper.BookmarkFont;
                backButton.FontSize = 24;
                backButton.Clicked += BookmarkPaneBackButton_Clicked;
                backButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
                backButton.VerticalOptions = LayoutOptions.CenterAndExpand;
                backButton.VerticalOptions = LayoutOptions.Center;
                Grid.SetColumn(backButton, 0);
                Grid.SetRow(backButton, 0);
                title.Children.Add(backButton);
            }
            else
            {
                SfFontButton bookmarkCloseButton = new SfFontButton() { Text = FontMappingHelper.Close, TextColor = Color.FromHex("8A000000"), BackgroundColor = Color.Transparent, VerticalOptions = LayoutOptions.Center };
                bookmarkCloseButton.FontFamily = FontMappingHelper.FontFamily;
                bookmarkCloseButton.FontSize = 24;
                bookmarkCloseButton.Clicked += BookmarkCloseButton_Clicked;
                bookmarkCloseButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
                bookmarkCloseButton.VerticalOptions = LayoutOptions.CenterAndExpand;
                bookmarkCloseButton.VerticalOptions = LayoutOptions.Center;
                Grid.SetColumn(bookmarkCloseButton, 2);
                Grid.SetRow(bookmarkCloseButton, 0);
                title.Children.Add(bookmarkCloseButton);
            }

            Frame titleBottomBorder = new Frame() { BackgroundColor = Color.FromHex("#000000"), Opacity = 0.12 };
            Grid.SetRow(titleBottomBorder, 1);
            Grid.SetColumn(titleBottomBorder, 0);
            Grid.SetColumnSpan(titleBottomBorder, 2);
            title.Children.Add(titleBottomBorder);

            if (Device.Idiom == TargetIdiom.Tablet)
                Grid.SetColumn(title, 1);
            Grid.SetRow(title, 0);
            Children.Add(title);

            bookmarkView = new ListView(ListViewCachingStrategy.RecycleElement);
            bookmarkView.ItemTapped += BookmarkView_ItemTapped;
            bookmarkView.SeparatorVisibility = SeparatorVisibility.None;
            bookmarkView.ItemsSource = listViewItemsSource;
            bookmarkView.RowHeight = 60;
            bookmarkView.ItemTemplate = new DataTemplate(() =>
            {
                ViewCell viewCell = new ViewCell();
                Grid view = new Grid() { ColumnSpacing = 0, RowSpacing = 0, BackgroundColor = Color.White };
                view.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });
                view.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                view.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });
                view.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                view.RowDefinitions.Add(new RowDefinition() { Height = 1 });

                Label bookmarkTitle = new Label();
                bookmarkTitle.HorizontalOptions = LayoutOptions.Start;
                bookmarkTitle.LineBreakMode = LineBreakMode.TailTruncation;
                bookmarkTitle.VerticalOptions = LayoutOptions.Center;
				//Bind the Text property of the bookmark title label to the Title property of custom bookmark
                bookmarkTitle.SetBinding(Label.TextProperty, "Title");
                bookmarkTitle.TextColor = Color.FromHex("#000000");
                bookmarkTitle.Opacity = 0.87;
                bookmarkTitle.FontFamily = "Roboto";
                bookmarkTitle.FontSize = 16;
                Grid.SetColumn(bookmarkTitle, 1);
                Grid.SetRow(bookmarkTitle, 0);
                view.Children.Add(bookmarkTitle);

                SfFontButton backToParentButton = new SfFontButton() { Text = FontMappingHelper.BookmarkBackward, TextColor = Color.FromHex("8A000000"), BackgroundColor = Color.Transparent };
                backToParentButton.FontFamily = FontMappingHelper.BookmarkFont;
                backToParentButton.FontSize = 24;
                backToParentButton.Clicked += BackToParentButton_Clicked;
                backToParentButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
                backToParentButton.VerticalOptions = LayoutOptions.CenterAndExpand;
                Grid.SetRow(backToParentButton, 0);
                Grid.SetColumn(backToParentButton, 0);
                view.Children.Add(backToParentButton);
				//Bind the IsVisible property of the backtoparent button to the IsBackToParentButtonVisible property of CustomBookmark
                backToParentButton.SetBinding(IsVisibleProperty, "IsBackToParentButtonVisible");

                SfFontButton expandButton = new SfFontButton() { Text = FontMappingHelper.BookmarkForward, TextColor = Color.FromHex("8A000000"), BackgroundColor = Color.Transparent };
                expandButton.SetBinding(SfFontButton.CommandParameterProperty, ".");
                expandButton.FontFamily = FontMappingHelper.BookmarkFont;
                expandButton.FontSize = 24;
                expandButton.Clicked += BookmarkExpand_Clicked;
                expandButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
                expandButton.VerticalOptions = LayoutOptions.CenterAndExpand;
                Grid.SetRow(expandButton, 0);
                Grid.SetColumn(expandButton, 2);
                view.Children.Add(expandButton);
				//Bind the IsVisible property of the expand button to the IsExpandButtonVisible property of CustomBookmark
                expandButton.SetBinding(IsVisibleProperty, "IsExpandButtonVisible");

                Frame bottomBorder = new Frame() { BackgroundColor = Color.FromHex("#000000"), Opacity = 0.12, Margin = 0 };
                Grid.SetRow(bottomBorder, 1);
                Grid.SetColumn(bottomBorder, 0);
                Grid.SetColumnSpan(bottomBorder, 3);
                view.Children.Add(bottomBorder);

                viewCell.View = view;
                return viewCell;
            });
            if (Device.Idiom == TargetIdiom.Tablet)
                Grid.SetColumn(bookmarkView, 1);
            Grid.SetRow(bookmarkView, 1);
            Children.Add(bookmarkView);

			//Add the border between bookmark toolbar and pdfviewer only if the device is tablet
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                Frame leftBorder = new Frame() { BackgroundColor = Color.FromHex("#000000"), Opacity = 0.12, Margin = 0 };
                Grid.SetRow(leftBorder, 0);
                Grid.SetColumn(leftBorder, 0);
                Grid.SetRowSpan(leftBorder, 2);
                Children.Add(leftBorder);
            }
        }

		//Handles the click event of the close button on bookmark toolbar in tablet
        private void BookmarkCloseButton_Clicked(object sender, EventArgs e)
        {
            this.WidthRequest = 0;
            isBookmarkPaneVisible = false;
        }

		
        private void BookmarkView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
			//Obtain the bookmark from the listview item and navigate to its destination
            pdfViewer.GoToBookmark((e.Item as CustomBookmark).Bookmark);
			
			//If the device is phone remove bookmark toolbar once the bookmark is navigated to
            if (Device.Idiom == TargetIdiom.Phone)
            {
                parentGrid.Children.Remove(this);
                isBookmarkPaneVisible = false;
            }
        }

		//Handles the click event of the backtoparent button on each bookmark in the list
        private void BackToParentButton_Clicked(object sender, EventArgs e)
        {
            listViewItemsSource.Clear();
            if (navigationQueue.Count < 2)
            {
                for (int i = 0; i < bookmarkLoadedDocument.Bookmarks.Count; i++)
                    listViewItemsSource.Add(new CustomBookmark(bookmarkLoadedDocument.Bookmarks[i], false));
                if(navigationQueue.Count != 0)
                    navigationQueue.RemoveAt(navigationQueue.Count - 1);
            }
            else
            {
				//Obtain the bookmark that was added to the navigationQueue when the expand button was clicked before
                PdfBookmark parentBookmark = navigationQueue[navigationQueue.Count - 2];
                navigationQueue.RemoveAt(navigationQueue.Count - 2);
                UpdateBookmarkList(parentBookmark);
            }
        }

		//Populate the bookmark toolbar with the bookmarks when a new PDF is loaded 
        internal void PopulateInitialBookmarkList()
        {
            listViewItemsSource.Clear();
            PdfBookmarkBase bookmarkBase = bookmarkLoadedDocument.Bookmarks;
            for (int i = 0; i < bookmarkBase.Count; i++)
                listViewItemsSource.Add(new CustomBookmark(bookmarkBase[i], false));
        }

		//Update the listview with new bookmarks when the backtoparent or expand button is clicked
        internal void UpdateBookmarkList(PdfBookmark bookmark)
        {
            listViewItemsSource.Clear();
            listViewItemsSource.Add(new CustomBookmark(bookmark, true));
            for (int i = 0; i < bookmark.Count; i++)
                listViewItemsSource.Add(new CustomBookmark(bookmark[i], false));
        }

		//Handles the click event of the expand button of a bookmark. The expand button is visible only for bookmark with children
        private void BookmarkExpand_Clicked(object sender, EventArgs e)
        {
            PdfBookmark bookmark = ((sender as SfFontButton).CommandParameter as CustomBookmark).Bookmark;
            navigationQueue.Add(bookmark);
            UpdateBookmarkList(bookmark);
        }

		//Handles the click event of the back button on the bookmark toolbar in phone
        private void BookmarkPaneBackButton_Clicked(object sender, EventArgs e)
        {
            parentGrid.Children.Remove(this);
            isBookmarkPaneVisible = false;
        }
    }

	//Class that holds the bookmark data. 
    internal class CustomBookmark : INotifyPropertyChanged
    {
        private string desktopExpandButtonIcon = "\ue702";

        public event PropertyChangedEventHandler PropertyChanged;

        public PdfBookmark Bookmark { get; set; }
        internal CustomBookmark(PdfBookmark bookmark, bool isBackToParentButtonVisible)
        {
            Bookmark = bookmark;
            IsBackToParentButtonVisible = isBackToParentButtonVisible;
        }

        internal CustomBookmark(PdfBookmark bookmark)
        {
            Bookmark = bookmark;
        }

		//Title of the bookmark
        public string Title
        {
            get
            {
                return Bookmark.Title;
            }
        }

        public string DesktopExpandButtonIcon
        {
            get
            {
                return desktopExpandButtonIcon;
            }
            set
            {
                desktopExpandButtonIcon = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DesktopExpandButtonIcon"));
            }
        }

		//Returns a value that indicates whether the expand button should be visible 
        public bool IsExpandButtonVisible
        {
            get
            {
                return Bookmark.Count != 0 && !IsBackToParentButtonVisible;
            }
        }
		
		//Gets or sets a value that indicates whether the backtoparent button should be visible
        public bool IsBackToParentButtonVisible { get; set; }
    }

}

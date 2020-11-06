#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfPdfViewer
{
    internal class BookMarkPane : Grid

    {
        Grid bookmarkTitle = new Grid();
        Label bookmarkTitleText = new Label() { Text = "Bookmarks", FontSize = 16 };
        ListView bookmarkView = new ListView();
        Syncfusion.SfPdfViewer.XForms.SfPdfViewer pdfViewer;
        StackLayout bookPane;
        IList<CustomBookmark> listViewItemsSource;
        List<PdfBookmark> navigationQueue = new List<PdfBookmark>();
        internal PdfLoadedDocument bookmarkLoadedDocument;
        




        internal BookMarkPane(PDFViewerCustomToolbar_Desktop toolbar_Desktop)
        {
            pdfViewer = toolbar_Desktop.pdfViewer;
            bookPane = toolbar_Desktop.basePane;
            bookmarkLoadedDocument = toolbar_Desktop.bookmarkLoadedDocument;
            listViewItemsSource = toolbar_Desktop.ListViewItemsSource;
            CreateToolBar();
        }
        private void CreateToolBar()
        {

            bookmarkTitle = new Grid();

            bookmarkTitle.HeightRequest = 40;
            bookmarkTitle.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            bookmarkTitle.ColumnDefinitions.Add(new ColumnDefinition() { Width = 32 });
            bookmarkTitle.RowDefinitions.Add(new RowDefinition() { Height = 38 });
            bookmarkTitle.RowDefinitions.Add(new RowDefinition() { Height = 2 });
            bookmarkTitle.VerticalOptions = LayoutOptions.Start;
            Frame frame3 = new Frame() { BackgroundColor = Color.FromHex("#E0E0E0") };
            Grid.SetColumnSpan(frame3, 2);
            Grid.SetRow(frame3, 1);

            bookmarkTitle.Children.Add(frame3);

            bookmarkTitle.RowSpacing = 10;

            bookmarkTitleText.HorizontalOptions = LayoutOptions.Start;
            bookmarkTitleText.VerticalOptions = LayoutOptions.Center;
            bookmarkTitleText.Margin = new Thickness(10, 10, 0, 0);
            bookmarkTitleText.FontSize = 15;
            bookmarkTitleText.TextColor = Color.FromHex("#000000");
            bookmarkTitleText.FontFamily = "SegoeUI";
            bookmarkTitleText.FontAttributes = FontAttributes.Bold;
            bookmarkTitle.Children.Add(bookmarkTitleText);


            Button closeButton = new Button() { WidthRequest = 30, HeightRequest = 30 };
            closeButton.Text = "\uE701";

            closeButton.FontFamily = "ms-appx:///Syncfusion.SfPdfViewer.XForms.UWP/Final_PDFViewer_UWP_FontUpdate.ttf#Final_PDFViewer_UWP_FontUpdate";
            closeButton.FontSize = 12;
            closeButton.TextColor = Color.FromHex("#000000");
            closeButton.BackgroundColor = Color.Transparent;
            closeButton.HorizontalOptions = LayoutOptions.End;
            closeButton.VerticalOptions = LayoutOptions.End;
            closeButton.Clicked += CloseButton_Clicked;
            Grid.SetColumn(closeButton, 1);
            Grid.SetRow(closeButton, 0);
            Grid.SetColumn(bookmarkTitleText, 0);
            Grid.SetRow(bookmarkTitleText, 0);
            bookmarkTitle.Children.Add(closeButton);
            Grid.SetRow(bookmarkTitle, 0);

            bookPane.Children.Add(bookmarkTitle);

            Grid.SetRow(bookmarkView, 1);
            bookmarkView.HorizontalOptions = LayoutOptions.StartAndExpand;
            bookmarkView.VerticalOptions = LayoutOptions.StartAndExpand;

            bookmarkView.Margin = new Thickness(0, 3, 0, 0);
            bookmarkView.ItemsSource = listViewItemsSource;
            bookmarkView.ItemTapped += BookmarkView_ItemTapped;

            bookmarkView.ItemTemplate = new DataTemplate(() =>
            {
                ViewCell viewCell = new ViewCell();
                Grid view = new Grid();
                Grid viewChild = new Grid();
                viewChild.SetBinding(Grid.MarginProperty, "MarginForDesktop");
                view.HeightRequest = 40;

                viewChild.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });
                viewChild.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                viewChild.ColumnDefinitions.Add(new ColumnDefinition() { Width = 40 });


                Label bookmarkTitle = new Label();
                bookmarkTitle.HorizontalOptions = LayoutOptions.StartAndExpand;

                bookmarkTitle.LineBreakMode = LineBreakMode.TailTruncation;
                bookmarkTitle.VerticalOptions = LayoutOptions.Center;
                bookmarkTitle.SetBinding(Label.TextProperty, "Title");
                bookmarkTitle.FontFamily = "SegoeUI";
                bookmarkTitle.FontSize = 13;
                Grid.SetColumn(bookmarkTitle, 1);

                Grid.SetRow(bookmarkTitle, 0);
                viewChild.Children.Add(bookmarkTitle);




                Button backToParentButton = new Button() { Text = FontMappingHelper.BookmarkBackward, TextColor = Color.FromHex("8A000000"), BackgroundColor = Color.Transparent };
                backToParentButton.FontFamily = FontMappingHelper.BookmarkFont;
                backToParentButton.FontSize = 24;
                backToParentButton.Clicked += BackToParentButton_Clicked;
                backToParentButton.HorizontalOptions = LayoutOptions.Start;
                backToParentButton.VerticalOptions = LayoutOptions.Start;
                Grid.SetRow(backToParentButton, 0);
                Grid.SetColumn(backToParentButton, 0);
                viewChild.Children.Add(backToParentButton);
                backToParentButton.SetBinding(IsVisibleProperty, "IsBackToParentButtonVisible");

                Button expandButton = new Button() { Text = FontMappingHelper.BookmarkForward, TextColor = Color.FromHex("8A000000"), BackgroundColor = Color.Transparent };
                expandButton.SetBinding(SfFontButton.CommandParameterProperty, ".");
                expandButton.FontFamily = FontMappingHelper.BookmarkFont;
                expandButton.FontSize = 24;
                expandButton.Clicked += BookmarkExpand_Clicked;
                expandButton.HorizontalOptions = LayoutOptions.End;
                expandButton.VerticalOptions = LayoutOptions.End;
                Grid.SetRow(expandButton, 0);
                Grid.SetColumn(expandButton, 2);
                viewChild.Children.Add(expandButton);
                expandButton.SetBinding(IsVisibleProperty, "IsExpandButtonVisible");




                view.Children.Add(viewChild);
                viewCell.View = view;

                return viewCell;
            });

            bookPane.Children.Add(bookmarkView);

            BackgroundColor = Color.FromHex("#F6F6F6");
            bookPane.WidthRequest = 280;


            bookPane.Children.Add(this);


        }
        private void BackToParentButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (listViewItemsSource != null && listViewItemsSource.Count > 0)
                {
                    for (int i = listViewItemsSource.Count - 1; i >= 0; i--)
                    {
                        listViewItemsSource.RemoveAt(i);
                    }
                }
            }
            catch (Exception)
            {

            }
            if (navigationQueue.Count < 2)
            {
                for (int i = 0; i < bookmarkLoadedDocument.Bookmarks.Count; i++)
                    listViewItemsSource.Add(new CustomBookmark(bookmarkLoadedDocument.Bookmarks[i], false));
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
        internal void PopulateInitialBookmarkList()
        {
            if (listViewItemsSource != null && listViewItemsSource.Count != 0)
            {
                try

                {
                    for (int i = listViewItemsSource.Count - 1; i >= 0; i--)
                        listViewItemsSource.RemoveAt(i);
                }
                catch (Exception)
                {

                }
            }
            if (bookmarkLoadedDocument != null)
            {
                PdfBookmarkBase bookmarkBase = bookmarkLoadedDocument.Bookmarks;
                for (int i = 0; i < bookmarkBase.Count; i++)
                    listViewItemsSource.Add(new CustomBookmark(bookmarkBase[i], false));
            }
            if (navigationQueue.Count != 0)
            {
                try
                {
                    for (int i = navigationQueue.Count - 1; i >= 0; i--)
                        navigationQueue.RemoveAt(i);
                }
                catch (Exception)
                {

                }
            }
        }
        private void BookmarkExpand_Clicked(object sender, EventArgs e)
        {
            PdfBookmark bookmark = ((sender as Button).CommandParameter as CustomBookmark).Bookmark;
            navigationQueue.Add(bookmark);
            UpdateBookmarkList(bookmark);
        }

        private void BookmarkView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)

                pdfViewer.GoToBookmark((e.Item as CustomBookmark).Bookmark);
        }


        internal void UpdateBookmarkList(PdfBookmark bookmark)
        {
            if (listViewItemsSource != null && listViewItemsSource.Count > 0)
            {
                for (int i = listViewItemsSource.Count - 1; i >= 0; i--)
                    listViewItemsSource.RemoveAt(i);
            }
            listViewItemsSource.Add(new CustomBookmark(bookmark, true));
            for (int i = 0; i < bookmark.Count; i++)
                listViewItemsSource.Add(new CustomBookmark(bookmark[i], false));
        }

        private  void CloseButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext as PdfViewerViewModel != null)
                (BindingContext as PdfViewerViewModel).IsBookMarkVisible = false;
            this.WidthRequest = 0;


        }

    }




}

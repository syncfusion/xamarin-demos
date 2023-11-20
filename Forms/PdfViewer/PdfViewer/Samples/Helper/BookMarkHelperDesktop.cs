#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.XForms.TabView;
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
        AbsoluteLayout absoluteLayoutContainer = new AbsoluteLayout();
        Label bookmarkTitleText = new Label() { Text = "Bookmarks", FontSize = 16 };
        ListView bookmarkView = new ListView();
        ListView customBookmarkView = new ListView();
        Syncfusion.SfPdfViewer.XForms.SfPdfViewer pdfViewer;
        StackLayout bookPane;
        IList<ContentBookmark> listViewItemsSource;
        ObservableCollection<BookmarkContextMenu> ContextMenuList = new ObservableCollection<BookmarkContextMenu>();
        List<PdfBookmark> navigationQueue = new List<PdfBookmark>();
        internal PdfLoadedDocument bookmarkLoadedDocument;
        Syncfusion.XForms.TabView.SfTabView tabView = new Syncfusion.XForms.TabView.SfTabView();
        private Grid tabviewHeader_Content;
        private Grid tabviewHeader_Bookmark;
        internal Frame AddBookmarkButton;
        internal Label AddBookmarkLabel;
        internal Frame contextOptionsFrame;
        StackLayout contextOptions;
        internal Frame toastMessageFrame;
        internal Label messageLabel;
        double CustomBookmarkView_ScrollY;
        internal int selectedCustomBookmarkIndex;
        PDFViewerCustomToolbar_Desktop PDFViewerCustomToolbar_Desktop;
        internal Grid NobookmarksLabel { get; set; }
        internal Grid CustomNobookmarksLabel { get; set; }




        internal BookMarkPane(PDFViewerCustomToolbar_Desktop toolbar_Desktop)
        {
            pdfViewer = toolbar_Desktop.pdfViewer;
            bookPane = toolbar_Desktop.basePane;
            bookmarkLoadedDocument = toolbar_Desktop.bookmarkLoadedDocument;
            listViewItemsSource = toolbar_Desktop.ListViewItemsSource;
            this.PDFViewerCustomToolbar_Desktop = toolbar_Desktop;
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

            NobookmarksLabel = new Grid();
            Label label = new Label() { Text = "No Bookmarks", FontSize = 15, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            NobookmarksLabel.Children.Add(label);


            CustomNobookmarksLabel = new Grid();
            Label customLabel = new Label() { Text = "No Bookmarks", FontSize = 15, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            CustomNobookmarksLabel.Children.Add(customLabel);

            Grid.SetRow(absoluteLayoutContainer, 1);
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

            customBookmarkView.HorizontalOptions = LayoutOptions.Center;
            customBookmarkView.VerticalOptions = LayoutOptions.Start;
            customBookmarkView.ItemsSource = pdfViewer.CustomBookmarks;
            customBookmarkView.Scrolled += CustomBookmarkView_Scrolled;
            customBookmarkView.ItemTapped += CustomBookmarkView_ItemTapped;
            customBookmarkView.ItemTemplate = new DataTemplate(() =>
            {
                ViewCell viewCell = new ViewCell();

                Grid view = new Grid();
                Grid viewChild = new Grid();
                viewChild.SetBinding(Grid.MarginProperty, "MarginForDesktop");
                view.HeightRequest = 40;
                viewChild.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                viewChild.ColumnDefinitions.Add(new ColumnDefinition() { Width = 32 });

                Label bookmarkLabel = new Label() { TextColor = Color.FromHex("#000000") };
                bookmarkLabel.Margin = new Thickness(12, 8, 0, 9);
                bookmarkLabel.LineBreakMode = LineBreakMode.TailTruncation;
                bookmarkLabel.VerticalOptions = LayoutOptions.Center;
                bookmarkLabel.SetBinding(Label.TextProperty, "Name");
                bookmarkLabel.FontFamily = "SegoeUI";
                bookmarkLabel.FontSize = 12;
                Grid.SetColumn(bookmarkLabel, 0);

                SfFontButton popUpMenuButton = new SfFontButton() { Text="\uE711", HeightRequest=30, WidthRequest=30};
                popUpMenuButton.FontFamily = FontMappingHelper.FontFamily;
                popUpMenuButton.BackgroundColor = Color.Transparent;
                popUpMenuButton.TextColor = Color.FromHex("#000000");
                popUpMenuButton.HorizontalOptions = LayoutOptions.Center;
                popUpMenuButton.VerticalOptions = LayoutOptions.Center;
                popUpMenuButton.Clicked += PopUpMenuButton_Clicked; 
                popUpMenuButton.Margin = new Thickness(0, 10, 12, 10);
                Grid.SetColumn(popUpMenuButton, 1);


                viewChild.Children.Add(bookmarkLabel);
                viewChild.Children.Add(popUpMenuButton);
                view.Children.Add(viewChild);
                viewCell.View = view;

                return viewCell;
            });


            

            tabviewHeader_Content = new Grid();
            Label Bookmark_DefaultHeader = new Label();
            Bookmark_DefaultHeader.WidthRequest = 40;
            Bookmark_DefaultHeader.FontFamily = FontMappingHelper.CustomBookmarkFont;
            Bookmark_DefaultHeader.Text = FontMappingHelper.Bookmark_Default;
            Bookmark_DefaultHeader.TextColor = Color.FromHex("#007CEE");
            Bookmark_DefaultHeader.FontSize = 25;
            Bookmark_DefaultHeader.HorizontalOptions = LayoutOptions.Center;
            Bookmark_DefaultHeader.VerticalOptions = LayoutOptions.Center;
            Bookmark_DefaultHeader.HorizontalTextAlignment = TextAlignment.Center;
            Bookmark_DefaultHeader.VerticalTextAlignment = TextAlignment.Center;
            tabviewHeader_Content.Children.Add(Bookmark_DefaultHeader);

            tabviewHeader_Bookmark = new Grid();
            Label Bookmark_CustomHeader = new Label();
            Bookmark_CustomHeader.WidthRequest = 40;
            Bookmark_CustomHeader.FontFamily = FontMappingHelper.CustomBookmarkFont;
            Bookmark_CustomHeader.Text = FontMappingHelper.Bookmark_Custom;
            Bookmark_CustomHeader.FontSize = 20;
            Bookmark_CustomHeader.HorizontalOptions = LayoutOptions.Center;
            Bookmark_CustomHeader.VerticalOptions = LayoutOptions.Center;
            Bookmark_CustomHeader.HorizontalTextAlignment = TextAlignment.Center;
            Bookmark_CustomHeader.VerticalTextAlignment = TextAlignment.Center;
            tabviewHeader_Bookmark.Children.Add(Bookmark_CustomHeader);

            var tabItems = new TabItemCollection
            {
                new SfTabItem()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Content = bookmarkView,
                    HeaderContent=tabviewHeader_Content
                },
                new SfTabItem()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Content = customBookmarkView,
                    HeaderContent=tabviewHeader_Bookmark
                },
            };
            tabView.TabHeight = 32;
            tabView.TabWidth = 140;
            tabView.Items = tabItems;
            tabView.SelectionChanged += TabView_SelectionChanged;
            AbsoluteLayout.SetLayoutFlags(tabView, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(tabView, new Rectangle(0, 0, 1, 1));
            absoluteLayoutContainer.Children.Add(tabView);

            toastMessageFrame = new Frame() { IsVisible = false, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.End, CornerRadius = 4, HeightRequest = 32, WidthRequest = 129, BackgroundColor = Color.FromHex("#353535"), Padding = 0, Margin = new Thickness(0, 0, 0, 13) };
            messageLabel = new Label() { BackgroundColor = Color.Transparent, HeightRequest = 20, Margin = new Thickness(0, 5, 0, 5), TextColor = Color.FromHex("#FFFFFF"), FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };
            toastMessageFrame.Content = messageLabel;


            AddBookmarkLabel = new Label() { TextColor = Color.White, FontSize = 24, BackgroundColor = Color.Transparent, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

            AddBookmarkButton = new Frame() { BackgroundColor = Color.FromHex("#007CEE"), Content = AddBookmarkLabel, HasShadow = false, Padding = 0 };

            TapGestureRecognizer addGesture = new TapGestureRecognizer();
            addGesture.Tapped += AddBookmarkButton_Clicked;

            AddBookmarkLabel.FontFamily = FontMappingHelper.CustomBookmarkFont;
            AddBookmarkLabel.Text = FontMappingHelper.Bookmark_Add;
            AddBookmarkButton.GestureRecognizers.Add(addGesture);
            AddBookmarkButton.CornerRadius = 34;
            AddBookmarkButton.HeightRequest = 68;
            AddBookmarkButton.WidthRequest = 68;

            VisualStateGroupList visualStateGroupList = new VisualStateGroupList();
            VisualStateGroup commonStateGroup = new VisualStateGroup();
            VisualState EnabledState = new VisualState() { Name = "Normal" };
            EnabledState.Setters.Add(new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex("#007CEE") });

            VisualState DisabledState = new VisualState() { Name = "Disabled" };
            DisabledState.Setters.Add(new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex("#7BB9F2") });
            
            AddBookmarkButton.Margin = new Thickness(0, 0, 26, 26);
            AbsoluteLayout.SetLayoutFlags(AddBookmarkButton, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(AddBookmarkButton, new Rect(1, 1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));


            commonStateGroup.States.Add(EnabledState);
            commonStateGroup.States.Add(DisabledState);
            visualStateGroupList.Add(commonStateGroup);
            VisualStateManager.SetVisualStateGroups(AddBookmarkButton, visualStateGroupList);
            
            absoluteLayoutContainer.Children.Add(AddBookmarkButton);

            contextOptionsFrame = new Frame() { BorderColor = Color.FromHex("#D5D5D5"), IsVisible = false, Padding = 0, HasShadow = false, Margin = new Thickness(0, 0, 22, 0), CornerRadius = 4, HeightRequest = 88, WidthRequest = 149, BackgroundColor = Color.FromHex("#F6F6F6") };            
            contextOptionsFrame.SetBinding(Frame.IsVisibleProperty,"IsContextMenuVisible");

            ListView ContextMenuListView = new ListView() { VerticalScrollBarVisibility = ScrollBarVisibility.Never };
            ContextMenuListView.RowHeight = 40;
            ContextMenuListView.ItemsSource = ContextMenuList;
            ContextMenuListView.ItemTapped += ContextMenuListView_ItemTapped; 
            ContextMenuList.Add(new BookmarkContextMenu(FontMappingHelper.RenameBookmark,"Rename"));
            ContextMenuList.Add(new BookmarkContextMenu(FontMappingHelper.DeleteBookmark, "Delete"));
            ContextMenuListView.ItemTemplate = new DataTemplate(() =>
            {
                ViewCell viewCell = new ViewCell();
                StackLayout stack = new StackLayout() { Orientation = StackOrientation.Horizontal };

                Label Label = new Label() { TextColor = Color.FromHex("#000000") };
                Label.VerticalOptions = LayoutOptions.Center;
                Label.HorizontalOptions = LayoutOptions.Center;
                Label.VerticalTextAlignment = TextAlignment.Center;
                Label.VerticalTextAlignment = TextAlignment.Center;
                Label.SetBinding(Label.TextProperty, "LabelText");
                Label.FontFamily = "SegoeUI";
                Label.FontSize = 12;

                Label Button = new Label() {WidthRequest=40, HorizontalTextAlignment=TextAlignment.Center, VerticalTextAlignment=TextAlignment.Center};
                Button.FontFamily = FontMappingHelper.CustomBookmarkFont;
                Button.BackgroundColor = Color.Transparent;
                Button.TextColor = Color.FromHex("#000000");
                Button.HorizontalOptions = LayoutOptions.Center;
                Button.VerticalOptions = LayoutOptions.Center;
                Button.SetBinding(Label.TextProperty, "IconText");

                stack.Children.Add(Button);
                stack.Children.Add(Label);

                viewCell.View = stack;

                return viewCell;

            });

            contextOptions = new StackLayout() { Orientation = StackOrientation.Vertical, BackgroundColor = Color.FromHex("#F6F6F6") , Margin= new Thickness(0,4,0,4) };
            contextOptions.HeightRequest = 80;
            contextOptions.WidthRequest = 149;

            AbsoluteLayout.SetLayoutFlags(contextOptionsFrame, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(contextOptionsFrame, new Rect(1, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            
            contextOptions.Children.Add(ContextMenuListView);

            contextOptionsFrame.Content = contextOptions;

            absoluteLayoutContainer.Children.Add(contextOptionsFrame);

            var hideComtextMenuTapGestureRecognizer = new TapGestureRecognizer();
            customBookmarkView.GestureRecognizers.Add(hideComtextMenuTapGestureRecognizer);
            hideComtextMenuTapGestureRecognizer.Tapped += (sender, args) =>
            {
                (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            };

            pdfViewer.CustomBookmarks.CollectionChanged += CustomBookmarks_CollectionChanged;

            BackgroundColor = Color.FromHex("#F6F6F6");
            bookPane.WidthRequest = 280;

            bookPane.Children.Add(absoluteLayoutContainer);
            bookPane.Children.Add(this);

        }

        private void CustomBookmarks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateCustomBookmarkView();
        }

        internal void UpdateBookmarkContent()
        {
            if (absoluteLayoutContainer.Parent == null)
            {
                Children.Add(absoluteLayoutContainer);
            }
            if (bookmarkLoadedDocument.Bookmarks != null && bookmarkLoadedDocument.Bookmarks.Count == 0)
            {
                tabView.Items[0].Content = NobookmarksLabel;
            }
            else if (bookmarkLoadedDocument.Bookmarks.Count > 0)
            {
                tabView.Items[0].Content = bookmarkView;
            }
        }
        internal void UpdateCustomBookmarkView()
        {

            if (absoluteLayoutContainer.Parent == null)
            {
                Children.Add(absoluteLayoutContainer);
            }
            if (pdfViewer.CustomBookmarks.Count == 0)
            {
                tabView.Items[1].Content = CustomNobookmarksLabel;
                AddBookmarkButton.IsEnabled = true;
            }
            else if (pdfViewer.CustomBookmarks.Count != 0)
            {
                tabView.Items[1].Content = customBookmarkView;
            }
        }
        private void ContextMenuListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;

            if (e.ItemIndex == 0)
            {
                OnRenameOptions(sender);
            }
            else if (e.ItemIndex == 1)
            {
                OnDeleteOptions(sender);
            }
            
        }

        private void TabView_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        {
            if ((BindingContext as PdfViewerViewModel).IsContextMenuVisible == true)
            {
                (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            }
            foreach (var item in tabView.Items)
            {
                if (e.Index == tabView.Items.IndexOf(item))
                    ((item.HeaderContent as Grid).Children[0] as Label).TextColor = Color.FromHex("#007CEE");
                else
                    ((item.HeaderContent as Grid).Children[0] as Label).TextColor = Color.Black; ;
            }
        }
        private void OnRenameOptions(object obj)
        {
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            PDFViewerCustomToolbar_Desktop.ToggleBookmarkPopup();
            PDFViewerCustomToolbar_Desktop.BookmarkPopup.IsVisible = true; 
            PDFViewerCustomToolbar_Desktop.BookmarkPopup.EditEntry.Text = pdfViewer.CustomBookmarks[this.selectedCustomBookmarkIndex].Name;
            PDFViewerCustomToolbar_Desktop.BookmarkPopup.EditEntry.Focus();                      
        }

        private async void OnDeleteOptions(object obj)
        {
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            this.messageLabel.Text = pdfViewer.CustomBookmarks[selectedCustomBookmarkIndex].Name + "- Deleted";
            if (pdfViewer.PageNumber == pdfViewer.CustomBookmarks[selectedCustomBookmarkIndex].PageNumber)
            {
                AddBookmarkButton.InputTransparent = false;
                AddBookmarkButton.BackgroundColor = Color.FromHex("#007CEE");
                AddBookmarkLabel.Opacity = 1;
            }
            pdfViewer.CustomBookmarks.RemoveAt(selectedCustomBookmarkIndex);            
            if (pdfViewer.CustomBookmarks.Count == 0)
            {
                AddBookmarkButton.InputTransparent = false;
                AddBookmarkButton.BackgroundColor = Color.FromHex("#007CEE");
                AddBookmarkLabel.Opacity = 1;
                UpdateCustomBookmarkView();
            }
            toastMessageFrame.IsVisible = true;
            PDFViewerCustomToolbar_Desktop.PositionToastMessage();           
            await toastMessageFrame.FadeTo(1, 1000);
            await toastMessageFrame.FadeTo(0, 1000);
            
        }        
        private void CustomBookmarkView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           pdfViewer.GoToBookmark(e.Item as Syncfusion.SfPdfViewer.XForms.CustomBookmark);
        }

        private void CustomBookmarkView_Scrolled(object sender, ScrolledEventArgs e)
        {
            this.CustomBookmarkView_ScrollY = e.ScrollY;
        }

        private async void AddBookmarkButton_Clicked(object sender, EventArgs e)
        {
            if ((BindingContext as PdfViewerViewModel).IsContextMenuVisible == true)
            {
                (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            }
            tabView.SelectedIndex = 1;
            pdfViewer.CustomBookmarks.Add(new Syncfusion.SfPdfViewer.XForms.CustomBookmark("Page " + pdfViewer.PageNumber, pdfViewer.PageNumber));
            AddBookmarkButton.InputTransparent = true;
            AddBookmarkButton.BackgroundColor = Color.FromHex("#7BB9F2");
            AddBookmarkLabel.Opacity = 0.7;
            PDFViewerCustomToolbar_Desktop.PositionToastMessage();
            this.messageLabel.Text = pdfViewer.CustomBookmarks.Last().Name + "- Added";
            toastMessageFrame.IsVisible = true;
            await toastMessageFrame.FadeTo(1, 1000);
            await toastMessageFrame.FadeTo(0, 1000);
        }

        private void PopUpMenuButton_Clicked(object sender, EventArgs e)
        {
            this.selectedCustomBookmarkIndex = pdfViewer.CustomBookmarks.IndexOf((Syncfusion.SfPdfViewer.XForms.CustomBookmark)(sender as Button).BindingContext);
            var YOffset= (selectedCustomBookmarkIndex * 40) + (40 * 0.5) - this.CustomBookmarkView_ScrollY + tabView.TabHeight;
            if (YOffset > absoluteLayoutContainer.Height - contextOptionsFrame.Height - 20)
            {
                YOffset = absoluteLayoutContainer.Height - contextOptionsFrame.Height - 20;
            }
            contextOptionsFrame.TranslationY = YOffset;
            if ((BindingContext as PdfViewerViewModel).IsContextMenuVisible==true)
            {
                (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            }
            else
            {
                (BindingContext as PdfViewerViewModel).IsContextMenuVisible = true;
            }
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
                    listViewItemsSource.Add(new ContentBookmark(bookmarkLoadedDocument.Bookmarks[i], false));
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
                    listViewItemsSource.Add(new ContentBookmark(bookmarkBase[i], false));
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
            PdfBookmark bookmark = ((sender as Button).CommandParameter as ContentBookmark).Bookmark;
            navigationQueue.Add(bookmark);
            UpdateBookmarkList(bookmark);
        }

        private void BookmarkView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)

                pdfViewer.GoToBookmark((e.Item as ContentBookmark).Bookmark);
        }


        internal void UpdateBookmarkList(PdfBookmark bookmark)
        {
            if (listViewItemsSource != null && listViewItemsSource.Count > 0)
            {
                for (int i = listViewItemsSource.Count - 1; i >= 0; i--)
                    listViewItemsSource.RemoveAt(i);
            }
            listViewItemsSource.Add(new ContentBookmark(bookmark, true));
            for (int i = 0; i < bookmark.Count; i++)
                listViewItemsSource.Add(new ContentBookmark(bookmark[i], false));
        }

        private  void CloseButton_Clicked(object sender, EventArgs e)
        {
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            if (BindingContext as PdfViewerViewModel != null)
                (BindingContext as PdfViewerViewModel).IsBookMarkVisible = false;
            this.WidthRequest = 0;


        }

    }
    internal class BookmarkContextMenu
    {
        internal BookmarkContextMenu(string iconText,string labelText)
        {
            IconText=iconText;
            LabelText=labelText;
        }
        public string IconText { get; private set; }
        public string LabelText { get; private set; }


    }

}

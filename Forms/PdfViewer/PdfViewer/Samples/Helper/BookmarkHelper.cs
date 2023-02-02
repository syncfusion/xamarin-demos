#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.XForms.TabView;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfPdfViewer
{
    internal class BookmarkToolbar : Grid
    {
        internal AbsoluteLayout absoluteLayoutContainer = new AbsoluteLayout();
        internal ListView bookmarkView;
        internal ListView customBookmarkView;
        List<PdfBookmark> navigationQueue = new List<PdfBookmark>();
        IList<ContentBookmark> listViewItemsSource;
        Syncfusion.SfPdfViewer.XForms.SfPdfViewer pdfViewer;
        Grid parentGrid;
        internal bool isBookmarkPaneVisible = false;
        internal PdfLoadedDocument bookmarkLoadedDocument;
        Syncfusion.XForms.TabView.SfTabView tabView = new Syncfusion.XForms.TabView.SfTabView();
        private Grid tabviewHeader_Content;
        private Grid tabviewHeader_Bookmark;
        internal Frame toastMessageFrame;
        Frame contextOptionsFrame;
        internal Label messageLabel;
        internal SfFontButton AddBookmarkButton;
        StackLayout contextOptions;
        StackLayout RenameTextButton;
        StackLayout DeleteTextButton;
        SfFontButton RenameIcon;
        SfFontButton DeleteIcon;
        Label RenameText;
        Label DeleteText;
        internal int selectedCustomBookmarkIndex;
        private double CustomBookmarkView_ScrollY;
        PDFViewerCustomToolbar_Phone PDFViewerCustomToolbar_Phone;
        PDFViewerCustomToolbar_Tablet PDFViewerCustomToolbar_Tablet;
        Grid tapDetectorGrid;
        internal Grid NobookmarksLabel { get; set; }
        internal Grid CustomNobookmarksLabel { get; set; }

        internal Grid customBookmarkContainer;

        internal BookmarkToolbar(PDFViewerCustomToolbar_Phone sampleView)
        {
            parentGrid = sampleView.parentGrid;
            pdfViewer = sampleView.pdfViewer;
            listViewItemsSource = sampleView.listViewItemsSource;
            PDFViewerCustomToolbar_Phone = sampleView;
            CreateBookmarkToolbar();
        }

        internal BookmarkToolbar(PDFViewerCustomToolbar_Tablet sampleView)
        {
            parentGrid = sampleView.parentGrid;
            pdfViewer = sampleView.pdfViewer;
            listViewItemsSource = sampleView.listViewItemsSource;
            PDFViewerCustomToolbar_Tablet=sampleView;
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

            NobookmarksLabel = new Grid();
            Label label = new Label() { Text = "No Bookmarks", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            NobookmarksLabel.Children.Add(label);


            CustomNobookmarksLabel = new Grid();
            Label customLabel = new Label() { Text = "No Bookmarks", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            CustomNobookmarksLabel.Children.Add(customLabel);

            if (Device.Idiom == TargetIdiom.Tablet)
                Grid.SetColumn(absoluteLayoutContainer, 1);
            Grid.SetRow(absoluteLayoutContainer, 1);
            Children.Add(absoluteLayoutContainer);

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

            customBookmarkView = new ListView(ListViewCachingStrategy.RecycleElement);
            customBookmarkView.SeparatorVisibility = SeparatorVisibility.None;
            customBookmarkView.ItemsSource = pdfViewer.CustomBookmarks;
            customBookmarkView.RowHeight = 60;
            customBookmarkView.Scrolled += CustomBookmarkView_Scrolled;
            customBookmarkView.ItemTapped += CustomBookmarkView_ItemTapped; ;
            customBookmarkView.ItemTemplate = new DataTemplate(() =>
            {
                ViewCell viewCell = new ViewCell();

                Grid viewChild = new Grid() { ColumnSpacing=0,RowSpacing=0, BackgroundColor = Color.White };
                viewChild.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                viewChild.ColumnDefinitions.Add(new ColumnDefinition() { Width = 32 });
                viewChild.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                viewChild.RowDefinitions.Add(new RowDefinition() { Height = 1 });

                Label bookmarkLabel = new Label() { TextColor = Color.FromHex("#000000") };
                bookmarkLabel.Margin = new Thickness(12, 8, 0, 9);
                bookmarkLabel.LineBreakMode = LineBreakMode.TailTruncation;
                bookmarkLabel.VerticalOptions = LayoutOptions.Center;
                bookmarkLabel.SetBinding(Label.TextProperty, "Name");
                bookmarkLabel.FontFamily = "SegoeUI";
                bookmarkLabel.FontSize = 16;
                Grid.SetColumn(bookmarkLabel, 0);
                Grid.SetRow(bookmarkLabel,0);

                SfFontButton popUpMenuButton = new SfFontButton() { TextColor = Color.FromHex("8A000000") ,HorizontalOptions=LayoutOptions.Center,VerticalOptions=LayoutOptions.Center };
                popUpMenuButton.FontSize = 24;
                popUpMenuButton.FontFamily = FontMappingHelper.MoreOptionsFont;
                popUpMenuButton.BackgroundColor = Color.Transparent;
                popUpMenuButton.Text = FontMappingHelper.Moreoptions;
                popUpMenuButton.Clicked += PopUpMenuButton_Clicked; ;
                popUpMenuButton.Margin = new Thickness(0, 10, 12, 10);
                Grid.SetColumn(popUpMenuButton, 1);
                Grid.SetRow(popUpMenuButton, 0);

                Frame bottomBorder = new Frame() { BackgroundColor = Color.FromHex("#000000"), Opacity = 0.12, Margin = 0 };
                Grid.SetRow(bottomBorder, 1);
                Grid.SetColumn(bottomBorder, 0);
                Grid.SetColumnSpan(bottomBorder, 2);

                viewChild.Children.Add(bookmarkLabel);
                viewChild.Children.Add(popUpMenuButton);
                viewChild.Children.Add(bottomBorder);
                viewCell.View = viewChild;

                return viewCell;
            });
            tabviewHeader_Content = new Grid();
            SfFontButton Bookmark_DefaultHeader = new SfFontButton() {ButtonName= "defaultHeader", BackgroundColor =Color.Transparent  };
            Bookmark_DefaultHeader.WidthRequest = 40;
            Bookmark_DefaultHeader.FontFamily = FontMappingHelper.CustomBookmarkFont;
            Bookmark_DefaultHeader.Text = FontMappingHelper.Bookmark_Default;
            Bookmark_DefaultHeader.TextColor = Color.FromHex("#007CEE");
            Bookmark_DefaultHeader.FontSize = 25;
            Bookmark_DefaultHeader.Clicked += Bookmark_DefaultHeader_Clicked;
            Bookmark_DefaultHeader.HorizontalOptions = LayoutOptions.Center;
            Bookmark_DefaultHeader.VerticalOptions = LayoutOptions.Center;
            tabviewHeader_Content.Children.Add(Bookmark_DefaultHeader);
             
            tabviewHeader_Bookmark = new Grid();
            SfFontButton Bookmark_CustomHeader = new SfFontButton() {ButtonName= "customHeader", BackgroundColor = Color.Transparent ,TextColor=Color.FromHex("#000000")};
            Bookmark_CustomHeader.WidthRequest = 40;
            Bookmark_CustomHeader.FontFamily = FontMappingHelper.CustomBookmarkFont;
            Bookmark_CustomHeader.Text = FontMappingHelper.Bookmark_Custom;
            Bookmark_CustomHeader.FontSize = 20;
            Bookmark_CustomHeader.HorizontalOptions = LayoutOptions.Center;
            Bookmark_CustomHeader.VerticalOptions = LayoutOptions.Center;
            Bookmark_CustomHeader.Clicked += Bookmark_CustomHeader_Clicked;
            tabviewHeader_Bookmark.Children.Add(Bookmark_CustomHeader);

            TapGestureRecognizer tapGestureToHideContextMenu = new TapGestureRecognizer();
            tapGestureToHideContextMenu.Tapped += TapGestureToHideContextMenu_Tapped;
            customBookmarkContainer = new Grid();
            customBookmarkContainer.Children.Add(customBookmarkView);
            pdfViewer.CustomBookmarks.CollectionChanged += CustomBookmarks_CollectionChanged;
            if (Device.RuntimePlatform == Device.Android)
            {
                tapDetectorGrid = new Grid();
                double topMargin = customBookmarkView.RowHeight * pdfViewer.CustomBookmarks.Count;                
                tapDetectorGrid.Margin = new Thickness(0, topMargin, 0, 0);
                tapDetectorGrid.GestureRecognizers.Add(tapGestureToHideContextMenu);
                customBookmarkContainer.Children.Add(tapDetectorGrid);
            }
            else
            {
                customBookmarkContainer.GestureRecognizers.Add(tapGestureToHideContextMenu);
            }

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
                    Content = customBookmarkContainer,
                    HeaderContent=tabviewHeader_Bookmark
                },
            };
            tabView.TabHeight = 32;
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                tabView.TabWidth = ((Application.Current.MainPage.Width * 0.4)/ 2 ) - 1;
            }
            else
            {
                tabView.TabWidth = Application.Current.MainPage.Width/2;
            }
            tabView.Items = tabItems;
            tabView.SelectionChanged += TabView_SelectionChanged; 
            AbsoluteLayout.SetLayoutFlags(tabView, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(tabView, new Rectangle(0, 0, 1, 1));
            
            absoluteLayoutContainer.Children.Add(tabView);

            

            toastMessageFrame = new Frame() { IsVisible = false, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.End, CornerRadius = 4, HeightRequest = 32,  BackgroundColor = Color.FromHex("#353535"), Padding = 0, Margin = new Thickness(0, 0, 0, 13) , HasShadow=false};
            messageLabel = new Label() { BackgroundColor = Color.Transparent, HeightRequest = 20, Margin = new Thickness(13, 7, 13, 7), TextColor = Color.FromHex("#FFFFFF"), FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };
            toastMessageFrame.Content = messageLabel;

            AbsoluteLayout.SetLayoutFlags(toastMessageFrame, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(toastMessageFrame, new Rectangle(0.5, 1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));            
            absoluteLayoutContainer.Children.Add(toastMessageFrame);

            AddBookmarkButton = new SfFontButton() { TextColor = Color.White, FontSize = 24 };


            VisualStateGroupList visualStateGroupList = new VisualStateGroupList();
            VisualStateGroup commonStateGroup = new VisualStateGroup();
            VisualState EnabledState = new VisualState() { Name = "Normal" };
            EnabledState.Setters.Add(new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex("#007CEE") });
            VisualState DisabledState = new VisualState() { Name = "Disabled" };
            DisabledState.Setters.Add(new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex("#7BB9F2") });
            DisabledState.Setters.Add(new Setter { Property=Button.TextColorProperty, Value = Color.FromHex("#FFFFFF")});
            AddBookmarkButton.FontFamily = FontMappingHelper.CustomBookmarkFont;
            AddBookmarkButton.Text = FontMappingHelper.Bookmark_Add;
            AddBookmarkButton.CornerRadius = 34;
            AddBookmarkButton.HeightRequest = 68;
            AddBookmarkButton.WidthRequest = 68;
            AddBookmarkButton.Margin = new Thickness(0, 0, 26, 26);
            AddBookmarkButton.Clicked += AddBookmarkButton_Clicked; 
            AbsoluteLayout.SetLayoutFlags(AddBookmarkButton, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(AddBookmarkButton, new Rect(1, 1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));


            commonStateGroup.States.Add(EnabledState);
            commonStateGroup.States.Add(DisabledState);
            visualStateGroupList.Add(commonStateGroup);
            VisualStateManager.SetVisualStateGroups(AddBookmarkButton, visualStateGroupList);

            absoluteLayoutContainer.Children.Add(AddBookmarkButton);

            contextOptionsFrame = new Frame() { HasShadow = false, IsVisible = false, Padding = 1, CornerRadius = 4, HeightRequest = 88, WidthRequest = 149, BackgroundColor = Color.FromHex("#D5D5D5") ,Margin= new Thickness(0,0,22,0) };
            contextOptionsFrame.SetBinding(Frame.IsVisibleProperty, "IsContextMenuVisible");
            Frame contextOptionsInnerFrame = new Frame() { Padding = new Thickness(0, 3, 0, 3), HasShadow = false, CornerRadius = 4, WidthRequest = 147, HeightRequest = 86, BackgroundColor = Color.FromHex("#F6F6F6") };

            contextOptions = new StackLayout() {Spacing=0, Orientation = StackOrientation.Vertical, BackgroundColor = Color.FromHex("#F6F6F6") , Margin=new Thickness(0,4,0,4)};            
            contextOptions.HeightRequest = 80;
            contextOptions.WidthRequest = 147;

            AbsoluteLayout.SetLayoutFlags(contextOptionsFrame, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(contextOptionsFrame, new Rect(1, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            RenameTextButton = new StackLayout() { HeightRequest = 40, WidthRequest = 99, Orientation = StackOrientation.Horizontal, BackgroundColor = Color.Transparent, Padding = 0 };
            DeleteTextButton = new StackLayout() { HeightRequest = 40, WidthRequest = 99, Orientation = StackOrientation.Horizontal, BackgroundColor = Color.Transparent, Padding = 0 };

            RenameIcon = new SfFontButton() { ButtonName="renameBookmarkButton", WidthRequest=40 , HeightRequest=40, Text = FontMappingHelper.RenameBookmark, TextColor = Color.FromHex("#000000"), BackgroundColor = Color.Transparent, FontSize = 16, Margin =0 , HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            RenameIcon.FontFamily = FontMappingHelper.CustomBookmarkFont;
            RenameIcon.Clicked += RenameIcon_Clicked; 

            DeleteIcon = new SfFontButton() {ButtonName="deleteBookmarkButton", WidthRequest=40,HeightRequest=40, Text = FontMappingHelper.DeleteBookmark, TextColor = Color.FromHex("#000000"), BackgroundColor = Color.Transparent, FontSize = 16, Margin =0, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center  };
            DeleteIcon.FontFamily = FontMappingHelper.CustomBookmarkFont;
            DeleteIcon.Clicked += DeleteIcon_Clicked; 


            RenameText = new Label() { Text = "Rename", TextColor = Color.FromHex("#000000"), BackgroundColor = Color.Transparent, FontSize = 12, WidthRequest = 59, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center };
            DeleteText = new Label() { Text = "Delete", TextColor = Color.FromHex("#000000"), BackgroundColor = Color.Transparent, FontSize = 12, WidthRequest = 59, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center };

            var renameTapGestureRecognizer = new TapGestureRecognizer();
            var deleteTapGestureRecognizer = new TapGestureRecognizer();
            RenameTextButton.GestureRecognizers.Add(renameTapGestureRecognizer);
            DeleteTextButton.GestureRecognizers.Add(deleteTapGestureRecognizer);
            Command renameOptionsCommand = new Command<object>(OnRenameOptions, CanExecute);
            Command deleteOptionsCommand = new Command<object>(OnDeleteOptions, CanExecute);
            renameTapGestureRecognizer.Command = renameOptionsCommand;
            deleteTapGestureRecognizer.Command = deleteOptionsCommand;

            RenameTextButton.Children.Add(RenameIcon);
            RenameTextButton.Children.Add(RenameText);
            DeleteTextButton.Children.Add(DeleteIcon);
            DeleteTextButton.Children.Add(DeleteText);

            contextOptions.Children.Add(RenameTextButton);
            contextOptions.Children.Add(DeleteTextButton);

            contextOptionsInnerFrame.Content = contextOptions;
            contextOptionsFrame.Content = contextOptionsInnerFrame;
            contextOptionsFrame.IsVisible = false;
            absoluteLayoutContainer.Children.Add(contextOptionsFrame);


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

        internal void UpdateBookmarkContent()
        {
            if (absoluteLayoutContainer.Parent == null)
            {
                Children.Add(absoluteLayoutContainer);
            }
            if (bookmarkLoadedDocument !=null && bookmarkLoadedDocument.Bookmarks != null && bookmarkLoadedDocument.Bookmarks.Count == 0)
            {
                tabView.Items[0].Content = NobookmarksLabel;
            }
            else if (bookmarkLoadedDocument != null && bookmarkLoadedDocument.Bookmarks.Count > 0)
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
               tabView.Items[1].Content = customBookmarkContainer;
            }
        }
        private void Bookmark_CustomHeader_Clicked(object sender, EventArgs e)
        {
            tabView.SelectedIndex = 1;
        }

        private void Bookmark_DefaultHeader_Clicked(object sender, EventArgs e)
        {
            tabView.SelectedIndex = 0;
        }

        private bool CanExecute(object parameter)
        {
            return true;
        }
        private void CustomBookmarks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                double topMargin = customBookmarkView.RowHeight * pdfViewer.CustomBookmarks.Count;
                tapDetectorGrid.Margin = new Thickness(0, topMargin, 0, 0);
            }            
            UpdateCustomBookmarkView();
        }
        private void TapGestureToHideContextMenu_Tapped(object sender, EventArgs e)
        {
            contextOptionsFrame.IsVisible = false;
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
        }
        private void OnRenameOptions(object obj)
        {
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            if (Device.Idiom == TargetIdiom.Phone)
            {
                Grid.SetRow(PDFViewerCustomToolbar_Phone.editBookmarkPopup, 0);
                Grid.SetColumn(PDFViewerCustomToolbar_Phone.editBookmarkPopup, 0);
                Grid.SetRowSpan(PDFViewerCustomToolbar_Phone.editBookmarkPopup, 2);
                Children.Add(PDFViewerCustomToolbar_Phone.editBookmarkPopup);
                PDFViewerCustomToolbar_Phone.editBookmarkPopup.EditEntry.Text = pdfViewer.CustomBookmarks[selectedCustomBookmarkIndex].Name;
                PDFViewerCustomToolbar_Phone.editBookmarkPopup.EditEntry.Focus();
                PDFViewerCustomToolbar_Phone.editBookmarkPopup.EditEntry.CursorPosition = 0;
                PDFViewerCustomToolbar_Phone.editBookmarkPopup.EditEntry.SelectionLength= PDFViewerCustomToolbar_Phone.editBookmarkPopup.EditEntry.Text.Length;
                PDFViewerCustomToolbar_Phone.editBookmarkPopup.IsVisible = true;
            }
            else
            {
                PDFViewerCustomToolbar_Tablet.ToggleBookmarkPopup();
                PDFViewerCustomToolbar_Tablet.editBookmarkPopup.EditEntry.Text = pdfViewer.CustomBookmarks[selectedCustomBookmarkIndex].Name;
                PDFViewerCustomToolbar_Tablet.editBookmarkPopup.EditEntry.Focus();
                PDFViewerCustomToolbar_Tablet.editBookmarkPopup.EditEntry.CursorPosition = 0;
                PDFViewerCustomToolbar_Tablet.editBookmarkPopup.EditEntry.SelectionLength= PDFViewerCustomToolbar_Tablet.editBookmarkPopup.EditEntry.Text.Length;
                PDFViewerCustomToolbar_Tablet.editBookmarkPopup.IsVisible = true;
            }            
            contextOptionsFrame.IsVisible = false;
        }
        private async void OnDeleteOptions(object obj)
        {
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            this.messageLabel.Text = pdfViewer.CustomBookmarks[selectedCustomBookmarkIndex].Name + "- Deleted";
            if (pdfViewer.PageNumber == pdfViewer.CustomBookmarks[selectedCustomBookmarkIndex].PageNumber)
            {
                AddBookmarkButton.IsEnabled = true;
            }
            pdfViewer.CustomBookmarks.RemoveAt(selectedCustomBookmarkIndex);
            if (pdfViewer.CustomBookmarks.Count == 0)
            {
                AddBookmarkButton.IsEnabled = true;
                UpdateCustomBookmarkView();
            }                      
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                PDFViewerCustomToolbar_Tablet.PositionToastMessage();
            }
            toastMessageFrame.IsVisible = true;
            contextOptionsFrame.IsVisible = false;
            await toastMessageFrame.FadeTo(1, 1000);
            await toastMessageFrame.FadeTo(0, 1000);
            
        }
        private void CustomBookmarkView_Scrolled(object sender, ScrolledEventArgs e)
        {
            CustomBookmarkView_ScrollY = e.ScrollY;
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
        }

        private void DeleteIcon_Clicked(object sender, EventArgs e)
        {
            OnDeleteOptions(sender);
        }

        private void RenameIcon_Clicked(object sender, EventArgs e)
        {
            OnRenameOptions(sender);
        }

        private async void AddBookmarkButton_Clicked(object sender, EventArgs e)
        {
            pdfViewer.CustomBookmarks.Add(new Syncfusion.SfPdfViewer.XForms.CustomBookmark("Page "+ pdfViewer.PageNumber ,pdfViewer.PageNumber));
            tabView.SelectedIndex = 1;
            AddBookmarkButton.IsEnabled = false;
            toastMessageFrame.IsVisible = true;
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                PDFViewerCustomToolbar_Tablet.PositionToastMessage();
            }
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            this.messageLabel.Text = pdfViewer.CustomBookmarks.Last().Name + "- Added";
            await toastMessageFrame.FadeTo(1, 1000);
            await toastMessageFrame.FadeTo(0, 1000);
        }

        private void TabView_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        {
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            foreach (var item in tabView.Items)
            {
                if (e.Index == tabView.Items.IndexOf(item))
                    ((item.HeaderContent as Grid).Children[0] as Button).TextColor = Color.FromHex("#007CEE");
                else
                    ((item.HeaderContent as Grid).Children[0] as Button).TextColor = Color.Black; ;
            }
        }

        private void PopUpMenuButton_Clicked(object sender, EventArgs e)
        {
            contextOptionsFrame.IsVisible = true;
            this.selectedCustomBookmarkIndex = pdfViewer.CustomBookmarks.IndexOf((Syncfusion.SfPdfViewer.XForms.CustomBookmark)(sender as Button).BindingContext);
            var YOffset = (selectedCustomBookmarkIndex * 60) + (60 * 0.5) - this.CustomBookmarkView_ScrollY + tabView.TabHeight;
            if (YOffset > absoluteLayoutContainer.Height - contextOptionsFrame.Height - 20)
            {
                YOffset = absoluteLayoutContainer.Height - contextOptionsFrame.Height - 20;
            }
            contextOptionsFrame.TranslationY = YOffset;
            if ((BindingContext as PdfViewerViewModel).IsContextMenuVisible)
                (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;           
            else
                 (BindingContext as PdfViewerViewModel).IsContextMenuVisible = true;
 
        }

        private void CustomBookmarkView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            pdfViewer.GoToBookmark(e.Item as Syncfusion.SfPdfViewer.XForms.CustomBookmark);

            if (Device.Idiom == TargetIdiom.Phone)
            {
                parentGrid.Children.Remove(this);
                isBookmarkPaneVisible = false;               
            }
            (sender as ListView).SelectedItem = null;
        }

        //Handles the click event of the close button on bookmark toolbar in tablet
        private void BookmarkCloseButton_Clicked(object sender, EventArgs e)
        {
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            this.WidthRequest = 0;
            isBookmarkPaneVisible = false;
        }

		
        private void BookmarkView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
			//Obtain the bookmark from the listview item and navigate to its destination
            pdfViewer.GoToBookmark((e.Item as ContentBookmark).Bookmark);
			
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
                    listViewItemsSource.Add(new ContentBookmark(bookmarkLoadedDocument.Bookmarks[i], false));
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
                listViewItemsSource.Add(new ContentBookmark(bookmarkBase[i], false));
        }

		//Update the listview with new bookmarks when the backtoparent or expand button is clicked
        internal void UpdateBookmarkList(PdfBookmark bookmark)
        {
            listViewItemsSource.Clear();
            listViewItemsSource.Add(new ContentBookmark(bookmark, true));
            for (int i = 0; i < bookmark.Count; i++)
                listViewItemsSource.Add(new ContentBookmark(bookmark[i], false));
        }

		//Handles the click event of the expand button of a bookmark. The expand button is visible only for bookmark with children
        private void BookmarkExpand_Clicked(object sender, EventArgs e)
        {
            PdfBookmark bookmark = ((sender as SfFontButton).CommandParameter as ContentBookmark).Bookmark;
            navigationQueue.Add(bookmark);
            UpdateBookmarkList(bookmark);
        }

		//Handles the click event of the back button on the bookmark toolbar in phone
        private void BookmarkPaneBackButton_Clicked(object sender, EventArgs e)
        {
            (BindingContext as PdfViewerViewModel).IsContextMenuVisible = false;
            contextOptionsFrame.IsVisible = false;
            //XAMARIN-44384
            if (Device.Idiom == TargetIdiom.Phone)
            {
                if (PDFViewerCustomToolbar_Phone?.editBookmarkPopup != null)
                {
                    Children?.Remove(PDFViewerCustomToolbar_Phone.editBookmarkPopup);
                }
            }
            parentGrid.Children.Remove(this);
            isBookmarkPaneVisible = false;
        }
    }

	//Class that holds the bookmark data. 
    internal class ContentBookmark : INotifyPropertyChanged
    {
        private string desktopExpandButtonIcon = "\ue702";

        public event PropertyChangedEventHandler PropertyChanged; 

        public PdfBookmark Bookmark { get; set; }
        internal ContentBookmark(PdfBookmark bookmark, bool isBackToParentButtonVisible)
        {
            Bookmark = bookmark;
            IsBackToParentButtonVisible = isBackToParentButtonVisible;
        }

        internal ContentBookmark(PdfBookmark bookmark)
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

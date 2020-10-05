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
using CoreGraphics;
using Foundation;
using Syncfusion.Pdf.Interactive;
using UIKit;

namespace SampleBrowser
{
    internal class BookmarkToolbar : UIView
    {
        internal UITableView bookmarkListView;
        private UILabel title;
        private UIButton backButton, bookmarkCloseButton;
        private UIView border, titleContainer;
        internal CustomToolbar parentView;
        internal BookmarkToolbar(CustomToolbar parent)
        {
            parentView = parent;
            border = new UIView();
            border.BackgroundColor = UIColor.LightGray;

            titleContainer = new UIView();
            titleContainer.BackgroundColor = new UIColor(red: 0.97f, green: 0.97f, blue: 0.97f, alpha: 1.0f);

			//Title label that displays "Bookmarks"
            title = new UILabel();
            title.Text = "Bookmarks";
            title.Font = UIFont.BoldSystemFontOfSize(14);
            title.TextColor = UIColor.Black;
            title.TextAlignment = UITextAlignment.Left;

			//Button to remove the bookmark toolbar (mobile only)
            backButton = new UIButton();
            backButton.AccessibilityIdentifier = "backbutton";
            backButton.Font = parentView.bookmarkFont;
            backButton.SetTitle("\ue709", UIControlState.Normal);
            backButton.SetTitleColor(UIColor.FromRGB(113, 113, 113), UIControlState.Normal);
            backButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            backButton.VerticalAlignment = UIControlContentVerticalAlignment.Center;
            backButton.TouchUpInside += BackButton_TouchUpInside;

            bookmarkCloseButton = new UIButton();
            bookmarkCloseButton.AccessibilityIdentifier = "bookmarkCloseButton";
            bookmarkCloseButton.Font = parentView.highFont;
            bookmarkCloseButton.SetTitle("\uE70f", UIControlState.Normal);
            bookmarkCloseButton.SetTitleColor(UIColor.FromRGB(113, 113, 113), UIControlState.Normal);
            bookmarkCloseButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            bookmarkCloseButton.VerticalAlignment = UIControlContentVerticalAlignment.Center;
            bookmarkCloseButton.TouchUpInside += bookmarkCloseButton_TouchUpInside; ;

            bookmarkListView = new UITableView();
            bookmarkListView.RowHeight = 60;
            bookmarkListView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            bookmarkListView.Source = new BookmarkListSource(parentView, bookmarkListView);
            titleContainer.AddSubview(title);
            this.AddSubview(bookmarkListView);
            this.AddSubview(titleContainer);
			
			//Add back button or left border only if the device is mobile or tablet respectively
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom != UIUserInterfaceIdiom.Pad)
                titleContainer.AddSubview(backButton);
            else
            {
                this.AddSubview(border);
                this.AddSubview(bookmarkCloseButton);
            }
        }

        //Handle the click event of close button on the title bar of tablet bookmark toolbar
        private void bookmarkCloseButton_TouchUpInside(object sender, EventArgs e)
        {
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                parentView.isBookmarkPaneVisible = false;

                //Remove the bookmark toolbar only if the device is a tablet
                if (parentView.bookmarkToolbar.Superview != null)
                    parentView.bookmarkToolbar.RemoveFromSuperview();
            }
        }

        //Handles the click event of back button on the title bar of mobile bookmark toolbar
        private void BackButton_TouchUpInside(object sender, EventArgs e)
        {
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom != UIUserInterfaceIdiom.Pad)
            {
                parentView.isBookmarkPaneVisible = false;
				
				//Remove the bookmark toolbar only if the device is not a tablet
                if (parentView.bookmarkToolbar.Superview != null)
                    parentView.bookmarkToolbar.RemoveFromSuperview();
            }
        }

		//Sets the frames of the title, back button, tableview and left border(tablet only)
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom != UIUserInterfaceIdiom.Pad)
            {
                backButton.Frame = new CGRect(0, 0, 50, 60);
                title.Frame = new CGRect(50, 0, Frame.Width - 50, 60);
                titleContainer.Frame = new CGRect(0, 0, Frame.Width, 60);
                bookmarkListView.Frame = new CGRect(0, 60, Frame.Width, Frame.Height - 60);
            }
            else
            {
                bookmarkCloseButton.Frame = new CGRect(Frame.Width - 50.5, 0, 50, 60);
                title.Frame = new CGRect(50.5, 0, Frame.Width - 50.5, 60);
                titleContainer.Frame = new CGRect(0.5, 0, Frame.Width - 0.5, 60);
                border.Frame = new CGRect(0, 0, 0.5, Frame.Height);
                bookmarkListView.Frame = new CGRect(0.5, 60, Frame.Width - 0.5, Frame.Height - 60);
            }
        }
    }

	//Class that holds the bookmark data and properties that determin whether the expand button or back button should be visible. 
    internal class CustomBookmark
    {
        public PdfBookmark Bookmark { get; set; }
        internal CustomBookmark(PdfBookmark bookmark, bool isBackToParentButtonVisible)
        {
            Bookmark = bookmark;
            IsBackToParentButtonVisible = isBackToParentButtonVisible;
        }
		
		//Expand button will be visible only if the current bookmark has children or it is not at the top of the list. 
        public bool IsExpandButtonVisible
        {
            get
            {
                return Bookmark.Count != 0 && !IsBackToParentButtonVisible;
            }
        }

		//Backtoparent button will be visible for the cell at the top of the list. 
        public bool IsBackToParentButtonVisible { get; set; }
    }

	//Source class for the tableview that lists bookmarks
    internal class BookmarkListSource : UITableViewSource
    {
        UITableView tableView;
		
		//Font that defines the icons for the bookmark toolbar buttons
        UIFont bookmarkFont;
        List<CustomBookmark> items;
        CustomToolbar parentView;
        private List<PdfBookmark> navigationQueue = new List<PdfBookmark>();
        internal BookmarkListSource(CustomToolbar parent, UITableView table)
        {
            parentView = parent;
            items = parentView.listViewItemsSource;
            tableView = table;
            bookmarkFont = parent.bookmarkFont;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            BookmarkCell cell = tableView.DequeueReusableCell("ListCell") as BookmarkCell;
            if (cell == null)
                cell = new BookmarkCell((NSString)"ListCell", bookmarkFont, parentView, navigationQueue);
            CustomBookmark item = items[indexPath.Row];
			
			//hide the backtoparent button based on the property of the CustomBookmark class
            cell.backToParentButton.Hidden = !item.IsBackToParentButtonVisible;
            cell.backToParentButton.Tag = indexPath.Row;
			
			//hide the expand button based on the property of the CustomBookmark class
            cell.expandButton.Hidden = !item.IsExpandButtonVisible;
            cell.expandButton.Tag = indexPath.Row;
            cell.title.Text = item.Bookmark.Title;
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
			//Obtain the selected bookmark and navigate to its destination
            parentView.pdfViewerControl.GoToBookmark(items[indexPath.Row].Bookmark);
			
			//Remove the bookmark toolbar from view for only mobile device
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom != UIUserInterfaceIdiom.Pad)
            {
                parentView.isBookmarkPaneVisible = false;
                if(parentView.bookmarkToolbar.Superview != null)
                    parentView.bookmarkToolbar.RemoveFromSuperview();
            }
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return items.Count;
        }
    }

	//Class that defines the cell design of the table view
    internal class BookmarkCell : UITableViewCell
    {
        internal UIButton backToParentButton, expandButton;
        private UIView customSeparatorBorder;
        internal UILabel title;
        CustomToolbar parentView;
		//List to maintain the previous bookmark list 
        private List<PdfBookmark> navigationQueue;
        internal BookmarkCell(NSString cellID, UIFont bookmarkFont, CustomToolbar parent, List<PdfBookmark> forwardQue) : base(UITableViewCellStyle.Default, cellID)
        {
            this.navigationQueue = forwardQue;
            parentView = parent;
            title = new UILabel();
            title.Font = UIFont.SystemFontOfSize(14);
            title.TextColor = UIColor.Black;
            title.BackgroundColor = UIColor.Clear;

			//Button to navigate to the parent bookmark of the current bookmark list
            backToParentButton = new UIButton();
            backToParentButton.AccessibilityIdentifier = "backToParentButton";
            backToParentButton.Font = bookmarkFont;
            backToParentButton.SetTitle("\ue709", UIControlState.Normal);
            backToParentButton.SetTitleColor(UIColor.FromRGB(113, 113, 113), UIControlState.Normal);
            backToParentButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            backToParentButton.TouchUpInside += BackToParentButton_TouchUpInside;

			//Button to navigate to the children of a bookmark. It is visible only the bookmark has children
            expandButton = new UIButton();
            expandButton.AccessibilityIdentifier = "expandButton";
            expandButton.Font = bookmarkFont;
            expandButton.SetTitle("\ue704", UIControlState.Normal);
            expandButton.SetTitleColor(UIColor.FromRGB(113, 113, 113), UIControlState.Normal);
            expandButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            expandButton.TouchUpInside += ExpandButton_TouchUpInside;

			//Border that separates the tableview cells
            customSeparatorBorder = new UIView();
            customSeparatorBorder.BackgroundColor = UIColor.LightGray;

            ContentView.Add(backToParentButton);
            ContentView.Add(title);
            ContentView.Add(expandButton);
            ContentView.Add(customSeparatorBorder);
        }

        private void BackToParentButton_TouchUpInside(object sender, EventArgs e)
        {
            PdfBookmark bookmark = parentView.listViewItemsSource[0].Bookmark;
            parentView.listViewItemsSource.Clear();
            if (navigationQueue.Count < 2)
            {
                for (int i = 0; i < parentView.loadedDocument.Bookmarks.Count; i++)
                    parentView.listViewItemsSource.Add(new CustomBookmark(parentView.loadedDocument.Bookmarks[i], false));
                parentView.bookmarkToolbar.bookmarkListView.ReloadData();
				if(navigationQueue.Count != 0)
					navigationQueue.RemoveAt(navigationQueue.Count - 1);
            }
            else
            {
				//Get the bookmark that was added to the list when the expand button was clicked
                PdfBookmark parentBookmark = navigationQueue[navigationQueue.Count - 2];
                navigationQueue.RemoveAt(navigationQueue.Count - 2);
                UpdateBookmarkList(parentBookmark);
            }
        }

        private void ExpandButton_TouchUpInside(object sender, EventArgs e)
        {
            int index = (int)(sender as UIButton).Tag;
            PdfBookmark bookmark = parentView.listViewItemsSource[index].Bookmark;
			
			//Add the current bookmark so that it can be used when back button is clicked later
            navigationQueue.Add(bookmark);
            UpdateBookmarkList(bookmark);
        }

		//Updates the tableview with the new bookmark list when backtoparent button or expand button is clicked
        internal void UpdateBookmarkList(PdfBookmark bookmark)
        {
            parentView.listViewItemsSource.Clear();
            parentView.listViewItemsSource.Add(new CustomBookmark(bookmark, true));
            for (int i = 0; i < bookmark.Count; i++)
                parentView.listViewItemsSource.Add(new CustomBookmark(bookmark[i], false));
            parentView.bookmarkToolbar.bookmarkListView.ReloadData();
        }

		//Sets the frame of the title, backtoparent button, expandbutton and the cell separator border. 
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            title.Frame = new CoreGraphics.CGRect(50, 0, ContentView.Bounds.Width - 100, ContentView.Bounds.Height - 0.5);
            backToParentButton.Frame = new CoreGraphics.CGRect(0, 0, 50, ContentView.Bounds.Height - 0.5);
            expandButton.Frame = new CoreGraphics.CGRect(ContentView.Bounds.Width - 50, 0, 50, ContentView.Bounds.Height - 0.5);
            customSeparatorBorder.Frame = new CGRect(0, ContentView.Bounds.Height - 0.5, ContentView.Bounds.Width, 0.5);
        }
    }

}
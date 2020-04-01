#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Syncfusion.SfDataGrid;
using Syncfusion.iOS.PopupLayout;
using UIKit;

namespace SampleBrowser
{
	public class PopupCustomizations : SampleView
    {
        #region Fields

        internal static SfDataGrid datagrid;
        TicketBookingViewModel viewModel;
        SfPopupLayout initialPopup;
        UIView mainView;		


        #endregion
        public PopupCustomizations()
		{
            CreateMainView();
            CreateDataGrid();
            this.AddSubview(mainView);
        }

        private void CreateMainView()
        {
            mainView = new UIView();

        }

        private void CreateDataGrid()
        {
            datagrid = new SfDataGrid();
            viewModel = new TicketBookingViewModel();
            datagrid.AutoGenerateColumns = false;
            datagrid.ColumnSizer = ColumnSizer.Star;
            datagrid.RowHeight = 117;
            datagrid.GridLoaded += datagrid_GridLoaded; 

            GridTextColumn movieList = new GridTextColumn();
            movieList.HeaderText = "Movies List";
            movieList.HeaderTextAlignment = UIKit.UITextAlignment.Center;
            movieList.UserCellType = typeof(MovieTile);

            datagrid.Columns.Add(movieList);
            datagrid.ItemsSource = viewModel.TheaterInformation;
            mainView.AddSubview(datagrid);
        }

        private void datagrid_GridLoaded(object sender, GridLoadedEventArgs e)
        {
            DisplayInitialPopup();
        }

        private void DisplayInitialPopup()
        {
            initialPopup = new SfPopupLayout();
            initialPopup.PopupView.AppearanceMode = AppearanceMode.OneButton;
            initialPopup.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.White;
            initialPopup.PopupView.FooterHeight = initialPopup.PopupView.FooterHeight - 10;
            initialPopup.PopupView.ShowFooter = true;
            initialPopup.PopupView.ShowCloseButton = false;
            initialPopup.PopupView.HeaderTitle = "Book tickets !";
            initialPopup.PopupView.AcceptButtonText = "OK";
            initialPopup.StaysOpen = true;
            UILabel messageView = new UILabel();
            messageView.Text = "Click on the book button to start booking tickets";
            messageView.TextColor = UIColor.Black;
            messageView.LineBreakMode = UILineBreakMode.WordWrap;
            messageView.Lines = 5;
            messageView.TextAlignment = UITextAlignment.Center;
            messageView.BackgroundColor = UIColor.White;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                initialPopup.PopupView.PopupStyle.HeaderFontSize = 14;
                messageView.Font = UIFont.PreferredCaption1;
                initialPopup.PopupView.Frame = new CGRect(-1, -1, (UIScreen.MainScreen.ApplicationFrame.Width / 10) * 8, 180);
            }
            else
            {
                initialPopup.PopupView.PopupStyle.HeaderFontSize = 20;
                messageView.Font = UIFont.PreferredBody;
                initialPopup.PopupView.Frame = new CGRect(-1, -1, -1, 200);
            }
            initialPopup.PopupView.ContentView = messageView;
            initialPopup.Show();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            mainView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
			datagrid.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
        }
    }
}

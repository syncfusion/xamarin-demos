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
	public class TheaterTile : GridCell
	{
		TheaterLayout theaterLayout;
		UIImageView infoImage;
		UILabel theaterTitle;
		UILabel theaterLocation;
        UILabel timing1;
		UILabel timing2;
        UILabel overlayTags;
        SfPopupLayout infopopup;
        SfPopupLayout termsAndConditionsPopup;
		object rowData;
		SfDataGrid dataGrid;
		UILabel message;

		public TheaterTile()
		{
			theaterLayout = new TheaterLayout();

			infoImage = new UIImageView();
            infoImage.Alpha = 0.54f;
			infoImage.UserInteractionEnabled = true;
			var tapGesture = new UITapGestureRecognizer(DisplayInfo) { NumberOfTapsRequired = 1 };
			infoImage.AddGestureRecognizer(tapGesture);

			theaterTitle = new UILabel();
			theaterTitle.Font = UIFont.PreferredCaption1;

			theaterLocation = new UILabel();
			theaterLocation.Font = UIFont.PreferredFootnote;
			theaterLocation.TextColor = UIColor.LightGray;

			timing1 = new UILabel();
			timing1.TextColor = UIColor.FromRGB(0, 124, 238);
			timing1.Font = UIFont.PreferredCaption2;
			timing1.TextAlignment = UITextAlignment.Center;
			timing1.Layer.BorderColor = UIColor.FromRGBA(0, 124, 238, 26).CGColor;
			timing1.Layer.BorderWidth = 0.5f;
			timing1.UserInteractionEnabled = true;
			var timingTapGesture = new UITapGestureRecognizer(TimingTapped) { NumberOfTapsRequired = 1 };
			timing1.AddGestureRecognizer(timingTapGesture);

			timing2 = new UILabel();
			timing2.TextColor = UIColor.FromRGB(0, 124, 238);
			timing2.Font = UIFont.PreferredCaption2;
			timing2.TextAlignment = UITextAlignment.Center;
			timing2.Layer.BorderColor = UIColor.FromRGBA(0, 124, 238, 26).CGColor;
			timing2.UserInteractionEnabled = true;
			var timingTapGesture2 = new UITapGestureRecognizer(TimingTapped) { NumberOfTapsRequired = 1 };
			timing2.AddGestureRecognizer(timingTapGesture2);
			timing2.Layer.BorderWidth = 0.5f;

			theaterLayout.AddSubview(theaterTitle);
			theaterLayout.AddSubview(theaterLocation);
			theaterLayout.AddSubview(timing1);
			theaterLayout.AddSubview(timing2);
			theaterLayout.AddSubview(infoImage);
			this.AddSubview(theaterLayout);
			this.CanRenderUnLoad = false;
		}

		private void TimingTapped()
		{
            DisplayTermsAndCondtionsPopup();
        }

        private void DisplayTermsAndCondtionsPopup()
        {
            termsAndConditionsPopup = new SfPopupLayout();
            termsAndConditionsPopup.IsOpen = false;
            termsAndConditionsPopup.PopupView.HeaderTitle = "Terms & Conditions";
            termsAndConditionsPopup.PopupView.BackgroundColor = UIColor.White;
            termsAndConditionsPopup.PopupView.ShowHeader = true;
            termsAndConditionsPopup.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.White;
            UIView view = new UIView();
            message = new UILabel();
            view.BackgroundColor = UIColor.White;
            message.TextColor = UIColor.Gray;
            message.Font = UIFont.SystemFontOfSize(14);
            message.AutoresizingMask = UIViewAutoresizing.All;
            termsAndConditionsPopup.PopupView.ShowCloseButton = false;
            view.AddSubview(message);
            termsAndConditionsPopup.PopupView.PopupStyle.BorderColor = UIColor.LightGray;
            termsAndConditionsPopup.PopupView.AppearanceMode = AppearanceMode.TwoButton;
            termsAndConditionsPopup.PopupView.HeaderHeight = 40;
            termsAndConditionsPopup.PopupView.FooterHeight = 40;
            termsAndConditionsPopup.PopupView.ShowFooter = true;
            message.Text = "1. Children below the age of 18 cannot be admitted for movies certified A. \n2. Please carry proof of age for movies certified A. \n3. Drinking and alcohol is strictly prohibited inside the premises. \n4. Please purchase tickets for children above age of 3.";
            message.Lines = 10;
            message.TextAlignment = UITextAlignment.Left;
            message.LineBreakMode = UILineBreakMode.WordWrap;
            termsAndConditionsPopup.PopupView.AcceptButtonText = "Accept";
            termsAndConditionsPopup.PopupView.DeclineButtonText = "Decline";
            termsAndConditionsPopup.StaysOpen = true;
            termsAndConditionsPopup.PopupView.ContentView = view;
            termsAndConditionsPopup.PopupView.PopupStyle.AcceptButtonTextColor = UIColor.FromRGB(0, 124, 238);
            termsAndConditionsPopup.PopupView.PopupStyle.DeclineButtonTextColor = UIColor.FromRGB(0, 124, 238);
            termsAndConditionsPopup.PopupView.PopupStyle.AcceptButtonBackgroundColor = UIColor.White;
            termsAndConditionsPopup.PopupView.PopupStyle.DeclineButtonBackgroundColor = UIColor.White;
            termsAndConditionsPopup.PopupView.AcceptButtonClicked += PopupView_AcceptButtonClicked;
            termsAndConditionsPopup.PopupView.AppearanceMode = AppearanceMode.TwoButton;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                termsAndConditionsPopup.PopupView.PopupStyle.HeaderFontSize = 14;
                message.Font = UIFont.PreferredCaption1;
                termsAndConditionsPopup.PopupView.Frame = new CGRect(-1, -1, this.DataColumn.Renderer.DataGrid.Frame.Width - 20, this.DataColumn.Renderer.DataGrid.Frame.Height / 1.75);
            }
            else
            {
                termsAndConditionsPopup.PopupView.PopupStyle.HeaderFontSize = 20;
                message.Font = UIFont.PreferredBody;
                termsAndConditionsPopup.PopupView.Frame = new CGRect(-1, -1, (this.DataColumn.Renderer.DataGrid.Frame.Width / 10) *6, this.DataColumn.Renderer.DataGrid.Frame.Height / 3);
            }
            termsAndConditionsPopup.IsOpen = true;
            message.Frame = new CGRect(10, 0, termsAndConditionsPopup.PopupView.Frame.Width - 20, view.Frame.Height);
        }

        private void PopupView_AcceptButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (termsAndConditionsPopup.PopupView.AcceptButtonText == "Accept")
            {
                termsAndConditionsPopup.PopupView.ContentView = CreateSeatSelectionPage();
                termsAndConditionsPopup.StaysOpen = true;
                e.Cancel = true;
            }
            else if(termsAndConditionsPopup.PopupView.AcceptButtonText == "Proceed")
            {
                overlayTags = new UILabel();
                overlayTags.Hidden = false;
                overlayTags.Text = "Tickets booked successfully";
                overlayTags.Layer.CornerRadius = 20f;
                overlayTags.TextColor = UIColor.White;
                overlayTags.TextAlignment = UITextAlignment.Center;
                overlayTags.ClipsToBounds = true;
                overlayTags.Font = UIFont.SystemFontOfSize(14);
                overlayTags.BackgroundColor = UIColor.FromRGB(101.0f / 255.0f, 101.0f / 255.0f, 101.0f / 255.0f);
                overlayTags.Layer.ZPosition = 1000;
                dataGrid.Superview.AddSubview(overlayTags);
                overlayTags.Frame = new CoreGraphics.CGRect((dataGrid.Superview.Frame.Right / 2) - 100, dataGrid.Superview.Frame.Bottom - 20, 200, 40);

                UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveLinear, () =>
                {
                    overlayTags.Alpha = 1.0f;
                },
                    () =>
                    {
                        UIView.Animate(3.0, () =>
                        {
                            overlayTags.Alpha = 0.0f;
                        });
                    }
                );
            }

        }

        private UIView CreateSeatSelectionPage()
        {
            UIView seatSelectionMainLayout = new UIView();
            seatSelectionMainLayout.BackgroundColor = UIColor.White; 

            SeatSelectionLayout numberOfSeatsLayout = new SeatSelectionLayout(termsAndConditionsPopup); 
            numberOfSeatsLayout.Frame = new CGRect(5, 5, termsAndConditionsPopup.PopupView.Frame.Width - 10, 42);

            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("1"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("2"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("3"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("4"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("5"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("6"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("7"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("8"));

            UILabel title2 = new UILabel();
            title2.Text = "Select your seat class";
            title2.TextColor = UIColor.Black;
            title2.Font = UIFont.SystemFontOfSize(14);
            title2.Frame = new CGRect(15, 92, termsAndConditionsPopup.PopupView.Frame.Width, 16);

            UILabel clas = new UILabel();
            clas.Text = "Silver";
            clas.TextColor = UIColor.Gray;
            clas.Font = UIFont.PreferredCaption1;
            clas.Frame = new CGRect(15, 133, 60, 20);

            UILabel cost = new UILabel();
            cost.Text = "$ 19.69";
            cost.TextColor = UIColor.Black;
            cost.Font = UIFont.PreferredCaption1;
            cost.Frame = new CGRect(termsAndConditionsPopup.PopupView.Frame.Width /2 - 60, 133, 60, 20);


            UILabel avail = new UILabel();
            avail.Text = "Available";
            avail.TextColor = UIColor.Green;
            avail.Font = UIFont.PreferredCaption1;
            avail.Frame = new CGRect(termsAndConditionsPopup.PopupView.Frame.Width - 80, 133, 60, 20);


            UILabel clas2 = new UILabel();
            clas2.Text = "Premier";
            clas2.TextColor = UIColor.Gray;
            clas2.Font = UIFont.PreferredCaption1;
            clas2.Frame = new CGRect(15, 153, 60, 20);

            UILabel cost2 = new UILabel();
            cost2.Text = "$ 23.65";
            cost2.TextColor = UIColor.Black;
            cost2.Font = UIFont.PreferredCaption1;
            cost2.Frame = new CGRect(termsAndConditionsPopup.PopupView.Frame.Width / 2 - 60, 153, 60, 20);


            UILabel avail2 = new UILabel();
            avail2.Text = "Unavailable";
            avail2.TextColor = UIColor.Red;
            avail2.Font = UIFont.PreferredCaption1;
            avail2.Frame = new CGRect(termsAndConditionsPopup.PopupView.Frame.Width - 80, 153, 80, 20);

            seatSelectionMainLayout.AddSubview(numberOfSeatsLayout);
            seatSelectionMainLayout.AddSubview(title2);
            seatSelectionMainLayout.AddSubview(clas);
            seatSelectionMainLayout.AddSubview(cost);
            seatSelectionMainLayout.AddSubview(avail);
            seatSelectionMainLayout.AddSubview(clas2);
            seatSelectionMainLayout.AddSubview(cost2);
            seatSelectionMainLayout.AddSubview(avail2);

            termsAndConditionsPopup.PopupView.HeaderTitle = "How many seats ?";
            termsAndConditionsPopup.PopupView.PopupStyle.HeaderTextColor = UIColor.Black;
            termsAndConditionsPopup.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.White;
            termsAndConditionsPopup.PopupView.PopupStyle.BorderThickness = 1;
            termsAndConditionsPopup.PopupView.ShowFooter = true;
            termsAndConditionsPopup.PopupView.ShowCloseButton = true;
            termsAndConditionsPopup.PopupView.AppearanceMode = AppearanceMode.OneButton;
            termsAndConditionsPopup.PopupView.FooterHeight = 40;
            termsAndConditionsPopup.PopupView.AcceptButtonText = "Proceed";
            termsAndConditionsPopup.PopupView.PopupStyle.AcceptButtonBackgroundColor = UIColor.FromRGB(0, 124, 238);
            termsAndConditionsPopup.PopupView.PopupStyle.AcceptButtonTextColor = UIColor.White;

            return seatSelectionMainLayout;
        }

        private UILabel CreateSeatSelectionLayout(string count)
        {
            var seatCountLabel = new UILabel();
            if (count == "2")
            {
                seatCountLabel.BackgroundColor = UIColor.FromRGB(0, 124, 238);
                seatCountLabel.TextColor = UIColor.White;
            }
            else
            {
                seatCountLabel.BackgroundColor = UIColor.White;
                seatCountLabel.TextColor = UIColor.Black;
            }

            seatCountLabel.Text = count;

            seatCountLabel.Font = UIFont.BoldSystemFontOfSize(12);
            seatCountLabel.TextAlignment = UITextAlignment.Center;
            seatCountLabel.UserInteractionEnabled = true;
            var tapGesture = new UITapGestureRecognizer(SeatSelected) { NumberOfTapsRequired = 1 };
            seatCountLabel.AddGestureRecognizer(tapGesture);
            return seatCountLabel;
        }

        void SeatSelected(UITapGestureRecognizer tasture)
        {
            foreach (var v in tasture.View.Superview.Subviews)
            {
                (v as UILabel).TextColor = UIColor.Black;
                v.BackgroundColor = UIColor.White;
            }
            tasture.View.BackgroundColor = UIColor.FromRGB(0, 124, 238);
            (tasture.View as UILabel).TextColor = UIColor.White;
        }

        private void DisplayInfo()
		{
            DisplayInfoPopup();
		}

        private void DisplayInfoPopup()
        {
            infopopup = new SfPopupLayout();
            infopopup.IsOpen = false;
            infopopup.PopupView.AppearanceMode = AppearanceMode.OneButton;
            infopopup.PopupView.HeaderTitle = (rowData as TicketBookingInfo).TheaterName;
            infopopup.PopupView.BackgroundColor = UIColor.White;
            infopopup.PopupView.ShowCloseButton = true;
            infopopup.PopupView.PopupStyle.HeaderTextColor = UIColor.Black;
            infopopup.PopupView.PopupStyle.HeaderTextAlignment = UIKit.UITextAlignment.Center;
            infopopup.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.White;
            infopopup.PopupView.ShowFooter = false;
            infopopup.PopupView.FooterHeight = 35;
            infopopup.PopupView.HeaderHeight = 30;
            infopopup.StaysOpen = false;
            infopopup.PopupView.PopupStyle.HeaderFontSize = 16;
            infopopup.PopupView.ShowHeader = true;
            infopopup.PopupView.Frame = new CGRect(-1, -1, this.DataColumn.Renderer.DataGrid.Frame.Width - 40, this.DataColumn.Renderer.DataGrid.Frame.Height / 2);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                infopopup.PopupView.PopupStyle.HeaderFontSize = 14;
                infopopup.PopupView.Frame = new CGRect(-1, -1, this.DataColumn.Renderer.DataGrid.Frame.Width - 20, this.DataColumn.Renderer.DataGrid.Frame.Height / 1.75);
            }
            else
            {
                infopopup.PopupView.PopupStyle.HeaderFontSize = 20;
                infopopup.PopupView.Frame = new CGRect(-1, -1, (this.DataColumn.Renderer.DataGrid.Frame.Width / 10) * 6, this.DataColumn.Renderer.DataGrid.Frame.Height / 3.5);
            }
            infopopup.PopupView.ContentView = CreateInfoPopupContent();
            infopopup.IsOpen = true;
        }

        private UIView CreateInfoPopupContent()
		{
			UIView mainview = new UIView();

			UILabel location = new UILabel();
			location.Lines = 10;
			location.Font = UIFont.PreferredCaption1;
			location.TextColor = UIColor.FromRGB(0,124, 238);
			location.LineBreakMode = UILineBreakMode.WordWrap;
			location.Text = (rowData as TicketBookingInfo).TheaterLocation + "421 E DRACHMAN TUCSON AZ 85705 - 7598 USA";

			UILabel facilitiesLabel = new UILabel();
			facilitiesLabel.Text = "Available Facilities";
            facilitiesLabel.TextAlignment = UITextAlignment.Center;

			UIImageView mtick = new UIImageView();
			mtick.Image = UIImage.FromFile("Images/Popup_MTicket.png");

			UIImageView park = new UIImageView();
			park.Image = UIImage.FromFile("Images/Popup_Parking.png");

			UIImageView food = new UIImageView();
			food.Image = UIImage.FromFile("Images/Popup_FoodCourt.png");

			UILabel ticketLabel = new UILabel();
			ticketLabel.Text = "M-Ticket";
			ticketLabel.TextColor = UIColor.Black;
			ticketLabel.Font = UIFont.PreferredCaption2;

			UILabel parkingLabel = new UILabel();
			parkingLabel.Text = "Parking";
			parkingLabel.TextColor = UIColor.Black;
			parkingLabel.Font = UIFont.PreferredCaption2;

			UILabel foodLabel = new UILabel();
			foodLabel.Text = "Food Court";
			foodLabel.TextColor = UIColor.Black;
			foodLabel.Font = UIFont.PreferredCaption2;

			mainview.AddSubview(location);
			mainview.AddSubview(facilitiesLabel);
			mainview.AddSubview(mtick);
			mainview.AddSubview(park);
			mainview.AddSubview(food);
			mainview.AddSubview(ticketLabel);
			mainview.AddSubview(parkingLabel);
			mainview.AddSubview(foodLabel);

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                location.Frame = new CGRect(Bounds.Left + 16, Bounds.Top + 20, 240, 40);
                facilitiesLabel.Frame = new CGRect(0, location.Frame.Bottom + 12, infopopup.PopupView.Frame.Width, 40);
                mtick.Frame = new CGRect(Bounds.Left + 55, facilitiesLabel.Frame.Bottom + 10, 20, 20);
                park.Frame = new CGRect(mtick.Frame.Right + 65, facilitiesLabel.Frame.Bottom + 10, 20, 20);
                food.Frame = new CGRect(park.Frame.Right + 55, facilitiesLabel.Frame.Bottom + 10, 20, 20);
                ticketLabel.Frame = new CGRect(Bounds.Left + 45, mtick.Frame.Bottom + 10, 50, 20);
                parkingLabel.Frame = new CGRect(ticketLabel.Frame.Right + 35, mtick.Frame.Bottom + 10, 50, 20);
                foodLabel.Frame = new CGRect(parkingLabel.Frame.Right + 15, mtick.Frame.Bottom + 10, 60, 20);

            }
            else
            {
                location.Frame = new CGRect(Bounds.Left + 16, Bounds.Top + 20, infopopup.PopupView.Frame.Width, 60);
                facilitiesLabel.Frame = new CGRect(0, location.Frame.Bottom + 12, infopopup.PopupView.Frame.Width, 40);
                mtick.Frame = new CGRect(Bounds.Width / 6, facilitiesLabel.Frame.Bottom + 10, 20, 20);
                park.Frame = new CGRect(mtick.Frame.Right + 75, facilitiesLabel.Frame.Bottom + 10, 20, 20);
                food.Frame = new CGRect(park.Frame.Right + 75, facilitiesLabel.Frame.Bottom + 10, 20, 20);
                ticketLabel.Frame = new CGRect(Bounds.Width / 7, mtick.Frame.Bottom + 10, 50, 20);
                parkingLabel.Frame = new CGRect(ticketLabel.Frame.Right + 55, mtick.Frame.Bottom + 10, 50, 20);
                foodLabel.Frame = new CGRect(parkingLabel.Frame.Right + 40, mtick.Frame.Bottom + 10, 60, 20);
            }
			return mainview;
		}

		protected override void UnLoad()
		{
			this.RemoveFromSuperview();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			dataGrid = this.DataColumn.Renderer.DataGrid;
			rowData = (this.DataColumn.RowData);
			infoImage.Image = (rowData as TicketBookingInfo).InfoImage;
			theaterTitle.Text = (rowData as TicketBookingInfo).TheaterName;
			theaterLocation.Text = (rowData as TicketBookingInfo).TheaterLocation;
			timing1.Text = (rowData as TicketBookingInfo).Timing1;
			timing2.Text = (rowData as TicketBookingInfo).Timing2;
            if (timing2.Text == null)
                timing2.Hidden = true;
			this.theaterLayout.Frame = new CGRect(Bounds.Left, Bounds.Top, Bounds.Width, Bounds.Height);
		}
	}

	public class TheaterLayout : UIView
	{
		public TheaterLayout()
		{

		}

		public override void LayoutSubviews()
		{
			this.Subviews[0].Frame = new CGRect(Bounds.Left + 16, Bounds.Top + 16, Bounds.Width - 60, 25);
			this.Subviews[1].Frame = new CGRect(Bounds.Left + 16, this.Subviews[0].Frame.Bottom + 6, Bounds.Width - 60 ,25);
            this.Subviews[2].Frame = new CGRect(Bounds.Left + 16, this.Subviews[1].Frame.Bottom + 6, 80,32);
			this.Subviews[3].Frame = new CGRect(this.Subviews[2].Frame.Right + 10, this.Subviews[1].Frame.Bottom + 6, 80,32);
			this.Subviews[4].Frame = new CGRect(this.Subviews[1].Frame.Right, Bounds.Height / 2 - 12 , 24, 24);
		}
	}

    public class SeatSelectionLayout : UIView
    {
        SfPopupLayout popup;
        public SeatSelectionLayout(SfPopupLayout pop)
        {
            popup = pop;
        }

        public override void LayoutSubviews()
        {
            nfloat temp = 0;
            for (int i = 0; i < this.Subviews.Length; i++)
            {
                this.Subviews[i].Frame = new CGRect(temp, this.Frame.Top, (popup.PopupView.Frame.Width - 10) / 8, 42);
                temp = temp + ((popup.PopupView.Frame.Width - 10) / 8);
            }
        }
    }


}

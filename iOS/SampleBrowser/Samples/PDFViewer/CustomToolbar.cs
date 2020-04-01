#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CoreGraphics;
using Syncfusion.iOS.PopupLayout;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.SfPdfViewer.iOS;
using Syncfusion.SfRangeSlider.iOS;
using UIKit;

namespace SampleBrowser
{
    public class CustomToolbar : SampleView
    {
        internal SfPdfViewer pdfViewerControl;
        internal const float DefaultToolbarHeight = 50f;
        internal UIView parentView;
        internal UIView toolbar;
        private UIView topBorder = new UIView();
        private UITextField pageNumberField = new UITextField();
        private UILabel totalPageLabel = new UILabel();
        private UIButton undoButton = new UIButton();
        private UIButton redoButton = new UIButton();
        private UISearchBar searchBar = new UISearchBar();
        private UIButton searchButton = new UIButton();
        private UIButton backButton = new UIButton();
        private UIButton searchNextButton = new UIButton();
        private UIButton searchPreviousButton = new UIButton();
        private UIButton fileButton = new UIButton();
        private UIButton viewmodeButton = new UIButton();
        internal CGRect toolBarFrame = new CGRect();
        internal CGRect bottomToolbarFrame = new CGRect();
        internal CGRect annotationFrame = new CGRect();
        internal CGRect separateAnnotationFrame = new CGRect();
        internal CGRect colorFrame = new CGRect();
        private bool isLoaded = false;
        internal UIView toolBar = new UIView();
        internal UIView searchToolBar = new UIView();
        private ActivityIndicator activityDialog;
        private DropDownMenu dropDownMenu;
        private UIAlertView popUpAlertView;
        private Stream fileStream;
        internal UIView bottomToolBar = new UIView();
        private UIButton annotationButton = new UIButton();
        internal UIView textAnnotationToolbar = new UIView();
        internal UIButton highlightAnnotationButton = new UIButton();
        internal UIButton underlineAnnotationButton = new UIButton();
        internal UIButton strikeOutAnnotationButton = new UIButton();
        internal UIView highlightToolbar = new UIView();
        internal UIView underlineToolbar = new UIView();
        internal UIView strikeOutToolbar = new UIView();
        internal UIView editStampAnnotationToolbar = new UIView();
        internal UIButton toolbarBackbutton = new UIButton();
        internal UIButton colorButton = new UIButton();
        internal UIView colorToolbar = new UIView();
        internal UIView thicknessToolbar = new UIView();
        internal UIButton deleteButton = new UIButton();
        private UIButton saveButton = new UIButton();
        internal UIButton highlightEnable = new UIButton();
        internal UIButton underlineEnable = new UIButton();
        internal UIButton editStampButton = new UIButton();
        internal UIButton strikeEnable = new UIButton();
        internal UIButton redButton = new UIButton();
        internal UIButton blueButton = new UIButton();
        internal UIButton yellowButton = new UIButton();
        internal UIButton blackButton = new UIButton();
        internal UIButton greenButton = new UIButton();
        internal UIButton grayButton = new UIButton();
        internal UIButton whiteButton = new UIButton();
        private UIAlertView pagePopupView = new UIAlertView();
        internal UIView annotationToolbar = new UIView();
        internal UIButton textMarkupAnnotationButton = new UIButton();
        internal UIButton inkAnnotationButton = new UIButton();
        internal UIButton editTextAnnotationButton = new UIButton();
        internal UIButton shapeAnnotationButton = new UIButton();
        internal UIView inkAnnotationToolbar = new UIView();
        internal UIView editTextAnnotationToolbar = new UIView();
        internal UIView inkAnnotationSessionToolbar = new UIView();
        internal UIButton inkButton = new UIButton();
        internal UIButton inkThicknessButton = new UIButton();
        internal UIButton inkColorButton = new UIButton();
        internal UIButton inkUndoButton = new UIButton();
        internal UIButton inkRedoButton = new UIButton();
        internal UIButton inkConfirmButton = new UIButton();
        internal UIButton textToolbarBackButton = new UIButton();
        internal UIButton bookmarkButton = new UIButton();
        internal bool isOpacityNeeded = false;
        internal bool isOpacitySelected = false;
        internal bool isThicknessTouched = false;
        internal bool isColorToolbarAdded = false;
        internal bool isOpacityToolbarAdded = false;
        internal bool colorToolbarCreated = false;
        internal UIButton opacitybutton = new UIButton();
        internal UISlider thicknessBar = new UISlider();
        internal UISlider opacitySlider = new UISlider();
        internal CGRect thicknessFrame = new CGRect();
        internal CGRect opacityFrame = new CGRect();
        internal UIView opacityPanel = new UIView();
        internal UILabel sliderValue = new UILabel();
        internal UILabel opacitySliderValue = new UILabel();
        internal bool isAnnotationToolbarVisible;
        internal IAnnotation annotation;
        internal AlertViewDelegate alertViewDelegate;
        internal UIFont highFont, stampFont, viewmodeFont;
        internal UIFont fontSizeFont;
        internal UIFont bookmarkFont;
        internal bool IsSelected;
        internal UIButton inkdeleteButton = new UIButton();
        internal bool isColorSelected;
        internal TextMarkupAnnotationHelper helper;
        internal EditTextAnnotationHelper edittextHelper;
        internal InkAnnotationHelper inkHelper;
        internal AnnotationHelper annotHelper;
        internal ShapeAnnotationHelper shapeHelper;
        internal UIButton BoldBtn1 = new UIButton();
        internal UIButton BoldBtn2 = new UIButton();
        internal UIButton BoldBtn3 = new UIButton();
        internal UIButton BoldBtn4 = new UIButton();
        internal UIButton BoldBtn5 = new UIButton();
        internal UIButton BoldColorBtn1 = new UIButton();
        internal UIButton BoldColorBtn2 = new UIButton();
        internal UIButton BoldColorBtn3 = new UIButton();
        internal UIButton BoldColorBtn4 = new UIButton();
        internal UIButton BoldColorBtn5 = new UIButton();
        internal bool iseditEnable = false;
        internal UIButton edittextThicknessButton = new UIButton();
        internal UIButton edittextColorButton = new UIButton();
        internal UIButton edittextDeleteButton = new UIButton();
        internal UIView FontSizePanel = new UIView();
        internal SfRangeSlider rangeSlider;
        internal UIButton rectangleAnnotationButton = new UIButton();
        internal UIButton circleAnnotationButton = new UIButton();
        internal UIButton lineAnnotationButton = new UIButton();
        internal UIButton arrowAnnotationButton = new UIButton();
        internal UIView shapeAnnotationToolbar = new UIView();
        internal UIView lineToolbar = new UIView();
        internal UIView rectangleToolbar = new UIView();
        internal UIView circleToolbar = new UIView();
        internal UIView arrowToolbar = new UIView();
        internal UIButton lineEnable = new UIButton();
        internal UIButton arrowEnable = new UIButton();
        internal UIButton circleEnable = new UIButton();
        internal UIButton rectangleEnable = new UIButton();
        internal UIButton shapeThicknessButton = new UIButton();
        internal UIButton shapeDeleteButton = new UIButton();
        internal UIButton shapeColorButton = new UIButton();
        internal UIToolbar annottoolbar = new UIToolbar();
        internal UIView separator = new UIView();
        internal AnnotationMode shapeView;
        internal UIButton signatureButton = new UIButton();
        internal UIButton stampButton = new UIButton();
        internal UIFont signatureFont;
        internal SfPopupLayout SfPopup;
        internal UITextField pwdEntry;
        internal UILabel errorMessage;
        internal UIButton okButton;
        
        internal int i = 0;
        //PdfLoadedDocument instance from which the bookmarks will be obtained
        internal PdfLoadedDocument loadedDocument;
        internal Stream initialStream;
        internal BookmarkToolbar bookmarkToolbar;
        internal List<CustomBookmark> listViewItemsSource = new List<CustomBookmark>();
        internal bool isBookmarkPaneVisible;
        internal StampAnnotationView stampView;

        public CustomToolbar()
        {
            parentView = new UIView(this.Frame);
            initialStream = typeof(CustomToolbar).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets.F# Succinctly.pdf");
            MemoryStream initialDocumentStream = new MemoryStream();
            initialStream.CopyTo(initialDocumentStream);
            loadedDocument = new PdfLoadedDocument(initialDocumentStream);
            PopulateInitialBookmarkList();
            var tap = new UITapGestureRecognizer(OnSingleTap);
            tap.CancelsTouchesInView = false; //for iOS5
            highFont = UIFont.FromName("Final_PDFViewer_IOS_FontUpdate", 30);
            stampFont = UIFont.FromName("Font Text edit stamp", 30);
            fontSizeFont = UIFont.FromName("Font size Font", 30);
			signatureFont = UIFont.FromName("Signature_PDFViewer_FONT", 30);
            //Font that defines the icons for the bookmark toolbar buttons
            bookmarkFont = UIFont.FromName("PdfViewer_FONT", 30);
            viewmodeFont = UIFont.FromName("Font Page icons", 30);
            this.AddGestureRecognizer(tap);
            helper = new TextMarkupAnnotationHelper(this);
            inkHelper = new InkAnnotationHelper(this);
            annotHelper = new AnnotationHelper(this);
            rangeSlider = new SfRangeSlider();
            edittextHelper = new EditTextAnnotationHelper(this);
            shapeHelper = new ShapeAnnotationHelper(this);
            opacitybutton.TouchUpInside += inkHelper.Opacitybutton_TouchUpInside;
            pdfViewerControl = new SfPdfViewer();
            pdfViewerControl.PreserveSignaturePadOrientation = true;
            pdfViewerControl.Toolbar.Enabled = false;
            pdfViewerControl.IsPasswordViewEnabled = false;
            pdfViewerControl.PageChanged += ViewerControl_PageChanged;
            pdfViewerControl.TextMarkupSelected += helper.PdfViewerControl_TextMarkupSelected;
            pdfViewerControl.TextMarkupDeselected += helper.PdfViewerControl_TextMarkupDeselected;
            pdfViewerControl.CanUndoModified += PdfViewerControl_CanUndoModified;
            pdfViewerControl.CanRedoModified += PdfViewerControl_CanRedoModified;
            pdfViewerControl.CanUndoInkModified += inkHelper.PdfViewerControl_CanUndoInkModified;
            pdfViewerControl.CanRedoInkModified += inkHelper.PdfViewerControl_CanRedoInkModified;
            pdfViewerControl.InkSelected += inkHelper.PdfViewerControl_InkSelected;
            pdfViewerControl.InkDeselected += inkHelper.PdfViewerControl_InkDeselected;
            pdfViewerControl.FreeTextAnnotationAdded += edittextHelper.PdfViewerControl_FreeTextAnnotationAdded;
            pdfViewerControl.FreeTextAnnotationDeselected += edittextHelper.PdfViewerControl_FreeTextAnnotationDeselected;
            pdfViewerControl.FreeTextAnnotationSelected += edittextHelper.PdfViewerControl_FreeTextAnnotationSelected;
            pdfViewerControl.FreeTextPopupDisappeared += edittextHelper.PdfViewerControl_FreeTextPopupDisappearing;
            pdfViewerControl.ShapeAnnotationSelected += shapeHelper.PdfViewerControl_ShapeAnnotationSelected;
            pdfViewerControl.ShapeAnnotationDeselected += shapeHelper.PdfViewerControl_ShapeAnnotationDeselected;
            pdfViewerControl.StampAnnotationSelected += helper.PdfViewerControl_StampAnnotationSelected;
            pdfViewerControl.StampAnnotationDeselected += helper.PdfViewerControl_StampAnnotationDeselected;
            BoldBtn1.TouchUpInside += inkHelper.BoldColorBtn1_TouchUpInside;
            BoldColorBtn1.TouchUpInside += inkHelper.BoldColorBtn1_TouchUpInside;
            BoldBtn2.TouchUpInside += inkHelper.BoldColorBtn2_TouchUpInside;
            BoldColorBtn2.TouchUpInside += inkHelper.BoldColorBtn2_TouchUpInside;
            BoldBtn3.TouchUpInside += inkHelper.BoldColorBtn3_TouchUpInside;
            BoldColorBtn3.TouchUpInside += inkHelper.BoldColorBtn3_TouchUpInside;
            BoldColorBtn4.TouchUpInside += inkHelper.BoldColorBtn4_TouchUpInside;
            BoldBtn4.TouchUpInside += inkHelper.BoldColorBtn4_TouchUpInside;
            BoldColorBtn5.TouchUpInside += inkHelper.BoldColorBtn5_TouchUpInside;
            BoldBtn5.TouchUpInside += inkHelper.BoldColorBtn5_TouchUpInside;
            inkColorButton.TouchUpInside += helper.ColorButton_TouchUpInside;
            colorButton.TouchUpInside += helper.ColorButton_TouchUpInside;
            inkAnnotationButton.TouchUpInside += inkHelper.InkAnnotationButton_TouchUpInside;
            inkThicknessButton.TouchUpInside += inkHelper.InkThicknessButton_TouchUpInside;
            shapeThicknessButton.TouchUpInside += inkHelper.InkThicknessButton_TouchUpInside;
            edittextThicknessButton.TouchUpInside += edittextHelper.EditTextThicknessButton_TouchUpInside;
            edittextColorButton.TouchUpInside += helper.ColorButton_TouchUpInside;
            shapeColorButton.TouchUpInside += helper.ColorButton_TouchUpInside;
            pageNumberField.Text = "1";
            CreateTopToolbar();
            bottomToolBar = CreateBottomToolbar();
            toolbar = toolBar;
            parentView.AddSubview(pdfViewerControl);
            AddSubview(parentView);
            AddSubview(toolbar);
            AddSubview(bottomToolBar);
            topBorder.BackgroundColor = UIColor.FromRGBA(red: 0.86f, green: 0.86f, blue: 0.86f, alpha: 1.0f);
            AddSubview(topBorder);
            activityDialog = new ActivityIndicator();
            activityDialog.Frame = new CGRect(UIScreen.MainScreen.Bounds.Width / 2 - 125, UIScreen.MainScreen.Bounds.Height / 2 - 50, 250, 100);
            popUpAlertView = new UIAlertView();

            UIView popupview = new UIView();
            SfPopup = new SfPopupLayout();
            SfPopup.StaysOpen = true;
            SfPopup.PopupView.AppearanceMode = AppearanceMode.TwoButton;
            SfPopup.PopupView.ShowCloseButton = false;
            popupview.AddSubview(SfPopup);
            SfPopup.PopupView.HeaderView = GetHeaderPopup();
            SfPopup.PopupView.ContentView = GetContentPopup();
            SfPopup.PopupView.FooterView = GetFooter();


            dropDownMenu = CreateDropDownMenu();
            dropDownMenu.DropDownMenuItemChanged += (e, a) =>
            {
                pdfViewerControl.Unload();
                listViewItemsSource.Clear();
                fileStream = typeof(CustomToolbar).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets." + a.DisplayText + ".pdf");

                try
                {
                    MemoryStream stream = new MemoryStream();
                    stream.Position = 0;
                    fileStream.CopyTo(stream);
                    pdfViewerControl.DocumentLoaded += PdfViewerControl_DocumentLoaded;
                    pdfViewerControl.PasswordErrorOccurred += PdfViewerControl_PasswordErrorOccurred;
                    loadedDocument = new PdfLoadedDocument(stream);
                    PopulateInitialBookmarkList();
                    pdfViewerControl.LoadDocument(fileStream);
                }
                catch (PdfException)
                {
                    SfPopup.Show();
                    DisableToolbar();
                    i++;
                }

                isBookmarkPaneVisible = false;
                if (bookmarkToolbar != null && bookmarkToolbar.Superview != null)
                    bookmarkToolbar.RemoveFromSuperview();
                ResetToolBar();
                annotHelper.RemoveAllToolbars(false);
                dropDownMenu.Close();
            };

        }


        private void PdfViewerControl_DocumentLoaded(object sender, EventArgs args)
        {
            errorMessage.Hidden = true;
            pwdEntry.Text = string.Empty;
            EnableToolbar();
            SfPopup.Dismiss();
            pageNumberField.Text = pdfViewerControl.PageNumber.ToString();
            totalPageLabel.Text = "/ " + pdfViewerControl.PageCount.ToString();
            totalPageLabel.SetNeedsDisplay();
            isLoaded = true;
        }

        private void DisableToolbar()
        {
            saveButton.Enabled = false;
            bookmarkButton.Enabled = false;
            searchButton.Enabled = false;
            pageNumberField.Enabled = false;
            annotationButton.Enabled = false;
            viewmodeButton.Enabled = false;
            saveButton.SetTitleColor(UIColor.LightGray, UIControlState.Disabled);
            bookmarkButton.SetTitleColor(UIColor.LightGray, UIControlState.Disabled);
            searchButton.SetTitleColor(UIColor.LightGray, UIControlState.Disabled);
            pageNumberField.TextColor = UIColor.Gray;
            totalPageLabel.TextColor = UIColor.Gray;
            annotationButton.SetTitleColor(UIColor.LightGray, UIControlState.Disabled);
            viewmodeButton.SetTitleColor(UIColor.LightGray, UIControlState.Disabled);
            pageNumberField.Text = "0";
            totalPageLabel.Text = "/ 0";
            pdfViewerControl.EnableScrollHead = false;
            undoButton.Enabled = false;
            redoButton.Enabled = false;
        }
        private void EnableToolbar()
        {
            saveButton.Enabled = true;
            bookmarkButton.Enabled = true;
            searchButton.Enabled = true;
            pageNumberField.Enabled = true;
            annotationButton.Enabled = true;
            viewmodeButton.Enabled = true;
            saveButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            bookmarkButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            searchButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            pageNumberField.TextColor = UIColor.FromRGB(0, 118, 255);
            annotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            viewmodeButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            pdfViewerControl.EnableScrollHead = true;
            undoButton.Enabled = true;
            redoButton.Enabled = true;
            totalPageLabel.TextColor= UIColor.FromRGB(0, 118, 255);
        }

        private void PdfViewerControl_PasswordErrorOccurred(object sender, PasswordErrorOccurredEventArgs e)
        {
            if (i == 0)
            {
                SfPopup.Show();
                i++;
            }
            else
            {
                errorMessage.Hidden = false;

            }
        }

        private UIView GetHeaderPopup()
        {
            UIView headerView = new UIView();
            UILabel headLabel = new UILabel();
            headLabel.Frame = new CGRect(70, 0, 300, 60);
            headLabel.Text = "Password Protected";
            headerView.BackgroundColor = UIColor.White;
            headerView.AddSubview(headLabel);
            return headerView;
        }
        private UIView GetContentPopup()
        {
            UIView contentView = new UIView();
            UILabel popupContentView = new UILabel();
            popupContentView.Frame = new CGRect(20, 0, 300, 25);
            popupContentView.Text = "Enter the password to open this File.";
            popupContentView.Font = UIFont.SystemFontOfSize(15);
            contentView.AddSubview(popupContentView);
            pwdEntry = new UITextField();
            pwdEntry.BorderStyle = UITextBorderStyle.RoundedRect;
            pwdEntry.Placeholder = "Password: syncfusion";
            pwdEntry.Text = string.Empty;
            pwdEntry.Delegate = new TextFieldDelegate(this);
            pwdEntry.SecureTextEntry = true;
            pwdEntry.EditingChanged += PwdEntry_EditingChanged;
            pwdEntry.Frame = new CGRect(20, 40, 260, 40);
            pwdEntry.Layer.BorderColor = UIColor.FromRGB(0, 128, 255).CGColor;
            contentView.AddSubview(pwdEntry);
            errorMessage = new UILabel();
            errorMessage.Frame = new CGRect(20, 80, 300, 25);
            errorMessage.Text = "Invalid Passsword!";
            errorMessage.Font = UIFont.SystemFontOfSize(15, UIFontWeight.Bold);
            errorMessage.Alpha = 0.5f;
            errorMessage.TextColor = UIColor.Red;
            errorMessage.Hidden = true;
            contentView.AddSubview(errorMessage);
            return contentView;
        }

        private void PwdEntry_EditingChanged(object sender, EventArgs e)
        {
            if (pwdEntry.Text != string.Empty)
            {
                okButton.Enabled = true;
                if (!errorMessage.Hidden)
                    errorMessage.Hidden = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }

        private UIView GetFooter()
        {
            UIView iView = new UIView();
            UIButton cancelButton = new UIButton();
            cancelButton.Frame = new CGRect(0, 0, 150, 70);
            cancelButton.SetTitle("Cancel", UIControlState.Normal);
            cancelButton.BackgroundColor = UIColor.White;
            cancelButton.TouchUpInside += CancelButton_TouchUpInside;
            cancelButton.SetTitleColor(UIColor.FromRGB(0, 128, 255), UIControlState.Normal);
            iView.AddSubview(cancelButton);
            okButton = new UIButton();
            okButton.SetTitle("Ok", UIControlState.Normal);
            okButton.TouchUpInside += OkButton_TouchUpInside;
            okButton.BackgroundColor = UIColor.White;
            okButton.SetTitleColor(UIColor.FromRGB(0, 128, 235), UIControlState.Normal);
            okButton.SetTitleColor(UIColor.FromRGB(176, 176, 176), UIControlState.Disabled);
            okButton.Enabled = false;
            okButton.Frame = new CGRect(150, 0, 150, 70);
            iView.AddSubview(okButton);
            return iView;
        }

        private void OkButton_TouchUpInside(object sender, EventArgs e)
        {
            fileStream.Position = 0;
            pdfViewerControl.LoadDocument(fileStream, pwdEntry.Text);

        }

        private void CancelButton_TouchUpInside(object sender, EventArgs e)
        {
            SfPopup.Dismiss();
            DisableToolbar();
        }

        //Populates the bookmark toolbar with the bookmarks when a PDF is loaded
        private void PopulateInitialBookmarkList()
        {
            listViewItemsSource.Clear();
            PdfBookmarkBase bookmarkBase = loadedDocument.Bookmarks;
            for (int i = 0; i < bookmarkBase.Count; i++)
                listViewItemsSource.Add(new CustomBookmark(bookmarkBase[i], false));
            if(bookmarkToolbar != null)
                bookmarkToolbar.bookmarkListView.ReloadData();
        }
        internal bool isStampViewVisible;
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            //SfPopup.Frame = new CGRect(0, 20, 200, 150);
            if (!isStampViewVisible && !isBookmarkPaneVisible || UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
				//Set the frames to SfPdfViewer and bookmark toolbar based on whether the bookmark toolbar is visible
                if (!isBookmarkPaneVisible)
                {
                    parentView.Frame = new CGRect(0, DefaultToolbarHeight, this.Frame.Width, this.Frame.Height - (DefaultToolbarHeight));
                    if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad && bookmarkToolbar != null)
                        bookmarkToolbar.Frame = new CGRect(this.Frame.Width, this.Frame.Y, 0, 0);
                }
                else
                {
                    parentView.Frame = new CGRect(0, DefaultToolbarHeight, 3 * this.Frame.Width / 5, this.Frame.Height - DefaultToolbarHeight);
                    if (bookmarkToolbar != null)
                        bookmarkToolbar.Frame = new CGRect(3 * this.Frame.Width / 5, DefaultToolbarHeight, this.Frame.Width - (3 * this.Frame.Width / 5), this.Frame.Height - 2*DefaultToolbarHeight);
                }

                if(isStampViewVisible)
                {
                    parentView.Frame = new CGRect(0, DefaultToolbarHeight, this.Frame.Width, this.Frame.Height - (DefaultToolbarHeight));
                    stampView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);

                }

                if (!isLoaded)
                {
                    pdfViewerControl.LoadDocument(initialStream);
                    totalPageLabel.Text = "/ " + pdfViewerControl.PageCount.ToString();
                    totalPageLabel.SetNeedsDisplay();
                    isLoaded = true;
        
                }
                pdfViewerControl.Frame = new CGRect(0, 0, parentView.Frame.Width, parentView.Frame.Height - DefaultToolbarHeight + 2);
                toolBarFrame.Width = this.Frame.Width;
                toolbar.Frame = toolBarFrame;
                int numberOfButtons = 7;
                nfloat space = Frame.Width / numberOfButtons;
                nfloat leftWithInSpace = (space - 35) / 2;
                fileButton.Frame = new CGRect(leftWithInSpace, 7, 35, 35);
                saveButton.Frame = new CGRect(space + leftWithInSpace, 7, 35, 35);
                undoButton.Frame = new CGRect(2 * space + leftWithInSpace, 7, 35, 35);
                redoButton.Frame = new CGRect(3 * space + leftWithInSpace, 7, 35, 35);
                viewmodeButton.Frame = new CGRect(4 * space + leftWithInSpace, 7, 35, 35);
                bookmarkButton.Frame = new CGRect(5 * space + leftWithInSpace, 7, 35, 35);
                searchButton.Frame = new CGRect(6 * space + leftWithInSpace, 7, 35, 35);
                
                bottomToolbarFrame.X = -2;
                bottomToolbarFrame.Width = this.Frame.Width + 3;
                bottomToolbarFrame.Y = parentView.Frame.Height + 2;
                bottomToolBar.Frame = bottomToolbarFrame;
                topBorder.Frame = new CGRect(toolBarFrame.X, toolBarFrame.Bottom - 1, toolBarFrame.Width, 1);
                annotationButton.Frame = new CGRect(this.Frame.Width - 60, 7, 35, 35);
                colorFrame.Width = bottomToolbarFrame.Width;
                annotationFrame.Width = bottomToolbarFrame.Width;
                colorFrame.Height = bottomToolbarFrame.Height;
                colorFrame.Y = parentView.Frame.Height - (DefaultToolbarHeight + colorFrame.Height - 4);
                colorToolbar.Frame = colorFrame;
                annotationFrame.Height = bottomToolbarFrame.Height;
                annotationFrame.Y = parentView.Frame.Height - annotationFrame.Height + 4;
                textAnnotationToolbar.Frame = annotationFrame;
                if (!IsSelected)
                    colorButton.Frame = new CGRect(this.Frame.Width - 120, 7, 35, 35);
                else
                    colorButton.Frame = new CGRect(this.Frame.Width - 55, 7, 35, 35);
                separateAnnotationFrame.Width = bottomToolbarFrame.Width;
                separateAnnotationFrame.Height = bottomToolbarFrame.Height;
                separateAnnotationFrame.Y = parentView.Frame.Height - separateAnnotationFrame.Height + 4;
                annotationToolbar.Frame = separateAnnotationFrame;
                highlightToolbar.Frame = separateAnnotationFrame;
                underlineToolbar.Frame = separateAnnotationFrame;
                strikeOutToolbar.Frame = separateAnnotationFrame;
                editStampAnnotationToolbar.Frame = separateAnnotationFrame;
                deleteButton.Frame = new CGRect(this.Frame.Width - 100, 7, 35, 35);
                if (annotation != null && annotation is StampAnnotation)
                    deleteButton.Frame = new CGRect(this.Frame.Width - 50, 7, 35, 35);
                toolbarBackbutton.Frame = new CGRect(15, 7, 35, 35);
                inkAnnotationSessionToolbar.Frame = toolBarFrame;
                shapeAnnotationToolbar.Frame = separateAnnotationFrame;
                editTextAnnotationToolbar.Frame = separateAnnotationFrame;
                lineToolbar.Frame = separateAnnotationFrame;
                rectangleToolbar.Frame = separateAnnotationFrame;
                circleToolbar.Frame = separateAnnotationFrame;
                arrowToolbar.Frame = separateAnnotationFrame;
                annotationToolbar.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            }
            //For mobile set the frame to bookmark toolbar so that it occupies the entire view
            else if (!isStampViewVisible && UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
                bookmarkToolbar.Frame = new CGRect(this.Frame.X, 0, this.Frame.Width, this.Frame.Height);
            else if (isStampViewVisible && UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
                stampView.Frame = new CGRect(this.Frame.X, 0, Frame.Width, Frame.Height);
        }
        void PdfViewerControl_CanUndoModified(object sender, CanUndoModifiedEventArgs args)
        {
            if (args.CanUndo)
            {
                undoButton.SetTitle("\ue70a", UIControlState.Normal);
                undoButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            }
            else
            {
                undoButton.SetTitle("\ue70a", UIControlState.Normal);
                undoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            }
        }
        void PdfViewerControl_CanRedoModified(object sender, CanRedoModifiedEventArgs args)
        {
            if (args.CanRedo)
            {
                redoButton.SetTitle("\ue716", UIControlState.Normal);
                redoButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            }
            else
            {
                redoButton.SetTitle("\ue716", UIControlState.Normal);
                redoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            }
        }
        public void OnSingleTap(UITapGestureRecognizer gesture)
        {
            this.EndEditing(true);
            pageNumberField.Text = pdfViewerControl.PageNumber.ToString();
        }
        private void ResetToolBar()
        {
            pageNumberField.Text = pdfViewerControl.PageNumber.ToString();
            totalPageLabel.Text = "/  " + pdfViewerControl.PageCount.ToString();
            totalPageLabel.Frame = new CGRect(totalPageLabel.Frame.X, totalPageLabel.Frame.Y, totalPageLabel.IntrinsicContentSize.Width, totalPageLabel.Frame.Height);
        }
        private void PageNumberField_EditingDidBegin(object sender, EventArgs e)
        {
            pageNumberField.ResignFirstResponder();
            alertViewDelegate = new AlertViewDelegate(pdfViewerControl);
            pagePopupView.Frame = new CGRect(40, parentView.Frame.Height / 4, 400, 150);
            pagePopupView.BackgroundColor = UIColor.White;
            pagePopupView.Layer.BorderWidth = 1;
            pagePopupView.Layer.BorderColor = new CGColor(0.2f, 0.2f);
            pagePopupView.Layer.CornerRadius = 10;
            pagePopupView.Title = "Go To Page";
            pagePopupView.Message = "Enter Page Number (1 - " + pdfViewerControl.PageCount.ToString() + ")";
            pagePopupView.AddButton("Cancel");
            pagePopupView.AddButton("OK");
            pagePopupView.Delegate = alertViewDelegate;
            pagePopupView.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
            pagePopupView.GetTextField(0).KeyboardType = UIKeyboardType.NumberPad;
            pagePopupView.CancelButtonIndex = 0;
            pagePopupView.GetTextField(0).BecomeFirstResponder();
            pageNumberField.Text = pdfViewerControl.PageNumber.ToString();
            pagePopupView.Show();
        }
        private void ViewerControl_PageChanged(object sender, PageChangedEventArgs args)
        {
            pageNumberField.Text = args.NewPageNumber.ToString();
        }
        protected virtual UIView CreateTopToolbar()
        {
            toolBarFrame = this.Frame;
            toolBarFrame.Height = DefaultToolbarHeight;
            toolBarFrame.Y = 0;
            toolBar.Frame = toolBarFrame;
            toolBar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            toolBar.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                fileButton.Frame = new CGRect(10, 7, 35, 35);
            else
                fileButton.Frame = new CGRect(5, 7, 35, 35);
            fileButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            fileButton.TouchUpInside += (e, a) =>
            {
                if (dropDownMenu.IsOpened)
                    dropDownMenu.Close();
                else
                    dropDownMenu.Open();
            };
            fileButton.Font = highFont;
            fileButton.SetTitle("\ue71d", UIControlState.Normal);
            fileButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            toolBar.Add(fileButton);

            saveButton.Frame = new CGRect(55, 7, 35, 35);
            saveButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            saveButton.TouchUpInside += annotHelper.SaveButton_TouchUpInside;
            saveButton.Font = highFont;
            saveButton.SetTitle("\ue718", UIControlState.Normal);
            saveButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            toolBar.Add(saveButton);
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                undoButton.Frame = new CGRect(parentView.Frame.Width / 2 - 25, 7, 35, 35);
            else
                undoButton.Frame = new CGRect(130, 7, 35, 35);
            undoButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            undoButton.TouchUpInside += UndoButton_TouchUpInside; ;
            undoButton.Font = highFont;
            undoButton.SetTitle("\ue70a", UIControlState.Normal);
            undoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            toolBar.Add(undoButton);
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                redoButton.Frame = new CGRect(parentView.Frame.Width / 2 + 10, 7, 35, 35);
            else
                redoButton.Frame = new CGRect(175, 7, 35, 35);
            redoButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            redoButton.TouchUpInside += RedoButton_TouchUpInside; ;
            redoButton.Font = highFont;
            redoButton.SetTitle("\ue716", UIControlState.Normal);
            redoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            toolBar.Add(redoButton);
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                bookmarkButton.Frame = new CGRect(parentView.Frame.Width - 50, 7, 35, 35);
            else
                bookmarkButton.Frame = new CGRect(parentView.Frame.Width - 55, 7, 35, 35);
            bookmarkButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            bookmarkButton.TouchUpInside += BookmarkButton_TouchUpInside; 
            bookmarkButton.Font = bookmarkFont;
            bookmarkButton.SetTitle("\ue701", UIControlState.Normal);
            bookmarkButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            toolBar.Add(bookmarkButton);

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                searchButton.Frame = new CGRect(parentView.Frame.Width - 50, 7, 35, 35);
            else
                searchButton.Frame = new CGRect(parentView.Frame.Width - 10, 7, 35, 35);
            searchButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            searchButton.TouchUpInside += SearchButtonClicked;
            searchButton.Font = highFont;
            searchButton.SetTitle("\ue719", UIControlState.Normal);
            searchButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            toolBar.Add(searchButton);

            viewmodeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            viewmodeButton.TouchUpInside += ViewmodeButton_TouchUpInside;
            viewmodeButton.Font = viewmodeFont;
            viewmodeButton.SetTitle("\ue705", UIControlState.Normal);
            viewmodeButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            toolBar.Add(viewmodeButton);
            return toolBar;
        }

        private void ViewmodeButton_TouchUpInside(object sender, EventArgs e)
        {
            if(pdfViewerControl.PageViewMode == PageViewMode.Continuous)
            {
                pdfViewerControl.PageViewMode = PageViewMode.PageByPage;
                viewmodeButton.SetTitle("\ue703", UIControlState.Normal);
            }
            else
            {
                pdfViewerControl.PageViewMode = PageViewMode.Continuous;
                viewmodeButton.SetTitle("\ue705", UIControlState.Normal);
            }
        }

        //Handles the click event of the bookmark button on the top toolbar
        private void BookmarkButton_TouchUpInside(object sender, EventArgs e)
        {
            if(bookmarkToolbar == null)
                bookmarkToolbar = new BookmarkToolbar(this);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                if (bookmarkToolbar.Superview == null)
                    AddSubview(bookmarkToolbar);
                else
                    bookmarkToolbar.RemoveFromSuperview();
                isBookmarkPaneVisible = !isBookmarkPaneVisible;
                annotHelper.RemoveAllToolbars(false);
                pdfViewerControl.AnnotationMode = AnnotationMode.None;
                isAnnotationToolbarVisible = false;
            }
            else
            {
                if (bookmarkToolbar.Superview == null)
                    AddSubview(bookmarkToolbar);
                isBookmarkPaneVisible = true;
            }
        }

        private UIView CreateBottomToolbar()
        {
            bottomToolbarFrame = this.Frame;
            bottomToolbarFrame.Height = DefaultToolbarHeight;
            bottomToolbarFrame.Y = 0;
            bottomToolBar.Frame = bottomToolbarFrame;
            bottomToolBar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            bottomToolBar.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                pageNumberField.Frame = new CGRect(45, 7, 45, 35);
            else
                pageNumberField.Frame = new CGRect(45, 7, 45, 35);
            pageNumberField.EditingDidBegin += PageNumberField_EditingDidBegin;
            pageNumberField.BorderStyle = UITextBorderStyle.RoundedRect;
            pageNumberField.TextColor = UIColor.FromRGB(0, 118, 255);
            pageNumberField.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            pageNumberField.TextAlignment = UITextAlignment.Center;
            bottomToolBar.Add(pageNumberField);
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                totalPageLabel.Frame = new CGRect(90, 7, 40, 35);
            else
                totalPageLabel.Frame = new CGRect(90, 7, 40, 35);
            totalPageLabel.TextColor = UIColor.FromRGB(0, 118, 255);
            bottomToolBar.Add(totalPageLabel);
            annotationButton.Frame = new CGRect(parentView.Frame.Width - 50, 7, 35, 35);
            annotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            annotationButton.TouchUpInside += annotHelper.AnnotationButton_TouchUpInside;
            annotationButton.Font = highFont;
            annotationButton.SetTitle("\ue706", UIControlState.Normal);
            annotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            bottomToolBar.Add(annotationButton);
            bottomToolBar.Layer.BorderWidth = 1;
            bottomToolBar.Layer.BorderColor = new CGColor(0.2f, 0.2f);
            return bottomToolBar;
        }
        internal UIView UpdateToolbarBorder(UIView updateToolbar, CGRect toolbarFrame)
        {
            updateToolbar.Layer.BorderWidth = 1;
            updateToolbar.Layer.BorderColor = new CGColor(0.2f, 0.2f);
            updateToolbar.Frame = new CGRect(toolbarFrame.X - 1, toolbarFrame.Y - 1, textAnnotationToolbar.Frame.Width + 2, textAnnotationToolbar.Frame.Height + 2);
            return updateToolbar;
        }
        protected virtual UIView CreateSearchTopToolbar()
        {
            annotHelper.RemoveAllToolbars(false);
            toolBarFrame = Frame;
            toolBarFrame.Height = DefaultToolbarHeight;
            toolBarFrame.Y = 0;
            searchToolBar.Frame = toolBarFrame;
            searchToolBar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            searchToolBar.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                backButton.Frame = new CGRect(20, 2, 50, 50);
            else
                backButton.Frame = new CGRect(2, 5, 40, 40);
            backButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            backButton.TouchUpInside += BackButtonClicked;
            backButton.Font = highFont;
            backButton.SetTitle("\ue71b", UIControlState.Normal);
            backButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            searchToolBar.Add(backButton);
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                searchBar.Frame = new CGRect(95, 5, 550, 40);
            else
                searchBar.Frame = new CGRect(40, 5, 210, 40);
            searchBar.Placeholder = "Enter text to search";
            searchBar.TextChanged += SearchBar_TextChanged;
            searchBar.SearchButtonClicked += SearchBar_SearchButtonClicked;
            searchToolBar.Add(searchBar);

            return searchToolBar;
        }
        internal void ToolbarBackbutton_TouchUpInside(object sender, EventArgs e)
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                pdfViewerControl.EndInkSession(false);
            }
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            annotHelper.RemoveAllToolbars(false);
            Add(annotationToolbar);
            isColorSelected = false;
            FontSizePanel.RemoveFromSuperview();
            rangeSlider.RemoveFromSuperview();
        }
        private void SearchBar_TextChanged(object sender, UISearchBarTextChangedEventArgs e)
        {
            if ((sender as UISearchBar).Text == string.Empty)
            {
                pdfViewerControl.CancelSearch();
            }
        }
        private void SearchCancelClicked(object sender, EventArgs e)
        {
            pdfViewerControl.CancelSearch();
            searchBar.Text = String.Empty;
        }
        public void UpdateToolBarValues()
        {
            pageNumberField.Text = pdfViewerControl.PageNumber.ToString();
        }
        private void SearchBar_SearchButtonClicked(object sender, EventArgs e)
        {
            dropDownMenu.Close();
            searchBar.ResignFirstResponder();
            pdfViewerControl.SearchText(searchBar.Text);
        }
        void RedoButton_TouchUpInside(object sender, EventArgs e)
        {
            pdfViewerControl.PerformRedo();
            annotHelper.RemoveAllToolbars(false);
        }
        void UndoButton_TouchUpInside(object sender, EventArgs e)
        {
            pdfViewerControl.PerformUndo();
            annotHelper.RemoveAllToolbars(false);
        }
        void SearchClicked(object sender, EventArgs ea)
        {
            pdfViewerControl.SearchText(searchBar.Text);
        }
        void SearchButtonClicked(object sender, EventArgs ea)
        {
            annotHelper.RemoveAllToolbars(false);
            toolbar.RemoveFromSuperview();
            backButton.Enabled = true;
            CreateSearchTopToolbar();
            toolbar = searchToolBar;
            searchBar.BecomeFirstResponder();
            AddSubview(toolbar);
            isBookmarkPaneVisible = false;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad && bookmarkToolbar != null && bookmarkToolbar.Superview != null)
                bookmarkToolbar.RemoveFromSuperview();
            dropDownMenu.Close();
        }
        void BackButtonClicked(object sender, EventArgs ea)
        {
            pdfViewerControl.CancelSearch();
            searchBar.Text = String.Empty;
            UpdateToolBarValues();
            searchToolBar.RemoveFromSuperview();
            toolBar.RemoveFromSuperview();
            toolbar = toolBar;
            toolBarFrame.Height = DefaultToolbarHeight;
            AddSubview(toolbar);
        }
        #region DropDown
        private List<DropDownMenuItem> GetResource()
        {

            var list = new List<DropDownMenuItem>();
            list.Add(new DropDownMenuItem()
            {
                DisplayText = "F# Succinctly",
                IsSelected = true
            });
            list.Add(new DropDownMenuItem()
            {
                DisplayText = "GIS Succinctly",
            });
            list.Add(new DropDownMenuItem()
            {
                DisplayText = "HTTP Succinctly",
            });
            list.Add(new DropDownMenuItem()
            {
                DisplayText = "JavaScript Succinctly",
            });
            list.Add(new DropDownMenuItem()
            {
                DisplayText = "Encrypted Document",
            });

            return list;
        }
        private DropDownMenu CreateDropDownMenu()
        {
            var dropDownMenu = new DropDownMenu(this, GetResource().ToArray())
            {
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.Black,
                Opacity = 1,
                BorderWidth = 1,
                Frame = new CGRect(0, DefaultToolbarHeight + 20, 250, 250)
            };
            return dropDownMenu;
        }
        #endregion
        internal class TextFieldDelegate : UITextFieldDelegate
        {
            CustomToolbar m_customToolbar = null;
            internal TextFieldDelegate(CustomToolbar customToolbar)
            {
                m_customToolbar = customToolbar;
            }
            public override bool ShouldReturn(UITextField textField)
            {
                m_customToolbar.fileStream.Position = 0;
                m_customToolbar.pdfViewerControl.LoadDocument(m_customToolbar.fileStream, m_customToolbar.pwdEntry.Text);
                return true;
            }
        }
    } 
}
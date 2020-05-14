#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.IO;
using Syncfusion.SfRangeSlider.XForms;
using Syncfusion.Pdf.Parsing;
using System.Collections.ObjectModel;
using popuplayout = Syncfusion.XForms.PopupLayout;

namespace SampleBrowser.SfPdfViewer
{
    [Preserve(AllMembers = true)]
    public partial class PDFViewerCustomToolbar_Tablet : SampleView
    {
        bool m_isPageInitiated = false;
        bool isAnnotationEditMode = false;
        internal Grid parentGrid;
        ShapeAnnotation selectedShapeAnnotation;
        FreeTextAnnotation selectedFreeTextAnnotation;
        StampAnnotation selectedStampAnnotation;
        TextMarkupAnnotation selectedAnnotation;
        InkAnnotation selectedInkAnnotation;
        HandwrittenSignature selectedSignatureAnnotation;
        private float m_backUpVerticalOffset = 0;
        private float m_backUpHorizontalOffset = 0;
        private float m_backUpZoomFactor = 0;
        string currentDocument = "F# Succinctly";
        private bool m_canRestoreBackup = false;
        bool canSetValueToSource = true;
        internal PdfLoadedDocument bookmarkLoadedDocument;
        internal IList<CustomBookmark> listViewItemsSource = new ObservableCollection<CustomBookmark>();
        BookmarkToolbar bookmarkToolbar;
        internal Syncfusion.SfPdfViewer.XForms.SfPdfViewer pdfViewer;
        StampAnnotationView stampView;
        private bool isDocumentLoaded = false;
        public PDFViewerCustomToolbar_Tablet()
        {
            InitializeComponent();
            pdfViewer = pdfViewerControl;
            string filePath = string.Empty;
#if COMMONSB
                filePath = "SampleBrowser.Samples.PdfViewer.Samples.";

#else
            filePath = "SampleBrowser.SfPdfViewer.";

#endif
            pdfViewerControl.PasswordErrorOccurred += PdfViewerControl_PasswordErrorOccurred;
            pdfViewerControl.UnhandledConditionOccurred += PdfViewerControl_UnhandledConditionOccurred;
            var m_pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath + "Assets." + "F# Succinctly" + ".pdf");
            pdfViewerControl.LoadDocument(m_pdfDocumentStream);
            parentGrid = mainGrid;
            if (Application.Current.MainPage != null)
            {
                toolbar.WidthRequest = Application.Current.MainPage.Width;
                searchBar.WidthRequest = Application.Current.MainPage.Width;
            }
            if (Device.RuntimePlatform == Device.UWP)
                arrowButton.IsVisible = false;
            textSearchEntry.TextChanged += TextSearchEntry_TextChanged;
            pdfViewerControl.TextMatchFound += PdfViewerControl_TextMatchFound;
            pdfViewerControl.CanUndoModified += PdfViewerControl_CanUndoModified;
            pdfViewerControl.CanRedoModified += PdfViewerControl_CanRedoModified;
            pdfViewerControl.CanUndoInkModified += PdfViewerControl_CanUndoInkModified;
            pdfViewerControl.CanRedoInkModified += PdfViewerControl_CanRedoInkModified;
            pdfViewerControl.DocumentLoaded += PdfViewerControl_DocumentLoaded;
            pdfViewerControl.SearchCompleted+= PdfViewerControl_SearchCompleted;
            pdfViewerControl.Toolbar.Enabled = false;
            pdfViewerControl.IsPasswordViewEnabled = false;
            pdfViewerControl.Tapped += PdfViewerControl_Tapped;
            pdfViewerControl.PageChanged += PdfViewerControl_PageChanged;
            pdfViewerControl.ShapeAnnotationSelected += PdfViewerControl_ShapeAnnotationSelected;
            pdfViewerControl.FreeTextAnnotationSelected += PdfViewerControl_FreeTextAnnotationSelected;
            pdfViewerControl.ShapeAnnotationDeselected += PdfViewerControl_ShapeAnnotationDeselected;
            pdfViewerControl.FreeTextAnnotationDeselected += PdfViewerControl_FreeTextAnnotationDeselected;
            pdfViewerControl.FreeTextPopupAppearing += PdfViewerControl_FreeTextPopupAppearing;
            pdfViewerControl.FreeTextPopupDisappeared += PdfViewerControl_FreeTextPopupDisappeared;
            (BindingContext as PdfViewerViewModel).HighlightColor = pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color;
            (BindingContext as PdfViewerViewModel).UnderlineColor = pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color;
            (BindingContext as PdfViewerViewModel).StrikeThroughColor = pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color;
            (BindingContext as PdfViewerViewModel).InkColor = pdfViewerControl.AnnotationSettings.Ink.Color;
            (BindingContext as PdfViewerViewModel).EditTextColor = pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            (BindingContext as PdfViewerViewModel).RectangleStrokeColor = pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor;
            (BindingContext as PdfViewerViewModel).LineStrokeColor = pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor;
            (BindingContext as PdfViewerViewModel).CircleStrokeColor = pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor;
            (BindingContext as PdfViewerViewModel).ArrowStrokeColor = pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor;
            (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor;
            cancelSearchButton.Clicked += CancelSearchButton_Clicked;
            TapGestureRecognizer bookmarkLayoutTapGesture = new TapGestureRecognizer();
            TapGestureRecognizer printLayoutTapGesture = new TapGestureRecognizer();
            bookmarkLayout.GestureRecognizers.Add(bookmarkLayoutTapGesture);
            PrintLayout.GestureRecognizers.Add(printLayoutTapGesture);
            bookmarkLayoutTapGesture.Tapped += bookmarkButton_Clicked;
            printLayoutTapGesture.Tapped += PrintButtonClicked;
            m_isPageInitiated = true;
            pageNumberEntry.PdfViewer = pdfViewerControl;
            pageNumberEntry.IsPageNumberEntry = true;
            pageNumberEntry.Completed += PageNumberEntry_Completed;
            slider.Value = pdfViewerControl.AnnotationSettings.Ink.Thickness;
            opacitySlider.Value = pdfViewerControl.AnnotationSettings.Ink.Opacity * 100;
            slider.ValueChanged += Slider_ValueChanged;
            fontSizeSlider.ShowValueLabel = false;
            fontSizeSlider.Minimum = 6;
            fontSizeSlider.Maximum = 22;
            fontSizeSlider.Value = 12;
            fontSizeSlider.KnobColor = (Device.RuntimePlatform == Device.iOS) ? Color.White : Color.Blue;
            fontSizeSlider.TrackSelectionColor = Color.Blue;
            fontSizeSlider.TrackColor = Color.Gray;
            fontSizeSlider.TickFrequency = 2;
            fontSizeSlider.StepFrequency = 2;
            fontSizeSlider.ShowRange = false;
            fontSizeSlider.Orientation = Syncfusion.SfRangeSlider.XForms.Orientation.Horizontal;
            fontSizeSlider.TickPlacement = TickPlacement.Inline;
            fontSizeSlider.ToolTipPlacement = ToolTipPlacement.None;

            opacitySlider.ValueChanged += OpacitySlider_ValueChanged;
            fontSizeSlider.Value = pdfViewerControl.AnnotationSettings.FreeText.TextSize;
            fontSizeSlider.ValueChanging += FontSizeSlider_ValueChanging; 
            fontSizeSlider.Value = pdfViewerControl.AnnotationSettings.FreeText.TextSize;
            fontSizeSliderValue.Text = pdfViewerControl.AnnotationSettings.FreeText.TextSize.ToString();
            bookmarkToolbar = new BookmarkToolbar(this);
            bookmarkToolbar.WidthRequest = 0;
            Grid.SetColumn(bookmarkToolbar, 1);
            pdfViewerGrid.Children.Add(bookmarkToolbar);

            signatureButton.FontFamily = FontMappingHelper.SignatureFont;
            signatureButton.Text = FontMappingHelper.Signature;
            stampView = new StampAnnotationView(pdfViewer);
            InitializePasswordDialog();

        }

        private void PdfViewerControl_PageChanged(object sender, PageChangedEventArgs args)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;

            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsPickerVisible = false;

        }

        private void PdfViewerControl_Tapped(object sender, TouchInteractionEventArgs e)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;

            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsPickerVisible = false;
        }

        popuplayout.SfPopupLayout popup;
        int i = 0;
        private Button okButton = new Button();
        private Entry passwordEntry = new Entry();
        private Label errorContent = new Label();
        void InitializePasswordDialog()
        {
            #region Password Protected
            popup = new popuplayout.SfPopupLayout();
            popup.PopupView.ShowFooter = true;
            popup.StaysOpen = true;
            popup.PopupView.MinimumWidthRequest = 100;
            popup.PopupView.MinimumHeightRequest = 100;
            popup.PopupView.HeightRequest = 210;
            popup.PopupView.WidthRequest = 330;
            popup.Closing += Popup_Closing;
            if (Device.RuntimePlatform == Device.iOS)
            {
                popup.PopupView.ShowCloseButton = false;
                popup.PopupView.HeightRequest = 220;
            }
              
            if (Device.RuntimePlatform != Device.iOS)
                popup.PopupView.HeightRequest = 200;
            popup.Closed += Popup_Closed;

            #region HeaderTemplate

            popup.PopupView.HeaderTemplate = new DataTemplate(() =>
            {
                StackLayout layout = new StackLayout()
                {
                    Padding = new Thickness(20, 15, 0, 0),
                    BackgroundColor = Color.White,
                    HeightRequest = 20
                };

                Label headerLabel = new Label()
                {
                    Text = "Password Protected",
                    FontSize = 20,
                    TextColor = Color.Black,
                    FontFamily = "Roboto-Medium",
                    HeightRequest = 24,
                };
                if (Device.RuntimePlatform == Device.iOS)
                    headerLabel.HorizontalOptions = LayoutOptions.Center;

                layout.Children.Add(headerLabel);
                return layout;
            }
            );


            #endregion



            #region  ContentTemplate

            popup.PopupView.ContentTemplate = new DataTemplate(() =>
            {
                StackLayout contentLayout = new StackLayout()
                {
                    BackgroundColor = Color.Transparent,
                    Padding = new Thickness(20, 10, 20, 0),
                    Spacing = 5
                };

                Label bodyContent = new Label()
                {
                    BackgroundColor = Color.Transparent,
                    Text = "Enter the password to open this PDF File.",
                    TextColor = Color.Black,
                    FontSize = 15,
                    FontFamily = "Roboto-Regular"
                };

                if (Device.RuntimePlatform == Device.iOS)
                {
                    passwordEntry.MinimumHeightRequest = 40;
                    passwordEntry.HeightRequest = 40;
                    passwordEntry.Margin = new Thickness(0,10,0,0);
                }

                passwordEntry.BackgroundColor = Color.Transparent;
                passwordEntry.Text = "";
                passwordEntry.Placeholder = "Password: syncfusion";
                passwordEntry.TextColor = Color.Black;
                passwordEntry.FontSize = 15;
                passwordEntry.FontFamily = "Roboto-Regular";
                passwordEntry.IsPassword = true;
                passwordEntry.TextChanged += PasswordEntry_TextChanged;
                passwordEntry.Completed+= OkButton_Clicked;

                Label errorContentInstance = new Label()
                {
                    BackgroundColor = Color.Transparent,
                    Text = "Invalid Password!",
                    TextColor = Color.Red,
                    FontSize = 15,
                    FontFamily = "Roboto-Regular",
                    IsVisible = false
                };
				if (Device.RuntimePlatform == Device.Android)
                {
                    errorContentInstance.Margin = new Thickness(0, -15, 0, 0);
                    passwordEntry.Margin = new Thickness(-3, 10, 0, 0);
                }

                this.errorContent = errorContentInstance;
                contentLayout.Children.Add(bodyContent);
                contentLayout.Children.Add(passwordEntry);
                contentLayout.Children.Add(this.errorContent);

                return contentLayout;
            });


            #endregion
            #region  FooterTemplate

            popup.PopupView.FooterTemplate = new DataTemplate(() =>
            {
                StackLayout layout = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 10

                };

                if (Device.RuntimePlatform != Device.iOS)
                    layout.Padding = new Thickness(170, 10, 0, 10);
                layout.BackgroundColor = Color.Transparent;
                Button cancelButton = new Button()
                {
                    Text = "Cancel",
                    FontSize = 15,
                    TextColor = Color.Black,
                    FontFamily = "Roboto-Medium",
                    BackgroundColor = Color.Transparent,
                    MinimumWidthRequest = 75,
                    WidthRequest = 75,
                };

                cancelButton.Clicked += CancelButton_Clicked;

                okButton.Text = "Ok";
                okButton.FontSize = 15;
                //okButton.Margin = new Thickness(20,0,0,0);
                okButton.TextColor = Color.FromRgba(2, 119, 255, 38);
                okButton.FontFamily = "Roboto-Medium";
                okButton.Clicked += OkButton_Clicked;
                okButton.IsEnabled = false;
                okButton.TextColor = Color.FromRgb(176, 176, 176);
                okButton.BackgroundColor = Color.Transparent;
                okButton.WidthRequest = 75;
                okButton.MinimumWidthRequest = 75;
                if (Device.RuntimePlatform == Device.iOS)
                    okButton.HorizontalOptions = LayoutOptions.FillAndExpand;
                if (Device.RuntimePlatform == Device.iOS)
                    cancelButton.HorizontalOptions = LayoutOptions.FillAndExpand;

                if (Device.Idiom == TargetIdiom.Tablet && Device.RuntimePlatform == Device.Android)
                {
                    layout.Padding = new Thickness(160, 5, 0, 0);
                    layout.Spacing = 0;
                    cancelButton.WidthRequest = 85;
                    okButton.HeightRequest = layout.Height - 10;
                    cancelButton.HeightRequest = layout.Height - 10;
                    //okButton.ContentLayout = .Center;
                }
                layout.Children.Add(cancelButton);
                layout.Children.Add(okButton);

                return layout;
            }
            );

            #endregion

            #endregion
        }

        private void Popup_Closing(object sender, Syncfusion.XForms.Core.CancelEventArgs e)
        {
            okButton.Clicked -= OkButton_Clicked;
			passwordEntry.Completed -= OkButton_Clicked;
        }

        private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == "")
            {
                if (okButton != null)
                {
                    okButton.IsEnabled = false;
                    okButton.TextColor = Color.FromRgba(2, 119, 255, 38);
                }
            }
            else
            {
                okButton.IsEnabled = true;
                okButton.TextColor = Color.FromRgb(2, 119, 255);
            }
        }

        private void OkButton_Clicked(object sender, EventArgs e)
        {
            passwordEntry.Unfocus();
            if (isDocumentLoaded)
                return;
            var filePath = string.Empty;
#if COMMONSB
            filePath = "SampleBrowser.Samples.PdfViewer.Samples.";

#else
            filePath = "SampleBrowser.SfPdfViewer.";

#endif
            pdfViewer.Unload();
            var fileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath + "Assets." + currentDocument + ".pdf");
            fileStream.Position = 0;
            pdfViewer.LoadDocument(fileStream, passwordEntry.Text);
        }


        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            passwordEntry.Unfocus();
            popup.Dismiss();
            i = 0;
            passwordEntry.Text = "";
            DisableAllButtons();
            pdfViewer.Unload();
        }
        private void Popup_Closed(object sender, EventArgs e)
        {
            if (isDocumentLoaded)
            {
                EnableAllButtons();
            }
            else
            {
                DisableAllButtons();
                pdfViewerControl.Unload();
            }

        }

        private void PdfViewerControl_PasswordErrorOccurred(object sender, PasswordErrorOccurredEventArgs e)
        {
            if (e.Title == "Error loading encrypted PDF document")
            {
                if (i == 0)
                {
                    errorContent.IsVisible = false;
                    popup.Show();
                    i++;
                    isDocumentLoaded = false;
                }
                else
                {
                    errorContent.IsVisible = true;
                }
                passwordEntry.Text = "";
                passwordEntry.Focus();
            }
           

        }

        private void PdfViewerControl_UnhandledConditionOccurred(object sender, UnhandledConditionEventArgs args)
        {
            DependencyService.Get<IAlertView>().Show(args.Description);
        }

        void DisableAllButtons()
        {
            saveButton.IsEnabled = false;
            bookmarkButton.IsEnabled = false;
            pageNumberEntry.IsEnabled = false;
            annotationButton.IsEnabled = false;
            searchButton.IsEnabled = false;
            viewModeButton.IsEnabled = false;
            pageCountLabel.IsEnabled = false;
            pageDivSeparator.IsEnabled = false;
            moreOptionsButton.IsEnabled = false;
            pageCountLabel.TextColor = Color.FromRgb(176,176,176);
            pageDivSeparator.TextColor = Color.FromRgb(176,176,176);
        }

        void EnableAllButtons()
        {
            saveButton.IsEnabled = true;
            bookmarkButton.IsEnabled = true;
            pageNumberEntry.IsEnabled = true;
            annotationButton.IsEnabled = true;
            searchButton.IsEnabled = true;
            viewModeButton.IsEnabled = true;
            pageCountLabel.IsEnabled = true;
            pageDivSeparator.IsEnabled = true;
            moreOptionsButton.IsEnabled = true;
            pageCountLabel.TextColor = Color.FromRgb(2,119,255);
            pageDivSeparator.TextColor = Color.FromRgb(2, 119, 255);
           

        }

        private void PdfViewerControl_FreeTextPopupDisappeared(object sender, FreeTextPopupDisappearedEventArgs args)
        {
            (BindingContext as PdfViewerViewModel).IsOpacityBarVisible = false;
            (BindingContext as PdfViewerViewModel).IsFontSizeSliderBarVisible = false;
            (BindingContext as PdfViewerViewModel).IsColorBarVisible = false;
            if ((BindingContext as PdfViewerViewModel).IsEditTextAnnotationBarVisible)
                (BindingContext as PdfViewerViewModel).IsEditTextAnnotationBarVisible = true;
            if ((BindingContext as PdfViewerViewModel).IsEditFreeTextAnnotationBarVisible)
                (BindingContext as PdfViewerViewModel).IsEditFreeTextAnnotationBarVisible = true;
        }

        private void AnnotationButtonClicked(object sender, EventArgs args)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
            pdfViewerControl.SelectionMode = Syncfusion.SfPdfViewer.XForms.SelectionMode.None;
            CollapseBookmarkPane();
        }
        private void PdfViewerControl_FreeTextPopupAppearing(object sender, FreeTextPopupAppearingEventArgs args)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
            (BindingContext as PdfViewerViewModel).IsOpacityBarVisible = false;
            (BindingContext as PdfViewerViewModel).IsFontSizeSliderBarVisible = false;
            (BindingContext as PdfViewerViewModel).IsColorBarVisible = false;
            if ((BindingContext as PdfViewerViewModel).IsEditTextAnnotationBarVisible)
                (BindingContext as PdfViewerViewModel).IsEditTextAnnotationBarVisible = false;
            if ((BindingContext as PdfViewerViewModel).IsEditFreeTextAnnotationBarVisible)
                (BindingContext as PdfViewerViewModel).IsEditFreeTextAnnotationBarVisible = false;
        }
        private void PdfViewerControl_FreeTextAnnotationDeselected(object sender, FreeTextAnnotationDeselectedEventArgs args)
        {
            selectedFreeTextAnnotation = null;
            isAnnotationEditMode = false;
            canSetValueToSource = false;            
            fontSizeSlider.Value = pdfViewerControl.AnnotationSettings.FreeText.TextSize;
            fontSizeSliderValue.Text = pdfViewerControl.AnnotationSettings.FreeText.TextSize.ToString();
        }
        private void FontSizeSlider_ValueChanging(object sender, Syncfusion.SfRangeSlider.XForms.ValueEventArgs e)
        {
            if (canSetValueToSource)
            {
                if (selectedFreeTextAnnotation != null)
                    selectedFreeTextAnnotation.Settings.TextSize = (int)(e.Value);

                else if (pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                    pdfViewerControl.AnnotationSettings.FreeText.TextSize = (int)(e.Value);
            }

            fontSizeSliderValue.Text = ((Int32)e.Value).ToString();
            canSetValueToSource = true;
        }

        private void PdfViewerControl_ShapeAnnotationDeselected(object sender, ShapeAnnotationDeselectedEventArgs args)
        {
            
            isAnnotationEditMode = false;
            canSetValueToSource = false;

            if ((BindingContext as PdfViewerViewModel).IsEditRectangleAnnotationBarVisible)
                (BindingContext as PdfViewerViewModel).IsEditRectangleAnnotationBarVisible = false;
            else if ((BindingContext as PdfViewerViewModel).IsEditCircleAnnotationBarVisible)
                (BindingContext as PdfViewerViewModel).IsEditCircleAnnotationBarVisible = false;
            else if ((BindingContext as PdfViewerViewModel).IsEditLineAnnotationBarVisible)
                (BindingContext as PdfViewerViewModel).IsEditLineAnnotationBarVisible = false;
            else if ((BindingContext as PdfViewerViewModel).IsEditArrowAnnotationBarVisible)
                (BindingContext as PdfViewerViewModel).IsEditArrowAnnotationBarVisible = false;

            AnnotationMode annotationMode = args.AnnotationType;
            selectedShapeAnnotation = null;
        }

        private void PdfViewerControl_DocumentLoaded(object sender, EventArgs args)
        {
            i = 0;
            EnableAllButtons();
            if (popup != null)
                popup.Dismiss();

            if (errorContent != null)
                errorContent.IsVisible = false;

            string filePath = string.Empty;
            if (Device.RuntimePlatform == Device.Android)
            {
                if (m_canRestoreBackup)
                {
                    pdfViewerControl.ZoomPercentage = m_backUpZoomFactor;
                    pdfViewerControl.VerticalOffset = m_backUpVerticalOffset;
                    pdfViewerControl.HorizontalOffset = m_backUpHorizontalOffset;
                    m_canRestoreBackup = false;
                }
            }

#if COMMONSB
            filePath = "SampleBrowser.Samples.PdfViewer.Samples.";

#else
            filePath = "SampleBrowser.SfPdfViewer.";
           
#endif
            if ((this.BindingContext as PdfViewerViewModel) != null
                && (this.BindingContext as PdfViewerViewModel).SelectedItem != null)
            {
                if ((this.BindingContext as PdfViewerViewModel).SelectedItem.FileName != currentDocument)
                    currentDocument = (this.BindingContext as PdfViewerViewModel).SelectedItem.FileName;
            }

            Stream stream = (typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath + "Assets." + currentDocument + ".pdf"));
            if (passwordEntry != null && passwordEntry.Text != null && passwordEntry.Text != string.Empty)
                bookmarkLoadedDocument = new PdfLoadedDocument(stream, passwordEntry.Text);
            else
                bookmarkLoadedDocument = new PdfLoadedDocument(stream);
            bookmarkToolbar.bookmarkLoadedDocument = bookmarkLoadedDocument;
			//Once the PDF is loaded populate the bookmark listview with the bookmarks of the PDF
            bookmarkToolbar.PopulateInitialBookmarkList();
            isDocumentLoaded = true;
        }

        internal void RefreshPageAfterSleep(bool isPageSwitched)
        {
			string filePath = string.Empty;
#if COMMONSB
            filePath = "SampleBrowser.Samples.PdfViewer.Samples.";

#else
            filePath = "SampleBrowser.SfPdfViewer.";
           
#endif
            m_canRestoreBackup = !isPageSwitched;
            if (!isPageSwitched)
            {
                Stream stream = (typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath + "Assets." + currentDocument + ".pdf"));
                bookmarkLoadedDocument = new PdfLoadedDocument(stream);
                (BindingContext as PdfViewerViewModel).PdfDocumentStream = stream;
                if (bookmarkToolbar != null)
                {
                    bookmarkToolbar.bookmarkLoadedDocument = bookmarkLoadedDocument;
					//Once the PDF is loaded populate the bookmark listview with the bookmarks of the PDF
                    bookmarkToolbar.PopulateInitialBookmarkList();
                }
            }
        }
        internal void CollectGC()
        {
            m_backUpHorizontalOffset = pdfViewerControl.HorizontalOffset;
            m_backUpVerticalOffset = pdfViewerControl.VerticalOffset;
            m_backUpZoomFactor = pdfViewerControl.ZoomPercentage;
            pdfViewerControl.Unload();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            isDocumentLoaded = false;
            currentDocument = (e.SelectedItem as Document).FileName;

            string filePath = string.Empty;
#if COMMONSB
                filePath = "SampleBrowser.Samples.PdfViewer.Samples.";

#else
            filePath = "SampleBrowser.SfPdfViewer.";

#endif
            pdfViewerControl.Unload();
            var pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath + "Assets." + currentDocument + ".pdf");

            pdfViewerControl.LoadDocument(pdfDocumentStream);

            if (Device.RuntimePlatform == Device.Android)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
			//When a new PDF is opened collapse the bookmark toolbar
            CollapseBookmarkPane();
        }

		//Collapses the bookmark toolbar
        internal void CollapseBookmarkPane()
        {
            bookmarkToolbar.WidthRequest = 0;
            bookmarkToolbar.isBookmarkPaneVisible = false;
        }
        private void PdfViewerControl_InkDeselected(object sender, InkDeselectedEventArgs args)
        {            
            isAnnotationEditMode = false;
            canSetValueToSource = false;
            selectedInkAnnotation = null;
            selectedSignatureAnnotation = null;
        }

        private void PdfViewerControl_InkSelected(object sender, InkSelectedEventArgs args)
        {
            if (sender is InkAnnotation)
            {
                selectedInkAnnotation = sender as InkAnnotation;
                isAnnotationEditMode = true;
                (BindingContext as PdfViewerViewModel).InkDeleteColor = new Color(selectedInkAnnotation.Settings.Color.R, selectedInkAnnotation.Settings.Color.G, selectedInkAnnotation.Settings.Color.B);
                opacitySlider.Value = selectedInkAnnotation.Settings.Opacity * 100;
                canSetValueToSource = true;
            }
            else
            {
                selectedSignatureAnnotation = sender as HandwrittenSignature;
                isAnnotationEditMode = true;
                (BindingContext as PdfViewerViewModel).InkDeleteColor = new Color(selectedSignatureAnnotation.Settings.Color.R, selectedSignatureAnnotation.Settings.Color.G, selectedSignatureAnnotation.Settings.Color.B);
                opacitySlider.Value = selectedSignatureAnnotation.Settings.Opacity * 100;
                canSetValueToSource = true;
            }
        }

        private void PdfViewerControl_CanRedoInkModified(object sender, CanRedoInkModifiedEventArgs args)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
            if (args.CanRedoInk)
            {
                if (Device.RuntimePlatform != Device.UWP)
                    inkRedoBtn.TextColor = Color.FromHex("#0076FF");
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        inkRedoBtn.TextColor = Color.FromHex("#0076FF");
                    });
                }
            }
            else
                inkRedoBtn.TextColor = Color.DarkGray;
        }

        private void PdfViewerControl_CanUndoInkModified(object sender, CanUndoInkModifiedEventArgs args)
        {
            if (args.CanUndoInk)
            {
                if (Device.RuntimePlatform != Device.UWP)
                    inkUndoBtn.TextColor = Color.FromHex("#0076FF");
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        inkUndoBtn.TextColor = Color.FromHex("#0076FF");
                    });
                }
            }
            else
                inkUndoBtn.TextColor = Color.DarkGray;
        }

        private void OpacitySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (canSetValueToSource)
            {
                if (selectedInkAnnotation != null)
                    selectedInkAnnotation.Settings.Opacity = (float)(Math.Round(e.NewValue, 0) / 100);
                else if (selectedSignatureAnnotation != null)
                    selectedSignatureAnnotation.Settings.Opacity = (float)(Math.Round(e.NewValue, 0) / 100);
                else if (selectedShapeAnnotation != null)
                    selectedShapeAnnotation.Settings.Opacity = (float)(Math.Round(e.NewValue, 0) / 100);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                    pdfViewerControl.AnnotationSettings.Ink.Opacity = (float)(Math.Round(e.NewValue, 0) / 100);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                    pdfViewerControl.AnnotationSettings.Rectangle.Settings.Opacity = (float)(Math.Round(e.NewValue, 0) / 100);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                    pdfViewerControl.AnnotationSettings.Circle.Settings.Opacity = (float)(Math.Round(e.NewValue, 0) / 100);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                    pdfViewerControl.AnnotationSettings.Line.Settings.Opacity = (float)(Math.Round(e.NewValue, 0) / 100);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                    pdfViewerControl.AnnotationSettings.Arrow.Settings.Opacity = (float)(Math.Round(e.NewValue, 0) / 100);
            }
            opacityValue.Text = ((int)Math.Round(e.NewValue, 0)).ToString() + "%";
            canSetValueToSource = true;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (canSetValueToSource)
            {
                if (selectedInkAnnotation != null)
                    selectedInkAnnotation.Settings.Thickness = (float)e.NewValue;
                else if (selectedSignatureAnnotation != null)
                    selectedSignatureAnnotation.Settings.Thickness = (float)e.NewValue;
                if (selectedShapeAnnotation != null)
                    selectedShapeAnnotation.Settings.Thickness = (int)e.NewValue;
                else if (selectedFreeTextAnnotation != null)
                    selectedFreeTextAnnotation.Settings.TextSize = (int)(e.NewValue);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                    pdfViewerControl.AnnotationSettings.Ink.Thickness = (float)e.NewValue;
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                    pdfViewerControl.AnnotationSettings.Rectangle.Settings.Thickness = (int)(e.NewValue);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                    pdfViewerControl.AnnotationSettings.Circle.Settings.Thickness = (int)(e.NewValue);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                    pdfViewerControl.AnnotationSettings.Line.Settings.Thickness =(int)(e.NewValue);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                    pdfViewerControl.AnnotationSettings.Arrow.Settings.Thickness = (int)(e.NewValue);
            }
            sliderValue.Text = ((Int32)e.NewValue).ToString();
            
            canSetValueToSource = true;
        }

        private void PageNumberEntry_Completed(object sender, EventArgs e)
        {
            int pageNumber = 0;
            int.TryParse((sender as CustomEntry).Text, out pageNumber);
            if(pageNumber>pdfViewerControl.PageCount||pageNumber<0)
            {
                DependencyService.Get<IAlertView>().Show("Please enter a valid page number.");
                pageNumberEntry.Text = pdfViewerControl.PageNumber.ToString();
            }
            else if (pageNumber != 0)
                pdfViewerControl.GoToPage(pageNumber);
        }

        private void PdfViewerControl_SearchCompleted(object sender, TextSearchCompletedEventArgs args)
        {
            if (args.NoMatchFound)
            {
                DependencyService.Get<IAlertView>().Show("\"" + args.TargetText + "\"" + " not found.");
                searchNextButton.IsVisible = false;
                searchPreviousButton.IsVisible = false;
            }
            else if (args.NoMoreOccurrence)
                DependencyService.Get<IAlertView>().Show("No more matches were found.");
        }

        private void PdfViewerControl_CanRedoModified(object sender, CanRedoModifiedEventArgs args)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
            if (args.CanRedo)
                redoButton.TextColor = Color.FromHex("#0076FF");
            else
                redoButton.TextColor = Color.DarkGray;
        }

        private void PdfViewerControl_CanUndoModified(object sender, CanUndoModifiedEventArgs args)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
            if (args.CanUndo)
                undoButton.TextColor = Color.FromHex("#0076FF");
            else
                undoButton.TextColor = Color.DarkGray;
        }


        private void PdfViewerControl_TextMarkupSelected(object sender, TextMarkupSelectedEventArgs args)
        {
            selectedAnnotation = sender as TextMarkupAnnotation;
            isAnnotationEditMode = true;
            (BindingContext as PdfViewerViewModel).DeleteButtonColor = new Color(selectedAnnotation.Settings.Color.R, selectedAnnotation.Settings.Color.G, selectedAnnotation.Settings.Color.B);
        }

        private void PdfViewerControl_TextMarkupDeselected(object sender, TextMarkupDeselectedEventArgs args)
        {
            selectedAnnotation = null;
            isAnnotationEditMode = false;
        }

        private void InkBackButton_Clicked(object sender, EventArgs e)
        {
	    pdfViewerControl.EndInkSession(false);
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.SelectionMode = Syncfusion.SfPdfViewer.XForms.SelectionMode.None;
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (selectedAnnotation != null)
            {
                pdfViewerControl.RemoveAnnotation(selectedAnnotation);
                selectedAnnotation = null;
                isAnnotationEditMode = false;
            }
            else if (selectedStampAnnotation != null)
            {
                pdfViewerControl.RemoveAnnotation(selectedStampAnnotation);
                selectedStampAnnotation = null;
                isAnnotationEditMode = false;
            }
        }

        private void InkDeleteButton_Clicked(object sender, EventArgs e)
        {
            if (selectedInkAnnotation != null)
            {
                pdfViewerControl.RemoveAnnotation(selectedInkAnnotation);
                selectedInkAnnotation = null;
                isAnnotationEditMode = false;
            }
            if(selectedSignatureAnnotation != null)
            {
                pdfViewerControl.RemoveAnnotation(selectedSignatureAnnotation);
                selectedSignatureAnnotation = null;
                isAnnotationEditMode = false;
            }
        }

        private void ShapeDeleteButton_Clicked(object sender, EventArgs e)
        {
            if (selectedShapeAnnotation != null)
            {
                pdfViewerControl.RemoveAnnotation(selectedShapeAnnotation);
                selectedShapeAnnotation = null;
                isAnnotationEditMode = false;
            }
        }

        private void EditTextDeleteButton_Clicked(object sender, EventArgs e)
        {
            if (selectedFreeTextAnnotation != null)
            {
                pdfViewerControl.RemoveAnnotation(selectedFreeTextAnnotation);
                selectedFreeTextAnnotation = null;
                isAnnotationEditMode = false;
            }
        }

      


        private void InkButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
            pdfViewerControl.AnnotationMode = AnnotationMode.Ink;
        }
        private void EndSession_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.EndInkSession(true);
        }
        private void CancelSearchButton_Clicked(object sender, EventArgs e)
        {
            textSearchEntry.Text = string.Empty;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            string filePath = DependencyService.Get<ISave>().Save(pdfViewerControl.SaveDocument() as MemoryStream);
            string message = "The PDF has been saved to " + filePath;
            DependencyService.Get<IAlertView>().Show(message);
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
        }

        void PdfViewerControl_TextMatchFound(object sender, TextMatchFoundEventArgs args)
        {
            searchNextButton.IsVisible = true;
            searchPreviousButton.IsVisible = true;
        }

        //private void PdfViewerControl_UnhandledCondition(object sender, UnhandledConditionEventArgs args)
        //{
        //    DependencyService.Get<IAlertView>().Show(args.Description);
        //}

        private void TextSearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as Entry).Text == string.Empty)
            {
                pdfViewerControl.CancelSearch();
                searchNextButton.IsVisible = false;
                searchPreviousButton.IsVisible = false;
                cancelSearchButton.IsVisible = false;
            }
            else
                cancelSearchButton.IsVisible = true;
        }
        private void OnSearchClicked(object sender, EventArgs e)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
            textSearchEntry.Focus();
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.SelectionMode = Syncfusion.SfPdfViewer.XForms.SelectionMode.None;
            CollapseBookmarkPane();
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            textSearchEntry.Text = string.Empty;
            textSearchEntry.Focus();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Application.Current.MainPage != null && Application.Current.MainPage.Width > 0 && m_isPageInitiated)
            {
                toolbar.WidthRequest = Application.Current.MainPage.Width;
                searchBar.WidthRequest = Application.Current.MainPage.Width;
            }
        }

        private void ShapeAnnotationColorButton_Clicked(object sender, EventArgs e)
        {
            if(selectedInkAnnotation!=null)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = selectedInkAnnotation.Settings.Color;
            else if (selectedSignatureAnnotation != null)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = selectedSignatureAnnotation.Settings.Color;
            if (selectedShapeAnnotation != null)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = selectedShapeAnnotation.Settings.StrokeColor;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Ink.Color;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor;

        }

        private void ColorButton_Clicked(object sender, EventArgs e)
        {
            switch ((sender as Button).CommandParameter.ToString())
            {
                case "Cyan":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.FromHex("#00FFFF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.FromHex("#00FFFF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.FromHex("#00FFFF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.FromHex("#00FFFF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                                pdfViewerControl.AnnotationSettings.FreeText.TextColor = Color.FromHex("#00FFFF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                                pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor = Color.FromHex("#00FFFF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                                pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor = Color.FromHex("#00FFFF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                                pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor = Color.FromHex("#00FFFF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                                pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor = Color.FromHex("#00FFFF");

                            (BindingContext as PdfViewerViewModel).OpacityButtonColor = Color.FromHex("#00FFFF");
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.FromHex("#00FFFF");
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.FromHex("#00FFFF");
                            if (selectedSignatureAnnotation != null)
                                selectedSignatureAnnotation.Settings.Color = Color.FromHex("#00FFFF");
                            if (selectedFreeTextAnnotation != null)
                                selectedFreeTextAnnotation.Settings.TextColor = Color.FromHex("#00FFFF");
                            if (selectedShapeAnnotation != null)
                                selectedShapeAnnotation.Settings.StrokeColor = Color.FromHex("#00FFFF");

                        }
                    }
                    break;

                case "Green":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.Green;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.Green;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.Green;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.Green;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                                pdfViewerControl.AnnotationSettings.FreeText.TextColor = Color.Green;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                                pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor = Color.Green;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                                pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor = Color.Green;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                                pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor = Color.Green;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                                pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor = Color.Green;

                            (BindingContext as PdfViewerViewModel).OpacityButtonColor = Color.Green;
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.Green;
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.Green;
                            if (selectedSignatureAnnotation != null)
                                selectedSignatureAnnotation.Settings.Color = Color.Green;
                            if (selectedFreeTextAnnotation != null)
                                selectedFreeTextAnnotation.Settings.TextColor = Color.Green;
                            if (selectedShapeAnnotation != null)
                                selectedShapeAnnotation.Settings.StrokeColor = Color.Green;
                        }
                    }
                    break;

                case "Yellow":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.Yellow;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.Yellow;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.Yellow;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.Yellow;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                                pdfViewerControl.AnnotationSettings.FreeText.TextColor = Color.Yellow;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                                pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor = Color.Yellow;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                                pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor = Color.Yellow;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                                pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor = Color.Yellow;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                                pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor = Color.Yellow;
                            (BindingContext as PdfViewerViewModel).OpacityButtonColor = Color.Yellow;
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.Yellow;
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.Yellow;
                            if (selectedSignatureAnnotation != null)
                                selectedSignatureAnnotation.Settings.Color = Color.Yellow;
                            if (selectedFreeTextAnnotation != null)
                                selectedFreeTextAnnotation.Settings.TextColor = Color.Yellow;
                            if (selectedShapeAnnotation != null)
                                selectedShapeAnnotation.Settings.StrokeColor = Color.Yellow;
                        }
                    }
                    break;

                case "Magenta":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.FromHex("#FF00FF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.FromHex("#FF00FF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.FromHex("#FF00FF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.FromHex("#FF00FF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                                pdfViewerControl.AnnotationSettings.FreeText.TextColor = Color.FromHex("#FF00FF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                                pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor = Color.FromHex("#FF00FF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                                pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor = Color.FromHex("#FF00FF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                                pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor = Color.FromHex("#FF00FF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                                pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor = Color.FromHex("#FF00FF");
                            (BindingContext as PdfViewerViewModel).OpacityButtonColor = Color.FromHex("#FF00FF");
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.FromHex("#FF00FF");
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.FromHex("#FF00FF");
                            if (selectedSignatureAnnotation != null)
                                selectedSignatureAnnotation.Settings.Color = Color.FromHex("#FF00FF");
                            if (selectedFreeTextAnnotation != null)
                                selectedFreeTextAnnotation.Settings.TextColor = Color.FromHex("#FF00FF");
                            if (selectedShapeAnnotation != null)
                                selectedShapeAnnotation.Settings.StrokeColor = Color.FromHex("#FF00FF");
                        }
                    }
                    break;

                case "Black":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.Black;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.Black;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.Black;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.Black;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                                pdfViewerControl.AnnotationSettings.FreeText.TextColor = Color.Black;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                                pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor = Color.Black;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                                pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor = Color.Black;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                                pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor = Color.Black;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                                pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor = Color.Black;
                            (BindingContext as PdfViewerViewModel).OpacityButtonColor = Color.Black;
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.Black;
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.Black;
                            if (selectedSignatureAnnotation != null)
                                selectedSignatureAnnotation.Settings.Color = Color.Black;
                            if (selectedFreeTextAnnotation != null)
                                selectedFreeTextAnnotation.Settings.TextColor = Color.Black;
                            if (selectedShapeAnnotation != null)
                                selectedShapeAnnotation.Settings.StrokeColor = Color.Black;
                        }
                    }
                    break;

                case "White":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.White;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.White;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.White;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.White;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                                pdfViewerControl.AnnotationSettings.FreeText.TextColor = Color.White;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                                pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor = Color.White;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                                pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor = Color.White;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                                pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor = Color.White;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                                pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor = Color.White;

                            (BindingContext as PdfViewerViewModel).OpacityButtonColor = Color.White;
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.White;
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.White;
                            if (selectedSignatureAnnotation != null)
                                selectedSignatureAnnotation.Settings.Color = Color.White;
                            if (selectedFreeTextAnnotation != null)
                                selectedFreeTextAnnotation.Settings.TextColor = Color.White;
                            if (selectedShapeAnnotation != null)
                                selectedShapeAnnotation.Settings.StrokeColor = Color.White;
                        }
                    }
                    break;
            }
        }
        private void PdfViewerControl_FreeTextAnnotationSelected(object sender, FreeTextAnnotationSelectedEventArgs args)
        {
            selectedFreeTextAnnotation = sender as FreeTextAnnotation;
            isAnnotationEditMode = true;
            (BindingContext as PdfViewerViewModel).EditTextDeleteColor = new Color(selectedFreeTextAnnotation.Settings.TextColor.R, selectedFreeTextAnnotation.Settings.TextColor.G, selectedFreeTextAnnotation.Settings.TextColor.B);
            fontSizeSlider.Value = selectedFreeTextAnnotation.Settings.TextSize;
            fontSizeSliderValue.Text = selectedFreeTextAnnotation.Settings.TextSize.ToString();
           canSetValueToSource = true;
        }
        private void EditTextButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
            pdfViewerControl.EditFreeTextAnnotation();
        }
        private void OpacityButton_Clicked(object sender, EventArgs e)
        {
            if (selectedInkAnnotation != null)
                opacitySlider.Value = selectedInkAnnotation.Settings.Opacity * 100;
            else if (selectedSignatureAnnotation != null)
                opacitySlider.Value = selectedSignatureAnnotation.Settings.Opacity * 100;
            else if (selectedShapeAnnotation != null)
                opacitySlider.Value = selectedShapeAnnotation.Settings.Opacity * 100;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                opacitySlider.Value = pdfViewerControl.AnnotationSettings.Ink.Opacity * 100;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                opacitySlider.Value = pdfViewerControl.AnnotationSettings.Rectangle.Settings.Opacity * 100;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                opacitySlider.Value = pdfViewerControl.AnnotationSettings.Circle.Settings.Opacity * 100;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                opacitySlider.Value = pdfViewerControl.AnnotationSettings.Line.Settings.Opacity * 100;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                opacitySlider.Value = pdfViewerControl.AnnotationSettings.Arrow.Settings.Opacity * 100;

        }

        private void ThicknessButton_Clicked(object sender, EventArgs e)
        {
            if (selectedInkAnnotation != null && selectedInkAnnotation.Settings.Thickness <= 10)
                slider.Value = selectedInkAnnotation.Settings.Thickness;
            else if (selectedSignatureAnnotation != null && selectedSignatureAnnotation.Settings.Thickness <= 10)
                slider.Value = selectedSignatureAnnotation.Settings.Thickness;
            else if (selectedShapeAnnotation != null && selectedShapeAnnotation.Settings.Thickness <= 10)
                slider.Value = selectedShapeAnnotation.Settings.Thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                slider.Value = pdfViewerControl.AnnotationSettings.Ink.Thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                slider.Value = pdfViewerControl.AnnotationSettings.Rectangle.Settings.Thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                slider.Value = pdfViewerControl.AnnotationSettings.Circle.Settings.Thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                slider.Value = pdfViewerControl.AnnotationSettings.Line.Settings.Thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                slider.Value = pdfViewerControl.AnnotationSettings.Arrow.Settings.Thickness;
        }

        private void PdfViewerControl_ShapeAnnotationSelected(object sender, ShapeAnnotationSelectedEventArgs args)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
            selectedShapeAnnotation = sender as ShapeAnnotation;
            isAnnotationEditMode = true;
            (BindingContext as PdfViewerViewModel).IsOpacityBarVisible = false;
            (BindingContext as PdfViewerViewModel).IsThicknessBarVisible = false;
            (BindingContext as PdfViewerViewModel).IsMainAnnotationBarVisible = false;
            (BindingContext as PdfViewerViewModel).IsShapeColorBarVisible = false;
            (BindingContext as PdfViewerViewModel).IsShapeAnnotationBarVisible = false;
            (BindingContext as PdfViewerViewModel).AnnotationGridHeightRequest = 50;
            if (args.AnnotationType == AnnotationMode.Rectangle)
            {
                (BindingContext as PdfViewerViewModel).RectangleDeleteColor = new Color(selectedShapeAnnotation.Settings.StrokeColor.R, selectedShapeAnnotation.Settings.StrokeColor.G, selectedShapeAnnotation.Settings.StrokeColor.B);
                (BindingContext as PdfViewerViewModel).IsEditRectangleAnnotationBarVisible = true;
            }
            else if (args.AnnotationType == AnnotationMode.Circle)
            {
                (BindingContext as PdfViewerViewModel).CircleDeleteColor = new Color(selectedShapeAnnotation.Settings.StrokeColor.R, selectedShapeAnnotation.Settings.StrokeColor.G, selectedShapeAnnotation.Settings.StrokeColor.B);
                (BindingContext as PdfViewerViewModel).IsEditCircleAnnotationBarVisible = true;
            }
            else if (args.AnnotationType == AnnotationMode.Line)
            {
                (BindingContext as PdfViewerViewModel).LineDeleteColor = new Color(selectedShapeAnnotation.Settings.StrokeColor.R, selectedShapeAnnotation.Settings.StrokeColor.G, selectedShapeAnnotation.Settings.StrokeColor.B);
                (BindingContext as PdfViewerViewModel).IsEditLineAnnotationBarVisible = true;
            }
            else if (args.AnnotationType == AnnotationMode.Arrow)
            {
                (BindingContext as PdfViewerViewModel).ArrowDeleteColor = new Color(selectedShapeAnnotation.Settings.StrokeColor.R, selectedShapeAnnotation.Settings.StrokeColor.G, selectedShapeAnnotation.Settings.StrokeColor.B);
                (BindingContext as PdfViewerViewModel).IsEditArrowAnnotationBarVisible = true;
            }
            opacitySlider.Value = selectedShapeAnnotation.Settings.Opacity * 100;
            canSetValueToSource = true;
        }
        private void ShapeButton_Clicked(object sender, EventArgs e)
        {

        }
        private void EditText_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.FreeText;
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
        }

		//Handles the click event of the bookmark button
        private void bookmarkButton_Clicked(object sender, EventArgs e)
        {
			//The bookmark toolbar will take 40% of the total width of the application
            double bookmarkToolbarWidth = 0.4 * mainGrid.Width;
			//Set the width of the bookmark toolbar based on the isBookmarkPaneVisible property
            bookmarkToolbar.WidthRequest = bookmarkToolbar.isBookmarkPaneVisible ? 0 : bookmarkToolbarWidth;
            bookmarkToolbar.isBookmarkPaneVisible = !bookmarkToolbar.isBookmarkPaneVisible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
        }

        private void signatureButton_Clicked(object sender, EventArgs e)
        {
            pdfViewer.AnnotationMode = AnnotationMode.HandwrittenSignature;
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
        }

        private void StampButton_Clicked(object sender, EventArgs e)
        {
            mainGrid.Children.Add(stampView);
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
        }

        private void PdfViewerControl_StampAnnotationSelected(object sender, StampAnnotationSelectedEventArgs args)
        {
            selectedStampAnnotation = sender as StampAnnotation;
            isAnnotationEditMode = true;
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
        }

        private void PdfViewerControl_StampAnnotationDeselected(object sender, StampAnnotationDeselectedEventArgs args)
        {
            selectedStampAnnotation = null;
            isAnnotationEditMode = false;
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
        }

        private void PrintButtonClicked(object sender, EventArgs e)
        {
            if (BindingContext is PdfViewerViewModel)
                (BindingContext as PdfViewerViewModel).IsMoreOptionsToolBarVisible = false;
            if (pdfViewerControl != null)
                pdfViewerControl.Print();
            
        }
    }

}


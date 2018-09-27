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
using System.Collections.ObjectModel;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

namespace SampleBrowser.SfPdfViewer
{
    [Preserve(AllMembers = true)]
    public partial class PDFViewerCustomToolbar_Phone : SampleView
    {
        bool m_isPageInitiated = false;
        bool isAnnotationEditMode = false;
        internal Grid parentGrid;
        TextMarkupAnnotation selectedAnnotation;
        InkAnnotation selectedInkAnnotation;
        ShapeAnnotation selectedShapeAnnotation;

        FreeTextAnnotation selectedFreeTextAnnotation;
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
        public PDFViewerCustomToolbar_Phone()
        {
            InitializeComponent();
            pdfViewer = pdfViewerControl;
            parentGrid = mainGrid;
            if (Application.Current.MainPage != null)
            {
                toolbar.WidthRequest = Application.Current.MainPage.Width;
                searchBar.WidthRequest = Application.Current.MainPage.Width;
            }
            if (Device.RuntimePlatform == Device.UWP)
                arrowButton.IsVisible = false;
            textSearchEntry.TextChanged += TextSearchEntry_TextChanged;
            pdfViewerControl.UnhandledConditionOccurred += PdfViewerControl_UnhandledCondition;
            pdfViewerControl.TextMatchFound += PdfViewerControl_TextMatchFound;
            pdfViewerControl.CanUndoModified += PdfViewerControl_CanUndoModified;
            pdfViewerControl.CanRedoModified += PdfViewerControl_CanRedoModified;
            pdfViewerControl.CanUndoInkModified += PdfViewerControl_CanUndoInkModified;
            pdfViewerControl.CanRedoInkModified += PdfViewerControl_CanRedoInkModified;
            pdfViewerControl.DocumentLoaded += PdfViewerControl_DocumentLoaded;
            pdfViewerControl.SearchCompleted += PdfViewerControl_SearchCompleted;
            pdfViewerControl.FreeTextPopupAppearing += PdfViewerControl_FreeTextPopupAppearing;
            pdfViewerControl.FreeTextPopupDisappeared += PdfViewerControl_FreeTextPopupDisappeared;
            pdfViewerControl.ShapeAnnotationSelected += PdfViewerControl_ShapeAnnotationSelected;
            pdfViewerControl.FreeTextAnnotationSelected += PdfViewerControl_FreeTextAnnotationSelected;
            pdfViewerControl.FreeTextAnnotationDeselected += PdfViewerControl_FreeTextAnnotationDeselected;
            pdfViewerControl.ShapeAnnotationDeselected += PdfViewerControl_ShapeAnnotationDeselected;
            pdfViewerControl.Toolbar.Enabled = false;
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
            m_isPageInitiated = true;
            pageNumberEntry.PdfViewer = pdfViewerControl;
            opacitySlider.Value = pdfViewerControl.AnnotationSettings.Ink.Opacity * 100;
            slider.Value = pdfViewerControl.AnnotationSettings.Ink.Thickness;
            pageNumberEntry.IsPageNumberEntry = true;
            pageNumberEntry.Completed += PageNumberEntry_Completed;
            slider.ValueChanged += Slider_ValueChanged;
            opacitySlider.ValueChanged += OpacitySlider_ValueChanged;
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
            fontSizeSlider.Value = pdfViewerControl.AnnotationSettings.FreeText.TextSize;
            fontSizeSlider.ValueChanging += FontSizeSlider_ValueChanging;
            fontSizeSlider.Value = pdfViewerControl.AnnotationSettings.FreeText.TextSize;
            fontSizeSliderValue.Text = pdfViewerControl.AnnotationSettings.FreeText.TextSize.ToString();
            bookmarkToolbar = new BookmarkToolbar(this);
            Grid.SetRow(bookmarkToolbar, 0);
            Grid.SetRowSpan(bookmarkToolbar, 3);
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
            pdfViewerControl.SelectionMode = SelectionMode.None;
        }
        private void PdfViewerControl_FreeTextPopupAppearing(object sender, FreeTextPopupAppearingEventArgs args)
        {
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
        }
        private void FontSizeSlider_ValueChanging(object sender, Syncfusion.SfRangeSlider.XForms.ValueEventArgs e)
        {
            if (canSetValueToSource)
            {
                if (selectedFreeTextAnnotation != null)
                    selectedFreeTextAnnotation.Settings.TextSize = (int)(e.Value);
                else if(pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                    pdfViewerControl.AnnotationSettings.FreeText.TextSize = (int)(e.Value);
            }

            fontSizeSliderValue.Text = ((Int32)e.Value).ToString();
            canSetValueToSource = true;
        }

        private void PdfViewerControl_FreeTextAnnotationSelected(object sender, FreeTextAnnotationSelectedEventArgs args)
        {
            selectedFreeTextAnnotation = sender as FreeTextAnnotation;
            isAnnotationEditMode = true;
            (BindingContext as PdfViewerViewModel).EditTextDeleteColor = new Color(selectedFreeTextAnnotation.Settings.TextColor.R, selectedFreeTextAnnotation.Settings.TextColor.G, selectedFreeTextAnnotation.Settings.TextColor.B);
            fontSizeSlider.Value = selectedFreeTextAnnotation.Settings.TextSize;
            canSetValueToSource = true;
        }

        private void PdfViewerControl_ShapeAnnotationDeselected(object sender, ShapeAnnotationDeselectedEventArgs args)
        {   
            isAnnotationEditMode = false;
            AnnotationMode annotationMode = args.AnnotationType;
            selectedShapeAnnotation = null;
        }

        private void PdfViewerControl_ShapeAnnotationSelected(object sender, ShapeAnnotationSelectedEventArgs args)
        {
            selectedShapeAnnotation = sender as ShapeAnnotation;
            isAnnotationEditMode = true;

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

            canSetValueToSource = true;
        }

        private void PdfViewerControl_DocumentLoaded(object sender, EventArgs args)
        {
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
            Stream stream = (typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath + "Assets." + currentDocument + ".pdf"));
            bookmarkLoadedDocument = new PdfLoadedDocument(stream);
            bookmarkToolbar.bookmarkLoadedDocument = bookmarkLoadedDocument;
			//When a new PDF is loaded populate the bookmark listview with the bookmarks of the PDF
            bookmarkToolbar.PopulateInitialBookmarkList();
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
                bookmarkToolbar.bookmarkLoadedDocument = bookmarkLoadedDocument;
                (BindingContext as PdfViewerViewModel).PdfDocumentStream = stream;
				//When a new PDF is loaded populate the bookmark listview with the bookmarks of the PDF
                if(bookmarkToolbar != null)
                bookmarkToolbar.PopulateInitialBookmarkList();
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
            currentDocument = (e.SelectedItem as Document).FileName;
            if (Device.RuntimePlatform == Device.Android)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void PdfViewerControl_InkDeselected(object sender, InkDeselectedEventArgs args)
        {
            isAnnotationEditMode = false;
            canSetValueToSource = false;
            if (selectedInkAnnotation != null)
            {
                opacitySlider.Value = selectedInkAnnotation.Settings.Opacity * 100;
            }
            selectedInkAnnotation = null;
        }

        private void PdfViewerControl_InkSelected(object sender, InkSelectedEventArgs args)
        {
            selectedInkAnnotation = sender as InkAnnotation;
            isAnnotationEditMode = true;
            (BindingContext as PdfViewerViewModel).InkDeleteColor = new Color(selectedInkAnnotation.Settings.Color.R, selectedInkAnnotation.Settings.Color.G, selectedInkAnnotation.Settings.Color.B);
            opacitySlider.Value = selectedInkAnnotation.Settings.Opacity * 100;
            canSetValueToSource = true;
        }

        private void PdfViewerControl_CanRedoInkModified(object sender, CanRedoInkModifiedEventArgs args)
        {
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
                if (selectedShapeAnnotation != null)
                    selectedShapeAnnotation.Settings.Thickness = (int)Math.Round(e.NewValue,0);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                    pdfViewerControl.AnnotationSettings.Ink.Thickness = (int)Math.Round(e.NewValue, 0);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                    pdfViewerControl.AnnotationSettings.Rectangle.Settings.Thickness = (int)Math.Round(e.NewValue, 0);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                    pdfViewerControl.AnnotationSettings.Circle.Settings.Thickness = (int)Math.Round(e.NewValue, 0);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                    pdfViewerControl.AnnotationSettings.Line.Settings.Thickness = (int)Math.Round(e.NewValue, 0);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                    pdfViewerControl.AnnotationSettings.Arrow.Settings.Thickness = (int)Math.Round(e.NewValue, 0);
            }
            sliderValue.Text = ((int)Math.Round(e.NewValue, 0)).ToString();
            canSetValueToSource = true;
        }

        private void PageNumberEntry_Completed(object sender, EventArgs e)
        {
            int pageNumber = 0;
            int.TryParse((sender as CustomEntry).Text, out pageNumber);

            if (pageNumber > pdfViewerControl.PageCount || pageNumber < 0)
            {
                DependencyService.Get<IAlertView>().Show("Please enter a valid page number.");
                pageNumberEntry.Text = pdfViewerControl.PageNumber.ToString();
            }
            else if(pageNumber != 0)
                pdfViewerControl.GoToPage(pageNumber);
        }

        private void PdfViewerControl_CanRedoModified(object sender, CanRedoModifiedEventArgs args)
        {
            if (args.CanRedo)
                redoButton.TextColor = Color.FromHex("#0076FF");
            else
                redoButton.TextColor = Color.DarkGray;
        }

        private void PdfViewerControl_CanUndoModified(object sender, CanUndoModifiedEventArgs args)
        {
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
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.SelectionMode = SelectionMode.None;
        }
        private void RectangleBackButton_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.SelectionMode = SelectionMode.None;
        }
        private void CircleBackButton_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.SelectionMode = SelectionMode.None;
        }
      
        private void LineBackButton_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.SelectionMode = SelectionMode.None;
        }
        private void ArrowBackButton_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.SelectionMode = SelectionMode.None;
        }


        private void EditTextBackButton_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.SelectionMode = SelectionMode.None;
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (selectedAnnotation != null)
            {
                pdfViewerControl.RemoveAnnotation(selectedAnnotation);
                selectedAnnotation = null;
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

        private void InkButton_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.Ink;
        }

        private void EditText_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.FreeText;
        }

        private void Shape_Clicked(object sender, EventArgs e)
        {
            
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
        }

        void PdfViewerControl_TextMatchFound(object sender, TextMatchFoundEventArgs args)
        {
            searchNextButton.IsVisible = true;
            searchPreviousButton.IsVisible = true;
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
        private void PdfViewerControl_UnhandledCondition(object sender, UnhandledConditionEventArgs args)
        {
            DependencyService.Get<IAlertView>().Show(args.Description);
        }

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
            textSearchEntry.Focus();
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
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

        private void OpacityButton_Clicked(object sender, EventArgs e)
        {
            if (selectedInkAnnotation != null)
                opacitySlider.Value = selectedInkAnnotation.Settings.Opacity * 100;
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
        private void AnnotationColorButton_Clicked(object sender, EventArgs e)
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Ink.Color;
            if (pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor;
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor;
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor;
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor;
        }

        private void ShapeAnnotationColorButton_Clicked(object sender, EventArgs e)
        {
            if (selectedInkAnnotation != null)
                (BindingContext as PdfViewerViewModel).OpacityButtonColor = selectedInkAnnotation.Settings.Color;
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

        private void EditTextDeleteButton_Clicked(object sender, EventArgs e)
        {
            if (selectedFreeTextAnnotation != null)
            {
                pdfViewerControl.RemoveAnnotation(selectedFreeTextAnnotation);
                selectedFreeTextAnnotation = null;
                isAnnotationEditMode = false;
            }
        }

        private void EditTextButton_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.EditFreeTextAnnotation();
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
                            if (selectedFreeTextAnnotation != null)
                                selectedFreeTextAnnotation.Settings.TextColor = Color.White;
                            if (selectedShapeAnnotation != null)
                                selectedShapeAnnotation.Settings.StrokeColor = Color.White;
                        }
                    }
                    break;
            }
        }
		//Add the bookmark toolbar when the bookmark button is clicked
        private void bookmarkButton_Clicked(object sender, EventArgs e)
        {
            bookmarkToolbar.isBookmarkPaneVisible = true;
            mainGrid.Children.Add(bookmarkToolbar);
        }
    }
}


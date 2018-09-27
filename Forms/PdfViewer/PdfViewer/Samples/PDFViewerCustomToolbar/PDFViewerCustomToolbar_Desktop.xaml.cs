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
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using SampleBrowser.Core;
using System.IO;
using Syncfusion.SfRangeSlider.XForms;
using Syncfusion.Pdf.Parsing;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfPdfViewer
{
    [Preserve(AllMembers = true)]
    public partial class PDFViewerCustomToolbar_Desktop : SampleView
    {
        bool m_isPageInitiated = false;
        bool isAnnotationEditMode = false;
        bool canSetValueToSource = true;
        TextMarkupAnnotation selectedAnnotation;
        InkAnnotation selectedInkAnnotation;
        ShapeAnnotation selectedShapeAnnotation;
        FreeTextAnnotation selectedFreeTextAnnotation;
        internal Syncfusion.SfPdfViewer.XForms.SfPdfViewer pdfViewer;
        internal StackLayout basePane;
        BookMarkPane bookMarkPane;
        internal PdfLoadedDocument bookmarkLoadedDocument;
        string currentDocument = "F# Succinctly";
        bool isDocumentLoaded = false;
        internal IList<CustomBookmark> ListViewItemsSource = new ObservableCollection<CustomBookmark>();
        public PDFViewerCustomToolbar_Desktop()
        {
            InitializeComponent();
            pdfViewer = pdfViewerControl;
            if (Application.Current.MainPage != null)
            {
                toolbar.WidthRequest = Application.Current.MainPage.Width;
                searchBar.WidthRequest = Application.Current.MainPage.Width;
            }
            textSearchEntry.TextChanged += TextSearchEntry_TextChanged;
            pdfViewerControl.Toolbar.Enabled = false;
            pdfViewerControl.UnhandledConditionOccurred += PdfViewerControl_UnhandledCondition;
            pdfViewerControl.TextMatchFound += PdfViewerControl_TextMatchFound;
            pdfViewerControl.CanUndoModified += PdfViewerControl_CanUndoModified;
            pdfViewerControl.CanRedoModified += PdfViewerControl_CanRedoModified;
            pdfViewerControl.CanUndoInkModified += PdfViewerControl_CanUndoInkModified;
            pdfViewerControl.CanRedoInkModified += PdfViewerControl_CanRedoInkModified;
            pdfViewerControl.SearchCompleted += PdfViewerControl_SearchCompleted;
            pdfViewerControl.DocumentLoaded += PdfViewerControl_DocumentLoaded;
            pdfViewerControl.ShapeAnnotationSelected += PdfViewerControl_ShapeAnnotationSelected;
            pdfViewerControl.FreeTextAnnotationSelected += PdfViewerControl_FreeTextAnnotationSelected;
            pdfViewerControl.FreeTextAnnotationDeselected += PdfViewerControl_FreeTextAnnotationDeselected;
            pdfViewerControl.ShapeAnnotationDeselected += PdfViewerControl_ShapeAnnotationDeselected;
            pdfViewerControl.FreeTextPopupAppearing += PdfViewerControl_FreeTextPopupAppearing;
            pdfViewerControl.FreeTextPopupDisappeared += PdfViewerControl_FreeTextPopupDisappeared;
            (BindingContext as PdfViewerViewModel).HighlightColor = pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color;
            (BindingContext as PdfViewerViewModel).UnderlineColor = pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color;
            (BindingContext as PdfViewerViewModel).StrikeThroughColor = pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color;
            (BindingContext as PdfViewerViewModel).EditTextColor = pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            (BindingContext as PdfViewerViewModel).RectangleStrokeColor = pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor;
            (BindingContext as PdfViewerViewModel).LineStrokeColor = pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor;
            (BindingContext as PdfViewerViewModel).CircleStrokeColor = pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor;
            (BindingContext as PdfViewerViewModel).ArrowStrokeColor = pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor;
            (BindingContext as PdfViewerViewModel).InkColor = pdfViewerControl.AnnotationSettings.Ink.Color;
            (BindingContext as PdfViewerViewModel).OpacityButtonColor = pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor;
            opacitySlider.Value = pdfViewerControl.AnnotationSettings.Ink.Opacity*100;
            opacitySlider.ValueChanged += OpacitySlider_ValueChanged;
            thicknessSlider.Value = pdfViewerControl.AnnotationSettings.Ink.Thickness;
            thicknessSlider.ValueChanged += ThicknessSlider_ValueChanged;

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
            // fontSizeSlider.ValueChanging += FontSizeSlider_ValueChanging;
            fontSizeSlider.ValueChanging += FontSizeSlider_ValueChanged;
            fontSizeSlider.Value = pdfViewerControl.AnnotationSettings.FreeText.TextSize;
            fontSizeSliderValue.Text = pdfViewerControl.AnnotationSettings.FreeText.TextSize.ToString();

            m_isPageInitiated = true;
            BookMarkButton.Text = "\ue703";
            BookMarkButton.FontFamily = FontMappingHelper.BookmarkFont;
            basePane = bookpane;
            bookMarkPane = new BookMarkPane(this);

        }
        private  void PdfViewerControl_DocumentLoaded(object sender, EventArgs args)

        {
            string filePath = string.Empty;
#if COMMONSB
            filePath = "SampleBrowser.Samples.PdfViewer.Samples.";

#else
            filePath = "SampleBrowser.SfPdfViewer.";

#endif
            Stream stream = (typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath+"Assets." + currentDocument + ".pdf"));
            bookmarkLoadedDocument = new PdfLoadedDocument(stream);
            bookMarkPane.bookmarkLoadedDocument = bookmarkLoadedDocument;
            if (isDocumentLoaded == false)
                bookMarkPane.PopulateInitialBookmarkList();
            isDocumentLoaded = true;


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
            if ((BindingContext as PdfViewerViewModel).IsBookMarkVisible)
                (BindingContext as PdfViewerViewModel).IsBookMarkVisible = false;
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
        private void EditTextButton_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.EditFreeTextAnnotation();
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            currentDocument = (e.SelectedItem as Document).FileName;
            isDocumentLoaded = false;

        }
        private void FontSizeSlider_ValueChanged(object sender, ValueEventArgs e)
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

        private void FontSizeSlider_ValueChanging(object sender, Syncfusion.SfRangeSlider.XForms.ValueEventArgs e)
        {
            if (canSetValueToSource)
            {
                if (selectedFreeTextAnnotation != null)
                    selectedFreeTextAnnotation.Settings.TextSize = (int)(e.Value);
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

            if (selectedShapeAnnotation != null)
            {
                if (selectedShapeAnnotation.Settings.Thickness <= 10)
                    thicknessSlider.Value = selectedShapeAnnotation.Settings.Thickness;
                opacitySlider.Value = selectedShapeAnnotation.Settings.Opacity * 100;
            }
            selectedShapeAnnotation = null;
        }

        private void BookMarkClicked(object sender, EventArgs e)
        {
            if ((BindingContext as PdfViewerViewModel).IsBookMarkVisible == false)
            {

                (BindingContext as PdfViewerViewModel).IsBookMarkVisible = true;

                BookmarkSeparator.BackgroundColor = Color.FromHex("#E0E0E0");



            }
            else
            {

                (BindingContext as PdfViewerViewModel).IsBookMarkVisible = false;


            }



        }
        private void PdfViewerControl_FreeTextAnnotationDeselected(object sender, FreeTextAnnotationDeselectedEventArgs args)
        {
            selectedFreeTextAnnotation = null;
            isAnnotationEditMode = false;
            canSetValueToSource = false;
            fontSizeSlider.Value = pdfViewerControl.AnnotationSettings.FreeText.TextSize;
        }

        private void PdfViewerControl_InkDeselected(object sender, InkDeselectedEventArgs args)
        {
            isAnnotationEditMode = false;
            canSetValueToSource = false;
            if (selectedInkAnnotation != null && selectedInkAnnotation.Settings.Thickness <= 10)
                thicknessSlider.Value = selectedInkAnnotation.Settings.Thickness;
            opacitySlider.Value = pdfViewerControl.AnnotationSettings.Ink.Opacity*100;
            selectedInkAnnotation = null;
        }

        private void PdfViewerControl_InkSelected(object sender, InkSelectedEventArgs args)
        {
            selectedInkAnnotation = sender as InkAnnotation;
            isAnnotationEditMode = true;
            (BindingContext as PdfViewerViewModel).InkDeleteColor = new Color(selectedInkAnnotation.Settings.Color.R, selectedInkAnnotation.Settings.Color.G, selectedInkAnnotation.Settings.Color.B);
            if (selectedInkAnnotation != null && selectedInkAnnotation.Settings.Thickness <= 10)
                thicknessSlider.Value = selectedInkAnnotation.Settings.Thickness;
            opacitySlider.Value = selectedInkAnnotation.Settings.Opacity*100;
            canSetValueToSource = true;
        }

        private void ThicknessButton_Clicked(object sender, EventArgs e)
        {
            if (selectedInkAnnotation != null && selectedInkAnnotation.Settings.Thickness <= 10)
                thicknessSlider.Value = selectedInkAnnotation.Settings.Thickness;
            else if (selectedShapeAnnotation != null && selectedShapeAnnotation.Settings.Thickness <= 10)
                thicknessSlider.Value = selectedShapeAnnotation.Settings.Thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                thicknessSlider.Value = pdfViewerControl.AnnotationSettings.Ink.Thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                thicknessSlider.Value = pdfViewerControl.AnnotationSettings.Rectangle.Settings.Thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                thicknessSlider.Value = pdfViewerControl.AnnotationSettings.Circle.Settings.Thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                thicknessSlider.Value = pdfViewerControl.AnnotationSettings.Line.Settings.Thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                thicknessSlider.Value = pdfViewerControl.AnnotationSettings.Arrow.Settings.Thickness;
        }

        private void ThicknessSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
              if (canSetValueToSource)
            {
                if (selectedInkAnnotation != null)
                    selectedInkAnnotation.Settings.Thickness = (float)e.NewValue;
                else if (selectedShapeAnnotation != null)
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

        private void OpacitySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (canSetValueToSource)
            {
                if (selectedInkAnnotation != null)
                    selectedInkAnnotation.Settings.Opacity = (float)(e.NewValue / 100);
                else if (selectedShapeAnnotation != null)
                    selectedShapeAnnotation.Settings.Opacity = (float)(e.NewValue / 100);
                else if(pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                    pdfViewerControl.AnnotationSettings.Ink.Opacity = (float)(e.NewValue / 100);
                 else if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                    pdfViewerControl.AnnotationSettings.Rectangle.Settings.Opacity = (float)(e.NewValue / 100);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                    pdfViewerControl.AnnotationSettings.Circle.Settings.Opacity = (float)(e.NewValue / 100);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                    pdfViewerControl.AnnotationSettings.Line.Settings.Opacity = (float)(e.NewValue / 100);
                else if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                    pdfViewerControl.AnnotationSettings.Arrow.Settings.Opacity = (float)(e.NewValue / 100);
            }
            opacityValue.Text = ((int)e.NewValue).ToString()+"%";
            canSetValueToSource = true;
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
            pdfViewerControl.AnnotationMode = AnnotationMode.Ink;
        }

        private void UndoInk_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.UndoInk();
        }

        private void RedoInk_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.RedoInk();
        }

        private void EndSession_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.EndInkSession(true);
        }

        private void PdfViewerControl_CanRedoInkModified(object sender, CanRedoInkModifiedEventArgs args)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (args.CanRedoInk)
                {
                    inkRedoBtn.TextColor = Color.FromHex("#0076FF");
                    inkRedoBtn.InputTransparent = false;
                }
                else
                {
                    inkRedoBtn.TextColor = Color.DarkGray;
                    inkRedoBtn.InputTransparent = true;
                }
            });
        }

        private void PdfViewerControl_CanUndoInkModified(object sender, CanUndoInkModifiedEventArgs args)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (args.CanUndoInk)
                {

                    inkUndoBtn.TextColor = Color.FromHex("#0076FF");
                    inkUndoBtn.InputTransparent = false;
                }
                else
                {
                    inkUndoBtn.TextColor = Color.DarkGray;
                    inkUndoBtn.InputTransparent = true;
                }
            });
        }

        private void PdfViewerControl_CanRedoModified(object sender, CanRedoModifiedEventArgs args)
        {
            if (args.CanRedo)
            {
                redoButton.TextColor = Color.FromHex("#0076FF");
                redoButton.InputTransparent = false;
            }
            else
            {
                redoButton.TextColor = Color.FromHex("#808080");
                redoButton.InputTransparent = true;
            }
        }

        private void PdfViewerControl_CanUndoModified(object sender, CanUndoModifiedEventArgs args)
        {
            if (args.CanUndo)
            {
                undoButton.TextColor = Color.FromHex("#0076FF");
                undoButton.InputTransparent = false;
            }
            else
            {
                undoButton.TextColor = Color.FromHex("#808080");
                undoButton.InputTransparent = true;
            }
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
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (selectedAnnotation != null)
            {
                pdfViewerControl.RemoveAnnotation(selectedAnnotation);
                selectedAnnotation = null;
                isAnnotationEditMode = false;
            }
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            string filePath = DependencyService.Get<ISave>().Save(pdfViewerControl.SaveDocument() as MemoryStream);
            string message = "The PDF has been saved to " + filePath;
            DependencyService.Get<IAlertView>().Show(message);
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
                            if(selectedFreeTextAnnotation!=null)
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
            }
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            textSearchEntry.Focus();
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.SelectionMode = SelectionMode.None;
        }
        private void Shape_Clicked(object sender, EventArgs e)
        {
            
        }

        private void EditText_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.FreeText;
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
        private void EditTextBackButton_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.SelectionMode = SelectionMode.None;
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


            if (selectedShapeAnnotation != null && selectedShapeAnnotation.Settings.Thickness <= 10)
                thicknessSlider.Value = selectedShapeAnnotation.Settings.Thickness;
            opacitySlider.Value = selectedShapeAnnotation.Settings.Opacity * 100;
            canSetValueToSource = true;
        }
        private void PdfViewerControl_FreeTextAnnotationSelected(object sender, FreeTextAnnotationSelectedEventArgs args)
        {
            selectedFreeTextAnnotation = sender as FreeTextAnnotation;
            isAnnotationEditMode = true;
            (BindingContext as PdfViewerViewModel).EditTextDeleteColor = new Color(selectedFreeTextAnnotation.Settings.TextColor.R, selectedFreeTextAnnotation.Settings.TextColor.G, selectedFreeTextAnnotation.Settings.TextColor.B);
            fontSizeSlider.Value = selectedFreeTextAnnotation.Settings.TextSize;
            (BindingContext as PdfViewerViewModel).IsEditFreeTextAnnotationBarVisible = true;
            (BindingContext as PdfViewerViewModel).IsMainAnnotationBarVisible =false;
            fontSizeSlider.Value = selectedFreeTextAnnotation.Settings.TextSize;
            canSetValueToSource = true;
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


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Application.Current.MainPage != null && Application.Current.MainPage.Width > 0 && m_isPageInitiated)
            {
                toolbar.WidthRequest = Application.Current.MainPage.Width;
                searchBar.WidthRequest = Application.Current.MainPage.Width;
            }
        }
    }

}
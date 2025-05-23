#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.Collections.Generic;
using Syncfusion.SfPdfViewer.XForms;

namespace SampleBrowser.SfPdfViewer
{
    [Preserve(AllMembers = true)]
    internal class PdfViewerViewModel : INotifyPropertyChanged
    {
        private Stream m_pdfDocumentStream;
        private string m_currentViewModeIconText = FontMappingHelper.ContinuousPage;
        private PageViewMode m_currentPageViewMode = PageViewMode.Continuous;
        private bool m_isToolbarVisible = true;
        private bool m_isPickerVisible = false;
        private bool m_moreOptionsToolBarVisible = false;
        private bool m_isSearchbarVisible = false;
        private bool m_isBottomToolbarVisible = true;
        private bool m_isSecondaryAnnotationBarVisible = false;
        private bool m_isHightlightBarVisible = false;
        private bool m_isUnderlineBarVisible = false;
        private bool m_isStrikeThroughBarVisible = false;
        private bool m_isSquigglyBarVisible = false;
        private bool m_isRectangleAnnotationBarVisible = false;
        private bool m_isCircleAnnotationBarVisible = false;
        private bool m_isLineAnnotationBarVisible = false;
        private bool m_isArrowAnnotationBarVisible = false;
        private bool m_isPolygonAnnotationBarVisible = false;
        private bool m_isCloudAnnotationBarVisible = false;
        private bool m_isPolylineAnnotationBarVisible = false;
        private bool m_isEditAnnotationBarVisible = false;
        private bool m_isEditStampAnnotationBarVisible = false;
        private bool m_isEditFreeTextAnnotationBarVisible = false;
        private bool m_isShapeAnnotationBarVisible = false;
        private bool m_isColorBarVisible = false;
        private bool m_isMainAnnotationBarVisible = false;
        private bool m_isInkBarVisible = false;
        private bool m_isRectangleBarVisible = false;
        private bool m_isCircleBarVisible = false;
        private bool m_isLineBarVisible = false;
        private bool m_isArrowBarVisible = false;
        private bool m_isPolygonBarVisible = false;
        private bool m_isCloudBarVisible = false;
        private bool m_isPolylineBarVisible = false;
        private bool m_isThicknessBarVisible = false;
        private bool m_isFontSizeSliderBarVisible = false;
        private bool m_isOpacityBarVisible = false;
        private bool m_isInkColorBarVisible = false;
        private bool m_isShapeColorBarVisible = false;
        private bool m_isEditTextBarVisible = false;
        private bool m_isEditInkBarVisible = false;
        private bool m_isEditRectangleAnnotationBarVisible = false;
        private bool m_isEditLineAnnotationBarVisible = false;
        private bool m_isEditCircleAnnotationBarVisible = false;
        private bool m_isEditTextAnnotationBarVisible = false;
        private bool m_isEditArrowAnnotationBarVisible = false;
        private bool m_isEditPolygonAnnotationBarVisible = false;
        private bool m_isEditCloudAnnotationBarVisible = false;
        private bool m_isEditPolylineAnnotationBarVisible = false;
        private bool m_isPopupBarVisible = false;
        private bool m_isEditPopupAnnotationBarVisible = false;
        private bool m_isPopupIconSelectorBarVisible = false;
        private bool m_isAnnotationGridVisible = false;
        private int m_annotationRowHeight = 50, m_colorRowHeight = 0, m_opacityRowHeight = 0;
        private int m_annotationGridHeightRequest = 0;
        private Color m_toggleColor = Color.LightGray;
        private Color m_highlightColor;
        private Color m_underlineColor;
        private Color m_strikeThroughColor;
        private Color m_squigglyColor;
        private Color m_deleteButtonColor;
        private Color m_inkdeleteColor;
        private Color m_rectangleDeleteColor;
        private Color m_circleDeleteColor;
        private Color m_editTextdeleteColor;
        private Color m_lineDeleteColor;
        private Color m_arrowDeleteColor;
        private Color m_polygonDeleteColor;
        private Color m_cloudDeleteColor;
        private Color m_polylineDeleteColor;
        private Color m_inkColor;
        private Color m_editTextColor;
        private Color m_rectangleStrokeColor;
        private Color m_circleStrokeColor;
        private Color m_lineStrokeColor;
        private Color m_arrowStrokeColor;
        private Color m_polygonStrokeColor;
        private Color m_cloudStrokeColor;
        private Color m_polylineStrokeColor;
        private Color m_opacityButtonColor;
        private bool m_isBookMarkVisible;
        private bool m_isContextMenuVisible;
        private Color m_popupDeleteColor;
        private Color m_popupColor;
        private PopupIcon m_popupIcon;
        private PopupIcon m_editPopupIcon;
        private bool m_isInkEraserBarVisible;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ToggleViewModeCommand { get; set; }
        public ICommand SearchAndToolbarToggleCommand { get; set; }
        public ICommand AnnotationCommand { get; set; }
        public ICommand FileOpenCommand { get; set; }
        public ICommand MoreOptionsCommand { get; set; }
        public ICommand HighlightCommand { get; set; }
        public ICommand UnderlineCommand { get; set; }
        public ICommand StrikeThroughCommand { get; set; }
        public ICommand SquigglyCommand { get; set; }
        public ICommand RectangleCommand { get; set; }
        public ICommand CircleCommand { get; set; }
        public ICommand LineCommand { get; set; }
        public ICommand ArrowCommand { get; set; }
        public ICommand PolygonCommand { get; set; }
        public ICommand CloudCommand { get; set; }
        public ICommand PolylineCommand { get; set; }
        public ICommand ColorButtonClickedCommand { get; set; }
        public ICommand ColorCommand { get; set; }
        public ICommand AnnotationBackCommand { get; set; }
        public ICommand TextMarkupSelectedCommand { get; set; }
        public ICommand TextMarkupDeselectedCommand { get; set; }
        public ICommand StampAnnotationSelectedCommand { get; set; }
        public ICommand StampAnnotationDeselectedCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DocumentLoadedCommand { get; set; }
        public ICommand TextMarkupCommand { get; set; }
        public ICommand InkCommand { get; set; }
        public ICommand EditTextCommand { get; set; }
        public ICommand ShapeCommand { get; set; }
        public ICommand TextMarkupBackCommand { get; set; }
        public ICommand InkBackButtonCommand { get; set; }

        public ICommand RectangleBackButtonCommand { get; set; }
        public ICommand CircleBackButtonCommand { get; set; }
        public ICommand LineBackButtonCommand { get; set; }
        public ICommand ArrowBackButtonCommand { get; set; }
        public ICommand PolygonBackButtonCommand { get; set; }
        public ICommand CloudBackButtonCommand { get; set; }
        public ICommand PolylineBackButtonCommand { get; set; }

        public ICommand EditTextBackButtonCommand { get; set; }
        public ICommand ShapeBackButtonCommand { get; set; }
        public ICommand InkThicknessCommand { get; set; }
        public ICommand RectangleThicknessCommand { get; set; }
        public ICommand CircleThicknessCommand { get; set; }
        public ICommand LineThicknessCommand { get; set; }
        public ICommand ArrowThicknessCommand { get; set; }
        public ICommand PolygonThicknessCommand { get; set; }
        public ICommand CloudThicknessCommand { get; set; }
        public ICommand PolylineThicknessCommand { get; set; }
        public ICommand EditTextFontSizeCommand { get; set; }
        public ICommand InkOpacityCommand { get; set; }
        public ICommand InkSelectedCommand { get; set; }
        public ICommand InkDeselectedCommand { get; set; }

        public ICommand ShapeSelectedCommand { get; set; }
        public ICommand ShapeDeselectedCommand { get; set; }
        public ICommand FreeTextSelectedCommand { get; set; }
        public ICommand FreeTextDeselectedCommand { get; set; }
        public ICommand InkDeleteCommand { get; set; }
        public ICommand ShapeDeleteCommand { get; set; }
        public ICommand EditTextDeleteCommand { get; set; }
        
        public ICommand PopupCommand { get; set; }
        public ICommand PopupBackButtonCommand { get; set; }
        public ICommand PopupDeleteCommand { get; set; }
        public ICommand PopupIconCommand { get; set; }
        public ICommand SelectPopupIconCommand { get; set; }
        public ICommand PopupAnnotationSelectedCommand { get; set; }
        public ICommand PopupAnnotationDeselectedCommand { get; set; }

        public ICommand OpacityButtonCommand { get; set; }

        public ICommand TabletBookmarkCommand { get; set; }

        public ICommand InkEraserCommand { get; set; }
        public ICommand InkEraserBackButtonCommand { get; set; }

        public Stream PdfDocumentStream
        {
            get
            {
                return m_pdfDocumentStream;
            }
            set
            {
                m_pdfDocumentStream = value;
                NotifyPropertyChanged("PdfDocumentStream");

            }
        }
        public bool IsBookMarkVisible
        {
            get { return m_isBookMarkVisible; }
            set
            {
                m_isBookMarkVisible = value;
                NotifyPropertyChanged("IsBookMarkVisible");
            }
        }

        public bool IsContextMenuVisible
        {
            get { return m_isContextMenuVisible; }
            set
            {
                m_isContextMenuVisible = value;
                NotifyPropertyChanged("IsContextMenuVisible");
            }
        }

        public int AnnotationGridHeightRequest
        {
            get { return m_annotationGridHeightRequest; }
            set
            {
                m_annotationGridHeightRequest = value;
                NotifyPropertyChanged("AnnotationGridHeightRequest");
            }
        }
        public Color DeleteButtonColor
        {
            get { return m_deleteButtonColor; }
            set
            {
                m_deleteButtonColor = value;
                NotifyPropertyChanged("DeleteButtonColor");
            }
        }
        public bool IsAnnotationGridVisible
        {
            get
            {
                return m_isAnnotationGridVisible;
            }
            set
            {
                m_isAnnotationGridVisible = value;
                NotifyPropertyChanged("IsAnnotationGridVisible");
            }
        }

        public string CurrentViewModeIconText
        {
            get
            {
                return m_currentViewModeIconText;
            }
            set
            {
                m_currentViewModeIconText = value;
                NotifyPropertyChanged("CurrentViewModeIconText");
            }
        }

        public PageViewMode CurrentPageViewMode
        {
            get
            {
                return m_currentPageViewMode;
            }
            set
            {
                m_currentPageViewMode = value;
                CurrentViewModeIconText = value == PageViewMode.Continuous?
                                      FontMappingHelper.ContinuousPage :
                                      FontMappingHelper.PageByPage;
                NotifyPropertyChanged("CurrentPageViewMode");
            }
        }

        public bool IsEditFreeTextAnnotationBarVisible
        {
            get { return m_isEditFreeTextAnnotationBarVisible; }
            set
            {
                m_isEditFreeTextAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditFreeTextAnnotationBarVisible");
            }
        }

        public bool IsEditPopupAnnotationBarVisible
        {
            get { return m_isEditPopupAnnotationBarVisible; }
            set
            {
                m_isEditPopupAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditPopupAnnotationBarVisible");
            }
        }

        public Color OpacityButtonColor
        {
            get { return m_opacityButtonColor; }
            set
            {
                m_opacityButtonColor = value;
                NotifyPropertyChanged("OpacityButtonColor");
            }
        }
        public Color ToggleColor
        {
            get { return m_toggleColor; }
            set
            {
                m_toggleColor = value;
                NotifyPropertyChanged("ToggleColor");

            }
        }

        public bool IsColorBarVisible
        {
            get
            {
                return m_isColorBarVisible;
            }
            set
            {
                m_isColorBarVisible = value;
                NotifyPropertyChanged("IsColorBarVisible");
            }
        }

        public bool IsThicknessBarVisible
        {
            get
            {
                return m_isThicknessBarVisible;
            }
            set
            {
                m_isThicknessBarVisible = value;
                NotifyPropertyChanged("IsThicknessBarVisible");
            }
        }

        public bool IsFontSizeSliderBarVisible
        {
            get
            {
                return m_isFontSizeSliderBarVisible;
            }
            set
            {
                m_isFontSizeSliderBarVisible = value;
                NotifyPropertyChanged("IsFontSizeSliderBarVisible");
            }
        }

        

        public bool IsInkColorBarVisible
        {
            get { return m_isInkColorBarVisible; }
            set
            {
                m_isInkColorBarVisible = value;
                NotifyPropertyChanged("IsInkColorBarVisible");
            }
        }
        public bool IsShapeColorBarVisible
        {
            get { return m_isShapeColorBarVisible; }
            set
            {
                m_isShapeColorBarVisible = value;
                NotifyPropertyChanged("IsShapeColorBarVisible");
            }
        }

        public bool IsEditTextColorBarVisible
        {
            get { return m_isEditTextBarVisible; }
            set
            {
                m_isEditTextBarVisible = value;
                NotifyPropertyChanged("IsEditTextColorBarVisible");
            }
        }

        public bool IsPopupBarVisible
        {
            get { return m_isPopupBarVisible; }
            set
            {
                m_isPopupBarVisible = value;
                NotifyPropertyChanged("IsPopupBarVisible");
            }
        }

        public bool IsPopupIconSelectorBarVisible
        {
            get { return m_isPopupIconSelectorBarVisible; }
            set
            {
                m_isPopupIconSelectorBarVisible = value;
                NotifyPropertyChanged("IsPopupIconSelectorBarVisible");
            }
        }

        public bool IsOpacityBarVisible
        {
            get
            {
                return m_isOpacityBarVisible;
            }
            set
            {
                m_isOpacityBarVisible = value;
                NotifyPropertyChanged("IsOpacityBarVisible");
            }
        }

        public bool IsMainAnnotationBarVisible
        {
            get
            {
                return m_isMainAnnotationBarVisible;
            }
            set
            {
                m_isMainAnnotationBarVisible = value;
                NotifyPropertyChanged("IsMainAnnotationBarVisible");
            }
        }

        public bool IsToolbarVisible
        {
            get { return m_isToolbarVisible; }
            set
            {
                if (m_isToolbarVisible == value)
                    return;
                m_isToolbarVisible = value;
                NotifyPropertyChanged("IsToolbarVisible");
            }
        }

        public bool IsEditAnnotationBarVisible
        {
            get { return m_isEditAnnotationBarVisible; }
            set
            {
                m_isEditAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditAnnotationBarVisible");
            }
        }

        public bool IsEditStampAnnotationBarVisible
        {
            get { return m_isEditStampAnnotationBarVisible; }
            set
            {
                m_isEditStampAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditStampAnnotationBarVisible");
            }
        }

        public bool IsShapeAnnotationBarVisible
        {
            get { return m_isShapeAnnotationBarVisible; }
            set
            {
                m_isShapeAnnotationBarVisible = value;
                NotifyPropertyChanged("IsShapeAnnotationBarVisible");
            }
        }

        public int AnnotationRowHeight
        {
            get { return m_annotationRowHeight; }
            set
            {
                m_annotationRowHeight = value;
                NotifyPropertyChanged("AnnotationRowHeight");
            }
        }

        public int OpacityRowHeight
        {
            get { return m_opacityRowHeight; }
            set
            {
                m_opacityRowHeight = value;
                NotifyPropertyChanged("OpacityRowHeight");
            }
        }

        public int ColorRowHeight
        {
            get { return m_colorRowHeight; }
            set
            {
                m_colorRowHeight = value;
                NotifyPropertyChanged("ColorRowHeight");
            }
        }

        public bool IsSecondaryAnnotationBarVisible
        {
            get { return m_isSecondaryAnnotationBarVisible; }
            set
            {
                if (m_isSecondaryAnnotationBarVisible == value) return;
                m_isSecondaryAnnotationBarVisible = value;
                NotifyPropertyChanged("IsSecondaryAnnotationBarVisible");
            }
        }

        public bool IsHighlightBarVisible
        {
            get { return m_isHightlightBarVisible; }
            set
            {
                if (m_isHightlightBarVisible == value) return;
                m_isHightlightBarVisible = value;
                NotifyPropertyChanged("IsHighlightBarVisible");
            }
        }

        public bool IsUnderlineBarVisible
        {
            get { return m_isUnderlineBarVisible; }
            set
            {
                if (m_isUnderlineBarVisible == value) return;
                m_isUnderlineBarVisible = value;
                NotifyPropertyChanged("IsUnderlineBarVisible");
            }
        }

        public Color InkDeleteColor
        {
            get { return m_inkdeleteColor; }
            set
            {
                m_inkdeleteColor = value;
                NotifyPropertyChanged("InkDeleteColor");
            }
        }

        public Color EditTextDeleteColor
        {
            get { return m_editTextdeleteColor; }
            set
            {
                m_editTextdeleteColor = value;
                NotifyPropertyChanged("EditTextDeleteColor");
            }
        }

        public Color PopupDeleteColor
        {
            get { return m_popupDeleteColor; }
            set
            {
                m_popupDeleteColor = value;
                NotifyPropertyChanged("PopupDeleteColor");
            }
        }
        public Color RectangleDeleteColor
        {
            get { return m_rectangleDeleteColor; }
            set
            {
                m_rectangleDeleteColor = value;
                NotifyPropertyChanged("RectangleDeleteColor");
            }
        }
        public Color CircleDeleteColor
        {
            get { return m_circleDeleteColor; }
            set
            {
                m_circleDeleteColor = value;
                NotifyPropertyChanged("CircleDeleteColor");
            }
        }
        public Color LineDeleteColor
        {
            get { return m_lineDeleteColor; }
            set
            {
                m_lineDeleteColor = value;
                NotifyPropertyChanged("LineDeleteColor");
            }
        }
        public Color ArrowDeleteColor
        {
            get { return m_arrowDeleteColor; }
            set
            {
                m_arrowDeleteColor = value;
                NotifyPropertyChanged("ArrowDeleteColor");
            }
        }

        public Color PolygonDeleteColor
        {
            get { return m_polygonDeleteColor; }
            set
            {
                m_polygonDeleteColor = value;
                NotifyPropertyChanged("PolygonDeleteColor");
            }
        }

        public Color CloudDeleteColor
        {
            get { return m_cloudDeleteColor; }
            set
            {
                m_cloudDeleteColor = value;
                NotifyPropertyChanged("CloudDeleteColor");
            }
        }

        public Color PolylineDeleteColor
        {
            get { return m_polylineDeleteColor; }
            set
            {
                m_polylineDeleteColor = value;
                NotifyPropertyChanged("PolylineDeleteColor");
            }
        }

        public bool IsStrikeThroughBarVisible
        {
            get { return m_isStrikeThroughBarVisible; }
            set
            {
                if (m_isStrikeThroughBarVisible == value) return;
                m_isStrikeThroughBarVisible = value;
                NotifyPropertyChanged("IsStrikeThroughBarVisible");
            }
        }

        public bool IsSquigglyBarVisible
        {
            get { return m_isSquigglyBarVisible; }
            set
            {
                if (m_isSquigglyBarVisible == value) return;
                m_isSquigglyBarVisible = value;
                NotifyPropertyChanged("IsSquigglyBarVisible");
            }
        }

        public bool IsRectangleAnnotationBarVisible
        {
            get { return m_isRectangleAnnotationBarVisible; }
            set
            {
                if (m_isRectangleAnnotationBarVisible == value) return;
                m_isRectangleAnnotationBarVisible = value;
                NotifyPropertyChanged("IsRectangleAnnotationBarVisible");
            }
        }

        public bool IsCircleAnnotationBarVisible
        {
            get { return m_isCircleAnnotationBarVisible; }
            set
            {
                if (m_isCircleAnnotationBarVisible == value) return;
                m_isCircleAnnotationBarVisible = value;
                NotifyPropertyChanged("IsCircleAnnotationBarVisible");
            }
        }

        public bool IsLineAnnotationBarVisible
        {
            get { return m_isLineAnnotationBarVisible; }
            set
            {
                if (m_isLineAnnotationBarVisible == value) return;
                m_isLineAnnotationBarVisible = value;
                NotifyPropertyChanged("IsLineAnnotationBarVisible");
            }
        }

        public bool IsArrowAnnotationBarVisible
        {
            get { return m_isArrowAnnotationBarVisible; }
            set
            {
                if (m_isArrowAnnotationBarVisible == value) return;
                m_isArrowAnnotationBarVisible = value;
                NotifyPropertyChanged("IsArrowAnnotationBarVisible");
            }
        }

        public bool IsPolygonAnnotationBarVisible
        {
            get { return m_isPolygonAnnotationBarVisible; }
            set
            {
                if (m_isPolygonAnnotationBarVisible == value)
                {
                    return;
                }
                m_isPolygonAnnotationBarVisible = value;
                NotifyPropertyChanged("IsPolygonAnnotationBarVisible");
            }
        }

        public bool IsCloudAnnotationBarVisible
        {
            get { return m_isCloudAnnotationBarVisible; }
            set
            {
                if (m_isCloudAnnotationBarVisible == value)
                {
                    return;
                }
                m_isCloudAnnotationBarVisible = value;
                NotifyPropertyChanged("IsCloudAnnotationBarVisible");
            }
        }

        public bool IsPolylineAnnotationBarVisible
        {
            get { return m_isPolylineAnnotationBarVisible; }
            set
            {
                if (m_isPolylineAnnotationBarVisible == value)
                {
                    return;
                }
                m_isPolylineAnnotationBarVisible = value;
                NotifyPropertyChanged("IsPolylineAnnotationBarVisible");
            }
        }

        public Color HighlightColor
        {
            get { return m_highlightColor; }
            set
            {
                if (m_highlightColor == value) return;
                m_highlightColor = value;
                NotifyPropertyChanged("HighlightColor");
            }
        }

        public Color InkColor
        {
            get { return m_inkColor; }
            set
            {
                m_inkColor = value;
                NotifyPropertyChanged("InkColor");
            }
        }

        public Color EditTextColor
        {
            get { return m_editTextColor; }
            set
            {
                m_editTextColor = value;
                NotifyPropertyChanged("EditTextColor");
            }
        }
        
        public Color PopupColor
        {
            get { return m_popupColor; }
            set
            {
                m_popupColor = value;
                NotifyPropertyChanged("PopupColor");
            }
        }

        public PopupIcon PopupIcon
        {
            get { return m_popupIcon; }
            set
            {
                m_popupIcon = value;
                NotifyPropertyChanged("PopupIcon");
            }
        }

        public PopupIcon EditPopupIcon
        {
            get { return m_editPopupIcon; }
            set
            {
                m_editPopupIcon = value;
                NotifyPropertyChanged("EditPopupIcon");
            }
        }

        public Color RectangleStrokeColor
        {
            get { return m_rectangleStrokeColor; }
            set
            {
                m_rectangleStrokeColor = value;
                NotifyPropertyChanged("RectangleStrokeColor");
            }
        }
        public Color CircleStrokeColor
        {
            get { return m_circleStrokeColor; }
            set
            {
                m_circleStrokeColor = value;
                NotifyPropertyChanged("CircleStrokeColor");
            }
        }

        public Color LineStrokeColor
        {
            get { return m_lineStrokeColor; }
            set
            {
                m_lineStrokeColor = value;
                NotifyPropertyChanged("LineStrokeColor");
            }
        }

        public Color ArrowStrokeColor
        {
            get { return m_arrowStrokeColor; }
            set
            {
                m_arrowStrokeColor = value;
                NotifyPropertyChanged("ArrowStrokeColor");
            }
        }

        public Color PolygonStrokeColor
        {
            get { return m_polygonStrokeColor; }
            set
            {
                m_polygonStrokeColor = value;
                NotifyPropertyChanged("PolygonStrokeColor");
            }
        }

        public Color CloudStrokeColor
        {
            get { return m_cloudStrokeColor; }
            set
            {
                m_cloudStrokeColor = value;
                NotifyPropertyChanged("CloudStrokeColor");
            }
        }

        public Color PolylineStrokeColor
        {
            get { return m_polylineStrokeColor; }
            set
            {
                m_polylineStrokeColor = value;
                NotifyPropertyChanged("PolylineStrokeColor");
            }
        }

        public Color UnderlineColor
        {
            get { return m_underlineColor; }
            set
            {
                if (m_underlineColor == value) return;
                m_underlineColor = value;
                NotifyPropertyChanged("UnderlineColor");
            }
        }

        public Color StrikeThroughColor
        {
            get { return m_strikeThroughColor; }
            set
            {
                if (m_strikeThroughColor == value) return;
                m_strikeThroughColor = value;
                NotifyPropertyChanged("StrikeThroughColor");
            }
        }
        
        public Color SquigglyColor
        {
            get { return m_squigglyColor; }
            set
            {
                if (m_squigglyColor == value) return;
                m_squigglyColor = value;
                NotifyPropertyChanged("SquigglyColor");
            }
        }

        public bool IsSearchbarVisible
        {
            get { return m_isSearchbarVisible; }
            set
            {
                if (m_isSearchbarVisible == value)
                    return;
                m_isSearchbarVisible = value;
                NotifyPropertyChanged("IsSearchbarVisible");
            }
        }

        public bool IsBottomToolbarVisible
        {
            get { return m_isBottomToolbarVisible; }
            set
            {
                if (m_isBottomToolbarVisible == value)
                    return;
                m_isBottomToolbarVisible = value;
                NotifyPropertyChanged("IsBottomToolbarVisible");
            }
        }
        
        public bool IsEditRectangleAnnotationBarVisible
        {
            get
            {
                return m_isEditRectangleAnnotationBarVisible;
            }
            set
            {
                m_isEditRectangleAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditRectangleAnnotationBarVisible");
            }
        }

        public bool IsEditLineAnnotationBarVisible
        {
            get
            {
                return m_isEditLineAnnotationBarVisible;
            }
            set
            {
                m_isEditLineAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditLineAnnotationBarVisible");
            }
        }

        public bool IsEditCircleAnnotationBarVisible
        {
            get
            {
                return m_isEditCircleAnnotationBarVisible;
            }
            set
            {
                m_isEditCircleAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditCircleAnnotationBarVisible");
            }
        }

        public bool IsEditTextAnnotationBarVisible
        {
            get
            {
                return m_isEditTextAnnotationBarVisible;
            }
            set
            {
                m_isEditTextAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditTextAnnotationBarVisible");
            }
        }

        

        public bool IsEditArrowAnnotationBarVisible
        {
            get
            {
                return m_isEditArrowAnnotationBarVisible;
            }
            set
            {
                m_isEditArrowAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditArrowAnnotationBarVisible");
            }
        }

        public bool IsEditCloudAnnotationBarVisible
        {
            get
            {
                return m_isEditCloudAnnotationBarVisible;
            }
            set
            {
                m_isEditCloudAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditCloudAnnotationBarVisible");
            }
        }

        public bool IsEditPolygonAnnotationBarVisible
        {
            get
            {
                return m_isEditPolygonAnnotationBarVisible;
            }
            set
            {
                m_isEditPolygonAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditPolygonAnnotationBarVisible");
            }
        }

        public bool IsEditPolylineAnnotationBarVisible
        {
            get
            {
                return m_isEditPolylineAnnotationBarVisible;
            }
            set
            {
                m_isEditPolylineAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditPolylineAnnotationBarVisible");
            }
        }

        public bool IsEditInkBarVisible
        {
            get { return m_isEditInkBarVisible; }
            set
            {
                m_isEditInkBarVisible = value;
                NotifyPropertyChanged("IsEditInkBarVisible");
            }
        }
        public bool IsPickerVisible
        {
            get { return m_isPickerVisible; }
            set
            {
                m_isPickerVisible = value;
                NotifyPropertyChanged("IsPickerVisible");
            }
        }

        public bool IsMoreOptionsToolBarVisible
        {
            get { return m_moreOptionsToolBarVisible; }
            set
            {
                m_moreOptionsToolBarVisible = value;
                NotifyPropertyChanged("IsMoreOptionsToolBarVisible");
            }
        }

        private string m_searchedText = string.Empty;
        public string SearchedText
        {
            get { return m_searchedText; }
            set
            {
                m_searchedText = value;
                if (m_searchedText != string.Empty)
                {
                    IsCancelVisible = true;
                }
                else
                {
                    IsCancelVisible = false;
                }
                NotifyPropertyChanged("SearchedText");
            }
        }

        private bool m_isCancelVisible = false;
        public bool IsCancelVisible
        {
            get { return m_isCancelVisible; }
            set
            {
                if (m_isCancelVisible == value)
                    return;
                m_isCancelVisible = value;
                NotifyPropertyChanged("IsCancelVisible");
            }
        }

        public bool IsInkBarVisible
        {
            get { return m_isInkBarVisible; }
            set
            {
                m_isInkBarVisible = value;
                NotifyPropertyChanged("IsInkBarVisible");
            }
        }

        public bool IsRectangleBarVisible
        {
            get { return m_isRectangleBarVisible; }
            set
            {
                m_isRectangleBarVisible = value;
                NotifyPropertyChanged("IsRectangleBarVisible");
            }
        }

        public bool IsCircleBarVisible
        {
            get { return m_isCircleBarVisible; }
            set
            {
                m_isCircleBarVisible = value;
                NotifyPropertyChanged("IsCircleBarVisible");
            }
        }

        public bool IsLineBarVisible
        {
            get { return m_isLineBarVisible; }
            set
            {
                m_isLineBarVisible = value;
                NotifyPropertyChanged("IsLineBarVisible");
            }
        }

        public bool IsArrowBarVisible
        {
            get { return m_isArrowBarVisible; }
            set
            {
                m_isArrowBarVisible = value;
                NotifyPropertyChanged("IsArrowBarVisible");
            }
        }

        public bool IsPolygonBarVisible
        {
            get { return m_isPolygonBarVisible; }
            set
            {
                m_isPolygonBarVisible = value;
                NotifyPropertyChanged("IsPolygonBarVisible");
            }
        }

        public bool IsCloudBarVisible
        {
            get { return m_isCloudBarVisible; }
            set
            {
                m_isCloudBarVisible = value;
                NotifyPropertyChanged("IsCloudBarVisible");
            }
        }

        public bool IsPolylineBarVisible
        {
            get { return m_isPolylineBarVisible; }
            set
            {
                m_isPolylineBarVisible = value;
                NotifyPropertyChanged("IsPolylineBarVisible");
            }
        }

        public bool IsInkEraserBarVisible
        {
            get { return m_isInkEraserBarVisible; }
            set
            {
                m_isInkEraserBarVisible = value;
                NotifyPropertyChanged("IsInkEraserBarVisible");
            }
        }

        private Document m_selectedItem;
        public Document SelectedItem
        {
            get
            {
                return m_selectedItem;
            }
            set
            {
                if (m_selectedItem == value)
                {
                    IsPickerVisible = false;
                    return;
                }
                m_selectedItem = value;
                string filePath = string.Empty;
#if COMMONSB
                filePath = "SampleBrowser.Samples.PdfViewer.Samples.";

#else
                filePath = "SampleBrowser.SfPdfViewer.";
           
#endif
                PdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath+"Assets." + m_selectedItem.FileName + ".pdf");
                NotifyPropertyChanged("SelectedItem");
                IsPickerVisible = false;
            }
        }


        private IList<Document> m_pdfDocumentCollection;
        public IList<Document> PdfDocumentCollection
        {
            get
            {
                if (m_pdfDocumentCollection == null)
                {
                    m_pdfDocumentCollection = new List<Document> { new Document("F# Succinctly"), new Document("GIS Succinctly"), new Document("HTTP Succinctly"), new Document("JavaScript Succinctly"), new Document("Encrypted Document") };
                }
                return m_pdfDocumentCollection;
            }
            set
            {
                if (m_pdfDocumentCollection == value)
                    return;
                m_pdfDocumentCollection = value;
                NotifyPropertyChanged("PdfDocumentCollection");
            }
        }
        public PdfViewerViewModel()
        {
            string filePath = string.Empty;
#if COMMONSB
            filePath = "SampleBrowser.Samples.PdfViewer.Samples.";

#else
            filePath = "SampleBrowser.SfPdfViewer.";
           
#endif
            m_pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath+"Assets.F# Succinctly.pdf");
            ToggleViewModeCommand = new Command<object>(OnViewModeToggled, CanExecute);
            SearchAndToolbarToggleCommand = new Command<object>(OnSearchAndToolbarToggleCommand, CanExecute);
            FileOpenCommand = new Command<object>(OnFileOpenedCommand, CanExecute);
            MoreOptionsCommand = new Command<object>(OnMoreOptionsCommand, CanExecute);
            AnnotationCommand = new Command<object>(OnAnnotationIconClickedCommand, CanExecute);
            HighlightCommand = new Command<object>(OnHighlightCommand, CanExecute);
            UnderlineCommand = new Command<object>(OnUnderlineCommand, CanExecute);
            StrikeThroughCommand = new Command<object>(OnStrikeThroughCommand, CanExecute);
            SquigglyCommand = new Command<object>(OnSquigglyCommand, CanExecute);
            RectangleCommand = new Command<object>(OnRectangleCommand, CanExecute);
            CircleCommand = new Command<object>(OnCircleCommand, CanExecute);
            LineCommand = new Command<object>(OnLineCommand, CanExecute);
            ArrowCommand = new Command<object>(OnArrowCommand, CanExecute);
            PolygonCommand = new Command<object>(OnPolygonCommand, CanExecute);
            CloudCommand = new Command<object>(OnCloudCommand, CanExecute);
            PolylineCommand = new Command<object>(OnPolylineCommand, CanExecute);
            AnnotationBackCommand = new Command<object>(OnAnnotationBackCommand, CanExecute);
            ColorButtonClickedCommand = new Command<object>(OnColorButtonClickedCommand, CanExecute);
            ColorCommand = new Command<object>(OnColorCommand, CanExecute);
            TextMarkupSelectedCommand = new Command<object>(OnTextMarkupSelectedCommand, CanExecute);
            TextMarkupDeselectedCommand = new Command<object>(OnTextMarkupDeselectedCommand, CanExecute);
            DeleteCommand = new Command<object>(OnDeleteCommand, CanExecute);
            DocumentLoadedCommand = new Command<object>(OnDocumentLoadedCommand, CanExecute);
            TextMarkupCommand = new Command<object>(OnTextMarkupCommand, CanExecute);
            InkCommand = new Command<object>(OnInkCommand, CanExecute);
            EditTextCommand = new Command<object>(OnEditTextCommand, CanExecute);
            ShapeCommand = new Command<object>(OnShapeCommand, CanExecute);
            InkBackButtonCommand = new Command<object>(OnInkBackButtonCommand, CanExecute);
            TextMarkupBackCommand = new Command<object>(OnTextMarkupBackCommand, CanExecute);
            RectangleBackButtonCommand = new Command<object>(OnRectangleBackButtonCommand, CanExecute);
            CircleBackButtonCommand = new Command<object>(OnCircleBackButtonCommand, CanExecute);
            LineBackButtonCommand = new Command<object>(OnLineBackButtonCommand, CanExecute);
            ArrowBackButtonCommand = new Command<object>(OnArrowBackButtonCommand, CanExecute);
            PolygonBackButtonCommand = new Command<object>(OnPolygonBackButtonCommand, CanExecute);
            CloudBackButtonCommand = new Command<object>(OnCloudBackButtonCommand, CanExecute);
            PolylineBackButtonCommand = new Command<object>(OnPolylineBackButtonCommand, CanExecute);
            EditTextBackButtonCommand = new Command<object>(OnEditTextBackButtonCommand, CanExecute);
            ShapeBackButtonCommand = new Command<object>(OnShapeBackButtonCommand, CanExecute);
            InkThicknessCommand = new Command<object>(OnInkThicknessCommand, CanExecute);
            RectangleThicknessCommand = new Command<object>(OnRectangleThicknessCommand, CanExecute);
            CircleThicknessCommand = new Command<object>(OnCircleThicknessCommand, CanExecute);
            LineThicknessCommand = new Command<object>(OnLineThicknessCommand, CanExecute);
            ArrowThicknessCommand = new Command<object>(OnArrowThicknessCommand, CanExecute);
            PolygonThicknessCommand = new Command<object>(OnPolygonThicknessCommand, CanExecute);
            CloudThicknessCommand = new Command<object>(OnCloudThicknessCommand, CanExecute);
            PolylineThicknessCommand = new Command<object>(OnPolylineThicknessCommand, CanExecute);
            EditTextFontSizeCommand = new Command<object>(OnEditTextFontSizeCommand, CanExecute);
            OpacityButtonCommand = new Command<object>(OnOpacityButtonColorCommand, CanExecute);
            InkOpacityCommand = new Command<object>(OnInkOpacityCommand, CanExecute);
            InkSelectedCommand = new Command<object>(OnInkSelectedCommand, CanExecute);
            InkDeselectedCommand = new Command<object>(OnInkDeselectedCommand, CanExecute);
            ShapeSelectedCommand = new Command<object[]>(OnShapeSelectedCommand, CanExecute);
            ShapeDeselectedCommand = new Command<object>(OnShapeDeselectedCommand, CanExecute);

            FreeTextSelectedCommand = new Command<object>(OnFreeTextSelectedCommand, CanExecute);
            FreeTextDeselectedCommand = new Command<object>(OnFreeTextDeselectedCommand, CanExecute);
            
            ShapeDeleteCommand = new Command<object>(OnShapeDeletedCommand, CanExecute);
            EditTextDeleteCommand = new Command<object>(OnEditTextDeleteCommand, CanExecute);
            TabletBookmarkCommand = new Command<object>(OnTabletBookmarkCommand, CanExecute);

            StampAnnotationSelectedCommand = new Command<object>(OnStampSelectedCommand, CanExecute);
            StampAnnotationDeselectedCommand = new Command<object>(OnStampDeselectedCommand, CanExecute);

            PopupCommand = new Command<object>(OnPopupCommand, CanExecute);
            PopupBackButtonCommand = new Command<object>(OnPopupBackButtonCommand, CanExecute);
            PopupIconCommand = new Command<object>(OnPopupIconCommand, CanExecute);
            SelectPopupIconCommand = new Command<object>(OnSelectPopupIconCommand, CanExecute);
            PopupDeleteCommand = new Command<object>(OnPopupDeleteCommand, CanExecute);
            PopupAnnotationSelectedCommand = new Command(OnPopupAnnotationSelectedCommand, CanExecute);
            PopupAnnotationDeselectedCommand = new Command(OnPopupAnnotationDeselectedCommand, CanExecute);

            InkEraserCommand = new Command(OnInkEraserCommand, CanExecute);
            InkEraserBackButtonCommand = new Command(OnInkEraserBackButtonCommand, CanExecute);
        }

        private void OnMoreOptionsCommand(object obj)
        {
            IsMoreOptionsToolBarVisible = !IsMoreOptionsToolBarVisible;
            IsPickerVisible = false;
        }

        private void OnViewModeToggled(object parameter)
        {
            IsMoreOptionsToolBarVisible = false;
            CurrentPageViewMode = CurrentPageViewMode == PageViewMode.Continuous ? PageViewMode.PageByPage : PageViewMode.Continuous;
        }
        private void OnTabletBookmarkCommand(object parameter)
        {
            if (AnnotationGridHeightRequest != 0)
                OnAnnotationIconClickedCommand(null);
        }
        private void OnOpacityButtonColorCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 100)
            {
                AnnotationGridHeightRequest = 150;
                AnnotationRowHeight = 50;
                ColorRowHeight = 50;
                OpacityRowHeight = 50;
                IsOpacityBarVisible = true;
            }
            else
            {
                AnnotationGridHeightRequest = 100;
                AnnotationRowHeight = 50;
                ColorRowHeight = 50;
                OpacityRowHeight = 1;
                IsOpacityBarVisible = false;
            }
        }

        private void OnInkDeselectedCommand(object parameter)
        {
            if (IsEditInkBarVisible)
            {
                AnnotationGridHeightRequest = 0;
                IsInkBarVisible = false;
                IsEditInkBarVisible = false;
                IsThicknessBarVisible = false;
                IsFontSizeSliderBarVisible = false;
                IsInkColorBarVisible = false;
                IsOpacityBarVisible = false;
            }
        }
        private void OnFreeTextSelectedCommand(object parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsInkBarVisible = false;
            IsEditInkBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsInkColorBarVisible = false;
            IsOpacityBarVisible = false;
            IsEditCircleAnnotationBarVisible = false;
            IsEditLineAnnotationBarVisible = false;
            IsEditArrowAnnotationBarVisible = false;            
            IsEditRectangleAnnotationBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsEditTextAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnFreeTextDeselectedCommand(object parameter)
        {
            AnnotationGridHeightRequest = 0;
            IsInkBarVisible = false;
            IsEditInkBarVisible = false;
            IsShapeAnnotationBarVisible = false;
            IsShapeColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsInkColorBarVisible = false;
            IsOpacityBarVisible = false;
            IsEditCircleAnnotationBarVisible = false;
            IsEditLineAnnotationBarVisible = false;
            IsEditArrowAnnotationBarVisible = false;
            IsEditPolygonAnnotationBarVisible = false;
            IsEditCloudAnnotationBarVisible = false;
            IsEditPolylineAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnShapeSelectedCommand(object[] parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;

            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsInkBarVisible = false;
            IsEditInkBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsInkColorBarVisible = false;
            IsOpacityBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                IsMainAnnotationBarVisible = false;
            }

            var shapeAnnotation = parameter[0] as Syncfusion.SfPdfViewer.XForms.ShapeAnnotation;
            var args = (parameter[1] as Syncfusion.SfPdfViewer.XForms.ShapeAnnotationSelectedEventArgs);

            if (args.AnnotationType == Syncfusion.SfPdfViewer.XForms.AnnotationMode.Rectangle)
            {
                IsEditCircleAnnotationBarVisible = false;
                IsEditLineAnnotationBarVisible = false;
                IsEditArrowAnnotationBarVisible = false;
                IsEditFreeTextAnnotationBarVisible = false;
                IsEditRectangleAnnotationBarVisible = true;
                IsEditPolygonAnnotationBarVisible = false;
                IsEditCloudAnnotationBarVisible = false;
                IsEditPolylineAnnotationBarVisible = false;
            }
            else if (args.AnnotationType == Syncfusion.SfPdfViewer.XForms.AnnotationMode.Circle)
            {
                IsEditCircleAnnotationBarVisible = true;
                IsEditLineAnnotationBarVisible = false;
                IsEditArrowAnnotationBarVisible = false;
                IsEditFreeTextAnnotationBarVisible = false;
                IsEditRectangleAnnotationBarVisible = false;
                IsEditPolygonAnnotationBarVisible = false;
                IsEditCloudAnnotationBarVisible = false;
                IsEditPolylineAnnotationBarVisible = false;
            }
            else if (args.AnnotationType == Syncfusion.SfPdfViewer.XForms.AnnotationMode.Line)
            {
                IsEditCircleAnnotationBarVisible = false;
                IsEditLineAnnotationBarVisible = true;
                IsEditArrowAnnotationBarVisible = false;
                IsEditFreeTextAnnotationBarVisible = false;
                IsEditRectangleAnnotationBarVisible = false;
                IsEditPolygonAnnotationBarVisible = false;
                IsEditCloudAnnotationBarVisible = false;
                IsEditPolylineAnnotationBarVisible = false;
            }
            else if (args.AnnotationType == Syncfusion.SfPdfViewer.XForms.AnnotationMode.Arrow)
            {
                IsEditCircleAnnotationBarVisible = false;
                IsEditLineAnnotationBarVisible = false;
                IsEditArrowAnnotationBarVisible = true;
                IsEditFreeTextAnnotationBarVisible = false;
                IsEditRectangleAnnotationBarVisible = false;
                IsEditPolygonAnnotationBarVisible = false;
                IsEditCloudAnnotationBarVisible = false;
                IsEditPolylineAnnotationBarVisible = false;
            }
            else if (args.AnnotationType == Syncfusion.SfPdfViewer.XForms.AnnotationMode.Polygon)
            {

                if (shapeAnnotation.Settings.BorderEffect == BorderEffect.Solid)
                {
                    IsEditPolygonAnnotationBarVisible = true;
                    IsEditCloudAnnotationBarVisible = false;
                }
                else
                {
                    IsEditCloudAnnotationBarVisible = true;
                    IsEditPolygonAnnotationBarVisible = false;
                }

                IsShapeAnnotationBarVisible = false;                
                IsEditCircleAnnotationBarVisible = false;
                IsEditLineAnnotationBarVisible = false;
                IsEditArrowAnnotationBarVisible = false;
                IsEditFreeTextAnnotationBarVisible = false;
                IsEditRectangleAnnotationBarVisible = false;
                IsEditPolylineAnnotationBarVisible = false;
            }

            else if (args.AnnotationType == Syncfusion.SfPdfViewer.XForms.AnnotationMode.Polyline)
            {
                IsEditPolylineAnnotationBarVisible = true;
                IsShapeAnnotationBarVisible = false;                
                IsEditCircleAnnotationBarVisible = false;
                IsEditLineAnnotationBarVisible = false;
                IsEditArrowAnnotationBarVisible = false;
                IsEditFreeTextAnnotationBarVisible = false;
                IsEditRectangleAnnotationBarVisible = false;
                IsEditCloudAnnotationBarVisible = false;
                IsEditPolygonAnnotationBarVisible = false;                
            }
        }

        private void OnShapeDeselectedCommand(object parameter)
        {
            AnnotationGridHeightRequest = 0;
            IsInkBarVisible = false;
            IsEditInkBarVisible = false;
            IsShapeAnnotationBarVisible = false;
            IsShapeColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsInkColorBarVisible = false;
            IsOpacityBarVisible = false;
            IsEditCircleAnnotationBarVisible = false;
            IsEditPolygonAnnotationBarVisible = false;
            IsEditCloudAnnotationBarVisible = false;
            IsEditLineAnnotationBarVisible = false;
            IsEditArrowAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnPopupAnnotationSelectedCommand(object parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsInkBarVisible = false;
            IsEditInkBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsInkColorBarVisible = false;
            IsOpacityBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                IsMainAnnotationBarVisible = false;
            }
            IsEditPopupAnnotationBarVisible = true;
            IsPopupBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }
        
        private void OnPopupAnnotationDeselectedCommand(object parameter)
        {
            AnnotationGridHeightRequest = 0;
            IsInkBarVisible = false;
            IsEditInkBarVisible = false;
            IsShapeAnnotationBarVisible = false;
            IsShapeColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsInkColorBarVisible = false;
            IsOpacityBarVisible = false;
            IsEditCircleAnnotationBarVisible = false;
            IsEditPolygonAnnotationBarVisible = false;
            IsEditCloudAnnotationBarVisible = false;
            IsEditLineAnnotationBarVisible = false;
            IsEditArrowAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnRectangleDeselectedCommand(object parameter)
        {
            if (IsEditRectangleAnnotationBarVisible)
            {
                AnnotationGridHeightRequest = 0;
                IsInkBarVisible = false;
                IsEditInkBarVisible = false;
                IsThicknessBarVisible = false;
                IsFontSizeSliderBarVisible = false;
                IsInkColorBarVisible = false;
                IsOpacityBarVisible = false;
                IsEditCircleAnnotationBarVisible = false;
                IsEditLineAnnotationBarVisible = false;
                IsEditArrowAnnotationBarVisible = false;
                IsEditFreeTextAnnotationBarVisible = false;
                IsEditRectangleAnnotationBarVisible = false;
            }
        }
        private void OnCircleDeselectedCommand(object parameter)
        {
            if (IsEditCircleAnnotationBarVisible)
            {
                AnnotationGridHeightRequest = 0;
                IsInkBarVisible = false;
                IsEditInkBarVisible = false;
                IsEditCircleAnnotationBarVisible = false;
                IsFontSizeSliderBarVisible = false;
                IsEditLineAnnotationBarVisible = false;
                IsEditFreeTextAnnotationBarVisible = false;
                IsEditArrowAnnotationBarVisible = false;
                IsEditRectangleAnnotationBarVisible = false;
                IsThicknessBarVisible = false;
                IsInkColorBarVisible = false;
                IsOpacityBarVisible = false;
            }
        }

        private void OnLineDeselectedCommand(object parameter)
        {
            if (IsEditLineAnnotationBarVisible)
            {
                AnnotationGridHeightRequest = 0;
                IsInkBarVisible = false;
                IsEditInkBarVisible = false;
                IsThicknessBarVisible = false;
                IsFontSizeSliderBarVisible = false;
                IsInkColorBarVisible = false;
                IsOpacityBarVisible = false;
                IsEditFreeTextAnnotationBarVisible = false;
                IsEditCircleAnnotationBarVisible = false;
                IsEditLineAnnotationBarVisible = false;
                IsEditArrowAnnotationBarVisible = false;
                IsEditRectangleAnnotationBarVisible = false;
            }
        }
        private void OnArrowDeselectedCommand(object parameter)
        {
            if (IsEditArrowAnnotationBarVisible)
            {
                AnnotationGridHeightRequest = 0;
                IsInkBarVisible = false;
                IsEditInkBarVisible = false;
                IsThicknessBarVisible = false;
                IsInkColorBarVisible = false;
                IsFontSizeSliderBarVisible = false;
                IsOpacityBarVisible = false;
                IsEditFreeTextAnnotationBarVisible = false;
                IsEditFreeTextAnnotationBarVisible = false;
                IsEditCircleAnnotationBarVisible = false;
                IsEditLineAnnotationBarVisible = false;
                IsEditArrowAnnotationBarVisible = false;
                IsEditRectangleAnnotationBarVisible = false;
            }
        }
        private void OnInkOpacityCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 100)
            {
                AnnotationGridHeightRequest = 150;
                AnnotationRowHeight = 50;
                ColorRowHeight = 50;
                OpacityRowHeight = 50;
                IsOpacityBarVisible = true;
            }
            else
            {
                AnnotationGridHeightRequest = 100;
                AnnotationRowHeight = 50;
                ColorRowHeight = 50;
                OpacityRowHeight = 1;
                IsOpacityBarVisible = false;
            }
            IsMoreOptionsToolBarVisible = false;

        }

     

        private void OnInkThicknessCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 120;
                AnnotationRowHeight = 50;
                ColorRowHeight = 70;
                IsFontSizeSliderBarVisible = false;
                IsThicknessBarVisible = true;
            }
            else
            {
                if (IsInkColorBarVisible)
                {
                    AnnotationGridHeightRequest = 120;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 70;
                    IsInkColorBarVisible = false;
                    IsFontSizeSliderBarVisible = false;
                    IsThicknessBarVisible = true;
                    IsOpacityBarVisible = false;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    IsFontSizeSliderBarVisible = false;
                    IsThicknessBarVisible = false;
                }
            }
        }

        private void OnRectangleThicknessCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 120;
                AnnotationRowHeight = 50;
                ColorRowHeight = 70;
                IsFontSizeSliderBarVisible = false;
                IsThicknessBarVisible = true;
            }
            else
            {
                if (IsShapeColorBarVisible)
                {
                    AnnotationGridHeightRequest = 120;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 70;
                    IsInkColorBarVisible = false;
                    IsFontSizeSliderBarVisible = false;
                    IsShapeColorBarVisible = false;
                    IsThicknessBarVisible = true;
                    IsOpacityBarVisible = false;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    IsFontSizeSliderBarVisible = false;
                    IsThicknessBarVisible = false;
                    IsOpacityBarVisible = false;
                    IsShapeColorBarVisible = false;
                }
            }
        }
        private void OnCircleThicknessCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 120;
                AnnotationRowHeight = 50;
                IsFontSizeSliderBarVisible = false;
                ColorRowHeight = 70;
                IsThicknessBarVisible = true;
            }
            else
            {
                if (IsShapeColorBarVisible)
                {
                    AnnotationGridHeightRequest = 120;
                    AnnotationRowHeight = 50;
                    IsFontSizeSliderBarVisible = false;
                    ColorRowHeight = 70;
                    IsShapeColorBarVisible = false;
                    IsThicknessBarVisible = true;
                    IsOpacityBarVisible = false;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    IsFontSizeSliderBarVisible = false;
                    IsThicknessBarVisible = false;
                    IsShapeColorBarVisible = false;
                }
            }
        }
        private void OnLineThicknessCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 120;
                AnnotationRowHeight = 50;
                IsFontSizeSliderBarVisible = false;
                ColorRowHeight = 70;
                IsThicknessBarVisible = true;
            }
            else
            {
                if (IsShapeColorBarVisible)
                {
                    AnnotationGridHeightRequest = 120;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 70;
                    IsShapeColorBarVisible = false;
                    IsFontSizeSliderBarVisible = false;
                    IsThicknessBarVisible = true;
                    IsOpacityBarVisible = false;
                }
                else
                {
                    IsFontSizeSliderBarVisible = false;
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    IsThicknessBarVisible = false;
                    IsShapeColorBarVisible = false;
                }
            }
        }

        private void OnArrowThicknessCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 120;
                IsFontSizeSliderBarVisible = false;
                AnnotationRowHeight = 50;
                ColorRowHeight = 70;
                IsThicknessBarVisible = true;
            }
            else
            {
                if (IsShapeColorBarVisible)
                {
                    AnnotationGridHeightRequest = 120;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 70;
                    IsFontSizeSliderBarVisible = false;
                    IsShapeColorBarVisible = false;
                    IsThicknessBarVisible = true;
                    IsOpacityBarVisible = false;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    IsThicknessBarVisible = false;
                    IsFontSizeSliderBarVisible = false;
                    IsShapeColorBarVisible = false;
                }
            }
        }

        private void OnPolygonThicknessCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 120;
                IsFontSizeSliderBarVisible = false;
                AnnotationRowHeight = 50;
                ColorRowHeight = 70;
                IsThicknessBarVisible = true;
            }
            else
            {
                if (IsShapeColorBarVisible)
                {
                    AnnotationGridHeightRequest = 120;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 70;
                    IsFontSizeSliderBarVisible = false;
                    IsShapeColorBarVisible = false;
                    IsThicknessBarVisible = true;
                    IsOpacityBarVisible = false;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    IsThicknessBarVisible = false;
                    IsFontSizeSliderBarVisible = false;
                    IsShapeColorBarVisible = false;
                }
            }
        }

        private void OnCloudThicknessCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 120;
                IsFontSizeSliderBarVisible = false;
                AnnotationRowHeight = 50;
                ColorRowHeight = 70;
                IsThicknessBarVisible = true;
            }
            else
            {
                if (IsShapeColorBarVisible)
                {
                    AnnotationGridHeightRequest = 120;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 70;
                    IsFontSizeSliderBarVisible = false;
                    IsShapeColorBarVisible = false;
                    IsThicknessBarVisible = true;
                    IsOpacityBarVisible = false;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    IsThicknessBarVisible = false;
                    IsFontSizeSliderBarVisible = false;
                    IsShapeColorBarVisible = false;
                }
            }
        }
        
        private void OnPolylineThicknessCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 120;
                IsFontSizeSliderBarVisible = false;
                AnnotationRowHeight = 50;
                ColorRowHeight = 70;
                IsThicknessBarVisible = true;
            }
            else
            {
                if (IsShapeColorBarVisible)
                {
                    AnnotationGridHeightRequest = 120;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 70;
                    IsFontSizeSliderBarVisible = false;
                    IsShapeColorBarVisible = false;
                    IsThicknessBarVisible = true;
                    IsOpacityBarVisible = false;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    IsThicknessBarVisible = false;
                    IsFontSizeSliderBarVisible = false;
                    IsShapeColorBarVisible = false;
                }
            }
        }

        private void OnEditTextFontSizeCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 120;
                AnnotationRowHeight = 50;
                ColorRowHeight = 70;
                IsFontSizeSliderBarVisible = true;
                IsThicknessBarVisible = false;
                IsOpacityBarVisible = false;
            }
            else
            {
                AnnotationGridHeightRequest = 50;
                AnnotationRowHeight = 50;
                ColorRowHeight = 1;
                IsFontSizeSliderBarVisible = false;
                IsThicknessBarVisible = false;
                IsOpacityBarVisible = false;
            }
        }

        private void OnShapeBackButtonCommand(object parameter)
        {
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsOpacityBarVisible = false;
            IsInkColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            ColorRowHeight = 1;
            IsRectangleBarVisible = false;
            IsLineBarVisible = false;
            IsCircleBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsShapeAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = true;
            IsToolbarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
        }
        private void OnEditTextBackButtonCommand(object parameter)
        {
            AnnotationGridHeightRequest = 50;
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsOpacityBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsInkColorBarVisible = false;
            IsShapeAnnotationBarVisible = false;
            IsShapeColorBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            ColorRowHeight = 1;
            IsRectangleBarVisible = false;
            IsLineBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsEditTextAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = true;
            IsToolbarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }
        private void OnInkBackButtonCommand(object parameter)
        {
            AnnotationGridHeightRequest = 50;
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsOpacityBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsInkColorBarVisible = false;
            ColorRowHeight = 1;
            IsFontSizeSliderBarVisible = false;
            IsRectangleBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsLineBarVisible = false;
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsMainAnnotationBarVisible = true;
            IsToolbarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
        }

        private void OnRectangleBackButtonCommand(object parameter)
        {
            AnnotationGridHeightRequest = 50;
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsOpacityBarVisible = false;
            IsInkColorBarVisible = false;
            IsRectangleBarVisible = false;
            IsLineBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;          
            IsEditAnnotationBarVisible = false;
            ColorRowHeight = 1;
            IsMainAnnotationBarVisible = false;
            IsShapeAnnotationBarVisible = true;
            IsShapeColorBarVisible = false;            
            IsToolbarVisible = true;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }
        private void OnCircleBackButtonCommand(object parameter)
        {
            AnnotationGridHeightRequest = 50;
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsOpacityBarVisible = false;
            IsInkColorBarVisible = false;
            IsRectangleBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsLineBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsEditAnnotationBarVisible = false;          
            ColorRowHeight = 1;
            IsMainAnnotationBarVisible = false;
            IsShapeAnnotationBarVisible = true;
            IsShapeColorBarVisible = false;
            IsToolbarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }
        private void OnLineBackButtonCommand(object parameter)
        {
            AnnotationGridHeightRequest = 50;
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsOpacityBarVisible = false;
            IsInkColorBarVisible = false;
            IsRectangleBarVisible = false;
            IsLineBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsShapeColorBarVisible = false;
            ColorRowHeight = 1;
            IsMainAnnotationBarVisible = false;
            IsShapeAnnotationBarVisible = true;
            IsToolbarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnArrowBackButtonCommand(object parameter)
        {
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsOpacityBarVisible = false;
            IsInkColorBarVisible = false;
            IsRectangleBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsLineBarVisible = false;
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsShapeColorBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            AnnotationGridHeightRequest = 50;
            ColorRowHeight = 1;
            IsMainAnnotationBarVisible = false;
            IsShapeAnnotationBarVisible = true;
            IsToolbarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnPolygonBackButtonCommand(object parameter)
        {
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsOpacityBarVisible = false;
            IsInkColorBarVisible = false;
            IsRectangleBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsLineBarVisible = false;
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsShapeColorBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            AnnotationGridHeightRequest = 50;
            ColorRowHeight = 1;
            IsMainAnnotationBarVisible = false;
            IsShapeAnnotationBarVisible = true;
            IsToolbarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }


        private void OnCloudBackButtonCommand(object parameter)
        {
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsOpacityBarVisible = false;
            IsInkColorBarVisible = false;
            IsRectangleBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsLineBarVisible = false;
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsShapeColorBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            AnnotationGridHeightRequest = 50;
            ColorRowHeight = 1;
            IsMainAnnotationBarVisible = false;
            IsShapeAnnotationBarVisible = true;
            IsToolbarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }
        
        private void OnPolylineBackButtonCommand(object parameter)
        {
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsOpacityBarVisible = false;
            IsInkColorBarVisible = false;
            IsRectangleBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsLineBarVisible = false;
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsShapeColorBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            AnnotationGridHeightRequest = 50;
            ColorRowHeight = 1;
            IsMainAnnotationBarVisible = false;
            IsShapeAnnotationBarVisible = true;
            IsToolbarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnPopupBackButtonCommand(object parameter)
        {
            AnnotationGridHeightRequest = 50;
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsOpacityBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsInkColorBarVisible = false;
            IsShapeAnnotationBarVisible = false;
            IsShapeColorBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            ColorRowHeight = 1;
            IsRectangleBarVisible = false;
            IsLineBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsEditTextAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = true;
            IsToolbarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnTextMarkupBackCommand(object parameter)
        {
            IsSecondaryAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = true;
            IsMoreOptionsToolBarVisible = false;
        }
        private void OnTextMarkupCommand(object parameter)
        {
            IsMainAnnotationBarVisible = false;
            IsSecondaryAnnotationBarVisible = true;
            IsMoreOptionsToolBarVisible = false;
        }

        private void OnInkCommand(object parameter)
        {
            IsMainAnnotationBarVisible = false;
            IsToolbarVisible = false;
            IsInkBarVisible = true;
            IsMoreOptionsToolBarVisible = false;
        }
        private void OnEditTextCommand(object parameter)
        {

            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                
                IsToolbarVisible = true;
            }
            else
            {
                IsToolbarVisible = false;
            }
            IsMainAnnotationBarVisible = false;
            IsInkBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsEditTextAnnotationBarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }
        private void OnShapeCommand(object parameter)
        {
            if(Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                IsMainAnnotationBarVisible = true;
                IsToolbarVisible = true;
            }
            else
            {
                IsMainAnnotationBarVisible = false;
                IsToolbarVisible = false;
            }
          
            IsInkBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsShapeAnnotationBarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnPopupCommand(object parameter)
        {
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                IsToolbarVisible = true;
            }
            else
            {
                IsToolbarVisible = false;
            }
            IsMainAnnotationBarVisible = false;
            IsInkBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsEditTextAnnotationBarVisible = false;
            IsPopupBarVisible = true;
            IsPopupIconSelectorBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }

        private void OnInkEraserCommand(object parameter)
        {
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                IsToolbarVisible = true;
            }
            else
            {
                IsToolbarVisible = false;
                if (AnnotationGridHeightRequest == 50)
                {
                    AnnotationGridHeightRequest = 120;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 70;
                }
            }
            IsMainAnnotationBarVisible = false;
            IsInkEraserBarVisible = true;
            IsPickerVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }

        private void OnInkEraserBackButtonCommand(object parameter)
        {
            AnnotationGridHeightRequest = 50;
            IsInkEraserBarVisible = false;
            IsMainAnnotationBarVisible = true;
            IsPickerVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }

        private void OnDeleteCommand(object parameter)
        {
            IsEditAnnotationBarVisible = false;
            IsEditStampAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsInkColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsOpacityBarVisible = false;
            AnnotationGridHeightRequest = 0;
            IsMoreOptionsToolBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnDocumentLoadedCommand(object parameter)
        {
            AnnotationGridHeightRequest = 0;
            IsSecondaryAnnotationBarVisible = false;
            IsColorBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsSquigglyBarVisible = false;
            IsRectangleAnnotationBarVisible = false;
            IsShapeAnnotationBarVisible = false;
            IsCircleAnnotationBarVisible = false;
            IsLineAnnotationBarVisible = false;
            IsArrowAnnotationBarVisible = false;
            IsPolygonAnnotationBarVisible = false;
            IsCloudAnnotationBarVisible = false;
            IsPolylineAnnotationBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsInkBarVisible = false;
            IsInkColorBarVisible = false;
            IsEditInkBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsEditLineAnnotationBarVisible = false;
            IsEditCircleAnnotationBarVisible = false;
            IsThicknessBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsOpacityBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
            IsInkEraserBarVisible = false;
        }
        private void OnTextMarkupSelectedCommand(object parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsUnderlineBarVisible = false;
            IsSquigglyBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsEditAnnotationBarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnStampSelectedCommand(object parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsUnderlineBarVisible = false;
            IsSquigglyBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsEditStampAnnotationBarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }

        private void OnTextMarkupDeselectedCommand(object parameter)
        {
			if (IsEditAnnotationBarVisible)
			{
				AnnotationGridHeightRequest = 0;
				IsEditAnnotationBarVisible = false;
			}
        }

        private void OnStampDeselectedCommand(object parameter)
        {
            if (IsEditStampAnnotationBarVisible)
            {
                AnnotationGridHeightRequest = 0;
                IsEditStampAnnotationBarVisible = false;
            }
            IsMoreOptionsToolBarVisible = false;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool CanExecute(object parameter)
        {
            return true;
        }

        private void OnSearchAndToolbarToggleCommand(object destinationPageParam)
        {
            IsToolbarVisible = !IsToolbarVisible;
            IsSearchbarVisible = !IsSearchbarVisible;
            IsPickerVisible = false;
            IsMoreOptionsToolBarVisible = false;
            IsSecondaryAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsColorBarVisible = false;
            IsHighlightBarVisible = IsUnderlineBarVisible = IsStrikeThroughBarVisible = IsSquigglyBarVisible = false;
			IsEditAnnotationBarVisible = false;
            AnnotationGridHeightRequest = 0;
            SearchedText = string.Empty;
            IsInkEraserBarVisible = false;
        }

        private void OnFileOpenedCommand(object openedFile)
        {
            IsPickerVisible = !IsPickerVisible;
            if(IsBookMarkVisible)
            IsBookMarkVisible = false;
            IsMoreOptionsToolBarVisible = false;
            IsContextMenuVisible = false;            
          
        }

        private void OnAnnotationIconClickedCommand(object parameter)
        {
            IsSearchbarVisible = false;
            if (IsAnnotationGridVisible)
            {
                IsAnnotationGridVisible = false;
            }
            else
                IsAnnotationGridVisible = true;
            if (AnnotationGridHeightRequest == 0)
            {
                AnnotationGridHeightRequest = 50;
                IsMainAnnotationBarVisible = true;
            }
            else
            {
                if (!IsEditAnnotationBarVisible)
                {
                    AnnotationGridHeightRequest = 0;
                    IsMainAnnotationBarVisible = false;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    IsMainAnnotationBarVisible = true;
                }
            }

            AnnotationRowHeight = 50;
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            IsInkColorBarVisible = false;
            IsOpacityBarVisible = false;
            IsFontSizeSliderBarVisible = false;
            IsThicknessBarVisible = false;
            IsShapeColorBarVisible = false;
            IsHighlightBarVisible = false;
            IsUnderlineBarVisible = false;
            IsSquigglyBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsSecondaryAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsInkBarVisible = false;
            IsPickerVisible = false;
            IsMoreOptionsToolBarVisible = false;
            IsShapeAnnotationBarVisible = false;
            IsRectangleBarVisible = false;
            IsCircleBarVisible = false;
            IsLineBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsPopupBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                IsEditTextAnnotationBarVisible = false;
            }
            IsArrowBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsEditLineAnnotationBarVisible = false;
            IsEditCircleAnnotationBarVisible = false;
            IsEditArrowAnnotationBarVisible = false;
            IsEditPolygonAnnotationBarVisible = false;
            IsEditCloudAnnotationBarVisible = false;
            IsEditPolylineAnnotationBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsInkEraserBarVisible = false;
        }

        private void OnHighlightCommand(object parameter)
        {
            IsSecondaryAnnotationBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsHighlightBarVisible = true;
            IsSquigglyBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsRectangleBarVisible = false;
            IsCircleBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsLineBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsPopupBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }

        private void OnUnderlineCommand(object parameter)
        {
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsUnderlineBarVisible = true;
            IsSquigglyBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsRectangleBarVisible = false;
            IsCircleBarVisible = false;
            IsLineBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsPopupBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }

        private void OnStrikeThroughCommand(object parameter)
        {
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = true;
            IsSquigglyBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsRectangleBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsCircleBarVisible = false;
            IsLineBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsPopupBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }
        
        private void OnSquigglyCommand(object parameter)
        {
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsSquigglyBarVisible = true;
            IsEditAnnotationBarVisible = false;
            IsRectangleBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsCircleBarVisible = false;
            IsLineBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsPopupBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }
        private void OnRectangleCommand(object parameter)
        {
            IsRectangleBarVisible = true;
            IsShapeAnnotationBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsHighlightBarVisible = false;
            IsSquigglyBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsSecondaryAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsInkBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;            
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsPopupBarVisible = false;
            IsMoreOptionsToolBarVisible = false;

        }
        private void OnCircleCommand(object parameter)
        {
            IsCircleBarVisible = true;
            IsShapeAnnotationBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsHighlightBarVisible = false;          
            IsSquigglyBarVisible = false;
            IsSecondaryAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsInkBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsRectangleBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsLineBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsPopupBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }
        private void OnLineCommand(object parameter)
        {
            IsLineBarVisible = true;
            IsShapeAnnotationBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsHighlightBarVisible = false;
            IsSquigglyBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsSecondaryAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsInkBarVisible = false;
            IsRectangleBarVisible = false;
            IsCircleBarVisible = false;
            IsArrowBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsPopupBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }
        private void OnArrowCommand(object parameter)
        {
            IsArrowBarVisible = true;
            IsShapeAnnotationBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsHighlightBarVisible = false;
            IsSquigglyBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsSecondaryAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false; 
            IsEditInkBarVisible = false;
            IsInkBarVisible = false;
            IsRectangleBarVisible = false;
            IsCircleBarVisible = false;
            IsLineBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsPopupBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }

        private void OnPolygonCommand(object parameter)
        {
            IsPolygonBarVisible = true;
            IsArrowBarVisible = false;
            IsShapeAnnotationBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsHighlightBarVisible = false;
            IsSquigglyBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsSecondaryAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsInkBarVisible = false;
            IsRectangleBarVisible = false;
            IsCircleBarVisible = false;
            IsLineBarVisible = false;
            IsCloudBarVisible = false;
            IsPolylineBarVisible = false;
            IsPopupBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }

        private void OnCloudCommand(object parameter)
        {
            IsCloudBarVisible = true;
            IsArrowBarVisible = false;
            IsShapeAnnotationBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsHighlightBarVisible = false;
            IsSquigglyBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsSecondaryAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsInkBarVisible = false;
            IsRectangleBarVisible = false;
            IsCircleBarVisible = false;
            IsLineBarVisible = false;
            IsPolygonBarVisible = false;
            IsPolylineBarVisible = false;
            IsPopupBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }
        
        private void OnPolylineCommand(object parameter)
        {
            IsPolylineBarVisible = true;
            IsArrowBarVisible = false;
            IsShapeAnnotationBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsHighlightBarVisible = false;
            IsSquigglyBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsSecondaryAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsInkBarVisible = false;
            IsRectangleBarVisible = false;
            IsCircleBarVisible = false;
            IsLineBarVisible = false;
            IsPolygonBarVisible = false;
            IsCloudBarVisible = false;
            IsPopupBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }

        private void OnAnnotationBackCommand(object parameter)
        {
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsSquigglyBarVisible = false;
            IsSecondaryAnnotationBarVisible = true;
            IsMoreOptionsToolBarVisible = false;
        }

        private void OnColorButtonClickedCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 100;
                AnnotationRowHeight = 50;
                ColorRowHeight = 50;
                if (IsHighlightBarVisible || IsUnderlineBarVisible || IsStrikeThroughBarVisible || IsSquigglyBarVisible || IsEditAnnotationBarVisible
                    || IsEditFreeTextAnnotationBarVisible || IsEditTextAnnotationBarVisible)
                    IsColorBarVisible = true;
                else if (IsInkBarVisible || IsEditInkBarVisible)
                    IsInkColorBarVisible = true;
                else if (IsRectangleBarVisible || IsCircleBarVisible || IsLineBarVisible || IsArrowBarVisible || IsPolygonBarVisible || IsCloudBarVisible || IsPolylineBarVisible || IsEditArrowAnnotationBarVisible
                    || IsEditCircleAnnotationBarVisible | IsEditRectangleAnnotationBarVisible || IsEditLineAnnotationBarVisible || IsEditPolygonAnnotationBarVisible || IsEditCloudAnnotationBarVisible || IsEditPolylineAnnotationBarVisible || IsPopupBarVisible || IsEditPopupAnnotationBarVisible)
                {
                    IsShapeColorBarVisible = true;
                }
            }
            else
            {
                if (IsThicknessBarVisible || IsFontSizeSliderBarVisible)
                {
                    IsThicknessBarVisible = false;
                    IsFontSizeSliderBarVisible = false;
                    AnnotationGridHeightRequest = 100;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 50;
                    if (IsHighlightBarVisible || IsUnderlineBarVisible || IsStrikeThroughBarVisible || IsSquigglyBarVisible || IsEditAnnotationBarVisible
                   || IsEditFreeTextAnnotationBarVisible || IsEditTextAnnotationBarVisible)
                        IsColorBarVisible = true;
                    else if (IsInkBarVisible || IsEditInkBarVisible)
                        IsInkColorBarVisible = true;
                    else if (IsRectangleBarVisible || IsCircleBarVisible || IsLineBarVisible || IsArrowBarVisible || IsPolygonBarVisible || IsCloudBarVisible || IsPolylineBarVisible || IsEditArrowAnnotationBarVisible
                        || IsEditCircleAnnotationBarVisible | IsEditRectangleAnnotationBarVisible || IsEditLineAnnotationBarVisible || IsEditPolygonAnnotationBarVisible || IsEditCloudAnnotationBarVisible || IsEditPolylineAnnotationBarVisible || IsPopupBarVisible || IsEditPopupAnnotationBarVisible)
                    {
                        IsShapeColorBarVisible = true;
                    }
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    if (IsHighlightBarVisible || IsUnderlineBarVisible || IsStrikeThroughBarVisible || IsSquigglyBarVisible || IsEditAnnotationBarVisible
                   || IsEditFreeTextAnnotationBarVisible || IsEditTextAnnotationBarVisible)
                        IsColorBarVisible = false;
                    else if (IsInkBarVisible || IsEditInkBarVisible)
                        IsInkColorBarVisible = false;
                    else if (IsRectangleBarVisible || IsCircleBarVisible || IsLineBarVisible || IsArrowBarVisible || IsPolygonBarVisible || IsCloudBarVisible || IsPolylineBarVisible || IsEditArrowAnnotationBarVisible
                        || IsEditCircleAnnotationBarVisible | IsEditRectangleAnnotationBarVisible || IsEditLineAnnotationBarVisible || IsEditPolygonAnnotationBarVisible || IsEditCloudAnnotationBarVisible || IsEditPolylineAnnotationBarVisible || IsPopupBarVisible || IsEditPopupAnnotationBarVisible)
                    {
                        IsShapeColorBarVisible = false;
                    }
                    IsOpacityBarVisible = false;
                    IsThicknessBarVisible = false;
                    IsFontSizeSliderBarVisible = false;
                }
            }
        }

        private void OnInkSelectedCommand(object parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsUnderlineBarVisible = false;
            IsSquigglyBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsEditInkBarVisible = true;
            IsMoreOptionsToolBarVisible = false;
            IsPopupBarVisible = false;
            IsEditPopupAnnotationBarVisible = false;
            IsPopupIconSelectorBarVisible = false;
        }
        private void OnRectangleSelectedCommand(object parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsUnderlineBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsEditCircleAnnotationBarVisible = false;
            IsEditLineAnnotationBarVisible = false;
            IsEditArrowAnnotationBarVisible = false;
            IsEditRectangleAnnotationBarVisible = true;
            IsMoreOptionsToolBarVisible = false;
        }
        private void OnCircleSelectedCommand(object parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsUnderlineBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsEditCircleAnnotationBarVisible = true;
            IsEditLineAnnotationBarVisible = false;
            IsEditArrowAnnotationBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }
        private void OnLineSelectedCommand(object parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsUnderlineBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsEditCircleAnnotationBarVisible = false;
            IsEditLineAnnotationBarVisible = true;
            IsEditArrowAnnotationBarVisible = false;
            IsEditRectangleAnnotationBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }
        private void OnArrowSelectedCommand(object parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsUnderlineBarVisible = false;
            IsEditFreeTextAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsEditCircleAnnotationBarVisible = false;
            IsEditLineAnnotationBarVisible = false;
            IsEditArrowAnnotationBarVisible = true;
            IsEditRectangleAnnotationBarVisible = false;
        }

        private void OnShapeDeletedCommand(object parameter)
        {
            if (IsEditRectangleAnnotationBarVisible)
                IsEditRectangleAnnotationBarVisible = false;
            else if (IsEditCircleAnnotationBarVisible)
                IsEditCircleAnnotationBarVisible = false;
            else if (IsEditLineAnnotationBarVisible)
                IsEditLineAnnotationBarVisible = false;
            else if (IsEditArrowAnnotationBarVisible)
                IsEditArrowAnnotationBarVisible = false;
            else if (IsEditPolygonAnnotationBarVisible)
                IsEditPolygonAnnotationBarVisible = false;
            else if (IsEditCloudAnnotationBarVisible)
                IsEditCloudAnnotationBarVisible = false;
            else if (IsEditPolylineAnnotationBarVisible)
                IsEditPolylineAnnotationBarVisible = false;
        }


        private void OnEditTextDeleteCommand(object parameter)
        {
            if (IsEditRectangleAnnotationBarVisible)
            {
                IsShapeColorBarVisible = false;
                IsColorBarVisible = false;
                IsEditRectangleAnnotationBarVisible = false;
            }
            else if (IsEditCircleAnnotationBarVisible)
            {
                IsColorBarVisible = false;
                IsShapeColorBarVisible = false;
                IsEditCircleAnnotationBarVisible = false;
            }
            else if (IsEditLineAnnotationBarVisible)
            {
                IsColorBarVisible = false;
                IsShapeColorBarVisible = false;
                IsEditLineAnnotationBarVisible = false;
            }
            else if (IsEditArrowAnnotationBarVisible)
            {
                IsColorBarVisible = false;
                IsShapeColorBarVisible = false;
                IsEditArrowAnnotationBarVisible = false;
            }
            else if (IsEditTextAnnotationBarVisible)
            {
                IsShapeColorBarVisible = false;
                IsColorBarVisible = false;
                IsEditTextAnnotationBarVisible = false;
            }
            else if (IsEditFreeTextAnnotationBarVisible)
            {
                IsColorBarVisible = false;
                IsShapeColorBarVisible = false;
                IsEditFreeTextAnnotationBarVisible = false;
            }
            else if (IsEditPolygonAnnotationBarVisible)
            {
                IsColorBarVisible = false;
                IsShapeColorBarVisible = false;
                IsEditPolygonAnnotationBarVisible = false;
            }
            else if (IsEditCloudAnnotationBarVisible)
            {
                IsColorBarVisible = false;
                IsShapeColorBarVisible = false;
                IsEditCloudAnnotationBarVisible = false;
            }
            else if (IsEditPolylineAnnotationBarVisible)
            {
                IsColorBarVisible = false;
                IsShapeColorBarVisible = false;
                IsEditPolylineAnnotationBarVisible = false;
            }
            else if (IsEditPopupAnnotationBarVisible)
            {
                IsColorBarVisible = false;
                IsShapeColorBarVisible = false;
                IsEditPopupAnnotationBarVisible = false;
                IsPopupIconSelectorBarVisible = false;
            }
        }

        private void OnPopupIconCommand(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Comment":
                    {
                        if (IsPopupBarVisible)
                            PopupIcon = PopupIcon.Comment;
                        else if (IsEditPopupAnnotationBarVisible)
                            EditPopupIcon = PopupIcon.Comment;
                    }
                    break;
                case "Note":
                    {
                        if (IsPopupBarVisible)
                            PopupIcon = PopupIcon.Note;
                        else if (IsEditPopupAnnotationBarVisible)
                            EditPopupIcon = PopupIcon.Note;
                    }
                    break;
                case "Help":
                    {
                        if (IsPopupBarVisible)
                            PopupIcon = PopupIcon.Help;
                        else if (IsEditPopupAnnotationBarVisible)
                            EditPopupIcon = PopupIcon.Help;
                    }
                    break;
                case "Key":
                    {
                        if (IsPopupBarVisible)
                            PopupIcon = PopupIcon.Key;
                        else if (IsEditPopupAnnotationBarVisible)
                            EditPopupIcon = PopupIcon.Key;
                    }
                    break;
                case "Paragraph":
                    {
                        if (IsPopupBarVisible)
                            PopupIcon = PopupIcon.Paragraph;
                        else if (IsEditPopupAnnotationBarVisible)
                            EditPopupIcon = PopupIcon.Paragraph;
                    }
                    break;
                case "NewParagraph":
                    {
                        if (IsPopupBarVisible)
                            PopupIcon = PopupIcon.NewParagraph;
                        else if (IsEditPopupAnnotationBarVisible)
                            EditPopupIcon = PopupIcon.NewParagraph;
                    }
                    break;
                case "Insert":
                    {
                        if (IsPopupBarVisible)
                            PopupIcon = PopupIcon.Insert;
                        else if (IsEditPopupAnnotationBarVisible)
                            EditPopupIcon = PopupIcon.Insert;
                    }
                    break;
            }
            IsPopupIconSelectorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            IsShapeColorBarVisible = false;
            IsInkColorBarVisible = false;
            IsOpacityBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
        }

        private void OnSelectPopupIconCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 100;
                AnnotationRowHeight = 50;
                ColorRowHeight = 50;
                IsPopupIconSelectorBarVisible = true;
                IsShapeColorBarVisible = false;
            }
            else
            {
                if (IsThicknessBarVisible || IsFontSizeSliderBarVisible)
                {
                    IsThicknessBarVisible = false;
                    IsFontSizeSliderBarVisible = false;
                    AnnotationGridHeightRequest = 100;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 50;
                    IsPopupIconSelectorBarVisible = true;
                    IsShapeColorBarVisible = false;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    IsOpacityBarVisible = false;
                    IsThicknessBarVisible = false;
                    IsFontSizeSliderBarVisible = false;
                    IsShapeColorBarVisible = false;
                    IsPopupIconSelectorBarVisible = false;
                }
            }
        }
        
        private void OnPopupDeleteCommand(object parameter)
        {
            IsPopupIconSelectorBarVisible = false;
            IsShapeColorBarVisible = false;
        }

        private void OnColorCommand(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Cyan":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.FromHex("#00FFFF");
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.FromHex("#00FFFF");
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.FromHex("#00FFFF");
                        if (IsSquigglyBarVisible)
                            SquigglyColor = Color.FromHex("#00FFFF");
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.FromHex("00FFFF");
                        if (IsInkBarVisible)
                            InkColor = Color.FromHex("00FFFF");
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.FromHex("00FFFF");
                        if (IsEditRectangleAnnotationBarVisible)
                            RectangleDeleteColor = Color.FromHex("00FFFF");
                        if (IsEditCircleAnnotationBarVisible)
                            CircleDeleteColor = Color.FromHex("00FFFF");
                        if (IsEditLineAnnotationBarVisible)
                            LineDeleteColor = Color.FromHex("00FFFF");
                        if (IsEditArrowAnnotationBarVisible)
                            ArrowDeleteColor = Color.FromHex("00FFFF");
                        if (IsEditPolygonAnnotationBarVisible || IsEditCloudAnnotationBarVisible)
                            PolygonDeleteColor = CloudDeleteColor = Color.FromHex("00FFFF");
                        if (IsEditPolylineAnnotationBarVisible)
                            PolylineDeleteColor = Color.FromHex("00FFFF");
                        if (IsEditFreeTextAnnotationBarVisible )
                            EditTextDeleteColor = Color.FromHex("00FFFF");
                        if (IsEditTextColorBarVisible || IsEditTextAnnotationBarVisible)
                            EditTextColor = Color.FromHex("00FFFF");
                        if (IsRectangleBarVisible)
                            RectangleStrokeColor = Color.FromHex("00FFFF");
                        if (IsCircleBarVisible)
                            CircleStrokeColor = Color.FromHex("00FFFF");
                        if (IsLineBarVisible)
                            LineStrokeColor = Color.FromHex("00FFFF");
                        if (IsArrowBarVisible)
                            ArrowStrokeColor = Color.FromHex("00FFFF");
                        if (IsPolygonBarVisible || IsCloudBarVisible)
                            PolygonStrokeColor = CloudStrokeColor = Color.FromHex("00FFFF");
                        if (IsPolylineBarVisible)
                            PolylineStrokeColor = Color.FromHex("00FFFF");
                        if (IsPopupBarVisible)
                            PopupColor = Color.FromHex("00FFFF");
                        if (IsEditPopupAnnotationBarVisible)
                            PopupDeleteColor = Color.FromHex("00FFFF");
                    }
                    break;

                case "Green":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.Green;
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.Green;
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.Green;
                        if (IsSquigglyBarVisible)
                            SquigglyColor = Color.Green;
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.Green;
                        if (IsInkBarVisible)
                            InkColor = Color.Green;
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.Green;
                        if (IsEditRectangleAnnotationBarVisible)
                            RectangleDeleteColor = Color.Green;
                        if (IsEditCircleAnnotationBarVisible)
                            CircleDeleteColor = Color.Green;
                        if (IsEditLineAnnotationBarVisible)
                            LineDeleteColor = Color.Green;
                        if (IsEditArrowAnnotationBarVisible)
                            ArrowDeleteColor = Color.Green;
                        if (IsEditPolygonAnnotationBarVisible || IsEditCloudAnnotationBarVisible)
                            PolygonDeleteColor = CloudDeleteColor = Color.Green;
                        if (IsEditPolylineAnnotationBarVisible)
                            PolylineDeleteColor = Color.Green;
                        if (IsEditFreeTextAnnotationBarVisible )
                            EditTextDeleteColor =  Color.Green;
                        if (IsEditTextColorBarVisible || IsEditTextAnnotationBarVisible)
                            EditTextColor =  Color.Green;
                        if (IsRectangleBarVisible)
                            RectangleStrokeColor =  Color.Green;
                        if (IsCircleBarVisible)
                            CircleStrokeColor =  Color.Green;
                        if (IsLineBarVisible)
                            LineStrokeColor =  Color.Green;
                        if (IsArrowBarVisible)
                            ArrowStrokeColor =  Color.Green;
                        if (IsPolygonBarVisible || IsCloudBarVisible)
                            PolygonStrokeColor = CloudStrokeColor = Color.Green;
                        if (IsPolylineBarVisible)
                            PolylineStrokeColor = Color.Green;
                        if (IsPopupBarVisible)
                            PopupColor = Color.Green;
                        if (IsEditPopupAnnotationBarVisible)
                            PopupDeleteColor = Color.Green;
                    }
                    break;

                case "Yellow":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.Yellow;
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.Yellow;
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.Yellow;
                        if (IsSquigglyBarVisible)
                            SquigglyColor = Color.Yellow;
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.Yellow;
                        if (IsInkBarVisible)
                            InkColor = Color.Yellow;
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.Yellow;
                        if (IsEditRectangleAnnotationBarVisible)
                            RectangleDeleteColor = Color.Yellow;
                        if (IsEditCircleAnnotationBarVisible)
                            CircleDeleteColor = Color.Yellow;
                        if (IsEditLineAnnotationBarVisible)
                            LineDeleteColor = Color.Yellow;
                        if (IsEditArrowAnnotationBarVisible)
                            ArrowDeleteColor = Color.Yellow;
                        if (IsEditPolygonAnnotationBarVisible || IsEditCloudAnnotationBarVisible)
                            PolygonDeleteColor = CloudDeleteColor = Color.Yellow;
                        if (IsEditPolylineAnnotationBarVisible)
                            PolylineDeleteColor = Color.Yellow;
                        if (IsEditTextColorBarVisible || IsEditTextAnnotationBarVisible)
                            EditTextColor = Color.Yellow;
                        if ( IsEditFreeTextAnnotationBarVisible )
                            EditTextDeleteColor = Color.Yellow;
                        if (IsRectangleBarVisible)
                            RectangleStrokeColor = Color.Yellow;
                        if (IsCircleBarVisible)
                            CircleStrokeColor = Color.Yellow;
                        if (IsLineBarVisible)
                            LineStrokeColor = Color.Yellow;
                        if (IsArrowBarVisible)
                            ArrowStrokeColor = Color.Yellow;
                        if (IsPolygonBarVisible || IsCloudBarVisible)
                            PolygonStrokeColor = CloudStrokeColor = Color.Yellow;
                        if (IsPolylineBarVisible)
                            PolylineStrokeColor = Color.Yellow;
                        if (IsPopupBarVisible)
                            PopupColor = Color.Yellow;
                        if (IsEditPopupAnnotationBarVisible)
                            PopupDeleteColor = Color.Yellow;
                    }
                    break;

                case "Magenta":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.FromHex("#FF00FF");
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.FromHex("#FF00FF");
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.FromHex("#FF00FF");
                        if (IsSquigglyBarVisible)
                            SquigglyColor = Color.FromHex("#FF00FF");
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.FromHex("#FF00FF");
                        if (IsInkBarVisible)
                            InkColor = Color.FromHex("#FF00FF");
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.FromHex("#FF00FF");
                        if (IsEditRectangleAnnotationBarVisible)
                            RectangleDeleteColor = Color.FromHex("#FF00FF");
                        if (IsEditCircleAnnotationBarVisible)
                            CircleDeleteColor = Color.FromHex("#FF00FF");
                        if (IsEditLineAnnotationBarVisible)
                            LineDeleteColor = Color.FromHex("#FF00FF");
                        if (IsEditFreeTextAnnotationBarVisible )
                            EditTextDeleteColor = Color.FromHex("#FF00FF");                      
                        if (IsEditArrowAnnotationBarVisible)
                            ArrowDeleteColor = Color.FromHex("#FF00FF");
                        if (IsEditPolygonAnnotationBarVisible || IsEditCloudAnnotationBarVisible)
                            PolygonDeleteColor = CloudDeleteColor = Color.FromHex("FF00FF");
                        if (IsEditPolylineAnnotationBarVisible)
                            PolylineDeleteColor = Color.FromHex("FF00FF");
                        if (IsEditTextColorBarVisible || IsEditTextAnnotationBarVisible)
                            EditTextColor = Color.FromHex("FF00FF");
                        if (IsRectangleBarVisible)
                            RectangleStrokeColor =Color.FromHex("FF00FF");
                        if (IsCircleBarVisible)
                            CircleStrokeColor =Color.FromHex("FF00FF");
                        if (IsLineBarVisible)
                            LineStrokeColor =Color.FromHex("FF00FF");
                        if (IsArrowBarVisible)
                            ArrowStrokeColor =Color.FromHex("FF00FF");
                        if (IsPolygonBarVisible || IsCloudBarVisible)
                            PolygonStrokeColor = CloudStrokeColor = Color.FromHex("FF00FF");
                        if (IsPolylineBarVisible)
                            PolylineStrokeColor = Color.FromHex("FF00FF");
                        if (IsPopupBarVisible)
                            PopupColor = Color.FromHex("FF00FF");
                        if (IsEditPopupAnnotationBarVisible)
                            PopupDeleteColor = Color.FromHex("FF00FF");
                    }
                    break;

                case "Black":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.Black;
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.Black;
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.Black;
                        if (IsSquigglyBarVisible)
                            SquigglyColor = Color.Black;
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.Black;
                        if (IsInkBarVisible)
                            InkColor = Color.Black;
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.Black;
                        if (IsEditRectangleAnnotationBarVisible)
                            RectangleDeleteColor = Color.Black;
                        if (IsEditCircleAnnotationBarVisible)
                            CircleDeleteColor = Color.Black;
                        if (IsEditLineAnnotationBarVisible)
                            LineDeleteColor = Color.Black;
                        if (IsEditFreeTextAnnotationBarVisible)
                            EditTextDeleteColor = Color.Black;
                        if (IsEditArrowAnnotationBarVisible)
                            ArrowDeleteColor = Color.Black;
                        if (IsEditPolygonAnnotationBarVisible || IsEditCloudAnnotationBarVisible)
                            PolygonDeleteColor = CloudDeleteColor = Color.Black;
                        if (IsEditPolylineAnnotationBarVisible)
                            PolylineDeleteColor = Color.Black;
                        if (IsEditTextColorBarVisible || IsEditTextAnnotationBarVisible)
                            EditTextColor = Color.Black;
                        if (IsRectangleBarVisible)
                            RectangleStrokeColor = Color.Black;
                        if (IsCircleBarVisible)
                            CircleStrokeColor = Color.Black;
                        if (IsLineBarVisible)
                            LineStrokeColor = Color.Black;
                        if (IsArrowBarVisible)
                            ArrowStrokeColor = Color.Black;
                        if (IsPolygonBarVisible || IsCloudBarVisible)
                            PolygonStrokeColor = CloudStrokeColor = Color.Black;
                        if (IsPolylineBarVisible)
                            PolylineStrokeColor = Color.Black;
                        if (IsPopupBarVisible)
                            PopupColor = Color.Black;
                        if (IsEditPopupAnnotationBarVisible)
                            PopupDeleteColor = Color.Black;
                    }
                    break;

                case "White":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.White;
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.White;
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.White;
                        if (IsSquigglyBarVisible)
                            SquigglyColor = Color.White;
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.White;
                        if (IsInkBarVisible)
                            InkColor = Color.White;
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.White;
                        if (IsEditRectangleAnnotationBarVisible)
                            RectangleDeleteColor = Color.White;
                        if (IsEditCircleAnnotationBarVisible)
                            CircleDeleteColor = Color.White;
                        if (IsEditLineAnnotationBarVisible)
                            LineDeleteColor = Color.White;
                        if (IsEditFreeTextAnnotationBarVisible)
                            EditTextDeleteColor = Color.White;
                        if (IsEditArrowAnnotationBarVisible)
                            ArrowDeleteColor = Color.White;
                        if (IsEditPolygonAnnotationBarVisible || IsEditCloudAnnotationBarVisible)
                            PolygonDeleteColor = CloudDeleteColor = Color.White;
                        if (IsEditPolylineAnnotationBarVisible)
                            PolylineDeleteColor = Color.White;
                        if (IsEditTextColorBarVisible || IsEditTextAnnotationBarVisible)
                            EditTextColor = Color.White;
                        if (IsRectangleBarVisible)
                            RectangleStrokeColor = Color.White;
                        if (IsCircleBarVisible)
                            CircleStrokeColor = Color.White;
                        if (IsLineBarVisible)
                            LineStrokeColor = Color.White;
                        if (IsArrowBarVisible)
                            ArrowStrokeColor = Color.White;
                        if (IsPolygonBarVisible || IsCloudBarVisible)
                            PolygonStrokeColor = CloudStrokeColor = Color.White;
                        if (IsPolylineBarVisible)
                            PolylineStrokeColor = Color.White;
                        if (IsPopupBarVisible)
                            PopupColor = Color.White;
                        if (IsEditPopupAnnotationBarVisible)
                            PopupDeleteColor = Color.White;
                    }
                    break;

            }
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            IsShapeColorBarVisible = false;
            IsInkColorBarVisible = false;
            IsOpacityBarVisible = false;
            IsMoreOptionsToolBarVisible = false;
            //IsEditInkBarVisible = false;
            //IsInkBarVisible = false;
            //IsRectangleBarVisible = false;
            //IsCircleBarVisible = false;
            //IsArrowBarVisible = false;
            //IsLineBarVisible = false;
        }

    }

}

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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.SfPdfViewer.Android;
using System.IO;
using System.Reflection;
using Android.Views.InputMethods;
using System.Diagnostics;
using static Android.Views.ViewGroup;
using Android.Graphics;
using Com.Syncfusion.Sfrangeslider;
using Syncfusion.Pdf.Parsing;
using Android.Util;
using Android.Graphics.Drawables;
using Syncfusion.Android.PopupLayout;
using Android.Text.Method;
using Android.Content.Res;
using Syncfusion.Pdf;

namespace SampleBrowser
{
    [Activity(ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class CustomToolBarPdfViewerDemo : SamplePage
    {
        internal SfPdfViewer pdfViewerControl;
        EditText pageNumberEntry;
        TextView pageCountText;
        LinearLayout mainView;
        internal FrameLayout m_topToolbars;
        internal LinearLayout m_bottomToolbars;
        LinearLayout toolBarGrid;
        GridLayout bottomtoolBarGrid;
        LinearLayout annotationBarGrid;
        GridLayout annotationBackGrid;
        GridLayout searchBarGrid;
        LinearLayout annotationColorBarGrid;
        EditText searchView;
        Button searchButton;
        Button bookmarkButton;
        Button viewModeButton;
        Button stampButton;
        Button backButton;
        Button clearSearchButton;
        Context pdfViewerContext;
        Button selectionButton;
        string backupDocumentName = string.Empty;
        Button annotationModeButton;
        Button highlightModeButton;
        Button underlineModeButton;
        Button strikeoutModeButton;
        Button annotationBackButton;
        Button annotationColorButton;
        internal bool m_isAnnotationModeSelected;
        internal bool isLoadedDocument = false;
        Button cyancolorButton;
        Button yellowcolorButton;
        Button greencolorButton;
        Button magentacolorButton;
        Button whitecolorButton;
        Button blackcolorButton;
        Button removeButton;
        Button undoButton;
        Button redoButton;
        Button saveButton;
        TextMarkupAnnotation annotation;
        FrameLayout annotationToolBar;
        Button annotationButton;
        internal Color fontColor;
        float textSize = 27;
        float viewModeTextSize = 22;
        FrameLayout annotationsToolbar;
        LinearLayout annotationsGrid;
        Button TextMarkupAnnotationButton;
        Button ShapeAnnotationButton;
        Button InkAnnotationButton;
        FrameLayout inkannotationtoolbar;
        GridLayout inkannotationgrid;
        Button inkundobutton;
        Button inkredobutton;
        Button inkannotationbackbutton;
        FrameLayout inkannotationbottomtoolbar;
        GridLayout inkannotationbottomgrid;
        Button inkannotationThicknessButton;
        Button inkAnnotationColorButton;
        FrameLayout inkannotationthicknessToolbar;
        GridLayout inkannotationthicknessGrid;
        LinearLayout lineView1;
        FrameLayout annotationbottomcolortoolbar;
        Button opacityButton;
        Button inkBackButton;
        Button inkButton;
        internal int currentColorPosition;
        FrameLayout inkannotationbottomopacitytoolbar;
        ImageButton lineFive1;
        ImageButton lineFour1;
        ImageButton lineOne1;
        LinearLayout linesLayout1;
        ImageButton lineThree1;
        ImageButton lineTwo1;
        private ImageButton lineOneContainer1;
        private ImageButton lineTwoContainer1;
        private ImageButton lineThreeContainer1;
        private ImageButton lineFourContainer1;
        private ImageButton lineFiveContainer1;
        SeekBar seekbar1;
        InkAnnotation inkannot;
        HandwrittenSignature signature;
        bool m_opacityChanged;
        Button textmarkupannotationBackButton;
        Button inkremovebutton;
        TextView endprogressLabel;
        bool m_thicknessChanged;
        FrameLayout m_shapeAnnoationToolbar;
        internal LinearLayout m_rangeSliderView;
        private TextView m_rangeSliderText;
        internal Com.Syncfusion.Sfrangeslider.SfRangeSlider m_rangeSlider;
        private string fontValue;
        internal BookmarkToolbar bookmarkToolbar;
        internal StampSelectionView stampSelectionView;
        internal bool isBookmarkVisible;
        MainViewLayoutListener layoutListener;
        internal FrameLayout bookmarkToolbarParentLayout;
        private Button signaturePadButton;
		internal PopupWindow popup;
        internal bool disableToolbar;
        internal bool enableToolbar;
        internal Stream PdfStream = null;
        internal SfPopupLayout initialPopup;
        internal TextView titleText;
        internal EditText editText;
        internal LinearLayout footerLinear;
        internal LinearLayout headerLinear;
        internal int i = 0;
        internal Button acceptButton;
        internal Button declineButton;
        internal TextView errorView;
        internal ScreenSize screenSize;
        public override View GetSampleContent(Context context)
        {

            m_context = context;
            layoutListener = new MainViewLayoutListener();
            fontColor = new Color(0, 118, 255);
            font = Typeface.CreateFromAsset(context.Assets, "PDFViewer_Android.ttf");
            fontSizeFont = Typeface.CreateFromAsset(context.Assets, "Font size Font.ttf");
            bookmarkFont = Typeface.CreateFromAsset(context.Assets, "PdfViewer_FONT.ttf");
            viewModeFont = Typeface.CreateFromAsset(context.Assets, "Android Page icons.ttf");
            stampFont = Typeface.CreateFromAsset(context.Assets, "Font Text edit stamp.ttf");
            signatureFont = Typeface.CreateFromAsset(context.Assets, "Signature_PDFViewer_FONT.ttf");
            LayoutInflater layoutInflater = LayoutInflater.From(context);
            pdfViewerContext = context;
            mainView = (LinearLayout)layoutInflater.Inflate(Resource.Layout.CustomToolbarPDFViewer, null);
			//The FrameLayout on which the bookmark toolbar will be added for tablet. 
            bookmarkToolbarParentLayout = (FrameLayout)mainView.FindViewById<FrameLayout>(Resource.Id.bookmarkParent);
            mainView.AddOnLayoutChangeListener(layoutListener);
            m_topToolbars = (FrameLayout)mainView.FindViewById(Resource.Id.top);
            m_bottomToolbars = (LinearLayout)mainView.FindViewById(Resource.Id.bottom);
            pageNumberEntry = (EditText)mainView.FindViewById(Resource.Id.pagenumberentry1);
            pageNumberEntry.KeyPress += PageNumberEntry_KeyPress;
            pageCountText = (TextView)mainView.FindViewById(Resource.Id.pagecounttext1);
            searchButton = mainView.FindViewById<Button>(Resource.Id.searchButton);
            searchButton.Typeface = font;
            bookmarkButton = mainView.FindViewById<Button>(Resource.Id.bookmarkbutton);
            bookmarkButton.Typeface = bookmarkFont;
            bookmarkButton.TextSize = textSize;
            bookmarkButton.SetTextColor(fontColor);
            bookmarkButton.Click += BookmarkButton_Click;
            viewModeButton = mainView.FindViewById<Button>(Resource.Id.viewmodebutton);
            viewModeButton.Typeface = viewModeFont;
            viewModeButton.TextSize = viewModeTextSize;
            viewModeButton.SetTextColor(fontColor);
            viewModeButton.Click += ViewModeButton_Click;
            stampButton = mainView.FindViewById<Button>(Resource.Id.stampButton);
            stampButton.Typeface = stampFont;
            stampButton.TextSize = textSize;
            stampButton.SetTextColor(fontColor);
            stampButton.Click += StampButton_Click;
            searchButton.SetTextColor(fontColor);
            searchButton.TextSize = textSize;
            searchButton.Click += SearchButton_Click;
            saveButton = mainView.FindViewById<Button>(Resource.Id.savebutton);
            saveButton.Typeface = font;
            saveButton.TextSize = textSize;
            saveButton.SetTextColor(fontColor);
            saveButton.Click += SaveButton_Click;
            undoButton = mainView.FindViewById<Button>(Resource.Id.undobutton);
            undoButton.Typeface = font;
            undoButton.TextSize = textSize;
            undoButton.SetTextColor(Color.Gray);
            undoButton.Click += UndoButton_Click;
            redoButton = mainView.FindViewById<Button>(Resource.Id.redobutton);
            redoButton.SetTextColor(Color.Gray);
            redoButton.Typeface = font;
            redoButton.TextSize = textSize;
            redoButton.Click += RedoButton_Click;
            removeButton = mainView.FindViewById<Button>(Resource.Id.removebutton);
            removeButton.Typeface = font;
            removeButton.SetTextColor(fontColor);
            removeButton.TextSize = textSize;
            removeButton.Click += RemoveButton_Click;
            annotationModeButton = (Button)mainView.FindViewById(Resource.Id.annotationbutton);
            annotationModeButton.Typeface = font;
            annotationModeButton.SetTextColor(fontColor);
            annotationModeButton.TextSize = textSize;
            annotationModeButton.Click += AnnotationModeButton_Click;
            pdfViewerControl = (SfPdfViewer)mainView.FindViewById(Resource.Id.pdfviewercontrol);
            pdfViewerControl.DocumentLoaded += PdfViewerControl_DocumentLoaded;
            pdfViewerControl.PageChanged += PdfViewerControl_PageChanged;
            backupDocumentName = "F# Succinctly";
            Stream docStream = typeof(PdfViewerDemo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets." + backupDocumentName + ".pdf");
            annotationToolBar = mainView.FindViewById<FrameLayout>(Resource.Id.annotationtoolbar);
            annotationToolBar.Visibility = ViewStates.Gone;
            toolBarGrid = mainView.FindViewById<LinearLayout>(Resource.Id.toolbarGrid);
            toolBarGrid.Visibility = ViewStates.Visible;
            bottomtoolBarGrid = mainView.FindViewById<GridLayout>(Resource.Id.bottomtoolbarGrid);
            bottomtoolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid = mainView.FindViewById<GridLayout>(Resource.Id.searchGrid);
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationBarGrid = mainView.FindViewById<LinearLayout>(Resource.Id.annotationgrid);
            annotationBarGrid.Visibility = ViewStates.Invisible;
            m_shapeAnnoationToolbar = mainView.FindViewById<FrameLayout>(Resource.Id.shapeannotationtoolbar);
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            shapeAnnotationBarGrid = mainView.FindViewById<LinearLayout>(Resource.Id.shapeannotationgrid);
            shapeAnnotationBarGrid.Visibility = ViewStates.Invisible;
            shapeAnnotationBarGrid.Visibility = ViewStates.Invisible;
            annotationBackGrid = mainView.FindViewById<GridLayout>(Resource.Id.annotationbackgrid);
            annotationBackGrid.Visibility = ViewStates.Invisible;
            annotationColorBarGrid = mainView.FindViewById<LinearLayout>(Resource.Id.selectedannotationcolorchangedGrid);
            annotationColorBarGrid.Visibility = ViewStates.Invisible;
            backButton = mainView.FindViewById<Button>(Resource.Id.backButton);
            backButton.Typeface = font;
            backButton.SetTextColor(fontColor);
            backButton.TextSize = textSize;
            highlightModeButton = (Button)mainView.FindViewById(Resource.Id.highlightbtn);
            highlightModeButton.Typeface = font;
            highlightModeButton.SetTextColor(fontColor);
            highlightModeButton.TextSize = textSize;
            highlightModeButton.Click += HighlightModeButton_Click;
            underlineModeButton = (Button)mainView.FindViewById(Resource.Id.underlinebtn);
            underlineModeButton.Typeface = font;
            underlineModeButton.SetTextColor(fontColor);
            underlineModeButton.TextSize = textSize;
            underlineModeButton.Click += UnderlineModeButton_Click;
            strikeoutModeButton = (Button)mainView.FindViewById(Resource.Id.strikeoutbutton);
            strikeoutModeButton.Typeface = font;
            strikeoutModeButton.SetTextColor(fontColor);
            strikeoutModeButton.TextSize = textSize;
            strikeoutModeButton.Click += StrikeoutModeButton_Click;

            annotationBackButton = (Button)mainView.FindViewById(Resource.Id.annotationbackbutton);
            annotationBackButton.Typeface = font;
            annotationBackButton.SetTextColor(fontColor);
            annotationBackButton.TextSize = textSize;
            annotationBackButton.Click += AnnotationBackButton_Click;
            annotationColorButton = (Button)mainView.FindViewById(Resource.Id.annotationcolorbutton);
            annotationColorButton.Click += AnnotationColorButton_Click;
            annotationButton = (Button)mainView.FindViewById(Resource.Id.annotationbtn);
            annotationButton.Typeface = font;
            annotationButton.SetTextColor(fontColor);
            annotationButton.TextSize = textSize;
            cyancolorButton = (Button)mainView.FindViewById(Resource.Id.cyanbutton);
            cyancolorButton.Click += CyancolorButton_Click;
            yellowcolorButton = (Button)mainView.FindViewById(Resource.Id.yellowbutton);
            yellowcolorButton.Click += YellowcolorButton_Click;
            greencolorButton = (Button)mainView.FindViewById(Resource.Id.greenbutton);
            greencolorButton.Click += GreencolorButton_Click;
            magentacolorButton = (Button)mainView.FindViewById(Resource.Id.magentabutton);
            magentacolorButton.Click += MagentacolorButton_Click;
            whitecolorButton = (Button)mainView.FindViewById(Resource.Id.whitebutton);
            whitecolorButton.Click += WhitecolorButton_Click;
            blackcolorButton = (Button)mainView.FindViewById(Resource.Id.blackbutton);
            blackcolorButton.Click += BlackcolorButton_Click;
            backButton.Click += BackButton_Click;
            searchView = mainView.FindViewById<EditText>(Resource.Id.search);
            searchView.SetHintTextColor(Android.Graphics.Color.Rgb(189, 189, 189));
            searchView.Hint = "Search text";
            searchView.FocusableInTouchMode = true;
            searchView.TextSize = 18;
            searchView.SetTextColor(Android.Graphics.Color.Rgb(103, 103, 103));
            searchView.TextAlignment = TextAlignment.Center;
            searchView.KeyPress += SearchView_KeyPress;
            searchView.TextChanged += SearchView_TextChanged;
            selectionButton = mainView.FindViewById<Button>(Resource.Id.selectDocumentButton);
            selectionButton.Typeface = font;
            selectionButton.SetTextColor(fontColor);
            selectionButton.TextSize = textSize;
            selectionButton.Click += SelectionButton_Click;
            clearSearchButton = mainView.FindViewById<Button>(Resource.Id.clearSearchResult);
            clearSearchButton.Typeface = font;
            clearSearchButton.SetTextColor(fontColor);
            clearSearchButton.TextSize = textSize;
            clearSearchButton.Click += ClearSearchButton_Click;
            annotationsGrid = (LinearLayout)mainView.FindViewById(Resource.Id.annotationsgrid);
            annotationsGrid.Visibility = ViewStates.Gone;
            annotationsToolbar = (FrameLayout)mainView.FindViewById(Resource.Id.annotationstoolbar);
            annotationsToolbar.Visibility = ViewStates.Gone;
            TextMarkupAnnotationButton = (Button)mainView.FindViewById(Resource.Id.textmarkupannotationButton);
            TextMarkupAnnotationButton.Typeface = font;
            TextMarkupAnnotationButton.SetTextColor(fontColor);
            TextMarkupAnnotationButton.TextSize = textSize;
            TextMarkupAnnotationButton.Click += TextMarkupAnnotationButton_Click;
            ShapeAnnotationButton = (Button)mainView.FindViewById(Resource.Id.shapeannotationButton);
            ShapeAnnotationButton.Typeface = font;
            ShapeAnnotationButton.SetTextColor(fontColor);
            ShapeAnnotationButton.TextSize = textSize;
            ShapeAnnotationButton.Click += ShapeAnnotationButton_Click;
            InkAnnotationButton = (Button)mainView.FindViewById(Resource.Id.inkannotationButton);
            InkAnnotationButton.Typeface = font;
            InkAnnotationButton.SetTextColor(fontColor);
            InkAnnotationButton.TextSize = textSize;
            InkAnnotationButton.Click += InkAnnotationButton_Click;
            TextAnnotationButton = (Button)mainView.FindViewById(Resource.Id.editannotationButton);
            TextAnnotationButton.Typeface = font;
            TextAnnotationButton.SetTextColor(fontColor);
            TextAnnotationButton.Text = "\uE71f";
            TextAnnotationButton.TextSize = textSize;
            TextAnnotationButton.Click += TextAnnotationButton_Click;

            signaturePadButton = (Button)mainView.FindViewById(Resource.Id.signButton);
            signaturePadButton.Typeface = signatureFont;            
            signaturePadButton.SetTextColor(fontColor);
            signaturePadButton.TextSize = textSize;
            signaturePadButton.Click += SignaturePadButton_Click;

            shapeannotationBackButton = (Button)mainView.FindViewById(Resource.Id.shapeannotationBackButton);
            shapeannotationBackButton.Typeface = font;
            shapeannotationBackButton.SetTextColor(fontColor);
            shapeannotationBackButton.TextSize = textSize;
            shapeannotationBackButton.Click += ShapeannotationBackButton_Click;

            rectangleModeButton = (Button)mainView.FindViewById(Resource.Id.rectanglebtn);
            rectangleModeButton.Typeface = font;
            rectangleModeButton.SetTextColor(fontColor);
            rectangleModeButton.TextSize = textSize;
            rectangleModeButton.Click += RectangleModeButton_Click;

            circleModeButton = (Button)mainView.FindViewById(Resource.Id.circlebtn);
            circleModeButton.Typeface = font;
            circleModeButton.SetTextColor(fontColor);
            circleModeButton.TextSize = textSize;
            circleModeButton.Click += CircleModeButton_Click;

            lineModeButton = (Button)mainView.FindViewById(Resource.Id.linebutton);
            lineModeButton.Typeface = font;
            lineModeButton.SetTextColor(fontColor);
            lineModeButton.TextSize = textSize;
            lineModeButton.Click += LineModeButton_Click;

            arrowModeButton = (Button)mainView.FindViewById(Resource.Id.arrowbutton);
            arrowModeButton.Typeface = font;
            arrowModeButton.SetTextColor(fontColor);
            arrowModeButton.TextSize = textSize;
            arrowModeButton.Click += ArrowModeButton_Click;

            inkannotationgrid = (GridLayout)mainView.FindViewById(Resource.Id.inkannotationgrid);
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar = (FrameLayout)mainView.FindViewById(Resource.Id.inkannotationtoolbar);
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkundobutton = (Button)mainView.FindViewById(Resource.Id.inkundobutton1);
            inkundobutton.Typeface = font;
            inkundobutton.TextSize = textSize;
            inkundobutton.SetTextColor(Color.Gray);
            inkundobutton.Click += Inkundobutton_Click;
            inkredobutton = (Button)mainView.FindViewById(Resource.Id.inkredobutton1);
            inkredobutton.Typeface = font;
            inkredobutton.TextSize = textSize;
            inkredobutton.SetTextColor(Color.Gray);
            inkredobutton.Click += Inkredobutton_Click;
            inkannotationbackbutton = (Button)mainView.FindViewById(Resource.Id.inkannotationbackbutton);
            inkannotationbackbutton.Typeface = font;
            inkannotationbackbutton.SetTextColor(fontColor);
            inkannotationbackbutton.TextSize = textSize;
            inkannotationbackbutton.Click += Inkannotationbackbutton_Click;

            inkannotationbottomgrid = (GridLayout)mainView.FindViewById(Resource.Id.inkannotationbottomgrid);
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar = (FrameLayout)mainView.FindViewById(Resource.Id.inkannotationbottomtoolbar);
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            inkannotationThicknessButton = (Button)mainView.FindViewById(Resource.Id.inkannotationThicknessButton);
            inkannotationThicknessButton.Typeface = font;
            inkannotationThicknessButton.TextSize = textSize;
            inkannotationThicknessButton.Click += InkannotationThicknessButton_Click;
            inkAnnotationColorButton = (Button)mainView.FindViewById(Resource.Id.inkAnnotationColorButton);
            inkAnnotationColorButton.Click += InkAnnotationColorButton_Click;

            inkannotationthicknessToolbar = (FrameLayout)mainView.FindViewById(Resource.Id.inkannotationthicknessToolbar);
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid = (GridLayout)mainView.FindViewById(Resource.Id.inkannotationthicknessGrid);
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;

            lineView1 = (LinearLayout)mainView.FindViewById(Resource.Id.lines1);
            lineView1.Visibility = ViewStates.Gone;

            annotationbottomcolortoolbar = (FrameLayout)mainView.FindViewById(Resource.Id.annotationbottomcolortoolbar);
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;

            opacityButton = (Button)mainView.FindViewById(Resource.Id.opacitybtn);
            opacityButton.Visibility = ViewStates.Gone;
            opacityButton.Typeface = font;         
            opacityButton.TextSize = textSize;
            opacityButton.Click += OpacityButton_Click;

            inkannotationbottomopacitytoolbar = (FrameLayout)mainView.FindViewById(Resource.Id.inkannotationbottomopacitytoolbar);
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;

            inkBackButton = (Button)mainView.FindViewById(Resource.Id.inkBackButton);
            inkBackButton.Visibility = ViewStates.Gone;
            inkBackButton.Typeface = font;
            inkBackButton.SetTextColor(fontColor);
            inkBackButton.TextSize = textSize;
            inkBackButton.Click += InkBackButton_Click;

            inkButton = (Button)mainView.FindViewById(Resource.Id.inkButton);
            inkButton.Visibility = ViewStates.Gone;
            inkButton.Typeface = font;
            inkButton.SetTextColor(fontColor);
            inkButton.TextSize = textSize;


            textmarkupannotationBackButton = (Button)mainView.FindViewById(Resource.Id.textmarkupannotationBackButton);
            textmarkupannotationBackButton.Typeface = font;
            textmarkupannotationBackButton.SetTextColor(fontColor);
            textmarkupannotationBackButton.TextSize = textSize;
            textmarkupannotationBackButton.Click += TextmarkupannotationBackButton_Click;

            inkremovebutton = (Button)mainView.FindViewById(Resource.Id.inkremovebutton);
            inkremovebutton.Typeface = font;
            inkremovebutton.Visibility = ViewStates.Gone;
            inkremovebutton.SetTextColor(fontColor);
            inkremovebutton.TextSize = textSize;
            inkremovebutton.Click += Inkremovebutton_Click;

            m_editTextAnntationButton=(Button)mainView.FindViewById(Resource.Id.edittextannotationButton);
            m_editTextAnntationButton.Typeface = font;
            m_editTextAnntationButton.Visibility = ViewStates.Gone;
            m_editTextAnntationButton.SetTextColor(fontColor);
            m_editTextAnntationButton.TextSize = textSize;
            m_editTextAnntationButton.Click += M_editTextAnntationButton_Click;

            linesLayout1 = (LinearLayout)mainView.FindViewById(Resource.Id.lines1);
            m_rangeandThicknessFrame = (FrameLayout)mainView.FindViewById(Resource.Id.thicknessrange);
            m_rangeSliderView = (LinearLayout)mainView.FindViewById(Resource.Id.rangeslider);
            linesLayoutGrid = (LinearLayout)mainView.FindViewById(Resource.Id.linesGrid);
            linesLayout1.Visibility = ViewStates.Gone;
            lineOneContainer1 = (ImageButton)mainView.FindViewById(Resource.Id.lineonecontainer1);
            lineOneContainer1.Tag = 0;
            lineOne1 = (ImageButton)mainView.FindViewById(Resource.Id.lineone1);
            lineOne1.Tag = 0;
            lineOne1.Click += ThickLinesClick;
            lineOneContainer1.Click += ThickContainerClick;
            lineTwoContainer1 = (ImageButton)mainView.FindViewById(Resource.Id.linetwocontainer1);
            lineTwoContainer1.Tag = 1;
            lineTwo1 = (ImageButton)mainView.FindViewById(Resource.Id.linetwo1);
            lineTwo1.Tag = 1;
            lineTwo1.Click += ThickLinesClick;
            lineTwoContainer1.Click += ThickLinesClick;
            lineThreeContainer1 = (ImageButton)mainView.FindViewById(Resource.Id.linethreecontainer1);
            lineThreeContainer1.Tag = 2;
            lineThree1 = (ImageButton)mainView.FindViewById(Resource.Id.linethree1);
            lineThree1.Tag = 2;
            lineThree1.Click += ThickLinesClick;
            lineThreeContainer1.Click += ThickContainerClick;
            lineFourContainer1 = (ImageButton)mainView.FindViewById(Resource.Id.linefourcontainer1);
            lineFourContainer1.Tag = 3;
            lineFour1 = (ImageButton)mainView.FindViewById(Resource.Id.linefour1);
            lineFour1.Tag = 3;
            lineFour1.Click += ThickLinesClick;
            lineFourContainer1.Click += ThickContainerClick;
            lineFiveContainer1 = (ImageButton)mainView.FindViewById(Resource.Id.linefivecontainer1);
            lineFiveContainer1.Tag = 4;
            lineFive1 = (ImageButton)mainView.FindViewById(Resource.Id.linefive1);
            lineFive1.Tag = 4;
            lineFive1.Click += ThickLinesClick;
            lineFiveContainer1.Click += ThickContainerClick;
            InitialializeRangeSlider();

            seekbar1 = (SeekBar)mainView.FindViewById(Resource.Id.seekbar1);
            seekbar1.StopTrackingTouch += Seekbar_StopTrackingTouch;
            seekbar1.ProgressChanged += Seekbar_ProgressChanged;
            endprogressLabel = (TextView)mainView.FindViewById(Resource.Id.endprogress);
            pdfViewerControl.Toolbar.Enabled = false;
            pdfViewerControl.IsPasswordViewEnabled = false;
            pdfViewerControl.PreserveSignaturePadOrientation = true;
            pdfViewerControl.FreeTextAnnotationAdded += PdfViewerControl_FreeTextAnnotationAdded;
            pdfViewerControl.FreeTextAnnotationSelected += PdfViewerControl_FreeTextAnnotationSelected;
            pdfViewerControl.FreeTextAnnotationDeselected += PdfViewerControl_FreeTextAnnotationDeselected;
            pdfViewerControl.ShapeAnnotationSelected += PdfViewerControl_ShapeAnnotationSelected;
            pdfViewerControl.ShapeAnnotationDeselected += PdfViewerControl_ShapeAnnotationDeselected;
            pdfViewerControl.InkDeselected += PdfViewerControl_InkDeselected; ;
            pdfViewerControl.InkSelected += PdfViewerControl_InkSelected;
            pdfViewerControl.CanUndoInkModified += PdfViewerControl_CanUndoInkModified;
            pdfViewerControl.CanRedoInkModified += PdfViewerControl_CanRedoInkModified;
            pdfViewerControl.TextMarkupSelected += PdfViewerControl_TextMarkupSelected;
            pdfViewerControl.TextMarkupDeselected += PdfViewerControl_TextMarkupDeselected;
            pdfViewerControl.StampAnnotationSelected += PdfViewerControl_StampAnnotationSelected;
            pdfViewerControl.StampAnnotationDeselected += PdfViewerControl_StampAnnotationDeselected;
            pdfViewerControl.CanRedoModified += PdfViewerControl_CanRedoModified;
            pdfViewerControl.CanUndoModified += PdfViewerControl_CanUndoModified;
            pdfViewerControl.FreeTextPopupAppearing += PdfViewerControl_FreeTextPopupAppearing;
            pdfViewerControl.FreeTextPopupDisappeared += PdfViewerControl_FreeTextPopupDisappeared;
            pdfViewerControl.PasswordErrorOccurred += PdfViewerControl_PasswordErrorOccurred;
            bookmarkToolbar = new BookmarkToolbar(m_context, this);
            bookmarkToolbar.bookmarkLoadedDocument = new PdfLoadedDocument(docStream);
			//Populate the ListView with the bookmark elements
            bookmarkToolbar.PopulateInitialBookmarkList();
            bookmarkToolbar.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            docStream.Position = 0;
            pdfViewerControl.LoadDocument(docStream);
            layoutListener.sampleView = this;
            screenSize = GetScreenSize();
            return mainView;
        }

        private void PdfViewerControl_PasswordErrorOccurred(object sender, PasswordErrorOccurredEventArgs e)
        {
            if (i == 0)
            {
                DisplayInitialPopup();
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(this.editText.WindowToken, HideSoftInputFlags.None);
                i++;
            }
            else
            {
                DisplayInitialPopup();
                errorView.Visibility = ViewStates.Visible;
            }
            isLoadedDocument = false;
        }

        private void ViewModeButton_Click(object sender, EventArgs e)
        {
            if (pdfViewerControl.PageViewMode == PageViewMode.Continuous)
            {
                pdfViewerControl.PageViewMode = PageViewMode.PageByPage;
                viewModeButton.Text = m_context.Resources.GetText(Resource.String.pdfviewer_icon_pagebypageviewmode);
            }
            else
            {
                pdfViewerControl.PageViewMode = PageViewMode.Continuous;
                viewModeButton.Text = m_context.Resources.GetText(Resource.String.pdfviewer_icon_continuousviewmode);
            }
        }

        private void PdfViewerControl_StampAnnotationDeselected(object sender, StampAnnotationDeselectedEventArgs args)
        {
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorButton.Visibility = ViewStates.Visible;
            annotationButton.Visibility = ViewStates.Gone;
            annotationBackButton.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;

            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            m_selectedStampAnnotation = null;
        }

        private void PdfViewerControl_StampAnnotationSelected(object sender, StampAnnotationSelectedEventArgs args)
        {
            m_shapeAnnot = null;
            inkannot = null;
            signature = null;
            m_freeTextAnnot = null;
            annotation = null;
            m_selectedStampAnnotation = sender as StampAnnotation;
            annotationToolBar.Visibility = ViewStates.Visible;
            annotationBackGrid.Visibility = ViewStates.Visible;
            removeButton.Visibility = ViewStates.Visible;
            annotationButton.Visibility = ViewStates.Gone;
            annotationBackButton.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;

            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            annotationColorButton.Visibility = ViewStates.Invisible;
        }

        private void StampButton_Click(object sender, EventArgs e)
        {
            if (stampSelectionView == null)
                stampSelectionView = new StampSelectionView(this.m_context, this);
            if(!IsDeviceTablet)
                mainView.AddView(stampSelectionView);
            else
            {
                Android.Util.Size screenSize = new Android.Util.Size(m_context.Resources.DisplayMetrics.WidthPixels, m_context.Resources.DisplayMetrics.HeightPixels);
                popup = new PopupWindow(stampSelectionView, screenSize.Width, screenSize.Height);
                Color color = Color.Black;
                color.A = (byte)100;
                popup.SetBackgroundDrawable(new ColorDrawable(color));
                popup.ShowAtLocation(mainView, GravityFlags.Center, 0, 0);
            }
            stampSelectionView.isShowing = true;
			m_topToolbars.Visibility = ViewStates.Invisible;
            m_bottomToolbars.Visibility = ViewStates.Invisible;
        }

        private void SignaturePadButton_Click(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.HandwrittenSignature;
        }
        //Returns a value which indicates whether the current device is a tablet. 
        internal bool IsDeviceTablet
        {
            get
            {
                DisplayMetrics m_displayMetrics = new DisplayMetrics();
                ((Activity)m_context).WindowManager.DefaultDisplay.GetMetrics(m_displayMetrics);
                double dispWidth = m_displayMetrics.WidthPixels / (double)m_displayMetrics.DensityDpi;
                double dispHeight = m_displayMetrics.HeightPixels / (double)m_displayMetrics.DensityDpi;
                return (Math.Sqrt(Math.Pow(dispWidth, 2) + Math.Pow(dispHeight, 2)) >= 7.0);
            }
        }

		//Expands the bookmark toolbar
        internal void ExpandBookmarkToolbar()
        {
            if (!isBookmarkVisible)
            {
                if (IsDeviceTablet)
                    this.bookmarkToolbarParentLayout.AddView(bookmarkToolbar);
                else
                {
                    this.mainView.AddView(bookmarkToolbar);
                    bookmarkToolbar.listAdapter.NotifyDataSetChanged();
                    m_topToolbars.Visibility = ViewStates.Invisible;
                    m_bottomToolbars.Visibility = ViewStates.Invisible;
                }
            }
            isBookmarkVisible = true;
        }

		//Collapses the bookmark toolbar. 
        internal void CollapseBookmarkToolbar()
        {
            if (isBookmarkVisible)
            {
                if (IsDeviceTablet)
                    this.bookmarkToolbarParentLayout.RemoveView(bookmarkToolbar);
                else
                {
                    this.mainView.RemoveView(bookmarkToolbar);
                    m_topToolbars.Visibility = ViewStates.Visible;
                    m_bottomToolbars.Visibility = ViewStates.Visible;
                }
            }
            isBookmarkVisible = false;
        }

        private void BookmarkButton_Click(object sender, EventArgs e)
        {
            if (isBookmarkVisible)
                CollapseBookmarkToolbar();
            else
            {
                ExpandBookmarkToolbar();
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationBarGrid.Visibility = ViewStates.Gone;
                annotationBackGrid.Visibility = ViewStates.Gone;
                annotationColorBarGrid.Visibility = ViewStates.Gone;
                annotationColorBarGrid.Visibility = ViewStates.Gone;
                annotationsToolbar.Visibility = ViewStates.Gone;
                annotationsGrid.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessGrid.Visibility = ViewStates.Gone;
                linesLayout1.Visibility = ViewStates.Gone;
                inkannotationtoolbar.Visibility = ViewStates.Gone;
                inkannotationgrid.Visibility = ViewStates.Gone;
                inkannotationbottomgrid.Visibility = ViewStates.Gone;
                inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
                toolBarGrid.Visibility = ViewStates.Visible;
                pdfViewerControl.AnnotationMode = AnnotationMode.None;
                opacityButton.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                lineView1.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                IsAnnotationModeSelected = false;
            }

        }

        private void PdfViewerControl_FreeTextPopupDisappeared(object sender, FreeTextPopupDisappearedEventArgs args)
        {
            if (m_topToolbars != null)
                m_topToolbars.Visibility = ViewStates.Visible;
            if (m_bottomToolbars != null)
                m_bottomToolbars.Visibility = ViewStates.Visible;
            if (pdfViewerControl.AnnotationMode==AnnotationMode.FreeText)
            {
                if(toolBarGrid!=null)
                toolBarGrid.Visibility = ViewStates.Visible;
                if(annotationsToolbar!=null)
                    annotationsToolbar.Visibility = ViewStates.Visible;
                if (bottomtoolBarGrid != null)
                    bottomtoolBarGrid.Visibility = ViewStates.Visible;
            }
          else
            {
                if (toolBarGrid != null)
                    toolBarGrid.Visibility = ViewStates.Visible;
                if (bottomtoolBarGrid!=null)
                  bottomtoolBarGrid.Visibility = ViewStates.Visible;
            }
        }

        private void PdfViewerControl_FreeTextPopupAppearing(object sender, FreeTextPopupAppearingEventArgs args)
        {
            InvisibleToolbars();
        }

        private void InvisibleToolbars()
        {
            //if(linesLayout1!=null)
            //linesLayout1.Visibility = ViewStates.Gone;
            //if(inkannotationtoolbar!=null)
            //inkannotationtoolbar.Visibility = ViewStates.Gone;
            //if (toolBarGrid != null)
            //    toolBarGrid.Visibility = ViewStates.Gone;
            //if (searchBarGrid != null)
            //    searchBarGrid.Visibility = ViewStates.Gone;
            if (m_topToolbars != null)
                m_topToolbars.Visibility = ViewStates.Gone;
            if (m_bottomToolbars != null)
                m_bottomToolbars.Visibility = ViewStates.Gone;

        }

        private void M_editTextAnntationButton_Click(object sender, EventArgs e)
        {
            pdfViewerControl.EditFreeTextAnnotation();
        }

        private void PdfViewerControl_FreeTextAnnotationAdded(object sender, FreeTextAnnotationAddedEventArgs args)
        {
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            shapeAnnotationBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Visible;
            annotationsGrid.Visibility = ViewStates.Visible;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Invisible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            m_rangeSliderView.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;

        }

        private void ShapeannotationBackButton_Click(object sender, EventArgs e)
        {
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Visible;
            annotationsGrid.Visibility = ViewStates.Visible;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Invisible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
        }

 
        private void InitialializeRangeSlider()
        {
            m_rangeSliderView.Orientation = Android.Widget.Orientation.Vertical;
            m_rangeSliderView.SetBackgroundColor(Color.ParseColor("#F6F6F6"));
            m_rangeSliderText = new TextView(m_context);
            m_rangeSliderText.Gravity = GravityFlags.Center | GravityFlags.CenterVertical;
            m_rangeSliderText.TextSize = 12;
            m_rangeSliderText.SetBackgroundColor(Color.ParseColor("#E9E9E9"));
            m_rangeSliderText.SetTextColor(Color.Black);
            LayoutParams m_rangeSliderTextParam = new LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
            m_rangeSliderText.LayoutParameters = m_rangeSliderTextParam;
            LayoutParams m_rangeSliderParam = new LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
            m_rangeSlider = new Com.Syncfusion.Sfrangeslider.SfRangeSlider(m_context);
            m_rangeSlider.SetBackgroundColor(Color.ParseColor("#E9E9E9"));
            fontValue = 12.ToString();
            m_rangeSlider.ShowValueLabel = false;
            m_rangeSlider.Minimum = 6;
            m_rangeSlider.Maximum = 22;
            m_rangeSlider.LayoutParameters = m_rangeSliderParam;
            m_rangeSlider.TickFrequency = 2;
            m_rangeSlider.StepFrequency = 2;
            m_rangeSlider.SnapsTo = Com.Syncfusion.Sfrangeslider.SnapsTo.Ticks;
            m_rangeSlider.ShowRange = false;
            m_rangeSlider.KnobColor = Color.ParseColor("#0076FF");
            m_rangeSlider.TrackSelectionColor = Color.ParseColor("#0076FF");
            m_rangeSlider.TickPlacement = Com.Syncfusion.Sfrangeslider.TickPlacement.Inline;
            m_rangeSlider.ToolTipPlacement = Com.Syncfusion.Sfrangeslider.ToolTipPlacement.None;
            m_rangeSlider.ValueChanged += m_rangeSlider_ValueChanged;
            m_rangeSliderText.Text = "Font: " + fontValue + " pt";
            m_rangeSliderView.AddView(m_rangeSliderText);
            m_rangeSliderView.AddView(m_rangeSlider);
        }

      

        private void m_rangeSlider_ValueChanged(object sender, Com.Syncfusion.Sfrangeslider.ValueChangedEventArgs e)
        {
            var value = (int)e.Value;
            fontValue = value.ToString();
            m_rangeSliderText.Text = "Font: " + fontValue + " pt";
            if (pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                pdfViewerControl.AnnotationSettings.FreeText.TextSize = (float)e.Value;
            if (m_freeTextAnnot != null)
                ((FreeTextAnnotation)m_freeTextAnnot).Settings.TextSize = (float)e.Value;
        }

        private void TextAnnotationButton_Click(object sender, EventArgs e)
        {
            var m_color = pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            m_color.A = (byte)255;
            inkAnnotationColorButton.SetBackgroundColor(m_color);
            pdfViewerControl.AnnotationMode = AnnotationMode.FreeText;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Visible;
            inkannotationgrid.Visibility = ViewStates.Visible;
            inkannotationbottomgrid.Visibility = ViewStates.Visible;
            inkannotationbottomtoolbar.Visibility = ViewStates.Visible;
            inkundobutton.Visibility = ViewStates.Invisible;
            inkredobutton.Visibility = ViewStates.Invisible;
            inkButton.Text = "\uE71f";
            inkButton.Visibility = ViewStates.Visible;
            inkBackButton.Visibility = ViewStates.Visible;
            inkremovebutton.Visibility = ViewStates.Gone;
            inkannotationThicknessButton.Typeface = fontSizeFont;
            inkannotationThicknessButton.Text = "\uE700";
            var m_colorbuttonbackground = pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            m_colorbuttonbackground.A = (byte)255;
            inkannotationThicknessButton.SetTextColor(m_colorbuttonbackground);
            opacityButton.Visibility = ViewStates.Invisible;
        }

        private void ArrowModeButton_Click(object sender, EventArgs e)
        {
            inkAnnotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor);
            pdfViewerControl.AnnotationMode = AnnotationMode.Arrow;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Visible;
            inkannotationgrid.Visibility = ViewStates.Visible;
            inkannotationbottomgrid.Visibility = ViewStates.Visible;
            inkannotationbottomtoolbar.Visibility = ViewStates.Visible;
            inkundobutton.Visibility = ViewStates.Invisible;
            inkredobutton.Visibility = ViewStates.Invisible;
            inkButton.Text = "\uE701";
            inkButton.Visibility = ViewStates.Visible;
            inkBackButton.Visibility = ViewStates.Visible;
            inkremovebutton.Visibility = ViewStates.Gone;
            inkannotationThicknessButton.Typeface = font;
            inkannotationThicknessButton.Text = "\uE722";
            var m_color = pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor;
            m_color.A = (byte)255;
            inkannotationThicknessButton.SetTextColor(m_color);
            opacityButton.Visibility = ViewStates.Visible;
        }

        private void LineModeButton_Click(object sender, EventArgs e)
        {
            var m_colorbuttonbackground = pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor;
            m_colorbuttonbackground.A = (byte)255;
            inkAnnotationColorButton.SetBackgroundColor(m_colorbuttonbackground);
            pdfViewerControl.AnnotationMode = AnnotationMode.Line;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Visible;
            inkannotationgrid.Visibility = ViewStates.Visible;
            inkannotationbottomgrid.Visibility = ViewStates.Visible;
            inkannotationbottomtoolbar.Visibility = ViewStates.Visible;
            inkundobutton.Visibility = ViewStates.Invisible;
            inkredobutton.Visibility = ViewStates.Invisible;
            inkButton.Text = "\uE703";
            inkButton.Visibility = ViewStates.Visible;
            inkBackButton.Visibility = ViewStates.Visible;
            inkremovebutton.Visibility = ViewStates.Gone;
            inkannotationThicknessButton.Typeface = font;
            inkannotationThicknessButton.Text = "\uE722";
            var m_color = pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor;
            m_color.A = (byte)255;
            inkannotationThicknessButton.SetTextColor(m_color);
            opacityButton.Visibility = ViewStates.Visible;
        }

        private void CircleModeButton_Click(object sender, EventArgs e)
        {
            var m_colorbuttonbackground = pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor;
            m_colorbuttonbackground.A = 255;
            inkAnnotationColorButton.SetBackgroundColor(m_colorbuttonbackground);
            pdfViewerControl.AnnotationMode = AnnotationMode.Circle;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Visible;
            inkannotationgrid.Visibility = ViewStates.Visible;
            inkannotationbottomgrid.Visibility = ViewStates.Visible;
            inkannotationbottomtoolbar.Visibility = ViewStates.Visible;
            inkundobutton.Visibility = ViewStates.Invisible;
            inkredobutton.Visibility = ViewStates.Invisible;
            inkButton.Text = "\uE714";
            inkButton.Visibility = ViewStates.Visible;
            inkBackButton.Visibility = ViewStates.Visible;
            inkremovebutton.Visibility = ViewStates.Gone;
            inkannotationThicknessButton.Typeface = font;
            inkannotationThicknessButton.Text = "\uE722";
            var m_color = pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor;
            m_color.A = (byte)255;
            inkannotationThicknessButton.SetTextColor(pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor);
            opacityButton.Visibility = ViewStates.Visible;
        }

        private void RectangleModeButton_Click(object sender, EventArgs e)
        {
            var m_colorbuttonbackground = pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor;
            m_colorbuttonbackground.A = (byte)255;
            inkAnnotationColorButton.SetBackgroundColor(m_colorbuttonbackground);
            pdfViewerControl.AnnotationMode = AnnotationMode.Rectangle;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Visible;
            inkannotationgrid.Visibility = ViewStates.Visible;
            inkannotationbottomgrid.Visibility = ViewStates.Visible;
            inkannotationbottomtoolbar.Visibility = ViewStates.Visible;
            inkundobutton.Visibility = ViewStates.Invisible;
            inkredobutton.Visibility = ViewStates.Invisible;
            inkButton.Text = "\uE710";
            inkButton.Visibility = ViewStates.Visible;
            inkBackButton.Visibility = ViewStates.Visible;
            inkremovebutton.Visibility = ViewStates.Gone;
            inkannotationThicknessButton.Typeface = font;
            inkannotationThicknessButton.Text = "\uE722";
            var m_color = pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor;
            m_color.A = (byte)255;
            inkannotationThicknessButton.SetTextColor(m_color);
            opacityButton.Visibility = ViewStates.Visible;
        }

        private void ShapeAnnotationButton_Click(object sender, EventArgs e)
        {
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Visible;
            shapeAnnotationBarGrid.Visibility = ViewStates.Visible;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Gone;
        }

        private bool ThicknessChanged
        {
            get
            {
                return m_thicknessChanged;
            }
            set
            {
                m_thicknessChanged = value;
            }
        }
        private void Seekbar_StopTrackingTouch(object sender, SeekBar.StopTrackingTouchEventArgs e)
        {
            double val = Math.Round((double)e.SeekBar.Progress / 100, 2);
            decimal dec = (decimal)val;
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                pdfViewerControl.AnnotationSettings.Ink.Opacity = (float)(dec);
              
            }
            if(pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                pdfViewerControl.AnnotationSettings.Rectangle.Settings.Opacity = (float)(dec);
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                pdfViewerControl.AnnotationSettings.Circle.Settings.Opacity = (float)(dec);
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                pdfViewerControl.AnnotationSettings.Line.Settings.Opacity = (float)(dec);
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                pdfViewerControl.AnnotationSettings.Arrow.Settings.Opacity = (float)(dec);
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkannot.Settings.Opacity = (float)(dec);
            }
            else if(pdfViewerControl.AnnotationMode == AnnotationMode.None && m_shapeAnnot != null)
            {
                m_shapeAnnot.Settings.Opacity = (float)(dec);
            }
            else if(pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature && signature != null)
            {
                signature.Settings.Opacity = (float)dec;
            }
            endprogressLabel.Text = string.Format("{0}%", (double)e.SeekBar.Progress);
        }

        private void ThickContainerClick(object sender, EventArgs e)
        {
            currentColorPosition = (int)((ImageButton)sender).Tag;
            Set();
        }
        private void ThickLinesClick(object sender, EventArgs e)
        {
            currentColorPosition = (int)((ImageButton)sender).Tag;
            Set();
        }
        internal void Set()
        {

            SetThickness(currentColorPosition);

        }

        private void SetThickness(int position)
        {
            switch (position)
            {
                case 0:
                    if (inkannot != null)
                    {
                        inkannot.Settings.Thickness = 1;
                    }
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                        pdfViewerControl.AnnotationSettings.Ink.Thickness = 1;
                    else if (signature != null)
                        signature.Settings.Thickness = 1;
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature)
                        pdfViewerControl.AnnotationSettings.HandwrittenSignature.Thickness = 1;
                    SetShapeThickness(2);
                    lineView1.Visibility = ViewStates.Invisible;
                    linesLayout1.Visibility = ViewStates.Gone;
                    ThicknessChanged = false;
                    break;
                case 1:
                    if (inkannot != null)
                    {
                        inkannot.Settings.Thickness = 2;
                    }
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                        pdfViewerControl.AnnotationSettings.Ink.Thickness = 2;
                    else if (signature != null)
                        signature.Settings.Thickness = 2;
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature)
                        pdfViewerControl.AnnotationSettings.HandwrittenSignature.Thickness = 2;
                    SetShapeThickness(4);

                    lineView1.Visibility = ViewStates.Invisible;
                    linesLayout1.Visibility = ViewStates.Gone;
                    ThicknessChanged = false;
                    break;
                case 2:
                    if (inkannot != null)
                    {
                        inkannot.Settings.Thickness = 5;
                    }
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                        pdfViewerControl.AnnotationSettings.Ink.Thickness = 5;
                    else if (signature != null)
                        signature.Settings.Thickness = 5;
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature)
                        pdfViewerControl.AnnotationSettings.HandwrittenSignature.Thickness = 5;
                    SetShapeThickness(6);
                    lineView1.Visibility = ViewStates.Invisible;
                    linesLayout1.Visibility = ViewStates.Gone;
                    ThicknessChanged = false;
                    break;
                case 3:
                    if (inkannot != null)
                    {
                        inkannot.Settings.Thickness = 7;
                    }
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                        pdfViewerControl.AnnotationSettings.Ink.Thickness = 7;
                    else if (signature != null)
                        signature.Settings.Thickness = 7;
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature)
                        pdfViewerControl.AnnotationSettings.HandwrittenSignature.Thickness = 7;
                    SetShapeThickness(8);
                    lineView1.Visibility = ViewStates.Invisible;
                    linesLayout1.Visibility = ViewStates.Gone;
                    ThicknessChanged = false;
                    break;
                case 4:
                    if (inkannot != null)
                    {
                        inkannot.Settings.Thickness = 10;
                    }
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                        pdfViewerControl.AnnotationSettings.Ink.Thickness = 10;
                    else if (signature != null)
                        signature.Settings.Thickness = 10;
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature)
                        pdfViewerControl.AnnotationSettings.HandwrittenSignature.Thickness = 10;
                    SetShapeThickness(10);
                    lineView1.Visibility = ViewStates.Invisible;
                    linesLayout1.Visibility = ViewStates.Gone;
                    ThicknessChanged = false;
                    break;
            }
        }

        private void SetShapeThickness(int thickness)
        {
            if (m_shapeAnnot != null)
            {
                m_shapeAnnot.Settings.Thickness = thickness;
            }
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                pdfViewerControl.AnnotationSettings.Rectangle.Settings.Thickness = thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                pdfViewerControl.AnnotationSettings.Circle.Settings.Thickness = thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                pdfViewerControl.AnnotationSettings.Line.Settings.Thickness = thickness;
            else if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                pdfViewerControl.AnnotationSettings.Arrow.Settings.Thickness = thickness;
        }

        private void Inkremovebutton_Click(object sender, EventArgs e)
        {
            m_editTextAnntationButton.Visibility = ViewStates.Gone;
            inkannot = (sender as InkAnnotation);
            if(inkannot!=null)
            pdfViewerControl.RemoveAnnotation(inkannot);
            if(m_shapeAnnot!=null)
                pdfViewerControl.RemoveAnnotation(m_shapeAnnot);
            if (m_freeTextAnnot != null)
                pdfViewerControl.RemoveAnnotation(m_freeTextAnnot);
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkButton.Visibility = ViewStates.Gone;
            inkBackButton.Visibility = ViewStates.Gone;
            inkremovebutton.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            pdfViewerControl.RemoveAnnotation(annotation);
            IsAnnotationModeSelected = false;
            m_shapeAnnot = null;
            m_freeTextAnnot = null;
            inkannot = null;
            signature = null;
        }

        private void TextmarkupannotationBackButton_Click(object sender, EventArgs e)
        {
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Visible;
            annotationsGrid.Visibility = ViewStates.Visible;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Invisible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
        }

        private bool OpacityChanged
        {

            get
            {
                return m_opacityChanged;
            }

            set
            {
                m_opacityChanged = value;
            }
        }

        private void PdfViewerControl_InkSelected(object sender, InkSelectedEventArgs args)
        {
            m_shapeAnnot = null;
            m_freeTextAnnot = null;
            annotation = null;
            Color color;
            if (!args.IsSignature)
            {
                inkannot = (sender as InkAnnotation);
                color = new Color((byte)inkannot.Settings.Color.R, (byte)inkannot.Settings.Color.G, (byte)inkannot.Settings.Color.B, (byte)255);
            }
            else
            {
                signature = (sender as HandwrittenSignature);
                color = new Color((byte)signature.Settings.Color.R, (byte)signature.Settings.Color.G, (byte)signature.Settings.Color.B, (byte)255);
            }
            inkAnnotationColorButton.SetBackgroundColor(color);
            inkannotationThicknessButton.SetTextColor(color);
            linesLayout1.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Invisible;
            inkannotationgrid.Visibility = ViewStates.Invisible;
            inkannotationbottomgrid.Visibility = ViewStates.Visible;
            inkannotationbottomtoolbar.Visibility = ViewStates.Visible;
            inkButton.Text = "\uE71d";
            inkannotationThicknessButton.Typeface = font;
            inkannotationThicknessButton.Text = "\uE722";
            inkButton.Visibility = ViewStates.Visible;
            inkBackButton.Visibility = ViewStates.Gone;
            inkremovebutton.Visibility = ViewStates.Visible;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            opacityButton.Visibility = ViewStates.Visible;
            if (!args.IsSignature)
                seekbar1.Progress = (int)(inkannot.Settings.Opacity * 100);
            else
                seekbar1.Progress = (int)(signature.Settings.Opacity * 100);
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;

        }

        private void PdfViewerControl_InkDeselected(object sender, InkDeselectedEventArgs args)
        {
            inkannot = null;
            signature = null;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            inkButton.Visibility = ViewStates.Gone;
            inkBackButton.Visibility = ViewStates.Gone;
            inkremovebutton.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;
            toolBarGrid.Visibility = ViewStates.Visible;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
        }

        private void PdfViewerControl_ShapeAnnotationDeselected(object sender, ShapeAnnotationDeselectedEventArgs args)
        {
            m_shapeAnnot = null;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            inkButton.Visibility = ViewStates.Gone;
            inkBackButton.Visibility = ViewStates.Gone;
            inkremovebutton.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;
            toolBarGrid.Visibility = ViewStates.Visible;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
        }

        private void PdfViewerControl_ShapeAnnotationSelected(object sender, ShapeAnnotationSelectedEventArgs args)
        {
            m_freeTextAnnot = null;
            inkannot = null;
            signature = null;
            annotation = null;
            m_shapeAnnot = (sender as ShapeAnnotation);
            Color color = new Color((byte)m_shapeAnnot.Settings.StrokeColor.R, (byte)m_shapeAnnot.Settings.StrokeColor.G, (byte)m_shapeAnnot.Settings.StrokeColor.B, (byte)255);
            inkAnnotationColorButton.SetBackgroundColor(color);
            inkannotationThicknessButton.SetTextColor(color);
            linesLayout1.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Invisible;
            inkannotationgrid.Visibility = ViewStates.Invisible;
            inkannotationbottomgrid.Visibility = ViewStates.Visible;
            inkannotationbottomtoolbar.Visibility = ViewStates.Visible;
            inkannotationThicknessButton.Typeface = font;
            inkannotationThicknessButton.Text = "\uE722";
            SetSelectedAnnotationButton(args);
            inkButton.Visibility = ViewStates.Visible;
            inkBackButton.Visibility = ViewStates.Gone;
            inkremovebutton.Visibility = ViewStates.Visible;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            seekbar1.Progress = (int)(m_shapeAnnot.Settings.Opacity * 100);
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;

        }

      

        private void PdfViewerControl_FreeTextAnnotationDeselected(object sender, FreeTextAnnotationDeselectedEventArgs args)
        {
            m_freeTextAnnot = null;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            inkButton.Visibility = ViewStates.Gone;
            inkBackButton.Visibility = ViewStates.Gone;
            inkremovebutton.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;
            toolBarGrid.Visibility = ViewStates.Visible;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            m_editTextAnntationButton.Visibility = ViewStates.Gone;
        }

        private void PdfViewerControl_FreeTextAnnotationSelected(object sender, FreeTextAnnotationSelectedEventArgs args)
        {
            m_shapeAnnot = null;
            signature = null;
            inkannot = null;
            signature = null;
            annotation = null;
            m_freeTextAnnot = (sender as FreeTextAnnotation);
            Color color = new Color((byte)m_freeTextAnnot.Settings.TextColor.R, (byte)m_freeTextAnnot.Settings.TextColor.G, (byte)m_freeTextAnnot.Settings.TextColor.B, (byte)255);
            inkAnnotationColorButton.SetBackgroundColor(color);
            inkannotationThicknessButton.SetTextColor(color);
            linesLayout1.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Invisible;
            inkannotationgrid.Visibility = ViewStates.Invisible;
            inkannotationbottomgrid.Visibility = ViewStates.Visible;
            inkannotationbottomtoolbar.Visibility = ViewStates.Visible;
            inkannotationThicknessButton.Typeface = fontSizeFont;
            inkannotationThicknessButton.Text = "\uE700";
            inkButton.Text = "\uE71f";
            inkButton.Visibility = ViewStates.Visible;
            inkBackButton.Visibility = ViewStates.Gone;
            inkremovebutton.Visibility = ViewStates.Visible;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            m_editTextAnntationButton.Visibility = ViewStates.Visible;
        }
        private void SetSelectedAnnotationButton(ShapeAnnotationSelectedEventArgs args)
        {
            if (args.AnnotationType == AnnotationMode.Rectangle)
                inkButton.Text = "\uE710";
            else if (args.AnnotationType == AnnotationMode.Circle)
                inkButton.Text = "\uE714";
            else if (args.AnnotationType == AnnotationMode.Line)
                inkButton.Text = "\uE703";
            else if (args.AnnotationType == AnnotationMode.Arrow)
                inkButton.Text = "\uE701";
        }
        private void PdfViewerControl_CanRedoInkModified(object sender, CanRedoInkModifiedEventArgs args)
        {
            if (args.CanRedoInk)
            {
                inkredobutton.SetTextColor(fontColor);
            }
            else
            {
                inkredobutton.SetTextColor(Color.Gray);
            }
        }

        private void PdfViewerControl_CanUndoInkModified(object sender, CanUndoInkModifiedEventArgs args)
        {
            if (args.CanUndoInk)
            {
                inkundobutton.SetTextColor(fontColor);
            }
            else
            {
                inkundobutton.SetTextColor(Color.Gray);
            }
        }

        private void Seekbar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {           
            endprogressLabel.Text = string.Format("{0}%", (e.Progress));
        }

        private void InkBackButton_Click(object sender, EventArgs e)
        {
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Visible;
            annotationsGrid.Visibility = ViewStates.Visible;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Invisible;            
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle || pdfViewerControl.AnnotationMode == AnnotationMode.Circle || pdfViewerControl.AnnotationMode == AnnotationMode.Arrow || pdfViewerControl.AnnotationMode == AnnotationMode.Line)
            {
                m_shapeAnnoationToolbar.Visibility = ViewStates.Visible;
                annotationsToolbar.Visibility = ViewStates.Gone;
                annotationsGrid.Visibility = ViewStates.Gone;

            }   
                if (pdfViewerControl.AnnotationMode==AnnotationMode.Ink)
            pdfViewerControl.EndInkSession(false);
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            if(!pdfViewerControl.CanUndo)
            undoButton.SetTextColor(Color.Gray);
            pdfViewerControl.SelectionMode = SelectionMode.None;
        }

        private void OpacityButton_Click(object sender, EventArgs e)
        {
            if (!OpacityChanged)
            {
                if(pdfViewerControl.AnnotationMode==AnnotationMode.Ink)
                seekbar1.Progress = ((int)(pdfViewerControl.AnnotationSettings.Ink.Opacity * 100));
                if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                    seekbar1.Progress = ((int)(pdfViewerControl.AnnotationSettings.Rectangle.Settings.Opacity * 100));
                if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                    seekbar1.Progress = ((int)(pdfViewerControl.AnnotationSettings.Circle.Settings.Opacity * 100));
                if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                    seekbar1.Progress = ((int)(pdfViewerControl.AnnotationSettings.Line.Settings.Opacity * 100));
                if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                    seekbar1.Progress = ((int)(pdfViewerControl.AnnotationSettings.Arrow.Settings.Opacity * 100));
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Visible;
                OpacityChanged = true;
            }
            else
            {
                OpacityChanged = false;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            }
        }

        private void InkAnnotationColorButton_Click(object sender, EventArgs e)
        {         
            if (annotationbottomcolortoolbar.Visibility == ViewStates.Visible)
            {
                OpacityChanged = false;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                opacityButton.Visibility = ViewStates.Gone;
                return;
            }
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            opacityButton.Visibility = ViewStates.Visible;
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                Color color = pdfViewerControl.AnnotationSettings.Ink.Color;
                color.A = (byte)(255);
                opacityButton.SetTextColor(color);
            }
            SetColorFreeTextAnnotation();
            SetColorRectangleAnnotation();
            SetColorCircleAnnotation();
            SetColorLineAnnotation();
            SetColorArrowAnnotation();
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                Color color = inkannot.Settings.Color;
                color.A = (byte)(255);
                opacityButton.SetTextColor(color);
            }
            else if(pdfViewerControl.AnnotationMode == AnnotationMode.None && signature != null)
            {
                Color color = signature.Settings.Color;
                color.A = (byte)255;
                opacityButton.SetTextColor(color);
            }
            annotationbottomcolortoolbar.Visibility = ViewStates.Visible;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Visible;
            lineView1.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
        }

        private void SetColorFreeTextAnnotation()
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                opacityButton.Visibility = ViewStates.Gone;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && m_freeTextAnnot != null)
            {
                opacityButton.Visibility = ViewStates.Gone;
            }

        }

        private void SetColorArrowAnnotation()
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {

                Color color = pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor;
                color.A = (byte)(255);
                opacityButton.SetTextColor(color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && m_shapeAnnot != null)
            {
                Color color = m_shapeAnnot.Settings.StrokeColor;
                color.A = (byte)(255);
                opacityButton.SetTextColor(color);
            }
        }

        private void SetColorLineAnnotation()
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
            {

                Color color = pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor;
                color.A = (byte)(255);
                opacityButton.SetTextColor(color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && m_shapeAnnot != null)
            {
                Color color = m_shapeAnnot.Settings.StrokeColor;
                color.A = (byte)(255);
                opacityButton.SetTextColor(color);
            }
        }

        private void SetColorCircleAnnotation()
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
            {

                Color color = pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor;
                color.A = (byte)(255);
                opacityButton.SetTextColor(color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && m_shapeAnnot != null)
            {
                Color color = m_shapeAnnot.Settings.StrokeColor;
                color.A = (byte)(255);
                opacityButton.SetTextColor(color);
            }
        }

        private void SetColorRectangleAnnotation()
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
            {

                Color color = pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor;
                color.A = (byte)( 255);
                opacityButton.SetTextColor(color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && m_shapeAnnot != null)
            {
                Color color = m_shapeAnnot.Settings.StrokeColor;
                color.A = (byte)(255);
                opacityButton.SetTextColor(color);
            }
        }

        private void InkannotationThicknessButton_Click(object sender, EventArgs e)
        {
            if(ThicknessChanged)
            {
                lineView1.Visibility = ViewStates.Gone;
                linesLayout1.Visibility = ViewStates.Gone;
                ThicknessChanged = false;
                return;
            }
            if (annotationbottomcolortoolbar.Visibility == ViewStates.Visible)
            {
                OpacityChanged = false;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                opacityButton.Visibility = ViewStates.Gone;               
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                lineView1.Visibility = ViewStates.Visible;
                linesLayoutGrid.Visibility = ViewStates.Visible;
                m_rangeandThicknessFrame.Visibility = ViewStates.Visible;
                m_rangeSliderView.Visibility = ViewStates.Invisible;
                var m_color = pdfViewerControl.AnnotationSettings.Ink.Color;
                m_color.A = (byte)255;
                lineOne1.SetBackgroundColor(m_color);
                lineTwo1.SetBackgroundColor(m_color);
                lineThree1.SetBackgroundColor(m_color);
                lineFour1.SetBackgroundColor(m_color);
                lineFive1.SetBackgroundColor(m_color);
                ThicknessChanged = true;
            }
            SetThicknessRectangleAnnotation();
            SetThicknessCircleAnnotation();
            SetThicknessLineAnnotation();
            SetThicknessArrowAnnotation();
            if(pdfViewerControl.AnnotationMode == AnnotationMode.FreeText||m_freeTextAnnot!=null)
            {
                lineView1.Visibility = ViewStates.Visible;
                linesLayoutGrid.Visibility = ViewStates.Invisible;
                m_rangeandThicknessFrame.Visibility = ViewStates.Visible;
                m_rangeSliderView.Visibility = ViewStates.Visible;
            }
            if (inkannot != null)
            {
                lineView1.Visibility = ViewStates.Visible;
                linesLayoutGrid.Visibility = ViewStates.Visible;
                m_rangeandThicknessFrame.Visibility = ViewStates.Visible;
                m_rangeSliderView.Visibility = ViewStates.Invisible;
                var m_color = inkannot.Settings.Color;
                m_color.A = (byte)255;
                lineOne1.SetBackgroundColor(m_color);
                lineTwo1.SetBackgroundColor(m_color);
                lineThree1.SetBackgroundColor(m_color);
                lineFour1.SetBackgroundColor(m_color);
                lineFive1.SetBackgroundColor(m_color);
                ThicknessChanged = true;
            }
            if (signature != null)
            {
                lineView1.Visibility = ViewStates.Visible;
                linesLayoutGrid.Visibility = ViewStates.Visible;
                m_rangeandThicknessFrame.Visibility = ViewStates.Visible;
                m_rangeSliderView.Visibility = ViewStates.Invisible;
                var m_color = signature.Settings.Color;
                m_color.A = (byte)255;
                lineOne1.SetBackgroundColor(m_color);
                lineTwo1.SetBackgroundColor(m_color);
                lineThree1.SetBackgroundColor(m_color);
                lineFour1.SetBackgroundColor(m_color);
                lineFive1.SetBackgroundColor(m_color);
                ThicknessChanged = true;
            }
            if (m_shapeAnnot!=null)
            {
                lineView1.Visibility = ViewStates.Visible;
                linesLayoutGrid.Visibility = ViewStates.Visible;
                m_rangeandThicknessFrame.Visibility = ViewStates.Visible;
                m_rangeSliderView.Visibility = ViewStates.Invisible;
                var m_color = m_shapeAnnot.Settings.StrokeColor;
                m_color.A = (byte)255;
                lineOne1.SetBackgroundColor(m_color);
                lineTwo1.SetBackgroundColor(m_color);
                lineThree1.SetBackgroundColor(m_color);
                lineFour1.SetBackgroundColor(m_color);
                lineFive1.SetBackgroundColor(m_color);
                ThicknessChanged = true;
            }
            lineView1.Visibility = ViewStates.Visible;
            linesLayout1.Visibility = ViewStates.Visible;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
        }

        private void SetThicknessArrowAnnotation()
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {
                linesLayoutGrid.Visibility = ViewStates.Visible;
                m_rangeandThicknessFrame.Visibility = ViewStates.Visible;
                m_rangeSliderView.Visibility = ViewStates.Invisible;
                var m_color = pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor;
                m_color.A = 255;
                lineOne1.SetBackgroundColor(m_color);
                lineTwo1.SetBackgroundColor(m_color);
                lineThree1.SetBackgroundColor(m_color);
                lineFour1.SetBackgroundColor(m_color);
                lineFive1.SetBackgroundColor(m_color);
                ThicknessChanged = true;
            }
        }

        private void SetThicknessLineAnnotation()
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
            {
                linesLayoutGrid.Visibility = ViewStates.Visible;
                m_rangeandThicknessFrame.Visibility = ViewStates.Visible;
                m_rangeSliderView.Visibility = ViewStates.Invisible;
                var m_color = pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor;
                m_color.A = (byte)255;
                lineOne1.SetBackgroundColor(m_color);
                lineTwo1.SetBackgroundColor(m_color);
                lineThree1.SetBackgroundColor(m_color);
                lineFour1.SetBackgroundColor(m_color);
                lineFive1.SetBackgroundColor(m_color);
                ThicknessChanged = true;
            }
        }

        private void SetThicknessCircleAnnotation()
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
            {
                linesLayoutGrid.Visibility = ViewStates.Visible;
                m_rangeandThicknessFrame.Visibility = ViewStates.Visible;
                m_rangeSliderView.Visibility = ViewStates.Invisible;
                var m_color = pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor;
                m_color.A = 255;
                lineOne1.SetBackgroundColor(m_color);
                lineTwo1.SetBackgroundColor(m_color);
                lineThree1.SetBackgroundColor(m_color);
                lineFour1.SetBackgroundColor(m_color);
                lineFive1.SetBackgroundColor(m_color);
                ThicknessChanged = true;
            }
        }

        private void SetThicknessRectangleAnnotation()
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
            {
                linesLayoutGrid.Visibility = ViewStates.Visible;
                m_rangeandThicknessFrame.Visibility = ViewStates.Visible;
                m_rangeSliderView.Visibility = ViewStates.Invisible;
                var m_color = pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor;
                m_color.A = (byte)255;
                lineOne1.SetBackgroundColor(m_color);
                lineTwo1.SetBackgroundColor(m_color);
                lineThree1.SetBackgroundColor(m_color);
                lineFour1.SetBackgroundColor(m_color);
                lineFive1.SetBackgroundColor(m_color);
                ThicknessChanged = true;
            }
        }

        private void Inkannotationbackbutton_Click(object sender, EventArgs e)
        {
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
        
                m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
                shapeAnnotationBarGrid.Visibility = ViewStates.Gone;
                annotationsToolbar.Visibility = ViewStates.Gone;
                annotationsGrid.Visibility = ViewStates.Gone;
 
            searchBarGrid.Visibility = ViewStates.Invisible;
            toolBarGrid.Visibility = ViewStates.Visible;
            if(pdfViewerControl.AnnotationMode==AnnotationMode.Ink)
            pdfViewerControl.EndInkSession(true);
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
        }

        private void Inkredobutton_Click(object sender, EventArgs e)
        {
            pdfViewerControl.RedoInk();
        }

        private void Inkundobutton_Click(object sender, EventArgs e)
        {
          
            pdfViewerControl.UndoInk();
        }

        private void AnnotationsBackButton_Click(object sender, EventArgs e)
        {
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.SelectionMode = SelectionMode.None;
            IsAnnotationModeSelected = false;
        }

        private void InkAnnotationButton_Click(object sender, EventArgs e)
        {
            var m_colorbuttonbackground = pdfViewerControl.AnnotationSettings.Ink.Color;
            m_colorbuttonbackground.A = (byte)255;
            inkAnnotationColorButton.SetBackgroundColor(m_colorbuttonbackground);
            pdfViewerControl.AnnotationMode = AnnotationMode.Ink;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Visible;
            inkannotationgrid.Visibility = ViewStates.Visible;
            inkannotationbottomgrid.Visibility = ViewStates.Visible;
            inkannotationbottomtoolbar.Visibility = ViewStates.Visible;
            inkredobutton.Visibility = ViewStates.Visible;
            inkundobutton.Visibility = ViewStates.Visible;
            inkButton.Text = "\uE71d";
            inkButton.Visibility = ViewStates.Visible;
            inkBackButton.Visibility = ViewStates.Visible;
            inkremovebutton.Visibility = ViewStates.Gone;
            inkannotationThicknessButton.Typeface = font;
            inkannotationThicknessButton.Text = "\uE722";
            var m_color = pdfViewerControl.AnnotationSettings.Ink.Color;
            m_color.A = (byte)255;
            inkannotationThicknessButton.SetTextColor(m_color);
            opacityButton.Visibility = ViewStates.Visible;
        }

        private void TextMarkupAnnotationButton_Click(object sender, EventArgs e)
        {
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            shapeAnnotationBarGrid.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Visible;
            annotationBarGrid.Visibility = ViewStates.Visible;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Gone;
        }

        private bool IsAnnotationModeSelected
        {
            get
            {
                return m_isAnnotationModeSelected;
            }
            set
            {
                m_isAnnotationModeSelected = value;
            }
        }

        #region DocumentSelectionMenu
        private void SelectionButton_Click(object sender, EventArgs e)
        {           
            if (searchBarGrid.Visibility == ViewStates.Visible)
            {
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
            }

            PopupMenu popup = new PopupMenu(pdfViewerContext, selectionButton);
            popup.Inflate(Resource.Drawable.popup_menu_pdfViewer);
            popup.MenuItemClick += Popup_MenuItemClick;
            popup.Show();
        }

        private void Popup_MenuItemClick(object sender, PopupMenu.MenuItemClickEventArgs e)
        {

            bookmarkToolbar.ClearBookmark();
            //Collapse the bookmark toolbar when a new PDF is selected
            CollapseBookmarkToolbar();
            string documentName = e.Item.TitleFormatted.ToString();
            if (documentName != backupDocumentName || disableToolbar)
            {
                pdfViewerControl.Unload();
                DisableToolbar();
                backupDocumentName = documentName;
                Stream docStream = typeof(PdfViewerDemo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets." + documentName + ".pdf");
                try
                {
                    bookmarkToolbar.bookmarkLoadedDocument = new PdfLoadedDocument(docStream, "");
                }
                catch (PdfException)
                {
                    DisplayInitialPopup();
                    i++;
                    return;
                }

                bookmarkToolbar.PopulateInitialBookmarkList();
                pdfViewerControl.LoadDocument(docStream);

            }
            if (isLoadedDocument)
                EnableToolbar();
        }
        private void EnableToolbar()
        {
            enableToolbar = true;
            if (!saveButton.Enabled)
                saveButton.Enabled = true;
            if (!bookmarkButton.Enabled)
                bookmarkButton.Enabled = true;
            if (!searchButton.Enabled)
                searchButton.Enabled = true;
            if (!pageNumberEntry.Enabled)
                pageNumberEntry.Enabled = true;
            if (!annotationModeButton.Enabled)
                annotationModeButton.Enabled = true;
            if (!viewModeButton.Enabled)
                viewModeButton.Enabled = true;
            pdfViewerControl.EnableScrollHead = true;
            saveButton.SetTextColor(fontColor);
            bookmarkButton.SetTextColor(fontColor);
            searchButton.SetTextColor(fontColor);
            pageNumberEntry.SetTextColor(fontColor);
            annotationModeButton.SetTextColor(fontColor);
            viewModeButton.SetTextColor(fontColor);
            pageCountText.SetTextColor(fontColor);
        }

        private void DisableToolbar()
        {
            disableToolbar = true;
            if (saveButton.Enabled)
                saveButton.Enabled = false;
            if (bookmarkButton.Enabled)
                bookmarkButton.Enabled = false;
            if (searchButton.Enabled)
                searchButton.Enabled = false;
            if (pageNumberEntry.Enabled)
                pageNumberEntry.Enabled = false;
            if (annotationModeButton.Enabled)
                annotationModeButton.Enabled = false;
            if (viewModeButton.Enabled)
                viewModeButton.Enabled = false;
            pdfViewerControl.EnableScrollHead = false;
            saveButton.SetTextColor(Color.Gray);
            bookmarkButton.SetTextColor(Color.Gray);
            searchButton.SetTextColor(Color.Gray);
            pageNumberEntry.SetTextColor(Color.Gray);
            annotationModeButton.SetTextColor(Color.Gray);
            viewModeButton.SetTextColor(Color.Gray);
            pageCountText.SetTextColor(Color.Gray);
            pageCountText.Text = "0";
            pageNumberEntry.Text = "0";
        }


        private void PdfViewerControl_DocumentLoaded1(object sender, EventArgs e)
        {
            initialPopup.Dismiss();
            errorView.Visibility = ViewStates.Invisible;
            InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
        }
        #region Password Protected


        public PasswordTransformationMethod TransformationMethod { get; private set; }
        private void DisplayInitialPopup()
        {
            #region Popup Properties
            initialPopup = new SfPopupLayout(mainView.Context);
            initialPopup.PopupView.WidthRequest = 400;
            initialPopup.PopupView.HeightRequest = 230;
            headerLinear = new LinearLayout(mainView.Context);
            LinearLayout linear = new LinearLayout(mainView.Context);
            editText = new EditText(mainView.Context);
            if (IsTablet(mainView.Context))
            {
                headerLinear.SetPadding(20, 10, 0, 0);
                linear.SetPadding(20, 20, 20, 0);

                editText.Layout(0, 70, 0, 0);
                initialPopup.PopupView.WidthRequest = 430 * mainView.Context.Resources.DisplayMetrics.Density;
                initialPopup.PopupView.HeightRequest = 230 * mainView.Context.Resources.DisplayMetrics.Density;
            }
            else
            {
                headerLinear.SetPadding(40, 40, 0, 0);
                linear.SetPadding(40, 20, 40, 0);

                editText.Layout(-20, 60, 0, 0);
                if (screenSize == ScreenSize.Small || screenSize == ScreenSize.Normal)
                {
                    editText.SetHeight(100);
                    editText.SetPadding(0, 20, 0, 0);
                    initialPopup.PopupView.WidthRequest = 140 * mainView.Context.Resources.DisplayMetrics.Density;
                    initialPopup.PopupView.HeightRequest = 85 * mainView.Context.Resources.DisplayMetrics.Density;
                }
                else if (screenSize == ScreenSize.Large || screenSize == ScreenSize.XLarge)
                {
                    editText.SetHeight(150);
                    editText.SetPadding(-5, 20, 0, 0);
                    initialPopup.PopupView.WidthRequest = 140 * mainView.Context.Resources.DisplayMetrics.Density;
                    initialPopup.PopupView.HeightRequest = 80 * mainView.Context.Resources.DisplayMetrics.Density;
                }
            }
            initialPopup.PopupView.ShowFooter = true;
            initialPopup.PopupView.ShowCloseButton = true;
            initialPopup.PopupView.HeaderTitle = "Password Protected";
            initialPopup.PopupView.AcceptButtonText = "OK";
            initialPopup.PopupView.DeclineButtonText = "CANCEL";
            initialPopup.Closed += InitialPopup_Closed;
            initialPopup.PopupView.PopupStyle.HeaderTextSize = (int)(10 * mainView.Context.Resources.DisplayMetrics.Density);
            initialPopup.StaysOpen = true;
            #endregion


            initialPopup.PopupView.HeaderView = headerLinear;
            titleText = new TextView(mainView.Context);
            titleText.Text = "Password Protected";
            titleText.SetTextSize(ComplexUnitType.Dip, 20);
            titleText.SetTextColor(Color.Black);
            titleText.Typeface = Typeface.DefaultBold;
            headerLinear.AddView(titleText);


            linear.Orientation = Android.Widget.Orientation.Vertical;
            TextView messageView = new TextView(mainView.Context);
            messageView.Text = "Enter the password to open this PDF File.";
            messageView.SetTextColor(Color.Black);
            messageView.SetTextSize(ComplexUnitType.Dip, 17);
            messageView.Typeface = Typeface.Default;
            linear.AddView(messageView);


            editText.TransformationMethod = Android.Text.Method.PasswordTransformationMethod.Instance;
            editText.Hint = "Password: syncfusion";
            editText.SetTextSize(ComplexUnitType.Dip, 15);
            //LinearLayout.LayoutParams ip=new LinearLayout.LayoutParams
            MarginLayoutParams parameter = new MarginLayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            parameter.SetMargins(-5, 20, 0, 10);
            editText.LayoutParameters = parameter;
            if (IsDeviceTablet)
                editText.SetPadding(10, 0, 0, 0);
            else
                editText.SetPadding(10, 0, 0, 0);
            editText.TextChanged += EditText_TextChanged;
            editText.FocusChange += EditText_FocusChange;
			editText.KeyPress+= AcceptButton_Click;
            editText.SetWidth(10);
            linear.AddView(editText);
            errorView = new TextView(mainView.Context);
            errorView.Text = "Invalid Password!";
            errorView.SetTextColor(Color.Red);
			if(IsTablet(mainView.Context))
            {
                errorView.SetPadding(0, -5, 0, 0);
                parameter.SetMargins(0,-10,0,0);
                errorView.LayoutParameters = parameter;
            }
            else
                errorView.SetPadding(0, -15, 0, 0);
            errorView.SetBackgroundColor(Color.White);
            errorView.SetTextSize(ComplexUnitType.Dip, 17);
            errorView.Visibility = ViewStates.Invisible;
            errorView.Typeface = Typeface.Default;
            linear.AddView(errorView);
            initialPopup.PopupView.ContentView = linear;
            footerLinear = new LinearLayout(mainView.Context);
            declineButton = new Button(mainView.Context);
            declineButton.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);


            declineButton.Text = "CANCEL";
            declineButton.SetTextSize(ComplexUnitType.Dip, 15);
            declineButton.SetBackgroundColor(Color.Transparent);
            declineButton.Click += DeclineButton_Click;
            footerLinear.AddView(declineButton);
            declineButton.Gravity = GravityFlags.End;
            footerLinear.SetHorizontalGravity(GravityFlags.Right);
            acceptButton = new Button(mainView.Context);
            acceptButton.SetWidth(0);
            acceptButton.Text = "OK";
            acceptButton.Enabled = false;
            acceptButton.SetTextSize(ComplexUnitType.Dip, 15);
            acceptButton.SetForegroundGravity(GravityFlags.End);
            acceptButton.SetBackgroundColor(Color.Transparent);
            acceptButton.Gravity = GravityFlags.Center;
            acceptButton.Click += AcceptButton_Click;
            footerLinear.AddView(acceptButton);
            initialPopup.PopupView.FooterView = footerLinear;
            initialPopup.PopupView.PopupStyle.CornerRadius = 0;
            initialPopup.Show();

        }

        private void EditText_FocusChange(object sender, View.FocusChangeEventArgs e)
        {

            editText.RequestFocus();
            InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(editText.WindowToken, HideSoftInputFlags.ImplicitOnly);
        }

        private void InitialPopup_Closed(object sender, EventArgs e)
        {
            if (!isLoadedDocument)
            {
                DisableToolbar();
            }
        }

        public ScreenSize GetScreenSize()
        {
            if ((mainView.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeNormal)
                return ScreenSize.Normal;
            else if ((mainView.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeLarge)
                return ScreenSize.Large;
            else if ((mainView.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeSmall)
                return ScreenSize.Small;
            else if ((mainView.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeXlarge)
                return ScreenSize.Small;
            return ScreenSize.Normal;
        }
        public static bool IsTablet(Context context)
        {
            Display display = ((Activity)context).WindowManager.DefaultDisplay;
            DisplayMetrics displayMetrics = new DisplayMetrics();
            display.GetMetrics(displayMetrics);

            var wInches = displayMetrics.WidthPixels / (double)displayMetrics.DensityDpi;
            var hInches = displayMetrics.HeightPixels / (double)displayMetrics.DensityDpi;

            double screenDiagonal = Math.Sqrt(Math.Pow(wInches, 2) + Math.Pow(hInches, 2));
            return (screenDiagonal >= 7.0);
        }
        private void EditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (editText.Text != "")
            {
                acceptButton.Enabled = true;
                acceptButton.SetTextColor(Color.Rgb(0, 118, 255));
            }
            else
            {
                acceptButton.Enabled = false;
                acceptButton.SetTextColor(Color.Gray);
            }
        }

        private void DeclineButton_Click(object sender, System.EventArgs e)
        {
            initialPopup.Dismiss();
            pdfViewerControl.Unload();
            DisableToolbar();
            InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
        }

        private void AcceptButton_Click(object sender, System.EventArgs e)
        {
            initialPopup.Dismiss();
            Stream docStream = typeof(PdfViewerDemo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets." + backupDocumentName + ".pdf");
            pdfViewerControl.LoadDocument(docStream, editText.Text);
            if (isLoadedDocument)
            {
                EnableToolbar();
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
            }
        }
        public enum ScreenSize
        {
            Small = 0,
            Normal,
            Large,
            XLarge
        }
        #endregion
        #endregion

        #region TextSearch
        private void SearchView_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (searchView.Text != string.Empty)
            {
                clearSearchButton.Visibility = ViewStates.Visible;
            }
            else
            {
                clearSearchButton.Visibility = ViewStates.Invisible;
            }
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            pdfViewerControl.CancelSearch();
            searchView.Text = "";
            clearSearchButton.Visibility = ViewStates.Invisible;
            InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
            inputMethodManager.ShowSoftInput(searchView, ShowFlags.Implicit);
        }

        private void SearchView_KeyPress(object sender, View.KeyEventArgs e)
        {
            var editText = sender as EditText;
            if (e.KeyCode == Keycode.Enter)
            {
                if (!string.IsNullOrWhiteSpace(editText.Text) && !string.IsNullOrEmpty(editText.Text))
                {
                    searchText = editText.Text;
                    pdfViewerControl.SearchText(searchText);
                }
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
            }
            if (e.KeyCode == Keycode.Del)
            {
                if (editText.Length() > 0)
                {
                    editText.Text = editText.Text.Remove(editText.Length() - 1, 1);
                    editText.SetSelection(editText.Text.Length);
                }
                else
                    pdfViewerControl.CancelSearch();
            }
            pdfViewerControl.SelectionMode = SelectionMode.None;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (searchBarGrid.Visibility == ViewStates.Visible)
            {
                searchBarGrid.Visibility = ViewStates.Invisible;
                toolBarGrid.Visibility = ViewStates.Visible;
                pdfViewerControl.CancelSearch();
                searchView.Text = "";
                clearSearchButton.Visibility = ViewStates.Invisible;
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            CollapseBookmarkToolbar();
            annotationToolBar.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;

            IsAnnotationModeSelected = false;
            if (toolBarGrid.Visibility == ViewStates.Visible)
            {
                toolBarGrid.Visibility = ViewStates.Invisible;
                searchBarGrid.Visibility = ViewStates.Visible;
                searchView.RequestFocus();
                clearSearchButton.Visibility = ViewStates.Invisible;
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.ShowSoftInput(searchView, ShowFlags.Implicit);
            }
        }

        string searchText = string.Empty;
        private Button TextAnnotationButton;
        private LinearLayout shapeAnnotationBarGrid;
        private Button rectangleModeButton;
        private Button circleModeButton;
        private Button lineModeButton;
        private Button arrowModeButton;
        private Button shapeannotationBackButton;
        private Typeface fontSizeFont;
        internal Typeface font, viewModeFont;
        internal Typeface bookmarkFont, stampFont;
        private ShapeAnnotation m_shapeAnnot;
        private FreeTextAnnotation m_freeTextAnnot;
        private StampAnnotation m_selectedStampAnnotation;
        private Context m_context;
        private LinearLayout linesLayoutGrid;
        private FrameLayout m_rangeandThicknessFrame;
        private Button m_editTextAnntationButton;
        internal Typeface signatureFont;

        #endregion

        private void PdfViewerControl_PageChanged(object sender, PageChangedEventArgs args)
        {
            pageNumberEntry.Text = args.NewPageNumber.ToString();
        }

        private void PdfViewerControl_DocumentLoaded(object sender, EventArgs args)
        {
            isLoadedDocument = true;
            pageNumberEntry.Text = pdfViewerControl.PageNumber.ToString();
            pageCountText.Text = pdfViewerControl.PageCount.ToString();
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                pdfViewerControl.EndInkSession(false);
            inkremovebutton.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            //if(initialPopup!=null)
            //initialPopup.Dismiss();
            EnableToolbar();
        }

        private void PageNumberEntry_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                int pageNumber = 0;
                if (int.TryParse((pageNumberEntry.Text), out pageNumber))
                {
                    if ((pageNumber > 0) && (pageNumber <= pdfViewerControl.PageCount))
                        pdfViewerControl.GoToPage(pageNumber);
                    else
                    {
                        DisplayAlertDialog();
                        pageNumberEntry.Text = pdfViewerControl.PageNumber.ToString();
                    }
                }
                pageNumberEntry.ClearFocus();
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
            }
        }

        void DisplayAlertDialog()
        {
            AlertDialog.Builder alertDialog = new AlertDialog.Builder(mainView.Context);
            alertDialog.SetTitle("Error");
            alertDialog.SetMessage("Please enter the valid page number");
            alertDialog.SetPositiveButton("OK", (senderAlert, args) => { });
            Dialog dialog = alertDialog.Create();
            dialog.Show();
        }

        private void AnnotationBackButton_Click(object sender, EventArgs e)
        {
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
        }

        private void StrikeoutModeButton_Click(object sender, EventArgs e)
        {
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationButton.Text = "\uE711";
            removeButton.Visibility = ViewStates.Gone;
            annotationBackButton.Visibility = ViewStates.Visible;
            annotationButton.Visibility = ViewStates.Visible;
            annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
            pdfViewerControl.AnnotationMode = AnnotationMode.Strikethrough;
        }

        private void UnderlineModeButton_Click(object sender, EventArgs e)
        {
            annotationBackGrid.Visibility = ViewStates.Visible;
            removeButton.Visibility = ViewStates.Gone;
            annotationBackButton.Visibility = ViewStates.Visible;
            annotationButton.Visibility = ViewStates.Visible;
            annotationButton.Text = "\uE70d";
            annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
            pdfViewerControl.AnnotationMode = AnnotationMode.Underline;
        }

        private void HighlightModeButton_Click(object sender, EventArgs e)
        {
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationButton.Visibility = ViewStates.Visible;
            annotationButton.Text = "\uE715";
            annotationBackButton.Visibility = ViewStates.Visible;
            removeButton.Visibility = ViewStates.Gone;
            annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
            pdfViewerControl.AnnotationMode = AnnotationMode.Highlight;


        }

        private void AnnotationModeButton_Click(object sender, EventArgs e)
        {
            CollapseBookmarkToolbar();
            pdfViewerControl.SelectionMode = SelectionMode.None;
            if (!pdfViewerControl.CanUndo)
                undoButton.SetTextColor(Color.Gray);
            if (!IsAnnotationModeSelected)
            {
                if (searchBarGrid.Visibility == ViewStates.Visible)
                {
                    InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                    inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
                }
                if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                    pdfViewerControl.EndInkSession(false);
                m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
                annotationsToolbar.Visibility = ViewStates.Visible;
                annotationsGrid.Visibility = ViewStates.Visible;
                annotationBackGrid.Visibility = ViewStates.Gone;
                annotationColorBarGrid.Visibility = ViewStates.Gone;
                toolBarGrid.Visibility = ViewStates.Visible;
                searchBarGrid.Visibility = ViewStates.Gone;
                IsAnnotationModeSelected = true;
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationBarGrid.Visibility = ViewStates.Gone;
                inkannotationtoolbar.Visibility = ViewStates.Gone;
                inkannotationgrid.Visibility = ViewStates.Gone;
                inkannotationbottomgrid.Visibility = ViewStates.Gone;
                inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
                toolBarGrid.Visibility = ViewStates.Visible;
                pdfViewerControl.AnnotationMode = AnnotationMode.None;
                opacityButton.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                lineView1.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessGrid.Visibility = ViewStates.Gone;
                linesLayout1.Visibility = ViewStates.Gone;
                inkremovebutton.Visibility = ViewStates.Gone;
                pdfViewerControl.AnnotationMode = AnnotationMode.None;             
            }
            else
            {
                if (searchBarGrid.Visibility == ViewStates.Visible)
                {
                    InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                    inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
                }
                if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                    pdfViewerControl.EndInkSession(false);
                inkremovebutton.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                pdfViewerControl.AnnotationMode = AnnotationMode.None;
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationBarGrid.Visibility = ViewStates.Gone;
                annotationBackGrid.Visibility = ViewStates.Gone;
                annotationColorBarGrid.Visibility = ViewStates.Gone;
                annotationColorBarGrid.Visibility = ViewStates.Gone;
                searchBarGrid.Visibility = ViewStates.Gone;
                IsAnnotationModeSelected = false;
                annotationsToolbar.Visibility = ViewStates.Gone;
                annotationsGrid.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessGrid.Visibility = ViewStates.Gone;
                linesLayout1.Visibility = ViewStates.Gone;
                inkannotationtoolbar.Visibility = ViewStates.Gone;
                inkannotationgrid.Visibility = ViewStates.Gone;
                inkannotationbottomgrid.Visibility = ViewStates.Gone;
                inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
                toolBarGrid.Visibility = ViewStates.Visible;
                pdfViewerControl.AnnotationMode = AnnotationMode.None;
                opacityButton.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                lineView1.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                pdfViewerControl.AnnotationMode = AnnotationMode.None;
            }
        }

        private void AnnotationColorButton_Click(object sender, EventArgs e)
        {
            annotationbottomcolortoolbar.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Visible;
            annotationToolBar.Visibility = ViewStates.Visible;
            annotationBackGrid.Visibility = ViewStates.Visible;
        }

        private void BlackcolorButton_Click(object sender, EventArgs e)
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.Black;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Black;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Black;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Black);
                inkannot.Settings.Color = Android.Graphics.Color.Black;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Black);
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && signature != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Black);
                signature.Settings.Color = Android.Graphics.Color.Black;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Black);
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Black);
                annotation.Settings.Color = Android.Graphics.Color.Black;

                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Black);
                annotationToolBar.Visibility = ViewStates.Visible;              
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Black);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.Black;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Black);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Black);
                pdfViewerControl.AnnotationSettings.HandwrittenSignature.Color = Android.Graphics.Color.Black;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Black);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            SetGreenRectangleAnnotation(Android.Graphics.Color.Black);
            SetGreenCircleAnnotation(Android.Graphics.Color.Black);
            SetGreenLineAnnotation(Android.Graphics.Color.Black);
            SetGreenArrowAnnotation(Android.Graphics.Color.Black);
            SetGreenFreeTextAnnotation(Android.Graphics.Color.Black);
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
        }

        private void WhitecolorButton_Click(object sender, EventArgs e)
        {

            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.White;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;               
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.White;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;               
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.White;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;             
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.White);
                annotation.Settings.Color = Android.Graphics.Color.White;
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.White);
                inkannot.Settings.Color = Android.Graphics.Color.White;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.White);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.White);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.White;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.White);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && signature != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.White);
                signature.Settings.Color = Android.Graphics.Color.White;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.White);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.White);
                pdfViewerControl.AnnotationSettings.HandwrittenSignature.Color = Android.Graphics.Color.White;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.White);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            SetGreenRectangleAnnotation(Android.Graphics.Color.White);
            SetGreenCircleAnnotation(Android.Graphics.Color.White);
            SetGreenLineAnnotation(Android.Graphics.Color.White);
            SetGreenArrowAnnotation(Android.Graphics.Color.White);
            SetGreenFreeTextAnnotation(Android.Graphics.Color.White);
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
        }

        private void MagentacolorButton_Click(object sender, EventArgs e)
        {

            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.Magenta;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Magenta;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Magenta;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationToolBar.Visibility = ViewStates.Visible;
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Magenta);
                annotation.Settings.Color = Android.Graphics.Color.Magenta;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Magenta);
                inkannot.Settings.Color = Android.Graphics.Color.Magenta;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Magenta);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Magenta);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.Magenta;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Magenta);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && signature != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Magenta);
                signature.Settings.Color = Android.Graphics.Color.Magenta;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Magenta);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Magenta);
                pdfViewerControl.AnnotationSettings.HandwrittenSignature.Color = Android.Graphics.Color.Magenta;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Magenta);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            SetGreenRectangleAnnotation(Android.Graphics.Color.Magenta);
            SetGreenCircleAnnotation(Android.Graphics.Color.Magenta);
            SetGreenLineAnnotation(Android.Graphics.Color.Magenta);
            SetGreenArrowAnnotation(Android.Graphics.Color.Magenta);
            SetGreenFreeTextAnnotation(Android.Graphics.Color.Magenta);
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
        }
        private void GreencolorButton_Click(object sender, EventArgs e)
        {

            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.Green;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Green;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Green;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Green);
                annotation.Settings.Color = Android.Graphics.Color.Green;
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Green);
                inkannot.Settings.Color = Android.Graphics.Color.Green;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Green);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }

            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Green);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.Green;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Green);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && signature != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Green);
                signature.Settings.Color = Android.Graphics.Color.Green;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Green);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }

            if (pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Green);
                pdfViewerControl.AnnotationSettings.HandwrittenSignature.Color = Android.Graphics.Color.Green;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Green);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            SetGreenRectangleAnnotation(Android.Graphics.Color.Green);
            SetGreenCircleAnnotation(Android.Graphics.Color.Green);
            SetGreenLineAnnotation(Android.Graphics.Color.Green);
            SetGreenArrowAnnotation(Android.Graphics.Color.Green);
            SetGreenFreeTextAnnotation(Android.Graphics.Color.Green);
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
        }

        private void SetGreenFreeTextAnnotation(Color color)
        {

            if (pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                inkAnnotationColorButton.SetBackgroundColor(color);
                pdfViewerControl.AnnotationSettings.FreeText.TextColor = color;
                inkannotationThicknessButton.SetTextColor(color);
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && m_freeTextAnnot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(color);
                m_freeTextAnnot.Settings.TextColor = color;
                inkannotationThicknessButton.SetTextColor(color);
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
        }

        private void SetGreenArrowAnnotation(Color color)
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {
                inkAnnotationColorButton.SetBackgroundColor(color);
                pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor = color;
                inkannotationThicknessButton.SetTextColor(color);
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && m_shapeAnnot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(color);
                m_shapeAnnot.Settings.StrokeColor = color;
                inkannotationThicknessButton.SetTextColor(color);
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
        }

        private void SetGreenLineAnnotation(Color color)
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Line)
            {
                inkAnnotationColorButton.SetBackgroundColor(color);
                pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor = color;
                inkannotationThicknessButton.SetTextColor(color);
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && m_shapeAnnot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(color);
                m_shapeAnnot.Settings.StrokeColor = color;
                inkannotationThicknessButton.SetTextColor(color);
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
        }

        private void SetGreenCircleAnnotation(Color color)
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
            {
                inkAnnotationColorButton.SetBackgroundColor(color);
                pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor = color;
                inkannotationThicknessButton.SetTextColor(color);
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && m_shapeAnnot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(color);
                m_shapeAnnot.Settings.StrokeColor = color;
                inkannotationThicknessButton.SetTextColor(color);
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
        }

        private void SetGreenRectangleAnnotation(Color color)
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
            {
                inkAnnotationColorButton.SetBackgroundColor(color);
                pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor = color;
                inkannotationThicknessButton.SetTextColor(color);
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && m_shapeAnnot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(color);
                m_shapeAnnot.Settings.StrokeColor = color;
                inkannotationThicknessButton.SetTextColor(color);
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
        }


        private void YellowcolorButton_Click(object sender, EventArgs e)
        {

            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.Yellow;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Yellow;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Yellow;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Yellow);
                inkannot.Settings.Color = Android.Graphics.Color.Yellow;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Yellow);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Yellow);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.Yellow;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Yellow);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Yellow);
                annotation.Settings.Color = Android.Graphics.Color.Yellow;
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            SetGreenRectangleAnnotation(Android.Graphics.Color.Yellow);
            SetGreenCircleAnnotation(Android.Graphics.Color.Yellow);
            SetGreenLineAnnotation(Android.Graphics.Color.Yellow);
            SetGreenArrowAnnotation(Android.Graphics.Color.Yellow);
            SetGreenFreeTextAnnotation(Android.Graphics.Color.Yellow);
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
        }

        private void CyancolorButton_Click(object sender, EventArgs e)
        {

            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.Cyan;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Cyan;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Cyan;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Cyan);
                annotation.Settings.Color = Android.Graphics.Color.Cyan;
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Cyan);
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Cyan);
                inkannot.Settings.Color= Android.Graphics.Color.Cyan;
                 annotationToolBar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Cyan);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.Cyan;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Cyan);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                annotationToolBar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            SetGreenRectangleAnnotation(Android.Graphics.Color.Cyan);
            SetGreenCircleAnnotation(Android.Graphics.Color.Cyan);
            SetGreenLineAnnotation(Android.Graphics.Color.Cyan);
            SetGreenArrowAnnotation(Android.Graphics.Color.Cyan);
            SetGreenFreeTextAnnotation(Android.Graphics.Color.Cyan);
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            m_shapeAnnot = null;
            m_freeTextAnnot = null;
            inkannot = null;
            signature = null;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Invisible;
            annotationBackGrid.Visibility = ViewStates.Invisible;
            annotationColorBarGrid.Visibility = ViewStates.Invisible;
            if (annotation != null)
                pdfViewerControl.RemoveAnnotation(annotation);
            else if (m_selectedStampAnnotation != null)
                pdfViewerControl.RemoveAnnotation(m_selectedStampAnnotation);
            IsAnnotationModeSelected = false;

            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            annotationToolBar.Visibility = ViewStates.Gone;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.PerformRedo();
            IsAnnotationModeSelected = false;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            annotationToolBar.Visibility = ViewStates.Gone;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.PerformUndo();
            IsAnnotationModeSelected = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            annotationToolBar.Visibility = ViewStates.Gone;
            m_shapeAnnoationToolbar.Visibility = ViewStates.Gone;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            IsAnnotationModeSelected = false;
            Stream stream1 = pdfViewerControl.SaveDocument();
            MemoryStream stream = stream1 as MemoryStream;
            string root = null;
            string fileName = backupDocumentName + ".pdf";
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);

            if (file.Exists()) file.Delete();
            Java.IO.FileOutputStream outs = new Java.IO.FileOutputStream(file);
            outs.Write(stream.ToArray());
            outs.Flush();
            outs.Close();

            AlertDialog.Builder alertDialog = new AlertDialog.Builder(mainView.Context);
            alertDialog.SetTitle("Save");
            alertDialog.SetMessage("The modified document is saved in the below location. " + "\n" + file.Path);
            alertDialog.SetPositiveButton("OK", (senderAlert, args) => { });
            Dialog dialog = alertDialog.Create();
            dialog.Show();

        }

        private void SelectedannotationColorButton_Click(object sender, EventArgs e)
        {
            annotationColorBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            if (annotationBarGrid.Visibility == ViewStates.Visible)
                annotationBarGrid.Visibility = ViewStates.Invisible;
            if (annotationBackButton.Visibility == ViewStates.Visible)
                annotationBackButton.Visibility = ViewStates.Invisible;
            if (annotationColorButton.Visibility == ViewStates.Visible)
                annotationColorButton.Visibility = ViewStates.Invisible;
        }

        private void PdfViewerControl_TextMarkupDeselected(object sender, TextMarkupDeselectedEventArgs args)
        {
            annotationColorBarGrid.Visibility = ViewStates.Gone;
           
            annotationButton.Visibility = ViewStates.Gone;
            annotationBackButton.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;

            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
	    annotationToolBar.Visibility = ViewStates.Gone;
        }

        private void PdfViewerControl_TextMarkupSelected(object sender, TextMarkupSelectedEventArgs args)
        {
            m_shapeAnnot = null;
            inkannot = null;
            signature = null;
            m_freeTextAnnot = null;
            annotation = (sender as TextMarkupAnnotation);
            annotationToolBar.Visibility = ViewStates.Visible;
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorButton.SetBackgroundColor(annotation.Settings.Color);
            removeButton.Visibility = ViewStates.Visible;
            annotationButton.Visibility = ViewStates.Gone;
            annotationBackButton.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;
           
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
          
        }

        private void PdfViewerControl_CanUndoModified(object sender, CanUndoModifiedEventArgs args)
        {
            if (args.CanUndo)
            {
                undoButton.SetTextColor(fontColor);
            }
            else
            {
                undoButton.SetTextColor(Color.Gray);
            }
        }

        private void PdfViewerControl_CanRedoModified(object sender, CanRedoModifiedEventArgs args)
        {
            if (args.CanRedo)
            {
                redoButton.SetTextColor(fontColor);
            }
            else
            {
                redoButton.SetTextColor(Color.Gray);
            }
        }

        public override void Destroy()
        {
            pdfViewerControl.Unload();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            base.Destroy();
        }
    }

    internal class MainViewLayoutListener : Java.Lang.Object, View.IOnLayoutChangeListener
    {
        internal CustomToolBarPdfViewerDemo sampleView;
        public void OnLayoutChange(View v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom)
        {
            if (sampleView.bookmarkToolbar != null && sampleView.pdfViewerControl != null)
            {
                if (!sampleView.IsDeviceTablet)
                {
                    if (!sampleView.isBookmarkVisible)
                    {
                        sampleView.pdfViewerControl.Layout(left, top, right, sampleView.m_bottomToolbars.Top);
                        sampleView.bookmarkToolbar.Layout(0, 0, 0, 0);
                    }
                    else
                    {
                        sampleView.pdfViewerControl.Layout(0, 0, 0, 0);
                        sampleView.bookmarkToolbar.Layout(left, top, right, bottom);
                    }
                }
                else
                {
                    if (!sampleView.isBookmarkVisible)
                    {
                        sampleView.pdfViewerControl.LayoutParameters = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.MatchParent, 1);
                        sampleView.bookmarkToolbarParentLayout.LayoutParameters = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.MatchParent, 0);
                    }
                    else
                    {
                        sampleView.pdfViewerControl.LayoutParameters = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.MatchParent, 3);
                        sampleView.bookmarkToolbarParentLayout.LayoutParameters = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.MatchParent, 2);
                    }
                }

                if (sampleView.stampSelectionView != null && !sampleView.IsDeviceTablet)
                {
                    if (!sampleView.stampSelectionView.isShowing)
                    {
                        sampleView.pdfViewerControl.Layout(left, top, right, sampleView.m_bottomToolbars.Top);
                        sampleView.stampSelectionView.Layout(0, 0, 0, 0);
                    }
                    else
                    {
                        
                        sampleView.stampSelectionView.Layout(left, top, right, bottom);
                    }
                }
            }
        }
    }
}
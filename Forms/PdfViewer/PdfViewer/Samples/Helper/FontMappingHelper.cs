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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfPdfViewer
{
    public class FontMappingHelper
    {
        public static string ContinuousPage = Device.RuntimePlatform == Device.Android ? "\uE700" : Device.RuntimePlatform == Device.iOS ? "\uE705" : "\uE705";

        public static string PageByPage = Device.RuntimePlatform == Device.Android ? "\uE701" : Device.RuntimePlatform == Device.iOS ? "\uE703" : "\uE703";

        public static string Bookmark = Device.RuntimePlatform == Device.Android ? "\uE700" : Device.RuntimePlatform == Device.iOS ? "\uE701" : "\uE703";

        internal static string BookmarkForward = "\uE704";

        internal static string BookmarkBackward = "\uE709";

        public static string ShowFile = Device.RuntimePlatform == Device.Android ? "\uE705" : Device.RuntimePlatform == Device.iOS ? "\uE71d" : "\uE720";

        public static string Back = Device.RuntimePlatform == Device.Android ? "\uE700" : Device.RuntimePlatform == Device.iOS ? "\uE71c" : "\uE70d";

        public static string Search = Device.RuntimePlatform == Device.Android ? "\uE708" : Device.RuntimePlatform == Device.iOS ? "\uE719" : "\uE71c";

        public static string Save = Device.RuntimePlatform == Device.Android ? "\uE70a" : Device.RuntimePlatform == Device.iOS ? "\uE718" : "\uE705";

        public static string Undo = Device.RuntimePlatform == Device.Android ? "\uE70c" : Device.RuntimePlatform == Device.iOS ? "\uE70a" : "\uE71f";

        public static string Underline = Device.RuntimePlatform == Device.Android ? "\uE70d" : Device.RuntimePlatform == Device.iOS ? "\uE70c" : "\uE721";

        public static string Redo = Device.RuntimePlatform == Device.Android ? "\uE70f" : Device.RuntimePlatform == Device.iOS ? "\uE716" : "\uE706";

        public static string StrikeThrough = Device.RuntimePlatform == Device.Android ? "\uE711" : Device.RuntimePlatform == Device.iOS ? "\uE71e" : "\uE709";

        public static string Highlight = Device.RuntimePlatform == Device.Android ? "\uE715" : Device.RuntimePlatform == Device.iOS ? "\uE710" : "\uE70c";

        public static string Select = Device.RuntimePlatform == Device.Android ? "\uE71c" : Device.RuntimePlatform == Device.iOS ? "\uE715" : "\uE70b";

        public static string Ink = Device.RuntimePlatform == Device.Android ? "\uE71d" : Device.RuntimePlatform == Device.iOS ? "\uE704" : "\uE704";

        public static string Delete = Device.RuntimePlatform == Device.Android ? "\uE71e" : Device.RuntimePlatform == Device.iOS ? "\uE714" : "\uE718";

        public static string Annotation = Device.RuntimePlatform == Device.Android ? "\uE720" : Device.RuntimePlatform == Device.iOS ? "\uE706" : "\uE708";

        public static string Previous = Device.RuntimePlatform == Device.Android ? "\uE70b" : Device.RuntimePlatform == Device.iOS ? "\uE708" : "\uE70f";

        public static string Next = Device.RuntimePlatform == Device.Android ? "\uE721" : Device.RuntimePlatform == Device.iOS ? "\uE70b" : "\uE700";

        public static string Close = Device.RuntimePlatform == Device.Android ? "\uE70e" : Device.RuntimePlatform == Device.iOS ? "\uE70f" : "\uE701";

        public static string SearchBack = Device.RuntimePlatform == Device.Android ? "\uE713" : Device.RuntimePlatform == Device.iOS ? "\uE71b" : "\uE702";

        public static string TextMarkup = Device.RuntimePlatform == Device.Android ? "\uE719" : Device.RuntimePlatform == Device.iOS ? "\uE70e" : "\uE719";

        public static string Thickness = Device.RuntimePlatform == Device.Android ? "\uE722" : Device.RuntimePlatform == Device.iOS ? "\uE722" : "\uE722";

        public static string FontSize = Device.RuntimePlatform == Device.Android ? "\uE700" : Device.RuntimePlatform == Device.iOS ? "\uE700" : "\uE700";

        public static string Transparent = Device.RuntimePlatform == Device.Android ? "\uE71a" : Device.RuntimePlatform == Device.iOS ? "\uE71a" : "\uE707";

        public static string EditText = Device.RuntimePlatform == Device.Android ? "\uE71f" : Device.RuntimePlatform == Device.iOS ? "\uE700" : "\uE71A";

        public static string EditTextFont = Device.RuntimePlatform == Device.Android ? "\uE71f" : Device.RuntimePlatform == Device.iOS ? "\uE700" : "\uE71A";

        public static string Stamp = Device.RuntimePlatform == Device.Android ? "\uE703" : Device.RuntimePlatform == Device.iOS ? "\uE701" : "\uE705";

        public static string Shape = Device.RuntimePlatform == Device.Android ? "\uE709" : Device.RuntimePlatform == Device.iOS ? "\uE721" : "\uE712";

        public static string Rectangle = Device.RuntimePlatform == Device.Android ? "\uE710" : Device.RuntimePlatform == Device.iOS ? "\uE705" : "\uE70e";
        public static string Circle = Device.RuntimePlatform == Device.Android ? "\uE714" : Device.RuntimePlatform == Device.iOS ? "\uE71f" : "\uE717";
        public static string Line = Device.RuntimePlatform == Device.Android ? "\uE703" : Device.RuntimePlatform == Device.iOS ? "\uE717" : "\uE71b";
        public static string Arrow = Device.RuntimePlatform == Device.Android ? "\uE701" : Device.RuntimePlatform == Device.iOS ? "\uE712" : "\uE70a";
        public static string Edit = Device.RuntimePlatform == Device.iOS ? "\uE720" : Device.RuntimePlatform == Device.Android ? "\uE71d" : "\uE710";
        public static string Signature = Device.RuntimePlatform == Device.Android ? "\uE701" : Device.RuntimePlatform == Device.iOS ? "\uE702" : "\uE700";
        public static string PageUp = "\uE723";
        public static string Moreoptions= Device.RuntimePlatform == Device.iOS ? "\uE702" : Device.RuntimePlatform == Device.Android ? "\uE714" : "\uE710";
        internal static string Print = Device.RuntimePlatform == Device.iOS ? "\uE700" : Device.RuntimePlatform == Device.Android ? "\uE701" : "\uE700";
        public static string PageDown = "\uE722";
        public static string EditTextFontFamily = Device.RuntimePlatform == Device.Android ?
            "Font size Font.ttf" :

            Device.RuntimePlatform == Device.iOS ?

            "Font size Font" :

            "/Assets/Fonts/Font size Font.ttf#Font size Font";


        public static string TextPath =

        Device.RuntimePlatform == Device.Android ?
            "PdfViewer_Text_font.ttf" :

            Device.RuntimePlatform == Device.iOS ?

            "PdfViewer_Text_font" :

            "/Assets/Fonts/PdfViewer_Text_font.ttf#PdfViewer_Text_font";

        public static string FontFamily =
            Device.RuntimePlatform == Device.Android ?

            "Final_PDFViewer_Android_FontUpdate.ttf" :

            Device.RuntimePlatform == Device.iOS ?

            "Final_PDFViewer_IOS_FontUpdate" :

            "/Assets/Fonts/Final_PDFViewer_UWP_FontUpdate.ttf#Final_PDFViewer_UWP_FontUpdate";

        public static string BookmarkFont =
            Device.RuntimePlatform == Device.Android ?

            "PdfViewer_FONT.ttf" :

            Device.RuntimePlatform == Device.iOS ?

            "PdfViewer_FONT" :

            "/Assets/Fonts/PdfViewer_FONT.ttf#PdfViewer_FONT";

        public static string printFont = Device.RuntimePlatform == Device.iOS ? "Font Print" : Device.RuntimePlatform == Device.Android ? "Font Print.ttf" : "/Assets/Fonts/Font Print.ttf#Font Print";
       
        public static string MoreOptionsFont =
            Device.RuntimePlatform == Device.Android ?

            "PDFViewer_Android.ttf" :

            Device.RuntimePlatform == Device.iOS ?

            "Final_PDFViewer_IOS_FontUpdate" :

            "/Assets/Fonts/PdfViewer_FONT.ttf#PdfViewer_FONT";

        public static string SignatureFont =
         Device.RuntimePlatform == Device.Android ?

         "Signature_PDFViewer_FONT.ttf" :

         Device.RuntimePlatform == Device.iOS ?

         "Signature_PDFViewer_FONT" :

         "/Assets/Fonts/Signature_PDFViewer_FONT.ttf#Signature_PDFViewer_FONT";

        public static string StampFont =
         Device.RuntimePlatform == Device.Android ?

         "Font Text edit stamp.ttf" :

         Device.RuntimePlatform == Device.iOS ?

         "Font Text edit stamp" :

         "/Assets/Fonts/Font Text edit stamp.ttf#Font Text edit stamp";

        public static string ViewModeFont = 
            Device.RuntimePlatform == Device.Android ? "Android Page icons.ttf" : 
            Device.RuntimePlatform == Device.iOS ? "Font Page icons" : "/Assets/Fonts/Font Page icons.ttf#Font Page icons";
    }
}

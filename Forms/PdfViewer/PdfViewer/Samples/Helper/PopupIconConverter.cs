#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfPdfViewer
{
    internal class PopupIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is PopupIcon icon)
            {
                switch (icon)
                {
                    case PopupIcon.Comment:  
                        return FontMappingHelper.Comment;
                    case PopupIcon.Note:
                        return FontMappingHelper.Note;
                    case PopupIcon.Help:
                        return FontMappingHelper.Help;
                    case PopupIcon.Key:
                        return FontMappingHelper.Key;
                    case PopupIcon.Paragraph:
                        return FontMappingHelper.Paragraph;
                    case PopupIcon.NewParagraph:
                            return FontMappingHelper.NewParagraph;
                    case PopupIcon.Insert:
                        return FontMappingHelper.Insert;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

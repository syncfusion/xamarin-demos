#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfRichTextEditor
{
    public partial class MailPage : SampleView
    {
        public MailPage()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                EntryFieldTo.Margin = EntryFieldSubject.Margin = new Thickness(16, 16, 16, 16);
            }

            RTE.Text = "<p>Hi,<br><br>The rich text editor component is WYSIWYG (\"what you see is what you get\") editor that provides the best user experience to create and update the content.Users can format their content using standard toolbar commands.<p>This Sample illustrates formatting related to <b>Bold</b>, <i>Italic</i>,<u> Underline</u>, <span style=\"background-color: rgb(255,255,0);\" > Highlight </span><span style=\"background-color: rgb(250,0,0); \">Colors </span>and <span style=\"color: rgb(255, 0, 0); text - decoration: inherit; \">Font </span><span style=\"color: blue; text - decoration: inherit; \"></span><span style=\"color: rgb(0,0,200); text - decoration: inherit; \">Colors </span>in Xamarin RTE control.<br></p>";
        }
    }
}
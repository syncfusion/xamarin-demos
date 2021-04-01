#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.RichTextEditor;
using System.Globalization;
using System.Resources;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfRichTextEditor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Themes : SampleView
    {
        public Themes()
        {
            InitializeComponent();

#if COMMONSB
            RichTextEditorResourceManager.Manager = new ResourceManager("SampleBrowser.Samples.RichTextEditor.Resources.Syncfusion.SfRichTextEditor.XForms", Application.Current.GetType().Assembly);
#else
            RichTextEditorResourceManager.Manager = new ResourceManager("SampleBrowser.SfRichTextEditor.Resources.Syncfusion.SfRichTextEditor.XForms", Application.Current.GetType().Assembly);
#endif
            if (Device.RuntimePlatform != Device.UWP)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            else
            {
                CultureInfo.CurrentUICulture = new CultureInfo("en-US");
            }

            RTE.Text = "<p>Hi,<br><br>The rich text editor component is WYSIWYG (\"what you see is what you get\") editor that provides the best user experience to create and update the content.</p>";
        }
    }
}
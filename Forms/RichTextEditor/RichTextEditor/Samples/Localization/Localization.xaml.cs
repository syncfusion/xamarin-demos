#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.RichTextEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfRichTextEditor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Localization : SampleView
    {
        public Localization()
        {
            InitializeComponent();
        }

        private void localePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            string text = "";
            if (picker.SelectedItem.Equals("Japanese"))
            {
                text = "<p>こんにちは、<br><br>リッチテキストエディターコンポーネントは、コンテンツを作成および更新するための最高のユーザーエクスペリエンスを提供するWYSIWYG（\"あなたが見るものはあなたが得るもの\"）エディターです。</p>";
                this.ChangedLanguage("ja-JP", text);
            }
            if (picker.SelectedItem.Equals("English"))
            {
                text = "<p>Hi,<br><br>The rich text editor component is WYSIWYG (\"what you see is what you get\") editor that provides the best user experience to create and update the content.</p>";
                this.ChangedLanguage("en-US", text);
            }
            if (picker.SelectedItem.Equals("German"))
            {
                text = "<p>Hallo,<br><br>Die Rich-Text-Editor-Komponente ist der WYSIWYG-Editor (\"Was Sie sehen, ist was Sie erhalten\"), der die beste Benutzererfahrung beim Erstellen und Aktualisieren des Inhalts bietet.</p>";
                this.ChangedLanguage("de-DE", text);
            }
            if (picker.SelectedItem.Equals("Spanish"))
            {
                text = "<p>Hola,<br><br>El componente del editor de texto enriquecido es el editor WYSIWYG (\"lo que ves es lo que obtienes \") que proporciona la mejor experiencia de usuario para crear y actualizar el contenido.</p>";
                this.ChangedLanguage("es-ES", text);
            }
        }

        void ChangedLanguage(string name, string text)
        {
            grid.Children.Clear();
#if COMMONSB
            RichTextEditorResourceManager.Manager = new ResourceManager("SampleBrowser.Samples.RichTextEditor.Resources.Syncfusion.SfRichTextEditor.XForms", Application.Current.GetType().Assembly);
#else
            RichTextEditorResourceManager.Manager = new ResourceManager("SampleBrowser.SfRichTextEditor.Resources.Syncfusion.SfRichTextEditor.XForms", Application.Current.GetType().Assembly);
#endif
            if (Device.RuntimePlatform != Device.UWP)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            }
            else
            {
                CultureInfo.CurrentUICulture = new CultureInfo(name);
            }

            Syncfusion.XForms.RichTextEditor.SfRichTextEditor sfRichTextEditor = new Syncfusion.XForms.RichTextEditor.SfRichTextEditor();
            sfRichTextEditor.ToolbarOptions = ToolbarOptions.Alignment | ToolbarOptions.Bold | ToolbarOptions.BulletList | ToolbarOptions.ClearFormat | ToolbarOptions.DecreaseIndent | ToolbarOptions.FontColor | ToolbarOptions.FontSize | ToolbarOptions.HighlightColor | ToolbarOptions.Hyperlink | ToolbarOptions.IncreaseIndent | ToolbarOptions.Italic | ToolbarOptions.NumberList | ToolbarOptions.ParagraphFormat | ToolbarOptions.Redo | ToolbarOptions.Underline | ToolbarOptions.Undo;
            sfRichTextEditor.VerticalOptions = LayoutOptions.FillAndExpand;
            sfRichTextEditor.HorizontalOptions = LayoutOptions.FillAndExpand;
            sfRichTextEditor.Text = text;
            grid.Children.Add(sfRichTextEditor);
        }
    }
}
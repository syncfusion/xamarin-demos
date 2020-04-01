#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using SampleBrowser.SfRichTextEditor.Samples;
using Syncfusion.XForms.RichTextEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfRichTextEditor
{
    public partial class MailPage : SampleView
    {
        public MailPage()
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

            if (Device.RuntimePlatform == Device.iOS)
            {
                EntryFieldTo.Margin = EntryFieldSubject.Margin = new Thickness(16, 16, 16, 16);
            }

            RTE.Text = "<p>Hi,<br><br>The rich text editor component is WYSIWYG (\"what you see is what you get\") editor that provides the best user experience to create and update the content.Users can format their content using standard toolbar commands.<p>This Sample illustrates formatting related to <b>Bold</b>, <i>Italic</i>,<u> Underline</u>, <span style=\"background-color: rgb(255,255,0);\" > Highlight </span><span style=\"background-color: rgb(250,0,0); \">Colors </span>and <span style=\"color: rgb(255, 0, 0); text - decoration: inherit; \">Font </span><span style=\"color: blue; text - decoration: inherit; \"></span><span style=\"color: rgb(0,0,200); text - decoration: inherit; \">Colors </span>in Xamarin RTE control.<br></p>";
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        Stream boogalooFontStream, handleeFontStream, kaushanFontStream, pinyonFontStream, robotoFontStream;
        public ICommand FontCommand { get; set; }
        public ICommand ImageCommand { get; set; }

        public ViewModel()
        {
            var assembly = Assembly.GetAssembly(Application.Current.GetType());
#if COMMONSB
            boogalooFontStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.RichTextEditor.Fonts.Boogaloo.ttf");
            handleeFontStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.RichTextEditor.Fonts.Handlee.ttf");
            kaushanFontStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.RichTextEditor.Fonts.Kaushan Script.ttf");
            pinyonFontStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.RichTextEditor.Fonts.Pinyon Script.ttf");
            robotoFontStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.RichTextEditor.Fonts.Roboto-Regular.ttf");
#else
            boogalooFontStream = assembly.GetManifestResourceStream("SampleBrowser.SfRichTextEditor.Fonts.Boogaloo.ttf");
            handleeFontStream = assembly.GetManifestResourceStream("SampleBrowser.SfRichTextEditor.Fonts.Handlee.ttf");
            kaushanFontStream = assembly.GetManifestResourceStream("SampleBrowser.SfRichTextEditor.Fonts.Kaushan Script.ttf");
            pinyonFontStream = assembly.GetManifestResourceStream("SampleBrowser.SfRichTextEditor.Fonts.Pinyon Script.ttf");
            robotoFontStream = assembly.GetManifestResourceStream("SampleBrowser.SfRichTextEditor.Fonts.Roboto-Regular.ttf");
#endif
            ImageCommand = new Command<object>(LoadImage);
            FontCommand = new Command<object>(LoadFonts);
        }

        void LoadFonts(object obj)
        {
            FontButtonClickedEventArgs fontEventArgs = (obj as FontButtonClickedEventArgs);
            if (!fontEventArgs.FontStreamCollection.ContainsKey("Boogaloo"))
                fontEventArgs.FontStreamCollection.Add("Boogaloo", boogalooFontStream);
            if (!fontEventArgs.FontStreamCollection.ContainsKey("Handlee"))
                fontEventArgs.FontStreamCollection.Add("Handlee", handleeFontStream);
            if (!fontEventArgs.FontStreamCollection.ContainsKey("Kaushan Script"))
                fontEventArgs.FontStreamCollection.Add("Kaushan Script", kaushanFontStream);
            if (!fontEventArgs.FontStreamCollection.ContainsKey("Pinyon Script"))
                fontEventArgs.FontStreamCollection.Add("Pinyon Script", pinyonFontStream);
        }

        void LoadImage(object obj)
        {
            ImageInsertedEventArgs imageInsertedEventArgs = (obj as ImageInsertedEventArgs);
            this.GetImage(imageInsertedEventArgs);
        }

        async void GetImage(ImageInsertedEventArgs imageInsertedEventArgs)
        {
            using (Stream imageStream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync())
            {
                if (imageStream != null)
                {
                    Syncfusion.XForms.RichTextEditor.ImageSource imageSource = new Syncfusion.XForms.RichTextEditor.ImageSource();
                    imageSource.ImageStream = imageStream;
                    imageInsertedEventArgs.ImageSourceCollection.Add(imageSource);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfImageEditor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Themes : SampleView
    {
        public Themes()
        {
            InitializeComponent();
            var assembly = typeof(ImageSerializeModel).GetTypeInfo().Assembly;
#if COMMONSB
            imageEditor.Source = ImageSource.FromResource("SampleBrowser.Icons.EditorPerson1.png", assembly);
#else
            imageEditor.Source = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.EditorPerson1.png", assembly);
#endif
        }
    }
}
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
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using SampleBrowser.SfImageEditor.UWP.Renderers;
using CustomControls = SampleBrowser.SfImageEditor.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Button = Xamarin.Forms.Button;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using System.IO;

[assembly: ExportRenderer(typeof(CustomControls.CustomButton), typeof(CustomButtonRenderer))]
[assembly:ExportRenderer(typeof(CustomControls.CustomEditor), typeof(CustomEditorRenderer))]
[assembly:ExportRenderer(typeof(CustomControls.RoundedColorButton), typeof(ColorButtonRenderer))]
[assembly: Dependency(typeof(CustomImageView))]
namespace SampleBrowser.SfImageEditor.UWP.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        CustomControls.CustomEditor editor;

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var element = (CustomControls.CustomEditor) e.NewElement;
                if (element == null)
                    return;
                editor = element;
                Control.Loaded += Control_Loaded;
                Control.Foreground = new SolidColorBrush(Colors.Black);
                Control.Text = element.WatermarkText;
                Control.GotFocus += Control_GotFocus;
                if (Device.Idiom == TargetIdiom.Desktop)
                {
                    Control.Height = 33;
                }
                Control.VerticalContentAlignment = VerticalAlignment.Center;
                Control.TextAlignment = Windows.UI.Xaml.TextAlignment.Center;
            }
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            //var text = sender as TextBox;
            //text.Style = App.Current.Resources["CustomTextBoxStyle"] as Windows.UI.Xaml.Style;
        }

        private void Control_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.SelectAll();
            textBox.TextChanged += TextBox_TextChanged;
        }

        protected override void Dispose(bool disposing)
        {

        }

        private void TextBox_TextChanged(object sender, Windows.UI.Xaml.Controls.TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == editor.WatermarkText)
                textBox.Text = string.Empty;
        }
    }

    public class ColorButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var element = e.NewElement as CustomControls.RoundedColorButton;
                element.SizeChanged += (s, args) =>
                {
                    Control.ApplyTemplate();
                    var grids = Control.GetVisuals<Windows.UI.Xaml.Controls.Grid>();
                    foreach (var grid in grids)
                    {
                        grid.Width = 150;
                        grid.Height = 40;
                        grid.CornerRadius = new Windows.UI.Xaml.CornerRadius(15);
                    }
                };
            }
        }
    }
    static class DependencyObjectExtensions
    {
        public static IEnumerable<T> GetVisuals<T>(this DependencyObject root)
            where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(root);

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);

                if (child is T)
                    yield return child as T;

                foreach (var descendants in child.GetVisuals<T>())
                {
                    yield return descendants;
                }
            }
        }
    }
    public class CustomImageView : ICustomViewDependencyService
    {
        public object GetCustomView(string imageName, object context)
        {
            Windows.UI.Xaml.Controls.Image svgimage = new Windows.UI.Xaml.Controls.Image()
            { Height = 200, Width = 200 };
            svgimage.Source = new SvgImageSource(new Uri("ms-appx:///Assets/" + imageName + ".svg", UriKind.Absolute));
            return svgimage;
        }

        public async Task<Stream> GetImageSource(string uri)
        {
            StorageFile imagefile = await StorageFile.GetFileFromPathAsync(uri);
            IRandomAccessStream stream = await imagefile.OpenAsync(FileAccessMode.Read);
            return stream.AsStream();
        }
    }

    // Applies font text color as white for the buttons in the customization sample
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                #if !COMMONSB
                Control.Style = SampleBrowser.SfImageEditor.UWP.App.Current.Resources["CustomButtonStyle"] as Windows.UI.Xaml.Style;
                #endif
            }
        }
    }
}

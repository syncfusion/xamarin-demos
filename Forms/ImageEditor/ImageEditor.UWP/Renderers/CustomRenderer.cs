#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
                Control.Foreground = new SolidColorBrush(Colors.White);
                Control.Text = element.WatermarkText;
                Control.GotFocus += Control_GotFocus;
                Control.VerticalContentAlignment = VerticalAlignment.Center;
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
                        grid.Width = 30;
                        grid.Height = 30;
                        grid.CornerRadius = new CornerRadius(15);
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
    }
  
}

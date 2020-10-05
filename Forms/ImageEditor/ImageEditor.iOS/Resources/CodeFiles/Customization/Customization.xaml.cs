#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.SfImageEditor.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfImageEditor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Customization : SampleView
    {
        bool isOpen;
        bool isPath;
        double height = 0, width = 0;
        void Redo(object sender, System.EventArgs e)
        {
            imageEditor.Redo();
            if (model.RedoCount > 0)
                model.RedoCount--;
            model.UndoCount++;
        }


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Device.RuntimePlatform.ToLower() == "uwp") return;
            if ((width != this.width || height != this.height) && (width > -1 || height > -1))
            {
                this.width = width;
                this.height = height;
                if (width < height)
                {
                    if (Device.Idiom == TargetIdiom.Phone)
                    {
                        captionTextBox.Margin = new Thickness(5, 0, 0, 0);
                        shareButton.Margin = new Thickness(0);
                        colorPalette.Padding = new Thickness(0);
                    }
                    else
                        captionTextBox.Margin = new Thickness(50, 0, 50, 0);
                }
                else
                {
                    if (Device.Idiom == TargetIdiom.Phone)
                    {
                        captionTextBox.Margin = new Thickness(75, 0, 50, 0);
                        shareButton.Margin = new Thickness(0, 0, 50, 0);
                        colorPalette.Padding = new Thickness(0, 20, 0, 20);
                    }
                    else
                    {
                        captionTextBox.Margin = new Thickness(200, 0, 200, 0);
                        shareButton.Margin=new Thickness(0, 0, 50, 0);
                    }
                }
            }
        }


        void ColorClicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            var color = button.BackgroundColor;
            if (isPath)
            {
                imageEditor.AddShape(ShapeType.Path, new PenSettings() { Color = color });
            }
            else
            {
                if (Settings is PenSettings)
                {
                    (Settings as PenSettings).Color = color;
                }
                else
                {
                    (Settings as TextSettings).Color = color;
                }
            }
            model.UndoCount++;
            if (!model.IsImageEdited)
                model.IsImageEdited = true;
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            model.DetectTouch();
            OpenToolbar();
        }

        void Reset(object sender, System.EventArgs e)
        {
            imageEditor.Reset();
            model.UndoCount = 0;
            model.RedoCount = 0;
            model.IsTouched = false;
            CloseToolbar();
            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                CloseColorPalette();
            model.IsColorPaletteVisible = false;
            isOpen = false;
            model.IsImageEdited = false;
        }

        void DoodleDraw(object sender, System.EventArgs e)
        {
            isPath = true;
            if (!isOpen)
            {
                OpenColorPalette();
                isOpen = true;
            }
            model.IsColorPaletteVisible = true;
            imageEditor.AddShape();
        }

        void AddText(object sender, System.EventArgs e)
        {
            isPath = false;
            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                if (!isOpen)
                {
                    OpenColorPalette();
                    isOpen = true;
                }
            }

            model.IsColorPaletteVisible = true;
            imageEditor.AddText("Text");
        }

        void AddRect(object sender, System.EventArgs e)
        {
            isPath = false;
            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                if (!isOpen)
                {
                    OpenColorPalette();
                    isOpen = true;
                }
            }
            model.IsColorPaletteVisible = true;
            imageEditor.AddShape(ShapeType.Rectangle);
        }

        void Undo(object sender, System.EventArgs e)
        {
            if (imageEditor.IsImageEdited || Device.RuntimePlatform == Device.UWP)
            {
                imageEditor.Undo();
                if (model.UndoCount > 0)
                    model.UndoCount--;
                model.RedoCount++;
            }
        }


        void Share(object sender, System.EventArgs e)
        {
            Share();
        }
        void OpenToolbar()
        {
            toolbarGrid.TranslateTo(0, 20, 400, Easing.Linear);
        }

        void CloseToolbar()
        {
            toolbarGrid.TranslateTo(0, -70, 400, Easing.Linear);
        }

        ImageModel model;

        void CloseColorPalette()
        {
            colorPalette.TranslateTo(this.Width, 0, 200, Easing.Linear);
        }

        void OpenColorPalette()
        {
            colorPalette.TranslateTo((-this.Width + 2 * colorPalette.Width) / 20, 0, 200, Easing.Linear);
        }

        async void Share()
        {
            imageEditor.Save();
            imageEditor.ImageSaved += (sender, args) =>
            {
                location = args.Location;
            };
            await DelayActionAsync(1000, Sharing);
        }

        public async Task DelayActionAsync(int delay, Action action)
        {
            await Task.Delay(delay);

            action();
        }

        void Sharing()
        {
            var temp = location;
            var share = DependencyService.Get<IShare>();
            if (string.IsNullOrEmpty(captionTextBox.Text))
            {

            }
            share.Show("Title", string.IsNullOrEmpty(captionTextBox.Text) ? "Message" : captionTextBox.Text.ToString(), temp);
        }

        private string location = "";

        public Customization()
        {
            model = new ImageModel();
            this.BindingContext = model;
            InitializeComponent();
            Assembly assembly = typeof(ImageSerializeModel).GetTypeInfo().Assembly;
            #if COMMONSB
            imageEditor.Source = ImageSource.FromResource("SampleBrowser.Icons.EditorTable.jpg", assembly);
            #else
            imageEditor.Source = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.EditorTable.jpg", assembly);
            #endif
            imageEditor.ToolbarSettings = new ToolbarSettings() { IsVisible = false };
            imageEditor.ItemSelected += ImageEditor_ItemSelected;
            imageEditor.ItemUnselected += ImageEditor_ItemUnselected;
            if (Device.RuntimePlatform != Device.Android && Device.RuntimePlatform != Device.iOS)
            {
				resetButton.Text = "\ue74a";
				redoButton.Text = "\ue739";
				undoButton.Text = "\ue716";
				rectButton.Text = "\ue701";
				textButton.Text = "\ue749";
				penButton.Text = "\ue747";
				shareButton.Text = "\ue751";
				captionTextBox.TextColor = Color.Black;
            }
        }

        private object Settings;

        private void ImageEditor_ItemSelected(object sender, ItemSelectedEventArgs args)
        {
            Settings = args.Settings;
            OpenColorPalette();
        }

        private void ImageEditor_ItemUnselected(object sender, ItemUnselectedEventArgs e)
        {
            CloseColorPalette();
            isOpen = false;
        }

        private void ShareButton_OnClicked(object sender, EventArgs e)
        {
            Share();
        }
    }

    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }

    public class CountToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value > 0)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(bool)value)
                return 0;
            return 1;
        }
    }
}
#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using Syncfusion.SfImageEditor.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfImageEditor
{
    public partial class ProfileEditPage : ContentPage
    {
        ProfileEditorViewModel ViewModel;
        public ProfileEditPage(ProfileEditorViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;

            if (viewModel.ByteArray == null)
            {
                imageEditor.Source = viewModel.ProfilePicture;
            }
            else
            {
                imageEditor.Source = ImageSource.FromStream(() => new MemoryStream(ViewModel.ByteArray));
            }

            imageEditor.SetToolbarItemVisibility("Text, Shape, Brightness, Effects, Bradley Hand, Path, 3:1, 3:2, 4:3, 5:4, 16:9, Undo, Redo, Transform", false);
            
            imageEditor.ToolbarSettings.ToolbarItems.Add(new FooterToolbarItem() { Text = "Crop" });
            
            imageEditor.ImageLoaded += ImageEditor_ImageLoaded;
            imageEditor.ImageSaving += ImageEditor_ImageSaving;
            imageEditor.ToolbarSettings.ToolbarItemSelected += ToolbarSettings_ToolbarItemSelected;
        }

        private void ImageEditor_ImageLoaded(object sender, ImageLoadedEventArgs args)
        {
            imageEditor.ToggleCropping(true, 3);
        }

        private void ToolbarSettings_ToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
        {
            if (e.ToolbarItem.Text == "Crop")
            {
                imageEditor.ToggleCropping(true, 3);
                e.Cancel = true;
            }
        }

        private void ImageEditor_ImageSaving(object sender, ImageSavingEventArgs args)
        {
            ViewModel.ByteArray = GetImageStreamAsBytes(args.Stream);
            args.Cancel = true;
            Navigation.PopAsync();
        }

        private byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }   

}

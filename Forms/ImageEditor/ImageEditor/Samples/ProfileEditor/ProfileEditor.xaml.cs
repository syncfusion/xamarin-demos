#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfImageEditor
{
    public partial class ProfileEditor : SampleView
    {
        public ProfileEditor()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfileEditPage(ViewModel));
        }

    }   

    public class ProfileEditorViewModel : INotifyPropertyChanged
    {
        public ProfileEditorViewModel()
        {
            Assembly assembly = typeof(ImageSerializeModel).GetTypeInfo().Assembly;

#if COMMONSB
            ProfilePicture = ImageSource.FromResource("SampleBrowser.Icons.Profile.png", assembly);
#else
            ProfilePicture = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.Profile.png", assembly);
#endif
            Details = new List<ProfileModel>();
            Details.Add(new ProfileModel() { Icon = "\ue72a", Field = "Name", Content = "Alison Doody" });
            Details.Add(new ProfileModel() { Icon = "\ue725", Field = "Email", Content = "alison.doody@syncfusion.com" });
            Details.Add(new ProfileModel() { Icon = "\ue766", Field = "Phone", Content = "+1-123-456-7890" });
            Details.Add(new ProfileModel() { Icon = "\ue757", Field = "Address", Content = "Avenue 2nd street, NW SY" });
        }

        private ImageSource profilePicture;

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageSource ProfilePicture
        {
            get
            {
                return profilePicture;
            }
            set
            {
                profilePicture = value;
                RaisePropertyChanged("ProfilePicture");
            }
        }

        private byte[] byteArray;

        public byte[] ByteArray
        {
            get { return byteArray; }
            set 
            {
                byteArray = value;

                ProfilePicture = ImageSource.FromStream(() => new MemoryStream(value));
            }
        }

        public List<ProfileModel> Details { get; set; }

        void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }

    public class ProfileModel
    {
        public string Icon { get; set; }

        public string Field { get; set; }

        public string Content { get; set; }
    }
}

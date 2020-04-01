#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.SfImageEditor
{
    public class SerializationViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SerializationModel> ModelList
        {
            get;
            set;
        }
        public SerializationViewModel()
        {
            Assembly assembly = typeof(ImageSerializeModel).GetTypeInfo().Assembly;
            ModelList = new ObservableCollection<SerializationModel>
            {
#if COMMONSB
                new SerializationModel { Location = "SampleBrowser.Icons.Editor_CreateNew.png", Strm = null, SelectionImage = ImageSource.FromResource("SampleBrowser.Icons.NotSelected.png", assembly), ImageName = "CreateNew", HorizontalOption = LayoutOptions.Center, VerticalOption = LayoutOptions.Center, Visibility = "false", CreateNewvisibility = "true", Height = 50, BackGround = Color.FromHex("#065DC7"), SelectedImageVisibility = "false" },
                new SerializationModel { Location = "SampleBrowser.Icons.EditorChart.jpg", Strm = null, SelectionImage = ImageSource.FromResource("SampleBrowser.Icons.NotSelected.png", assembly), Imagestream = "SampleBrowser.Icons.Chart.txt", ImageName = "Chart", HorizontalOption = LayoutOptions.FillAndExpand, VerticalOption = LayoutOptions.FillAndExpand, Visibility = "true", Height = 50, BackGround = Color.FromHex("#D3D3D3"), CreateNewvisibility = "false", SelectedImageVisibility = "false", SelectedItemThickness = new Thickness(0, 0, 0, 0) },
                new SerializationModel { Location = "SampleBrowser.Icons.EditorVenn.jpg", Strm = null, SelectionImage = ImageSource.FromResource("SampleBrowser.Icons.NotSelected.png", assembly), Imagestream = "SampleBrowser.Icons.Venn.txt", ImageName = "Venn Diagram", HorizontalOption = LayoutOptions.FillAndExpand, VerticalOption = LayoutOptions.FillAndExpand, Visibility = "true", Height = 50, BackGround = Color.FromHex("#D3D3D3"), CreateNewvisibility = "false", SelectedImageVisibility = "false", SelectedItemThickness = new Thickness(0, 0, 0, 0) },
                new SerializationModel { Location = "SampleBrowser.Icons.EditorFreeHand.jpg", Strm = null, SelectionImage = ImageSource.FromResource("SampleBrowser.Icons.NotSelected.png", assembly), Imagestream = "SampleBrowser.Icons.FreeHand.txt", ImageName = "Freehand", HorizontalOption = LayoutOptions.FillAndExpand, VerticalOption = LayoutOptions.FillAndExpand, Visibility = "true", Height = 50, BackGround = Color.FromHex("#D3D3D3"), CreateNewvisibility = "false", SelectedImageVisibility = "false", SelectedItemThickness = new Thickness(0, 0, 0, 0) },
#else
                new SerializationModel {  Location = "SampleBrowser.SfImageEditor.Icons.Editor_CreateNew.png", Strm = null, SelectionImage = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.NotSelected.png", assembly), ImageName = "CreateNew", HorizontalOption = LayoutOptions.Center, VerticalOption = LayoutOptions.Center, Visibility = "false", CreateNewvisibility = "true", Height = 50, BackGround = Color.FromHex("#065DC7"), SelectedImageVisibility = "false" },
                new SerializationModel {  Location = "SampleBrowser.SfImageEditor.Icons.EditorChart.jpg", Strm = null, SelectionImage = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.NotSelected.png", assembly), Imagestream = "SampleBrowser.SfImageEditor.Icons.Chart.txt", ImageName = "Chart", HorizontalOption = LayoutOptions.FillAndExpand, VerticalOption = LayoutOptions.FillAndExpand, Visibility = "true", Height = 50, BackGround = Color.FromHex("#D3D3D3"), CreateNewvisibility = "false", SelectedImageVisibility = "false", SelectedItemThickness = new Thickness(0, 0, 0, 0) },
                new SerializationModel {  Location = "SampleBrowser.SfImageEditor.Icons.EditorVenn.jpg", Strm = null, SelectionImage = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.NotSelected.png", assembly), Imagestream = "SampleBrowser.SfImageEditor.Icons.Venn.txt", ImageName = "Venn Diagram", HorizontalOption = LayoutOptions.FillAndExpand, VerticalOption = LayoutOptions.FillAndExpand, Visibility = "true", Height = 50, BackGround = Color.FromHex("#D3D3D3"), CreateNewvisibility = "false", SelectedImageVisibility = "false", SelectedItemThickness = new Thickness(0, 0, 0, 0) },
                new SerializationModel {  Location = "SampleBrowser.SfImageEditor.Icons.EditorFreeHand.jpg", Strm = null, SelectionImage = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.NotSelected.png", assembly), Imagestream = "SampleBrowser.SfImageEditor.Icons.FreeHand.txt", ImageName = "Freehand", HorizontalOption = LayoutOptions.FillAndExpand, VerticalOption = LayoutOptions.FillAndExpand, Visibility = "true", Height = 50, BackGround = Color.FromHex("#D3D3D3"), CreateNewvisibility = "false", SelectedImageVisibility = "false", SelectedItemThickness = new Thickness(0, 0, 0, 0) },
#endif

            };
    }





        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }

    public class SerializationModel : INotifyPropertyChanged
    {
        private ImageSource name;
        public ImageSource Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");

            }
        }

        public Stream iOSStream;

        private string _imagestream;
        public string Imagestream
        {
            get { return _imagestream; }
            set
            {
                _imagestream = value;
                RaisePropertyChanged("Imagestream");
            }
        }


        private LayoutOptions _horizontalOption;
        public LayoutOptions HorizontalOption
        {
            get { return _horizontalOption; }
            set
            {
                _horizontalOption = value;
                RaisePropertyChanged("HorizontalOption");
            }
        }

        private LayoutOptions _verticalOption;
        public LayoutOptions VerticalOption
        {
            get { return _verticalOption; }
            set
            {
                _verticalOption = value;
                RaisePropertyChanged("VerticalOption");
            }
        }

        private string _visibility;
        public string Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                RaisePropertyChanged("Visibility");
            }
        }

        private string _createNewvisibility;
        public string CreateNewvisibility
        {
            get { return _createNewvisibility; }
            set
            {
                _createNewvisibility = value;
                RaisePropertyChanged("CreateNewvisibility");
            }
        }



        private Color _backGround;
        public Color BackGround
        {
            get { return _backGround; }
            set
            {
                _backGround = value;
                RaisePropertyChanged("BackGround");
            }
        }

        private Stream _stream=null;
        public Stream Strm
        {
            get { return _stream; }
            set
            {
                _stream = value;
                RaisePropertyChanged("Strm");
            }
        }


        private string _imageName;
        public string ImageName
        {
            get { return _imageName; }
            set
            {
                _imageName = value;
                RaisePropertyChanged("ImageName");
            }
        }

        private int _height;
        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
                RaisePropertyChanged("Height");
            }
        }


        private ImageSource _selectionImage;
        public ImageSource SelectionImage
        {
            get { return _selectionImage; }
            set
            {
                _selectionImage = value;
                RaisePropertyChanged("SelectionImage");

            }
        }


        internal void SetLocation(string value)
        {
            DependencyService.Get<IFileToStream>().LoadSampleStream(value, this);
        }

        private string location = String.Empty;
        public string Location
        {
            get { return location; }
            set
            {

                location = value;
                RaisePropertyChanged("Location");

            }
        }

        private string _selectedImageVisibility;
        public string SelectedImageVisibility
        {
            get { return _selectedImageVisibility; }
            set
            {
                _selectedImageVisibility = value;
                RaisePropertyChanged("SelectedImageVisibility");
            }
        }

        private Thickness _selectedItemThickness;
        public Thickness SelectedItemThickness
        {
            get { return _selectedItemThickness; }
            set
            {
                _selectedItemThickness = value;
                RaisePropertyChanged("SelectedItemThickness");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }

    public class ImageEditorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var location = value.ToString();
            if(location!=null && location.StartsWith("SampleBrowser"))
            {
                Assembly assembly = typeof(ImageSerializeModel).GetTypeInfo().Assembly;
                return ImageSource.FromResource(location, assembly);
            }
            if (!string.IsNullOrEmpty(location) && Device.RuntimePlatform == Device.iOS)
                return ImageSource.FromStream(() => DependencyService.Get<IFileToStream>().LoadSampleStream(location));
            if (!string.IsNullOrEmpty(location) && Device.RuntimePlatform == Device.UWP)
                return ImageSource.FromStream(() => DependencyService.Get<ICustomViewDependencyService>().GetImageSource(location).Result);
            return value != null ? ImageSource.FromFile(location) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}

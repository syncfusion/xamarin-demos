using System.Collections.ObjectModel;
using System.ComponentModel;
using UIKit;
namespace SampleBrowser
{
    public class FileManager : INotifyPropertyChanged
    {

        private string fileName;
        private UIImage imageIcon;
        private ObservableCollection<FileManager> subFolder;

        public ObservableCollection<FileManager> SubFolder
        {
            get { return subFolder; }
            set
            {
                subFolder = value;
                RaisedOnPropertyChanged("SubFolder");
            }
        }

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisedOnPropertyChanged("FileName");
            }
        }
        public UIImage ImageIcon
        {
            get { return imageIcon; }
            set
            {
                imageIcon = value;
                RaisedOnPropertyChanged("ImageIcon");
            }
        }
        public FileManager()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }
    }
}
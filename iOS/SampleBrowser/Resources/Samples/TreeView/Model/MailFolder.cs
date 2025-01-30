using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SampleBrowser
{
    public class MailFolder : INotifyPropertyChanged
    {

        private string folderName;
        private int mailsCount;
        private ObservableCollection<MailFolder> subFolder;

        public ObservableCollection<MailFolder> SubFolder
        {
            get { return subFolder; }
            set
            {
                subFolder = value;
                RaisedOnPropertyChanged("SubFolder");
            }
        }

        public string FolderName
        {
            get { return folderName; }
            set
            {
                folderName = value;
                RaisedOnPropertyChanged("FolderName");
            }
        }
        public int MailsCount
        {
            get { return mailsCount; }
            set
            {
                mailsCount = value;
                RaisedOnPropertyChanged("MailsCount");
            }
        }
        public MailFolder()
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
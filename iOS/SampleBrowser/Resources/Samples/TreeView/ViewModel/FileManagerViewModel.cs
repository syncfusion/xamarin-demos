#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using UIKit;

namespace SampleBrowser
{
    public class FileManagerViewModel
    {
        public ObservableCollection<FileManager> Folders { get; set; }

        public FileManagerViewModel()
        {
            GenerateFiles();
        }

        private void GenerateFiles()
        {
            var doc = new FileManager() { FileName = "Documents", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_folder.png") };
            var download = new FileManager() { FileName = "Downloads", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_folder.png") };
            var mp3 = new FileManager() { FileName = "Music", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_folder.png") };
            var pics = new FileManager() { FileName = "Pictures", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_folder.png") };
            var videos = new FileManager() { FileName = "Videos", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_folder.png") };

            var polution = new FileManager() { FileName = "Environmental Pollution.docx", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_word.png") };
            var globalWarming = new FileManager() { FileName = "Global Warming.ppt", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_ppt.png") };
            var sanitation = new FileManager() { FileName = "Sanitation.docx", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_word.png") };
            var socialnetwork = new FileManager() { FileName = "Social Network.pdf", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_pdf.png") };
            var youthempower = new FileManager() { FileName = "Youth Empowerment.pdf", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_pdf.png") };

            var game = new FileManager() { FileName = "Game.exe", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_exe.png") };
            var tutorials = new FileManager() { FileName = "Tutorials.zip", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_zip.png") };
            var typescript = new FileManager() { FileName = "TypeScript.7z", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_zip.png") };
            var uiguide = new FileManager() { FileName = "UI-Guide.pdf", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_pdf.png") };

            var song = new FileManager() { FileName = "Gouttes", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_mp3.png") };

            var camera = new FileManager() { FileName = "Camera Roll", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_folder.png") };
            var stone = new FileManager() { FileName = "Stone.jpg", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_png.png") };
            var wind = new FileManager() { FileName = "Wind.jpg", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_png.png") };

            var img0 = new FileManager() { FileName = "WIN_20160726_094117.JPG", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_img0.png") };
            var img1 = new FileManager() { FileName = "WIN_20160726_094118.JPG", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_img1.png") };

            var video0 = new FileManager() { FileName = "Nature.mp4", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_video.png") };
            var video1 = new FileManager() { FileName = "Wild.mpeg", ImageIcon = UIImage.FromBundle("Images/TreeView/treeview_video.png") };


            doc.SubFolder = new ObservableCollection<FileManager>
            {
                polution,
                globalWarming,
                sanitation,
                socialnetwork,
                youthempower
            };

            download.SubFolder = new ObservableCollection<FileManager>
            {
                game,
                tutorials,
                typescript,
                uiguide
            };

            mp3.SubFolder = new ObservableCollection<FileManager>
            {
                song
            };

            pics.SubFolder = new ObservableCollection<FileManager>
            {
                camera,
                stone,
                wind
            };
            camera.SubFolder = new ObservableCollection<FileManager>
            {
                img0,
                img1
            };

            videos.SubFolder = new ObservableCollection<FileManager>
            {
                video0,
                video1
            };

            this.Folders = new ObservableCollection<FileManager>();
            Folders.Add(doc);
            Folders.Add(download);
            Folders.Add(mp3);
            Folders.Add(pics);
            Folders.Add(videos);
        }
    }
}
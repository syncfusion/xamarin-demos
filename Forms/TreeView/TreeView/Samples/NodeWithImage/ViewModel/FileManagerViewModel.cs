#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeView
{
    [Preserve(AllMembers = true)]
    public class FileManagerViewModel
    {
        #region Fields

        private ObservableCollection<FileManager> imageNodeInfo;

        #endregion

        #region Constructor

        public FileManagerViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<FileManager> ImageNodeInfo
        {
            get { return imageNodeInfo; }
            set { this.imageNodeInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            FileImageInfoRespository nodeImageInfoRepository = new FileImageInfoRespository();
            imageNodeInfo = nodeImageInfoRepository.GetNodeImageInfo();
        }

        #endregion
    }

    [Preserve(AllMembers = true)]
    public class FileImageInfoRespository
    {
        #region Constructor

        public FileImageInfoRespository()
        {
        }

        #endregion

        internal ObservableCollection<FileManager> GetNodeImageInfo()
        {
            var nodeImageInfo = new ObservableCollection<FileManager>();
            Assembly assembly = typeof(NodeWithImage).GetTypeInfo().Assembly;
#if COMMONSB
            var doc = new FileManager() { ItemName = "Documents", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_folder.png", assembly) };
            var download = new FileManager() { ItemName = "Downloads", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_folder.png", assembly) };
            var mp3 = new FileManager() { ItemName = "Music", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_folder.png", assembly) };
            var pictures = new FileManager() { ItemName = "Pictures", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_folder.png", assembly) };
            var video = new FileManager() { ItemName = "Videos", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_folder.png", assembly) };

            var pollution = new FileManager() { ItemName = "Environmental Pollution.docx", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_word.png", assembly) };
            var globalWarming = new FileManager() { ItemName = "Global Warming.ppt", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_ppt.png", assembly) };
            var sanitation = new FileManager() { ItemName = "Sanitation.docx", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_word.png", assembly) };
            var socialNetwork = new FileManager() { ItemName = "Social Network.pdf", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_pdf.png", assembly) };
            var youthEmpower = new FileManager() { ItemName = "Youth Empowerment.pdf", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_pdf.png", assembly) };

            var games = new FileManager() { ItemName = "Game.exe", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_exe.png", assembly) };
            var tutorials = new FileManager() { ItemName = "Tutorials.zip", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_zip.png", assembly) };
            var typeScript = new FileManager() { ItemName = "TypeScript.7z", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_zip.png", assembly) };
            var uiGuide = new FileManager() { ItemName = "UI-Guide.pdf", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_pdf.png", assembly) };

            var song = new FileManager() { ItemName = "Gouttes", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_mp3.png", assembly) };

            var camera = new FileManager() { ItemName = "Camera Roll", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_folder.png", assembly) };
            var stone = new FileManager() { ItemName = "Stone.jpg", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_png.png", assembly) };
            var wind = new FileManager() { ItemName = "Wind.jpg", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_png.png", assembly) };

            var img0 = new FileManager() { ItemName = "WIN_20160726_094117.JPG", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_img0.png", assembly) };
            var img1 = new FileManager() { ItemName = "WIN_20160726_094118.JPG", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_img1.png", assembly) };

            var video1 = new FileManager() { ItemName = "Naturals.mp4", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_video.png", assembly) };
            var video2 = new FileManager() { ItemName = "Wild.mpeg", ImageIcon = ImageSource.FromResource("SampleBrowser.Icons.NodeWithImage.treeview_video.png", assembly) };
#else

            var doc = new FileManager() { ItemName = "Documents", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_folder.png", assembly) };
            var download = new FileManager() { ItemName = "Downloads", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_folder.png", assembly) };
            var mp3 = new FileManager() { ItemName = "Music", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_folder.png", assembly) };
            var pictures = new FileManager() { ItemName = "Pictures", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_folder.png", assembly) };
            var video = new FileManager() { ItemName = "Videos", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_folder.png", assembly) };

            var pollution = new FileManager() { ItemName = "Environmental Pollution.docx", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_word.png", assembly) };
            var globalWarming = new FileManager() { ItemName = "Global Warming.ppt", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_ppt.png", assembly) };
            var sanitation = new FileManager() { ItemName = "Sanitation.docx", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_word.png", assembly) };
            var socialNetwork = new FileManager() { ItemName = "Social Network.pdf", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_pdf.png", assembly) };
            var youthEmpower = new FileManager() { ItemName = "Youth Empowerment.pdf", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_pdf.png", assembly) };

            var games = new FileManager() { ItemName = "Game.exe", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_exe.png", assembly) };
            var tutorials = new FileManager() { ItemName = "Tutorials.zip", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_zip.png", assembly) };
            var typeScript = new FileManager() { ItemName = "TypeScript.7z", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_zip.png", assembly) };
            var uiGuide = new FileManager() { ItemName = "UI-Guide.pdf", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_pdf.png", assembly) };

            var song = new FileManager() { ItemName = "Gouttes", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_mp3.png", assembly) };

            var camera = new FileManager() { ItemName = "Camera Roll", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_folder.png", assembly) };
            var stone = new FileManager() { ItemName = "Stone.jpg", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_png.png", assembly) };
            var wind = new FileManager() { ItemName = "Wind.jpg", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_png.png", assembly) };

            var img0 = new FileManager() { ItemName = "WIN_20160726_094117.JPG", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_img0.png", assembly) };
            var img1 = new FileManager() { ItemName = "WIN_20160726_094118.JPG", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_img1.png", assembly) };

            var video1 = new FileManager() { ItemName = "Naturals.mp4", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_video.png", assembly) };
            var video2 = new FileManager() { ItemName = "Wild.mpeg", ImageIcon = ImageSource.FromResource("SampleBrowser.SfTreeView.Icons.NodeWithImage.treeview_video.png", assembly) };
#endif
            doc.SubFiles = new ObservableCollection<FileManager>
            {
                pollution,
                globalWarming,
                sanitation,
                socialNetwork,
                youthEmpower
            };

            download.SubFiles = new ObservableCollection<FileManager>
            {
                games,
                tutorials,
                typeScript,
                uiGuide
            };

            mp3.SubFiles = new ObservableCollection<FileManager>
            {
                song
            };

            pictures.SubFiles = new ObservableCollection<FileManager>
            {
                camera,
                stone,
                wind
            };
            camera.SubFiles = new ObservableCollection<FileManager>
            {
                img0,
                img1
            };

            video.SubFiles = new ObservableCollection<FileManager>
            {
                video1,
                video2
            };

            nodeImageInfo.Add(doc);
            nodeImageInfo.Add(download);
            nodeImageInfo.Add(mp3);
            nodeImageInfo.Add(pictures);
            nodeImageInfo.Add(video);
            return nodeImageInfo;
        }
    }
}
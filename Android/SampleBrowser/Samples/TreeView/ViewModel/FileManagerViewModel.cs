#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

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
            var doc = new FileManager() { FileName = "Documents", ImageIcon = Resource.Drawable.treeview_folder };
            var download = new FileManager() { FileName = "Downloads", ImageIcon = Resource.Drawable.treeview_folder };
            var mp3 = new FileManager() { FileName = "Music", ImageIcon = Resource.Drawable.treeview_folder };
            var pics = new FileManager() { FileName = "Pictures", ImageIcon = Resource.Drawable.treeview_folder };
            var video = new FileManager() { FileName = "Videos", ImageIcon = Resource.Drawable.treeview_folder };

            var pollution = new FileManager() { FileName = "Environmental Pollution.docx", ImageIcon = Resource.Drawable.treeview_word };
            var globalwarming = new FileManager() { FileName = "Global Warming.ppt", ImageIcon = Resource.Drawable.treeview_ppt };
            var sanitation = new FileManager() { FileName = "Sanitation.docx", ImageIcon = Resource.Drawable.treeview_word };
            var socialnetwork = new FileManager() { FileName = "Social Network.pdf", ImageIcon = Resource.Drawable.treeview_pdf };
            var youthempower = new FileManager() { FileName = "Youth Empowerment.pdf", ImageIcon = Resource.Drawable.treeview_pdf };

            var game = new FileManager() { FileName = "Game.exe", ImageIcon = Resource.Drawable.treeview_exe };
            var tutorials = new FileManager() { FileName = "Tutorials.zip", ImageIcon = Resource.Drawable.treeview_zip };
            var typescript = new FileManager() { FileName = "TypeScript.7z", ImageIcon = Resource.Drawable.treeview_zip };
            var uiguide = new FileManager() { FileName = "UI-Guide.pdf", ImageIcon = Resource.Drawable.treeview_pdf };

            var song = new FileManager() { FileName = "Gouttes", ImageIcon = Resource.Drawable.treeview_mp3 };

            var camera = new FileManager() { FileName = "Camera Roll", ImageIcon = Resource.Drawable.treeview_folder };
            var stone = new FileManager() { FileName = "Stone.jpg", ImageIcon = Resource.Drawable.treeview_png };
            var wind = new FileManager() { FileName = "Wind.jpg", ImageIcon = Resource.Drawable.treeview_png };

            var img0 = new FileManager() { FileName = "WIN_20160726_094117.JPG", ImageIcon = Resource.Drawable.treeview_img0 };
            var img1 = new FileManager() { FileName = "WIN_20160726_094118.JPG", ImageIcon = Resource.Drawable.treeview_img1 };

            var video0 = new FileManager() { FileName = "Naturals.mp4", ImageIcon = Resource.Drawable.treeview_video };
            var video1 = new FileManager() { FileName = "Wild.mpeg", ImageIcon = Resource.Drawable.treeview_video };

            doc.SubFolder = new ObservableCollection<FileManager>
            {
                pollution,
                globalwarming,
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

            video.SubFolder = new ObservableCollection<FileManager>
            {
                video0,
                video1
            };

            this.Folders = new ObservableCollection<FileManager>();
            Folders.Add(doc);
            Folders.Add(download);
            Folders.Add(mp3);
            Folders.Add(pics);
            Folders.Add(video);
        }
    }
}
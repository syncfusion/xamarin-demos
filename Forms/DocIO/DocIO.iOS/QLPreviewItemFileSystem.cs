#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using QuickLook;
using Foundation;
using System.IO;

namespace SampleBrowser.DocIO.iOS
{
    public class QLPreviewItemFileSystem : QLPreviewItem
	{
		string _fileName, _filePath;

		public QLPreviewItemFileSystem(string fileName, string filePath)
		{
			_fileName = fileName;
			_filePath = filePath;
		}

		public override string ItemTitle
		{
			get
			{
				return _fileName;
			}
		}
		public override NSUrl ItemUrl
		{
			get
			{
				return NSUrl.FromFilename(_filePath);
			}
		}
	}

	public class QLPreviewItemBundle : QLPreviewItem
	{
		string _fileName, _filePath;
		public QLPreviewItemBundle(string fileName, string filePath)
		{
			_fileName = fileName;
			_filePath = filePath;
		}

		public override string ItemTitle
		{
			get
			{
				return _fileName;
			}
		}
		public override NSUrl ItemUrl
		{
			get
			{
				var documents = NSBundle.MainBundle.BundlePath;
				var lib = Path.Combine(documents, _filePath);
				var url = NSUrl.FromFilename(lib);
				return url;
			}
		}
	}
}


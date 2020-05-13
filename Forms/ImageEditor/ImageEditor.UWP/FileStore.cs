#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.IO;
using Windows.ApplicationModel;
using Windows.Storage;

namespace SampleBrowser.SfImageEditor.UWP
{
	public class FileStore: IFileStore
	{
		public string GetFilePath()
		{
			return Path.Combine(Package.Current.InstalledLocation.Path, "image.png");
		}
	}
}

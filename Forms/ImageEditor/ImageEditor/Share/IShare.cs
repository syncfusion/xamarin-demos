#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using System.Threading.Tasks;

namespace SampleBrowser.SfImageEditor
{
	public interface IShare
	{
		void Show(string title, string message, string filePath);
	}

    public interface IFileToStream
    {
        void LoadSampleStream(string filename, SerializationModel model);
		Stream LoadSampleStream(string fileName);
    }
}

#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using Photos;
using System.Collections.Generic;
using SampleBrowser.SfImageEditor.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileToStream))]
namespace SampleBrowser.SfImageEditor.iOS
{
	public class FileStore : IFileStore
	{
		public string GetFilePath()
		{
			return "image.png";
		}

       
	}

    public class FileToStream : IFileToStream
    {
        Dictionary<string, Stream> dictionary = new Dictionary<string, Stream>();
        byte[] byteArray;

        public void LoadSampleStream(string filename,SerializationModel model )
        {
            try
            {
                string[] str = filename.Split('/');

                PHFetchResult assetResult = PHAsset.FetchAssetsUsingLocalIdentifiers(str, null);
                PHAsset asset = assetResult.firstObject as PHAsset;
                Stream stream= new MemoryStream();
                PHImageManager.DefaultManager.RequestImageData(asset, null, (data, dataUti,
                orientation, info) =>
                {
                    byteArray = data.ToArray();
                    Stream streamm = new MemoryStream(byteArray);
                    dictionary.Add(filename, streamm);
                    model.Location = filename;
                });
               
            }
            catch (Exception)
            {
                
            }
        }

        public Stream LoadSampleStream(string fileName)
        {
            if (dictionary != null)
            {
                Stream imageStream = new MemoryStream(byteArray);
                return imageStream;
            }
            else return null;
        }
    }
}

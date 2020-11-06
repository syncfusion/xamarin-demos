#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using System.Threading.Tasks;

namespace SampleBrowser.SfImageEditor.Droid
{
	public class Share: IShare
	{
		private readonly Context _context;
		public Share()
		{
			_context = Application.Context;
		}

		public void Show( string title, string message, string filePath)
		{
			var extension = filePath.Substring(filePath.LastIndexOf(".") + 1).ToLower();
			var contentType = string.Empty;
		
			switch (extension)
			{
				case "pdf":
					contentType = "application/pdf";
					break;
				case "png":
					contentType = "image/png";
					break;
                case "jpg":
                    contentType = "image/jpg";
                    break;
				default:
					contentType = "application/octetstream";
					break;
			}

            Java.IO.File file = new Java.IO.File(filePath);
            if (file.Exists())
            {
                Intent email = new Intent(Intent.ActionSend);
                Android.Net.Uri uri = Android.Support.V4.Content.FileProvider.GetUriForFile(Android.App.Application.Context, Android.App.Application.Context.PackageName + ".provider", file);
                email.PutExtra(Intent.ExtraSubject, message);
                email.PutExtra(Intent.ExtraStream, uri);
                email.SetFlags(ActivityFlags.NewTask);
                email.SetType(contentType);
                Application.Context.StartActivity(email);
            }
        }
	}
}
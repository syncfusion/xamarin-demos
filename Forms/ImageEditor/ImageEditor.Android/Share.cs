#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

		public Task Show( string title, string message, string filePath)
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

			var intent = new Intent(Intent.ActionSend);
			intent.SetType(contentType);
			intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.Parse("file://" + filePath));
			intent.PutExtra(Intent.ExtraText, message ?? string.Empty);
			intent.PutExtra(Intent.ExtraSubject, title ?? string.Empty);

			var chooserIntent = Intent.CreateChooser(intent, title ?? string.Empty);
			chooserIntent.SetFlags(ActivityFlags.ClearTop);
			chooserIntent.SetFlags(ActivityFlags.NewTask);
			_context.StartActivity(chooserIntent);

			return Task.FromResult(true);
		}
	}
}
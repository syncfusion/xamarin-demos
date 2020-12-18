#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Foundation;
using System.Threading.Tasks;
using UIKit;
using Photos;
using System.IO;
using System;

namespace SampleBrowser.SfImageEditor.iOS
{
	public class Share : IShare
	{
        /// <summary>
        /// MUST BE CALLED FROM THE UI THREAD
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public void Show(string title, string message, string filePath)
        {
            string[] str = filePath.Split('/');
            PHFetchResult assetResult = PHAsset.FetchAssetsUsingLocalIdentifiers(str, null);
            PHAsset asset = assetResult.firstObject as PHAsset;
            PHImageManager.DefaultManager.RequestImageData(asset, null, HandlePHImageDataHandler);
        }

       async void HandlePHImageDataHandler(NSData data, NSString dataUti, UIImageOrientation orientation, NSDictionary info)
        {
            UIImage newImage = new UIImage(data);
            var items = new NSObject[] { newImage };
            var activityController = new UIActivityViewController(items, null);
            var vc = GetVisibleViewController();

            NSString[] excludedActivityTypes = null;

            if (excludedActivityTypes != null && excludedActivityTypes.Length > 0)
                activityController.ExcludedActivityTypes = excludedActivityTypes;

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                if (activityController.PopoverPresentationController != null)
                {
                    activityController.PopoverPresentationController.SourceView = vc.View;
                }
            }
           await vc.PresentViewControllerAsync(activityController, true);
        }

        static UIImage FromUrl(string uri)
        {
            using (var url =  NSUrl.FromFilename(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }


		UIViewController GetVisibleViewController()
		{
			var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

			if (rootController.PresentedViewController == null)
				return rootController;

			if (rootController.PresentedViewController is UINavigationController)
			{
				return ((UINavigationController)rootController.PresentedViewController).TopViewController;
			}

			if (rootController.PresentedViewController is UITabBarController)
			{
				return ((UITabBarController)rootController.PresentedViewController).SelectedViewController;
			}

			return rootController.PresentedViewController;
		}
	}
}

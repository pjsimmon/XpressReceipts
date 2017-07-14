using System;
using System.Collections.Generic;
using System.Linq;

using System.IO; //for Path

using Foundation;
using UIKit;

namespace XamarinAppR2.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

            //Add the camera options for ios after LoadApplication

            //var imagePicker = new UIImagePickerController { SourceType = UIImagePickerControllerSourceType.Camera };
            UIImagePickerControllerCameraDevice cameraDevice = new UIImagePickerControllerCameraDevice(); 

            if (UIImagePickerController.IsCameraDeviceAvailable(cameraDevice))
            {

                var imagePicker = new UIImagePickerController { SourceType = UIImagePickerControllerSourceType.Camera };


				(Xamarin.Forms.Application.Current as App).ShouldTakePicture += () =>
			  app.KeyWindow.RootViewController.PresentViewController(imagePicker, true, null);

				//Save the picture to the MyDocuments folder and call the shared "ShowImage" method
				imagePicker.FinishedPickingMedia += (sender, e) =>
				{
					var filepath = Path.Combine(Environment.GetFolderPath(
									   Environment.SpecialFolder.MyDocuments), "tmp.png");
					var image = (UIImage)e.Info.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage"));
					InvokeOnMainThread(() =>
					{
						image.AsPNG().Save(filepath, false);
						(Xamarin.Forms.Application.Current as App).ShowImage(filepath);
					});
					app.KeyWindow.RootViewController.DismissViewController(true, null); //changed the name of UIApplication to app
				};

				imagePicker.Canceled += (sender, e) => app.KeyWindow.RootViewController.DismissViewController(true, null);
            }
            else //no camera available
            {
				//create a new message alert 
				UIAlertView alert = new UIAlertView()
				{
					Title = "Camera Error",
					Message = "No camera available"
				};
				alert.AddButton("OK");
				alert.Show();
                
                
            }



			return base.FinishedLaunching(app, options);
		}
	}
}

using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Provider; //for MediaStore
using Android.Net; //for Uri.FromFile

using Java.IO; //for file (Java.IO.File)

using System.Collections.Generic;
using System.Linq;

using System.IO; //for Path



//used Android.OS.Environment for environment
//and Android.Net.Uri for URI




namespace XamarinAppR2.Droid
{
    [Activity(Label = "XamarinAppR2.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //Added this to get picture file for android (path for the camera image)
        static readonly Java.IO.File file = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "tmp.jpg");

        //static File file;

        protected override void OnCreate(Bundle bundle)
        {
            //Computer generated code
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            System.Console.WriteLine("Before creating bundle");

            base.OnCreate(bundle);

            System.Console.WriteLine("After creating bundle");

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());


            //file = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "tmp.jpg");

            /////////////////////Me and my code/////////////

           // while (true)
            //{
                /// Assigns an event handler and creates an intent to capture the image
                (Xamarin.Forms.Application.Current as App).ShouldTakePicture += () =>
                {
                    //DeleteFile(file.Path);
                    //file = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "tmp.jpg");

                    var intent = new Intent(MediaStore.ActionImageCapture);
                    intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(file));  //I did Android.Net.Uri instead of just Uri
                    StartActivityForResult(intent, 0);

                    //(Xamarin.Forms.Application.Current as App).ShowImage(file.Path);


                };

                //Activity reacts to the resulting image
                //(Xamarin.Forms.Application.Current as App).ShowImage(file.Path);


                ////////////

                //If automatic button clicked --> OCR
			    (Xamarin.Forms.Application.Current as App).Automatic += () =>
				{

                    Toast.MakeText(this, "OCR not set up yet", ToastLength.Long).Show();

				};


			////////////

			    //If manual button clicked --> user inputs data manaually
			    (Xamarin.Forms.Application.Current as App).Manual += () =>
				{

				//Intent intent = new Intent(MainActivity.this, SecondActivity.class);
				//startActivity(intent);


				};


			//Activity reacts to the resulting image
			(Xamarin.Forms.Application.Current as App).ShowImage(file.Path);






		} //end onCreate

    }



		//Need to allow user to click TakePicture button multiple times 
		//Above code is in the onCreate (only executed once)
		//Need more code in MainActivity in case the user needs to retake a picture


		
}

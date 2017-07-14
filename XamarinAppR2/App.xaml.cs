﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinAppR2
{
    public partial class App : Application
    {
        //For the camera
        //public static App Instance;
         readonly Image image = new Image();  //make readonly or no?

        //public event Action ShouldTakePicture = () => {};


        public App()
        {
            //InitializeComponent();

            MainPage = new NavigationPage(new XamarinAppR2.MainPage());

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Button {
                            Text = "Take a picture of your receipt!",
                            Command = new Command(o => ShouldTakePicture()),
                        },
                        image,
                        new Label {
                            Text = "Choose a way to enter receipt information:"
                        },
                        new Button {
                            Text = "Automatically",
                            Command = new Command(o => Automatic()),
                        },
                        new Button {
                            Text = "Manually",
                            Command = new Command(o => Manual()),
                        }
                    },
                },
            };

			//MainPage = new MainPage();

		}

		//To call "take picture" from android and ios
		public event System.Action ShouldTakePicture = () => { };

		//Call OCR to automatically input info from receipt
		public event System.Action Automatic = () => { };

		//Enable user to manually enter text from recepeit
		public event System.Action Manual = () => 
        {
           // Navigation.PushAsync(new InformationPage());
        };


		public void ShowImage(string filepath) 
        {
            image.Source = ImageSource.FromFile(filepath);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


    }
}
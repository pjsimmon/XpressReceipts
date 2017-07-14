using System;
using Xamarin.Forms;

namespace XamarinAppR2
{
	public partial class MainPage : ContentPage
	{

        readonly Image image = new Image();

        public MainPage()
        {
            InitializeComponent();

            //Open Camera view

            //TakePicture --> Camera Button

            Button pictureButton = new Button()
            {
                Text = "Take a picture of your receipt:",
                HorizontalOptions = LayoutOptions.Center,
            };
            pictureButton.Clicked += shouldTakePicture;


            Label receiptLabel = new Label()
            {
                Text = "Choose a way to enter the receipt information:",
                HorizontalOptions = LayoutOptions.Center
            };

            Button manButton = new Button()
            {
                Text = "Manually",
                HorizontalOptions = LayoutOptions.Center
            };
            manButton.Clicked += manualClicked;

            Button autoButton = new Button()
            {
                Text = "Automatically",
                HorizontalOptions = LayoutOptions.Center
            };
            autoButton.Clicked += automaticClicked;

            //Build the page
            this.Content = new StackLayout
            {
                Children =
                {
                    pictureButton,
                    image,
                    receiptLabel,
                    autoButton,
                    manButton
                }

            };

            // Might need to add padding, depending on the device being used

        }


		//To call "take picture" from android and ios
		void shouldTakePicture(object sender, EventArgs e)
        {
            
        }


        //Automatic means use OCR to get information from the reciept. //async
		void automaticClicked(object sender, EventArgs e)
		{
            
		}

        //Manual means manually enter the information.
		async void manualClicked(object sender, EventArgs e)
		{
            InformationPage infoPage = new InformationPage();
            await Navigation.PushAsync (infoPage);
		}

		//Call OCR to automatically input info from receipt
		public event System.Action Automatic = () => { };

		//Enable user to manually enter text from recepeit
		public event System.Action Manual = () => { };

	}
}
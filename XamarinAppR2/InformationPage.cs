using System;

using Xamarin.Forms;

namespace XamarinAppR2
{
    public class InformationPage : ContentPage
    {
        public InformationPage()
        {

            Label header = new Label()
            {
                Text = "Enter or Confirm Receipt Information:",
                HorizontalOptions = LayoutOptions.Center
            };

            Entry CostEntry = new Entry()
            {
                Text = "Input the cost (before tax)",
                HorizontalOptions = LayoutOptions.Center
            };

            Entry TaxEntry = new Entry()
            {
                Text = "Input the tax",
                HorizontalOptions = LayoutOptions.Center
            };

            Entry TotalEntry = new Entry()
            {
                Text = "Input the total for the transaction",
                HorizontalOptions = LayoutOptions.Center
            };

            Entry TipEntry = new Entry()
            {
                Text = "Input the tip (optional)",
                HorizontalOptions = LayoutOptions.Center
            };

            Button confirmButton = new Button()
            {
                Text = "Confirm",
                HorizontalOptions = LayoutOptions.Center
            };
            confirmButton.Clicked += confirmClicked;

            Button cancelButton = new Button()
            {
                Text = "Cancel",
                HorizontalOptions = LayoutOptions.Center
            };
            cancelButton.Clicked += cancelClicked;


            // Might need to add padding, depending on the device being used.

            //Build the page
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    CostEntry,
                    TaxEntry,
                    TotalEntry,
                    TipEntry,
                    confirmButton,
                    cancelButton
                }
            };

        }


        //Confirm clicked
        void confirmClicked(object sender, EventArgs e) 
        {
            //Go to the next content page --> send e-mail to Christine
            
        }


        //Cancel clicked
        void cancelClicked(object sender, EventArgs e)
        {
            //Go back to the previous page, ask the user to take a new picture
        }




    }
}

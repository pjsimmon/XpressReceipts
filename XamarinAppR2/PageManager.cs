using System;
using Xamarin.Forms;


namespace XamarinAppR2
{
    public class PageManager
    {
        public static NavigationPage Init()
        {
            //This makes MainPage the root/navigation page
            NavigationPage nav = new NavigationPage(new MainPage());
			return nav;

        }
    }
}

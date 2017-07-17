using System;

using Xamarin.Forms;

namespace ConeccionApp
{
    public partial class App : Application
    {    
          public App()
          {
              InitializeComponent();

            //MainPage = new ConeccionApp.MainPage();
            MainPage = new ConeccionApp.Views.LoginView();

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

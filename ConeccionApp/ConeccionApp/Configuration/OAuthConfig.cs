using ConeccionApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConeccionApp.Configuration
{
    public class OAuthConfig
    {
        public static MainPage _HomePage;
        static NavigationPage _NavigationPage;
        public static UserDetails User;

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {
                    _NavigationPage.Navigation.PushModalAsync(_HomePage);
                });
            }
        }
    }
}

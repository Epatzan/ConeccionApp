using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using ConeccionApp.Views;
using Xamarin.Forms.Platform.Android;
using ConeccionApp.Droid.PageRenderers;

[assembly: ExportRenderer(typeof(LoginViewFacebook), typeof(LoginFacebook))]
namespace ConeccionApp.Droid.PageRenderers
{
  public class LoginFacebook : PageRenderer
    {
        Account loggedInAccount = null;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var auth = new OAuth2Authenticator(
                clientId: App.Instance.FacebookOAuthSettings.ClientId,
                scope: App.Instance.FacebookOAuthSettings.Scope,
                authorizeUrl: new Uri(App.Instance.FacebookOAuthSettings.AuthorizeUrl),
                redirectUrl: new Uri(App.Instance.FacebookOAuthSettings.RedirectUrl));

            auth.Title = "Facebook login";
            auth.AllowCancel = true;

            var activity = this.Context as Activity;
            activity.StartActivity(auth.GetUI(activity));

            auth.Completed += async (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    loggedInAccount = eventArgs.Account;

                    await GetFacebookData();

                    AccountStore.Create(activity).Save(loggedInAccount, "Facebook");
                    App.Instance.SuccessfulLoginAction.Invoke();
                    App.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);

                    await App.Instance.IniciarSesion();
                }
                else
                {
                    // The user cancelled
                    App.Instance.SuccessfulLoginAction.Invoke();
                }
            };
        }
    }
}
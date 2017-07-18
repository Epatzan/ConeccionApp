﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using ConeccionApp.Views;
using Xamarin.Forms;
using ConeccionApp.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using ConeccionApp.Configuration;

[assembly: ExportRenderer(typeof(ProviderLoginPage), typeof(LoginRenderer))]
namespace ConeccionApp.iOS.Renderers
{
    public class LoginRenderer : PageRenderer
    {
        bool showLogin = true;
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            //Get and Assign ProviderName from ProviderLoginPage
            var loginPage = Element as ProviderLoginPage;
            string providername = loginPage.ProviderName;
            
            if (showLogin && OAuthConfig.User == null)
            {
                showLogin = false;

                //Create OauthProviderSetting class with Oauth Implementation .Refer Step 6
                OAuthProviderSetting oauth = new OAuthProviderSetting();

                if (providername == "Twitter")
                {
                    var auth = oauth.LoginWithTwitter();
                    // After Twitter  login completed 
                    auth.Completed += (sender, eventArgs) =>
                    {
                        DismissViewController(true, null);
                        if (eventArgs.IsAuthenticated)
                        {
                            /*  OAuthConfig.User = new UserDetails();
                              // Get and Save User Details 
                              OAuthConfig.User.Token = eventArgs.Account.Properties["oauth_token"];
                              OAuthConfig.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
                              OAuthConfig.User.TwitterId = eventArgs.Account.Properties["user_id"];
                              OAuthConfig.User.ScreenName = eventArgs.Account.Properties["screen_name"];

                              OAuthConfig.SuccessfulLoginAction.Invoke();*/
                        }
                        else
                        {
                            // The user cancelled
                        }
                    };


                    //activity.StartActivity(auth.GetUI(activity));
                    PresentViewController(auth.GetUI(), true, null);
                }
                else
                {
                    var auth = oauth.LoginWithProvider(providername);

                    // After facebook,google and all identity provider login completed 
                    auth.Completed += (sender, eventArgs) =>
                    {
                        DismissViewController(true, null);
                        if (eventArgs.IsAuthenticated)
                        {
                            /* OAuthConfig.User = new UserDetails();
                             // Get and Save User Details 
                             OAuthConfig.User.Token = eventArgs.Account.Properties["oauth_token"];
                             OAuthConfig.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
                             OAuthConfig.User.TwitterId = eventArgs.Account.Properties["user_id"];
                             OAuthConfig.User.ScreenName = eventArgs.Account.Properties["screen_name"];

                             OAuthConfig.SuccessfulLoginAction.Invoke();*/
                        }
                        else
                        {
                            // The user cancelled
                        }
                    };

                    PresentViewController(auth.GetUI(), true,null);
                   // activity.StartActivity(auth.GetUI(activity));
                }
            }

        }
    }
}
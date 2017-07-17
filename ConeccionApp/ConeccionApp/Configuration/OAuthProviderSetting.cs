using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace ConeccionApp.Configuration
{
    public class OAuthProviderSetting
    {
        public string ClientId { get; private set; }
        public string ConsumerKey { get; private set; }
        public string ConsumerSecret { get; private set; }
        public string RequestTokenUrl { get; private set; }
        public string AccessTokenUrl { get; private set; }
        public string AuthorizeUrl { get; private set; }
        public string CallbackUrl { get; private set; }

        public enum OauthIdentityProvider
        {
            GOOGLE,
            FACEBOOK,
            TWITTER
           
        }

        public OAuth1Authenticator LoginWithTwitter()
        {
            OAuth1Authenticator Twitterauth = null;
            try
            {
                Twitterauth = new OAuth1Authenticator(
                           consumerKey: "CT7yAVd0n2Ow649VYgl4VHpio",    
                           consumerSecret: "N1riKGqobIt8IMAclFIV73m1yCBhH0pb6eyNU560PVilSF0PB3", 
                           requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"), 
                           authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"), 
                           accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"), 
                           callbackUrl: new Uri("http://www.loencuentra.com")    
                       );
            }
            catch (Exception ex)
            {

            }
            return Twitterauth;
        }
        public OAuth2Authenticator LoginWithProvider(string Provider)
        {
            OAuth2Authenticator auth = null;
            switch (Provider)
            {
                case "Google":
                    {
                        auth = new OAuth2Authenticator(
                                   
                                    "1031739772600-aa55son5nl2n5u12ure62s3un1sn77g0.apps.googleusercontent.com",
                                   "AIzaSyCuqusnr3plwt4n9MTKqyFHfPFyUTsu4b4",                                   
                                    "https://www.googleapis.com/auth/userinfo.email",
                                    new Uri("https://accounts.google.com/o/oauth2/auth"),
                                    new Uri("http://www.google.com.gt"),
                                    new Uri("https://accounts.google.com/o/oauth2/token")
                                    );

                        break;
                    }
                case "FaceBook":
                    {
                        auth = new OAuth2Authenticator(

                 clientId: "799886733477858",  
                 scope: "",
                 authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"), 
                 redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")
             );
                        break;
                    }
               

            }
            return auth;

        }
    }
}

using Android.Content;
using Badge.Plugin;
using Plugin.FirebasePushNotification;
using SamplePushNotification.Views;
using Xamarin.Forms;

namespace SamplePushNotification
{
    public partial class App : Application
    {
        int contador;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            CrossFirebasePushNotification.Current.Subscribe("all");

            //Will navigate to an specific page/activity when clicked on notification
           CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                //System.Diagnostics.Debug.WriteLine("Opened the notification");
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new ActiveMethods());
            };

            CrossFirebasePushNotification.Current.OnNotificationReceived += async (s, p) =>
            {
                MessagingCenter.Subscribe<App>(this, "PushNotificationRecieved", (sender) =>
                {
                    contador++;
                    CrossBadge.Current.SetBadge(contador);
                });

                System.Diagnostics.Debug.WriteLine($"RECEIVED NOTIFICATION");
            };

            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
        }


        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"TokenFireBase: {e.Token}");
        }

       protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

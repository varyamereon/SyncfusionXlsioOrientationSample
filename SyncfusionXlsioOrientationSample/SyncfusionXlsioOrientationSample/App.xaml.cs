using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncfusionXlsioOrientationSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTIyMDgwQDMxMzkyZTMzMmUzMFN0bWoyUVhrT0ZQN1c2Rk1mK3NoVzJMa0p3bW5SOUMrYjZnSFR2ZlFjLzQ9");

            MainPage = new MainPage();
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

﻿using Medikit.Mobile.Services;
using Medikit.Mobile.ViewModels;
using Xamarin.Forms;

namespace Medikit.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<INavigationService, NavigationService>();
            DependencyService.Register<IAlertService, AlertService>();
            DependencyService.Register<SettingsViewModel>();
            DependencyService.Register<ICertificateStore, SqliteCertificateStore>();
            DependencyService.Register<CertificatesViewModel>();
            DependencyService.Register<MedikitMobileOptions>();
            MainPage = new AppShell();
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

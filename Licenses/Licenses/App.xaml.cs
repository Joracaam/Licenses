using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Prism.Ioc;
using Prism;
using Licenses.Views;
using Licenses.ViewModels;
using Licenses.Services;
using Licenses.Interfaces;
using Licenses.AccessData;
using Xamarin.Essentials;
using System.IO;
using Licenses.Models;
using System.Collections.Generic;

namespace Licenses
{
    public partial class App : PrismApplication
    {
        static Database db;
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        public static Database Database
        {
            get
            {
                if (db == null)
                {
                    db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Apps.db3"));
                }
                return db;
            }
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "Shapes_Experimental", "Shell_UWP_Experimental" });
            NavigationService.NavigateAsync(new System.Uri("http://Licenses/LicensePage", System.UriKind.Absolute));

            bool FirstBoot = Preferences.Get("FirstBoot", true);

            if (FirstBoot)
            {
                List<Apps> apps = new List<Apps>()
                {
                    new Apps(){Name = "TestApp", HashCounter = 50}
                };

                Database.SaveAppAsync(apps);
                Preferences.Set("FirstBoot", false);
            }
        }

        protected override void RegisterTypes(IContainerRegistry ContainerRegistry)
        {
            //ViewModels
            ContainerRegistry.RegisterForNavigation<LicensePage, LicensePageViewModel>();
            ContainerRegistry.RegisterForNavigation<AddAppPage, AddAppPageViewModel>();

            //Services
            ContainerRegistry.Register<IVerifyHash, VerifyHash>();
            ContainerRegistry.Register<IDatabase, Database>();
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

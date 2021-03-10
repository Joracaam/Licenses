using Licenses.Interfaces;
using Licenses.Models;
using Licenses.Utils;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Licenses.ViewModels
{
    public class LicensePageViewModel: BaseViewModel
    {
        #region Fields
        INavigationService navigation;
        private readonly IVerifyHash hash;
        private string serialCode;
        private string marcaModelo;
        private string buttonColor = "#db5856";
        private bool isAppSelected;
        private bool isVisible;
        private string license;
        private List<Apps> apps;
        private Apps app;
        #endregion

        #region Properties
        public string SerialCode
        {
            get { return serialCode; }
            set
            {
                serialCode = value;
                ButtonColor = "#db5856";
                License = String.Empty;
                OnPropertyChanged("SerialCode");
            }
        }

        public bool IsAppSelected
        {
            get { return isAppSelected; }
            set
            {
                isAppSelected = value;
                OnPropertyChanged("IsAppSelected");
            }
        }

         public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }

        public string ButtonColor
        {
            get { return buttonColor; }
            set
            {
                buttonColor = value;
                OnPropertyChanged("ButtonColor");
            }
        }

        public string License
        {
            get { return license; }
            set
            {
                license = value;
                OnPropertyChanged("License");
            }
        }

        public List<Apps> Apps
        {
            get { return apps; }
            set
            {
                apps = value;
                OnPropertyChanged("Apps");
            }
        }

        public Apps AppSelected
        {
            get { return app; }
            set
            {
                app = value;

                if (app != null)
                {
                    IsAppSelected = true;
                }
                else
                {
                    IsAppSelected = false;
                }
                OnPropertyChanged("AppSelected");
            }
        }

        public string MarcaModelo
        {
            get { return marcaModelo; }
            set
            {
                marcaModelo = value;
                OnPropertyChanged("MarcaModelo");
            }
        }
        #endregion

        #region Constructor
        public LicensePageViewModel(IVerifyHash hash, INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            this.hash = hash;
            navigation = navigationService;

            //Add Commands
            Commands.Add("GetLicensed", new Command(GetLicensed));
            Commands.Add("GotoAddAppPage", new Command(GotoAddAppPage));

            Initialize();
        }
        #endregion

        #region UI methods

        private void Initialize()
        {
            Apps = App.Database.GetAppsAsync().Result;
        }

        private void GetLicensed()
        {
            if (AppSelected != null)
            {
                if (!String.IsNullOrWhiteSpace(SerialCode))
                {
                    License = hash.GetMd5Hash(SerialCode, AppSelected.HashCounter);

                    if (!string.IsNullOrWhiteSpace(License))
                    {
                        IsVisible = true;
                        ButtonColor = "#FDC868";
                        ShowAlert("Genial!", "Copie la licencia e introduzcala en la aplicación del dispositivo que la solicita", "Ok");
                    }
                    else
                    {
                        ShowAlert("Hey!", "Debe introducir los valores solicitados", "Reintentar");
                    }
                }
                else
                {
                        ShowAlert("Hey!", "Debe introducir los valores solicitados", "Reintentar");
                }
            }
            else
            {
                ShowAlert("Hey!", "Primero debe seleccionar una aplicación", "Reintentar");
            }
        }

        private void GotoAddAppPage()
        {
            navigation.NavigateAsync("AddAppPage");
        }
        #endregion
    }
}

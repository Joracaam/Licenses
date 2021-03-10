using Licenses.Interfaces;
using Licenses.Models;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Licenses.ViewModels
{
    public class AddAppPageViewModel: BaseViewModel
    {
        IDatabase database;
        INavigationService navigation;
        IPageDialogService pageDialog;

        private string appName = string.Empty;
        private int hashCounter = 0;
        private string buttonColor = "#db5856";
        public string AppName { get { return appName; } set { appName = value; OnPropertyChanged("AppName"); } }
        public int HashCounter { get { return hashCounter; } set { hashCounter = value; OnPropertyChanged("HashCounter"); } }
        public string ButtonColor { get { return buttonColor; } set { buttonColor = value; OnPropertyChanged("ButtonColor"); } }

        public AddAppPageViewModel(IDatabase database, INavigationService navigationService, IPageDialogService pageDialogService): base(navigationService,pageDialogService)
        {
            this.database = database;
            navigation = navigationService;
            pageDialog = pageDialogService;
            Commands.Add("Add", new Command(Add));
        }
        public void Add()
        {
            Apps app = new Apps()
            {
                Name = AppName,
                HashCounter = HashCounter
            };

            var result = database.SaveAppAsync(app).Result;

            if (result > 0)
            {
                ShowAlert("", "Aplicacion agregada exitosamente","Ok");
                AppName = string.Empty;
                HashCounter = 0;
            }
        }
    }
}

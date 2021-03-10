using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Licenses.ViewModels
{
    public class BaseViewModel: ObservableProperty
    {
        //Injectors
        readonly INavigationService navigationService;
        readonly IPageDialogService pageDialogService;

        public Dictionary<string, ICommand> Commands { get; protected set; }

        public BaseViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            this.navigationService = navigationService;
            this.pageDialogService = pageDialogService;

            Commands = new Dictionary<string, ICommand>();
        }

        public void ShowAlert(string title, string message, string cancelButton)
        {
            pageDialogService.DisplayAlertAsync(title, message, cancelButton);
        }

        public bool ShowAlert(string title, string message, string acceptButton, string cancelButton)
        {
            return pageDialogService.DisplayAlertAsync(title, message, acceptButton, cancelButton).Result;
        }
    }
}

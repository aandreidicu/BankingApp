using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Windows.Input;
using SMB.Models;
using SMB.Repositories;
using System.Net;
using System.Threading;
using System.Security.Principal;

namespace SMB.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //Field-uri
        string _numeWindow;

        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;

        public string NumeWindow { get => _numeWindow; set { _numeWindow = value; OnPropertyChanged(nameof(NumeWindow)); } }

        public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public SecureString Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        private ViewModelBase _currentChildView;
        public ViewModelBase CurrentChildView { get { return _currentChildView; } set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }
        //Comenzi
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        public ICommand SignShow { get; }

        //Constructor
        public LoginViewModel()
        {
            NumeWindow = "LOG IN";
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            SignShow = new ViewModelCommand(ExecuteSignShow, CanExecuteSignShow);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        private bool CanExecuteSignShow(object obj)
        {
            return true;
        }

        private void ExecuteSignShow(object obj)
        {
            NumeWindow = "SIGN UP";
            CurrentChildView = new SignUpViewModel();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* invalid mail or password";
            }
        }


        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}

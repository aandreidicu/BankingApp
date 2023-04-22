using SMB.Models;
using SMB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SMB.ViewModel
{
    public class SignUpViewModel : ViewModelBase
    {
        //Field-uri
        string _firstname;
        string _lastname;
        string _personalcode;
        System.DateTime _birthdate;
        string _county;
        string _city;
        string _HomeAddress;
        string _phone;
        string _email;
        string _password;
        string _STRcurrency;
        int _INTcurrency;

        private IUserRepository userRepository;
        private bool _isViewVisible = true;

        public string FirstName { get => _firstname; set { _firstname = value; OnPropertyChanged(nameof(FirstName)); } }
        public string LastName { get => _lastname; set { _lastname = value; OnPropertyChanged(nameof(LastName)); } }
        public string PersonalCode { get => _personalcode; set { _personalcode = value; OnPropertyChanged(nameof(PersonalCode)); } }
        public System.DateTime BirthDate { get => _birthdate; set { _birthdate = value; OnPropertyChanged(nameof(BirthDate)); } }
        public string County { get => _county; set { _county = value; OnPropertyChanged(nameof(County)); } }
        public string City { get => _city; set { _city = value; OnPropertyChanged(nameof(City)); } }
        public string HomeAddress { get => _HomeAddress; set { _HomeAddress = value; OnPropertyChanged(nameof(HomeAddress)); } }
        public string Phone { get => _phone; set { _phone = value; OnPropertyChanged(nameof(Phone)); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged(nameof(Email)); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string STRCurency { get => _STRcurrency; set { _STRcurrency = value; OnPropertyChanged(nameof(STRCurency)); } }
        public int INTCurency { get => _INTcurrency; set { _INTcurrency = value; OnPropertyChanged(nameof(INTCurency)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        public ICommand SignCommand { get; }

        public SignUpViewModel()
        {
            userRepository = new UserRepository();
            SignCommand = new ViewModelCommand(ExecuteSignCommand, CanExecuteSignCommand);
        }
        private bool CanExecuteSignCommand(object obj)
        {
            bool validSign;
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(PersonalCode) || string.IsNullOrWhiteSpace(BirthDate.ToString()) || string.IsNullOrWhiteSpace(County) || string.IsNullOrWhiteSpace(City) || string.IsNullOrWhiteSpace(HomeAddress) || string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(STRCurency))
                validSign = false;
            else
                validSign = true;
            return validSign;
        }

        private void ExecuteSignCommand(object obj)
        {

            UsersLegal user = new UsersLegal();
            CurrentAccount account = new CurrentAccount();



            user.userID = Guid.NewGuid();
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.personalCode = PersonalCode;
            user.birthDate = BirthDate;
            user.County = County;
            user.City = City;
            user.HomeAddress = HomeAddress;
            user.phone = Phone;
            user.mail = Email;
            user.password = Password;

            StringBuilder sb = new StringBuilder();
            Random random = new Random(Environment.TickCount);
            int number1 = random.Next(0, 10000);
            int number2 = random.Next(0, 10000);
            int number3 = random.Next(0, 10000);
            sb.AppendFormat("RO49 UGBI {0:D4} {1:D4} {2:D4} 0RON", number1, number2, number3);
            string ibanuRes = sb.ToString();

            if (STRCurency == "RON")
            {
                account.currency = 1;
            }
            if (STRCurency == "EUR")
            {
                account.currency = 2;
            }
            if (STRCurency == "USD")
            {
                account.currency = 3;
            }

            account.IBAN = ibanuRes;
            account.CompanyID = null;
            account.UserID = user.userID;



            userRepository.AddUser(user, account);
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Email, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Email), null);
                IsViewVisible = false;
            }
            else
            {
                MessageBox.Show("NU E BINE");
            }
            //email unic , mecanisme de erori TO DO: DEPOZIT, LOG OUT , STATISTICI
        }
    }
}
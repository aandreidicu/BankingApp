using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FontAwesome.Sharp;
using SMB.Models;
using SMB.Repositories;

namespace SMB.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;


        private IUserRepository userRepository;
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        //WINDOW_URI
        //Proprietati
        public ViewModelBase CurrentChildView { get { return _currentChildView; } set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }
        public string Caption { get { return _caption; } set { _caption = value; OnPropertyChanged(nameof(Caption)); } }
        public IconChar Icon { get { return _icon; } set { _icon = value; OnPropertyChanged(nameof(Icon)); } }
        //!-- COMENZI
        public ICommand ShowOverviewViewCommand { get; }
        public ICommand ShowStatisticsViewCommand { get; }
        public ICommand ShowTransactionsViewCommand { get; }
        public ICommand ShowTransfersViewCommand { get; }





        public MainViewModel()
        {
            userRepository = new UserRepository();
            LoadCurrentUserDate();

            //Initializez comenzile de mai sus
            ShowOverviewViewCommand = new ViewModelCommand(ExecuteShowOverviewViewCommand);
            ShowStatisticsViewCommand = new ViewModelCommand(ExecuteShowStatisticsViewCommand);
            ShowTransactionsViewCommand = new ViewModelCommand(ExecuteShowTransactionsViewCommand);
            ShowTransfersViewCommand = new ViewModelCommand(ExecuteShowTransfersViewCommand);

            //View DEFAULT!!!
            ExecuteShowOverviewViewCommand(null);
        }

        private void ExecuteShowStatisticsViewCommand(object obj)
        {
            CurrentChildView = new StatisticsViewModel();
            Caption = "Statistics";
            Icon = IconChar.PieChart;
        }

        private void ExecuteShowOverviewViewCommand(object obj)
        {
            CurrentChildView = new OverviewViewModel();
            Caption = "Overview";
            Icon = IconChar.Home;
        }
        private void ExecuteShowTransactionsViewCommand(object obj)
        {
            CurrentChildView = new TransactionsViewModel();
            Caption = "Transactions";
            Icon = IconChar.ShoppingBag;
        }
        private void ExecuteShowTransfersViewCommand(object obj)
        {
            CurrentChildView = new TransfersViewModel();
            Caption = "Transfer";
            Icon = IconChar.MoneyBillTransfer;
        }

        public void LoadCurrentUserDate()
        {
            CurrentUserAccount = new UserAccountModel();
            var user = userRepository.GetByMail(Thread.CurrentPrincipal.Identity.Name);
            var current_account = userRepository.getCurrentAccountbyID(user.userID);
            var deposit = userRepository.getDepositbyID(user.userID);
            var transactions = userRepository.getTransactionsListbyIBAN(current_account.IBAN);
            if (user != null)
            {
                CurrentUserAccount.Username = user.mail;
                CurrentUserAccount.ProfilePicture = null;

                // Current account
                CurrentUserAccount.CurrentAccount_Currency = current_account.currency.ToString();
                if (CurrentUserAccount.CurrentAccount_Currency == "1")
                {
                    CurrentUserAccount.CurrentAccount_Currency = "RON";
                }
                if (CurrentUserAccount.CurrentAccount_Currency == "2")
                {
                    CurrentUserAccount.CurrentAccount_Currency = "EUR";
                }
                if (CurrentUserAccount.CurrentAccount_Currency == "3")
                {
                    CurrentUserAccount.CurrentAccount_Currency = "USD";
                }
                CurrentUserAccount.CurrentAccount_IBAN = current_account.IBAN;
                CurrentUserAccount.CurrentAccount_Balance = 0; //aici trebuie modificat in functie de tranzactii

                //Deposit TREBUIE FACUT BINDING PE VIEW DAR MAI INCOLO
                /* CurrentUserAccount.Deposit_Currency = deposit.currency.ToString();
                 if (CurrentUserAccount.CurrentAccount_Currency == "1")
                 {
                     CurrentUserAccount.CurrentAccount_Currency = "RON";
                 }
                 if (CurrentUserAccount.CurrentAccount_Currency == "2")
                 {
                     CurrentUserAccount.CurrentAccount_Currency = "EUR";
                 }
                 if (CurrentUserAccount.CurrentAccount_Currency == "3")
                 {
                     CurrentUserAccount.CurrentAccount_Currency = "USD";
                 }
                 CurrentUserAccount.Deposit_IBAN= deposit.IBAN;
                 CurrentUserAccount.Deposit_Balance = "0"; //aici trebuie modificat*/

                //TRANZACTII
                
                CurrentUserAccount.Lista_tranzactii = transactions;
                CurrentUserAccount.Lista_tranzactii.Reverse();

                for (int i = 0; i < transactions.Count; i++)
                {
                    CurrentUserAccount.Lista_tranzactii[i].StrTranDate = CurrentUserAccount.Lista_tranzactii[i].tranDate.ToString();
                    char[] seps = { ' ' };
                    string[] parts = CurrentUserAccount.Lista_tranzactii[i].StrTranDate.Split(seps);
                    CurrentUserAccount.Lista_tranzactii[i].StrTranDate = parts[0];

                    var another_user = userRepository.GetByID(userRepository.GetByIBAN(CurrentUserAccount.Lista_tranzactii[i].srcIBAN));
                    CurrentUserAccount.Lista_tranzactii[i].NumeSursa = another_user.FirstName + " " + another_user.LastName;
                    var another_user2 = userRepository.GetByID(userRepository.GetByIBAN(CurrentUserAccount.Lista_tranzactii[i].destIBAN));
                    CurrentUserAccount.Lista_tranzactii[i].NumeDestinatie = another_user2.FirstName + " " + another_user2.LastName;
                    if (CurrentUserAccount.Lista_tranzactii[i].srcIBAN == current_account.IBAN)
                    {
                        CurrentUserAccount.Lista_tranzactii[i].Semn = "-";
                        CurrentUserAccount.CurrentAccount_Balance -= CurrentUserAccount.Lista_tranzactii[i].amount;
                    }
                    else
                    {
                        CurrentUserAccount.Lista_tranzactii[i].Semn = "+";
                        CurrentUserAccount.CurrentAccount_Balance += CurrentUserAccount.Lista_tranzactii[i].amount;
                    }
                    if (CurrentUserAccount.Lista_tranzactii[i].currency == 1)
                    {
                        CurrentUserAccount.Lista_tranzactii[i].TextCurrency = "RON";
                    }
                    if (CurrentUserAccount.Lista_tranzactii[i].currency == 2)
                    {
                        CurrentUserAccount.Lista_tranzactii[i].TextCurrency = "EUR";
                    }
                    if (CurrentUserAccount.Lista_tranzactii[i].currency == 3)
                    {
                        CurrentUserAccount.Lista_tranzactii[i].TextCurrency = "USD";
                    }
                    CurrentUserAccount.Lista_tranzactii[i].IDFereastra = i + 1;
                }
                CurrentUserAccount.STRCurrentAccount_Balance = CurrentUserAccount.CurrentAccount_Balance.ToString("0.00");

                
            }

        }

    }
}



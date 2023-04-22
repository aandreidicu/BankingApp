using SMB.Models;
using SMB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SMB.ViewModel
{
    public class TransfersViewModel : ViewModelBase
    {
        //Field-uri
        private string _iban;
        private decimal _amount;
        private string _description;
        private string _errorMsg;
        private string _succesMessage;

        private IUserRepository userRepository;
        public UserAccountModel _currentUserAccount;
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

        public string Iban { get => _iban; set { _iban = value; OnPropertyChanged(nameof(Iban)); } }
        public decimal Amount { get => _amount; set { _amount = value; OnPropertyChanged(nameof(Amount)); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged(nameof(Description)); } }
        public string ErrorMsg { get => _errorMsg; set { _errorMsg = value; OnPropertyChanged(nameof(ErrorMsg)); } }
        public string SuccesMessage { get => _succesMessage; set { _succesMessage = value; OnPropertyChanged(nameof(SuccesMessage)); } }


        //Comenzi
        public ICommand SendCommand { get; }

        //Constructor
        public TransfersViewModel()
        {
            userRepository = new UserRepository();
            SendCommand = new ViewModelCommand(ExecuteSendCommand, CanExecuteSendCommand);
        }

        private bool CanExecuteSendCommand(object obj)
        {
            bool validTransfer;
            if (string.IsNullOrWhiteSpace(Iban) || Amount == 0 || Amount<2)
                validTransfer = false;
            else
                validTransfer = true;
            return validTransfer;
        }
        private void ExecuteSendCommand(object obj)
        {
            CurrentUserAccount = new UserAccountModel();
            var user = userRepository.GetByMail(Thread.CurrentPrincipal.Identity.Name);
            var current_account = userRepository.getCurrentAccountbyID(user.userID);
            var receiver_accountID = userRepository.GetByIBAN(Iban);
            var receiver_account = userRepository.GetByID(receiver_accountID);
            
            

            var transactions = userRepository.getTransactionsListbyIBAN(current_account.IBAN);
            CurrentUserAccount.Lista_tranzactii = transactions;
            for (int i = 0; i < transactions.Count; i++)
            {
                if (CurrentUserAccount.Lista_tranzactii[i].srcIBAN == current_account.IBAN)
                {

                    CurrentUserAccount.CurrentAccount_Balance -= CurrentUserAccount.Lista_tranzactii[i].amount;
                }
                else
                {

                    CurrentUserAccount.CurrentAccount_Balance += CurrentUserAccount.Lista_tranzactii[i].amount;
                }
            }
            var ctx = new BigBankDBEntities1();
            
            var idCount = ctx.Transactions.Count();
            

            if (receiver_account != null && Amount <= CurrentUserAccount.CurrentAccount_Balance)
            {
                idCount++;
                userRepository.SendMoneyTransfer(idCount,current_account.IBAN, Iban, current_account.currency, Amount, Description);//trebuie modificat astfel incat sa pot obtine iban current si currency
                ErrorMsg = "";
                SuccesMessage = "The transfer was executed successfully!";
            }
            else if(receiver_account == null)
            {
                ErrorMsg = "* invalid IBAN or doesn't exist";
            }
            else if(Amount > CurrentUserAccount.CurrentAccount_Balance)
            {
                ErrorMsg = "* insufficient funds";
            }
            
        }
    }
}

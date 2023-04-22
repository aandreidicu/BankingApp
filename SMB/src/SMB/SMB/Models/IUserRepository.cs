using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SMB.Models
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UsersLegal userLegalModel);
        void Edit(UsersLegal userLegalMode);
        void Remove(System.Guid id);
        UsersLegal GetByID(System.Guid id);
        UsersLegal GetByMail(string mail);
        IEnumerable<UsersLegal> GetByAll();
        //II

        CurrentAccount getCurrentAccountbyID(Guid ID);
        Deposit getDepositbyID(Guid ID);
        List<Transaction> getTransactionsListbyIBAN(string IBAN);
        Guid GetByIBAN(string IBAN);

        //III
        void SendMoneyTransfer(int id_add,string currIBAN,string IBAN,int currency,decimal amount,string description);
        void AddUser(UsersLegal user,CurrentAccount user_account);
    }
}

using SMB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SMB.Repositories
{
    public class UserRepository : UsersLegal, IUserRepository
    {
        public void Add(UsersLegal userLegalModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser = false;
            //using (var command = new SqlCommand())
            //{
            //    command.CommandText = "select * from [UserLegal] where mail=@mail and [password]=@password";
            //    command.Parameters.Add("@mail", System.Data.SqlDbType.NVarChar).Value = credential.UserName;
            //    command.Parameters.Add("@mail", System.Data.SqlDbType.NVarChar).Value = credential.Password;
            //    validUser=command.ExecuteScalar() == null ? false : true;
            //}



            using (var ctx = new BigBankDBEntities1())
            {
                var command = from c in ctx.UsersLegals

                              where c.mail == credential.UserName && c.password == credential.Password

                              orderby c.userID

                              select new
                              {

                                  c.mail,
                                  c.password
                              };

                foreach (var user in command)
                {
                    if (user.mail != null && user.password != null)
                    {
                        validUser = true;
                    }
                    else
                    {
                        validUser = false;
                    }
                }
            }
            return validUser;
        }

        public void Edit(UsersLegal userLegalMode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsersLegal> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UsersLegal GetByID(Guid id)
        {
            UsersLegal user = null;

            using (var ctx = new BigBankDBEntities1())
            {
                var command = from c in ctx.UsersLegals

                              where c.userID == id

                              orderby c.userID

                              select new
                              {
                                  c.userID,
                                  c.FirstName,
                                  c.LastName,
                                  c.personalCode,
                                  c.birthDate,
                                  c.County,
                                  c.City,
                                  c.HomeAddress,
                                  c.mail,
                                  c.phone,
                                  c.password
                              };

                foreach (var u in command)
                {

                    user = new UsersLegal()
                    {
                        userID = u.userID,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        personalCode = u.personalCode,
                        birthDate = u.birthDate,
                        County = u.County,
                        City = u.City,
                        HomeAddress = u.HomeAddress,
                        mail = u.mail,
                        phone = u.phone,
                        password = u.password
                    };
                }
            }
            return user;
        }

        public UsersLegal GetByMail(string mail)
        {
            UsersLegal user = null;

            using (var ctx = new BigBankDBEntities1())
            {
                var command = from c in ctx.UsersLegals

                              where c.mail == mail

                              orderby c.userID

                              select new
                              {
                                  c.userID,
                                  c.FirstName,
                                  c.LastName,
                                  c.personalCode,
                                  c.birthDate,
                                  c.County,
                                  c.City,
                                  c.HomeAddress,
                                  c.mail,
                                  c.phone,
                                  c.password
                              };

                foreach (var u in command)
                {

                    user = new UsersLegal()
                    {
                        userID = u.userID,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        personalCode = u.personalCode,
                        birthDate = u.birthDate,
                        County = u.County,
                        City = u.City,
                        HomeAddress = u.HomeAddress,
                        mail = u.mail,
                        phone = u.phone,
                        password = u.password
                    };
                }
            }
            return user;
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public CurrentAccount getCurrentAccountbyID(Guid ID)
        {
            CurrentAccount account = null;
            using (var ctx = new BigBankDBEntities1())
            {
                var command = from c in ctx.CurrentAccounts
                              where c.UserID == ID
                              orderby c.UserID
                              select new
                              {
                                  c.UserID,
                                  c.IBAN,
                                  c.CompanyID,
                                  c.currency
                              };
                foreach (var u in command)
                {
                    account = new CurrentAccount()
                    {
                        UserID = u.UserID,
                        IBAN = u.IBAN,
                        CompanyID = u.CompanyID,
                        currency = u.currency
                    };
                }
            }
            return account;
        }

        public Deposit getDepositbyID(Guid ID)
        {
            Deposit deposit = null;
            using (var ctx = new BigBankDBEntities1())
            {
                var command = from c in ctx.Deposits
                              where c.UserID == ID
                              orderby c.UserID
                              select new
                              {
                                  c.UserID,
                                  c.IBAN,
                                  c.CompanyID,
                                  c.currency,
                                  c.depositType,
                                  c.creationDate
                              };
                foreach (var u in command)
                {
                    deposit = new Deposit()
                    {
                        UserID = u.UserID,
                        IBAN = u.IBAN,
                        CompanyID = u.CompanyID,
                        currency = u.currency,
                        depositType = u.depositType,
                        creationDate = u.creationDate
                    };
                }
            }
            return deposit;
        }

        public List<Transaction> getTransactionsListbyIBAN(string IBAN)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (var ctx = new BigBankDBEntities1())
            {
                var command = from c in ctx.Transactions
                              where c.srcIBAN == IBAN || c.destIBAN == IBAN
                              select new
                              {
                                  c.ID,
                                  c.srcIBAN,
                                  c.destIBAN,
                                  c.amount,
                                  c.currency,
                                  c.tranDate,
                                  c.tDescription
                              };
                foreach (var u in command)
                {
                    transactions.Add(new Transaction()
                    {
                        ID = u.ID,
                        srcIBAN = u.srcIBAN,
                        destIBAN = u.destIBAN,
                        amount = u.amount,
                        currency = u.currency,
                        tranDate = u.tranDate,
                        tDescription = u.tDescription
                    });

                }
            }
            return transactions;
        }
        public Guid GetByIBAN(string IBAN)
        {
            Guid id = Guid.Empty;
            using (var ctx = new BigBankDBEntities1())
            {
                var command = from c in ctx.CurrentAccounts

                              where c.IBAN == IBAN

                              orderby c.UserID

                              select new
                              {
                                  c.IBAN,
                                  c.UserID,
                                  c.CompanyID,
                                  c.currency
                              };

                foreach (var u in command)
                {
                    id = (Guid)u.UserID;
                }
            }
            return id;
        }
        public void SendMoneyTransfer(int id_add,string currIBAN, string IBAN, int currency, decimal amount, string description)
        {
            using (var ctx = new BigBankDBEntities1())
            {
                var trans = new Transaction();
                trans.ID = id_add;
                trans.srcIBAN = currIBAN;
                trans.destIBAN = IBAN;
                trans.amount = amount;
                trans.currency = currency;
                trans.tranDate = DateTime.Now;
                trans.tDescription = description;


                ctx.Transactions.Add(trans);
                ctx.SaveChanges(); 
            }

        }
        public void AddUser(UsersLegal user,CurrentAccount curracc)
        {
            
            using (var ctx = new BigBankDBEntities1())
            {
                ctx.UsersLegals.Add(user);
                ctx.CurrentAccounts.Add(curracc);
                ctx.SaveChanges();
                
            }
            
        }
    }
}

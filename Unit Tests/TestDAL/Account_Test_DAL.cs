using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using InterfaceLayer;

namespace Unit_Tests
{
    internal class Account_Test_DAL : STUB, IAccount
    {
        internal AccountDTO newAccountDTO;
        internal int newID;
        internal string newName;
        internal string newPassword;
        public bool Create(AccountDTO accountDTO)
        {
            newAccountDTO = accountDTO;
            Accounts.Add(accountDTO);
            return true;
        }

        public AccountDTO GetByID(int id)
        {
            newID = id;
            foreach (AccountDTO account in Accounts)
            {
                if(account.ID == id)
                {
                    return account;
                }
            }
            return null;
        }

        public AccountDTO GetByLogin(string name, string password)
        {
            newName = name;
            newPassword = password;
            foreach (AccountDTO account in Accounts)
            {
                if (account.Name == name && account.Password == password)
                {
                    return account;
                }
            }
            return null;
        }

        public bool Update(AccountDTO accountDTO)
        {
            newAccountDTO = accountDTO;
            for (int i = 0; i < Accounts.Count; i++)
            {
                if (Accounts[i].ID == accountDTO.ID)
                {
                    Accounts[i] = accountDTO;
                    return true;
                }
            }
            return false;
        }
    }
}

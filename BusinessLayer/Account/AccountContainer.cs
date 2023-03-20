using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer;

namespace BusinessLayer
{
    public class AccountContainer
    {
        private readonly IAccount iAccount;

        public AccountContainer(IAccount iAccount)
        {
            this.iAccount = iAccount;
        }

        public bool Create(Account account)
        {
            return iAccount.Create(account.ToAccountDTO());
        }

        public Account GetByID(int id)
        {
            try
            {
                return new(iAccount.GetByID(id));
            }
            catch
            {
                return null;
            }
        }

        public Account GetByLogin(string name, string password)
        {
            try
            {
                return new(iAccount.GetByLogin(name, password));
            }
            catch
            {
                return null;
            }
        }
    }
}

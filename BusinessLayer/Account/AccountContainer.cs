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
            account.Password = account.Password.HashString();
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

        public int Login(Account account)
        {
            try
            {
                account.Password = account.Password.HashString();
                return iAccount.Login(account.ToAccountDTO()).ID;
            }
            catch
            {
                return 0;
            }
        }
    }
}

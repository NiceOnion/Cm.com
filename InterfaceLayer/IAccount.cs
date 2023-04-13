using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IAccount
    {
        bool Create(AccountDTO accountDTO);

        AccountDTO GetByID(int id);

        AccountDTO Login(AccountDTO accountDTO);
    }
}

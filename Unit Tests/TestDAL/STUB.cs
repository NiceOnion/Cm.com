using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using InterfaceLayer;

namespace Unit_Tests
{
    internal class STUB
    {
        internal List<AccountDTO> Accounts = new () { new AccountDTO(1, "TestName1", "TestPassword1"), new AccountDTO(2, "TestName2", "TestPassword 2"), new AccountDTO(3, "TestName3", "TestPassword3")};
    }
}
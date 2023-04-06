using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataAccessLayer;
using InterfaceLayer;

namespace Unit_Tests
{
    internal class STUB : IDemo
    {
        internal List<AccountDTO> Accounts = new() { new AccountDTO(1, "TestName1", "TestPassword1"), new AccountDTO(2, "TestName2", "TestPassword 2"), new AccountDTO(3, "TestName3", "TestPassword3") };
        internal List<DemoDTO> demos = new List<DemoDTO>();

        public STUB()
        {
            demos.Add(new DemoDTO("test", true)
            {
                Id = 1,
            });
            demos.Add(new DemoDTO("test2", true)
            {
                Id = 2
            });
        }

        public bool DeleteDemo(int id)
        {
            DemoDTO demoDTO = demos.FirstOrDefault(x => x.Id == id);
            var result = demos.Remove(demoDTO);
            if (result == true)
            {
                return true;
            }
            return false;
        }


        public List<DemoDTO> GetDemoList()
        {
            return demos;
        }

        public List<DemoDTO> GetDemosOfUser(int userId)
        {
            throw new NotImplementedException();
        }

        public DemoDTO GetOneDemo(int ID)
        {
            throw new NotImplementedException();
        }

        public bool NewDemo(DemoDTO demoDTO)
        {
            throw new NotImplementedException();
        }

        public bool SaveDemo(DemoDTO demoDTO)
        {
            demos.Add(demoDTO);
            return true;
        }
        public bool EditDemo(int DemoID)
        {
            throw new NotImplementedException();
        }
    }
}
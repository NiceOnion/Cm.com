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
    internal class STUB:IDemo
    {
        internal List<AccountDTO> Accounts = new () { new AccountDTO(1, "TestName1", "TestPassword1"), new AccountDTO(2, "TestName2", "TestPassword 2"), new AccountDTO(3, "TestName3", "TestPassword3")};
        internal List<DemoDTO> demos = new List<DemoDTO>();

        public STUB()
        {
            demos.Add(new DemoDTO
            {
                id = 1,
                name = "test",
                visibility = true
            });
            demos.Add(new DemoDTO
            {
                id = 2,
                name = "test2",
                visibility = true
            });
        }

        public bool DeleteDemo(int id)
        {
            DemoDTO demoDTO = demos.FirstOrDefault(x => x.id == id);
            var result = demos.Remove(demoDTO);
            if (result == true)
            {
                return true;
            }
            return false;
        }

        public bool EditDemo(int DemoID)
        {
            throw new NotImplementedException();
        }

        public List<DemoDTO> GetDemoList()
        {
            return demos;
        }

        public DemoDTO GetOneDemo(int ID)
        {
            throw new NotImplementedException();
        }

        public bool NewDemo(DemoDTO demoDTO)
        {
            if (demoDTO.id != null && demoDTO.name != null)
            {
                demos.Add(demoDTO);
                return true;
            }
            return false;
        }

        public bool SaveDemo(DemoDTO demoObject)
        {
            throw new NotImplementedException();
        }
    }
}
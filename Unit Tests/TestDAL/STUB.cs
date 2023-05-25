using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using InterfaceLayer;
using InterfaceLayer.DTO;

namespace Unit_Tests
{
    internal class STUB : IDemo
    {
        internal List<AccountDTO> Accounts = new() { new AccountDTO(1, "TestName1", "TestPassword1"), new AccountDTO(2, "TestName2", "TestPassword 2"), new AccountDTO(3, "TestName3", "5465737450617373776f72643353797374656d2e427974655b5d") };
        internal List<DemoDTO> demos = new List<DemoDTO>();

        public STUB()
        {
            demos.Add(new DemoDTO("test", true)
            {
                Id = 1,
                AccountID = 1,
            });
            demos.Add(new DemoDTO("test2", true)
            {
                Id = 2,
                AccountID = 1,
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
            return demos.Where(demo => demo.AccountID == userId).ToList();
        }

        public DemoDTO GetOneDemo(int ID)
        {
            return demos.Where(demo => demo.Id == ID).First();
        }

        public bool NewDemo(DemoDTO demoDTO)
        {
            demos.Add(demoDTO); 
            return true;
        }

        public bool SaveDemo(DemoDTO demoDTO)
        {
            demos.Add(demoDTO);
            return true;
        }
        public bool EditDemo(DemoDTO demoDTO)
        {
            DemoDTO demo = demos.First(x => x.Id == demoDTO.Id);
            var result = demos.Remove(demo);
             demos.Add(demoDTO);
            return true;
        }

        public bool EditDemo(int DemoID)
        {
            throw new NotImplementedException();
        }

        public DemoDTO GetOneDemoByName(string demoName)
        {
            return demos.Where(demo => demo.Name == demoName).First();
        }

        public List<DemoDTO> GetArchivedDemosOfUser(int userId)
        {
            return demos.Where(demo => demo.AccountID == userId).Where(demo => demo.Visibility == false).ToList();
        }

        public bool ReinstateDemo(int demoId)
        {
            throw new NotImplementedException();
        }

        public List<FlowDTO> GetFlowsOfDemo(int id)
        {
            throw new NotImplementedException();
        }

        public bool FullDeleteDemo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
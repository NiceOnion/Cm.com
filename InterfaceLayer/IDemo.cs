using InterfaceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IDemo
    {
        public bool NewDemo(DemoDTO demoDTO);
        public DemoDTO GetOneDemo(int ID);
        public List<DemoDTO> GetDemosOfUser(int userID);
        public bool SaveDemo(DemoDTO demoObject);
        public bool DeleteDemo(int id);
        public List<DemoDTO> GetDemoList();
        DemoDTO GetOneDemoByName(string demoName);
        public List<DemoDTO> GetArchivedDemosOfUser(int userId);
        public bool ReinstateDemo(int demoId);
        public List<FlowDTO> GetFlowsOfDemo(int id);
        public bool FullDeleteDemo(int id);
    }
}

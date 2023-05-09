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
        public bool EditDemo(DemoDTO demoDTO);
        public bool SaveDemo(DemoDTO demoObject);
       public bool DeleteDemo(int id);
        public List<DemoDTO> GetDemoList();
    }
}

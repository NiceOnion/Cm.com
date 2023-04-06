using DataAccessLayer;
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
        public bool EditDemo(int DemoID);
        public bool SaveDemo(DemoDTO demoObject);
       public bool DeleteDemo(int id);
        public List<DemoDTO> GetDemoList();
        public List<DemoDTO> GetDemosOfUser(int userId);
    }
}

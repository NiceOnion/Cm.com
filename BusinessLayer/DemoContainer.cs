using DataAccessLayer;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DemoContainer
    {
        IDemo IDemo;

        public DemoContainer(IDemo iDemo)
        {
            IDemo = iDemo;
        }

        public bool NewDemoObject(string name, int accountID)
        {
            return IDemo.NewDemo(new DemoDTO(name, accountID));
        }

        public DemoObject GetOneDemoObject(int ID)
        {
            return new DemoObject(IDemo.GetOneDemo(ID));
        }

        public List<DemoObject> GetDemosOfUser(int userID)
        {
            return IDemo.GetDemosOfUser(userID).ConvertAll(demoDTO => new DemoObject(demoDTO)); ;
        }
        public bool EditDemo(int DemoID)
        {
            return EditDemo(DemoID);
        }
        public bool SaveDemo(DemoObject demoObject)
        {
            DemoDTO demoDTO = new DemoDTO(demoObject.Name);
            IDemo.SaveDemo(demoDTO);
            return true;
        }
        public bool DeleteDemo(int id)
        {
            return IDemo.DeleteDemo(id);
        }
        public List<DemoObject> GetDemoList()
        {
            List<DemoDTO> demoDTO = IDemo.GetDemoList();
            List<DemoObject> demoList = new List<DemoObject>();
            foreach (DemoDTO demo in demoDTO)
            {
                demoList.Add(new DemoObject(demo));
            }

            return demoList;
        }
    }
}

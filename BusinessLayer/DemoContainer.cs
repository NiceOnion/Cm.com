using InterfaceLayer;
using InterfaceLayer.DTO;
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

        public bool NewDemoObject(DemoObject demoObject)
        {
            return IDemo.NewDemo(new DemoDTO(demoObject.Name, demoObject.Visibility, demoObject.AccountId, demoObject.Id,demoObject.Description));
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
            demoDTO.Visibility = demoObject.Visibility;
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

        public DemoObject GetOneDemoObjectByName(string name)
        {
            return new DemoObject(IDemo.GetOneDemoByName(name));
        }

        public List<Flow> GetFlowsOfDemo(int id)
        {
            return IDemo.GetFlowsOfDemo(id).ConvertAll(flowDTO => new Flow(flowDTO));
        }

        public List<DemoObject> GetArchivedDemosOfUser(int userId)
        {
            return IDemo.GetArchivedDemosOfUser(userId).ConvertAll(demoDTO => new DemoObject(demoDTO));
        }
        public bool ReinstateDemo(int demoId)
        {
            return IDemo.ReinstateDemo(demoId);
        }
    }
}

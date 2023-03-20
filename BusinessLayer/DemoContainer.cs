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

        public DemoContainer (IDemo iDemo)
        {
            IDemo = iDemo;
        }

        public bool NewDemoObject(string name /*, Account account*/)
        {
            return IDemo.NewDemo(new DemoDTO( name /*, account*/));
        }

        public DemoObject GetOneDemoObject(int ID) 
        {
            return new DemoObject(IDemo.GetOneDemo(ID));
        }
        public List<DemoObject> GetAllDemo() 
        {
            return new List<DemoObject>(IDemo.GetAllDemo().ConvertAll(demoDTO => new DemoObject(demoDTO)));
        }
    }
}

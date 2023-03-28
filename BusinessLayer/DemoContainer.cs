using DataAccessLayer;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal class DemoContainer
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
        public bool EditDemo(int DemoID)
        {
            return EditDemo(DemoID);
        }
    }
}

using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DemoObject
    {
        public string Name { get; private set; } = "";
        //public Account account { get; private set; }
        
        public DemoObject(string name){
            Name = name;
        }

        public DemoObject(DemoDTO demoDTO) {

            this.Name = demoDTO.Name;
            //this.account = account;
        }
    }
}

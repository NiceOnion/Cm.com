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
        public string name { get; private set; } = "";
        //public Account account { get; private set; }
        
        public DemoObject(){

        }

        public DemoObject(DemoDTO demoDTO) {

            this.name = demoDTO.name;
            //this.account = account;
        }
    }
}

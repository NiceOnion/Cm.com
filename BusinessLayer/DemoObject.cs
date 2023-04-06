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
        public bool visibility { get; private set; }
        public int id { get; private set; }
        //public Account account { get; private set; }

        public DemoObject(){

        public DemoObject(string name, int account){
            Name = name;
            Account = account;
        }

        public DemoObject(DemoDTO demoDTO) {

            this.name = demoDTO.name;
            this.visibility = demoDTO.visibility;
            this.id = demoDTO.id;
            //this.account = account;
        }
    }
}

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
        public string name { get;  set; } = "";
        public bool visibility { get;  set; }
        public int id { get;  set; }
        //public Account account { get; private set; }
        public string Description { get; set; }
        public int AccountId { get; set; }

        public DemoObject(){}

        public DemoObject(string name, int accountId)
        {
            Name = name;
            AccountId = accountId;
        }

        public DemoObject(DemoDTO demoDTO) {

            this.name = demoDTO.Name;
            this.visibility = demoDTO.Visibility;
            this.id = demoDTO.Id;
            //this.account = account;
        }
    }
}

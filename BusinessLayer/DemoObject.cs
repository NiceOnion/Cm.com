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
        public string Name { get;  set; } = "";
        public bool Visibility { get;  set; }
        public int Id { get;  set; }
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

            this.Name = demoDTO.Name;
            this.Visibility = demoDTO.Visibility;
            this.Id = demoDTO.Id;
            this.Description = demoDTO.Description;
        }
    }
}

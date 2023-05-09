using InterfaceLayer;
using InterfaceLayer.DTO;
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
        public string Name { get; set; } = "Demo";
        public bool Visibility { get; set; } = true;
        public int Id { get; set; }
        public int AccountId { get; set; }

        public DemoObject(){}

        public DemoObject(string name, int accountId)
        {
            Name = name;
            AccountId = accountId;
        }

        public DemoObject(DemoDTO demoDTO)
        {
            this.Name = demoDTO.Name;
            this.Visibility = demoDTO.Visibility;
            this.Id = demoDTO.Id;
        }

        public Flow GetFlow(IFlow iflow, int id)
        {
            return new Flow(iflow.GetFlow(id));
        }
    }
}

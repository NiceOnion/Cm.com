using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.DTO
{
    public class FlowDTO
    {
        public int Id;
        public string Name;
        public string Description;
        public string Json;

        public FlowDTO() { }
        public FlowDTO(int id, string name, string description, string json)
        {
            Id = id;
            Name = name;
            Description = description;
            Json = json;
        }
    }
}

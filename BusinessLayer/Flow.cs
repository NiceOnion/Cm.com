using InterfaceLayer;
using InterfaceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer
{
    public class Flow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Json { get; set; }

        public Flow()
        {

        }

        public Flow(int id, string name, string description, string json)
        {
            Id = id;
            Name = name;
            Description = description;
            Json = json;
        }

        public Flow(FlowDTO flowDTO)
        {
            Id = flowDTO.Id;
            Name = flowDTO.Name;
            Description = flowDTO.Description;
            Json = flowDTO.Json;
        }

        public FlowDTO toDTO()
        {
            return new FlowDTO()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Json = this.Json,
            };
        }

        public bool Edit(IFlow iFlow)
        {
            return iFlow.Edit(this.toDTO());
        }
    }
}

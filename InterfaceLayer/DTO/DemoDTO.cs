using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace InterfaceLayer.DTO
{
    [DataContract]
    public class DemoDTO
    {
        public string Name { get; set; }
        public bool Visibility { get; set; }
        public int AccountID { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }

        public DemoDTO(string name)
        {
            Name = name;
        }
        public DemoDTO(string name, int accountID)
        {
            Name = name;
            AccountID = accountID;
        }
        public DemoDTO(string name, bool visibility)
        {
            Name = name;
            Visibility = visibility;
        }

        [JsonConstructor]
        public DemoDTO(string name, bool visibility, int accountID, int id, string description)
        {
            AccountID = accountID;
            Id = id;
            Name = name;
            Visibility = visibility;
            Description = description;
        }

        public DemoDTO()
        {
        }
    }
}
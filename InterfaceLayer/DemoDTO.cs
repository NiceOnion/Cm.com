using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DataAccessLayer
{
    [DataContract]
    public class DemoDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Visibility { get; set; }
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public int Id { get; set; }
        public string Description { get; set; }

        public DemoDTO(string name) 
        {
            this.Name = name;
        }
        public DemoDTO()
        {

        }

        [JsonConstructor]
        public DemoDTO(string name, bool visibility, int accountID, int id)
        {
            AccountID = accountID;
            Id = id;
            Name = name;
            Visibility = visibility;            
        }
    }
}
namespace DataAccessLayer
{
    public class DemoDTO
    {
        public string name { get; set; }    
        public bool visibility { get; set; }    
        public int id { get; set; } 

        public DemoDTO(string name) 
        {
            this.name = name;
        }
        public DemoDTO()
        {

        }

    }
}
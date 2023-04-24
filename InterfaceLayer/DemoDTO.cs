namespace DataAccessLayer
{
    public class DemoDTO
    {
        public string Name { get; set; }    
        public bool Visibility { get; set; }  
        public int AccountID { get; set; }
        public int Id { get; set; } 

        public DemoDTO(string name) 
        {
            this.Name = name;
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

    }
}
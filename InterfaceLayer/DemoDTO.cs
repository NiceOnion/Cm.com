namespace DataAccessLayer
{
    public class DemoDTO
    {
        public string Name;
        public int AccountId;
        public bool Visibility = false;

        public DemoDTO(string name, bool visibility) 
        {
            this.Name = name;
            this.Visibility = visibility;
        }
        public DemoDTO(string name, int accountId) 
        {
            this.Name = name;
            this.AccountId = accountId;
        }
        public DemoDTO(string name, int accountId, bool visibility) 
        {
            this.Name = name;
            this.AccountId = accountId;
            this.Visibility = visibility;
        }
    }
}
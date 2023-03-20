using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public class AccountDTO
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }

        public AccountDTO(int id, string name, string password)
        {
            this.ID = id;
            this.Name = name;
            this.Password = password;
        }
    }
}

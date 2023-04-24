using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer;

namespace BusinessLayer
{
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Account(int id, string name, string password)
        {
            this.ID = id;
            this.Name = name;
            this.Password = password;
        }

        public Account(AccountDTO accountDTO)
        {
            this.ID = accountDTO.ID;
            this.Name = accountDTO.Name;
            this.Password = accountDTO.Password;
        }

        public Account() { }

        public AccountDTO ToAccountDTO()
        {
            return new(this.ID, this.Name, this.Password);
        }
    }
}

using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IDemo
    {
        public bool NewDemo(DemoDTO demoDTO);
        public DemoDTO GetOneDemo(int ID);
    }
}

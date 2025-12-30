using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developer_evaluation_btg.Model
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }        
        public int Age { get; set; }
        public string Address { get; set; }
    }
}

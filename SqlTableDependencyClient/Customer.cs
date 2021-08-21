using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTableDependencyClient
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //Properties not present in the database are ignored
        public string City { get; set; }
        public DateTime Born { get; set; }
    }
}

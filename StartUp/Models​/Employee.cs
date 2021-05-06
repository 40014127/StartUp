using System;
using System.Collections.Generic;

#nullable disable

namespace StartUp.Models​
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

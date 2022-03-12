using Common.Helper.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Abstraction.Entities
{
  public  interface IDepartmentEntity : IAggregateRoot
    {
     
        public string Name { get; set; }
    }
}

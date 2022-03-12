using Common.Helper.Commons;

using StudentManagement.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Abstraction.Entities
{
  public  interface IStudentEntity : IAggregateRoot

    {
        string StudentRegNumber { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        string Address { get; set; }
         string Gender { get; set; }
         Guid DepartmentId { get; set; }
         string Level { get; set; }

        Guid programId { get; set; }
    }
    
}

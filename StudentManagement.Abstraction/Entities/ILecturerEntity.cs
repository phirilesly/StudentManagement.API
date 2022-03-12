
using Common.Helper.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Abstraction.Entities
{
  public  interface ILecturerEntity : IAggregateRoot
    {
     
         string Name { get; set; }
         Guid DepartmentId { get; set; }
         Guid CourseId { get; set; }
    }
}

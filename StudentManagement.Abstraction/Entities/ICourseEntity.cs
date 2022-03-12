
using Common.Helper.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Abstraction.Entities
{
   public interface ICourseEntity : IAggregateRoot
    {
         
         string Level { get; set; }
         string Name { get; set; }
         Guid DepartmentId { get; set; }
        Guid LecturerId { get; set; }
    }
}

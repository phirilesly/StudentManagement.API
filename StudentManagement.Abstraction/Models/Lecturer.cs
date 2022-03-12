
using Common.Helper.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Abstraction.Models
{
  public  class Lecturer: BaseModel, ICommandData
    {
     
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CourseId { get; set; }
    }
}

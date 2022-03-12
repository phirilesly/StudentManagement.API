using Common.Helper.Commons;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Abstraction.Models
{
  public  class Course: BaseModel, ICommandData
    {
     
        public string Level { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid LecturerId { get; set; }

        public Guid programId { get; set; }
    }
}

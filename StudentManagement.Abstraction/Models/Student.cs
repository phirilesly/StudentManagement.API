
using Common.Helper.Commons;
using StudentManagement.Abstraction.Command;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Abstraction.Models
{
   public class Student: BaseModel, ICommandData
    {
        public string StudentRegNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public Guid DepartmentId { get; set; }
       public string Level { get; set; }

        public Guid programId { get; set; }

    }
}

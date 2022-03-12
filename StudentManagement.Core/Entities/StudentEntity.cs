using StudentManagement.Abstraction.Entities;
using System;

namespace StudentManagement.Core.Entities
{
    public class StudentEntity : IStudentEntity
    {
       

        public string Address { get ; set ; }
        public string Gender { get ; set ; }
        public Guid DepartmentId { get ; set ; }
        public string Level { get ; set ; }

        public DateTime LastProcessedEventTime =>DateTime.Now;

        public bool IsDeleted { get ; set ; }
        public bool IsNew { get ; set ; }
        public Guid Id {get ; set ; }
        public string StudentRegNumber { get ; set ; }
        public string FirstName { get ; set ; }
        public string Surname { get ; set ; }
        public Guid programId { get ; set ; }
    }
}

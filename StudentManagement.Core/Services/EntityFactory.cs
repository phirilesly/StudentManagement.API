using StudentManagement.Abstraction.Entities;
using StudentManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Services
{
  public static class EntityFactory
    {
        public static IStudentEntity CreateStudent()
        {
            return new StudentEntity()
            {
                IsNew = true,
                Id = Guid.NewGuid()
            };
        }

        public static IDepartmentEntity CreateDepartment()
        {
            return new DepartmentEntity()
            {
                IsNew = true,
                Id = Guid.NewGuid()
            };
        }

        public static ILecturerEntity CreateLecturer()
        {
            return new LecturerEntity()
            {
                IsNew = true,
                Id = Guid.NewGuid()
            };
        }

        public static ICourseEntity CreateCourse()
        {
            return new CourseEntity()
            {
                IsNew = true,
                Id = Guid.NewGuid()
            };
        }

        public static IDegreeProgramEntity CreateDegreeProgram()
        {
            return new DegreeProgramEntity()
            {
                IsNew = true,
                Id = Guid.NewGuid()
            };
        }
    }
}

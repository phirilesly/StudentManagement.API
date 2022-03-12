using Common.Helper.Commons;
using StudentManagement.Abstraction.Entities;
using StudentManagement.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Abstraction.Service
{
   public interface IStudentManagementQueryHandler
    {
        Task<IStudentEntity> GetStudent(Guid id);

        Task<List<IStudentEntity>> GetAllStudents();

        Task<IDepartmentEntity> GetDepartment(Guid id);

        Task<List<IDepartmentEntity>> GetAlldepartments();

        Task<ICourseEntity> GetCourse(Guid id);

        Task<List<ICourseEntity>> GetAllCourses();

        Task<ILecturerEntity> GetLecturer(Guid id);
        Task<List<ILecturerEntity>> GetAllLecturers();

        Task<List<IDegreeProgramEntity>> GetAllDegreePrograms();

        Task<IDegreeProgramEntity> GetDegreeProgram(Guid id);

        Task<IEnumerable<IStudentEntity>> GetStudents(List<SearchParameter> searchParameters);
        Task<IEnumerable<ICourseEntity>> GetCourses(List<SearchParameter> searchParameters);
        Task<IEnumerable<ILecturerEntity>> GetLecturers(List<SearchParameter> searchParameters);
        Task<IEnumerable<IDegreeProgramEntity>> GetDegreePrograms(List<SearchParameter> searchParameters);

        Task<IEnumerable<IDepartmentEntity>> GetDepartments(List<SearchParameter> searchParameters);




    }
}

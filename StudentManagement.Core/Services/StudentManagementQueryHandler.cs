
using Common.Helper.Commons;
using StudentManagement.Abstraction.Entities;
using StudentManagement.Abstraction.Repositories;
using StudentManagement.Abstraction.Service;
using StudentManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Core.Services
{
    public class StudentManagementQueryHandler : IStudentManagementQueryHandler
    {
        private IStudentRepository _studentRepository;
        private IDepartmentRepository _departmentRepository;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IDegreeProgramRepository _degreeProgramRepository;
        public StudentManagementQueryHandler(IStudentRepository repository, ILecturerRepository lecturerRepository, ICourseRepository courseRepository, IDepartmentRepository departmentRepository, IDegreeProgramRepository degreeProgramRepository)
        {
            _studentRepository = repository;
            _lecturerRepository = lecturerRepository;
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
            _degreeProgramRepository = degreeProgramRepository;
        }

        public async Task<List<IStudentEntity>> GetAllStudents()
        {
            var search = new List<SearchParameter> { new SearchParameter { } };
            var students = await _studentRepository.FindModelsAsync(search);
            return students.ToList();
        }

      

        public async Task<IStudentEntity> GetStudent(Guid id)
        {
            return await _studentRepository.LoadModelAsync(id);
        }

     



        public async Task<IDepartmentEntity> GetDepartment(Guid id)
        {
            return await _departmentRepository.LoadModelAsync(id);
        }

        public async Task<List<IDepartmentEntity>> GetAlldepartments()
        {
            var search = new List<SearchParameter> { new SearchParameter { } };
            var students = await _departmentRepository.FindModelsAsync(search);
            return students.ToList();
        }

        public async Task<ICourseEntity> GetCourse(Guid id)
        {
            return await _courseRepository.LoadModelAsync(id);
        }

        public async Task<List<ICourseEntity>> GetAllCourses()
        {
            var search = new List<SearchParameter> { new SearchParameter { } };
            var courses = await _courseRepository.FindModelsAsync(search);
            return courses.ToList();
        }

        public async Task<ILecturerEntity> GetLecturer(Guid id)
        {
            return await _lecturerRepository.LoadModelAsync(id);
        }

        public async Task<List<ILecturerEntity>> GetAllLecturers()
        {
            var search = new List<SearchParameter> { new SearchParameter { } };
            var students = await _lecturerRepository.FindModelsAsync(search);
            return students.ToList();
        }

        public async Task<List<IDegreeProgramEntity>> GetAllDegreePrograms()
        {
            var search = new List<SearchParameter> { new SearchParameter { } };
            var students = await _degreeProgramRepository.FindModelsAsync(search);
            return students.ToList();
        }

        public async Task<IDegreeProgramEntity> GetDegreeProgram(Guid id)
        {
            return await _degreeProgramRepository.LoadModelAsync(id);
        }

        public async Task<IEnumerable<IStudentEntity>> GetStudents(List<SearchParameter> searchParameters)
        {
            return await _studentRepository.FindModelsAsync(searchParameters);
        }

        public async Task<IEnumerable<ICourseEntity>> GetCourses(List<SearchParameter> searchParameters)
        {
            return await  _courseRepository.FindModelsAsync(searchParameters);
        }

        public async Task<IEnumerable<ILecturerEntity>> GetLecturers(List<SearchParameter> searchParameters)
        {
            return await _lecturerRepository.FindModelsAsync(searchParameters);
        }

        public async Task<IEnumerable<IDegreeProgramEntity>> GetDegreePrograms(List<SearchParameter> searchParameters)
        {
            return await  _degreeProgramRepository.FindModelsAsync(searchParameters);
        }

        public async Task<IEnumerable<IDepartmentEntity>> GetDepartments(List<SearchParameter> searchParameters)
        {
            return await  _departmentRepository.FindModelsAsync(searchParameters);
        }
    }
}

using Common.Helper.Commons;
using Common.Helper.Commons.Enums;
using StudentManagement.Abstraction.Command;
using StudentManagement.Abstraction.Models;
using StudentManagement.Abstraction.Repositories;
using StudentManagement.Abstraction.Service;
using StudentManagement.Core.Aggregates;
using StudentManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Services
{
    public class StudentManagementApplication : IStudentManagementApplication
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IDegreeProgramRepository _degreeProgramRepository;

        public StudentManagementApplication(IStudentRepository repository, ILecturerRepository lecturerRepository, ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            _studentRepository = repository;
            _lecturerRepository = lecturerRepository;
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }


        public async Task<CommandResult> AddDepartment(AddDepartment command)
        {
            var entity = (DepartmentEntity)await _departmentRepository.LoadAggregateAsync(Guid.Empty);

            var aggregate = new DepartmentAggregate(entity);
            var resourse = command.CommandData;
            resourse.Id = aggregate.Id;

            var commandResult = new CommandResult<Department>(aggregate.Id, resourse, true);

            var result = aggregate.Register(command.CommandData);
            if (result.IsValid)
            {
                await _departmentRepository.SaveAggregateAsync(entity);
            }
            else
            {
                commandResult = new CommandResult<Department>(Guid.Empty, command.CommandData, false);
                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }



        public async Task<CommandResult> AddStudent(AddStudent command)
        {
            var entity = (StudentEntity)await _studentRepository.LoadAggregateAsync(Guid.Empty);

            var aggregate = new StudentAggregate(entity);
            var resourse = command.CommandData;
            resourse.Id = aggregate.Id;

            var commandResult = new CommandResult<Student>(aggregate.Id, resourse, true);

            var result = aggregate.Register(command.CommandData);
            if (result.IsValid)
            {
                await _studentRepository.SaveAggregateAsync(entity);
            }
            else
            {
                commandResult = new CommandResult<Student>(Guid.Empty, command.CommandData, false);
                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }

        public async Task<CommandResult> Addcourse(AddCourse command)
        {
            var entity = (CourseEntity)await _courseRepository.LoadAggregateAsync(Guid.Empty);

            var aggregate = new CourseAggregate(entity);
            var resourse = command.CommandData;
            resourse.Id = aggregate.Id;

            var commandResult = new CommandResult<Course>(aggregate.Id, resourse, true);

            var result = aggregate.Register(command.CommandData);
            if (result.IsValid)
            {
                await _courseRepository.SaveAggregateAsync(entity);
            }
            else
            {
                commandResult = new CommandResult<Course>(Guid.Empty, command.CommandData, false);
                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }




        public async Task<CommandResult> AddLecturer(AddLecturer command)
        {
            var entity = (LecturerEntity)await _lecturerRepository.LoadAggregateAsync(Guid.Empty);

            var aggregate = new LecturerAggregate(entity);
            var resourse = command.CommandData;
            resourse.Id = aggregate.Id;

            var commandResult = new CommandResult<Lecturer>(aggregate.Id, resourse, true);

            var result = aggregate.Register(command.CommandData);
            if (result.IsValid)
            {
                await _lecturerRepository.SaveAggregateAsync(entity);
            }
            else
            {
                commandResult = new CommandResult<Lecturer>(Guid.Empty, command.CommandData, false);
                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }





        public async Task<CommandResult> UpdateStudent(UpdateStudent command)
        {
            //load 

            var entity = (StudentEntity)await _studentRepository.LoadAggregateAsync(command.CommandData.Id);

            //initialise
            var aggregate = new StudentAggregate(entity);
            var commandResult = new CommandResult(entity.Id, true);

            //validate 
            var result = aggregate.Update(command.CommandData);

            if (result.IsValid)
            {
                //save 

                await _studentRepository.SaveAggregateAsync(entity);


            }
            else
            {
                commandResult = new CommandResult(Guid.Empty, false);

                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }

        public async Task<CommandResult> RemoveStudent(DeleteStudent command)
        {
            var entity = (StudentEntity)await _studentRepository.LoadAggregateAsync(command.CommandData.Id);

            //initialise
            var aggregate = new StudentAggregate(entity);
            var commandResult = new CommandResult(entity.Id, true);

            //delete 

            aggregate.Delete();
            await _studentRepository.SaveAggregateAsync(entity);


            return commandResult;
        }

        public async Task<CommandResult> UpdateCourse(UpdateCourse command)
        {
            //load 

            var entity = (CourseEntity)await _courseRepository.LoadAggregateAsync(command.CommandData.Id);

            //initialise
            var aggregate = new CourseAggregate(entity);
            var commandResult = new CommandResult(entity.Id, true);

            //validate 
            var result = aggregate.Update(command.CommandData);

            if (result.IsValid)
            {
                //save 

                await _courseRepository.SaveAggregateAsync(entity);


            }
            else
            {
                commandResult = new CommandResult(Guid.Empty, false);

                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }

        public async Task<CommandResult> RemoveCourse(DeleteCourse command)
        {
            var entity = (CourseEntity)await _courseRepository.LoadAggregateAsync(command.CommandData.Id);

            //initialise
            var aggregate = new CourseAggregate(entity);
            var commandResult = new CommandResult(entity.Id, true);

            //delete 

            aggregate.Delete();
            await _courseRepository.SaveAggregateAsync(entity);


            return commandResult;
        }

        public async Task<CommandResult> UpdateDepartment(UpdateDepartment command)
        {
            //load 

            var entity = (DepartmentEntity)await _departmentRepository.LoadAggregateAsync(command.CommandData.Id);

            //initialise
            var aggregate = new DepartmentAggregate(entity);
            var commandResult = new CommandResult(entity.Id, true);

            //validate 
            var result = aggregate.Update(command.CommandData);

            if (result.IsValid)
            {
                //save 

                await _departmentRepository.SaveAggregateAsync(entity);


            }
            else
            {
                commandResult = new CommandResult(Guid.Empty, false);

                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }

        public async Task<CommandResult> RemoveDepartment(DeleteDepartment command)
        {
            var entity = (DepartmentEntity)await _departmentRepository.LoadAggregateAsync(command.CommandData.Id);

            //initialise
            var aggregate = new DepartmentAggregate(entity);
            var commandResult = new CommandResult(entity.Id, true);

            //delete 

            aggregate.Delete();
            await _departmentRepository.SaveAggregateAsync(entity);


            return commandResult;
        }

        public async Task<CommandResult> UpdateLecturer(UpdateLecturer command)
        {
            //load 

            var entity = (LecturerEntity)await _lecturerRepository.LoadAggregateAsync(command.CommandData.Id);

            //initialise
            var aggregate = new LecturerAggregate(entity);
            var commandResult = new CommandResult(entity.Id, true);

            //validate 
            var result = aggregate.Update(command.CommandData);

            if (result.IsValid)
            {
                //save 

                await _lecturerRepository.SaveAggregateAsync(entity);


            }
            else
            {
                commandResult = new CommandResult(Guid.Empty, false);

                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }

        public async Task<CommandResult> DeleteLecturer(DeleteLecturer command)
        {
            var entity = (LecturerEntity)await _lecturerRepository.LoadAggregateAsync(command.CommandData.Id);

            //initialise
            var aggregate = new LecturerAggregate(entity);
            var commandResult = new CommandResult(entity.Id, true);

            //delete 
        
            aggregate.Delete();
            await _lecturerRepository.SaveAggregateAsync(entity);


            return commandResult;
        }

        public async Task<CommandResult> AddDegreeProgram(AddDegreeProgram command)
        {
            var entity = (DegreeProgramEntity)await _degreeProgramRepository.LoadAggregateAsync(Guid.Empty);

            var aggregate = new DegreeProgramAggregate(entity);
            var resourse = command.CommandData;
            resourse.Id = aggregate.Id;

            var commandResult = new CommandResult<DegreeProgram>(aggregate.Id, resourse, true);

            var result = aggregate.Register(command.CommandData);
            if (result.IsValid)
            {
                await _degreeProgramRepository.SaveAggregateAsync(entity);
            }
            else
            {
                commandResult = new CommandResult<DegreeProgram>(Guid.Empty, command.CommandData, false);
                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }

        public async Task<CommandResult> UpdateDegreeProgram(UpdateDegreeProgram command)
        {
            //load 

            var entity = (DegreeProgramEntity)await _degreeProgramRepository.LoadAggregateAsync(command.CommandData.Id);

            //initialise
            var aggregate = new DegreeProgramAggregate(entity);
            var commandResult = new CommandResult(entity.Id, true);

            //validate 
            var result = aggregate.Update(command.CommandData);

            if (result.IsValid)
            {
                //save 

                await _degreeProgramRepository.SaveAggregateAsync(entity);


            }
            else
            {
                commandResult = new CommandResult(Guid.Empty, false);

                foreach (var validationMessage in result.ValidationMessages)
                {
                    commandResult.AddResultMessage(ResultMessageType.Error, validationMessage.Code, validationMessage.Message);
                }
            }
            return commandResult;
        }

        public async Task<CommandResult> DeleteDegreeProgram(DeleteDegreeProgram command)
        {
            var entity = (DegreeProgramEntity)await _degreeProgramRepository.LoadAggregateAsync(command.CommandData.Id);

            //initialise
            var aggregate = new DegreeProgramAggregate(entity);
            var commandResult = new CommandResult(entity.Id, true);

            //delete 

            aggregate.Delete();
            await _degreeProgramRepository.SaveAggregateAsync(entity);


            return commandResult;
        }
    }
}

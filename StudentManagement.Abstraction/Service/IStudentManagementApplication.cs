using Common.Helper.Commons;
using StudentManagement.Abstraction.Command;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Abstraction.Service
{
  public  interface IStudentManagementApplication
    {
        Task<CommandResult> AddStudent(AddStudent command);
        Task<CommandResult> Addcourse(AddCourse command);
        Task<CommandResult> AddDepartment(AddDepartment command);
        Task<CommandResult> AddLecturer(AddLecturer command);

        Task<CommandResult> AddDegreeProgram(AddDegreeProgram command);

        Task<CommandResult> UpdateDegreeProgram(UpdateDegreeProgram command);

        Task<CommandResult> DeleteDegreeProgram(DeleteDegreeProgram command);


        Task<CommandResult> UpdateStudent(UpdateStudent command);
        Task<CommandResult> RemoveStudent(DeleteStudent command);

        Task<CommandResult> UpdateCourse(UpdateCourse command);
        Task<CommandResult> RemoveCourse(DeleteCourse command);

        Task<CommandResult> UpdateDepartment(UpdateDepartment command);
        Task<CommandResult> RemoveDepartment(DeleteDepartment command);

        Task<CommandResult> UpdateLecturer(UpdateLecturer command);
        Task<CommandResult> DeleteLecturer(DeleteLecturer command);
    }
}

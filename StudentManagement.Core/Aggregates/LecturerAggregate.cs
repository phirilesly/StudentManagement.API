using Common.Helper.Commons;
using StudentManagement.Abstraction.Models;
using StudentManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Aggregates
{
  public  class LecturerAggregate : BaseAggregate<LecturerEntity>
    {
        ValidationResult validationResult = new ValidationResult();
        public LecturerAggregate(LecturerEntity entity) : base(entity)
        {

        }

        private ValidationResult Validate(Lecturer lecturer)
        {
            return validationResult;
        }


        public ValidationResult Register(Lecturer lecturer)
        {
            if (Validate(lecturer).IsValid)
            {
                lecturer.Id = Entity.Id;
                SetDetails(lecturer);
                //AddEvent(new SAdded(register));
            }
            return validationResult;
        }



        public ValidationResult Update(Lecturer lecturer)
        {
            if (Validate(lecturer).IsValid)
            {
                SetDetails(lecturer);


            }
            return validationResult;
        }


        public void Delete()
        {
            Entity.IsDeleted = true;

        }
        private void SetDetails(Lecturer lecturer)
        {
            Entity.CourseId = lecturer.CourseId;
            Entity.Id = lecturer.Id;
            Entity.Name = lecturer.Name;
            Entity.DepartmentId = lecturer.DepartmentId;

        }

    }
}

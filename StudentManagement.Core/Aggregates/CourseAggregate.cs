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
   public class CourseAggregate :  BaseAggregate<CourseEntity>
    {
        ValidationResult validationResult = new ValidationResult();
        public CourseAggregate(CourseEntity entity) : base(entity)
        {

        }

        private ValidationResult Validate(Course course)
        {
            return validationResult;
        }


        public ValidationResult Register(Course course)
        {
            if (Validate(course).IsValid)
            {
                course.Id = Entity.Id;
                SetDetails(course);
                //AddEvent(new SAdded(register));
            }
            return validationResult;
        }



        public ValidationResult Update(Course course)
        {
            if (Validate(course).IsValid)
            {
                SetDetails(course);


            }
            return validationResult;
        }


        public void Delete()
        {
            Entity.IsDeleted = true;

        }
        private void SetDetails(Course course)
        {
            Entity.Id = course.Id;
            Entity.LecturerId = course.LecturerId;
            Entity.Name = course.Name;
            Entity.Level = course.Level;
            Entity.DepartmentId = course.DepartmentId;
            

        }
    }
}

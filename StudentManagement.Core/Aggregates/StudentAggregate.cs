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
   public  class StudentAggregate : BaseAggregate<StudentEntity>
    {
        ValidationResult validationResult = new ValidationResult();
        public StudentAggregate(StudentEntity entity) : base(entity)
        {

        }

        private ValidationResult ValidateAsset(Student student)
        {
            return validationResult;
        }

        
        public ValidationResult Register(Student student)
        {
            if (ValidateAsset(student).IsValid)
            {
                student.Id = Entity.Id;
                SetDetails(student);
                //AddEvent(new SAdded(register));
            }
            return validationResult;
        }

       
       
        public ValidationResult Update(Student student)
        {
            if (ValidateAsset(student).IsValid)
            {
                SetDetails(student);
               

            }
            return validationResult;
        }

        
        public void Delete()
        {
            Entity.IsDeleted = true;
            
        }
        private void SetDetails(Student student)
        {
            Entity.Id = student.Id;
            Entity.FirstName = student.FirstName;
            Entity.DepartmentId = student.DepartmentId;
            Entity.Gender = student.Gender;
            Entity.Address = student.Address;
            Entity.Level = student.Level;
            Entity.programId = student.programId;
            Entity.StudentRegNumber = student.StudentRegNumber;
            Entity.Surname = student.Surname;
            
            
        }


    }
}


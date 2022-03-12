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
    public class DegreeProgramAggregate : BaseAggregate<DegreeProgramEntity>
    {
        ValidationResult validationResult = new ValidationResult();
        public DegreeProgramAggregate(DegreeProgramEntity entity) : base(entity)
        {

        }

        private ValidationResult ValidateAsset(DegreeProgram program)
        {
            return validationResult;
        }


        public ValidationResult Register(DegreeProgram program)
        {
            if (ValidateAsset(program).IsValid)
            {
                program.Id = Entity.Id;
                SetDetails(program);
                //AddEvent(new SAdded(register));
            }
            return validationResult;
        }



        public ValidationResult Update(DegreeProgram program)
        {
            if (ValidateAsset(program).IsValid)
            {
                SetDetails(program);


            }
            return validationResult;
        }


        public void Delete()
        {
            Entity.IsDeleted = true;

        }
        private void SetDetails(DegreeProgram program)
        {
            Entity.Id = program.Id;
            Entity.DepartmentId = program.DepartmentId;
            Entity.Name = program.Name;
            Entity.Level = program.Level;
        

        }


    }
}

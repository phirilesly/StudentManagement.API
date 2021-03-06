using Common.Helper.Commons;
using StudentManagement.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Abstraction.Command
{
  public  class UpdateDegreeProgram:ICommand<DegreeProgram>
    {
        public UpdateDegreeProgram()
        {
            CommandId = Guid.NewGuid();
            Name = GetType().Name.ToLower();
            CommandTime = DateTime.Now;
        }
        public string UserId { get; set; }
        public Guid SubscriptionId { get; set; }
        public string UserEmail { get; set; }
        public DateTime CommandTime { get; set; }
        public Guid CommandId { get; set; }
        public DegreeProgram CommandData { get; set; }
        public string Name { get; set; }
    }
}

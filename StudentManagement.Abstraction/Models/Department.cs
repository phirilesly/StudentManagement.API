using Common.Helper.Commons;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Abstraction.Models
{
   public class Department: BaseModel, ICommandData
    {
      
        public string Name { get; set; }

      
    }
}


using Common.Helper.Commons;
using Common.Helper.Commons.Enums;
using StudentManagement.Abstraction.Entities;
using StudentManagement.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Abstraction.Repositories
{
  public  interface IStudentRepository
    {
        Task<IEnumerable<IStudentEntity>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType);

        Task<IStudentEntity> LoadAggregateAsync(Guid id);

        Task<Guid> SaveAggregateAsync(IStudentEntity aggregate);

        Task<IEnumerable<IStudentEntity>> FindModelsAsync(List<SearchParameter> searchParameters);

        Task<IStudentEntity> LoadModelAsync(Guid modelId);

        Task<Guid> SaveModelAsync(IStudentEntity model);


    }
}

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
  public  interface ICourseRepository
    {
        Task<IEnumerable<ICourseEntity>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType);

        Task<ICourseEntity> LoadAggregateAsync(Guid id);

        Task<Guid> SaveAggregateAsync(ICourseEntity aggregate);

        Task<IEnumerable<ICourseEntity>> FindModelsAsync(List<SearchParameter> searchParameters);

        Task<ICourseEntity> LoadModelAsync(Guid modelId);

        Task<Guid> SaveModelAsync(ICourseEntity model);
    }
}

using Common.Helper.Commons;
using Common.Helper.Commons.Enums;
using StudentManagement.Abstraction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Abstraction.Repositories
{
   public interface IDegreeProgramRepository
    {
        Task<IEnumerable<IDegreeProgramEntity>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType);

        Task<IDegreeProgramEntity> LoadAggregateAsync(Guid id);

        Task<Guid> SaveAggregateAsync(IDegreeProgramEntity aggregate);

        Task<IEnumerable<IDegreeProgramEntity>> FindModelsAsync(List<SearchParameter> searchParameters);

        Task<IDegreeProgramEntity> LoadModelAsync(Guid modelId);

        Task<Guid> SaveModelAsync(IDegreeProgramEntity model);
    }
}

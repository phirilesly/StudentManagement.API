using Common.Helper.Commons;
using Common.Helper.Commons.Enums;
using StudentManagement.Abstraction.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Abstraction.Repositories
{
    public interface IDepartmentRepository 
    {
        Task<IEnumerable<IDepartmentEntity>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType);

        Task<IDepartmentEntity> LoadAggregateAsync(Guid id);

        Task<Guid> SaveAggregateAsync(IDepartmentEntity aggregate);

        Task<IEnumerable<IDepartmentEntity>> FindModelsAsync(List<SearchParameter> searchParameters);

        Task<IDepartmentEntity> LoadModelAsync(Guid modelId);

        Task<Guid> SaveModelAsync(IDepartmentEntity model);
    }
}

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
   public interface ILecturerRepository
    {

        Task<IEnumerable<ILecturerEntity>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType);

        Task<ILecturerEntity> LoadAggregateAsync(Guid id);

        Task<Guid> SaveAggregateAsync(ILecturerEntity aggregate);

        Task<IEnumerable<ILecturerEntity>> FindModelsAsync(List<SearchParameter> searchParameters);

        Task<ILecturerEntity> LoadModelAsync(Guid modelId);

        Task<Guid> SaveModelAsync(ILecturerEntity model);
    }
}

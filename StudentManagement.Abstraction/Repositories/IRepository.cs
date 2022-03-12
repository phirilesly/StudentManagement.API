using Common.Helper.Commons;
using Common.Helper.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Abstraction.Repositories
{
  public  interface IRepository<T,TId>where T : IAggregateRoot
    {
        Task<IEnumerable<T>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType);
        Task<T> LoadAggregateAsync(TId id);
        Task<TId> SaveAggregateAsync(T aggregate);

        Task<T> LoadModelAsync(TId modelId);
        Task<IEnumerable<T>> FindModelsAsync(List<SearchParameter> searchParameters);


        Task<TId> SaveModelAsync(T model);
    }
}

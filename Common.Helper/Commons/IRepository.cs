using Common.Helper.Commons.Enums;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Common.Helper.Commons
{
   public interface IRepository<T, TId> where T: IAggregateRoot
    {
        Task<IEnumerable<T>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType);
        Task<T> LoadAggregateAsync(TId id);
        Task<TId> SaveAggregateAsync(T aggregate);



        Task<T> LoadModelAsync(TId modelId);



        Task<IEnumerable<T>> FindModelsAsync(List<SearchParameter> searchParameters);


       
    }
}

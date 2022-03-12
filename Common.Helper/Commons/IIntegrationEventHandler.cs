
using System.Threading.Tasks;

namespace Common.Helper.Commons
{
    public interface IIntegrationEventHandler<T> where T : IIntegrationEvent
    {
        string HandlerName { get; }
        Task HandleAsync(T @event);
    }
}

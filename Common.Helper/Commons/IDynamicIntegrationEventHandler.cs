
using System.Threading.Tasks;

namespace Common.Helper.Commons
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}

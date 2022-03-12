

namespace Common.Helper.Commons
{
    public interface IIntegrationEvent : IEvent
    {
        string SystemId { get; set; }
        string SystemName { get; set; }
    }
}

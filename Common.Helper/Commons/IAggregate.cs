

using System.Collections.Generic;


namespace Common.Helper.Commons
{
    public interface IAggregate<T> where T : IAggregateRoot
    {
        T Entity { get; }
        IEnumerable<IEvent> Events { get; }
        void AddEvent(IEvent domainEvent);
        void ClearEvents();
    }
}

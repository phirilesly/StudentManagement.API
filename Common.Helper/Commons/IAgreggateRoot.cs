using System;


namespace Common.Helper.Commons
{
    public interface IAggregateRoot : IEntity
    {
        DateTime LastProcessedEventTime { get; }
    }
}

using System;


namespace Common.Helper.Commons
{
    public interface IEvent : IMessage
    {
        Guid EventId { get; }
        DateTime EventTime { get; }

    }

    public interface IEvent<T> : IEvent, IMessage where T : IEventData
    {
        T EventData { get; set; }
    }
}

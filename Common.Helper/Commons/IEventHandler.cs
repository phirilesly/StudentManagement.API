﻿
using System.Threading.Tasks;

namespace Common.Helper.Commons
{
    public interface IEventHandler<T> where T : IEvent
    {
        string HandlerName { get; }
        Task HandleAsync(T @event);
    }
    public interface IEventHandler<T, Td> where T : IEvent<Td> where Td : IEventData
    {
        string HandlerName { get; }
        Task HandleAsync(T @event);
    }
}

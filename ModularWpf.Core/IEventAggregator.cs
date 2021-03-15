using System;

namespace ModularWPF.Core
{
    public interface IEventAggregator
    {
        void Publish<TEvent>(TEvent sampleEvent) where TEvent : EventBase;
        IObservable<TEvent> GetEvent<TEvent>() where TEvent : EventBase;
    }
}

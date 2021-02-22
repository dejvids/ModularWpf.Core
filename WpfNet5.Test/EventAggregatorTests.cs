using System;
using WpfNet5.Core;
using Xunit;

namespace WpfNet5.Test
{
    public class EventAggregatorTests
    {
        [Fact]
        public void EventAggregatorReturnsEvent()
        {
            //Arrange
            var eventAggregator = new EventAggregator();
            var testEvent = new TestEvent { EventId = Guid.NewGuid() };
            TestEvent subscrivedEvent = null;
            
            //Act
            eventAggregator.GetEvent<TestEvent>().Subscribe(e => subscrivedEvent = e);
            eventAggregator.Publish<EventBase>(testEvent);

            //Assert
            Assert.Equal(testEvent.EventId, subscrivedEvent.EventId);
        }

        [Fact]
        public void EventAggregatorShouldSubscribeEachPublish()
        {
            //Arrange
            var eventAggregator = new EventAggregator();
            var event1 = new TestEvent() { EventId = Guid.NewGuid() };
            var event2 = new TestEvent() { EventId = Guid.NewGuid() };
            int subscribedEvents = 0;

            //Act
            eventAggregator.Publish(event1);
            eventAggregator.Publish(event2);
            eventAggregator.GetEvent<TestEvent>().Subscribe(e => subscribedEvents++);

            //Assert
            Assert.Equal(2, subscribedEvents);
        }

        class TestEvent : EventBase
        {
            public Guid EventId { get; set; }
        }

    }
}

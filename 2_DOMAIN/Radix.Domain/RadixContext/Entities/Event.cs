using System;
using Radix.Domain.RadixContext.Entities.Authentication;
using Radix.Shared.Entities;

namespace Radix.Domain.RadixContext.Entities
{
    public class Event: Entity
    {
        public TimeSpan timestamp { get; private set;}
        public string tag { get; private set;}
        public string value{ get; private set;}
        public User user {get; private set;}
        private Event() {}
        public Event(TimeSpan timestamp, string tag, string value, User user)
        {
            this.timestamp = timestamp;
            this.tag = tag;
            this.value = value;
            this.user = user;
        }
    }
}
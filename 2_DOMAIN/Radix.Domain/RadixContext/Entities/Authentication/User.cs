using System.Collections.Generic;
using System.Linq;
using Radix.Shared.Entities;

namespace Radix.Domain.RadixContext.Entities.Authentication
{
    public class User : Entity
    {
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public string Role { get; private set; }
        private IList<Event> _events;
        public IReadOnlyCollection<Event> Events
        {
            get
            {
                return this._events.ToArray();
            }
        }
        protected User() { }
        public User(string userName, string passWord, string role)
        {
            UserName = userName;
            PassWord = passWord;
            Role = role;
        }
        public void AddEvent(Event ev)
        {
            _events.Add(ev);
        }
    }
}
using Radix.Shared.Entities;

namespace Radix.Domain.RadixContext.Entities.Authentication
{
    public class User : Entity
    {
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public string Role { get; private set; }
        private  User(){}
        public User(string userName, string passWord, string role)
        {
            UserName = userName;
            PassWord = passWord;
            Role = role;
        }
    }
}
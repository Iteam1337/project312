using project312.Models;
using System.Collections.Generic;

namespace project312.modules
{
    public interface IDatabaseAccess
    {
        void AddSubscriber(Subscriber subscriber);
        List<Subscriber> GetSubscribers();
    }
}
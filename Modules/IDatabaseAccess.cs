using System;
using Npgsql;

namespace project312.modules
{
    public interface IDatabaseAccess
    {
        void AddSubscriber(string email, string name);
    }
}
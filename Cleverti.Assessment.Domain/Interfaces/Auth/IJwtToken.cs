using Cleverti.Assessment.Domain.Entities;
using System;

namespace Cleverti.Assessment.Domain.Interfaces.Auth
{
    public interface IJwtToken
    {
        string Generate(User user, out DateTime expires);
    }
}

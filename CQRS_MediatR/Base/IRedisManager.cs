using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MediatR.Base
{
    public interface IRedisManager
    {
        bool Create<T>(string cacheKey, T value);
        T Get<T>(string key);
        string GetString(string key);
        bool CreateEventSourcing(EventData data);
        void DeleteApiCache(Type inputModelType);
    }
}

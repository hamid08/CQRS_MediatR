using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MediatR.Base
{
    public static class CacheKeyManager
    {
        public static string GetCacheKey(string apiName)
        {
            return "cache_" + apiName;
        }
        public static string GetCacheKey(string apiName, string args)
        {
            return "cache_" + apiName + "_" + args;
        }
    }
}

using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurboPortalApi.Common.MemoryHelper
{
    public class MemoryCacheHelper
    {
        private static IMemoryCache _memoryCache = null;
        //泛型缓存的根本原理就在于类的静态构造函数只执行一次，
        //而不同的泛型会被认为是不同的类
        static MemoryCacheHelper()
        {
            if (_memoryCache == null)
            {
                _memoryCache = new MemoryCache(new MemoryCacheOptions());
            }
        }
        public static void SetCache(string key, object value)
        {
            //_memoryCache.Set(key, value, TimeSpan.FromMinutes(1));
            _memoryCache.Set(key, value);
        }
        public static object GetCache(string key)
        {
            return _memoryCache.Get(key);
        }
    }
}

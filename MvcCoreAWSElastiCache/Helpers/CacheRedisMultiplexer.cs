using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSElastiCache.Helpers
{
    public class CacheRedisMultiplexer
    {
        private static Lazy<ConnectionMultiplexer> CrearConexion =
            new Lazy<ConnectionMultiplexer>(() =>
            {
                //return ConnectionMultiplexer.Connect("cache-redis-personajes-0001-001.mk0zjh.0001.use1.cache.amazonaws.com:6379,ssl=True,abortConnect=False,sslprotocols=tls12");
                return ConnectionMultiplexer.Connect("cache-personajes-0001-001.mk0zjh.0001.use1.cache.amazonaws.com:6379");
            });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return CrearConexion.Value;
            }
        }
    }
}

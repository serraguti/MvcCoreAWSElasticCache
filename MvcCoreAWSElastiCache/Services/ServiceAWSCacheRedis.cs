using MvcCoreAWSElastiCache.Helpers;
using MvcCoreAWSElastiCache.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSElastiCache.Services
{
    public class ServiceAWSCacheRedis
    {
        private IDatabase cache;

        public ServiceAWSCacheRedis()
        {
            this.cache = CacheRedisMultiplexer.Connection.GetDatabase();
        }

        public void GuardarPersonaje(Personaje p)
        {
            //VAMOS A TENER EN REDIS VARIOS PERSONAJES EN JSON
            List<Personaje> personajes;
            String json = this.cache.StringGet("personajes");
            if (json == null)
            {
                personajes = new List<Personaje>();
            }
            else
            {
                personajes = JsonConvert.DeserializeObject<List<Personaje>>(json);
            }
            personajes.Add(p);
            json = JsonConvert.SerializeObject(personajes);
            this.cache.StringSet("personajes", json
                , TimeSpan.FromMinutes(15));
        }

        public List<Personaje> GetPersonajesCache()
        {
            String json = this.cache.StringGet("personajes");
            if (json == null)
            {
                return null;
            }
            else
            {
                List<Personaje> personajes =
                    JsonConvert.DeserializeObject<List<Personaje>>(json);
                return personajes;
            }
        }
    }
}

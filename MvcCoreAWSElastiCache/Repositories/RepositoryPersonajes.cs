using MvcCoreAWSElastiCache.Data;
using MvcCoreAWSElastiCache.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSElastiCache.Repositories
{
    public class RepositoryPersonajes
    {
        PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public List<Personaje> GetPersonajes()
        {
            return this.context.Personajes.ToList();
        }

        public Personaje FindPersonaje(int id)
        {
            return this.context.Personajes
                .SingleOrDefault(x => x.IdPersonaje == id);
        }

        private int GetMaxIdPersonaje()
        {
            return this.context.Personajes
                .Max(x => x.IdPersonaje) + 1;
        }

        public void InsertPersonaje(String nombre, String imagen)
        {
            Personaje p = new Personaje();
            p.IdPersonaje = this.GetMaxIdPersonaje();
            p.Nombre = nombre;
            p.Imagen = imagen;
            this.context.Personajes.Add(p);
            this.context.SaveChanges();
        }
    }
}

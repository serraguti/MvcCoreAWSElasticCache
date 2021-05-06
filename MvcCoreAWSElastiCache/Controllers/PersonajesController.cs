using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSElastiCache.Models;
using MvcCoreAWSElastiCache.Repositories;
using MvcCoreAWSElastiCache.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSElastiCache.Controllers
{
    public class PersonajesController : Controller
    {
        RepositoryPersonajes repo;
        private ServiceAWSCacheRedis ServiceCache;

        public PersonajesController(RepositoryPersonajes repo
            , ServiceAWSCacheRedis service)
        {
            this.repo = repo;
            this.ServiceCache = service;
        }

        public IActionResult Index()
        {
            return View(this.repo.GetPersonajes());
        }

        public IActionResult Details(int id)
        {
            return View(this.repo.FindPersonaje(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Personaje p)
        {
            this.repo.InsertPersonaje(p.Nombre, p.Imagen);
            return RedirectToAction("Index");
        }

        public IActionResult Favoritos()
        {
            return View(this.ServiceCache.GetPersonajesCache());
        }

        public IActionResult SeleccionarFavorito(int id)
        {
            //BUSCAMOS AL PERSONAJE EN BBDD
            Personaje p = this.repo.FindPersonaje(id);
            //GUARDAMOS EN CACHE
            this.ServiceCache.GuardarPersonaje(p);
            ViewData["MENSAJE"] = "Personaje almacenado";
            return RedirectToAction("Index");
        }
    }
}

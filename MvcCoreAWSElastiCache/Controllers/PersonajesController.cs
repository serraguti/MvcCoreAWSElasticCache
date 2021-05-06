using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSElastiCache.Models;
using MvcCoreAWSElastiCache.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSElastiCache.Controllers
{
    public class PersonajesController : Controller
    {
        RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
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
    }
}

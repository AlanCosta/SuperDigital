using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SuperDigital.IO.Application.Interfaces;
using SuperDigital.IO.Application.Services;
using SuperDigital.IO.Application.ViewModels;
using SuperDigital.IO.Domain.Core.Notifications;
using SuperDigital.IO.Domain.Interfaces;
using SuperDigital.Site.Models;

namespace SuperDigital.Site.Controllers
{
    public class AnunciosController : BaseController
    {
        private readonly IAnuncioAppService context;
        private readonly ISuperDigitalClient client;

        public AnunciosController(IAnuncioAppService _context,
            IDomainNotificationHandler<DomainNotification> notifications,
            ISuperDigitalClient _client) : base(notifications)
        {
            context = _context;
            client = _client;
        }
        // GET: Anuncios
        public ActionResult Index()
        {
            return View(context.ObterTodos());
        }

        // GET: Anuncios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoViewModel = context.ObterPorId(id.Value);
            if (eventoViewModel == null)
            {
                return NotFound();
            }

            return View(eventoViewModel);
        }

        // GET: Anuncios/Create
        public ActionResult Create()
        {
            ViewBag.Marcas = JsonConvert.DeserializeObject<List<Marca>>(client.getMarcas().Content);
            return View();
        }

        // POST: Anuncios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnuncioViewModel collection)
        {
            if (!ModelState.IsValid) return View(collection);

            context.Registrar(collection);

            return RedirectToAction("Index");
        }

        public string ConsultarModelo(int IdMarca)
        {
            var Modelos = JsonConvert.DeserializeObject<List<Modelo>>(client.getModelos(IdMarca).Content);

            return JsonConvert.SerializeObject(Modelos);
        }

        public string ConsultarVersao(int IdModelo)
        {
            var Modelos = JsonConvert.DeserializeObject<List<Versao>>(client.getVersao(IdModelo).Content);

            return JsonConvert.SerializeObject(Modelos);
        }

        public string ConsultarMarca()
        {
            var Marcas = JsonConvert.DeserializeObject<List<Marca>>(client.getMarcas().Content);

            return JsonConvert.SerializeObject(Marcas);
        }

        // GET: Anuncios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncioViewModel = context.ObterPorId(id.Value);

            if (anuncioViewModel == null)
            {
                return NotFound();
            }

            return View(anuncioViewModel);
        }

        // POST: Anuncios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, AnuncioViewModel collection)
        {
            if (!ModelState.IsValid) return View(collection);

            context.Atualizar(collection);

            return RedirectToAction("Index");
        }

        // GET: Anuncios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventoViewModel = context.ObterPorId(id.Value);
            if (eventoViewModel == null)
            {
                return NotFound();
            }

            return View(eventoViewModel);
        }

        // POST: Anuncios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            context.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
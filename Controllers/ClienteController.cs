using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1_EstebanRavazoli.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IMemoryCache _cache;


        public ClienteController(IMemoryCache cache)
        {
            _cache = cache;
        }

        private List<Models.Cliente> ObtenerListaClientes()
        {
            List<Models.Cliente> lista;
            if (_cache.Get("ListaDeClientes") is null)
            {
                lista = new List<Models.Cliente>();
                _cache.Set("ListaDeClientes", lista);

            }
            else
            {
                lista = (List<Models.Cliente>)_cache.Get("ListaDeClientes");

            }

            return lista;
        }

        public ActionResult Funcion() 
        {
            


            return View();
        }

        // GET: ClienteController
        public ActionResult Index(string Id)
        {
            List<Models.Cliente> listaClientes;

            listaClientes = ObtenerListaClientes();

            if (Id is null)
            {
                return View(listaClientes);

            }
            else
            {
                List<Models.Cliente> listaClientesFiltrada;
                listaClientesFiltrada = listaClientes.Where(x => x.Id.Contains(Id)).ToList();
                return View(listaClientesFiltrada);
            }


        }

        // GET: ClienteController/Details/5
        public ActionResult Details(string Id)
        {


            List<Models.Cliente> listaDeCliente;
            Models.Cliente cliente;

            listaDeCliente = ObtenerListaClientes();

            cliente = listaDeCliente.Find(x => x.Id == Id);

            if (cliente is null)
            {
                return RedirectToAction(nameof(Error));

            }
            else
            {
                return View(cliente.Proyectos);

            }



        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Cliente cliente)
        {
            try
            {
                List<Models.Cliente> lista;
                lista = ObtenerListaClientes();
                lista.Add(cliente);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(string id)
        {
            List<Models.Cliente> lista;

            Models.Cliente cliente;
            lista = ObtenerListaClientes();

            cliente = (Models.Cliente)lista.Find(x => x.Id == id);


            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Cliente cliente)
        {
            try
            {
                List<Models.Cliente> listaAEditar;
                Models.Cliente clienteAEditar;
                listaAEditar = ObtenerListaClientes();
                clienteAEditar = (Models.Cliente)listaAEditar.Find(x => x.Id == cliente.Id);

                clienteAEditar.Nombre = cliente.Nombre;
                clienteAEditar.Telefono = cliente.Telefono;



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Error()
        {



            return View();
        }
    }
}

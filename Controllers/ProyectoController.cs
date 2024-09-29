using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1_EstebanRavazoli.Controllers
{
    public class ProyectoController : Controller
    {
        private readonly IMemoryCache _cache;
        static int id = 1;

        public ProyectoController(IMemoryCache cache)
        {
            _cache = cache;
        }

        /*Función para generar ID*/
        public int GenerarID()
        {

            return id++;

        }

        private List<Models.Proyecto> ObtenerListaProyectos()
        {
            List<Models.Proyecto> listaProyectos;
            if (_cache.Get("ListaDeProyectos") is null)
            {
                listaProyectos = new List<Models.Proyecto>();
                _cache.Set("ListaDeProyectos", listaProyectos);

            }
            else
            {
                listaProyectos = (List<Models.Proyecto>)_cache.Get("ListaDeProyectos");

            }

            return listaProyectos;
        }

        private List<Models.Cliente> ObtenerListaClientes()
        {
            List<Models.Cliente> listaDeClientes;
            if (_cache.Get("ListaDeClientes") is null)
            {
                listaDeClientes = new List<Models.Cliente>();
                _cache.Set("ListaDeClientes", listaDeClientes);

            }
            else
            {
                listaDeClientes = (List<Models.Cliente>)_cache.Get("ListaDeClientes");

            }

            return listaDeClientes;
        }

        public void CalcularCostoPorMetroCuadrado(Models.Proyecto proyecto)
        {
            int areaDePilasAbiertoOCerrada = proyecto.AreaPilasAbierta ? 2 : 3;
            double factor1 = proyecto.CantidadDormitorios + proyecto.CantidadBaniosCompletos + proyecto.CantidadMediosBanios + Convert.ToInt32(proyecto.TerrazaTamanio)
                            + Convert.ToInt32(proyecto.PisoTipo) + Convert.ToInt32(proyecto.MuebleCocinaMaterial);
            double factor2 = areaDePilasAbiertoOCerrada * Convert.ToInt32(proyecto.MetrosConstruccion);

            double costo = (factor1 + factor2) * 20000;
            proyecto.CostoPorMetroCuadrado = costo;


        }

        // GET: ProyectoController
        public ActionResult Index()
        {
            List<Models.Proyecto> listaProyectos;
            listaProyectos = ObtenerListaProyectos();

           return View(listaProyectos);

        }

        // GET: ProyectoController/Details/5
        public ActionResult Details(int id)
        {
            List<Models.Proyecto> listaDeProyectos;
            Models.Proyecto proyecto;
            listaDeProyectos = ObtenerListaProyectos();
            proyecto = listaDeProyectos.Find(x => x.IdProyecto == id);


            return View(proyecto);

        }

        // GET: ProyectoController/Create
        public ActionResult Create()
        {

            return View();

        }

        // POST: ProyectoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Proyecto proyecto)
        {


            try
            {
                proyecto.IdProyecto = GenerarID();
                List<Models.Cliente> listaDeClientes;
                List<Models.Proyecto> listaDeProyectos;
                listaDeClientes = ObtenerListaClientes();
                listaDeProyectos = ObtenerListaProyectos();
                Models.Cliente cliente;

                cliente = listaDeClientes.Find(x => x.Id == proyecto.IdCliente);
                if (cliente is null)
                {

                    return RedirectToAction(nameof(Error));
                }
                else
                {
                    listaDeProyectos.Add(proyecto);
                    CalcularCostoPorMetroCuadrado(proyecto);
                    cliente.Proyectos.Add(proyecto);
                    return RedirectToAction(nameof(Index));
                }



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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1_EstebanRavazoli.Models
{
    public class Proyecto
    {
        [Display(Name = "ID Proyecto")]
        [Range(Int32.MinValue, 10000)]
        public int IdProyecto { get; set; }

        [Display(Name = "Cédula cliente")]
        [Required(ErrorMessage = "Debes digitar la cédula del cliente")]
        [RegularExpression(@"^\d{1,2}\-\d{3,4}\-\d{4,5}$", ErrorMessage = "Número en formato inválido.")]
        public string IdCliente { get; set; }

        [Display(Name = "Nombre del proyecto")]
        [Required(ErrorMessage = "Debes indicar el nombre del proyecto")]
        [RegularExpression(@"^[^#$%^*@!?,><;]*$", ErrorMessage = "Nombre en formato inválido.")]
        public string Nombre { get; set; }


        [Display(Name = "Cantidad de dormitorios")]
        [Required(ErrorMessage = "Debes digitar la cantidad de dormitorios")]
        [RegularExpression(@"[1-6]$", ErrorMessage = "Debe ingresar un número entre 1 y 6.")]
        public int CantidadDormitorios { get; set; }

        [Display(Name = "Cantidad de baños completos")]
        [Required(ErrorMessage = "Debes digitar la cantidad baños completos")]
        [RegularExpression(@"[1-5]$", ErrorMessage = "Debe ingresar un número entre 1 y 5.")]
        public int CantidadBaniosCompletos { get; set; }

        [Display(Name = "Cantidad de medios baños")]
        [Required(ErrorMessage = "Debes digitar la cantidad de medios baños")]
        [RegularExpression(@"[1-3]$", ErrorMessage = "Debe ingresar un número entre 1 y 3.")]
        public int CantidadMediosBanios { get; set; }

        [Display(Name = "Sala Integrada con cocina")]
        public bool SalaIntegradaConCocina { get; set; }

        [Display(Name = "Area de Pilas Abierta")]
        public bool AreaPilasAbierta { get; set; }

        [Display(Name = "Tamaño de la terraza")]
        public Terraza TerrazaTamanio { get; set; }

        [Display(Name = "Tipo de piso")]
        public TipoDePiso PisoTipo { get; set; }

        [Display(Name = "Material del mueble de cocina")]
        public MuebleCocina MuebleCocinaMaterial { get; set; }

        [Display(Name = "Metros cuadrados de construcción")]
        public MetrosConstruccion MetrosConstruccion { get; set; }


        public double CostoPorMetroCuadrado { get; set; }


    }
}

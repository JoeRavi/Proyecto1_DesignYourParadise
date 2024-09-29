using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Proyecto1_EstebanRavazoli.Models
{
    public class Cliente
    {


        

        [Display(Name = "Cedula")]
        [Required(ErrorMessage = "El número de cédula es requerido")]
        [RegularExpression(@"^\d{1,2}\-\d{3,4}\-\d{4,5}$", ErrorMessage = "Número en formato inválido.")]
        public string Id { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [RegularExpression(@"^([A-Za-z]{0}?[A-Za-z]+[\s])+([A-Za-z]{0}?[A-Za-z])+[\s]?([A-Za-z]{0}?[A-Za-z])?$", ErrorMessage = "Nombre en formato inválido.")]
        public string Nombre { get; set; }


        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El número de teléfono es requerido.")]
        [RegularExpression(@"^[0-9]{4}(-[0-9]{4})?$", ErrorMessage = "Número en formato inválido.")]
        public string Telefono { get; set; }

        public List<Proyecto> Proyectos { get; set; }

        public Cliente()
        {
            Proyectos = new List<Proyecto>();

        }

    }
}

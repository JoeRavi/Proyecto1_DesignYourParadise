using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1_EstebanRavazoli.Models
{
    public enum TipoDePiso
    {
        [Display(Name = "Concreto lujado")]
        Lujado = 0,
        [Display(Name = "Porcelanato")]
        Porcelanato = 1,
        [Display(Name = "Cerámica")]
        Ceramica = 2

    }
}

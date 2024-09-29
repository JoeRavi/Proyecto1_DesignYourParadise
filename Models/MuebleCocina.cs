using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1_EstebanRavazoli.Models
{
    public enum MuebleCocina
    {
        [Display(Name = "Granito")]
        Granito = 0,
        [Display(Name = "Cuarzo")]
        Cuarzo = 1,
        [Display(Name = "Terrazo")]
        Terrazo = 2

    }
}

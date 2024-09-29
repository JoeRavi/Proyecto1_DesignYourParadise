using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1_EstebanRavazoli.Models
{
    public enum Terraza
    {
        [Display(Name = "Pequeña")]
        Pequenia = 0,
        [Display(Name = "Mediana")]
        Mediana = 1,
        [Display(Name = "Grande")]
        Grande = 2

    }
}

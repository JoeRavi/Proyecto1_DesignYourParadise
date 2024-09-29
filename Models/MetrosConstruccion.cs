using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1_EstebanRavazoli.Models
{
    public enum MetrosConstruccion
    {
        [Display(Name = "De 50m2 a 80m2")]
        CincuentaOchenta=0,
        [Display(Name = "De 80m2 a 100m2")]
        OchentaCien =1,
        [Display(Name = "De 100m2 a 150m2")]
        CienCientocincuenta =2,
        [Display(Name = "De 150m2 a 200m2")]
        CientocincuentaDoscientos =3,
        [Display(Name = "De 200m2 a 300m2")]
        DoscientosTrescientos =4


    }
}

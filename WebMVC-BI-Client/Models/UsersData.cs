using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebMVC_BI_Client.Models
{
    public class UsersData
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage ="Nombre de Usuario requerido")]
        [Display(Name = "Nombre usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Contraseña Requerida")]
        [DataType (DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Necesita confirmar su contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmPasword { get; set; }
    }
}
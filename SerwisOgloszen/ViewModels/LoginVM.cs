using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SerwisOgloszen.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Nazwa Użytkownika")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

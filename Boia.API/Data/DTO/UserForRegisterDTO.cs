using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boia.API.Data.DTO
{
    public class UserForRegisterDTO
    {
        [Required(ErrorMessage = "O nome de usuário deve ser informado")]
        public string Username{ get; set; }

        [Required(ErrorMessage = "A senha deve ser informada")]
        [StringLength(12 ,MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 12 caracteres")]
        public string Password { get; set; }
    }
}

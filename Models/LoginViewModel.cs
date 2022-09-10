using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Dev.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Nome do Usuário")]
        [StringLength(255, MinimumLength =10)]
        public string UserName { get; set; }

        
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(255, MinimumLength = 10)]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        public string ReturnUrl{ get; set; }
        
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Auth.Model.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="You have missed to fill the username!")]
        [Display(Name ="User Name")]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}

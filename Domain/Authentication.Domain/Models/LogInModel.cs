﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Models
{
    public class LogInModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }


    public class LogInOTPModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class ForgotPasswordModel
    {
        [Required]
        public string Email { get; set; }
    }
}

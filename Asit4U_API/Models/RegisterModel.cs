using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asit4U_API.Models
{
    public class RegisterModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message { get; set; }
        public RegisterModel()
        {

        }
    }
}
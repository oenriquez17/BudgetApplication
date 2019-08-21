using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.ViewModels
{
    public class RegisterViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string PasswordConfirmation { get; set; }
    }
}
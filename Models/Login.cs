using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Models
{
    public class Login
    {
        [Key]
        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }
    }
}

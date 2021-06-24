using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ClinicManagement.ClinicModel
{
    public partial class User
    {
        [Required(ErrorMessage = "Email ID is Mandatory:")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email")]
        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicManagement.ClinicModel
{
    public partial class User
    {
        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

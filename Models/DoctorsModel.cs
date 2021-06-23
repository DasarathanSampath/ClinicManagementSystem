using ClinicManagement.ClinicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Models
{
    public class DoctorsModel
    {       
            ///<summary>
            /// Gets or sets Customers.
            ///</summary>
            public List<Doctor> Doctors { get; set; }

            ///<summary>
            /// Gets or sets CurrentPageIndex.
            ///</summary>
            public int CurrentPageIndex { get; set; }

            ///<summary>
            /// Gets or sets PageCount.
            ///</summary>
            public int PageCount { get; set; }

        
    }
}

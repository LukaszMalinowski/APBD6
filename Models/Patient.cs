using System;
using System.Collections;
using System.Collections.Generic;

namespace cwiczenia6_zen_s19743.Models
{
    public class Patient
    {
        public Patient()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
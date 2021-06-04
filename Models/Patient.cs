using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cwiczenia6_zen_s19743.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        [Key] public int IdPatient { get; set; }
        [Required] [MaxLength(100)] public string FirstName { get; set; }
        [Required] [MaxLength(100)] public string LastName { get; set; }
        [Required] public DateTime Birthday { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
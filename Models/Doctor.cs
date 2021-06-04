using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cwiczenia6_zen_s19743.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        [Key] public int IdDoctor { get; set; }
        [Required] [MaxLength(100)] public string FirstName { get; set; }
        [Required] [MaxLength(100)] public string LastName { get; set; }
        [Required] public string Email { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
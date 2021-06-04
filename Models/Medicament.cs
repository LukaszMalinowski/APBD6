using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cwiczenia6_zen_s19743.Models
{
    public partial class Medicament
    {
        public Medicament()
        {
            PrescriptionMedicaments = new HashSet<PrescriptionMedicament>();
        }

        [Key] public int IdMedicament { get; set; }
        [Required] [MaxLength(100)] public string Name { get; set; }
        [Required] [MaxLength(100)] public string Description { get; set; }
        [Required] [MaxLength(100)] public string Type { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    }
}
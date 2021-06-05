using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cwiczenia6_zen_s19743.Models
{
    public partial class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
        [ForeignKey(nameof(IdMedicament))] public virtual Medicament Medicament { get; set; }
        [ForeignKey(nameof(IdPrescription))] public virtual Prescription Prescription { get; set; }
    }
}
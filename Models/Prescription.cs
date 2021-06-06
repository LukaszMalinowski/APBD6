using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace cwiczenia6_zen_s19743.Models
{
    public partial class Prescription
    {
        public Prescription()
        {
            PrescriptionMedicaments = new HashSet<PrescriptionMedicament>();
        }

        [Key] public int IdPrescription { get; set; }
        [Required] public DateTime Date { get; set; }
        [Required] public DateTime DueDate { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
        [JsonIgnore] public int IdPatient { get; set; }
        [JsonIgnore] public int IdDoctor { get; set; }
        [ForeignKey(nameof(IdPatient))] public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(IdDoctor))] public virtual Doctor Doctor { get; set; }
    }
}
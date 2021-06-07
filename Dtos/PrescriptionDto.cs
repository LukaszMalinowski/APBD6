using System;
using System.Collections.Generic;

namespace cwiczenia6_zen_s19743.Dtos
{
    public class PrescriptionDto
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public DoctorDto Doctor { get; set; }
        public PatientDto Patient { get; set; }
        public ICollection<MedicamentDto> Medicaments { get; set; }
    }
}
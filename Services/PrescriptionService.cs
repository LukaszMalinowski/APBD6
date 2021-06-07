using System.Linq;
using cwiczenia6_zen_s19743.Exceptions;
using cwiczenia6_zen_s19743.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia6_zen_s19743.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        public Prescription GetPrescriptionById(int prescriptionId)
        {
            var dbContext = new MainDbContext();

            var prescription = dbContext.Prescriptions
                .Where(tmpPrescription => tmpPrescription.IdPrescription == prescriptionId)
                .Select(tmpPrescription => new Prescription
                {
                    IdPrescription = tmpPrescription.IdPrescription,
                    Date = tmpPrescription.Date,
                    DueDate = tmpPrescription.DueDate,
                    IdPatient = tmpPrescription.IdPatient,
                    IdDoctor = tmpPrescription.IdDoctor,
                    Patient = tmpPrescription.Patient,
                    Doctor = tmpPrescription.Doctor,
                    PrescriptionMedicaments = tmpPrescription
                        .PrescriptionMedicaments.Select(prescriptionMedicament => new PrescriptionMedicament
                        {
                            Details = prescriptionMedicament.Details,
                            Medicament = prescriptionMedicament.Medicament
                        }).ToList()
                })
                .SingleOrDefault();


            if (prescription == null)
            {
                throw new PrescriptionNotFoundException(prescriptionId);
            }

            return prescription;
        }
    }
}
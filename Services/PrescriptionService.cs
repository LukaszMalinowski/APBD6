using System.Linq;
using cwiczenia6_zen_s19743.Dtos;
using cwiczenia6_zen_s19743.Exceptions;
using cwiczenia6_zen_s19743.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia6_zen_s19743.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        public PrescriptionDto GetPrescriptionById(int prescriptionId)
        {
            var dbContext = new MainDbContext();

            var prescription = dbContext.Prescriptions
                .Where(tmpPrescription => tmpPrescription.IdPrescription == prescriptionId)
                .Select(tmpPrescription => new PrescriptionDto
                {
                    IdPrescription = tmpPrescription.IdPrescription,
                    Date = tmpPrescription.Date,
                    DueDate = tmpPrescription.DueDate,
                    Patient = new PatientDto
                    {
                        IdPatient = tmpPrescription.IdPatient,
                        FirstName = tmpPrescription.Patient.FirstName,
                        LastName = tmpPrescription.Patient.LastName
                    },
                    Doctor = new DoctorDto
                    {
                        IdDoctor = tmpPrescription.IdDoctor,
                        FirstName = tmpPrescription.Doctor.FirstName,
                        LastName = tmpPrescription.Doctor.LastName
                    },
                    Medicaments = tmpPrescription.PrescriptionMedicaments
                        .Select(medicament => new MedicamentDto
                        {
                            IdMedicament = medicament.IdMedicament,
                            Details = medicament.Details,
                            Dose = medicament.Dose,
                            Name = medicament.Medicament.Name,
                            Description = medicament.Medicament.Description,
                            Type = medicament.Medicament.Type
                        }).ToList()
                }).FirstOrDefault();


            if (prescription == null)
            {
                throw new PrescriptionNotFoundException(prescriptionId);
            }

            return prescription;
        }
    }
}
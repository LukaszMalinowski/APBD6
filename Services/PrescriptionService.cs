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
                .Include(tmpPrescription => tmpPrescription.PrescriptionMedicaments)
                .Include(tmpPrescription => tmpPrescription.Doctor)
                .Include(tmpPrescription => tmpPrescription.Patient)
                .SingleOrDefault();

            if (prescription == null)
            {
                throw new PrescriptionNotFoundException(prescriptionId);
            }

            return prescription;
        }
    }
}
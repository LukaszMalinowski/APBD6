using System.Linq;
using cwiczenia6_zen_s19743.Exceptions;
using cwiczenia6_zen_s19743.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia6_zen_s19743.Services
{
    public class DoctorService : IDoctorService
    {
        public Doctor GetDoctorById(int doctorId)
        {
            var dbContext = new MainDbContext();
            var doctor = dbContext.Doctors
                .Where(doctor1 => doctor1.IdDoctor == doctorId)
                .Include(doctor1 => doctor1.Prescriptions)
                .FirstOrDefault();

            if (doctor == null)
            {
                throw new DoctorNotFoundException(doctorId);
            }

            return doctor;
        }

        public void AddDoctor(Doctor doctor)
        {
            var dbContext = new MainDbContext();

            doctor.IdDoctor = 0;

            doctor.Prescriptions = null;

            dbContext.Doctors.Add(doctor);

            dbContext.SaveChanges();
        }

        public void UpdateDoctor(int doctorId, Doctor doctor)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteDoctor(int doctorId)
        {
            var dbContext = new MainDbContext();

            var doctor = dbContext.Doctors
                .SingleOrDefault(tmpDoctor => tmpDoctor.IdDoctor == doctorId);

            if (doctor == null)
            {
                throw new DoctorNotFoundException(doctorId);
            }

            dbContext.Doctors.Remove(doctor);
            dbContext.SaveChanges();
        }
    }
}
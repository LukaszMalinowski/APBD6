using cwiczenia6_zen_s19743.Models;

namespace cwiczenia6_zen_s19743.Services
{
    public interface IDoctorService
    {
        Doctor GetDoctorById(int doctorId);

        void AddDoctor(Doctor doctor);

        void UpdateDoctor(int doctorId, Doctor doctor);

        void DeleteDoctor(int doctorId);
    }
}
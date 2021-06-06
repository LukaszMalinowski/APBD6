using cwiczenia6_zen_s19743.Models;

namespace cwiczenia6_zen_s19743.Services
{
    public interface IPrescriptionService
    {
        Prescription GetPrescriptionById(int prescriptionId);
    }
}
using cwiczenia6_zen_s19743.Dtos;
using cwiczenia6_zen_s19743.Models;

namespace cwiczenia6_zen_s19743.Services
{
    public interface IPrescriptionService
    {
        PrescriptionDto GetPrescriptionById(int prescriptionId);
    }
}
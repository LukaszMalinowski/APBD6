using System;

namespace cwiczenia6_zen_s19743.Exceptions
{
    public class PrescriptionNotFoundException : Exception
    {
        public PrescriptionNotFoundException(int id)
            : base("Prescription with id " + id + " not found.")
        {
        }
    }
}
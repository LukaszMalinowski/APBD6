using System;

namespace cwiczenia6_zen_s19743.Exceptions
{
    public class DoctorNotFoundException : Exception
    {
        public DoctorNotFoundException(int id)
            : base("Doctor with id " + id + " not found.")
        {
        }
    }
}
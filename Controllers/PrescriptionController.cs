using System;
using cwiczenia6_zen_s19743.Dtos;
using cwiczenia6_zen_s19743.Exceptions;
using cwiczenia6_zen_s19743.Models;
using cwiczenia6_zen_s19743.Services;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia6_zen_s19743.Controllers
{
    [ApiController]
    [Route("/api/prescriptions")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _service;

        public PrescriptionController(IPrescriptionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{prescriptionId}")]
        public IActionResult GetPrescriptionById(int prescriptionId)
        {
            PrescriptionDto prescription;

            try
            {
                prescription = _service.GetPrescriptionById(prescriptionId);
            }
            catch (PrescriptionNotFoundException e)
            {
                return NotFound(e.Message);
            }

            _service.GetPrescriptionById(prescriptionId);

            return Ok(prescription);
        }
    }
}
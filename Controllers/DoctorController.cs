using System;
using cwiczenia6_zen_s19743.Exceptions;
using cwiczenia6_zen_s19743.Models;
using cwiczenia6_zen_s19743.Services;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia6_zen_s19743.Controllers
{
    [Route("/api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }


        [Route("{doctorId}")]
        [HttpGet]
        public IActionResult GetDoctorById(int doctorId)
        {
            Doctor doctor;

            try
            {
                doctor = _service.GetDoctorById(doctorId);
            }
            catch (DoctorNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            _service.AddDoctor(doctor);

            return NoContent();
        }

        [Route("{doctorId}")]
        [HttpPut]
        public IActionResult UpdateDoctor(int doctorId, [FromBody] Doctor doctor)
        {
            return null;
        }

        [Route("{doctorId}")]
        [HttpDelete]
        public IActionResult DeleteDoctorById(int doctorId)
        {
            try
            {
                _service.DeleteDoctor(doctorId);
            }
            catch (DoctorNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return NoContent();
        }
    }
}
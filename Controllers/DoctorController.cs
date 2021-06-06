using cwiczenia6_zen_s19743.Models;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia6_zen_s19743.Controllers
{
    [Route("/api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        [Route("{doctorId}")]
        [HttpGet]
        public IActionResult GetDoctorById(int doctorId)
        {
            return null;
        }

        [HttpPost]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            return null;
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
            return null;
        }
    }
}
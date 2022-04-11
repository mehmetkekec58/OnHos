using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        IVisitDoctorProfileService _visitDoctorProfileService;

        public VisitsController(IVisitDoctorProfileService visitDoctorProfileService)
        {
            _visitDoctorProfileService = visitDoctorProfileService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _visitDoctorProfileService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

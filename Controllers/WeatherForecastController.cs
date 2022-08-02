using API.Interfaces;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly CitizenInterface _CI;

        public WeatherForecastController(CitizenInterface CI)
        {
            _CI = CI;
        }

        [HttpGet(Name = "GetCitizens")]
        public async Task<ActionResult<List<Citizen>>> Get()
        {

            return Ok(await _CI.Get());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Citizen>> Get(int id) {

            var Citizen = _CI.Get(id);

            if (Citizen == null)
            {

                return NotFound();

            }
            else {

                return Ok(await Citizen);

            }

        }

        [HttpPost]
        public async Task<ActionResult<List<Citizen>>> AddCitizen(Citizen citizen)
        {
            return Ok(await _CI.AddCitizen(citizen));

        }

        [HttpPut]
        public async Task<ActionResult<List<Citizen>>> UpdateCitizen(Citizen request)
        {

            var Citizen = _CI.UpdateCitizen(request);

            if (Citizen == null)
            {

                return BadRequest("Citizen Not Found");

            }
            else
            {

                return Ok(await Citizen);

            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Citizen>>> DeleteCitizen(int id) {

            var Citizen = _CI.DeleteCitizen(id);

            if (Citizen == null)
            {

                return BadRequest("Citizen Not Found");

            }
            else
            {

                return Ok(await Citizen);

            }

        }


    }
}
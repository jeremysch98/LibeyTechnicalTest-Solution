using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [Route("[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceAggregate _aggregate;

        public ProvinceController(IProvinceAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        [Route("GetByRegion/{regionCode}")]
        public IActionResult GetByRegion(string regionCode)
        {
            var row = _aggregate.GetByRegion(regionCode);
            return Ok(row);
        }
    }
}

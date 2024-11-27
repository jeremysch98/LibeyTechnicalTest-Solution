using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [Route("[controller]")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoAggregate _aggregate;

        public UbigeoController(IUbigeoAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        [Route("GetByRegionProvince/{regionCode}/{provinceCode}")]
        public IActionResult GetByRegion(string regionCode, string provinceCode)
        {
            var row = _aggregate.GetByRegionProvince(regionCode, provinceCode);
            return Ok(row);
        }
    }
}

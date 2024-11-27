using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application
{
    public class ProvinceAggregate : IProvinceAggregate
    {
        private readonly IProvinceRepository _repository;

        public ProvinceAggregate(IProvinceRepository repository)
        {
            _repository = repository;
        }

        public List<ProvinceResponse> GetByRegion(string regionCode)
        {
            return _repository.GetByRegion(regionCode);
        }
    }
}

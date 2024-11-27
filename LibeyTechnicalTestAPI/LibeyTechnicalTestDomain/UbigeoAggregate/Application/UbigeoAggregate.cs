using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.UbigeoAggregate.Application
{
    public class UbigeoAggregate : IUbigeoAggregate
    {
        private readonly IUbigeoRepository _repository;

        public UbigeoAggregate(IUbigeoRepository repository)
        {
            _repository = repository;
        }

        public List<UbigeoResponse> GetByRegionProvince(string regionCode, string provinceCode)
        {
            return _repository.GetByRegionProvince(regionCode, provinceCode);
        }
    }
}

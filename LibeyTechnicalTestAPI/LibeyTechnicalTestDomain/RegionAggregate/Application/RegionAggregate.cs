using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.RegionAggregate.Application
{
    public class RegionAggregate : IRegionAggregate
    {
        private readonly IRegionRepository _repository;

        public RegionAggregate(IRegionRepository repository)
        {
            _repository = repository;
        }

        public List<RegionResponse> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

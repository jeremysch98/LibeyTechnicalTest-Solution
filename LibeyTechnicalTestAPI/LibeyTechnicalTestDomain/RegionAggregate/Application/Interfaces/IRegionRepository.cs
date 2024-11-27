using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces
{
    public interface IRegionRepository
    {
        List<RegionResponse> GetAll();
    }
}

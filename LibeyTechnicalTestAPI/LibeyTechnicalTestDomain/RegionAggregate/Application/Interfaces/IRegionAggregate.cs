using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces
{
    public interface IRegionAggregate
    {
        List<RegionResponse> GetAll();
    }
}

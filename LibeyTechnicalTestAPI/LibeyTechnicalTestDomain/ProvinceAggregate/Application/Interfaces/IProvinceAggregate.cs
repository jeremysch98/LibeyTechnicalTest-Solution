using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces
{
    public interface IProvinceAggregate
    {
        List<ProvinceResponse> GetByRegion(string regionCode);
    }
}

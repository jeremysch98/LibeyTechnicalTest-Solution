using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces
{
    public interface IProvinceRepository
    {
        List<ProvinceResponse> GetByRegion(string regionCode);
    }
}

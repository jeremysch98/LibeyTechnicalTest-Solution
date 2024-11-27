using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces
{
    public interface IUbigeoAggregate
    {
        List<UbigeoResponse> GetByRegionProvince(string regionCode, string provinceCode);
    }
}

using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.UbigeoAggregate.Infraestructure
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly Context _context;

        public UbigeoRepository(Context context)
        {
            _context = context;
        }

        public List<UbigeoResponse> GetByRegionProvince(string regionCode, string provinceCode)
        {
            var q = from ubigeo in _context.Ubigeos.Where(x => x.RegionCode.Equals(regionCode) && x.ProvinceCode.Equals(provinceCode))
                    select new UbigeoResponse()
                    {
                        UbigeoCode = ubigeo.UbigeoCode,
                        UbigeoDescription = ubigeo.UbigeoDescription
                    };
            return q.ToList();
        }
    }
}

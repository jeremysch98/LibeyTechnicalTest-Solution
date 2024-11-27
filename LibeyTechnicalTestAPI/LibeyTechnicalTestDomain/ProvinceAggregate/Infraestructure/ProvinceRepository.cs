using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Infraestructure
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly Context _context;

        public ProvinceRepository(Context context)
        {
            _context = context;
        }

        public List<ProvinceResponse> GetByRegion(string regionCode)
        {
            var q = from province in _context.Provinces.Where(x => x.RegionCode.Equals(regionCode))
                    select new ProvinceResponse()
                    {
                        ProvinceCode = province.ProvinceCode,
                        ProvinceDescription = province.ProvinceDescription
                    };
            return q.ToList();
        }
    }
}

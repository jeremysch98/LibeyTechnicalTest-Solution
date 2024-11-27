using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.RegionAggregate.Infraestructure
{
    public class RegionRepository : IRegionRepository
    {
        private readonly Context _context;

        public RegionRepository(Context context)
        {
            _context = context;
        }

        public List<RegionResponse> GetAll()
        {
            var q = from region in _context.Regions
                    select new RegionResponse()
                    {
                        RegionCode = region.RegionCode,
                        RegionDescription = region.RegionDescription
                    };

            return q.ToList();
        }
    }
}

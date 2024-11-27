using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        
        public List<LibeyUserResponse> GetAll()
        {
            var q = from libeyUser in _context.LibeyUsers
                    join documentType in _context.DocumentTypes on libeyUser.DocumentTypeId equals documentType.DocumentTypeId
                    join ubigeo in _context.Ubigeos on libeyUser.UbigeoCode equals ubigeo.UbigeoCode
                    join province in _context.Provinces on ubigeo.ProvinceCode equals province.ProvinceCode
                    join region in _context.Regions on ubigeo.RegionCode equals region.RegionCode
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        DocumentTypeDescription = documentType.DocumentTypeDescription,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone,
                        UbigeoCode = libeyUser.UbigeoCode,
                        UbigeoDescription = ubigeo.UbigeoDescription,
                        ProvinceCode = ubigeo.ProvinceCode,
                        ProvinceDescription = province.ProvinceDescription,
                        RegionCode = ubigeo.RegionCode,
                        RegionDescription = region.RegionDescription
                    };
            return q.ToList();
        }

        public LibeyUser Find(string documentNumber)
        {
            var rowFound = _context.LibeyUsers.SingleOrDefault(x => x.DocumentNumber.Equals(documentNumber));

            return rowFound;
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var q = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber))
                    join ubigeo in _context.Ubigeos on libeyUser.UbigeoCode equals ubigeo.UbigeoCode
                    join province in _context.Provinces on ubigeo.ProvinceCode equals province.ProvinceCode
                    join region in _context.Regions on ubigeo.RegionCode equals region.RegionCode
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone,
                        UbigeoCode = libeyUser.UbigeoCode,
                        UbigeoDescription = ubigeo.UbigeoDescription,
                        ProvinceCode = ubigeo.ProvinceCode,
                        ProvinceDescription = province.ProvinceDescription,
                        RegionCode = ubigeo.RegionCode,
                        RegionDescription = region.RegionDescription
                    };

            return q.FirstOrDefault();
            //var list = q.ToList();
            //if (list.Any()) return list.First();
            //else return new LibeyUserResponse();
        }

        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }

        public void Update(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Update(libeyUser);
            _context.SaveChanges();
        }

        public bool ExistLibeyUserDocumentNumber(string documentNumber)
        {
            return _context.LibeyUsers.Any(x => x.DocumentNumber.Equals(documentNumber));
        }

        public void ClearEF(LibeyUser libeyUser)
        {
            _context.Entry(libeyUser).State = EntityState.Detached;
        }
    }
}
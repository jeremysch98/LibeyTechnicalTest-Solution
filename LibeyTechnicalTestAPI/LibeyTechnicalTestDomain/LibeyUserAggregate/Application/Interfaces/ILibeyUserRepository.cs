using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        List<LibeyUserResponse> GetAll();
        LibeyUserResponse FindResponse(string documentNumber);
        LibeyUser Find(string documentNumber);
        void Create(LibeyUser libeyUser);
        void Update(LibeyUser libeyUser);
        bool ExistLibeyUserDocumentNumber(string documentNumber);
        void ClearEF(LibeyUser libeyUser);
    }
}

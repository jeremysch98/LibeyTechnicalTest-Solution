using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces
{
    public interface IDocumentTypeRepository
    {
        List<DocumentTypeResponse> GetAll();
    }
}

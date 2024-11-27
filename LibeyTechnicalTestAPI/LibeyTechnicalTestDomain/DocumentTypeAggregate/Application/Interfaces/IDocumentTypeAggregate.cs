using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces
{
    public interface IDocumentTypeAggregate
    {
        List<DocumentTypeResponse> GetAll();
    }
}

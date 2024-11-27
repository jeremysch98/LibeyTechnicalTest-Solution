using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.EFCore;

namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Infraestructure
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly Context _context;

        public DocumentTypeRepository(Context context)
        {
            _context = context;
        }

        public  List<DocumentTypeResponse> GetAll()
        {
            var q = from documentType in _context.DocumentTypes
                    select new DocumentTypeResponse()
                    {
                        DocumentTypeId = documentType.DocumentTypeId,
                        DocumentTypeDescription = documentType.DocumentTypeDescription
                    };

            return q.ToList();
        }
    }
}

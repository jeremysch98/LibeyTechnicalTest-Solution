using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application
{
    public class DocumentTypeAggregate : IDocumentTypeAggregate
    {
        private readonly IDocumentTypeRepository _repository;

        public DocumentTypeAggregate(IDocumentTypeRepository repository)
        {
            _repository = repository;
        }

        public List<DocumentTypeResponse> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

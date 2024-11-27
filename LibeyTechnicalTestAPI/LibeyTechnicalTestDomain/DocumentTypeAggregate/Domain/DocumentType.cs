namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Domain
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeDescription { get; set; }

        public DocumentType(int documentTypeId, string documentTypeDescription)
        {
            DocumentTypeId = documentTypeId;
            DocumentTypeDescription = documentTypeDescription;
        }
    }
}

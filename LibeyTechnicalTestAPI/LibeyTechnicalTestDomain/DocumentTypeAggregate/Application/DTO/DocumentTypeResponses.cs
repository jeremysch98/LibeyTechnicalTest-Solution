namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO
{
    public record DocumentTypeResponse
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeDescription { get; set; }
    }
}

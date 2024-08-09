using System;

namespace Inva.LawMax.Application.Contracts.Dtos
{
    public class CreateUpdateHearingDto
    {
        public DateTime Date { get; set; }
        public string Decision { get; set; }
        public Guid CaseId { get; set; }
    }
}

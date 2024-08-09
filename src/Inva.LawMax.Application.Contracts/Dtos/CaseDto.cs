using Inva.LawMax.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;

namespace Inva.LawMax.Application.Contracts.Dtos
{
    public class CaseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid LawyerId { get; set; }
        public LawyerDto Lawyer { get; set; }
        public List<HearingDto> Hearings { get; set; } = new List<HearingDto>();
    }
}

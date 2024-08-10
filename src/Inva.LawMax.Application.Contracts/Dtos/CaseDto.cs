using Inva.LawMax.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;

namespace Inva.LawMax.Application.Contracts.Dtos
{
    public class CaseDto
    {
        public Guid Id { get; set; }
        public Guid LawyerId { get; set; }
        public LawyerDto Lawyer { get; set; }
        public string Number { get; set; }
        public int Year { get; set; }
        public string LitigationDegree { get; set; }
        public string FinalVerdict { get; set; }

    }
}

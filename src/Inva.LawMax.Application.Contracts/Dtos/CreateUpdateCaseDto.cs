using System;

namespace Inva.LawMax.Application.Contracts.Dtos
{
    public class CreateUpdateCaseDto
    {
        public string Number { get; set; }
        public int Year { get; set; }
        public string LitigationDegree { get; set; }
        public string FinalVerdict { get; set; }
        public Guid LawyerId { get; set; }
    }
}

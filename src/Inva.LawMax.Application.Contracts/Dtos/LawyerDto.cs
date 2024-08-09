using System;

namespace Inva.LawMax.Application.Contracts.Dtos
{
    public class LawyerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}

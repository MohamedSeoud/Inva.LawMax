using System;
using Volo.Abp.Domain.Entities;

namespace Inva.LawMax.Domain.Entities
{
    public class Lawyer : Entity<Guid>
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}

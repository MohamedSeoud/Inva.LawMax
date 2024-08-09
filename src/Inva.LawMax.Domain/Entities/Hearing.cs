using System;
using Volo.Abp.Domain.Entities;

namespace Inva.LawMax.Domain.Entities
{
    public class Hearing : Entity<Guid>
    {
        public DateTime Date { get; set; }
        public string Decision { get; set; }
        public Guid CaseId { get; set; }
        public virtual Case Case { get; set; }
    }
}

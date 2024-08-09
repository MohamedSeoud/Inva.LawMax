using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Inva.LawMax.Domain.Entities
{
    public class Case : Entity<Guid>
    {
        public string Number { get; set; }
        public int Year { get; set; }
        public string LitigationDegree { get; set; }
        public string FinalVerdict { get; set; }
        public virtual ICollection<Hearing> Hearings { get; set; }
        public Guid LaywerId { get; set; }

        public virtual Lawyer Lawyer { get; set; }
    }
}

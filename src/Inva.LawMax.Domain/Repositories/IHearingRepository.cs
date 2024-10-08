﻿using Inva.LawMax.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Inva.LawMax.Domain.Repositories
{
    public interface IHearingRepository : IRepository<Hearing, Guid>
    {
        Task<IList<Hearing>> GetByCaseIdAsync(Guid caseId);
        Task<Hearing> GetAsync(Guid id, bool includeDetails = false);
        Task<List<Hearing>> GetListAsync(bool includeDetails = false);
    }
}

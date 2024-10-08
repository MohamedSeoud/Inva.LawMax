﻿using Inva.LawMax.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Inva.LawMax.Domain.Repositories
{
    public interface ICaseRepository : IRepository<Case, Guid>
    {
        Task<Case> GetByNumberAsync(string number);
        Task<Case> GetAsync(Guid id, bool includeDetails = false);
        Task<List<Case>> GetListAsync(bool includeDetails = false);

    }
}

using Inva.LawMax.Domain.Entities;
using Inva.LawMax.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;

namespace Inva.LawMax.EntityFrameworkCore.Repositories
{
    public class EfCoreHearingRepository : EfCoreRepository<LawMaxDbContext, Hearing, Guid>, IHearingRepository
    {
        public EfCoreHearingRepository(IDbContextProvider<LawMaxDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

        public async Task<IList<Hearing>> GetByCaseIdAsync(Guid caseId)
        {
            return await DbSet.Where(h => h.CaseId == caseId).ToListAsync();
        }
    }
}

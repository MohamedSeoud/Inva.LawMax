using Inva.LawMax.Domain.Entities;
using Inva.LawMax.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Inva.LawMax.EntityFrameworkCore.Repositories
{
    public class EfCoreCaseRepository : EfCoreRepository<LawMaxDbContext, Case, Guid>, ICaseRepository
    {
        public EfCoreCaseRepository(IDbContextProvider<LawMaxDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

        public async Task<Case> GetByNumberAsync(string number)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.Number == number);
        }
    }
}

using Inva.LawMax.Domain.Entities;
using Inva.LawMax.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Collections.Generic;
using Polly;

namespace Inva.LawMax.EntityFrameworkCore.Repositories
{
    public class EfCoreCaseRepository : EfCoreRepository<LawMaxDbContext, Case, Guid>, ICaseRepository
    {
        public EfCoreCaseRepository(IDbContextProvider<LawMaxDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

        public async Task<Case> GetAsync(Guid id, bool includeDetails = false)
        {
            var query =  DbSet.AsQueryable();

            if (includeDetails)
            {
                query = query.Include(c => c.Lawyer); 
            }
            return await query.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Case> GetByNumberAsync(string number)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.Number == number);
        }

        public Task<List<Case>> GetListAsync(bool includeDetails = false)
        {
            var query = DbSet.AsQueryable();

            if (includeDetails)
            {
                query = query.Include(c => c.Lawyer);
            }
            return query.ToListAsync();
        }


    }
}

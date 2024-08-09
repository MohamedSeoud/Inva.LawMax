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
    public class EfCoreLawyerRepository : EfCoreRepository<LawMaxDbContext, Lawyer, Guid>, ILawyerRepository
    {
        public EfCoreLawyerRepository(IDbContextProvider<LawMaxDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

        public async Task<Lawyer> GetByNameAsync(string name)
        {
            return await DbSet.FirstOrDefaultAsync(l => l.Name == name);
        }
    }
}

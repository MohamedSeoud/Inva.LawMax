using Inva.LawMax.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Inva.LawMax.Domain.Repositories
{
    public interface ILawyerRepository : IRepository<Lawyer, Guid>
    {
        Task<Lawyer> GetByNameAsync(string name);
    }
}

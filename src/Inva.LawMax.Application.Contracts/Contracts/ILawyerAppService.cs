using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inva.LawMax.Application.Contracts.Dtos;


namespace Inva.LawMax.Application.Contracts
{
    public interface ILawyerAppService
    {
        Task<LawyerDto> GetAsync(Guid id);
        Task<List<LawyerDto>> GetListAsync();
        Task<LawyerDto> CreateAsync(CreateUpdateLawyerDto input);
        Task<LawyerDto> UpdateAsync(Guid id, CreateUpdateLawyerDto input);
        Task DeleteAsync(Guid id);
    }
}

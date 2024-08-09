using Inva.LawMax.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inva.LawMax.Application.Contracts
{
    public interface ICaseAppService
    {
        Task<CaseDto> GetAsync(Guid id);
        Task<List<CaseDto>> GetListAsync();
        Task<CaseDto> CreateAsync(CreateUpdateCaseDto input);
        Task<CaseDto> UpdateAsync(Guid id, CreateUpdateCaseDto input);
        Task DeleteAsync(Guid id);
    }
}

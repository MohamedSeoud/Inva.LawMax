using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inva.LawMax.Application.Contracts.Dtos;


namespace Inva.LawMax.Application.Contracts
{
    public interface IHearingAppService
    {
        Task<HearingDto> GetAsync(Guid id);
        Task<List<HearingDto>> GetListAsync();
        Task<HearingDto> CreateAsync(CreateUpdateHearingDto input);
        Task<HearingDto> UpdateAsync(Guid id, CreateUpdateHearingDto input);
        Task DeleteAsync(Guid id);
    }
}

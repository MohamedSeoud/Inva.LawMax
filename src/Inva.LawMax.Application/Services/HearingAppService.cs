using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inva.LawMax.Application.Contracts;
using Inva.LawMax.Application.Contracts.Dtos;
using Inva.LawMax.Domain.Entities;
using Inva.LawMax.Domain.Repositories;
using Volo.Abp.Application.Services;

namespace Inva.LawMax.Application
{
    public class HearingAppService : ApplicationService, IHearingAppService
    {
        private readonly IHearingRepository _hearingRepository;
        private readonly IMapper _mapper;

        public HearingAppService(IHearingRepository hearingRepository, IMapper mapper)
        {
            _hearingRepository = hearingRepository;
            _mapper = mapper;
        }

        public async Task<HearingDto> GetAsync(Guid id)
        {
            var hearing = await _hearingRepository.GetAsync(id,true);
            return _mapper.Map<Hearing, HearingDto>(hearing);
        }

        public async Task<List<HearingDto>> GetListAsync()
        {
            var hearings = await _hearingRepository.GetListAsync(true);
            // Convert IList to List using ToList() extension method
            return _mapper.Map<List<Hearing>, List<HearingDto>>(hearings.ToList());
        }

        public async Task<HearingDto> CreateAsync(CreateUpdateHearingDto input)
        {
            var hearing = _mapper.Map<CreateUpdateHearingDto, Hearing>(input);
            var createdHearing = await _hearingRepository.InsertAsync(hearing);
            return _mapper.Map<Hearing, HearingDto>(createdHearing);
        }

        public async Task<HearingDto> UpdateAsync(Guid id, CreateUpdateHearingDto input)
        {
            var hearing = await _hearingRepository.GetAsync(id);
            _mapper.Map(input, hearing);
            var updatedHearing = await _hearingRepository.UpdateAsync(hearing);
            return _mapper.Map<Hearing, HearingDto>(updatedHearing);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _hearingRepository.DeleteAsync(id);
        }
    }
}

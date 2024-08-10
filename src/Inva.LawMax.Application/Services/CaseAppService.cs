using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Inva.LawMax.Application.Contracts;
using Inva.LawMax.Application.Contracts.Dtos;
using Inva.LawMax.Domain.Entities;
using Inva.LawMax.Domain.Repositories;
using Volo.Abp.Application.Services;

namespace Inva.LawMax.Application.Services
{
    public class CaseAppService : ApplicationService, ICaseAppService
    {
        private readonly ICaseRepository _caseRepository;
        private readonly IMapper _mapper;

        public CaseAppService(ICaseRepository caseRepository, IMapper mapper)
        {
            _caseRepository = caseRepository;
            _mapper = mapper;
        }

        public async Task<CaseDto> GetAsync(Guid id)
        {
            var caseEntity = await _caseRepository.GetAsync(id);
            return _mapper.Map<Case, CaseDto>(caseEntity);
        }

        public async Task<List<CaseDto>> GetListAsync()
        {
            var cases = await _caseRepository.GetListAsync(true);
            return _mapper.Map<List<Case>, List<CaseDto>>(cases);
        }

        public async Task<CaseDto> CreateAsync(CreateUpdateCaseDto input)
        {
            var caseEntity = _mapper.Map<CreateUpdateCaseDto, Case>(input);
            caseEntity.LaywerId = input.LawyerId;
            var createdCase = await _caseRepository.InsertAsync(caseEntity);
            return _mapper.Map<Case, CaseDto>(createdCase);
        }

        public async Task<CaseDto> UpdateAsync(Guid id, CreateUpdateCaseDto input)
        {
            var caseEntity = await _caseRepository.GetAsync(id,true);
            _mapper.Map(input, caseEntity);
            caseEntity.LaywerId=input.LawyerId;
            var updatedCase = await _caseRepository.UpdateAsync(caseEntity);
            return _mapper.Map<Case, CaseDto>(updatedCase);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _caseRepository.DeleteAsync(id);
        }
    }
}

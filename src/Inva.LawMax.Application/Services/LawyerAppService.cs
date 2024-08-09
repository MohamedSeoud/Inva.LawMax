using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Inva.LawMax.Application.Contracts;
using Inva.LawMax.Application.Contracts.Dtos;
using Inva.LawMax.Domain.Entities;
using Inva.LawMax.Domain.Repositories;
using Volo.Abp.Application.Services;

namespace Inva.LawMax.Application
{
    public class LawyerAppService : ApplicationService, ILawyerAppService
    {
        private readonly ILawyerRepository _lawyerRepository;
        private readonly IMapper _mapper;

        public LawyerAppService(ILawyerRepository lawyerRepository, IMapper mapper)
        {
            _lawyerRepository = lawyerRepository;
            _mapper = mapper;
        }

        public async Task<LawyerDto> GetAsync(Guid id)
        {
            var lawyer = await _lawyerRepository.GetAsync(id);
            return _mapper.Map<Lawyer, LawyerDto>(lawyer);
        }

        public async Task<List<LawyerDto>> GetListAsync()
        {
            var lawyers = await _lawyerRepository.GetListAsync();
            return _mapper.Map<List<Lawyer>, List<LawyerDto>>(lawyers);
        }

        public async Task<LawyerDto> CreateAsync(CreateUpdateLawyerDto input)
        {
            var lawyer = _mapper.Map<CreateUpdateLawyerDto, Lawyer>(input);
            var createdLawyer = await _lawyerRepository.InsertAsync(lawyer);
            return _mapper.Map<Lawyer, LawyerDto>(createdLawyer);
        }

        public async Task<LawyerDto> UpdateAsync(Guid id, CreateUpdateLawyerDto input)
        {
            var lawyer = await _lawyerRepository.GetAsync(id);
            _mapper.Map(input, lawyer);
            var updatedLawyer = await _lawyerRepository.UpdateAsync(lawyer);
            return _mapper.Map<Lawyer, LawyerDto>(updatedLawyer);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _lawyerRepository.DeleteAsync(id);
        }




    }
}

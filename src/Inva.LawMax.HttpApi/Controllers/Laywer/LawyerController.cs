using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Inva.LawMax.Application.Contracts.Dtos;
using Asp.Versioning;
using Volo.Abp;
using Inva.LawMax.Application.Contracts;

namespace Inva.LawMax.Controllers.Laywer
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Lawyer")]
    [Route("api/app/lawyers")]
    public class LawyerController : ControllerBase
    {
        private readonly ILawyerAppService _lawyerAppService;

        public LawyerController(ILawyerAppService lawyerAppService)
        {
            _lawyerAppService = lawyerAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LawyerDto>>> GetListAsync()
        {
            return await _lawyerAppService.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<LawyerDto> GetAsync(Guid id)
        {
            return await _lawyerAppService.GetAsync(id);
        }

        [HttpPost]
        public async Task<LawyerDto> CreateAsync(CreateUpdateLawyerDto input)
        {
            return await _lawyerAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public async Task<LawyerDto> UpdateAsync(Guid id, CreateUpdateLawyerDto input)
        {
            return await _lawyerAppService.UpdateAsync(id, input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _lawyerAppService.DeleteAsync(id);
        }
    }
}

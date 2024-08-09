
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Inva.LawMax.Application.Contracts.Dtos;
using Asp.Versioning;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Inva.LawMax.Application.Contracts;

namespace Inva.LawMax.Controllers.Case
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Case")]
    [Route("api/app/cases")]
    public class CaseController : AbpController
    {
        private readonly ICaseAppService _caseAppService;

        public CaseController(ICaseAppService caseAppService)
        {
            _caseAppService = caseAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CaseDto>>> GetListAsync()
        {
            return await _caseAppService.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<CaseDto> GetAsync(Guid id)
        {
            return await _caseAppService.GetAsync(id);
        }

        [HttpPost]
        public async Task<CaseDto> CreateAsync(CreateUpdateCaseDto input)
        {
            return await _caseAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public async Task<CaseDto> UpdateAsync(Guid id, CreateUpdateCaseDto input)
        {
            return await _caseAppService.UpdateAsync(id, input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _caseAppService.DeleteAsync(id);
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Inva.LawMax.Application.Contracts.Dtos;
using Asp.Versioning;
using Volo.Abp;
using Inva.LawMax.Application.Contracts;

namespace Inva.LawMax.Controllers.Hearing
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Hearing")]
    [Route("api/app/hearings")]
    public class HearingController : ControllerBase
    {
        private readonly IHearingAppService _hearingAppService;

        public HearingController(IHearingAppService hearingAppService)
        {
            _hearingAppService = hearingAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HearingDto>>> GetListAsync()
        {
            return await _hearingAppService.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<HearingDto> GetAsync(Guid id)
        {
            return await _hearingAppService.GetAsync(id);
        }

        [HttpPost]
        public async Task<HearingDto> CreateAsync(CreateUpdateHearingDto input)
        {
            return await _hearingAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public async Task<HearingDto> UpdateAsync(Guid id, CreateUpdateHearingDto input)
        {
            return await _hearingAppService.UpdateAsync(id, input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _hearingAppService.DeleteAsync(id);
        }
    }
}

using AutoMapper;
using Inva.LawMax.Application.Contracts.Dtos;
using Inva.LawMax.Domain.Entities;

namespace Inva.LawMax;

public class LawMaxApplicationAutoMapperProfile : Profile
{
    public LawMaxApplicationAutoMapperProfile()
    {

        CreateMap<Lawyer, LawyerDto>();
        CreateMap<CreateUpdateLawyerDto, Lawyer>();
        CreateMap<Case, CaseDto>();
        CreateMap<CreateUpdateCaseDto, Case>();
        CreateMap<Hearing, HearingDto>();
        CreateMap<CreateUpdateHearingDto, Hearing>();

    }
}

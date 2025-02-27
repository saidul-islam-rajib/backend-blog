using Mapster;
using Sober.Application.Pages.Educations.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.EducationAggregate.Entities;

namespace Sober.Api.Common.Mappings
{
    public class EducationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(EducationRequest Request, Guid UserId, string LogoPath), CreateEducationCommand>()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.IsCurrentStudent, src => src.Request.IsCurrentStudent)
                .Map(dest => dest.InstituteLogo, src => src.LogoPath)
                .Map(dest => dest.EducationSection, src => src.Request.EducationSection)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<EducationSectionRequest, EducationSectionCommand>()
                .Map(dest => dest.SectionDescription, src => src.SectionDescription);

            config.NewConfig<Education, EducationResponse>()
                .Map(dest => dest.EducationId, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value)
                .Map(dest => dest.InstituteName, src => src.InstituteName)
                .Map(dest => dest.InstituteLogo, src => src.InstituteLogo)
                .Map(dest => dest.Department, src => src.Department)
                .Map(dest => dest.IsCurrentStudent, src => src.IsCurrentStudent);

            config.NewConfig<EducationSection, EducationSectionResponse>()
                .Map(dest => dest.EducationSectionId, src => src.Id.Value)
                .Map(dest => dest.SectionDescription, src => src.SectionDescription);


            config.NewConfig<(UpdateEducationRequest Request, Guid EducationId, Guid UserId, string LogoPath), UpdateEducationCommand>()
                .Map(dest => dest.EducationId, src => src.EducationId)
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.InstituteName, src => src.Request.InstituteName)
                .Map(dest => dest.InstituteLogo, src => src.LogoPath)
                .Map(dest => dest.Department, src => src.Request.Department)
                .Map(dest => dest.IsCurrentStudent, src => src.Request.IsCurrentStudent)
                .Map(dest => dest.StartDate, src => src.Request.StartDate)
                .Map(dest => dest.EndDate, src => src.Request.EndDate)                
                .Map(dest => dest.EducationSection, src => src.Request.EducationSection.Adapt<List<UpdateEducationSectionCommand>>());

            config.NewConfig<UpdateEducationSectionRequest, UpdateEducationSectionCommand>()
                .Map(dest => dest.SectionDescription, src => src.SectionDescription);
        }
    }
}

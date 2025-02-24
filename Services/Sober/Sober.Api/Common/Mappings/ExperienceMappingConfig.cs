using Mapster;
using Sober.Application.Pages.Experiences.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate.Entities;

namespace Sober.Api.Common.Mappings
{
    public class ExperienceMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(ExperienceRequest Request, Guid UserId, string LogoPath), CreateExperienceCommand>()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.CompanyLogo, src => src.LogoPath)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Experience, ExperienceResponse>()
                .Map(dest => dest.ExperienceId, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value)
                .Map(dest => dest.Designation, src => src.Designation)
                .Map(dest => dest.CompanyLogo, src => src.CompanyLogo)
                .Map(dest => dest.CompanyName, src => src.CompanyName);

            config.NewConfig<ExperienceSection, ExperienceSectionResponse>()
                .Map(dest => dest.ExperienceSectionId, src => src.Id.Value)
                .Map(dest => dest.SectionDescription, src => src.SectionDescription);

            config.NewConfig<(ExperienceRequest Request, Guid UserId, Guid ExperienceId), UpdateExperienceCommand>()
                .Map(dest => dest.ExperienceId, src => src.ExperienceId)
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest, src => src.Request);
        }
    }
}

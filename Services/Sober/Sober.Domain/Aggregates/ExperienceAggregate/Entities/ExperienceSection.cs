using Sober.Domain.Aggregates.ExperienceAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.ExperienceAggregate.Entities;

public sealed class ExperienceSection : Entity<ExperienceSectionId>
{
    public string SectionDescription { get; set; } = null!;

    private ExperienceSection(ExperienceSectionId experienceSectionId, string sectionDescription) : base(experienceSectionId)
    {
        SectionDescription = sectionDescription;
    }

    public static ExperienceSection Create(string sectionDescription)
    {
        ExperienceSection experienceSection = new ExperienceSection(ExperienceSectionId.CreateUqique(), sectionDescription);
        return experienceSection;
    }

    public ExperienceSection()
    {
    }
}

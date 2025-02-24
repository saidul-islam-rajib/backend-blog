using Sober.Domain.Aggregates.EducationAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.EducationAggregate.Entities;

public sealed class EducationSection : Entity<EducationSectionId>
{
    public string SectionDescription { get; set; } = null!;

    private EducationSection(
        EducationSectionId educationSectionId,
        string sectionDescription) : base(educationSectionId)
    {
        SectionDescription = sectionDescription;
    }

    public static EducationSection Create(string sectionDescription)
    {
        EducationSection education = new EducationSection(EducationSectionId.CreateUqique(), sectionDescription);
        return education;
    }

    public EducationSection()
    {
    }
}

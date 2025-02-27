using Sober.Domain.Aggregates.EducationAggregate.Entities;
using Sober.Domain.Aggregates.EducationAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.EducationAggregate
{
    public sealed class Education : AggregateRoot<EducationId>
    {
       readonly List<EducationSection> _educationSection = new();
        public string InstituteName { get; set; } = null!;
        public string? InstituteLogo { get; set; }
        public string Department { get; set; } = null!;
        public bool IsCurrentStudent { get; set; }
        public DateTime StartDate { get ; set; }
        public DateTime? EndDate { get; set; }
        public UserId UserId { get; private set; }
        public ICollection<EducationSection> EducationSection => _educationSection;

        private Education(
            EducationId id,
            UserId userId,
            string instituteName,
            string? instituteLogo,
            string department,
            bool isCurrentStudent,
            List<EducationSection> educationSection,
            DateTime startDate,
            DateTime? endDate) : base(id)
        {
            UserId = userId;
            InstituteName = instituteName;
            InstituteLogo = instituteLogo ?? null;
            Department = department;
            IsCurrentStudent = isCurrentStudent;
            _educationSection = educationSection;
            StartDate = startDate;
            EndDate = endDate;
        }

        public static Education Create(
            UserId userId,
            string instituteName,
            string? instituteLogo,
            string department,
            bool isCurrentStudent,
            List<EducationSection> educationSection,
            DateTime startDate,
            DateTime? endDate)
        {
            Education response = new Education(
                EducationId.CreateUnique(),
                userId,
                instituteName,
                instituteLogo,
                department,
                isCurrentStudent,
                educationSection,
                startDate,
                endDate);

            return response;
        }

        private Education() { }
    }
}

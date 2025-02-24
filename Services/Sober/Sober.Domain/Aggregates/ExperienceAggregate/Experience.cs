using Sober.Domain.Aggregates.ExperienceAggregate.Entities;
using Sober.Domain.Aggregates.ExperienceAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.ExperienceAggregate
{
    public sealed class Experience : AggregateRoot<ExperienceId>
    {
        private readonly List<ExperienceSection> _experienceSection = new();
        public string CompanyName { get; set; } = null!;
        public string? ShortName { get; set; }
        public string? CompanyLogo { get; set; }
        public string Designation { get; set; } = null!;
        public bool IsCurrentEmployee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsFullTimeEmployee { get; set; }
        public UserId UserId { get; set; }
        public ICollection<ExperienceSection> ExperienceSection => _experienceSection;

        private Experience(
            ExperienceId experienceId,
            UserId userId,
            string companyName,
            string shortName,
            string companyLogo,
            string designation,
            bool isCurrentEmployee,
            bool isFullTimeEmployee,
            List<ExperienceSection> experienceSection,
            DateTime startDate,
            DateTime endDate
            ) : base(experienceId)
        {
            UserId = userId;
            CompanyName = companyName;
            ShortName = shortName ?? null;
            CompanyLogo = companyLogo ?? null;
            Designation = designation;
            IsCurrentEmployee = isCurrentEmployee;
            StartDate = startDate;
            EndDate = endDate;
            IsFullTimeEmployee = isFullTimeEmployee;
            _experienceSection = experienceSection;
        }

        public static Experience Create(
            UserId userId,
            string companyName,
            string shortName,
            string companyLogo,
            string designation,
            bool isCurrentEmployee,
            bool isFullTimeEmployee,
            List<ExperienceSection> experienceSection,
            DateTime startDate,
            DateTime endDate
            )
        {
            Experience response = new Experience(
                ExperienceId.CreateUnique(),
                userId,
                companyName,
                shortName,
                companyLogo,
                designation,
                isCurrentEmployee,
                isFullTimeEmployee,
                experienceSection,
                startDate,
                endDate);

            return response;
        }        

        private Experience()
        {
            
        }
    }
}

using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.ExperienceAggregate.ValueObjects
{
    public sealed class ExperienceId : ValueObject
    {
        public Guid Value { get; private set; }
        public ExperienceId(Guid value)
        {
            Value = value;
        }

        public static ExperienceId CreateUnique()
        {
            return new ExperienceId(Guid.NewGuid());
        }

        public static ExperienceId Create(Guid value)
        {
            return new ExperienceId(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

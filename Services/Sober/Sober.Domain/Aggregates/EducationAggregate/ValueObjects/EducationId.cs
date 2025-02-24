using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.EducationAggregate.ValueObjects
{
    public sealed class EducationId : ValueObject
    {
        public Guid Value { get; private set; }
        public EducationId(Guid value)
        {
            Value = value;
        }

        public static EducationId CreateUnique()
        {
            return new EducationId(Guid.NewGuid());
        }

        public static EducationId Create(Guid value)
        {
            return new EducationId(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

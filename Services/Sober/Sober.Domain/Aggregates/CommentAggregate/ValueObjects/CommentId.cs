using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.CommentAggregate.ValueObjects
{
    public sealed class CommentId : ValueObject
    {
        public Guid Value { get; private set; }
        public CommentId(Guid value)
        {
            Value = value;
        }

        public static CommentId CreateUnique()
        {
            return new CommentId(Guid.NewGuid());
        }

        public static CommentId Create(Guid value)
        {
            return new CommentId(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

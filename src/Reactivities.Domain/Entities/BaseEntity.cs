using System;

namespace Reactivities.Domain.Entities
{
    public class BaseEntity : IEquatable<BaseEntity>
    {
        public Guid Id { get; private set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public bool Equals(BaseEntity other)
        {
            return other != null && Id == other.Id;
        }
    }
}
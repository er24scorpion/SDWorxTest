using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.Data
{
    /// <summary>
    /// ID incrementing generator for in-memory database
    /// (in case of relational db, that would happend on DB level)
    /// </summary>
    public class IdValueGenerator : ValueGenerator<int>
    {
        private int _current;

        public override bool GeneratesTemporaryValues => false;

        public override int Next(EntityEntry entry)
            => Interlocked.Increment(ref _current);
    }
}

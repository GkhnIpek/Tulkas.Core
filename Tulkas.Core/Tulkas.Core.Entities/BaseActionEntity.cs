using System;

namespace Tulkas.Core.Entities
{
    public class BaseActionEntity<T> : BaseEntity<T>
    {
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

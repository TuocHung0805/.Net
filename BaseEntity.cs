using System;

namespace Store
{
    public abstract class BaseEntity
    {
        public bool IsDelete { get; set; } = false;
        public DateTime? CreatedDate { get; set; } = null;
        public DateTime? UpdatedDate { get; set; } = null;
        public DateTime? DeletedDate { get; set; } = null;
    }
}

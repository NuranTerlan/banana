using System;

namespace Domain.Commons
{
    public class AuditEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
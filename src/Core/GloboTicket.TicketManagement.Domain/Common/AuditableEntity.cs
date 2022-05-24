using System;

namespace GloboTicket.TicketManagement.Domain.Common
{
    public class AuditableEntity
    {
#nullable enable
        public string? CreatedBy { get; set; }
#nullable disable
        public DateTime CreatedDate { get; set; }
#nullable enable
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
#nullable disable
    }
}

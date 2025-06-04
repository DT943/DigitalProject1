using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Domain.Models
{
    public class BasicEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Code { get; set; }


    }

    public class BasicEntityWithAuditInfo : BasicEntity
    {
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
    }

    public class BasicEntityWithAuditAndFakeDelete : BasicEntityWithAuditInfo
    {
        public bool IsDeleted { get; set; } = false;
    }

    public class BasicEntityAndFakeDelete : BasicEntity
    {
        public bool IsDeleted { get; set; } = false;
    }




    public class ApproveEntityWithAuditAndFakeDelete : BasicEntityWithAuditInfo
    {
        public string? AwaitingApprovalUserCode { get; set; }

        public string? ApprovedUserCode { get; set; }

        public string ApprovalStatus { get; set; } = "PendingApproval";
    }

}

using System.ComponentModel.DataAnnotations;

namespace Audit.Domain
{
    public class AuditDetails
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(100)]
        public string? UserCode { get; set; }

        public string? Token { get; set; }
        public string? userRole { get; set; }

        [MaxLength(100)]
        public string? controllerName { get; set; }

        [MaxLength(100)]
        public string? actionName { get; set; }

        public string? request { get; set; }

        public string? response { get; set; }

        public DateTime? ActionTime { get; set; }
        [MaxLength(100)]
        public string? IP { get; set; }




    }
}

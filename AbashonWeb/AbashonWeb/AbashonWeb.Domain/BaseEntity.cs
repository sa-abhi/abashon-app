using System;
using System.ComponentModel.DataAnnotations;

namespace AbashonWeb.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [StringLength(20)]
        public string UpdatedBy { get; set; }
    }
}

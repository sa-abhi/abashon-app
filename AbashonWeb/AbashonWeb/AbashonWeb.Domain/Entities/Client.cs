using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Domain.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        [StringLength(10)]
        public string ClientIdentificatinNumber { get; set; }

        [Required]
        [MinLength(2)]
        public string ClientFirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string ClientLastName { get; set; }
        public string Email { get; set; }

        [Required]
        [MinLength(11), MaxLength(11)]
        public string ContactNo { get; set; }

        [Required]
        [MaxLength(300)]
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}

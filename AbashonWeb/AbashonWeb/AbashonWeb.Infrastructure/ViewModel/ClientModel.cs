using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Infrastructure.ViewModel
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public string ClientIdentificatinNumber { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}

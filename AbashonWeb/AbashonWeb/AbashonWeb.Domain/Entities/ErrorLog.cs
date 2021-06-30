using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Domain.Entities
{
    public class ErrorLog : BaseEntity
    {        
        public string Source { get; set; }
        public string Method { get; set; }
        public string Arguments { get; set; }
        public string LineNo { get; set; }
        public string Message { get; set; }
        public string PreviewMessage { get; set; }
        public string StackTrace { get; set; }       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DAL.Models
{
    public class Lead
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

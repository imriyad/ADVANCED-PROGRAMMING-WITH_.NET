using System;

namespace CRMSystem.DAL.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

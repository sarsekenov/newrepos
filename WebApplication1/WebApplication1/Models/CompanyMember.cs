using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CompanyMember
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public int CompanyId { get; set; }
    }
}
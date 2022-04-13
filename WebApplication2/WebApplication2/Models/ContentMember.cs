using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ContentMember
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Allows { get; set; }
        public int ContentId { get; set; }
        
    }
}
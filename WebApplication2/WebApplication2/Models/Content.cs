using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int FolderId { get; set; }
    }
}
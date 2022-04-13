using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class FolderMember
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Allows { get; set; }
        public string Role { get; set; }
        public int FolderId { get; set; }
    }
}
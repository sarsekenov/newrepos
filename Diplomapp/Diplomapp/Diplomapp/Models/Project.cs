using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplomapp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }
    }
}
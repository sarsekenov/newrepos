using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplomapp.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deadline { get; set; }
        public int Status { get; set; }
        public bool IsCompleted { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
    }
}
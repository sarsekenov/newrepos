using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplomapp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
    }
}
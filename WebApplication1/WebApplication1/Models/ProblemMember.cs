﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProblemMember
    {
        public string Id { get; set; }
        public string Role { get; set; }
        //public string Allows { get; set; }
        public int TaskId { get; set; }
    }
}
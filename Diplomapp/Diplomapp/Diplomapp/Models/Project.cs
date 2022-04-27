using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using MvvmHelpers;

namespace Diplomapp.Models
{
    public class Project 
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public int CompanyId { get; set ;}

    }
}
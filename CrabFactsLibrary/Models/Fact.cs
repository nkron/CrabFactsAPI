using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrabFactsLibrary.Models
{
    public class Fact
    {
        public int id { get; set; }
        public string description { get; set; }
        public List<Crab> crabs { get; set; }       
    }
}
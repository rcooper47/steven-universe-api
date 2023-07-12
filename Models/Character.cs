using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace steven_api.Models
{
    public class Character
    {
        public int id { get; set; }
        public String? name { get; set; }
        public String? gemStone { get; set; }
        public String? affiliations { get; set; }
        public String? alignment { get; set; }
        public String? status { get; set; }
        //public List<Character>? friends { get; set; }
    }
}
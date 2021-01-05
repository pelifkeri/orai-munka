using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkMySQL.Models
{
    public class Etel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Vegan { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}

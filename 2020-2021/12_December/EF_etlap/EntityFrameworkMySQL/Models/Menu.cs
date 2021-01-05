using System.Collections.Generic;

namespace EntityFrameworkMySQL.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string EtkezesiTipus { get; set; }

        public List<Etel> Etelek { get; set; }
    }
}

using System.Collections.Generic;

namespace Coders_Airlines.Models
{
    public class Countries
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<string> Cities { get; set; }
    }
}

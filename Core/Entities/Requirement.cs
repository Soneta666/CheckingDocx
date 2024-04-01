using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Requirement
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public ICollection<Value> Values { get; set; }
        
    }
}

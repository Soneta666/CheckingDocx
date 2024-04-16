using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Value
    {
        [Key]
        public uint Id { get; set; }

        public string Name { get; set; }

        public uint RequirementId { get; set; }
        public Requirement Requirement { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ValueDTO
    {
        public uint Id {  get; set; }

        public string Value { get; set; }

        public uint RequirementId { get; set; }
    }
}

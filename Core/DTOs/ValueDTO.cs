using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ValueDTO
    {
        public uint Id {  get; set; }

        public string Name { get; set; }

        public uint RequirementId { get; set; }
        public RequirementDTO? Requirement { get; set; }
    }
}

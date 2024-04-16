using Core.DTOs;
using Core.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MapperProfiles
{
    public class Mapping
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<Value, ValueDTO>
                .NewConfig()
                .Map(dest => dest.Requirement, src => src.Requirement);
            TypeAdapterConfig<ValueDTO, Value>.NewConfig();
            
            TypeAdapterConfig<Requirement, RequirementDTO>
                .NewConfig();
            TypeAdapterConfig<RequirementDTO, Requirement>
                .NewConfig();
        }
    }
}

using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRequirementsService
    {
        List<Requirement> GetRequirements();

        void Create(RequirementDTO requirement);

        void Edit(Requirement requirement);

        void Delete(int id);
    }
}

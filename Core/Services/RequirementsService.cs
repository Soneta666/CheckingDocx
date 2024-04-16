using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class RequirementsService : IRequirementsService
    {
        private readonly IRepository<Requirement> requirementRepo;
        private readonly IMapper mapper;

        public RequirementsService(IRepository<Requirement> requirementRepo, IMapper mapper)
        {
            this.requirementRepo = requirementRepo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RequirementDTO>> GetAll()
        {
            var result = await requirementRepo.GetAll();
            return mapper.Map<IEnumerable<RequirementDTO>>(result);
        }
        
        public async Task<RequirementDTO?> GetById(uint id)
        {
            if(id < 0) return null;

            Requirement requirement = await requirementRepo.GetItemBySpec(new Requirements.ById(id));

            return mapper.Map<RequirementDTO>(requirement);
        }

        public async Task Create(RequirementDTO requirement)
        {
            await requirementRepo.Insert(mapper.Map<Requirement>(requirement));
            await requirementRepo.Save();
        }

        public async Task Update(RequirementDTO requirement)
        {
            await requirementRepo.Update(mapper.Map<Requirement>(requirement));
            await requirementRepo.Save();
        }

        public async Task Delete(uint id)
        {
            if(await requirementRepo.GetById(id) == null) return;

            await requirementRepo.Delete(id);
            await requirementRepo.Save();
        }
    }
}

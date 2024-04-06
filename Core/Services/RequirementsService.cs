using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
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
        private readonly IRepository<Value> valueRepo;
        private readonly IMapper mapper;

        public RequirementsService(IRepository<Requirement> requirementRepo, IRepository<Value> valueRepo, IMapper mapper)
        {
            this.requirementRepo = requirementRepo;
            this.valueRepo = valueRepo;
            this.mapper = mapper;
        }

        public List<Requirement> GetAll()
        {
            return requirementRepo.Get().ToList();
        }
        
        public Requirement? GetById(int id)
        {
            if(id < 0) return null;

            Requirement requirement = requirementRepo.Get().FirstOrDefault(r => r.Id == id);

            return requirement;
        }

        public void Create(RequirementDTO requirement)
        {
            requirementRepo.Insert(mapper.Map<Requirement>(requirement));
            requirementRepo.Save();
        }

        public void Update(Requirement requirement)
        {
            requirementRepo.Update(requirement);
            requirementRepo.Save();
        }

        public void Delete(int id)
        {
            if (valueRepo.Get().FirstOrDefault(v => v.RequirementId == id) != null) return;

            Requirement requirement = GetById(id);

            requirementRepo.Delete(requirement);
            requirementRepo.Save();
        }
    }
}

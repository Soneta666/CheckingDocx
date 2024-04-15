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
    public class ValuesService : IValuesService
    {
        private readonly IRepository<Value> valueRepo;
        private readonly IMapper mapper;

        public ValuesService(IRepository<Value> valueRepo, IMapper mapper)
        {
            this.valueRepo = valueRepo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ValueDTO>> GetAll()
        {
            var result = await valueRepo.GetAll();
            return mapper.Map<IEnumerable<ValueDTO>>(result);
        }

        public async Task<ValueDTO?> GetById(int id)
        {
            if (id < 0) return null;

            var value = valueRepo.GetByID(id);

            return mapper.Map<ValueDTO>(value);
        }

        public async Task Create(ValueDTO value)
        {
            await valueRepo.Insert(mapper.Map<Value>(value));
            await valueRepo.Save();
        }

        public async Task Update(ValueDTO value)
        {
            await valueRepo.Update(mapper.Map<Value>(value));
            await valueRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await valueRepo.GetByID(id) == null) return;

            await valueRepo.Delete(id);
            await valueRepo.Save();
        }
    }
}

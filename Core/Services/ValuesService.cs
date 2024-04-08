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

        public List<Value> GetAll()
        {
            return valueRepo.Get().ToList();
        }

        public Value? GetById(int id)
        {
            if (id < 0) return null;

            Value value = valueRepo.Get().FirstOrDefault(r => r.Id == id);

            return value;
        }

        public void Create(ValueDTO value)
        {
            valueRepo.Insert(mapper.Map<Value>(value));
            valueRepo.Save();
        }

        public void Update(ValueDTO value)
        {
            valueRepo.Update(mapper.Map<Value>(value));
            valueRepo.Save();
        }

        public void Delete(int id)
        {
            Value value = GetById(id);

            valueRepo.Delete(value);
            valueRepo.Save();
        }
    }
}

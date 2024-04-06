using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IValuesService
    {
        List<Value> GetValues();

        void Create(ValueDTO value);

        void Edit(Value value);

        void Delete(int id);
    }
}

using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IValuesService
    {
        Task<IEnumerable<ValueDTO>> GetAll();
        Task<ValueDTO?> GetById(int id);

        Task Create(ValueDTO value);

        Task Update(ValueDTO value);

        Task Delete(int id);
    }
}

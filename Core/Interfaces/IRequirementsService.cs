﻿using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRequirementsService
    {
        Task<IEnumerable<RequirementDTO>> GetAll();

        Task<RequirementDTO?> GetById(uint id);

        Task Create(RequirementDTO requirement);

        Task Update(RequirementDTO requirement);

        Task Delete(uint id);
    }
}

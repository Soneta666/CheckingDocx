using Ardalis.Specification;
using Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    internal class Requirements
    {
        public class ById : Specification<Requirement>
        {
            public ById(uint id)
            {
                Query
                    .Where(r => r.Id == id);
            }
        }
    }
}

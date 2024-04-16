using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Core.Entities;

namespace Core.Specifications
{
    public static class Values
    {
        public class GetAll : Specification<Value>
        {
            public GetAll()
            {
                Query
                    .Include(v => v.Requirement);
            }
        }
        public class ById : Specification<Value>
        {
            public ById(uint id)
            {
                Query
                    .Where(v => v.Id == id)
                    .Include(v => v.Requirement);
            }
        }
    }
}

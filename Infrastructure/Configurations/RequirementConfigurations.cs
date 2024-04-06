using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class RequirementConfigurations : IEntityTypeConfiguration<Requirement>
    {
        public void Configure(EntityTypeBuilder<Requirement> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.Values).WithOne(v => v.Requirement).HasForeignKey(v => v.RequirementId);
        }
    }
}

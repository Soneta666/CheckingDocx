using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class DbContextExtensions
    {
        public static void SeedRequirements(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Requirement>().HasData(new[]
            {
                new Requirement()
                {
                    Id = 1,
                    Name = "Шрифт",
                    GetSearch = "FontFamily"
                },
                new Requirement()
                {
                    Id = 2,
                    Name = "Розмір шрифту",
                    GetSearch = "Size"
                },
                new Requirement()
                {
                    Id = 3,
                    Name = "Вирівняти",
                    GetSearch = "Size"
                },
            });
        }
        public static void SeedValues(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Value>().HasData(new[]
            {
                new Value()
                {
                    Id = 1,
                    Name = "Times New Roman",
                    RequirementId = 1,
                },
                new Value()
                {
                    Id = 2,
                    Name = "Arial",
                    RequirementId = 1,
                },
                new Value()
                {
                    Id = 3,
                    Name = "MS Sans Serif",
                    RequirementId = 1,
                },
                new Value()
                {
                    Id = 4,
                    Name = "10",
                    RequirementId = 2,
                },
                new Value()
                {
                    Id = 5,
                    Name = "11",
                    RequirementId = 2,
                },
                new Value()
                {
                    Id = 6,
                    Name = "12",
                    RequirementId = 2,
                },
            });
        }
    }
}

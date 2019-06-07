using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fruits.model
{
    public class FruitsContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public FruitsContext(DbContextOptions<FruitsContext> options)
        : base(options)
        {

        }

        public DbSet<Fruitscls> Fruits { get; set; }
    }
}

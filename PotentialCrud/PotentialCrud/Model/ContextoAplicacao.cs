using Microsoft.EntityFrameworkCore;
using PotentialCrud.Model.Developers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotentialCrud.Model
{
    public class ContextoAplicacao:DbContext
    {
        public ContextoAplicacao(DbContextOptions<ContextoAplicacao>options):base(options)
        {

        }

        public DbSet<Developer> Developers { get; set; }


    }
}

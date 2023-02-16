using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmpTracker.Models;

namespace EmpTracker.Data
{
    public class EmpTrackerContext : DbContext
    {
        public EmpTrackerContext (DbContextOptions<EmpTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<EmpTracker.Models.Engineer> Engineer { get; set; } = default!;

        public DbSet<EmpTracker.Models.WorkLocation> WorkLocation { get; set; }
    }
}

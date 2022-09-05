using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Data
{
    public class SimulationDbContext : IdentityDbContext
    {
        public SimulationDbContext(DbContextOptions<SimulationDbContext> options)
            : base(options)
        {
        }
    }
}

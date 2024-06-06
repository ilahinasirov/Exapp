using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.Context
{
	public class ProjectContext : DbContext
	{

        public ProjectContext():base()
        {
                
        }
		public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=pgsqlilahi;Database=Exapp");
		}

		
		public DbSet<User> Users { get; set; }
	}
}

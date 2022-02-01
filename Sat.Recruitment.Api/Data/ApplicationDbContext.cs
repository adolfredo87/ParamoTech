using Sat.Recruitment.Api.Models;
using System;
using System.Collections.Generic;
using FileContextCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Data
{
	public class ApplicationDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseFileContextDatabase(location: @"F:\Proyectos\Git\adolfredo87\ParamoTech\Sat.Recruitment.Api\Files\");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("Users");
		}

	}
}

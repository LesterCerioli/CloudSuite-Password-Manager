using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Messaging;
using PasswordGenerator.Domain.Models;
using PasswordGenerator.Infrastructure.Mappings.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Infrastructure.Context
{
	public class PasswordDbContext : DbContext
	{
		public PasswordDbContext(DbContextOptions<PasswordDbContext> options)
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			ChangeTracker.AutoDetectChangesEnabled = false;
		}

		public DbSet<Password> Passwords { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Ignore<ValidationResult>();
			modelBuilder.Ignore<Event>();

			foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
					e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
				property.SetColumnType("varchar(100)");

			modelBuilder.ApplyConfiguration(new PasswordEFCoreMapping());

			modelBuilder.Entity<Password>(c =>
			{
				c.ToTable("Passwords");
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}

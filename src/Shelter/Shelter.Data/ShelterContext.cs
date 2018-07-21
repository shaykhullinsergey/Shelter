using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Shelter
{
	public abstract class ShelterContext : DbContext
	{
		protected ShelterContext(DbContextOptions options) 
			: base(options)
		{
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			ValidateContext();
			return base.SaveChangesAsync(cancellationToken);
		}

		public override int SaveChanges()
		{
			ValidateContext();
			return base.SaveChanges();
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			ValidateContext();
			return base.SaveChanges(acceptAllChangesOnSuccess);
		}

		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
		{
			ValidateContext();
			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		private void ValidateContext()
		{
			var entities = ChangeTracker
				.Entries<IValidatableObject>()
				.Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
				.Select(x => x.Entity)
				.ToList();

			var serviceProvider = this.GetService<IServiceProvider>();

			var list = new List<ValidationResult>();
			
			foreach (var entity in entities)
			{
				var validationContext = new ValidationContext(entity, serviceProvider, null);

				list.AddRange(entity.Validate(validationContext));
			}

			if (list.Any())
			{
				throw new ShelterValidationException(list);
			}
		}
	}
}
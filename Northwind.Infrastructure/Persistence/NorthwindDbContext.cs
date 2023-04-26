using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Domain.Entities;

namespace Northwind.Infrastructure.Persistence
{
	public class NorthwindDbContext : DbContext
	{
		public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
		{

		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.ApplyConfiguration(new CustomerMapping());
			modelBuilder.ApplyConfiguration(new EmployeeMapping());
			modelBuilder.ApplyConfiguration(new ProductMapping());

			base.OnModelCreating(modelBuilder);
		}
		public class CustomerMapping : IEntityTypeConfiguration<Customer>
		{
			public void Configure(EntityTypeBuilder<Customer> builder)
			{
				builder.HasKey(x => x.Id);
				builder.Property(x => x.Id).IsRequired();
				builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
				builder.Property(x => x.ContactTitle).HasMaxLength(30);
				builder.Property(x => x.Address).HasMaxLength(60);
				builder.Property(x => x.City).HasMaxLength(15);
				builder.Property(x => x.Region).HasMaxLength(15);
				builder.Property(x => x.PostalCode).HasMaxLength(10);
				builder.Property(x => x.Country).HasMaxLength(15);
				builder.Property(x => x.Phone).HasMaxLength(24);
				builder.Property(x => x.Fax).HasMaxLength(24);
			}
		}
		public class EmployeeMapping : IEntityTypeConfiguration<Employee>
		{
			public void Configure(EntityTypeBuilder<Employee> builder)
			{
				builder.HasKey(x => x.Id);
				builder.Property(x => x.Id).IsRequired();
				builder.Property(x => x.LastName).HasMaxLength(20).IsRequired();
				builder.Property(x => x.FirstName).HasMaxLength(10).IsRequired();
				builder.Property(x => x.Title).HasMaxLength(30);
				builder.Property(x => x.TitleOfCourtesy).HasMaxLength(25);
				builder.Property(x => x.Address).HasMaxLength(60);
				builder.Property(x => x.City).HasMaxLength(15);
				builder.Property(x => x.Region).HasMaxLength(15);
				builder.Property(x => x.PostalCode).HasMaxLength(10);
				builder.Property(x => x.Country).HasMaxLength(15);
				builder.Property(x => x.HomePhone).HasMaxLength(24);
				builder.Property(x => x.Extension).HasMaxLength(4);
				builder.Property(x => x.Photo).HasMaxLength(15);
				builder.Property(x => x.Notes).HasColumnType("ntext");
				builder.Property(x => x.PhotoPath).HasMaxLength(255);
			}
		}
		public class ProductMapping : IEntityTypeConfiguration<Product>
		{
			public void Configure(EntityTypeBuilder<Product> builder)
			{
				builder.HasKey(x => x.Id);
				builder.Property(x => x.Id).IsRequired();
				builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
				builder.Property(x => x.QuantityPerUnit).HasMaxLength(20);
				builder.Property(x => x.UnitPrice).HasColumnType("money");
				builder.Property(x => x.UnitsInStock).HasColumnType("smallint");
				builder.Property(x => x.UnitsOnOrder).HasColumnType("smallint");
				builder.Property(x => x.ReorderLevel).HasColumnType("smallint");
			}
		}
	}
}

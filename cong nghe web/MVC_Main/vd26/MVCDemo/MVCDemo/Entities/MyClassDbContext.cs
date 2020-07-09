namespace MVCDemo.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyClassDbContext : DbContext
    {
        public MyClassDbContext()
            : base("name=MyClassDbContext")
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Office>()
                .HasMany(e => e.Employee)
                .WithOptional(e => e.Office1)
                .HasForeignKey(e => e.Office);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.FullName)
                .IsFixedLength();
        }
    }
}

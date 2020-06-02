namespace AptekaFramework.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Apteka_DBContext : DbContext
    {
        public Apteka_DBContext()
            : base("name=Apteka_DBContext")
        {
        }

        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<delivery> deliveries { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<medicine> medicines { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<order_med> order_med { get; set; }
        public virtual DbSet<payment> payments { get; set; }
        public virtual DbSet<vendor> vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.customers_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<delivery>()
                .Property(e => e.delivery_method)
                .IsUnicode(false);

            modelBuilder.Entity<delivery>()
                .Property(e => e.delivery_track_number)
                .IsUnicode(false);

            modelBuilder.Entity<delivery>()
                .Property(e => e.delivery_status)
                .IsUnicode(false);

            modelBuilder.Entity<medicine>()
                .Property(e => e.med_price)
                .HasPrecision(19, 2);

            modelBuilder.Entity<medicine>()
                .HasMany(e => e.order_med)
                .WithRequired(e => e.medicine)
                .HasForeignKey(e => e.medicines_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_med)
                .WithRequired(e => e.order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.amount)
                .HasPrecision(19, 2);

            modelBuilder.Entity<payment>()
                .Property(e => e.payment_method)
                .IsUnicode(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.payment_status)
                .IsUnicode(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.payment_number)
                .IsUnicode(false);

            modelBuilder.Entity<vendor>()
                .HasMany(e => e.medicines)
                .WithRequired(e => e.vendor)
                .HasForeignKey(e => e.vendors_ID)
                .WillCascadeOnDelete(false);
        }
    }
}

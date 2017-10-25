namespace Shop.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WeShop : DbContext
    {
        public WeShop()
            : base("name=WeShop")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<OrderBillChi> OrderBillChi { get; set; }
        public virtual DbSet<OrderBillFath> OrderBillFath { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProReview> ProReview { get; set; }
        public virtual DbSet<ProSort> ProSort { get; set; }
        public virtual DbSet<ShopCart> ShopCart { get; set; }
        public virtual DbSet<Sort> Sort { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .HasOptional(e => e.OrderBillFath)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ShopCart)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Cusid);

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.totalprice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Payment>()
                .HasOptional(e => e.OrderBillFath)
                .WithRequired(e => e.Payment)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderBillChi)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.procode);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.ProReview)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProSort)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ShopCart)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.Stock)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Tag)
                .WithMany(e => e.Product)
                .Map(m => m.ToTable("ProTag").MapLeftKey("ProCode").MapRightKey("TagId"));
        }
    }
}

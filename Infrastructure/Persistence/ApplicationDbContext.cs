using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<BusinessSpace> BusinessSpaces { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Credential> Credentials { get; set; }

        public DbSet<House> Houses { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<ReviewUser> ReviewUsers { get; set; }

        public DbSet<ReviewProperty> ReviewProperties { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Estate>(entity =>
            {
                entity.ToTable("Estates"); 

                entity.HasKey(e => e.Id); 
                entity.Property(e => e.Id)
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("uuid_generate_v4()")
                    .ValueGeneratedOnAdd(); 

                entity.Property(e => e.UserId)
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("uuid_generate_v4()")
                    .IsRequired(); 

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100); 

                entity.Property(e => e.Description)
                    .HasMaxLength(500); 

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)"); 

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ListingData)
                    .IsRequired();

                modelBuilder.Entity<Estate>()
                    .HasOne(e => e.User)
                    .WithMany(u => u.Estates)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            /********************************************************************/

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id)
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("uuid_generate_v4()")
                    .ValueGeneratedOnAdd();

                entity.Property(u => u.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            /********************************************************************/

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable("Apartments");

                entity.HasKey(a => a.EstateId);

                entity.Property(a => a.RoomNumber)
                    .IsRequired()
                    .HasColumnType("smallint");

                entity.Property(a => a.FloorNumber)
                    .IsRequired()
                    .HasColumnType("smallint");

                entity.Property(a => a.FullySeparated)
                    .IsRequired()
                    .HasColumnType("boolean");

                entity.HasOne<Estate>()
                    .WithOne()
                    .HasForeignKey<Apartment>(a => a.EstateId) 
                    .OnDelete(DeleteBehavior.Cascade); 
            });
            /********************************************************************/

            modelBuilder.Entity<BusinessSpace>(entity =>
            {
                entity.ToTable("BusinessSpaces");

                entity.HasKey(b => b.EstateId);

                entity.Property(b => b.FloorNumber)
                    .IsRequired()
                    .HasColumnType("smallint");

                entity.HasOne<Estate>()
                    .WithOne()
                    .HasForeignKey<BusinessSpace>(b => b.EstateId) 
                    .OnDelete(DeleteBehavior.Cascade); 
            });

            /*******************************************************************/

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contacts");

                entity.HasKey(c => c.Id); 

                entity.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

               
                entity.HasOne<User>()
                    .WithOne()
                    .HasForeignKey<Contact>(c => c.UserId) 
                    .OnDelete(DeleteBehavior.Cascade); 
            });
            /*******************************************************************/

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.ToTable("Credentials");

                entity.HasKey(c => c.UserId); 

                entity.Property(c => c.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne<User>()
                    .WithOne()
                    .HasForeignKey<Credential>(c => c.UserId) 
                    .OnDelete(DeleteBehavior.Cascade); 
            });

            /*******************************************************************/

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorites");

                entity.HasKey(f => new { f.UserId, f.EstateId });

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(f => f.UserId)
                    .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne<Estate>()
                    .WithMany()
                    .HasForeignKey(f => f.EstateId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });
            /*******************************************************************/

            modelBuilder.Entity<House>(entity =>
            {
                entity.ToTable("Houses");

                entity.HasKey(h => h.EstateId);

                entity.Property(h => h.OutsideAreaSize)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)"); 

              
                entity.HasOne<Estate>()
                    .WithOne()
                    .HasForeignKey<House>(h => h.EstateId) 
                    .OnDelete(DeleteBehavior.Cascade);
            });

            /*******************************************************************/

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Images");

                entity.HasKey(i => i.Id); 

                entity.Property(i => i.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(i => i.EstateId)
                    .IsRequired(); 

                entity.Property(i => i.Extenstion)
                    .IsRequired()
                    .HasMaxLength(10); 

              
                entity.HasOne<Estate>()
                    .WithMany()
                    .HasForeignKey(i => i.EstateId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });

            /*******************************************************************/

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Reports");

                entity.HasKey(r => r.Id);

                entity.Property(r => r.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(r => r.BuyerId)
                    .IsRequired();

                entity.Property(r => r.SellerId)
                    .IsRequired();

                entity.Property(r => r.Description)
                    .HasMaxLength(1000); 

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(r => r.BuyerId)
                    .OnDelete(DeleteBehavior.Restrict) 
                    .IsRequired();

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(r => r.SellerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });



            /*******************************************************************/

            modelBuilder.Entity<ReviewProperty>(entity =>
            {
                entity.ToTable("ReviewProperties");

                entity.HasKey(rp => rp.Id); 

                entity.Property(rp => rp.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(rp => rp.EstateId)
                    .IsRequired(); 

                entity.Property(rp => rp.BuyerId)
                    .IsRequired();

                entity.Property(rp => rp.Description)
                    .HasMaxLength(1000);

                entity.Property(rp => rp.Rating)
                    .IsRequired()
                    .HasColumnType("smallint");

                entity.HasOne<Estate>()
                    .WithMany()
                    .HasForeignKey(rp => rp.EstateId)
                    .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(rp => rp.BuyerId)
                    .OnDelete(DeleteBehavior.Restrict); 
            });

            /*******************************************************************/

            modelBuilder.Entity<ReviewUser>(entity =>
            {
                entity.ToTable("ReviewUsers");

                entity.HasKey(ru => ru.Id);

                entity.Property(ru => ru.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(ru => ru.BuyerId)
                    .IsRequired(); 

                entity.Property(ru => ru.SellerId)
                    .IsRequired();

                entity.Property(ru => ru.Description)
                    .HasMaxLength(1000); 

                entity.Property(ru => ru.Rating)
                    .IsRequired()
                    .HasColumnType("smallint"); 

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(ru => ru.BuyerId)
                    .OnDelete(DeleteBehavior.Restrict) 
                    .IsRequired();

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(ru => ru.SellerId)
                    .OnDelete(DeleteBehavior.Restrict) 
                    .IsRequired();
            });

            /*******************************************************************/

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");

                entity.HasKey(t => t.Id);

                entity.Property(t => t.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(t => t.SellerGuid)
                    .IsRequired(); 

                entity.Property(t => t.BuyerGuid)
                    .IsRequired(); 

                entity.Property(t => t.EstateGuid)
                    .IsRequired(); 

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(t => t.SellerGuid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(t => t.BuyerGuid)
                    .OnDelete(DeleteBehavior.Restrict) 
                    .IsRequired();

               
                entity.HasOne<Estate>()
                    .WithMany()
                    .HasForeignKey(t => t.EstateGuid)
                    .OnDelete(DeleteBehavior.Restrict) 
                    .IsRequired();
            });


        }
    }
}

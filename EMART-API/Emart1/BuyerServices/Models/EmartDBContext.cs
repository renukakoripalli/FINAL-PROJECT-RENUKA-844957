using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BuyerServices.Models
{
    public partial class EmartDBContext : DbContext
    {
        public EmartDBContext()
        {
        }

        public EmartDBContext(DbContextOptions<EmartDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Discounts> Discounts { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Subcategory> Subcategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CLLTCEC\\SQLEXPRESS;Initial Catalog=EmartDB;Persist Security Info=True;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("PK__Buyer__DE90ADE77831681F");

                entity.Property(e => e.Bid)
                    .HasColumnName("bid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Createddatetime)
                    .HasColumnName("createddatetime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasColumnName("emailid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mobilenumber)
                    .HasColumnName("mobilenumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Cartid)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Bid)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Categoryid)
                    .HasColumnName("categoryid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Iid)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Itemname)
                    .IsRequired()
                    .HasColumnName("itemname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Subcategoryid)
                    .HasColumnName("subcategoryid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.B)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Bid)
                    .HasConstraintName("FK__Cart__Bid__70DDC3D8");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__Cart__categoryid__71D1E811");

                entity.HasOne(d => d.I)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Iid)
                    .HasConstraintName("FK__Cart__Iid__6FE99F9F");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Subcategoryid)
                    .HasConstraintName("FK__Cart__subcategor__72C60C4A");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Categoryid)
                    .HasColumnName("categoryid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Briefdetails)
                    .IsRequired()
                    .HasColumnName("briefdetails")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasColumnName("categoryname")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Discounts>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("PK__Discount__C036565004537BEB");

                entity.Property(e => e.Did)
                    .HasColumnName("DId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountCode)
                    .IsRequired()
                    .HasColumnName("Discount_code")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Percentage).HasColumnName("percentage");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.Iid)
                    .HasName("PK__Items__C4962F8443D611BA");

                entity.Property(e => e.Iid)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Categoryid)
                    .HasColumnName("categoryid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Itemname)
                    .IsRequired()
                    .HasColumnName("itemname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sid)
                    .HasColumnName("sid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stocknumber).HasColumnName("stocknumber");

                entity.Property(e => e.Subcategoryid)
                    .IsRequired()
                    .HasColumnName("subcategoryid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__Items__category___4F7CD00D");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("FK__Items__sid__5AEE82B9");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Subcategoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Items__scid__5070F446");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Purchase__DD36D56205A64932");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Bid)
                    .IsRequired()
                    .HasColumnName("bid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Datetime)
                    .HasColumnName("datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iid)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasColumnName("sid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Transactionstatus)
                    .HasColumnName("transactionstatus")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Transactiontype)
                    .IsRequired()
                    .HasColumnName("transactiontype")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.B)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.Bid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Purchase__Buyer___5535A963");

                entity.HasOne(d => d.I)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.Iid)
                    .HasConstraintName("FK__Purchase__Item_i__5629CD9C");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.Sid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Purchase__Seller__5441852A");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__Seller__DDDFDD366FDF4CBB");

                entity.Property(e => e.Sid)
                    .HasColumnName("sid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Briefaboutcompany)
                    .HasColumnName("briefaboutcompany")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Contactnumber)
                    .IsRequired()
                    .HasColumnName("contactnumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasColumnName("emailid")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gstin)
                    .IsRequired()
                    .HasColumnName("gstin")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Postaladdress)
                    .IsRequired()
                    .HasColumnName("postaladdress")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.Property(e => e.Subcategoryid)
                    .HasColumnName("subcategoryid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Briefdetails)
                    .IsRequired()
                    .HasColumnName("briefdetails")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Categoryid)
                    .HasColumnName("categoryid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gst).HasColumnName("GST");

                entity.Property(e => e.Subcategoryname)
                    .IsRequired()
                    .HasColumnName("subcategoryname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__Subcatego__categ__173876EA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

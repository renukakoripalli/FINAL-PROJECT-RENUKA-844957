using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdminServices.Models
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

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("Item_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasColumnName("sid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StockNumber).HasColumnName("Stock_number");

                entity.Property(e => e.SubcategoryId)
                    .IsRequired()
                    .HasColumnName("subcategory_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Items__category___4F7CD00D");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Sid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Items__sid__5165187F");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Items__scid__5070F446");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Purchase__DD36D56205A64932");

                entity.Property(e => e.PId)
                    .HasColumnName("pId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BuyerId)
                    .IsRequired()
                    .HasColumnName("Buyer_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime)
                    .HasColumnName("Date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .HasColumnName("Item_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfItems).HasColumnName("Number_of_items");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SellerId)
                    .IsRequired()
                    .HasColumnName("Seller_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnName("transaction_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Purchase__Buyer___5535A963");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__Purchase__Item_i__5629CD9C");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.SellerId)
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

                entity.Property(e => e.Contactnumber).HasColumnName("contactnumber");

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasColumnName("emailid")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gstin)
                    .IsRequired()
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
                entity.Property(e => e.SubcategoryId)
                    .HasColumnName("subcategory_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Briefdetails)
                    .IsRequired()
                    .HasColumnName("briefdetails")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gst).HasColumnName("GST");

                entity.Property(e => e.SubcategoryName)
                    .IsRequired()
                    .HasColumnName("subcategory_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Subcatego__categ__173876EA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

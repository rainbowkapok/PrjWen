using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PrjWen.Models
{
    public partial class WenDBContext : DbContext
    {
        public WenDBContext()
        {
        }

        public WenDBContext(DbContextOptions<WenDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category商品類別> Category商品類別s { get; set; }
        public virtual DbSet<CreditCard信用卡> CreditCard信用卡s { get; set; }
        public virtual DbSet<Log記錄檔> Log記錄檔s { get; set; }
        public virtual DbSet<Member會員> Member會員s { get; set; }
        public virtual DbSet<OrderStatus訂單狀態> OrderStatus訂單狀態s { get; set; }
        public virtual DbSet<Order訂單總表> Order訂單總表s { get; set; }
        public virtual DbSet<Product商品> Product商品s { get; set; }
        public virtual DbSet<Receipt購買商品明細> Receipt購買商品明細s { get; set; }
        public virtual DbSet<Store各分店> Store各分店s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WenDB;encrypt=false;Integrated Security=True;encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<Category商品類別>(entity =>
            {
                entity.HasKey(e => e.Id類別編號);

                entity.ToTable("Category商品類別");

                entity.Property(e => e.CategoryName類別名稱)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CreditCard信用卡>(entity =>
            {
                entity.HasKey(e => e.Cid信用卡流水號);

                entity.ToTable("CreditCard信用卡");

                entity.Property(e => e.Cid信用卡流水號).HasColumnName("CId信用卡流水號");

                entity.Property(e => e.Cname信用卡公司名)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CName信用卡公司名");

                entity.Property(e => e.Cnum信用卡號)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CNum信用卡號");

                entity.Property(e => e.Cuse使用狀態).HasColumnName("CUse使用狀態");
            });

            modelBuilder.Entity<Log記錄檔>(entity =>
            {
                entity.ToTable("Log記錄檔");

                entity.Property(e => e.CreatedTime建立時間).HasColumnType("date");

                entity.Property(e => e.Level級別).HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SysAction)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.System).HasMaxLength(50);
            });

            modelBuilder.Entity<Member會員>(entity =>
            {
                entity.HasKey(e => e.Id會員編號);

                entity.ToTable("Member會員");

                entity.Property(e => e.Apikey)
                    .HasColumnName("APIKey")
                    .HasComment("以識別介接權限的GUID，APIKey需要提前申請");

                entity.Property(e => e.Cid信用卡流水號).HasColumnName("CId信用卡流水號");

                entity.Property(e => e.CreatedTime建立時間).HasColumnType("date");

                entity.Property(e => e.Email信箱)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender性別).HasComment("0:女，1:男");

                entity.Property(e => e.Name會員名稱)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Password密碼)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone手機號碼)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SessionId).HasComment("SessionId	字串GUID，由作業的發起方產生，以識別此次介接動作的一連串流程");

                entity.HasOne(d => d.Cid信用卡流水號Navigation)
                    .WithMany(p => p.Member會員s)
                    .HasForeignKey(d => d.Cid信用卡流水號)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Member會員_CreditCard信用卡");
            });

            modelBuilder.Entity<OrderStatus訂單狀態>(entity =>
            {
                entity.HasKey(e => e.OrdStatusId訂單狀態編號);

                entity.ToTable("OrderStatus訂單狀態");

                entity.Property(e => e.OrdName訂單狀態名稱)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Order訂單總表>(entity =>
            {
                entity.HasKey(e => e.OrdId訂單編號);

                entity.ToTable("Order訂單總表");

                entity.Property(e => e.OrdDate訂單日期).HasColumnType("datetime");

                entity.HasOne(d => d.OrdStatusId訂單狀態編號Navigation)
                    .WithMany(p => p.Order訂單總表s)
                    .HasForeignKey(d => d.OrdStatusId訂單狀態編號)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order訂單總表_OrderStatus訂單狀態");

                entity.HasOne(d => d.StoreId各店編號Navigation)
                    .WithMany(p => p.Order訂單總表s)
                    .HasForeignKey(d => d.StoreId各店編號)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order訂單總表_Store各分店");
            });

            modelBuilder.Entity<Product商品>(entity =>
            {
                entity.HasKey(e => e.Id產品編號);

                entity.ToTable("Product商品");

                entity.Property(e => e.Name產品名稱).HasMaxLength(50);

                entity.Property(e => e.Path圖片路徑).HasMaxLength(300);

                entity.Property(e => e.Price價格).HasColumnType("money");

                entity.HasOne(d => d.Id類別編號Navigation)
                    .WithMany(p => p.Product商品s)
                    .HasForeignKey(d => d.Id類別編號)
                    .HasConstraintName("FK_Product商品_Category商品類別");
            });

            modelBuilder.Entity<Receipt購買商品明細>(entity =>
            {
                entity.HasKey(e => e.Rid明細編號);

                entity.ToTable("Receipt購買商品明細");

                entity.Property(e => e.Rid明細編號).HasColumnName("RId明細編號");

                entity.HasOne(d => d.Id產品編號Navigation)
                    .WithMany(p => p.Receipt購買商品明細s)
                    .HasForeignKey(d => d.Id產品編號)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipt購買商品明細_Product商品");

                entity.HasOne(d => d.OrdId訂單編號Navigation)
                    .WithMany(p => p.Receipt購買商品明細s)
                    .HasForeignKey(d => d.OrdId訂單編號)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipt購買商品明細_Order訂單總表");
            });

            modelBuilder.Entity<Store各分店>(entity =>
            {
                entity.HasKey(e => e.StoreId各店編號);

                entity.ToTable("Store各分店");

                entity.Property(e => e.Address地址).HasMaxLength(200);

                entity.Property(e => e.StoreName店名)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Tel電話).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

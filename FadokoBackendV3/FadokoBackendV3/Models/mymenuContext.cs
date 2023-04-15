using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FadokoBackendV3.Models
{
    public partial class mymenuContext : DbContext
    {
        public mymenuContext()
        {
        }

        public mymenuContext(DbContextOptions<mymenuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Commodity> Commodities { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Receiptconn> Receiptconns { get; set; }
        public virtual DbSet<Tetelconn> Tetelconns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=mymenu;user=root;password=;sslmode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdId)
                    .HasName("PRIMARY");

                entity.ToTable("admin");

                entity.Property(e => e.AdId).HasColumnType("int(11)");

                entity.Property(e => e.Active).HasColumnType("int(2)");

                entity.Property(e => e.AdEmail)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.AdName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.AdPermission)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.AdPhone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Commodity>(entity =>
            {
                entity.HasKey(e => e.CoId)
                    .HasName("PRIMARY");

                entity.ToTable("commodity");

                entity.Property(e => e.CoId).HasColumnType("int(11)");

                entity.Property(e => e.CoActive).HasColumnType("int(2)");

                entity.Property(e => e.CoCat).HasColumnType("int(3)");

                entity.Property(e => e.CoName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.CoPrice).HasColumnType("int(10)");

                entity.Property(e => e.CoUnit).HasColumnType("int(10)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrId)
                    .HasName("PRIMARY");

                entity.ToTable("orders");

                entity.HasIndex(e => e.AdId, "CuId");

                entity.Property(e => e.OrId).HasColumnType("int(11)");

                entity.Property(e => e.AdId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Status).HasColumnType("int(11)");

                entity.HasOne(d => d.Ad)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AdId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("orders_ibfk_1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PrId)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.Property(e => e.PrId).HasColumnType("int(11)");

                entity.Property(e => e.PrActive).HasColumnType("int(2)");

                entity.Property(e => e.PrName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PrOther)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.PrPrice).HasColumnType("int(6)");

                entity.Property(e => e.PrSize)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PrUrl)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Receiptconn>(entity =>
            {
                entity.HasKey(e => e.ReId)
                    .HasName("PRIMARY");

                entity.ToTable("receiptconn");

                entity.HasIndex(e => e.CoId, "CoId");

                entity.HasIndex(e => e.PrId, "PrId");

                entity.Property(e => e.ReId).HasColumnType("int(7)");

                entity.Property(e => e.CoId).HasColumnType("int(11)");

                entity.Property(e => e.PrId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(10)");

                entity.HasOne(d => d.Co)
                    .WithMany(p => p.Receiptconns)
                    .HasForeignKey(d => d.CoId)
                    .HasConstraintName("receiptconn_ibfk_2");

                entity.HasOne(d => d.Pr)
                    .WithMany(p => p.Receiptconns)
                    .HasForeignKey(d => d.PrId)
                    .HasConstraintName("receiptconn_ibfk_1");
            });

            modelBuilder.Entity<Tetelconn>(entity =>
            {
                entity.HasKey(e => e.OrId)
                    .HasName("PRIMARY");

                entity.ToTable("tetelconn");

                entity.HasIndex(e => e.PrId, "PrId");

                entity.Property(e => e.OrId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PrId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.HasOne(d => d.Or)
                    .WithOne(p => p.Tetelconn)
                    .HasForeignKey<Tetelconn>(d => d.OrId)
                    .HasConstraintName("tetelconn_ibfk_1");

                entity.HasOne(d => d.Pr)
                    .WithMany(p => p.Tetelconns)
                    .HasForeignKey(d => d.PrId)
                    .HasConstraintName("tetelconn_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

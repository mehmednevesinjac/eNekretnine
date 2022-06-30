using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database
{
    public partial class NekretnineContext : DbContext
    {
        public NekretnineContext()
        {
        }

        public NekretnineContext(DbContextOptions<NekretnineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzave> Drzaves { get; set; } = null!;
        public virtual DbSet<Grad> Grads { get; set; } = null!;
        public virtual DbSet<Lokacije> Lokacijes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=app.fit.ba,1431;Database=Nekretnine;Trusted_Connection=false;User ID=Nekretnine;Password=mmGh$909;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Nekretnine");

            modelBuilder.Entity<Drzave>(entity =>
            {
                entity.HasKey(e => e.DrzavaId);

                entity.ToTable("Drzave");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.ToTable("Grad");

                entity.HasIndex(e => e.DrzavaId, "IX_Grad_DrzavaId");

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grads)
                    .HasForeignKey(d => d.DrzavaId);
            });

            modelBuilder.Entity<Lokacije>(entity =>
            {
                entity.HasKey(e => e.LokacijaId);

                entity.ToTable("Lokacije");

                entity.HasIndex(e => e.GradId, "IX_Lokacije_GradId");

                entity.Property(e => e.LokacijaId).HasColumnName("LokacijaID");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Lokacijes)
                    .HasForeignKey(d => d.GradId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

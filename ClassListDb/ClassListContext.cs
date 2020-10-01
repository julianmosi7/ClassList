using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassListDb
{
    public partial class ClassListContext : DbContext
    {
        public ClassListContext()
        {
        }

        public ClassListContext(DbContextOptions<ClassListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clazz> Clazzs { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("data source=C:\\Users\\mosha\\Documents\\Schule\\4.Klasse\\POS\\ClassList\\ClassListDb\\Students.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clazz>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClazzId).HasColumnName("Clazz_Id");

                entity.HasOne(d => d.Clazz)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClazzId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

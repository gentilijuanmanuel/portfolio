namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
            : base("name=ProjectContext")
        {
        }

        public virtual DbSet<Experiencia> Experiencia { get; set; }
        public virtual DbSet<Habilidad> Habilidad { get; set; }
        public virtual DbSet<TablaDato> TablaDato { get; set; }
        public virtual DbSet<Testimonio> Testimonio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experiencia>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Experiencia>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Experiencia>()
                .Property(e => e.Desde)
                .IsUnicode(false);

            modelBuilder.Entity<Experiencia>()
                .Property(e => e.Hasta)
                .IsUnicode(false);

            modelBuilder.Entity<Experiencia>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Habilidad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TablaDato>()
                .Property(e => e.Relacion)
                .IsUnicode(false);

            modelBuilder.Entity<TablaDato>()
                .Property(e => e.Valor)
                .IsUnicode(false);

            modelBuilder.Entity<TablaDato>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Testimonio>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<Testimonio>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Testimonio>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Testimonio>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Facebook)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Twitter)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.YouTube)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Foto)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Experiencia)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Usuario_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Habilidad)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Usuario_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Testimonio)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Usuario_id)
                .WillCascadeOnDelete(false);
        }
    }
}

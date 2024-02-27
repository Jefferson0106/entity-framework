using Microsoft.EntityFrameworkCore;
using projectoef.Models;

namespace projectoef;

      public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("d75a4879-cb18-40c3-94a5-3d80bafb1bfe"), Nombre = "Actividades pendiente", Peso = 20 });
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("d75a4879-cb18-40c3-94a5-3d80bafb1b02"), Nombre = "Actividades personales", Peso = 50 });

            
        modelBuilder.Entity<Categoria>(Categoria =>
        {
            Categoria.ToTable("Categoria");
            Categoria.HasKey(p=> p.CategoriaId);

            Categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);

            Categoria.Property(p=> p.Descripcion).IsRequired(false);

            Categoria.Property(p=> p.Peso);
   
            Categoria.HasData(categoriasInit);
        });
         
         List<Tarea> tareasInit = new List<Tarea>();

         tareasInit.Add(new Tarea() {TareaId = Guid.Parse("d75a4879-cb18-40c3-94a5-3d80bafb1b11"), CategoriaId = Guid.Parse("d75a4879-cb18-40c3-94a5-3d80bafb1bfe"), PrioridadTarea = Prioridad.Media, Titulo = "pago de servicio ", FechaCreacion = DateTime.Now });
          tareasInit.Add(new Tarea() {TareaId = Guid.Parse("d75a4879-cb18-40c3-94a5-3d80bafb1b10"), CategoriaId = Guid.Parse("d75a4879-cb18-40c3-94a5-3d80bafb1b02"), PrioridadTarea = Prioridad.Baja, Titulo = "terminar la pelicula", FechaCreacion = DateTime.Now });

        modelBuilder.Entity<Tarea>(tarea=>
    {
        tarea.ToTable("Tarea");
        tarea.HasKey(p=> p.TareaId);

        tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);

        tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);

        tarea.Property(p=> p.Descripcion).IsRequired(false);

        tarea.Property(p=> p.PrioridadTarea);

        tarea.Property(p=> p.FechaCreacion);

        tarea.Ignore(p=> p.Resume);

        tarea.HasData(tareasInit);
    });
        
    }

}
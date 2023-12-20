using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Project.FootballTrick.Shared.Entities;



namespace Project.FootballTrick.Dal
{
    public partial class FootballTrickContext : DbContext
    {
        public virtual DbSet<Team> Teams { get; set; }
       
        public FootballTrickContext(DbContextOptions<FootballTrickContext> options)
        : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            
             modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamId)
                .HasColumnName("TeamId");

                entity.Property(e => e.Name)
                .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                .HasColumnType("datetime");

            });    

            OnModelCreatingPartial(modelBuilder);   
                          
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        // protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        // {
        //     configurationBuilder.Properties<string>().HaveMaxLength(20);
        // }  

    }
}
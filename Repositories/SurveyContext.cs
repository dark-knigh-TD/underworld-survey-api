using Microsoft.EntityFrameworkCore;
using SurveyApi.Model;

namespace SurveyApi.Context
{
    public class SurveyContext : DbContext
    {
        public SurveyContext(DbContextOptions<SurveyContext> options) : base(options)
        {
        }

        // DbSets para las entidades
        public DbSet<UserSurvey> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<OptionsSurvey> Options { get; set; }
        public DbSet<Responses> Responses { get; set; }
        public DbSet<MultipleResponses> MultipleResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración adicional de las relaciones, restricciones, etc.
            //modelBuilder.Entity<User>().ToTable("users");
            //modelBuilder.Entity<Survey>().ToTable("surveys");
            //modelBuilder.Entity<Question>().ToTable("questions");
            //modelBuilder.Entity<Option>().ToTable("options");
            //modelBuilder.Entity<Responses>().ToTable("responses");
            //modelBuilder.Entity<MultipleResponse>().ToTable("multiple_responses");
        }
    }
}
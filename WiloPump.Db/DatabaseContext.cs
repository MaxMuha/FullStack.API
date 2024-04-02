using Microsoft.EntityFrameworkCore;
using WiloPump.Db.Models;

namespace WiloPump.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Pump> Pumps { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pump>()
                .HasOne(e => e.Engine)
                .WithMany()
                .HasForeignKey(e => e.EngineId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pump>()
                .HasOne(e => e.HousingMaterial)
                .WithMany(e => e.HousingMaterialPumps)
                .HasForeignKey(e => e.HousingMaterialId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pump>()
                .HasOne(e => e.LmpellerMaterial)
                .WithMany()
                .HasForeignKey(e => e.LmpellerMaterialId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Pump>()
            //    .HasOne(e => e.Engine)
            //    .WithMany(p => p.Pumps);

            //modelBuilder.Entity<Engine>()
            //    .HasMany(p => p.Pumps)
            //    .WithOne(p => p.Engine);

            //modelBuilder.Entity<Material>()
            //    .HasMany(c => c.HousingMaterialPumps)
            //    .WithOne(p => p.HousingMaterial);

            //modelBuilder.Entity<Material>()
            //    .HasMany(p => p.LmpellerMaterialPumps)
            //    .WithOne(c => c.LmpellerMaterial);

            var pumpId = Guid.Parse("1f9631b1-76cf-42f7-bd64-aee4386c9cad");
            var engineId = Guid.Parse("88de934e-46ac-41f6-b72a-9a7ceb398d18");
            var housingMaterialId = Guid.Parse("d31c3852-9e03-4b8a-a518-e1d876118fae");
            var lmpellerMaterialId = Guid.Parse("b6962658-3f60-4456-8df0-190e3b214204");

            var engine = new Engine
            {
                Id = engineId,
                Name = "Трехфазный",
                Power = 3,
                Amperage = 16.9,
                RatedSpeed = 2900,
                Description = "Электродвигатель",
                Price = 1590,
            };

            var housingMaterial = new Material
            {
                Id = housingMaterialId,
                Name = "Материал корпуса",
                Description = "Материал корпуса",
            };
            var lmpellerMaterial = new Material
            {
                Id = lmpellerMaterialId,
                Name = "Материал колеса",
                Description = "Материал колеса",
            };

            var pump = new Pump
            {
                Id = pumpId,
                Name = "NOC 25/8 EM",
                MaxPressure = 10,
                LiquidTemperature = "-10,+110",
                Weight = 3.8,
                EngineId = engineId,
                HousingMaterialId = housingMaterialId,
                LmpellerMaterialId= lmpellerMaterialId,
                Description = "Трехскоростной циркуляционный насос",
                Image = "Изображение",
                Price = 13500,
            };

            modelBuilder.Entity<Engine>().HasData(engine); //создание таблицы Engines

            modelBuilder.Entity<Material>().HasData(housingMaterial, lmpellerMaterial); //создание таблицы Materials

            modelBuilder.Entity<Pump>().HasData(pump); //создание таблицы Pumps


        }
    }
}

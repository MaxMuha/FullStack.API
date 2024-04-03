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
                .WithMany(p => p.Pumps);

            modelBuilder.Entity<Engine>()
                .HasMany(p => p.Pumps)
                .WithOne(p => p.Engine);

            modelBuilder.Entity<Material>()
                .HasMany(c => c.HousingMaterialPumps)
                .WithOne(p => p.HousingMaterial);

            modelBuilder.Entity<Material>()
                .HasMany(p => p.LmpellerMaterialPumps)
                .WithOne(c => c.LmpellerMaterial);

            var pump1Id = Guid.Parse("1f9631b1-76cf-42f7-bd64-aee4386c9cad");
            var pump2Id = Guid.Parse("ed725738-d0e0-42e6-91c3-ba1fbae7f2ec");
            var pump3Id = Guid.Parse("914e3db4-0c95-436d-a9e8-72a9d236bef7");
            var pump4Id = Guid.Parse("93a74c8a-0e56-4c2e-bbd1-8e8c362e8c3b");
            var pump5Id = Guid.Parse("28e9e46e-88bc-4751-af0e-a75980d4e489");
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
                Name = "Чугун",
                Description = "Прочный материал",
            };

            var lmpellerMaterial = new Material
            {
                Id = lmpellerMaterialId,
                Name = "Материал колеса",
                Description = "Материал колеса",
            };

            var pump1 = new Pump
            {
                Id = pump1Id,
                Name = "NOC 25/8 EM",
                MaxPressure = 10,
                LiquidTemperature = "-10,+110",
                Weight = 3,
                EngineId = engineId,
                HousingMaterialId = housingMaterialId,
                LmpellerMaterialId= lmpellerMaterialId,
                Description = "Простой и надёжный циркуляционный насос с мокрым ротором.",
                Image = "https://cdn.vseinstrumenti.ru/images/goods/santehnicheskoe-oborudovanie/inzhenernaya-santehnika/12017849/560x504/154444745.jpg",
                Price = 11495,
            };

            var pump2 = new Pump
            {
                Id = pump2Id,
                Name = "NOC 65/12 DM",
                MaxPressure = 10,
                LiquidTemperature = "+110",
                Weight = 24,
                EngineId = engineId,
                HousingMaterialId = housingMaterialId,
                LmpellerMaterialId = lmpellerMaterialId,
                Description = "Циркуляционный насос для специализированных работ",
                Image = "https://cdn.vseinstrumenti.ru/images/goods/santehnicheskoe-oborudovanie/inzhenernaya-santehnika/8576907/560x504/99483939.jpg",
                Price = 53053,
            };

            var pump3 = new Pump
            {
                Id = pump3Id,
                Name = "NOC 50/16 DM",
                MaxPressure = 10,
                LiquidTemperature = "+110",
                Weight = 21,
                EngineId = engineId,
                HousingMaterialId = housingMaterialId,
                LmpellerMaterialId = lmpellerMaterialId,
                Description = "Простой и надёжный циркуляционный насос с мокрым ротором.",
                Image = "https://cdn.vseinstrumenti.ru/images/goods/santehnicheskoe-oborudovanie/inzhenernaya-santehnika/12017891/560x504/154444973.jpg",
                Price = 81227,
            };

            var pump4 = new Pump
            {
                Id = pump4Id,
                Name = "Yonos Pico 25/1-4",
                MaxPressure = 10,
                LiquidTemperature = "+95",
                Weight = 1.8,
                EngineId = engineId,
                HousingMaterialId = housingMaterialId,
                LmpellerMaterialId = lmpellerMaterialId,
                Description = "Высокоэффективный насос с электронной системой регулирования.",
                Image = "https://cdn.vseinstrumenti.ru/images/goods/santehnicheskoe-oborudovanie/inzhenernaya-santehnika/13016417/560x504/159541025.jpg",
                Price = 26412,
            };

            var pump5 = new Pump
            {
                Id = pump5Id,
                Name = "STAR-RS 25/6",
                MaxPressure = 10,
                LiquidTemperature = "-10,+110",
                Weight = 3.2,
                EngineId = engineId,
                HousingMaterialId = housingMaterialId,
                LmpellerMaterialId = lmpellerMaterialId,
                Description = "Циркуляционный насос с мокрым ротором для установки в трубах с ручной трехступенчатой регулировкой частоты вращения.",
                Image = "https://cdn.vseinstrumenti.ru/images/goods/santehnicheskoe-oborudovanie/inzhenernaya-santehnika/13172509/560x504/160317907.jpg",
                Price = 22010,
            };

            modelBuilder.Entity<Engine>().HasData(engine); //создание таблицы Engines

            modelBuilder.Entity<Material>().HasData(housingMaterial, lmpellerMaterial); //создание таблицы Materials

            modelBuilder.Entity<Pump>().HasData(pump1, pump2, pump3, pump4, pump5); //создание таблицы Pumps


        }
    }
}

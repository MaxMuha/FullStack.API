using FullStack.API.Models;
using WiloPump.Db.Models;

namespace FullStack.API.Helpers
{
    public static class Mapping
    {
        public static Pump ToPump(this PumpViewModel pumpViewModel)
        {
            return new Pump
            {
                Id = pumpViewModel.Id,
                Name = pumpViewModel.Name,
                MaxPressure = pumpViewModel.MaxPressure,
                LiquidTemperature = pumpViewModel.LiquidTemperature,
                Weight = pumpViewModel.Weight,

                EngineId = pumpViewModel.Engine.Id,
                Engine = pumpViewModel.Engine.ToEngine(),

                HousingMaterial = pumpViewModel.HousingMaterial.ToMaterial(),
                LmpellerMaterial = pumpViewModel.LmpellerMaterial.ToMaterial(),

                Description = pumpViewModel.Description,
                Image = pumpViewModel.Image,
                Price = pumpViewModel.Price,
            };
        }
        public static PumpViewModel ToPumpViewModel(this Pump pump)
        {
            return new PumpViewModel
            {
                Id = pump.Id,
                Name = pump.Name,
                MaxPressure = pump.MaxPressure,
                LiquidTemperature = pump.LiquidTemperature,
                Weight = pump.Weight,
                Engine = pump.Engine.ToEngineViewModel(),
                HousingMaterial = pump.HousingMaterial.ToMaterialViewModel(),
                LmpellerMaterial = pump.LmpellerMaterial.ToMaterialViewModel(),
                Description = pump.Description,
                Image = pump.Image,
                Price = pump.Price,
            };
        }
        public static List<PumpViewModel> ToProductViewModels(this List<Pump> pumps)
        {
            var pumpsViewModel = new List<PumpViewModel>();
            foreach (var pump in pumps)
            {
                pumpsViewModel.Add(pump.ToPumpViewModel());
            }
            return pumpsViewModel;
        }
        public static Engine ToEngine(this EngineViewModel engineViewModel)
        {
            return new Engine
            {
                Id = engineViewModel.Id,
                Name = engineViewModel.Name,
                Power = engineViewModel.Power,
                Amperage = engineViewModel.Amperage,
                RatedSpeed = engineViewModel.RatedSpeed,
                Description = engineViewModel.Description,
                Price = engineViewModel.Price,
            };
        }
        public static EngineViewModel ToEngineViewModel(this Engine engine)
        {
            return new EngineViewModel
            {
                Id = engine.Id,
                Name = engine.Name,
                Power = engine.Power,
                Amperage = engine.Amperage,
                RatedSpeed = engine.RatedSpeed,
                Description = engine.Description,
                Price = engine.Price,
            };
        }
        public static Material ToMaterial(this MaterialViewModel materialViewModel)
        {
            return new Material
            {
                Id = materialViewModel.Id,
                Name = materialViewModel.Name,
                Description = materialViewModel.Description,
            };
        }
        public static MaterialViewModel ToMaterialViewModel(this Material material)
        {
            return new MaterialViewModel
            {
                Id = material.Id,
                Name = material.Name,
                Description = material.Description,
            };
        }
    }
}


using WiloPump.Db.Models;

namespace FullStack.API.Models
{
    public class PumpViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MaxPressure { get; set; }
        public string LiquidTemperature { get; set; }
        public double Weight { get; set; }

        public EngineViewModel Engine { get; set; }

        public MaterialViewModel HousingMaterial { get; set; }
        public MaterialViewModel LmpellerMaterial { get; set; }

        public string Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
    }

}

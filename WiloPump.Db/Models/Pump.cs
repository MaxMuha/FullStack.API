using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WiloPump.Db.Models
{
    public class Pump
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MaxPressure { get; set; }
        public string LiquidTemperature { get; set; }
        public double Weight { get; set; }

        public Guid EngineId { get; set; }
        public Engine Engine { get; set; }

        public Guid HousingMaterialId { get; set; }
        public Material HousingMaterial { get; set; }

        public Guid LmpellerMaterialId { get; set; }
        public Material LmpellerMaterial { get; set; }

        public string Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
    }
}

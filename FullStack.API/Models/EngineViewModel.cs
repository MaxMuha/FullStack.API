using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStack.API.Models
{
    public class EngineViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public double Amperage { get; set; }
        public int RatedSpeed { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

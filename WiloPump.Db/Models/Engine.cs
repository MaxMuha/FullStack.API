using Microsoft.EntityFrameworkCore;

namespace WiloPump.Db.Models
{
    public class Engine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public double Amperage { get; set; }
        public int RatedSpeed { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<Pump> Pumps { get; set; }

        public Engine()
        {
            Pumps = new List<Pump>();
        }
    }
}


using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace WiloPump.Db.Models
{
    public class Material
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Pump> HousingMaterialPumps { get; set; }
        public List<Pump> LmpellerMaterialPumps { get; set; }

        public Material()
        {
            HousingMaterialPumps = new List<Pump>();
            LmpellerMaterialPumps = new List<Pump>();
        }
    }
}

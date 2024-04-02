using Microsoft.EntityFrameworkCore;
using WiloPump.Db;
using WiloPump.Db.Models;

public class PumpsDbRepository : IPumps
{
    private readonly DatabaseContext databaseContext;
    public PumpsDbRepository(DatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }
    public async Task<List<Pump>> GetAllAsync()
    {
        return await databaseContext.Pumps
            .Include(x => x.Engine)
            .Include(x => x.HousingMaterial)
            .Include(x => x.LmpellerMaterial)
            .ToListAsync();
    }
    public async Task AddAsync(Pump pump)
    {
        await databaseContext.Pumps.AddAsync(pump);
        await databaseContext.SaveChangesAsync();
    }
    public Pump? GetPump(Guid id)
    {
        return databaseContext.Pumps
            .Include(x => x.Engine)
            .Include(x => x.HousingMaterial)
            .Include(x => x.LmpellerMaterial)
            .FirstOrDefault(x => x.Id == id);
    }
    public async Task<Pump> UpdatePumpAsync(Pump pump, Pump newPump)
    {
        pump.Name = newPump.Name;
        pump.MaxPressure = newPump.MaxPressure;
        pump.LiquidTemperature = newPump.LiquidTemperature;
        pump.Weight = newPump.Weight;
        pump.Description = newPump.Description;
        pump.Image = newPump.Image;
        pump.Price = newPump.Price;

        pump.Engine.Name = newPump.Engine.Name;
        pump.Engine.Power = newPump.Engine.Power;
        pump.Engine.Amperage = newPump.Engine.Amperage;
        pump.Engine.RatedSpeed = newPump.Engine.RatedSpeed;
        pump.Engine.Description = newPump.Engine.Description;
        pump.Engine.Price = newPump.Engine.Price;

        pump.HousingMaterial.Name = newPump.HousingMaterial.Name;
        pump.HousingMaterial.Description = newPump.HousingMaterial.Description;

        pump.LmpellerMaterial.Name = newPump.LmpellerMaterial.Name;
        pump.LmpellerMaterial.Description = newPump.LmpellerMaterial.Description;

        await databaseContext.SaveChangesAsync();

        return pump;
    }
    public async Task RemoveAsync(Pump pump)
    {
        databaseContext.Pumps.Remove(pump);

        await databaseContext.SaveChangesAsync();
    }
}
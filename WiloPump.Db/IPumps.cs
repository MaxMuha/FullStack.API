using WiloPump.Db.Models;
using WiloPump.Db;

public interface IPumps
{
    Task<List<Pump>> GetAllAsync();
    Task AddAsync(Pump pump);
    Pump? GetPump(Guid id);
    Task<Pump?> UpdatePumpAsync(Pump pump, Pump newPump);
    Task RemoveAsync(Pump pump);
}